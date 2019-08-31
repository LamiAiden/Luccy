using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Entity.Sys
{
    public class SysUserEntity:Abp.Domain.Entities.Entity<string>
    {
        [Display(Name = "Id")]
        public override string Id { get; set; }


        [Display(Name = "名字")]
        public string UserName { get; set; }


        [Display(Name = "密码")]
        public string Password { get; set; }


        [Display(Name = "真实姓名")]
        public string TrueName { get; set; }


        [Display(Name = "员工卡")]
        public string Card { get; set; }


        [Display(Name = "身份证")]
        public string MobileNumber { get; set; }


        [Display(Name = "电话号码")]
        public string PhoneNumber { get; set; }


        [Display(Name = "QQ")]
        public string QQ { get; set; }


        [Display(Name = "电子邮箱")]
        public string EmailAddress { get; set; }


        [Display(Name = "其他信息")]
        public string OtherContact { get; set; }


        [Display(Name = "省份")]
        public string Province { get; set; }


        [Display(Name = "城市")]
        public string City { get; set; }


        [Display(Name = "村")]
        public string Village { get; set; }


        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "在职状态")]
        public bool State { get; set; }

        [Display(Name = "添加时间")]
        public DateTime? CreateTime { get; set; }


        [Display(Name = "添加人")]
        public string CreatePerson { get; set; }


        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "生日")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "入职时间")]
        public DateTime? JoinDate { get; set; }


        [Display(Name = "婚姻")]
        public string Marital { get; set; }


        [Display(Name = "党派")]
        public string Political { get; set; }


        [Display(Name = "民族")]
        public string Nationality { get; set; }


        [Display(Name = "籍贯")]
        public string Native { get; set; }


        [Display(Name = "毕业学校")]
        public string School { get; set; }


        [Display(Name = "就读专业")]
        public string Professional { get; set; }


        [Display(Name = "学历")]
        public string Degree { get; set; }


        [Display(Name = "部门")]
        public string DepId { get; set; }


        [Display(Name = "职位")]
        public string PosId { get; set; }


        [Display(Name = "个人简介")]
        public string Expertise { get; set; }


        [Display(Name = "在职状况")]
        public string JobState { get; set; }


        [Display(Name = "照片")]
        public string Photo { get; set; }


        [Display(Name = "附件")]
        public string Attach { get; set; }
     
    }
}
