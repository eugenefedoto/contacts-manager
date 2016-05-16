using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ContactsManagerV3.Models;

namespace ContactsManagerV3.Migrations
{
    [DbContext(typeof(ManagerContext))]
    [Migration("20160516030447_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactsManagerV3.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BirthDate");

                    b.Property<string>("Comments");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("ProfileImagePath");

                    b.Property<bool>("isAssociate");

                    b.Property<bool>("isColleague");

                    b.Property<bool>("isFamily");

                    b.Property<bool>("isFriend");

                    b.HasKey("Id");
                });
        }
    }
}
