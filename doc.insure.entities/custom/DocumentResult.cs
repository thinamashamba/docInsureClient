using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doc.insure.entities.custom
{
    public class DocumentResult
    {
        public int DocumentId { get; set; }
        public int AppUserId { get; set; }
        public string DocumentOwner { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentDescription { get; set; }
        public System.Guid DocumentGUID { get; set; }
        public string DocumentLink { get; set; }
        public int DocumentCategoryId { get; set; }
        public string DocumentCategoryDesc { get; set; }
        public System.DateTime dtCreated { get; set; }
        public string DocCreatedDate
        {
            get
            {
                //return dtCreated.ToString("dddd, d MMM yyyy");
                return dtCreated.ToString("d MMMM yyyy");
            }
        }
    }
}
