using System.ComponentModel.DataAnnotations;

namespace QL_DiemHS.Models
{
    public class MonHoc
    {
        [Key]
        public int MaMon { get; set; }
        [Required] 
        public string TenMon { get; set;}
    }
}
