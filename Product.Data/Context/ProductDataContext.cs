namespace Product.Data.Context
{
    using System.Data.Entity;

    public class ProductDataContext : DbContext
    {
        // Your context has been configured to use a 'ProductDataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Product.Data.Context.ProductDataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProductDataContext' 
        // connection string in the application configuration file.
        public ProductDataContext()
            : base("name=ProductDataContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Entities.Product> Products { get; set; }
        public virtual DbSet<Entities.Material> Materials { get; set; }
        public virtual DbSet<Entities.ProductMaterial> ProductMaterials { get; set; }
    }
}