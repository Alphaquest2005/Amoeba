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
	public partial class DataProperties: BaseEntity, IDataProperties
	{
		public virtual int EntityPropertyId { get; set; }
		public virtual int DataTypeId { get; set; }
		public virtual int MaxLength { get; set; }
		public virtual int ModelTypeId { get; set; }

		//-------------------Navigation Properties -------------------------------//
			// ---------Child Relationships
				public virtual PrimaryKeyOptions PrimaryKeyOptions {get; set;}
		
			// ---------Parent Relationships
				public virtual EntityProperties EntityProperties {get; set;}
				public virtual DataTypes DataTypes {get; set;}
				public virtual ModelTypes ModelTypes {get; set;}
	

	}
}
