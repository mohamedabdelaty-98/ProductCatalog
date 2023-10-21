using ProductCatalog.Models;

namespace ProductCatalog.Repository
{
    public class ProductRepo : CrudOperation<Product>,IProduct
    {
        private readonly Context context;

        public ProductRepo(Context context) : base(context)
        {
            this.context = context;
        }
      

        public List<Product> getproductbydate(DateTime dateTime)
        {
            
            return context.products.
                Where(e=>dateTime<=e.StartDate.AddDays(e.Duration) && dateTime>=e.StartDate).ToList();
        }
        public List<Product> getproductbycategroy(int id)
        {
            List<Product> avilableproduct = getproductbydate(DateTime.Now);
            return avilableproduct.Where(e => e.CategoryId == id).ToList();
        }

        public Product getdetailsbyid(int id)
        {
            List<Product> products = getproductbydate(DateTime.Now);
            if(products !=null)
                return products.Find(p => p.Id == id);
            return null;
         }
    }
}

