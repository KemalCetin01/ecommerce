
namespace ShopApp.Business.Abstract
{
   public interface IValidator<T>
    {
        string ErrorMessage { get; set; }
        bool Validate(T entity);
    }
}
