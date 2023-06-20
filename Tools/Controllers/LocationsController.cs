using Microsoft.AspNetCore.Mvc;
using Tools.Data;
using Tools.Models;

public class LocationsController : Controller
{
	private readonly ApplicationDbContext _context;

	public LocationsController(ApplicationDbContext context)
	{
		_context = context;
	}

	public IActionResult Index()
	{
		var locations = _context.Locations.ToList();
		return View(locations);
    }

    public IActionResult View()
    {
        var locations = _context.Locations.ToList();
        return View(locations);
    }

    public IActionResult Create(Locations locations)
	{
		if (ModelState.IsValid)
		{
			_context.Locations.Add(locations);
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}

		return View(locations);
	}
}
