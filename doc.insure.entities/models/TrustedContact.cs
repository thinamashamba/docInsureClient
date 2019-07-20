//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace doc.insure.entities.models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrustedContact
    {
        public int TrustedContactId { get; set; }
        public int AppUserId { get; set; }
        public Nullable<int> ContactAppUserId { get; set; }
        public System.DateTime TrustedContactCreated { get; set; }
        public string TrustedContactEmail { get; set; }
        public string TrustedContactFullName { get; set; }
        public int RelationShipTypeId { get; set; }
        public System.Guid TrustedContactGuid { get; set; }
        public int TrustedContactStatusId { get; set; }
    
        public virtual AppUser AppUser { get; set; }
        public virtual AppUser AppUser1 { get; set; }
        public virtual RelationShipType RelationShipType { get; set; }
        public virtual TrustedContactStatu TrustedContactStatu { get; set; }
    }
}
