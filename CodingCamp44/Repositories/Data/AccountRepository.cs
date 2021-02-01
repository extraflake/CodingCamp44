using CodingCamp44.Context;
using CodingCamp44.Models;
using CodingCamp44.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using CodingCamp44.Handler;
using CodingCamp44.Repositories;
using System.Net;
using System.Net.Mail;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dapper;

namespace CodingCamp44.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account, MyContext>
    {
        private readonly MyContext myContext;
        private DbSet<Account> accounts;
        private readonly SendEmail sendEmail = new SendEmail();
        private readonly PersonRepository personRepository;

        public AccountRepository(MyContext myContext, PersonRepository personRepository) : base (myContext)
        {
            myContext.Set<Account>();
            this.myContext = myContext;
            this.personRepository = personRepository;
        }

        public Login_VM LoginTaskSync(string email, string password)
        {
            Login_VM result = null;

            string connectStr = "Data Source=DESKTOP-ILI17T6;Initial Catalog=CodingCamp44;User ID=sa;Password=sapassword;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";//ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

            using (IDbConnection db = new SqlConnection(connectStr))
            {
                string readSp = "sp_retrieve_login";
                var parameter = new { Email = email, Password = password };
                result = db.Query<Login_VM>(readSp, parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }

	    public int Register(RegisterVM registerVM)
        {

            var person = new Person()
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
                Phone = registerVM.Phone,
                Address = registerVM.Address,
                BirthDate = registerVM.BirthDate,
                NIK = registerVM.NIK,
                Status = StatusPerson.Active
            };

            var account = new Account()
            {
                NIK = registerVM.NIK,
                Password = registerVM.Password,
                Status = StatusAccount.Active
            };

            var resPerson = personRepository.Create(person); 
            
            myContext.Add(account); 

            var resAccount = myContext.SaveChanges();

            if (resAccount > 0 && resPerson > 0) {
                return 1;
            }
            else
            {
                return 0;
            }
	    }
        
        public int ResetPassword(Account account, string email)
        {
            var data = myContext.Persons.Where(x => x.Email == email).FirstOrDefault();
            if(data == null)
            {
                return 0;
            }
            else
            {
                myContext.Entry(account).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                sendEmail.Send(email);
                return result;
            }
        }

        public int ChangePassword(string NIK, string password) 
        {
            Account acc = accounts.Find(NIK);
            acc.Password = password;
            myContext.Entry(acc).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }

         public Account getByNIK(string NIK) 
        {
            var result = myContext.Accounts.Where(a => a.NIK == NIK).FirstOrDefault();
            return result;
        }

        public Account GetAccountById(string id)
        {
            return accounts.Find(id);
        }

        public int DeleteAccount(string id)
        {
            if (accounts == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                Account account = accounts.Find(id);
                accounts.Remove(account);
                var result = myContext.SaveChanges();
                return result;
            }
        }
    }
}
