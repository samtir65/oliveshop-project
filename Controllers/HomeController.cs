using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OliveShop.Data;
using OliveShop.Models;
using System.Security.Claims;

namespace OliveShop.Controllers
{
    public class HomeController : Controller
    {
     
        private readonly ILogger<HomeController> _logger;
       private OliveshopContext _context;  
        public HomeController(ILogger<HomeController> logger,OliveshopContext context)
        {
            _logger = logger;
            _context=context;

        }

        public IActionResult Index()
        {
            var product=_context.Products.ToList();

            return View(product);
        }
        public IActionResult detail(int ItemId)
        {
            var product=_context.Products.Include(i=>i.item).SingleOrDefault(i=>i.ItemId==ItemId);
            var categories=_context.Products.Where(w=>w.ProductID==ItemId)
            .SelectMany(c=>c.categoritoProducts)
            .Select(ca=>ca.Category).ToList();

            if(product==null)
            {   

                return NotFound();
            }
            
        var vm=new DetailViewModel()
        {
            product=product,
            categories=categories

        };
            return View(vm);
        
        }
        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }
        [Authorize]
        public  IActionResult AddtoCart(int itemid)
        {
            var product=_context.Products.Include(i=>i.item).SingleOrDefault(p=>p.ProductID==itemid);
            if(product!=null)
            {
                int userid=int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order=_context.Orders.FirstOrDefault(o=>o.Userid==userid && !o.IsFinaly);
                if(order!=null)
                {
                    var orderdetails=_context.orderDetails.FirstOrDefault
                    (or=>or.OrderId==order.OrderId && or.ProductID==product.ProductID);
                    if(orderdetails!=null)
                    {
                        orderdetails.Count+=1;

                    }
                    else
                    {
                         _context.orderDetails.Add(new OrderDetails()
                    {
                        Count=1,
                        OrderId=order.OrderId,
                        ProductID=product.ProductID,
                        Price=product.item.Price  
                    });


                    }


                }
                else
                {
                    order=new order()
                    {
                        CreateDate=DateTime.Now,
                        IsFinaly=false,
                        Userid=userid,
                    };
                    _context.Add(order);
                    _context.SaveChanges();
                    _context.orderDetails.Add(new OrderDetails()
                    {
                        Count=1,
                        OrderId=order.OrderId,
                        ProductID=product.ProductID,
                        Price=product.item.Price  
                    });

                }
                _context.SaveChanges();
            }
            else
            {
                return NotFound();



            }
            return RedirectToAction("ShowCart");

            
        }

    [Authorize]
    public IActionResult ShowCart()
    
    {
    int userid=int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
    
    var order=_context.Orders.Where(o=>o.Userid==userid && !o.IsFinaly)
    .Include(o=>o.OrderDetails).ThenInclude(o=>o.product).FirstOrDefault();
       
    return View(order);
    }
    [Authorize]
    public IActionResult Removecart(int detailID)
    {
        var orderdetails=_context.orderDetails.FirstOrDefault(or=>or.detailID==detailID);
        if(orderdetails.Count<2)
        {
             _context.Remove(orderdetails);

        }
        orderdetails.Count-=1;
       
        _context.SaveChanges(); 
        return RedirectToAction("ShowCart");

    }
     
     public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
