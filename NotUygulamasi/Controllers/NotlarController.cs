using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotUygulamasi.Data;
using NotUygulamasi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NotUygulamasi.Controllers
{
    public class NotlarController : Controller
    {
        private readonly NotUygulamasiContext _context;

        public NotlarController(NotUygulamasiContext context)
        {
            _context = context;
        }
 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notlar.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
     }

       var not = await _context.Notlar.FirstOrDefaultAsync(m => m.NotId == id);
            if (not == null)
        {
                return NotFound();
           }

            return View(not);
        }
      public IActionResult Create()
        {
            return View();
        }
  

        [HttpPost]
        public async Task<IActionResult> Create([Bind("NotId,Baslik,Icerik,TamamlanmaDurumu")] Not not)
        {
            if (ModelState.IsValid)
            {
                not.OlusturmaTarihi = DateTime.Now;
                not.SonDuzenlemeTarihi = DateTime.Now;
                _context.Add(not);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(not);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var not = await _context.Notlar.FindAsync(id);
            if (not == null)
            {
                return NotFound();
            }
            return View(not);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("NotId,Baslik,Icerik,TamamlanmaDurumu")] Not not)
        {
            if (id != not.NotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    not.SonDuzenlemeTarihi = DateTime.Now;
                    _context.Update(not);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotExists(not.NotId))
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
            return View(not);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var not = await _context.Notlar.FirstOrDefaultAsync(m => m.NotId == id);
            if (not == null)
            {
                return NotFound();
            }

            return View(not);
        }
        [HttpPost, ActionName("Delete")]
     
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var not = await _context.Notlar.FindAsync(id);
            _context.Notlar.Remove(not);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotExists(int id)
        {
            return _context.Notlar.Any(e => e.NotId == id);
        }
    }
}
 