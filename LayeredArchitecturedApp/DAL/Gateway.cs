using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredArchitecturedApp.Model;

namespace LayeredArchitecturedApp.DAL
{
    class Gateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["LayeredArchitectureConString"].ConnectionString;


        public int Save(Account anAccount)
        {

            string query = "INSERT INTO customer VALUES('"+anAccount.CustomerName+"','"+anAccount.Email+"','"+anAccount.AccountNumber+"','"+anAccount.OpeningDate+"','"+anAccount.Balance+"')";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        
       
        }


        public int Deposit(string accountNumber, decimal amount)
        {
           

            string query = "UPDATE  customer SET balance+='"+amount+"' WHERE cu_accountno='"+accountNumber+"'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
            
        }


        public Decimal GetBalance(string accountNo)
        {
            decimal balance=0;
            string query = "SELECT Balance FROM customer WHERE cu_accountno='"+accountNo+"'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                balance += decimal.Parse(reader["Balance"].ToString());
            }
            connection.Close();
            return balance;

        }


        public int Withdraw(string accountnumber,decimal amount)
        {

            string query = "UPDATE  customer SET balance-='" + amount + "' WHERE cu_accountno='" + accountnumber+"'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
            
            

        }



        public List<Account> GetData(List<Account>AccountList)
        {

            AccountList=new List<Account>();

            string query = "SELECT cu_accountno,cu_name,cu_openingdate,balance FROM customer ";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Account account=new Account();
                account.AccountNumber = reader["cu_accountno"].ToString();
                account.CustomerName = reader["cu_name"].ToString();
                account.OpeningDate = reader["cu_openingdate"].ToString();
                account.Balance = decimal.Parse(reader["balance"].ToString());

                AccountList.Add(account);
            }
            connection.Close();

            return AccountList;

           

        }



        public List<Account>Search(List< Account> accounts ,string  accountno)
        {
            accounts=new List<Account>();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT cu_accountno,cu_name,cu_openingDate,balance FROM customer WHERE (cu_accountno LIKE'" + accountno + "%')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();


            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Account account1 = new Account();

                account1.AccountNumber = reader["cu_accountno"].ToString();

                account1.CustomerName= reader["cu_name"].ToString();

                account1.OpeningDate = reader["cu_openingDate"].ToString();

                account1.Balance = decimal.Parse(reader["balance"].ToString());

                accounts.Add(account1);
            }

            reader.Close();
            connection.Close();

            return accounts;
        }
      
    }
}
