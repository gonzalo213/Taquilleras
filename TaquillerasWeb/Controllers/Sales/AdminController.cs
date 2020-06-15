using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaquillerasWeb.Controllers.Sales;
using Taquilleras.Data;
using Taquilleras.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;

namespace TaquillerasWeb.Controllers.Sales
{
    public class AdminController : Controller
    {
        private readonly IDbConnectionFactory _factory;
        TransactionData td;
        EntityManager<Product> producManager;
        EntityManager<ActionType> actionManager;
        public AdminController(IDbConnectionFactory factory)
        {
            _factory = factory;
            td = new TransactionData(this._factory);
            producManager = new EntityManager<Product>(this._factory);
            actionManager = new EntityManager<ActionType>(this._factory);
        }
        public IActionResult Index()
        {
            EntityManager<TicketOffice> admTicketOffice = new EntityManager<TicketOffice>(this._factory);
            List<TicketOffice> lst = admTicketOffice.GetAllAsync().Result.ToList();
            ViewBag.entities = (List<SelectListItem>)lst.ConvertAll(d => { return new SelectListItem() { Value = d.Id.ToString(), Text = d.Description }; });
            return View();
        }
        [HttpPost]
        public IActionResult Find(Microsoft.AspNetCore.Http.IFormCollection elements)
        {
            List<Transaction> transactions = new List<Transaction>();
            transactions.AddRange(td.Find(DateTime.Parse(elements["dpFilter"].ToString()), int.Parse(elements["Taquilla"].ToString())));
            List<Transaction> transactionsTem = new List<Transaction>(transactions.Count);
            transactions.ForEach((item) => transactionsTem.Add(item.Clone()));

            foreach (Transaction transaction in transactionsTem)
                foreach (Product producto in producManager.GetAllAsync().Result.ToList())
                    foreach (ActionType action in actionManager.GetAllAsync().Result.ToList())
                    {
                        TransactionDetail tem = new TransactionDetail()
                        {
                            Product = new Product() { IdProduct = producto.IdProduct, Description = producto.Description },
                            MovementType = new ActionType() { IdTipoMovimiento = action.IdTipoMovimiento, Description = action.Description },
                            Transaction = new Transaction() { Id = transaction.Id },
                            Quantity = 0,
                            Price = 0,
                        };
                        if (transactions.Where(t => t.Id == transaction.Id).ToList().Count > 0)
                        {
                            if (transactions.Where(t => t.Id == transaction.Id).First().TransactionDetail.Where(m => m.ProductId == producto.IdProduct && m.MovementTypeId == action.IdTipoMovimiento).ToList().Count > 0)
                            {
                                TransactionDetail tl = transactions.Where(t => t.Id == transaction.Id).First().TransactionDetail.Where(m => m.ProductId == producto.IdProduct && m.MovementTypeId == action.IdTipoMovimiento).First();
                                tem.Id = tl.Id;
                                tem.InvalidValue = tl.InvalidValue;
                                tem.Price = tl.Price;
                                tem.Quantity = tl.Quantity;
                                tem.Transaction = tl.Transaction;
                                tem.InvalidValue = tl.InvalidValue;
                                tem.Transaction = new Transaction() { Id = transaction.Id };
                            }
                        }
                        if (producto.IdProduct != 3)
                            transaction.TransactionDetail.Add(tem);
                        else if (producto.IdProduct == action.IdTipoMovimiento)
                            transaction.TransactionDetail.Add(tem);
                    }

            EntityManager<TicketOffice> admTicketOffice = new EntityManager<TicketOffice>(this._factory);
            List<TicketOffice> lst = admTicketOffice.GetAllAsync().Result.ToList();
            ViewBag.entities = (List<SelectListItem>)lst.ConvertAll(d => { return new SelectListItem() { Value = d.Id.ToString(), Text = d.Description }; });

            return View("~/Views/Admin/Index.cshtml", transactionsTem);
        }

        [HttpGet]
        public IActionResult Edit()
        {


            List<TransactionTem> details = new List<TransactionTem> {  new TransactionTem { ImportCardDotation = 500 },
                                                                        new TransactionTem { ImportCardDotation = 70 } ,
                                                                        new TransactionTem { ImportCardDotation  = 400 } };
            return View(details);

        }
        [HttpPost]
        public IActionResult Edit(object array)
        {
            return View();
        }
        [HttpPost]
        public JsonResult Test(dynamic name)
        {
            return Json("Hola Mundo");
        }
    }
}