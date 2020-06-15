using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaquillerasWeb.Controllers.Sales
{
    public class TransacctionItem
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
