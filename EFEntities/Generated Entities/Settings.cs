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
	public partial class Settings: BaseEntity, ISettings
	{
		public virtual int ApplicationId { get; set; }
		public virtual int LayerId { get; set; }
		public virtual string Name { get; set; }
		public virtual int ProjectId { get; set; }
		public virtual string Value { get; set; }

		//-------------------Navigation Properties -------------------------------//
			// ---------Child Relationships
		
			// ---------Parent Relationships
				public virtual Applications Applications {get; set;}
				public virtual Layers Layers {get; set;}
				public virtual Projects Projects {get; set;}
	

	}
}
