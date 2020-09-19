﻿// <auto-generated />
using System;
using CpntextLib.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CookBookMVC.Migrations
{
    [DbContext(typeof(CookBookContext))]
    [Migration("20200916214416_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CookBookMVC.Models.Image", b =>
                {
                    b.Property<string>("ImageId")
                        .HasColumnType("text");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("ImageId");

                    b.ToTable("ImageModels");
                });

            modelBuilder.Entity("CookBookMVC.Models.ImageIngredient", b =>
                {
                    b.Property<string>("ImageId")
                        .HasColumnType("text");

                    b.Property<string>("IngredientId")
                        .HasColumnType("text");

                    b.HasKey("ImageId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("ImageIngredients");
                });

            modelBuilder.Entity("CookBookMVC.Models.ImageRecipe", b =>
                {
                    b.Property<string>("ImageId")
                        .HasColumnType("text");

                    b.Property<string>("RecipeId")
                        .HasColumnType("text");

                    b.HasKey("ImageId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("ImageRecipes");
                });

            modelBuilder.Entity("CookBookMVC.Models.Ingredient", b =>
                {
                    b.Property<string>("IngredientId")
                        .HasColumnType("text");

                    b.Property<string>("Energy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("IngredientId");

                    b.ToTable("IngredientModels");
                });

            modelBuilder.Entity("CookBookMVC.Models.IngredientCount", b =>
                {
                    b.Property<string>("RecipeCountId")
                        .HasColumnType("text");

                    b.Property<int?>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("IngredientId")
                        .HasColumnType("text");

                    b.HasKey("RecipeCountId");

                    b.HasIndex("IngredientId")
                        .IsUnique();

                    b.ToTable("IngredientCount");
                });

            modelBuilder.Entity("CookBookMVC.Models.Recipe", b =>
                {
                    b.Property<string>("RecipeId")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("RecipeId");

                    b.ToTable("RecipeModels");
                });

            modelBuilder.Entity("CookBookMVC.Models.ImageIngredient", b =>
                {
                    b.HasOne("CookBookMVC.Models.Image", "Image")
                        .WithMany("ImageIngredients")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookBookMVC.Models.Ingredient", "Ingredient")
                        .WithMany("ImageIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CookBookMVC.Models.ImageRecipe", b =>
                {
                    b.HasOne("CookBookMVC.Models.Image", "Image")
                        .WithMany("ImageRecepies")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookBookMVC.Models.Recipe", "Recipe")
                        .WithMany("ImageRecipes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CookBookMVC.Models.Ingredient", b =>
                {
                    b.HasOne("CookBookMVC.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CookBookMVC.Models.IngredientCount", b =>
                {
                    b.HasOne("CookBookMVC.Models.Ingredient", "Ingredient")
                        .WithOne("IngredientCount")
                        .HasForeignKey("CookBookMVC.Models.IngredientCount", "IngredientId");
                });
#pragma warning restore 612, 618
        }
    }
}
