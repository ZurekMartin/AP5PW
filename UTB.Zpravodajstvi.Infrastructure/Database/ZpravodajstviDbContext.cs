using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Domain.Entities.Interfaces;
using UTB.Zpravodajstvi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using UTB.Zpravodajstvi.Infrastructure.Database.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UTB.Zpravodajstvi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace UTB.Zpravodajstvi.Infrastructure.Database
{
    public class ZpravodajstviDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ZpravodajstviDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ArticleInit productInit = new ArticleInit();
            modelBuilder.Entity<Article>().HasData(productInit.GetArticles());
            ArticleTagInit articleTagInit = new ArticleTagInit();
            modelBuilder.Entity<ArticleTag>().HasData(articleTagInit.GetArticleTags());
            CarouselInit carouselInit = new CarouselInit();
            modelBuilder.Entity<Carousel>().HasData(carouselInit.GetCarousels());
            CategoryInit categoryInit = new CategoryInit();
            modelBuilder.Entity<Category>().HasData(categoryInit.GetCategories());
            TagInit tagInit = new TagInit();
            modelBuilder.Entity<Tag>().HasData(tagInit.GetTags());

            //Identity - User and Role initialization
            //roles must be added first
            RolesInit rolesInit = new RolesInit();
            modelBuilder.Entity<Role>().HasData(rolesInit.GetRolesAMC());
            //then, create users ..
            UserInit userInit = new UserInit();
            User admin = userInit.GetAdmin();
            User writer = userInit.GetWriter();
            //.. and add them to the table
            modelBuilder.Entity<User>().HasData(admin, writer);
            //and finally, connect the users with the roles
            UserRolesInit userRolesInit = new UserRolesInit();
            List<IdentityUserRole<int>> adminUserRoles = userRolesInit.GetRolesForAdmin();
            List<IdentityUserRole<int>> writerUserRoles = userRolesInit.GetRolesForWriter();
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(writerUserRoles);
        }
    }
}
