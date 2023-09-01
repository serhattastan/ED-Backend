using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUIUI;
//SOLID
//O - Open Closed Principle
//DTOs == Data Transform Object
class Program
{
    static void Main(string[] args)
    {
        ProductTest();

        //CategoryTest();

    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll())
        {
            Console.WriteLine(category.CategoryId + " " + category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        foreach (var product in productManager.GetProductDetails())
        {
            Console.WriteLine(product.ProductId + " *** " + product.ProductName + " *** " + product.CategoryName + " *** " + product.UnitsInStock);
        }
    }
}