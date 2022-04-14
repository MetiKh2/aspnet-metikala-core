using MetiKala.Domain.Entities.Order;
using MetiKala.Domain.Entities.Permission;
using MetiKala.Domain.Entities.Products;
using MetiKala.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MetiKala.Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<User> User { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<RolePermission> RolePermissions { get; set; }
        DbSet<ProductsGroupe> ProductsGroupes { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductFeature> ProductFeatures { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<UserDiscount> UserDiscount { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<ProductDiscount> ProductDiscounts { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess); 
        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
