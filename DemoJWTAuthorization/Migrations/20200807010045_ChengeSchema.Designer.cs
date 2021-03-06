﻿// <auto-generated />
using System;
using DemoJWTAuthorization.Models.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoJWTAuthorization.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200807010045_ChengeSchema")]
    partial class ChengeSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoJWTAuthorization.Models.DAL.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("FialedRepeat")
                        .HasColumnType("int");

                    b.Property<short>("InheritTypeID")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("LastFialed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastPasswordChanges")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("PersonID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("Account","SSO");
                });

            modelBuilder.Entity("DemoJWTAuthorization.Models.DAL.Person", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(2048)")
                        .HasMaxLength(2048);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CityID")
                        .HasColumnType("bigint");

                    b.Property<string>("EconomicCode")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int?>("Education")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("FieldActivity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<short?>("Gilder")
                        .HasColumnType("smallint");

                    b.Property<short?>("GovernmentSharePercentage")
                        .HasColumnType("smallint");

                    b.Property<string>("GroupType")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<string>("LegalDocumentation")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<short?>("LegalTypeID")
                        .HasColumnType("smallint");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<short?>("MaritalStatus")
                        .HasColumnType("smallint");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<short?>("Nationality")
                        .HasColumnType("smallint");

                    b.Property<bool?>("OrganizationEmployee")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<byte?>("RelationshipTypeId")
                        .HasColumnType("tinyint");

                    b.Property<short?>("Religion")
                        .HasColumnType("smallint");

                    b.Property<string>("SabtCode")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("SabtDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Sex")
                        .HasColumnType("bit");

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Study")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool?>("TransferList")
                        .HasColumnType("bit");

                    b.Property<short?>("TypeGovernmentCompanyID")
                        .HasColumnType("smallint");

                    b.Property<short>("TypeID")
                        .HasColumnType("smallint");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("fax")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<long?>("provinceID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Role","SSO");
                });

            modelBuilder.Entity("DemoJWTAuthorization.Models.DAL.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentRoleID")
                        .HasColumnType("int");

                    b.Property<string>("TitleEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("TitleFa")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("ID");

                    b.HasIndex("ParentRoleID");

                    b.ToTable("Roles","SSO");
                });

            modelBuilder.Entity("DemoJWTAuthorization.Models.DAL.Account", b =>
                {
                    b.HasOne("DemoJWTAuthorization.Models.DAL.Person", "Person")
                        .WithMany("Accounts")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DemoJWTAuthorization.Models.DAL.Role", b =>
                {
                    b.HasOne("DemoJWTAuthorization.Models.DAL.Role", "Role1")
                        .WithMany("Roles1")
                        .HasForeignKey("ParentRoleID");
                });
#pragma warning restore 612, 618
        }
    }
}
