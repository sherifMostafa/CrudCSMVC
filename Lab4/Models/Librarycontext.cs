using System;
using System.Data.Entity;
using System.Linq;

namespace Lab4.Models
{
    public class Librarycontext : DbContext
    {
        // Your context has been configured to use a 'Librarycontext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Lab4.Models.Librarycontext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Librarycontext' 
        // connection string in the application configuration file.
        public Librarycontext()
            : base("name=Librarycontext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<books> Books { get; set; }
        public virtual DbSet<users> Users { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<catalog> Catalogs { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}