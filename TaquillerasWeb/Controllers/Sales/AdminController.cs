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
        EntityManager<TicketOffice> admTicketOffice;
        List<TicketOffice> lst;
        public AdminController(IDbConnectionFactory factory)
        {
            _factory = factory;
            td = new TransactionData(this._factory);
            producManager = new EntityManager<Product>(this._factory);
            actionManager = new EntityManager<ActionType>(this._factory);
            admTicketOffice = new EntityManager<TicketOffice>(this._factory);
            lst = admTicketOffice.GetAllAsync().Result.ToList();            
        }
        public IActionResult Index()
        {
            TempData["TicketOffices"] = (List<SelectListItem>)lst.ConvertAll(d => { return new SelectListItem() { Value = d.Id.ToString(), Text = d.Description }; });
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

            TempData["TicketOffices"] = (List<SelectListItem>)lst.ConvertAll(d => { return new SelectListItem() { Value = d.Id.ToString(), Text = d.Description }; });
            return View("~/Views/Admin/Index.cshtml", transactionsTem);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Edit(object array)
        {
            return View();
        }
        public IActionResult Test(string data)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (string element in data.Replace("{\"ClientTransaction\":[", "").Replace("]}", "").Replace("\"", "").Replace("z", "").Split("},{"))
            {
                int idTransaction = int.Parse(element.Split(":").Last().ToString().Split("_").First().ToString());
                int idDetail = int.Parse(element.Split(":").Last().ToString().Split("_").ToArray()[1].ToString());
                int idProduct = int.Parse(element.Split(":").Last().ToString().Split("_").ToArray()[2].ToString());
                int idType = int.Parse(element.Split(":").Last().ToString().Split("_").ToArray()[3].ToString());

                if (transactions.Count == 0)
                    transactions.Add(new Transaction() { Id = idTransaction });
                else
                {

                }
                    if (transactions.Where(t => t.Id == idTransaction).Count() > 0)
                    transactions.Where(t => t.Id == idTransaction).First().TransactionDetail.Add(new TransactionDetail() { Id = idTransaction, ProductId = idProduct, MovementTypeId = idType });
                else
                {
                    Transaction transactionTem = new Transaction() { Id = idTransaction };
                    transactionTem.TransactionDetail.Add(new TransactionDetail() { Id = idTransaction, ProductId = idProduct, MovementTypeId = idType });
                }
            }
            return Json("Hola Mundo");
        }
    }
    public class ClientTransaction {
        public string ProducId { get; set; }
        public string Value { get; set; }
    }
}