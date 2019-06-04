using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace DoubleGisGidClasses.Web.Models
{
    namespace DataAccessPostgreSqlProvider
    {
        public class DoubleGisGidDbContext : DbContext
        {
            public DoubleGisGidDbContext()
            {
                Database.EnsureCreated();
            }
            public DoubleGisGidDbContext(DbContextOptions<DoubleGisGidDbContext> options) : base(options)
            {

            }
            public DbSet<DbPlace> Places { get; set; }
            public static string ConnectionString { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(DoubleGisGidDbContext.ConnectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }

        /// <summary>
        /// То из чего состоит информация, представленная пользователю о выбранном месте
        /// </summary>
        public class DbPlace
        {
            public DbPlace(Place Place)
            {
                Name = Place.Name;
                MainPhoto = Place.MainPhoto;
                RegistrationDate = Place.RegistrationDate;
                Likes = Place.Likes;
                Dislikes = Place.Dislikes;                
            }
            public DbPlace() { }

            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            
            public string Name { get; set; }
            
            public string Likes { get; set; }
            
            public string Dislikes { get; set; }

            public DbInformation DbInformation { get; set; }

            public byte[] MainPhoto { get; set; }
            
            public DateTime RegistrationDate { get; set; }

            public List<string> PhoneNumber { get; set; }

            public List<string> SocialContacts { get; set; }
        }
        public class DbInformation
        {
            public DbInformation() { }
            public DbInformation(Information information)
            {
                SpokesmanName = information.SpokesmanName;
                Discription = information.Discription;
                City = information.City;
                Region = information.Region;
                NameOfStreet = information.NameOfStreet;
                NumberOfStreet = information.NumberOfStreet;
            }

            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int PlaceId { get; set; }
            [ForeignKey("PlaceId")]
            public virtual DbPlace Place { get; set; }

            
            public string SpokesmanName { get; set; }

            
            public string Discription { get; set; }

            
            public string City { get; set; }

            
            public string Region { get; set; }

            
            public string NameOfStreet { get; set; }

            
            public double NumberOfStreet { get; set; }
        }
    }
}


