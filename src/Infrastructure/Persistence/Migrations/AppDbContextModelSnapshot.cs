using System;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations;

[DbContext(typeof(AppDbContext))]
partial class AppDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity("Domain.Entities.Product", b =>
        {
            b.Property<Guid>("Id");
            b.Property<DateTime>("CreatedAt");
            b.Property<string>("Name").IsRequired().HasMaxLength(120);
            b.Property<decimal>("Price").HasPrecision(18, 2);
            b.HasKey("Id");
            b.ToTable("Products");
        });
    }
}
