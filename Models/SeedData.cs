using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Dragon Ball",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Fighter",
                        Rating ="r",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "Doremon",
                        ReleaseDate = DateTime.Parse("1979-5-10"),
                        Genre = "Romantic Comedy",
                        Rating ="r",
                        Price = 3.99M
                    },
                    new Movie
                    {
                        Title = "Harry Poter",
                        ReleaseDate = DateTime.Parse("1998-12-12"),
                        Genre = "Romantic Fighter",
                        Rating ="r",
                        Price = 7.99M
                    },
                    new Movie
                    {
                        Title = "68",
                        ReleaseDate = DateTime.Parse("2020-10-10"),
                        Genre = "Mecha Drama",
                        Rating ="r",
                        Price = 8.99M
                    },
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating ="r",
                        Price = 7.99M,
                        
                    }
                );

                // Student
                if (context.Student.Any())
                {
                    return;   // DB has been seeded
                }

                context.Student.AddRange(
                    new Student
                    {
                        StudentId = "1",
                        StudentName = "Dang Van Duc",
                        Address = "Thai Binh"
                    },
                    new Student
                    {
                        StudentId = "2",
                        StudentName = "Tran Duc Vinh",
                        Address = "Hà Nội"
                    },
                    new Student
                    {
                        StudentId = "3",
                        StudentName = "Dao Thoai Huyen Nhi",
                        Address = "Hà Nội"
                    },
                    new Student
                    {
                        StudentId = "4",
                        StudentName = "Dinh Quan Dai",
                        Address = "Hà Nội"
                    },
                    new Student
                    {
                        StudentId = "5",
                        StudentName = "Bui Khac Quan",
                        Address = "Hà Nội"
                    }
                );

                // Person
                if (context.Person.Any())
                {
                    return;   // DB has been seeded
                }

                context.Person.AddRange(
                    new Person
                    {
                        PersonId = "1",
                        PersonName = "Dang Van Duc"
                    },
                    new Person
                    {
                        PersonId = "2",
                        PersonName = "Tran Duc Vinh"
                    },
                    new Person
                    {
                        PersonId = "3",
                        PersonName = "Dao Thoai Huyen NHi"
                    },
                    new Person
                    {
                        PersonId = "4",
                        PersonName = "Dinh Quang Dai"
                    },
                    new Person
                    {
                        PersonId = "5",
                        PersonName = "Bui Khac Quan"
                    }
                );

                // Employee
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
                    new Employee
                    {
                        EmployeeID = "1",
                        EmployeeName = "Dang Vna Duc",
                        PhoneNumber = 0123456789
                    },
                    new Employee
                    {
                        EmployeeID = "2",
                        EmployeeName = "Tran Duc Vinh",
                        PhoneNumber = 0123456789
                    },
                    new Employee
                    {
                        EmployeeID = "3",
                        EmployeeName = "Dao Thoai Huyen Nhi",
                        PhoneNumber = 0123456789
                    },
                    new Employee
                    {
                        EmployeeID = "4",
                        EmployeeName = "Dinh Quang Dai",
                        PhoneNumber = 0123456789
                    },
                    new Employee
                    {
                        EmployeeID = "5",
                        EmployeeName = "Bui Khac QUan",
                        PhoneNumber = 0123456789
                    }
                );

                // Product
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        ProductId = "1",
                        ProductName = "ao khoac",
                        UnitPrice = 1,
                        Quantity = 10000
                    },
                    new Product
                    {
                        ProductId = "2",
                        ProductName = "ao so mi",
                        UnitPrice = 2,
                        Quantity = 15000
                    },
                    new Product
                    {
                        ProductId = "3",
                        ProductName = "quan dai",
                        UnitPrice = 3,
                        Quantity = 30000
                    },
                    new Product
                    {
                        ProductId = "4",
                        ProductName = "ao ohong",
                        UnitPrice = 4,
                        Quantity = 40000
                    },
                    new Product
                    {
                        ProductId = "5",
                        ProductName = "quan dui",
                        UnitPrice = 5,
                        Quantity = 5000
                    }
                );

                context.SaveChanges();
            }
        }
    }
}