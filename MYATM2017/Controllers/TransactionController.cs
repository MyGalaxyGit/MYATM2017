using MYATM2017.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYATM2017.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Deposit(int checkingAccountId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Deposit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                CheckingAccount checkingAccount = new CheckingAccount();
                db.Transactions.Add(transaction);
                checkingAccount= db.CheckingAccounts.Find(transaction.CheckingAccountId);
                //foreach (var item in checkingAccounts)
                //{
                
                //}
                checkingAccount.Balance = checkingAccount.Balance + transaction.Amount;
                //db.CheckingAccounts.SqlQuery("update table CheckingAccount set Balance=@balance where Id=@Id", new SqlParameter("@balance" = balance, "@Id" = id));
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

    }
}
