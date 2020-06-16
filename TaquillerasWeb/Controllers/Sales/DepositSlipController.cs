using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Taquilleras.Data;
using TaquillerasWeb.Models;
using Taquilleras.Entities;

namespace TaquillerasWeb.Controllers.Sales
{

    public class DepositSlipController : Controller
    {

        //private taquillerassContext db = new taquillerassContext();
        private readonly IDbConnectionFactory _factory;
        private EntityManager<Taquilleras.Entities.DepositSlip> entitytem;
        public DepositSlipController(IDbConnectionFactory factory)
        {
            _factory = factory;
            entitytem = new Taquilleras.Data.EntityManager<Taquilleras.Entities.DepositSlip>(factory);
        }

        public IActionResult Lista()
        {
            return View(entitytem.GetAllAsync().Result);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Taquilleras.Entities.DepositSlip depositSlip)
        {
            if (ModelState.IsValid)
            {
                entitytem.CreateAsync(depositSlip).Wait();
            }
            return RedirectToAction(nameof(Lista));
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Taquilleras.Entities.DepositSlip result = entitytem.GetAsync(id).Result;
                if (result != null)
                {
                    return View(result);
                }
            }
            return RedirectToAction(nameof(Lista));
        }

        [HttpPost]
        public IActionResult Edit(Taquilleras.Entities.DepositSlip depositSlip)
        {
            if (ModelState.IsValid)
            {
                entitytem.UpdateAsync(depositSlip).Wait();
            }
            return RedirectToAction(nameof(Lista));
        }
    }
}