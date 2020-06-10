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
        public DepositSlipController(IDbConnectionFactory factory, IConfiguration configuration)
        {
            _factory = factory;
        }
        public IActionResult Lista()
        {
            Taquilleras.Data.EntityManager<Taquilleras.Entities.DepositSlip> entitytem = new Taquilleras.Data.EntityManager<Taquilleras.Entities.DepositSlip>(_factory);
            //Taquilleras.Entities.DepositSlip depo = new Taquilleras.Entities.DepositSlip();
            //{};
            var all = entitytem.GetAllAsync().Result;
            //entitytem.GetAllAsync().Wait();
            return View(all);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Taquilleras.Entities.DepositSlip depositSlip)
        {
            Taquilleras.Data.EntityManager<Taquilleras.Entities.DepositSlip> entitytem = new Taquilleras.Data.EntityManager<Taquilleras.Entities.DepositSlip>(_factory);
            if (ModelState.IsValid)
            {
                entitytem.CreateAsync(depositSlip).Wait();
            }
            return RedirectToAction(nameof(Lista));

        }


        //[HttpGet]

        //public IActionResult Edit(Taquilleras.Entities.DepositSlip depositSlip)
        //{
        //    if (depositSlip != null)
        //    {
        //        Taquilleras.Data.EntityManager<Taquilleras.Entities.DepositSlip> entitytem = new Taquilleras.Data.EntityManager<Taquilleras.Entities.DepositSlip>(_factory);

        //        entitytem.GetAsync(depositSlip).Wait();

        //        if (depositSlip != null)
        //        {

        //            return View(
        //                depositSlip);

        //        }
        //    }
        //    return RedirectToAction("Lista", "DepositSlip");

        //}

        //[HttpPost]

        //public async Task<IActionResult> Edit(DepositSlip depositSlip)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        DepositSlip result = await _service.Update(depositSlip);
        //        if (result != null)
        //        {



        //            return View(depositSlip);

        //        }
        //    }
        //    return View(null);
        //}


        
    }
}