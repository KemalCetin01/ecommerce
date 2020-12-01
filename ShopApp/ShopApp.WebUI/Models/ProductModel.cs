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
        public String Name { get; set; }
        [Required]
        public String ImageUrl { get; set; }
        [Required]
        [StringLength(10000,MinimumLength =20,ErrorMessage ="Ürün İsmi Min 20 Karakter ve Max 100 Karakter Olmalıdır.")]
        public String Description { get; set; }
        [Required(ErrorMessage ="Fiyat Belirtiniz.")]
        [Range(1,10000)]
        public decimal? Price { get; set; }
        public List<Category> SelectedCategories{ get; set; }
        public List<Brand> SelectedBrands{ get; set; }
    }
}
