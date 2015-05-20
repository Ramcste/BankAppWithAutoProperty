using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredArchitecturedApp.BLL;
using LayeredArchitecturedApp.DAL;
using LayeredArchitecturedApp.Model;

namespace LayeredArchitecturedApp
{
    public partial class BankAppUI : Form
    {
        public BankAppUI()
        {
            InitializeComponent();
        }

        Manager manager=new Manager();
        private void saveAccountButton_Click(object sender, EventArgs e)
        {
            Account anAccount=new Account();

            anAccount.CustomerName = customerNameTextBox.Text;
            anAccount.Email = emailTextBox.Text;
            anAccount.AccountNumber = accountNumberTextBox.Text;
            anAccount.OpeningDate = openingDateTextBox.Text;
            anAccount.Balance = 0;
            MessageBox.Show(manager.Save(anAccount));





        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
           
            
            string accountno = accountNumberEntryTextBox.Text;
            decimal amount = decimal.Parse(amountTextBox.Text);
           
            MessageBox.Show(manager.Withdraw(accountno,amount));


        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            string accountNumber = accountNumberEntryTextBox.Text;
            decimal amount = Convert.ToDecimal(amountTextBox.Text);
            MessageBox.Show(manager.Deposit(accountNumber, amount));
        }

        private void searchAccountNumberButton_Click(object sender, EventArgs e)
        {
            string accountnumber = accountNumberSearchTextBox.Text;

            accountInfoListView.Items.Clear();
            
            List<Account> accounts = new List<Account>();
            
            foreach (var account in manager.GetSearchList(accounts, accountnumber))
            {

                ListViewItem item = new ListViewItem();
                item.Text = account.AccountNumber;
                item.SubItems.Add(account.CustomerName);
                item.SubItems.Add(account.OpeningDate);
                item.SubItems.Add(account.Balance.ToString());

                accountInfoListView.Items.Add(item);



            }
        }

        private void BankAppUI_Load(object sender, EventArgs e)
        {
            List<Account>accounts=new List<Account>();

            


            foreach (var account in manager.GetAccountList(accounts))
            {

                ListViewItem item = new ListViewItem();
                item.Text = account.AccountNumber;
                item.SubItems.Add(account.CustomerName);
                item.SubItems.Add(account.OpeningDate);
                item.SubItems.Add(account.Balance.ToString());

                accountInfoListView.Items.Add(item);



            }
        }
    }
}
