using ProductCatalog.Models;

namespace ProductCatalog.Repository
{
    public interface IProduct:ICrudOperation<Product>
    {
        List<Product> getproductbycategroy(int id);
        List<Product> getproductbydate(DateTime dateTime);
        Product getdetailsbyid(int id);
    }
}
