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
	public partial class StateMachines: BaseEntity, IStateMachines
	{
		public virtual string Name { get; set; }

		//-------------------Navigation Properties -------------------------------//
			// ---------Child Relationships
				public virtual ICollection<StateMachineStates> StateMachineStates {get; set;}
				public virtual ICollection<StateMachineTriggers> StateMachineTriggers {get; set;}
		
			// ---------Parent Relationships
	

	}
}
