using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiNetCoreDemo.Models
{
    public class Student
    {
        [Key]
        [Required]
        [Display(Name = "记录号")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "学号不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "学号必须为4位")]
        [Display(Name = "学号")]
        public string StId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "姓名不能为空")]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "姓名不能超过4位且不能低于2位")]
        [Display(Name = "姓名")]
        public string StName { get; set; }

        [Display(Name = "职务")]
        public string StTitle { get; set; }

        [Display(Name = "学分")]
        public List<Subject> Subjects { get; set; }
    }

    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = "学科不能为空")]
        [Display(Name = "学科")]
        public string SubTitle { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="学分不能为空")]
        [Display(Name = "学分")]
        public int SubSource { get; set; }
    }
}
