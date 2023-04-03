using AndPlace.Data.Domain.Enums;
using AndPlace.Data.Domain.Models;
using AndPlace.Data.Domain.Models.Accounting;
using AndPlace.Data.Domain.Models.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace AndPlace.Data.Domain.Context;

public sealed class MenuContext : DbContext
{
    public DbSet<MenuSectionModel> MenuSections { get; set; } = null!;
    
    public DbSet<ProductModel> Products { get; set; } = null!;

    public DbSet<IngredientModel> Ingredients { get; set; } = null!;

    public DbSet<IngredientAccountingModel> IngredientsAccounting { get; set; } = null!;

    public DbSet<CompositionModel> Compositions { get; set; } = null!;
 
    public MenuContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=db_menu;Username=postgres;Password=2002");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder
            .Entity<MenuSectionModel>(SetPropertyMenuSections)
            .Entity<ProductModel>(SetPropertyProducts)
            .Entity<IngredientModel>(SetPropertyIngredients)
            .Entity<IngredientAccountingModel>(SetPropertyIngredientsAccounting)
            .Entity<CompositionModel>(SetPropertyComposition);
    }

    private void SetPropertyMenuSections(EntityTypeBuilder<MenuSectionModel> entity)
    {
        _ = entity.ToTable("menu_sections");
        
        _ = entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        
        _ = entity.Property(e => e.NameSection)
            .HasMaxLength(50)
            .HasColumnName("menu_section_name");

        _ = entity.Property(e => e.Description)
            .HasMaxLength(200)
            .HasColumnName("menu_section_description");

        _ = entity.Property(e => e.DepartmentManufacturer)
            .HasColumnName("department_manufacturer");
    }

    private void SetPropertyProducts(EntityTypeBuilder<ProductModel> entity)
    {
        _ = entity.ToTable("products");
        
        _ = entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        
        _ = entity.Property(e => e.Description)
            .HasMaxLength(200)
            .HasColumnName("product_description");
                
        _ = entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("product_name");
        
        _ = entity.Property(e => e.MenuSectionId)
            .HasColumnName("menu_section_id");
        
        _ = entity.Property(e => e.Price)
            .HasColumnName("product_price");
                
        _ = entity.HasOne(p => p.MenuSection)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.MenuSectionId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("fk_menu_section_products");
    }

    private void SetPropertyIngredients(EntityTypeBuilder<IngredientModel> entity)
    {
        _ = entity.ToTable("ingredients");
        
        _ = entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        
        _ = entity.Property(e => e.Unit)
            .HasMaxLength(20)
            .HasColumnName("ingredients_unit");
                
        _ = entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("ingredients_name");

        _ = entity.HasOne(i => i.IngredientAccounting)
            .WithOne(ia => ia.Ingredient)
            .HasForeignKey<IngredientAccountingModel>(ia => ia.IngredientId);
    }

    private void SetPropertyIngredientsAccounting(EntityTypeBuilder<IngredientAccountingModel> entity)
    {
        _ = entity.ToTable("ingredients_accounting");
        
        _ = entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        
        _ = entity.Property(e => e.Count)
            .HasColumnName("ingredient_accounting_count");

        _ = entity.Property(e => e.IngredientId)
            .HasColumnName("ingredient_id");
    }

    private void SetPropertyComposition(EntityTypeBuilder<CompositionModel> entity)
    {
        _ = entity.ToTable("compositions");

        _ = entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        _ = entity.Property(e => e.Count)
            .HasColumnName("composition_id");

        _ = entity.HasOne(c => c.Ingredient)
            .WithMany(i => i.Compositions)
            .HasForeignKey(c => c.IngredientId);

        _ = entity.HasOne(c => c.Product)
            .WithMany(p => p.Compositions)
            .HasForeignKey(c => c.ProductId);
    }
}