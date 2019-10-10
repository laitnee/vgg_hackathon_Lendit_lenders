﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lendit.Data;

namespace lendit.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190708092608_initial migration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("lendit.Model.Eligibility", b =>
                {
                    b.Property<int>("EligibilityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BVN");

                    b.Property<string>("NIN");

                    b.Property<string>("Status");

                    b.Property<string>("UserHash");

                    b.Property<string>("VCN");

                    b.HasKey("EligibilityId");

                    b.HasIndex("UserHash")
                        .IsUnique();

                    b.ToTable("Eligibilities");
                });

            modelBuilder.Entity("lendit.Model.LenderBorrowerTransaction", b =>
                {
                    b.Property<int>("LenderBorrowerTransactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("BorrowHash");

                    b.Property<string>("LenderHash");

                    b.Property<string>("Status");

                    b.HasKey("LenderBorrowerTransactionId");

                    b.HasIndex("BorrowHash");

                    b.HasIndex("LenderHash");

                    b.ToTable("LenderBorrowerTransactions");
                });

            modelBuilder.Entity("lendit.Model.LenderPool", b =>
                {
                    b.Property<int>("LenderPoolId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("InterestRate");

                    b.Property<string>("LenderHash");

                    b.Property<string>("Notes");

                    b.Property<string>("Status");

                    b.HasKey("LenderPoolId");

                    b.HasIndex("LenderHash");

                    b.ToTable("LenderPools");
                });

            modelBuilder.Entity("lendit.Model.Logger", b =>
                {
                    b.Property<int>("LoggerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ErrorDate");

                    b.Property<string>("ErrorDetails");

                    b.Property<string>("ErrorType");

                    b.HasKey("LoggerId");

                    b.ToTable("Loggers");
                });

            modelBuilder.Entity("lendit.Model.TransactionEntity", b =>
                {
                    b.Property<int>("TransactionEntityId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<string>("UserHash");

                    b.HasKey("TransactionEntityId");

                    b.HasIndex("UserHash");

                    b.ToTable("TransactionEntities");
                });

            modelBuilder.Entity("lendit.Model.User", b =>
                {
                    b.Property<string>("UserHash")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<string>("AccountNo");

                    b.Property<string>("Bank");

                    b.Property<double>("CreditScore");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("UserHashEx");

                    b.HasKey("UserHash");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("lendit.Model.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Balance");

                    b.Property<string>("PrivateKey");

                    b.Property<string>("PublicKey");

                    b.Property<string>("UserHash");

                    b.Property<string>("WalletHash");

                    b.HasKey("WalletId");

                    b.HasIndex("UserHash")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("lendit.Model.Eligibility", b =>
                {
                    b.HasOne("lendit.Model.User", "User")
                        .WithOne("Eligibility")
                        .HasForeignKey("lendit.Model.Eligibility", "UserHash");
                });

            modelBuilder.Entity("lendit.Model.LenderBorrowerTransaction", b =>
                {
                    b.HasOne("lendit.Model.User", "Borrower")
                        .WithMany("BorrowerTransaction")
                        .HasForeignKey("BorrowHash");

                    b.HasOne("lendit.Model.User", "Lender")
                        .WithMany("LenderTransaction")
                        .HasForeignKey("LenderHash");
                });

            modelBuilder.Entity("lendit.Model.LenderPool", b =>
                {
                    b.HasOne("lendit.Model.User", "Lender")
                        .WithMany("LenderPool")
                        .HasForeignKey("LenderHash");
                });

            modelBuilder.Entity("lendit.Model.TransactionEntity", b =>
                {
                    b.HasOne("lendit.Model.User", "User")
                        .WithMany("TransactionEntity")
                        .HasForeignKey("UserHash");
                });

            modelBuilder.Entity("lendit.Model.Wallet", b =>
                {
                    b.HasOne("lendit.Model.User", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("lendit.Model.Wallet", "UserHash");
                });
#pragma warning restore 612, 618
        }
    }
}