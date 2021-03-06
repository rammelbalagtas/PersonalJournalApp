// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalJournal.MVCApp.Data;

namespace PersonalJournal.MVCApp.Migrations
{
    [DbContext(typeof(PersonalJournalDBContext))]
    partial class PersonalJournalDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalJournal.Models.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PersonalJournal.Models.Models.JournalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MoodId")
                        .HasColumnType("int");

                    b.Property<int?>("SubsectionId1")
                        .HasColumnType("int");

                    b.Property<int?>("SubsectionId2")
                        .HasColumnType("int");

                    b.Property<int?>("SubsectionId3")
                        .HasColumnType("int");

                    b.Property<int?>("SubsectionId4")
                        .HasColumnType("int");

                    b.Property<int?>("SubsectionId5")
                        .HasColumnType("int");

                    b.Property<string>("SubsectionText1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubsectionText2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubsectionText3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubsectionText4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubsectionText5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MoodId");

                    b.HasIndex("SubsectionId1");

                    b.HasIndex("SubsectionId2");

                    b.HasIndex("SubsectionId3");

                    b.HasIndex("SubsectionId4");

                    b.HasIndex("SubsectionId5");

                    b.ToTable("JournalEntries");
                });

            modelBuilder.Entity("PersonalJournal.Models.Models.Mood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Moods");
                });

            modelBuilder.Entity("PersonalJournal.Models.Models.Subsection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Subsections");
                });

            modelBuilder.Entity("PersonalJournal.Models.Models.JournalEntry", b =>
                {
                    b.HasOne("PersonalJournal.Models.Models.Category", "Category")
                        .WithMany("JournalEntries")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalJournal.Models.Models.Mood", "Mood")
                        .WithMany("JournalEntries")
                        .HasForeignKey("MoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalJournal.Models.Models.Subsection", "Subsection1")
                        .WithMany()
                        .HasForeignKey("SubsectionId1");

                    b.HasOne("PersonalJournal.Models.Models.Subsection", "Subsection2")
                        .WithMany()
                        .HasForeignKey("SubsectionId2");

                    b.HasOne("PersonalJournal.Models.Models.Subsection", "Subsection3")
                        .WithMany()
                        .HasForeignKey("SubsectionId3");

                    b.HasOne("PersonalJournal.Models.Models.Subsection", "Subsection4")
                        .WithMany()
                        .HasForeignKey("SubsectionId4");

                    b.HasOne("PersonalJournal.Models.Models.Subsection", "Subsection5")
                        .WithMany()
                        .HasForeignKey("SubsectionId5");

                    b.Navigation("Category");

                    b.Navigation("Mood");

                    b.Navigation("Subsection1");

                    b.Navigation("Subsection2");

                    b.Navigation("Subsection3");

                    b.Navigation("Subsection4");

                    b.Navigation("Subsection5");
                });

            modelBuilder.Entity("PersonalJournal.Models.Models.Category", b =>
                {
                    b.Navigation("JournalEntries");
                });

            modelBuilder.Entity("PersonalJournal.Models.Models.Mood", b =>
                {
                    b.Navigation("JournalEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
