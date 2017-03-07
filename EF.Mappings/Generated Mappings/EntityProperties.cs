﻿// <autogenerated>
//   This file was generated by T4 code generator Amoeba-DataEntities.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>

using System;
using EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Mappings
{
	public class EntityPropertiesMap
	{
		public static void Map(EntityTypeBuilder<EntityProperties> entityBuilder)
		{
			entityBuilder.ToTable("EntityProperties", "dbo");
			entityBuilder.HasKey(t => t.Id);
			entityBuilder.Property(t => t.Id).HasColumnName("Id").UseSqlServerIdentityColumn();	
			entityBuilder.Property(t => t.EntityId).HasColumnName("EntityId").IsRequired();
			entityBuilder.Property(t => t.PropertyName).HasColumnName("PropertyName").IsRequired().HasMaxLength(50);
			entityBuilder.Property(t => t.PropertyName).HasColumnName("PropertyName").IsRequired().HasMaxLength(50);
		//-------------------Navigation Properties -------------------------------//
				entityBuilder.HasMany(x => x.DataProperties).WithOne(p => p.EntityProperties).HasForeignKey(c => c.EntityPropertyId).OnDelete(DeleteBehavior.Restrict);
				entityBuilder.HasMany(x => x.EntityViewEntityProperties).WithOne(p => p.EntityProperties).HasForeignKey(c => c.EntityPropertyId).OnDelete(DeleteBehavior.Restrict);
				entityBuilder.HasMany(x => x.PresentationProperties).WithOne(p => p.EntityProperties).HasForeignKey(c => c.EntityPropertyId).OnDelete(DeleteBehavior.Restrict);
				entityBuilder.HasMany(x => x.TestValues).WithOne(p => p.EntityProperties).HasForeignKey(c => c.EntityPropertyId).OnDelete(DeleteBehavior.Restrict);
	
				//----------------Parent Properties
				//entityBuilder.HasOne(p => p.Entities).WithMany(p => p.EntityProperties).HasForeignKey(c => c.EntityId).OnDelete(DeleteBehavior.Restrict);
	
		}
	}
}