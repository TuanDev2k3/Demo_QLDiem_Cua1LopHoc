using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_DiemHS.Models
{
    public class HocSinh
    {
        [Key]
        public int MaHS { get; set;}
        public string TenHS { get; set; }
       
    }
}
