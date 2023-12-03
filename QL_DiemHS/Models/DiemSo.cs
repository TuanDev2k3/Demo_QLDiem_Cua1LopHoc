using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_DiemHS.Models
{
    public class DiemSo
    {
        [Key]
        public int MaMon { get; set; }

        [Key]
        public int MaHS { get; set; }
        //

        [ForeignKey("MaMon")]
        public MonHoc MonHoc { get; set; }
        [ForeignKey("MaHS")]
        public HocSinh HocSinh { get; set; }

        [ValidateNever]
        public double Diem15p { get; set; }
        public double Diem1t { get; set; }
        public double DiemGk { get; set; }
        public double DiemCk { get; set; }
		public double DiemTrungBinh { get; set; }


	}
}
