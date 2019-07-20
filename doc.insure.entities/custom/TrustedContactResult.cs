using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doc.insure.entities.custom
{
    public class TrustedContactResult
    {
        public int TrustedContactId { get; set; }
        public int AppUserId { get; set; }
        public string AppUserFullName { get; set; }
        public int ContactAppUserId { get; set; }
        public string ContactAppUserFullName { get; set; }
        public System.DateTime TrustedContactCreated { get; set; }
        public string TrustedContactEmail { get; set; }
        public string TrustedContactFullName { get; set; }
        public int RelationShipTypeId { get; set; }
        public string RelationShipTypeDesc { get; set; }
        public System.Guid TrustedContactGuid { get; set; }
        public Nullable<int> TrustedContactStatusId { get; set; }
        public string TrustedContactStatusDesc { get; set; }
        public string TrustedContactCreatedDate
        {
            get
            {
                //return dtCreated.ToString("dddd, d MMM yyyy");
                return TrustedContactCreated.ToString("d MMMM yyyy");
            }
        }
    }
}
