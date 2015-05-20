using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredArchitecturedApp.DAL;
using LayeredArchitecturedApp.Model;

namespace LayeredArchitecturedApp.BLL
{
    class Manager
    {
        Gateway gateway=new Gateway();




        public string  Save(Account anAccount)
        {
            int value;

            if (anAccount.AccountNumber.Length > 7)
            {
                value = gateway.Save(anAccount);

                if (value > 0)
                {
                    return "Saved Successfully";
                }
                else
                {
                    return "Save Failed";
                }

            }

            else
            {
                return "Account Number must be 8 characters long";

            }

           

        }


        public string Deposit(string accountNumber, decimal amount)
        {
            int value = gateway.Deposit(accountNumber, amount);

            if (value > 0)
            {
                return "Deposit Successfully";
            }
            else
            {
                return "Deposit Failed";
            }


        }



        public string Withdraw(string accountno,decimal amount)
        {
            decimal balance = gateway.GetBalance(accountno);
            
           
            if (balance > amount)
            {

                int  value = gateway.Withdraw(accountno, amount);

                if (value > 0)
                {
                    return "Withdraw Successfully";
                }
                else
                {
                    return "Withdraw Failed";
                }
            }

            else
            {
                return "Not Enough Balance";
            }

        }

        public List<Account> GetAccountList(List<Account>acccounts )
        {
            return gateway.GetData(acccounts);
        }


        public List<Account> GetSearchList(List<Account>accounts,string accountno)
        {
            accounts = new List<Account>();
            return gateway.Search(accounts,accountno);
        } 
    }
}
