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
	public class ApplicationEntitiesMap
	{
		public static void Map(EntityTypeBuilder<ApplicationEntities> entityBuilder)
		{
			entityBuilder.ToTable("ApplicationEntities", "dbo");
			entityBuilder.HasKey(t => t.Id);
			entityBuilder.Property(t => t.Id).HasColumnName("Id").UseSqlServerIdentityColumn();	
			entityBuilder.Property(t => t.ApplicationId).HasColumnName("ApplicationId").IsRequired();
			entityBuilder.Property(t => t.EntityId).HasColumnName("EntityId").IsRequired();
		//-------------------Navigation Properties -------------------------------//
	
				//----------------Parent Properties
				//entityBuilder.HasOne(p => p.Applications).WithMany(p => p.ApplicationEntities).HasForeignKey(c => c.ApplicationId).OnDelete(DeleteBehavior.Restrict);
				//entityBuilder.HasOne(p => p.Entities).WithMany(p => p.ApplicationEntities).HasForeignKey(c => c.EntityId).OnDelete(DeleteBehavior.Restrict);
	
		}
	}
}
