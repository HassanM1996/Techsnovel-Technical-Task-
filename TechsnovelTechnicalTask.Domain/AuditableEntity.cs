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
        [Display(Name = "Create by ")]
        [MaxLength(250)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0: HH:mm, yy/MM/dd}")]
        [Display(Name = "Update Date")]
        public DateTime UpdatedDate { get; set; }

        [Display(Name = "Update by")]
        [ScaffoldColumn(false)]
        [MaxLength(250)]
        public string UpdatedBy { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0: HH:mm, yy/MM/dd}")]
        [Display(Name = "Delete Date")]
        public DateTime? DeletedDate { get; set; }

        [Display(Name = "Delete by")]
        [ScaffoldColumn(false)]
        [MaxLength(250)]
        public string? DeletedBy { get; set; }


    }
    public abstract class AuditableEntity : AuditableEntity<long>
    {

    }
}
