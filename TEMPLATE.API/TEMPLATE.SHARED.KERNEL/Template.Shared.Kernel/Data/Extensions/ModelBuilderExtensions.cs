﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Shared.Kernel.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}
