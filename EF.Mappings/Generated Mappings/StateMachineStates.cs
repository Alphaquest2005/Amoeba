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
	public class StateMachineStatesMap
	{
		public static void Map(EntityTypeBuilder<StateMachineStates> entityBuilder)
		{
			entityBuilder.ToTable("StateMachineStates", "dbo");
			entityBuilder.HasKey(t => t.Id);
			entityBuilder.Property(t => t.Id).HasColumnName("Id").UseSqlServerIdentityColumn();	
			entityBuilder.Property(t => t.MachineId).HasColumnName("MachineId").IsRequired();
			entityBuilder.Property(t => t.StateId).HasColumnName("StateId").IsRequired();
		//-------------------Navigation Properties -------------------------------//
	
				//----------------Parent Properties
				//entityBuilder.HasOne(p => p.StateMachines).WithMany(p => p.StateMachineStates).HasForeignKey(c => c.MachineId).OnDelete(DeleteBehavior.Restrict);
				//entityBuilder.HasOne(p => p.States).WithMany(p => p.StateMachineStates).HasForeignKey(c => c.StateId).OnDelete(DeleteBehavior.Restrict);
	
		}
	}
}
