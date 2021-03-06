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
	public class SettingsMap
	{
		public static void Map(EntityTypeBuilder<Settings> entityBuilder)
		{
			entityBuilder.ToTable("Settings", "dbo");
			entityBuilder.HasKey(t => t.Id);
			entityBuilder.Property(t => t.Id).HasColumnName("Id").UseSqlServerIdentityColumn();	
			entityBuilder.Property(t => t.ApplicationId).HasColumnName("ApplicationId").IsRequired();
			entityBuilder.Property(t => t.LayerId).HasColumnName("LayerId").IsRequired();
			entityBuilder.Property(t => t.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
			entityBuilder.Property(t => t.ProjectId).HasColumnName("ProjectId").IsRequired();
			entityBuilder.Property(t => t.Value).HasColumnName("Value").IsRequired().HasMaxLength(255);
		//-------------------Navigation Properties -------------------------------//
	
				//----------------Parent Properties
				//entityBuilder.HasOne(p => p.Applications).WithMany(p => p.Settings).HasForeignKey(c => c.ApplicationId).OnDelete(DeleteBehavior.Restrict);
				//entityBuilder.HasOne(p => p.Layers).WithMany(p => p.Settings).HasForeignKey(c => c.LayerId).OnDelete(DeleteBehavior.Restrict);
				//entityBuilder.HasOne(p => p.Projects).WithMany(p => p.Settings).HasForeignKey(c => c.ProjectId).OnDelete(DeleteBehavior.Restrict);
	
		}
	}
}
