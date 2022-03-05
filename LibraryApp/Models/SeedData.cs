using System;
using System.Linq;
using AutoMapper.Internal;
using LibraryApp;
using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Models
{
    public static class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            await using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            using var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!roleManager.Roles.Any())
            {
                var roles = new[]
                {
                    RolesConstants.Owner,
                    RolesConstants.StoreManager,
                    RolesConstants.User
                };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            if (context.MembershipTypes.Any())
            {
                Console.WriteLine("Database already seeded");
                return;
            }

            context.MembershipTypes.AddRange(
                new MembershipType
                {
                    Id = 1,
                    Name = "membershiptype1",
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0
                },
                new MembershipType
                {
                    Id = 2,
                    Name = "membershiptype2",
                    SignUpFee = 10,
                    DurationInMonths = 1,
                    DiscountRate = 8
                },
                new MembershipType
                {
                    Id = 3,
                    Name = "membershiptype3",
                    SignUpFee = 100,
                    DurationInMonths = 5,
                    DiscountRate = 14
                },
                new MembershipType
                {
                    Id = 4,
                    Name = "membershiptype4",
                    SignUpFee = 3000,
                    DurationInMonths = 17,
                    DiscountRate = 18
                });

            context.Rentals.AddRange(
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 1,
                        Name = "Customer1"
                    },
                    Book = new Book
                    {
                        AuthorName = "author1",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 1,
                        Name = "Name1",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                },
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 1,
                        Name = "Customer2"
                    },
                    Book = new Book
                    {
                        AuthorName = "author2",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 2,
                        Name = "Name2",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                },
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 3,
                        Name = "Customer3"
                    },
                    Book = new Book
                    {
                        AuthorName = "author3",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 3,
                        Name = "Name3",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                }
                );

            await context.SaveChangesAsync();
        }

    }
}