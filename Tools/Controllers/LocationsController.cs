using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Tools.Data;
using Tools.Models;

public class LocationsController : Controller
{
	private readonly ApplicationDbContext _context;
	private readonly IConfiguration _configuration;

	public LocationsController(
		ApplicationDbContext context,
		IConfiguration configuration)
	{
		_context = context;
		_configuration = configuration;
	}

	public IActionResult Index()
	{
		var locations = _context.Locations.ToList();
		return View(locations);
    }

    public new IActionResult View()
    {
		string googleMapsApiKey = _configuration["GOOGLE_MAPS_API_KEY"];

		var locations = _context.Locations.ToList();

		var model = new LocationsViewModel()
		{
			Locations = locations,
			ApiKey = googleMapsApiKey
		};

        return View(model);
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

	// GET: Locations/Edit/5
	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null || _context.Locations == null)
		{
			return NotFound();
		}

		var location = await _context.Locations.FindAsync(id);
		if (location == null)
		{
			return NotFound();
		}
		return View(location);
	}

	// POST: Locations/Edit/5
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Latitude,Longitude,CountryCode")] Locations locations)
	{
		if (id != locations.ID)
		{
			return NotFound();
		}

		if (ModelState.IsValid)
		{
			try
			{
				_context.Update(locations);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!LocationExists(locations.ID))
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
		return View(locations);
	}

	private bool LocationExists(int id)
	{
		return (_context.Locations?.Any(e => e.ID == id)).GetValueOrDefault();
	}
}
