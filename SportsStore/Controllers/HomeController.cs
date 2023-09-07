using Microsoft.AspNetCore.Mvc;
using SportsStore.Interfaces;

namespace SportsStore.Controllers
{

    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;

        public HomeController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index(int productPage = 1)
        {
            return View(repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize));
        }
    }
}
