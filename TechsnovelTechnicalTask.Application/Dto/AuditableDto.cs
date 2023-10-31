using System.ComponentModel.DataAnnotations;

namespace TechsnovelTechnicalTask.Application.Dto
{
    public class AuditableDto<T> : EntityDto<T>
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

    }
    public abstract class AuditableDto : AuditableDto<long>
    {

    }
}
