using Microsoft.AspNetCore.Mvc;
using WEB_253503_Yarmak.Domain.Entities;
using WEB_253503_Yarmak.Domain.Models;
using WEB_253503_Yarmak.Services.CategoryService;
using WEB_253503_Yarmak.Services.ProductService;

namespace WEB_253503_Yarmak.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(string? category, int pageNo = 1)
       {
            List<Category> categoryList = (await _categoryService.GetCategoryListAsync()).Data;
            ViewData["Categories"] = categoryList;
            ViewData["currentCategory"] = (category is null)?null:char.ToUpper(category[0]) + category.Substring(1);


            var request = HttpContext.Request;
            string? _category = request.RouteValues["category"]?.ToString();

            ResponseData<ProductListModel<Phone>> productResponse;
            if (category == null || category=="Все")
            {
                productResponse =
                    await _productService.GetProductListAsync(null, pageNo);
            }
            else
            {
                productResponse =
                    await _productService.GetProductListAsync(category, pageNo);
            }
            if (!productResponse.Successfull)
                return NotFound(productResponse.ErrorMessage);
            //TODO: добавить пагинацию
            //TODO: рефакторинг кода!
            ProductListModel<Phone> productListModel = new ProductListModel<Phone>(
                (category == null || category == "все")?((MemoryProductService)_productService).GetAmountOfAllProduct():((MemoryProductService)_productService).GetAmountOfProductWithCategory(category), 
                pageNo, 
                ((MemoryProductService)_productService).AmountOfPages
            );

            ViewData["ProductListModel"] = productListModel;
            return View(productResponse.Data.Items);
        }
    }
}
