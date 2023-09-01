using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUIUI;
//SOLID
//O - Open Closed Principle
class Program
{
    static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        foreach (var product in productManager.GetByUnitPrice(10,100))
        {
            Console.WriteLine(product.ProductName);
        }
    }
}