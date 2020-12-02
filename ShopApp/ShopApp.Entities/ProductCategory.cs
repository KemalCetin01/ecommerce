

namespace ShopApp.Entities
{
    public class ProductCategory
    {
        //iki tabloyu birleştiren tablo  contition(cankşın)

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
