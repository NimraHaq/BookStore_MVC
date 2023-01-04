using System.ComponentModel;

namespace EadProject.Data
{
    public class BaseClass
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
