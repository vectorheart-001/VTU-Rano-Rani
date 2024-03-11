using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ApiProject.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System.Reflection.Emit;
using ApiProject.Domain.Enums;

namespace ApiProject.Infrastructure
{
    public class ApiAppContext : DbContext
    {
        public ApiAppContext()
        { 
        }
        public ApiAppContext(DbContextOptions<ApiAppContext> dbContext):base(dbContext) 
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
       
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Major>()
                .HasKey(x => x.Id);
            builder.Entity<Major>().HasData(
            new Major { Id = "000", Name = "None", PlacesLeft = 0, PaymentType = "None", Type = "None" },
            new Major { Id = "004", Name = "Археология", PlacesLeft = 3, PaymentType = "Държавна поръчка", Type = "Задочно" },
            new Major { Id = "044", Name = "Балканистика", PlacesLeft = 5, PaymentType = "Държавна поръчка", Type = "Редовно" },
            new Major { Id = "018", Name = "Българска филология", PlacesLeft = 2, PaymentType = "Държавна поръчка", Type = "Задочно" },
            new Major { Id = "005", Name = "География", PlacesLeft = 4, PaymentType = "Държавна поръчка", Type = "Редовно" },
            new Major { Id = "045", Name = "Германистика", PlacesLeft = 1, PaymentType = "Държавна поръчка", Type = "Задочно" },
            new Major { Id = "703", Name = "Дипломация и международни отношения", PlacesLeft = 7, PaymentType = "Платено обучение", Type = "Редовно" },
            new Major { Id = "702", Name = "Дипломация и международни отношения", PlacesLeft = 7, PaymentType = "Платено обучение", Type = "Задочно" },
            new Major { Id = "007", Name = "Етнология", PlacesLeft = 4, PaymentType = "Държавна поръчка", Type = "Редовно" },
            new Major { Id = "698", Name = "Журналистика", PlacesLeft = 2, PaymentType = "Платено обучение", Type = "Задочно" },
            new Major { Id = "074", Name = "Изящни изкуства – живопис", PlacesLeft = 1, PaymentType = "Държавна поръчка", Type = "Редовно" },
            new Major { Id = "075", Name = "Изящни изкуства – рисуване и интермедия", PlacesLeft = 1, PaymentType = "Държавна поръчка", Type = "Задочно" },
            new Major { Id = "077", Name = "Изящни изкуства – стенопис", PlacesLeft = 1, PaymentType = "Държавна поръчка", Type = "Редовно" },
            new Major { Id = "057", Name = "Информационно брокерство и дигитални медии", PlacesLeft = 1, PaymentType = "Държавна поръчка", Type = "Задочно" },
            new Major { Id = "003", Name = "История", PlacesLeft = 2, PaymentType = "Държавна поръчка", Type = "Редовно" },
            new Major { Id = "203", Name = "История", PlacesLeft = 7603, PaymentType = "Държавна поръчка", Type = "Задочно" },
            new Major { Id = "059", Name = "Компютърни науки", PlacesLeft = 11, PaymentType = "Държавна поръчка", Type = "Редовно" },
            new Major { Id = "008", Name = "Културен туризъм", PlacesLeft = 3, PaymentType = "Държавна поръчка", Type = "Задочно" },
            new Major { Id = "653", Name = "Международни икономически отношения", PlacesLeft = 13, PaymentType = "Платено обучение", Type = "Редовно" },
            new Major { Id = "066", Name = "Начална училищна педагогика и специална педагогика (Велико Търново)", PlacesLeft = 1, PaymentType = "Държавна поръчка", Type = "Задочно" },
            new Major { Id = "015", Name = "Педагогика на обучението по български език и география", PlacesLeft = 1, PaymentType = "Държавна поръчка", Type = "Редовно" },
            new Major { Id = "215", Name = "Педагогика на обучението по български език и география", PlacesLeft = 1, PaymentType = "Държавна поръчка", Type = "Задочно" }
            );


        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer("INSERT DATA SOURCE");
        }
    }
        
    }

