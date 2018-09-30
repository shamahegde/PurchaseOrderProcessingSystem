using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPS
{
    public abstract class Account:IDisposable
    {
        public long _AccountNumber { get; private set; }//account number will be read-only to external world since private set is used
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        private int _balance;
        public int Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }
        public Account()
        {
           
        }
        ~Account()
        {
           Dispose();
        }
        public abstract void Dispose();

        public virtual void openAccount(int bal,string uname)
        {
            try
            {
                this._AccountNumber = AppData.GetNextAccNum();
                this.Username = uname;
                this.Balance = bal;
                AppData.accountsData.Add(this._AccountNumber, this);
                Console.WriteLine("Account Created:");
                this.getAccountDetails();
                Console.WriteLine(Environment.NewLine);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed to create Account ");
                Console.WriteLine(ex.Message);
                Console.WriteLine(Environment.NewLine);
            }
        }

        public virtual void editAccount(string uname)
        {
           

        }

        public abstract void withdraw(int amt,int displayLog= 1);        
        public virtual void deposit( int amt,int displayLog=1)
        {
            try
            {
                this.Balance = this.Balance + amt;
                if (displayLog == 1)
                {
                    Console.WriteLine("Amount Deposited for account :" + this._AccountNumber + " Balance:" + this.Balance);
                    Console.WriteLine(Environment.NewLine);
                }
            }
            catch(Exception ex)
            {
                if (displayLog == 1)
                {
                    Console.WriteLine("Failed to deposit amount");
                    Console.WriteLine(ex.Message);
                }
                else
                    throw ex;
            }
        }

        public virtual void getAccountDetails()
        {
            Console.WriteLine("AccountNumber:" + this._AccountNumber + " UserName:" + this._username + " Balance:" + this._balance);
        }
    }
}
