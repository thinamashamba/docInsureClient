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
    
    public partial class DocumentView
    {
        public int DocumentId { get; set; }
        public int AppUserId { get; set; }
        public string DocumentOwner { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentDescription { get; set; }
        public System.Guid DocumentGUID { get; set; }
        public string DocumentLink { get; set; }
        public string OriginalFileName { get; set; }
        public int DocumentCategoryId { get; set; }
        public string DocumentCategoryDesc { get; set; }
        public System.DateTime dtCreated { get; set; }
    }
}
