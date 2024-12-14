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

namespace UTB.Zpravodajstvi.Infrastructure.Database
{
    public class ZpravodajstviDbContext : DbContext
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
        }
    }
}
