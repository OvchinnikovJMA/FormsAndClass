﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Sirea.Models
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
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            /// <summary>
            /// Название места
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Рейтинг места, составляемый пользователями
            /// </summary>
            public DbRating Rating { get; set; }
            /// <summary>
            /// Информация о месте
            /// </summary>
            public DbInformation Information { get; set; }
            /// <summary>
            /// Фото(путь, где хранится фото)
            /// </summary>
            public byte[] MainPhoto { get; set; }
            /// <summary>
            /// Контакты с местом
            /// </summary>
            public DbContacts Contacts { get; set; }
            /// <summary>
            /// Комментарии пользователей о месте
            /// </summary>
            public DateTime RegistrationDate { get; set; }
            public override string ToString()
            {
                return $"Название: {Name} ; Лайки: {Rating.Likes.ToString()} ; Дизлайки: {Rating.Dislikes.ToString()} ";
            }
        }
        /// <summary>
        /// Контакты с представителями места
        /// </summary>
        public class DbContacts
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int PlaceId { get; set; }
            [ForeignKey("PlaceId")]
            public virtual DbPlace Place { get; set; }
            /// <summary>
            /// Номера телефона представителей места(при необходимости)
            /// </summary>
            public List<string> PhoneNumber { get; set; }
            /// <summary>
            /// Ссылки на соц.сети
            /// </summary>
            public List<string> SocialContacts { get; set; }
            public string DoNumbers()
            {
                var result = "";
                foreach (var number in PhoneNumber)
                {
                    result += $"{number} ;";
                }
                return result;
            }
            public string DoContacts()
            {
                var result = "";
                foreach (var number in PhoneNumber)
                {
                    result += $"{number} ;";
                }
                return result;
            }
        }
        /// <summary>
        /// Информация о месте, которую сооставляет представитель
        /// </summary>
        public class DbInformation
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int PlaceId { get; set; }
            [ForeignKey("PlaceId")]
            public virtual DbPlace Place { get; set; }
            /// <summary>
            /// Имя предсавителя места
            /// </summary>
            public string SpokesmanName { get; set; }
            /// <summary>
            /// Описание, составляемое представителем места
            /// </summary>
            public string Discription { get; set; }
            /// <summary>
            /// Список Адресов места
            /// </summary>
            public DbAddress Address { get; set; }
        }
        /// <summary>
        /// Адрес места
        /// </summary>
        public class DbAddress
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int PlaceId { get; set; }
            [ForeignKey("PlaceId")]
            public virtual DbPlace Place { get; set; }
            /// <summary>
            /// Город, где находится место
            /// </summary>
            public string City { get; set; }
            /// <summary>
            /// Регион места
            /// </summary>
            public string Region { get; set; }
            public DbStreet Street { get; set; }
        }
        /// <summary>
        /// Улица
        /// </summary>
        public class DbStreet
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int PlaceId { get; set; }
            [ForeignKey("PlaceId")]
            public virtual DbPlace Place { get; set; }
            public double Number { get; set; }
            public string Name { get; set; }
        }
        /// <summary>
        /// Оценка места
        /// </summary>
        public class DbRating
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int PlaceId { get; set; }
            [ForeignKey("PlaceId")]
            public virtual DbPlace Place { get; set; }
            public int Likes { get; set; }
            public int Dislikes { get; set; }
        }
    }
}
