using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ContactsManagerV3.Models;

namespace ContactsManagerV3.Migrations
{
    [DbContext(typeof(ManagerContext))]
    partial class ManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactsManagerV3.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BirthDate");

                    b.Property<string>("Comments")
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Key");

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
