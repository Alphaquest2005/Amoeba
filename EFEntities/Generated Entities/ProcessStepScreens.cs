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
	public partial class ProcessStepScreens: BaseEntity, IProcessStepScreens
	{
		public virtual int ProcessStepId { get; set; }
		public virtual int ScreenId { get; set; }

		//-------------------Navigation Properties -------------------------------//
			// ---------Child Relationships
		
			// ---------Parent Relationships
				public virtual ProcessSteps ProcessSteps {get; set;}
				public virtual Screens Screens {get; set;}
	

	}
}
