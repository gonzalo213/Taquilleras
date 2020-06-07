using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaquillerasWeb.Models;
using TaquillerasWeb.Services;

namespace TaquillerasWeb.Controllers
{
    public class CRUDController : Controller
    {
        private readonly CRUD1 _service;
        public CRUDController(CRUD1 service)
        {

            _service = service;
        }
        //[Route()]

        //[Route("Login/{id?}")]

        public IActionResult Lista()
        {
            var crud = _service.GetAll().Result;

            return View(crud);
        }

        //[Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            DepositSlip result = await _service.GetById(id);
            if (result != null)
            {
                return View(result);
            }
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepositSlip depositSlip)
        {
            if (ModelState.IsValid)
            {
                DepositSlip result = await _service.Create(depositSlip);
                if (result != null)
                {

                    return View(result);
                }
            }
            return RedirectToAction(nameof(Create));
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                DepositSlip result = _service.GetById(id).Result;
                if (result != null)
                {

                    return View(result);

                }
            }
            return RedirectToAction("Lista", "Fichas");

        }

        [HttpPost]

        public async Task<IActionResult> Edit(DepositSlip depositSlip)
        {
            if (ModelState.IsValid)
            {
                DepositSlip result = await _service.Update(depositSlip);
                if (result != null)
                {



                    return View(depositSlip);

                }
            }
            return View(null);
        }


        [HttpGet]

        public IActionResult Edit2(int? id)
        {
            if (id != null)
            {
                DepositSlip result = _service.GetById(id).Result;
                if (result != null)
                {

                    return View(result);

                }
            }
            return RedirectToAction("Lista", "Fichas");

        }
        [HttpPost]

        public async Task<IActionResult> Edit2(DepositSlip depositSlip)
        {
            if (ModelState.IsValid)
            {
                DepositSlip result = await _service.Update(depositSlip);
                if (result != null)
                {

                    ViewBag.nota = result;

                    return View(depositSlip);

                }
            }
            return View(null);
        }
        //[HttpGet]
        //public IActionResult Delete()
        //{
        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            DepositSlip result = await _service.GetById(id);
            if (result != null)
            {
                DepositSlip Fichas = await _service.Delete(result);
                if (Fichas != null)
                {
                    return RedirectToAction(nameof(Lista), new { Message = "Eliminado exitosamente" });
                }
            }
            return RedirectToAction(nameof(Lista));
        }


        [HttpGet]
        public async Task<IActionResult> Delete2(int id)
        {
            DepositSlip result = await _service.GetById(id);
            if (result != null)
            {
               DepositSlip Fichas = await _service.Delete(result);
                if (Fichas != null)
                {
                    return RedirectToAction("Lista", "Fichas");

                }
            }
            return RedirectToAction("Lista", "Fichas");

        }
    }
}