using System.ComponentModel.DataAnnotations;

namespace TechsnovelTechnicalTask.Domain.Entities
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0: HH:mm, yy/MM/dd}")]
        [Display(Name = "Create Date ")]
        public DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0: HH:mm, yy/MM/dd}")]
        [Display(Name = "Update Date")]
        public DateTime UpdatedDate { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0: HH:mm, yy/MM/dd}")]
        [Display(Name = "Delete Date")]
        public DateTime? DeletedDate { get; set; }

    }
    public abstract class AuditableEntity : AuditableEntity<long>
    {

    }
}
