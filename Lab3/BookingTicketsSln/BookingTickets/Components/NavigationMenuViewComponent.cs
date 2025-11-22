using Microsoft.AspNetCore.Mvc;
using BookingTickets.Models;
using System.Linq;

namespace BookingTickets.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly BookingDbContext _context;

        public NavigationMenuViewComponent(BookingDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _context.Events
                .Select(e => e.Category)
                .Distinct()
                .OrderBy(c => c);

            string selectedCategory = RouteData.Values["category"] as string;

            return View(new NavigationMenuViewModel
            {
                Categories = categories.ToList(),
                SelectedCategory = selectedCategory
            });
        }
    }

    public class NavigationMenuViewModel
    {
        public IEnumerable<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
    }
}
