using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models
{
    public class OrderModel
    {
        [Display(Name = "Adı")]
        public string FirstName { get; set; }
        [Display(Name = "Soyadı")]
        public string LastName { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Şehir")]
        public string City { get; set; }
        [Display(Name = "Telefon No")]
        public string Phone { get; set; }
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        [Display(Name = "Kart Üzerindeki Ad / Soyad")]
        public string CardName { get; set; }
        [Display(Name = "Kart Numarası")]
        public string CardNumber { get; set; }
        [Display(Name = "Son Kullanma (Ay)")]
        public string ExpirationMonth { get; set; }
        [Display(Name = "Son Kullanma (Yıl)")]
        public string ExpirationYear { get; set; }
        [Display(Name = "CVV")]
        public string Cvv { get; set; }
        public CartModel CartModel { get; set; }
    }
}
