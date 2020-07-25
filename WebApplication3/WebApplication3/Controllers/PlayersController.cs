using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class PlayersController : Controller
    {
        private readonly WebApplication3Context _context;

        public PlayersController(WebApplication3Context context)
        {
            _context = context;
        }

        // GET: Players
        public async Task<IActionResult> Index(string playerPosition, string playerCountry)
        {
            var webApplication3Context = _context.Player.Include(p => p.Contract).ThenInclude(p=>p.Team);
            IQueryable<Player> players = _context.Player.AsQueryable();
            IQueryable<string> positionQuery = _context.Player.OrderBy(m => m.Position).Select(m => m.Position).Distinct();
            IQueryable<string> countryQuery = _context.Player.OrderBy(m => m.Country).Select(m => m.Country).Distinct();
            if (!string.IsNullOrEmpty(playerPosition))
            {
                players = players.Where(x => x.Position == playerPosition);
            }
            if (!string.IsNullOrEmpty(playerCountry))
            {
                players = players.Where(x => x.Country == playerCountry);
            }
           

            var playerSearchViewModel = new PlayersSearchViewModel
            {
                Positions = new SelectList(await positionQuery.ToListAsync()),
                Countries = new SelectList(await countryQuery.ToListAsync()),
                Players = await players.ToListAsync()
            };
            return View(playerSearchViewModel);

        }
        // GET: Contracts
        public async Task<IActionResult> Index2()
        {
            var webApplication3Context = _context.Player.Include(c => c.Contract);
            return View(await webApplication3Context.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.Contract).Include(p=>p.Image)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewData["ContractId"] = new SelectList(_context.Contract, "Id", "Id");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JerseyNumber,FirstName,LastName,Weight,Height,Position,PrefferedLeg,Goals,Country,BirthDate,ContractId")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractId"] = new SelectList(_context.Contract, "Id", "Id", player.ContractId);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["ContractId"] = new SelectList(_context.Contract, "Id", "Id", player.ContractId);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JerseyNumber,FirstName,LastName,Weight,Height,Position,PrefferedLeg,Goals,Country,BirthDate,ContractId")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
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
            ViewData["ContractId"] = new SelectList(_context.Contract, "Id", "Id", player.ContractId);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.Contract)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Player.FindAsync(id);
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}
