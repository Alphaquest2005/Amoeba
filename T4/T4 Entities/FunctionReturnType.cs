//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace T4Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class FunctionReturnType : BaseEntity
    {
        public int DataTypeId { get; set; }
    
        public virtual Function Function { get; set; }
        public virtual DataType DataType { get; set; }
    }
}