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
    
    public partial class EntityRelationship : BaseEntity
    {
        public int ParentEntityPropertyId { get; set; }
        public int ChildEntityPropertyId { get; set; }
        public int RelationshipTypeId { get; set; }
    
        public virtual EntityProperty ChildProperty { get; set; }
        public virtual EntityProperty ParentProperty { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }
    }
}