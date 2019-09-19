using IndividualInfo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IndividualInfo.ViewModels
{
    public class IndividualViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "پر کردن فیلد نام ضروری است")]
        [MaxLength(14, ErrorMessage = "حداکثر 50 کاراکتر")]
        public string Name { get; set; }

        [Display(Name = "جنسیت")]
        public bool? Gender { get; set; }

        public List<SelectListItem> SelectListItems { get; set; }

        [Display(Name = "تلفن مستقیم")]
        [MaxLength(14, ErrorMessage = "حداکثر 14 کاراکتر")]
        public string TelDirect { get; set; }

        [Display(Name = "تلفن داخلی")]
        [MaxLength(14, ErrorMessage = "حداکثر 4 کاراکتر")]
        public string TelDakheli { get; set; }

        [Display(Name = "موبایل")]
        [MaxLength(14, ErrorMessage = "حداکثر 20 کاراکتر")]
        public string Mobile { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(14, ErrorMessage = "حداکثر 250 کاراکتر")]
        public string Description { get; set; }

        public Semat Semat { get; set; }

        [Display(Name = "سِمَت")]
        public byte? SematId { get; set; }

        public IEnumerable<Semat> Semats { get; set; }
        //public bool? Deleted { get; set; }

    }
}