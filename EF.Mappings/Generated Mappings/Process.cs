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
	public class ProcessMap
	{
		public static void Map(EntityTypeBuilder<Process> entityBuilder)
		{
			entityBuilder.ToTable("Process", "UI");
			entityBuilder.HasKey(t => t.Id);
			entityBuilder.Property(t => t.Id).HasColumnName("Id").UseSqlServerIdentityColumn();	
			entityBuilder.Property(t => t.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
		//-------------------Navigation Properties -------------------------------//
				entityBuilder.HasMany(x => x.ApplicationProcess).WithOne(p => p.Process).HasForeignKey(c => c.ProcessId).OnDelete(DeleteBehavior.Restrict);
				entityBuilder.HasMany(x => x.ProcessSteps).WithOne(p => p.Process).HasForeignKey(c => c.ProcessId).OnDelete(DeleteBehavior.Restrict);
	
				//----------------Parent Properties
	
		}
	}
}