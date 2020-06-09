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
    public class TransactionController : Controller
    {
        private taquillerassContext db = new taquillerassContext();
        private readonly IDbConnectionFactory _factory;

        public TransactionController(IDbConnectionFactory factory, IConfiguration configuration)
        {
            _factory = factory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            Taquilleras.Entities.Transaction salesTransacction = new Taquilleras.Entities.Transaction { KeyTaq = 1, DateVenta = DateTime.Now.Date, ShiftTypeId = 1, Status = "A" };
            salesTransacction.TransactionDetail = new List<Taquilleras.Entities.TransactionDetail> { new Taquilleras.Entities.TransactionDetail { Id = 50, Quantity = 500 }, new Taquilleras.Entities.TransactionDetail { Id = 1, Quantity = 70 } };
            return View(salesTransacction);
        }
        [HttpPost]
        public IActionResult Index(Taquilleras.Entities.Transaction salesTransacction)
        {
                       return View();
        }
        [HttpGet]
        public IActionResult Operation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Operation(TransactionTem tem)
        {

            Taquilleras.Entities.Transaction salesTransacction = new Taquilleras.Entities.Transaction {KeyTaq = 1,DateVenta = tem.SalesDate, ShiftTypeId = 1, Status = "A" };
            salesTransacction.TransactionDetail = new HashSet<Taquilleras.Entities.TransactionDetail> { new Taquilleras.Entities.TransactionDetail() { ProductId = 1, MovementTypeId = 1, Quantity = tem.ImportTicketRecived, TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 1, MovementTypeId = 2, Quantity= tem.ImportTicketDotation,TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 1, MovementTypeId = 3, Quantity = tem.ImportTicketSale,TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 2, MovementTypeId = 1, Quantity = tem.ImportCardRecived,TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 2, MovementTypeId = 2, Quantity = tem.ImportCardDotation,TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 2, MovementTypeId = 3, Quantity = tem.ImportCardSale,TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 3, MovementTypeId = 3, Quantity = tem.ImporRefillSale,TransactionId = salesTransacction.Id },
                                                                        };
            Taquilleras.Data.TransactionData entity = new Taquilleras.Data.TransactionData(_factory);
            entity.AddCompleate(salesTransacction);

            Taquilleras.Data.EntityManager<Taquilleras.Entities.DepositSlip> entitytem   = new Taquilleras.Data.EntityManager<Taquilleras.Entities.DepositSlip>(_factory);
            Taquilleras.Entities.DepositSlip depo = new Taquilleras.Entities.DepositSlip() { ShiftTypeId = 1, TicketOfficeId= 1, Expediente = "12334", 
                DateDeposit = DateTime.Now.Date, DateSale= DateTime.Now.Date, Import = 500,
                NumEnvase = "666",NumFicha="666", Status ="A"
            };
            entitytem.CreateAsync(depo).Wait();

            /*
            entity.CreateAsync(salesTransacction).Wait();
           
            Taquilleras.Data.TransactionDetailsData entityDetail = new TransactionDetailsData(_factory);
            HashSet<Taquilleras.Entities.TransactionDetail> details = new HashSet<Taquilleras.Entities.TransactionDetail>();
            if (tem.ImportTicketRecived>0)
                details.Add(new Taquilleras.Entities.TransactionDetail() { ProductId = 1, MovementTypeId = 1, Quantity = tem.ImportTicketRecived, TransactionId = salesTransacction.Id });
            if (tem.ImportTicketDotation > 0)
                details.Add(new Taquilleras.Entities.TransactionDetail() { ProductId = 1, MovementTypeId = 2, Quantity = tem.ImportTicketDotation, TransactionId = salesTransacction.Id });
            if (tem.ImportTicketSale > 0)
                details.Add(new Taquilleras.Entities.TransactionDetail() { ProductId = 1, MovementTypeId = 3, Quantity = tem.ImportTicketSale, TransactionId = salesTransacction.Id });
            if (tem.ImportCardRecived > 0)
                details.Add(new Taquilleras.Entities.TransactionDetail() { ProductId = 2, MovementTypeId = 1, Quantity = tem.ImportCardRecived, TransactionId = salesTransacction.Id });
            if (tem.ImportCardDotation > 0)
                details.Add(new Taquilleras.Entities.TransactionDetail() { ProductId = 2, MovementTypeId = 2, Quantity = tem.ImportCardDotation, TransactionId = salesTransacction.Id });
            if (tem.ImportCardDotation > 0)
                details.Add(new Taquilleras.Entities.TransactionDetail() { ProductId = 2, MovementTypeId = 3, Quantity = tem.ImportCardSale, TransactionId = salesTransacction.Id });
            if (tem.ImporRefillSale > 0)
                details.Add(new Taquilleras.Entities.TransactionDetail() { ProductId = 3, MovementTypeId = 3, Quantity = tem.ImporRefillSale, TransactionId = salesTransacction.Id });
            entityDetail.AddRange(details);
/*
            entityDetail.AddRange(new HashSet<Taquilleras.Entities.TransactionDetail> { new Taquilleras.Entities.TransactionDetail() { ProductId = 1, MovementTypeId = 1, Quantity = tem.ImportTicketRecived, TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 1, MovementTypeId = 2, Quantity= tem.ImportTicketDotation,TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 1, MovementTypeId = 3, Quantity = tem.ImportTicketSale,TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 2, MovementTypeId = 1, Quantity = tem.ImportCardRecived,TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 2, MovementTypeId = 2, Quantity = tem.ImportCardDotation,TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 2, MovementTypeId = 3, Quantity = tem.ImportCardSale,TransactionId = salesTransacction.Id },
                                                                        new Taquilleras.Entities.TransactionDetail() { ProductId = 3, MovementTypeId = 3, Quantity = tem.ImporRefillSale,TransactionId = salesTransacction.Id },
                                                                        });
           
            //entity.CreateAsync(salesTransacction).Wait();*/
            return View(tem);
        }
    }
    public class TransactionTem
    {
        public DateTime SalesDate { set; get; }
        public decimal ImportTicketRecived { set; get; }
        public decimal ImportTicketDotation { set; get; }
        public decimal ImportTicketSale { set; get; }
        public decimal ImportCardRecived { set; get; }
        public decimal ImportCardDotation { set; get; }
        public decimal ImportCardSale { set; get; }
        public decimal ImporRefillSale { set; get; }

    }
}