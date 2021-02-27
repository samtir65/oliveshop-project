using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OliveShop.Models;

namespace OliveShop.Data
{
    public class OliveshopContext:DbContext
    {
        public OliveshopContext(DbContextOptions<OliveshopContext> options):base(options)
        {

        }
        
       public DbSet<Category> categories { get; set; }
       public DbSet<Item> items { get; set; }
       public DbSet<Product> Products { get; set; }
       public DbSet<CategoritoProduct> CategoritoProducts { get; set; }
       public DbSet<User> Users { get; set; }
       
       public DbSet<OrderDetails> orderDetails { get; set; }
       public DbSet <order> Orders { get; set; }


     
       protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<CategoritoProduct>()
            .HasKey(keyExpression: cp =>new{cp.CategoryId,cp.ProductID});
            modelBuilder.Entity<Product>(p=>
            {
                p.HasKey(p=>p.ProductID);
                p.HasOne<Item>(w=>w.item).WithOne(w=>w.product).HasForeignKey<Item>(w=>w.ItemId);
                p.Property(p=>p.ProductName).HasMaxLength(200);
                p.Property(p=>p.Description).HasMaxLength(500);

            }
            
            );
        
            modelBuilder.Entity<Item>(i=>{
              i.Property(i=>i.Price).HasColumnType("money");
              i.HasKey(i=>i.ItemId);

            });
                modelBuilder.Entity<Category>(c=>{
                  c.HasKey(c=>c.CategoryId);
                  c.Property(c=>c.Name).HasMaxLength(200);
                  c.Property(c=>c.Description).HasMaxLength(500);

                });
        modelBuilder.Entity<OrderDetails>(or=>{
        or.Property(or=>or.Price).HasColumnType("money");});

              #region seeddate
            modelBuilder.Entity<Category>().HasData(new Category{
            CategoryId=1,
            Description="گروه لباسهای ورزشی",
            Name="لباسهاس ورزشی"
        

            },
             new Category
        {
            CategoryId=2,
            Description="گروه لوازم خانگی",
            Name="لوازم خانگی"
        }
       );
       modelBuilder.Entity<Item>().HasData(new 
       Item{
           ItemId=1,
           Price=5000,
           QuantitiInStock=100

       });
        modelBuilder.Entity<Item>().HasData(new 
       Item{
           ItemId=2,
           Price=3000,
           QuantitiInStock=60

       });
        modelBuilder.Entity<Item>().HasData(new 
       Item{
           ItemId=3,
           Price=4000,
           QuantitiInStock=40

       });
        modelBuilder.Entity<Product>().HasData(new 
       Product{
            ProductID=1,
            ItemId=1,
            ProductName="محصول شماره 1",
            Description="mahsol"

       });
         modelBuilder.Entity<Product>().HasData(new 
       Product{
            ProductID=2,
            ItemId=2,
            ProductName="محصول شماره 2",
            Description="mahsol2"
           
       });
         modelBuilder.Entity<Product>().HasData(new 
       Product{
            ProductID=3,
            ItemId=3,
            ProductName="محصول شماره 3 ",
            Description="mahsol3"
       });
       modelBuilder.Entity<CategoritoProduct>().HasData(new CategoritoProduct{
        ProductID=1,CategoryId=1
       });
        modelBuilder.Entity<CategoritoProduct>().HasData(new CategoritoProduct{
        ProductID=1,CategoryId=2

       });
        modelBuilder.Entity<CategoritoProduct>().HasData(new CategoritoProduct{
        ProductID=2,CategoryId=1

       });
        modelBuilder.Entity<CategoritoProduct>().HasData(new CategoritoProduct{
        ProductID=2,CategoryId=2

       });
        modelBuilder.Entity<CategoritoProduct>().HasData(new CategoritoProduct{
        ProductID=3,CategoryId=1

       });
        modelBuilder.Entity<CategoritoProduct>().HasData(new CategoritoProduct{
        ProductID=3,CategoryId=2

       });
    
        #endregion       
        base.OnModelCreating (modelBuilder) ;     

        }
   


    }
}