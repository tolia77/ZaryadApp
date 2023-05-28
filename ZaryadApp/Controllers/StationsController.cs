using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZaryadApp.Data;
using ZaryadApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ZaryadApp.Controllers
{
    public class StationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Stations
        public async Task<IActionResult> Index(string city, decimal price, string plug, decimal voltage, int settingsId)
        {
            List<string> plugs = new List<string>() 
            {
                "CHAdeMO", "CCS", "Type 2", "J-1772", "GB/T (Fast)", "Wall (Euro)"
            };
            ViewBag.context = _context;
            ViewBag.Settings = new SelectList((from m in _context.Settings select m.Id).ToList());
            ViewBag.Plugs = new SelectList(plugs);
            var stations = from m in _context.Station select m;
            if (settingsId > 0)
            {
                Settings settings = _context.Settings.Find(settingsId);
                if (!String.IsNullOrEmpty(settings.City))
                {
                    ViewData["city"] = settings.City;
                    stations = stations.Where(s => s.City!.Contains(settings.City));
                }
                if (settings.Price > 0)
                {
                    ViewData["price"] = settings.Price;
                    stations = stations.Where(p => p.Price <= settings.Price);
                }
                if (settings.Voltage > 0)
                {
                    ViewData["voltage"] = settings.Voltage;
                    stations = stations.Where(v => v.Voltage <= settings.Voltage);
                }
                if (!String.IsNullOrEmpty(settings.Plug))
                {
                    ViewData["plug"] = settings.Plug;
                    stations = stations.Where(m => m.Plug!.Contains(settings.Plug));
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(city))
                {
                    stations = stations.Where(s => s.City!.Contains(city));
                }
                if (price > 0)
                {
                    stations = stations.Where(p => p.Price <= price);
                }
                if (voltage > 0)
                {
                    stations = stations.Where(v => v.Voltage <= voltage);
                }
                if (!String.IsNullOrEmpty(plug))
                {
                    stations = stations.Where(m => m.Plug!.Contains(plug));
                }
            }
            return View(await stations.ToListAsync());
            //return _context.Station != null ?
            //              View(await _context.Station.ToListAsync()) :
            //              Problem("Entity set 'ApplicationDbContext.Station'  is null.");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminIndex(string city, decimal price, string plug, decimal voltage)
        {
            List<string> plugs = new List<string>()
            {
                "CHAdeMO", "CCS", "Type 2", "J-1772", "GB/T (Fast)", "Wall (Euro)"
            };
            ViewBag.Plugs = new SelectList(plugs);
            var stations = from m in _context.Station select m;
            if (!String.IsNullOrEmpty(city))
            {
                stations = stations.Where(s => s.City!.Contains(city));
            }
            if (price > 0)
            {
                stations = stations.Where(p => p.Price <= price);
            }
            if (voltage > 0)
            {
                stations = stations.Where(v => v.Voltage <= voltage);
            }
            if (!String.IsNullOrEmpty(plug))
            {
                stations = stations.Where(m => m.Plug!.Contains(plug));
            }
            return stations != null ?
                          View(await stations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Station'  is null.");
        }
        // GET: Stations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Station == null)
            {
                return NotFound();
            }

            var station = await _context.Station
                .FirstOrDefaultAsync(m => m.Id == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // GET: Stations/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,City,Address,Plug,Voltage,Price")] Station station)
        {
            if (ModelState.IsValid)
            {
                _context.Add(station);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(station);
        }

        // GET: Stations/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Station == null)
            {
                return NotFound();
            }

            var station = await _context.Station.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }
            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,City,Address,Plug,Voltage,Price")] Station station)
        {
            if (id != station.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(station);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationExists(station.Id))
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
            return View(station);
        }

        // GET: Stations/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Station == null)
            {
                return NotFound();
            }

            var station = await _context.Station
                .FirstOrDefaultAsync(m => m.Id == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Station == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Station'  is null.");
            }
            var station = await _context.Station.FindAsync(id);
            if (station != null)
            {
                _context.Station.Remove(station);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StationExists(int id)
        {
            return (_context.Station?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
