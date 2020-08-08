using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace WebApp.Public
{
    public class RestClient
    {
        public string EndPoint { get; set; }
        public Enums.HttpVerb HttpMethod { get; set; }
        public Enums.AuthenticationType AuthType { get; set; }
        public Enums.AutheticationTechnique AuthTech { get; set; }
        public string AuthorizationUserName { get; set; }
        public string AuthorizationPassword { get; set; }
        public string ServiceAuthorizationUserName { get; set; }
        public string ServiceAuthorizationPassword { get; set; }
        public string AuthorizationToken { get; set; }
        public string PostJSON { get; set; }
        private string Params { set; get; }
        private string Directory { set; get; }

        public RestClient()
        {
            EndPoint = string.Empty;
            HttpMethod = Enums.HttpVerb.GET;
        }

        public void SetParams(Dictionary<string,string> inputParams)
        {
            Params = "";

            foreach (var key in inputParams.Keys)
            {
                if (!String.IsNullOrEmpty(Params))
                    Params += "&";
                else
                    Params = "?";

                Params += key+"="+inputParams[key];
            }
        }

        public void SetDirectory(List<string> inputDirectory)
        {
            Directory = "";

            foreach (var val in inputDirectory)
            {
                Directory += ("/" + val);
            }
        }

        public string MakeRequest()
        {
            
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint+Directory+Params);
            
            request.Method = HttpMethod.ToString();

            try
            {
                if (AuthorizationUserName.Any() || AuthorizationPassword.Any() && AuthType!= Enums.AuthenticationType.Bearer)
                {
                    String authHeaer = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(AuthorizationUserName + ":" + AuthorizationPassword));
                    request.Headers.Add("Authorization", "Basic " + authHeaer);
                }

                if (ServiceAuthorizationUserName.Any() || ServiceAuthorizationPassword.Any() && AuthType != Enums.AuthenticationType.Bearer)
                {
                    String authHeaerService = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(ServiceAuthorizationUserName + ":" + ServiceAuthorizationPassword));
                    request.Headers.Add("ServiceAuthorization", authHeaerService);
                }

                if (AuthType == Enums.AuthenticationType.Bearer && AuthorizationToken.Any())
                {
                    request.Headers.Add("Authorization", "Bearer " + AuthorizationToken);
                }
            }
            catch { }

            try
            {
                if (request.Method == "POST" && PostJSON != string.Empty)
                {
                    request.ContentType = "application/json";
                    using (StreamWriter swJSONPayload = new StreamWriter(request.GetRequestStream()))
                    {
                        swJSONPayload.Write(PostJSON);

                        swJSONPayload.Close();
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }

            HttpWebResponse response = null;

            try
            {
                //Turn Off Validat ssl
                request.ServerCertificateValidationCallback = delegate (
                Object obj, X509Certificate certificate, X509Chain chain,
                SslPolicyErrors errors)
                {
                    return (true);
                };
                response = (HttpWebResponse)request.GetResponse();

                
                //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                            //strResponseValue += "\n{\"Status\":[\"" + response.StatusCode + "\"],\"StatusCode\":{"+ (int)response.StatusCode + "}}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
                
                try
                {
                    StreamWriter sw = null;

                    if (PostJSON != null)
                    {
                        sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\postJSONLog.txt", true);
                        sw.WriteLine(String.Format(@"(postJSON = {0}, URL = {1}, DateTime= {2}, Response={3})" ,PostJSON ,EndPoint ,DateTime.Now , strResponseValue ?? "null"));
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch { }

            }

            return strResponseValue;
        }

        public WebResponse MakeRequestGetFile()
        {
            try
            {
                 //Get File
                HttpWebRequest FileRequest = (HttpWebRequest)WebRequest.Create(Path.Combine(EndPoint+Directory)+Params);
                
                return FileRequest.GetResponse();
            }
            catch
            {
                return null;
            }
        }
        
    }
}
