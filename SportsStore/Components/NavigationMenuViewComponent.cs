using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Neri_SportsStore.Models;

namespace Neri_SportsStore.Components {

    public class NavigationMenuViewComponent : ViewComponent {
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo) {
            repository = repo;
        }

        public IViewComponentResult Invoke() {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
