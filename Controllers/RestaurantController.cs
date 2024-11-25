using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEST2.Models;

namespace TEST2.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly YourDbContext _context;
        public RestaurantController(YourDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return View(restaurants);
        }
        // Action to display the details of a specific restaurant
        public async Task<IActionResult> Details(int id)
        {
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(r => r.RestaurantId == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }
        // Action to display the "Create" view
        public IActionResult Create()
        {
            return View();
        }
        // Action to handle the form submission for creating a restaurant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestaurantId,RestaurantName,Description,Phone,Email,Address,City,PostalCode,OpeningHours,Rating")] RestaurantModel restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }
        // Action to display the "Edit" view
        public async Task<IActionResult> Edit(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }
        // Action to handle the form submission for editing a restaurant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RestaurantId,RestaurantName,Description,Phone,Email,Address,City,PostalCode,OpeningHours,Rating")] RestaurantModel restaurant)
        {
            if (id != restaurant.RestaurantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.RestaurantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }
        // Action to display the "Delete" view
        public async Task<IActionResult> Delete(int id)
        {
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(r => r.RestaurantId == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }
        // Action to handle the form submission for deleting a restaurant
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(r => r.RestaurantId == id);
        }

    }
}
