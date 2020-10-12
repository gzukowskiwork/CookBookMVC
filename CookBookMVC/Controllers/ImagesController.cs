using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CpntextLib.Context;
using Models.Models;
using Wrapper.Repository;
using Microsoft.AspNetCore.Authorization;
using EmailService;
using EmailLib;
using CookBookMVC.Installers.Services;

namespace CookBookMVC.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ISendEmail _sendEmail;
        public ImagesController(/*CookBookContext context*/ IRepositoryWrapper repositoryWrapper, ISendEmail sendEmail)
        {
            _repositoryWrapper = repositoryWrapper;
            _sendEmail = sendEmail;
        }

        // GET: Images
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            var message = new Message(new string[] { "grzegorz.zukowski.gda@gmail.com" }, "Test email", "This is the content from our email.");
            await _sendEmail.SendEmailAsync(message);
            return View(await _repositoryWrapper.ImageRepository.GetAllImages());
        }

        //// GET: Images/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var image = await _context.ImageModels
        //        .FirstOrDefaultAsync(m => m.ImageId == id);
        //    if (image == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(image);
        //}

        // GET: Images/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ImageId,Title,ImageName")] Image image)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(image);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(image);
        //}

        //// GET: Images/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var image = await _context.ImageModels.FindAsync(id);
        //    if (image == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(image);
        //}

        //// POST: Images/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("ImageId,Title,ImageName")] Image image)
        //{
        //    if (id != image.ImageId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(image);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ImageExists(image.ImageId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(image);
        //}

        //// GET: Images/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var image = await _context.ImageModels
        //        .FirstOrDefaultAsync(m => m.ImageId == id);
        //    if (image == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(image);
        //}

        //// POST: Images/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var image = await _context.ImageModels.FindAsync(id);
        //    _context.ImageModels.Remove(image);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ImageExists(string id)
        //{
        //    return _context.ImageModels.Any(e => e.ImageId == id);
        //}
    }
}
