using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models
{
    public class ProductModel
    { //çok bozmamak genişletmemek gerek
        public int Id { get; set; }
        //[Required]
        //[StringLength(60,MinimumLength =10,ErrorMessage ="Ürün İsmi Min 10 Karakter ve Max 60 Karakter Olmalıdır.")]
        [Display(Name = "Ürün Adı")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Ürün Görseli")]
        public String ImageUrl { get; set; }
        [Required]
        [StringLength(10000,MinimumLength =20,ErrorMessage ="Ürün İsmi Min 20 Karakter ve Max 100 Karakter Olmalıdır.")]
        [Display(Name = "Açıklama")]
        public String Description { get; set; }
        //[Required(ErrorMessage ="Fiyat Belirtiniz.")]
        [Range(1,10000)]
        [Display(Name = "Fiyat")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal? Price { get; set; }
       // [Required(ErrorMessage = "Boyut Belirtiniz.(160*230)")]
        [Display(Name = "Boyut (160*230)")]
        public String Dimensions { get; set; }
       // [Required]
        public String Modell { get; set; }
     //  [Required]
        [Display(Name = "Materyal")]
        public String Material { get; set; }
        [Display(Name = "MetreKare")]
        public decimal? SequenceMeter { get; set; }
        [Display(Name = "Garanti Süresi")]
        public decimal? WarrantyPeriod { get; set; }
        public String Code { get; set; }

        public List<Category> SelectedCategories{ get; set; }
        public Brand SelectedBrands{ get; set; }
        public List<SelectListItem> Brands{ get; set; }
    }
}
