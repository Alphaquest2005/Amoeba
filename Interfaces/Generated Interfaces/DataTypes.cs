﻿// <autogenerated>
//   This file was generated by T4 code generator Amoeba-Interfaces.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>

using System.ComponentModel.Composition;
using SystemInterfaces;


namespace Interfaces
{
	[InheritedExport]
	public partial interface IDataTypes:IEntity  
	{
		string Name { get;}
		string DBType { get;}



	}
}
