using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ContactsManagerV3.Models;

namespace ContactsManagerV3.Migrations
{
    [DbContext(typeof(ManagerContext))]
    [Migration("20160512000853_InitialDatabase")]
    partial class InitialDatabase
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

                    b.Property<bool>("Associate");

                    b.Property<string>("BirthDate");

                    b.Property<bool>("Colleague");

                    b.Property<string>("Comments");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<bool>("Family");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("Friend");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("ProfileImagePath");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ContactsManagerV3.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContactId");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ContactsManagerV3.Models.Group", b =>
                {
                    b.HasOne("ContactsManagerV3.Models.Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });
        }
    }
}
