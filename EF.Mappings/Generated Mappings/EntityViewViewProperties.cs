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
	public class EntityViewViewPropertiesMap
	{
		public static void Map(EntityTypeBuilder<EntityViewViewProperties> entityBuilder)
		{
			entityBuilder.ToTable("EntityViewViewProperties", "dbo");
			entityBuilder.HasKey(t => t.Id);
			entityBuilder.Property(t => t.Id).HasColumnName("Id").ValueGeneratedNever();	
			entityBuilder.Property(t => t.Id).HasColumnName("Id").IsRequired();
			entityBuilder.Property(t => t.EntityViewPropertyId).HasColumnName("EntityViewPropertyId").IsRequired();
		//-------------------Navigation Properties -------------------------------//
	
				//----------------Parent Properties
				//entityBuilder.HasOne(p => p.EntityViewProperties).WithOne(p => p.EntityViewViewProperties).HasForeignKey<EntityViewProperties>(c => c.Id).OnDelete(DeleteBehavior.Restrict);
				//entityBuilder.HasOne(p => p.EntityViewProperties).WithMany(p => p.EntityViewViewProperties).HasForeignKey(c => c.EntityViewPropertyId).OnDelete(DeleteBehavior.Restrict);
	
		}
	}
}
