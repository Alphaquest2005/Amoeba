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
	public partial class EntityViewPropertyFunctionParameter: BaseEntity, IEntityViewPropertyFunctionParameter
	{
		public virtual string Value { get; set; }
		public virtual int FunctionParameterId { get; set; }

		//-------------------Navigation Properties -------------------------------//
			// ---------Child Relationships
		
			// ---------Parent Relationships
				public virtual EntityViewPropertyFunction EntityViewPropertyFunction {get; set;}
				public virtual FunctionParameters FunctionParameters {get; set;}
	

	}
}
