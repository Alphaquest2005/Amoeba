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
	public partial class ScreenViews: BaseEntity, IScreenViews
	{
		public virtual int ScreenId { get; set; }
		public virtual int ViewId { get; set; }

		//-------------------Navigation Properties -------------------------------//
			// ---------Child Relationships
		
			// ---------Parent Relationships
				public virtual Screens Screens {get; set;}
				public virtual Views Views {get; set;}
	

	}
}
