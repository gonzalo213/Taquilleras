
//using TaquillerasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaquillerasWeb.Services
{
    //public class CRUD1 : CRUD
    //{
    //    private readonly taquillerassContext _service;
    //    public CRUD1(taquillerassContext service)
    //    {
    //        _service = service;
    //    }
    //    public Task<DepositSlip> Create(DepositSlip depositSlip)
    //    {
    //        return Task.Run(() =>
    //        {

    //            try
    //            {
    //                _service.DepositSlip.Add(depositSlip);
    //                _service.SaveChanges();
    //                return depositSlip;
    //            }
    //            catch (Exception exp)
    //            {

    //                Console.WriteLine($"error:{exp}");
    //            }
    //            return null;
    //        });

    //    }

    //    public Task<DepositSlip> Delete(DepositSlip depositSlip)
    //    {
    //        return Task.Run(() =>
    //        {

    //            try
    //            {
    //                _service.DepositSlip.Remove(depositSlip);
    //                _service.SaveChanges();
    //                return depositSlip;
    //            }
    //            catch (Exception exp)
    //            {

    //                Console.WriteLine($"error:{exp}");
    //            }
    //            return null;
    //        });

    //    }

    //    public Task<IEnumerable<DepositSlip>> GetAll()
    //    {
    //        return Task.Run(() =>
    //        {

    //            try
    //            {
    //                return _service.DepositSlip.OrderBy(v => v.Id).AsEnumerable();

    //            }
    //            catch (Exception exp)
    //            {

    //                Console.WriteLine($"error:{exp}");
    //            }
    //            return null;
    //        });

    //    }

    //    public Task<DepositSlip> GetById(int? id)
    //    {
    //        return Task.Run(() => {


    //            if (id != null)
    //            {
    //                try
    //                {
    //                    var lop = _service.DepositSlip.Where(v => v.Id == id).First();
    //                    if (lop != null)
    //                    {
    //                        return lop;
    //                    }

    //                }
    //                catch (Exception exp)
    //                {

    //                    Console.WriteLine($"error:{exp}");
    //                }
    //            }
    //            return null;


    //        });
    //    }

    //    public Task<DepositSlip> Update(DepositSlip depositSlip)
    //    {
    //        return Task.Run(() =>
    //        {

    //            try
    //            {
    //                _service.DepositSlip.Update(depositSlip);
    //                _service.SaveChanges();
    //                return depositSlip;
    //            }
    //            catch (Exception exp)
    //            {

    //                Console.WriteLine($"error:{exp}");
    //            }
    //            return null;
    //        });

    //    }
    //}
}
