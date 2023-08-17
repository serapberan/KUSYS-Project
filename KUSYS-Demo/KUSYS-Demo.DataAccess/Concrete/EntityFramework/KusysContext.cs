using KUSYS_Demo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.DataAccess.Concrete.EntityFramework
{
    /// <summary>
    /// Context --> VT ile Classlarımızı birlestirdigimiz ve baglantı yaptıgımız alandır.
    /// </summary>
    public class KusysContext : DbContext
    {
        //-----Vertabanını tanıt
        /// <summary>
        /// VT Baglantı bilgilerimiz 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SERAPBERAN\\SQLEXPRESS;Database=DbKusysCase;Integrated Security=True");
        }

        //------Tabloları tanıt
        /// <summary>
        /// DbSet --> VT icin  Classlarımızın hangi tablo olarak oluşacagını belirtiyoruz.
        /// </summary>
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

       
    }
}
