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
	public class ScreenLayoutsMap
	{
		public static void Map(EntityTypeBuilder<ScreenLayouts> entityBuilder)
		{
			entityBuilder.ToTable("ScreenLayouts", "UI");
			entityBuilder.HasKey(t => t.Id);
			entityBuilder.Property(t => t.Id).HasColumnName("Id").UseSqlServerIdentityColumn();	
			entityBuilder.Property(t => t.LayoutId).HasColumnName("LayoutId").IsRequired();
			entityBuilder.Property(t => t.ScreenId).HasColumnName("ScreenId").IsRequired();
		//-------------------Navigation Properties -------------------------------//
	
				//----------------Parent Properties
				//entityBuilder.HasOne(p => p.Layout).WithMany(p => p.ScreenLayouts).HasForeignKey(c => c.LayoutId).OnDelete(DeleteBehavior.Restrict);
				//entityBuilder.HasOne(p => p.Screens).WithMany(p => p.ScreenLayouts).HasForeignKey(c => c.ScreenId).OnDelete(DeleteBehavior.Restrict);
	
		}
	}
}
