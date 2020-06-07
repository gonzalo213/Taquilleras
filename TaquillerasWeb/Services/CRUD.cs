using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaquillerasWeb.Models;
using Microsoft.AspNetCore.Razor.Language;

namespace TaquillerasWeb.Services
{
    public interface CRUD
    {
        Task<DepositSlip> Create(DepositSlip depositSlip);
        Task<IEnumerable<DepositSlip>> GetAll();
        Task<DepositSlip> GetById(int? id);
        Task<DepositSlip> Update(DepositSlip depositSlip);
        Task<DepositSlip> Delete(DepositSlip depositSlip);
    }
}
