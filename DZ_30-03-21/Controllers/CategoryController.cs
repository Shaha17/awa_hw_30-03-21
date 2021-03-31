using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using DZ_30_03_21.Models;
using DZ_30_03_21.Context;
using Microsoft.EntityFrameworkCore;
using DZ_30_03_21.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace DZ_30_03_21.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ShopDbContext _shopDbContext;

		public CategoryController(ILogger<HomeController> logger, ShopDbContext shopDbContext)
		{
			_logger = logger;
			_shopDbContext = shopDbContext;
		}

		public async Task<IActionResult> Index()
		{
			var lst = await _shopDbContext.Categories.ToListAsync();
			return View(lst);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if (id <= 0)
			{
				return RedirectToAction("Index");
			}
			var rez = _shopDbContext.Categories.Find(id);
			if (rez == null)
			{
				return RedirectToAction("Index");
			}
			_shopDbContext.Categories.Remove(rez);
			await _shopDbContext.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CategoryViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			_shopDbContext.Categories.Add(new Models.Category() { Name = model.Name });

			await _shopDbContext.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (id <= 0)
			{
				return RedirectToAction("Index");
			}

			var rez = await _shopDbContext.Categories.FindAsync(id);

			if (rez == null)
			{
				return RedirectToAction("Index");
			}
			return View(new CategoryViewModel()
			{
				Id = rez.Id,
				Name = rez.Name,
			});
		}
		[HttpPost]
		public async Task<IActionResult> Edit(CategoryViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var rez = _shopDbContext.Categories.Find(model.Id);
			if (rez == null)
			{
				return RedirectToAction("Index");
			}

			rez.Name = model.Name;
			await _shopDbContext.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
