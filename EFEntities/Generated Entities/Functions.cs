﻿// <autogenerated>
//   This file was generated by T4 code generator Amoeba-DataEntities.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>

using System;
using System.Collections.Generic;
using Common.DataEntites;
using EF.Entities;
using Interfaces;

namespace EF.Entities
{
	public partial class Functions: BaseEntity, IFunctions
	{
		public virtual string Name { get; set; }

		//-------------------Navigation Properties -------------------------------//
			// ---------Child Relationships
				public virtual ICollection<EntityViewPropertyFunction> EntityViewPropertyFunction {get; set;}
				public virtual FunctionBody FunctionBody {get; set;}
				public virtual ICollection<FunctionParameters> FunctionParameters {get; set;}
				public virtual FunctionReturnType FunctionReturnType {get; set;}
		
			// ---------Parent Relationships
	

	}
}