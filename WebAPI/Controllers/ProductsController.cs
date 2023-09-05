using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Attribute - Javada Anotation
    public class ProductsController : ControllerBase
    {

        //Loosely Coupled : Gevşek Bağlılık
        //IoC Container : Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            //Dependency Chain : Bağımlılık Zinciri
            //IProductService productService = new ProductManager( new EfProductDal());
            
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
