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
	public partial class ProcessSteps: BaseEntity, IProcessSteps
	{
		public virtual int ProcessId { get; set; }
		public virtual int StepId { get; set; }

		//-------------------Navigation Properties -------------------------------//
			// ---------Child Relationships
				public virtual ICollection<ProcessStepScreens> ProcessStepScreens {get; set;}
		
			// ---------Parent Relationships
				public virtual Process Process {get; set;}
				public virtual Steps Steps {get; set;}
	

	}
}
