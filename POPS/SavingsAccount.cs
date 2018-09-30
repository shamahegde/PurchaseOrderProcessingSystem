using System;

namespace POPS
{
    public class SavingsAccount:Account,IROI,ITransaction
    {
        public int MaxAmountPerDay { get; set; }
        public string typeOfAccount
        {
            get
            {
                return "Savings";
            }
        }
        public SavingsAccount()
        {

        }
        public override void Dispose()
        {
            //dispose unamaged resources
        }

        public override void openAccount(int bal, string uname)
        {
            try
            {
                if (bal < 1000)
                    throw new MinBalException();
                base.openAccount(bal, uname);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed to create Account for "+ uname);
                Console.WriteLine(ex.Message);
                Console.WriteLine(Environment.NewLine);
            }
        }
        public override void editAccount(string uname)
        {
            try
            {
                this.Username = uname;
                AppData.accountsData[this._AccountNumber].Username = uname;
                Console.WriteLine("Edit Accout success!");
                Console.WriteLine(Environment.NewLine);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Edit Accout failed for "+ uname);
                Console.WriteLine(ex.Message);
                Console.WriteLine(Environment.NewLine);
            }
        }
        public void TransferAmount( long ToAccount, int amt)
        {
            try
            {
                if (AppData.accountsData[ToAccount] != null)
                {
                    this.withdraw(amt,0);
                    AppData.accountsData[ToAccount].deposit(amt,0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Transfer failed for " + this.Username);
                Console.WriteLine(ex.Message);
                Console.WriteLine(Environment.NewLine);
            }
        }
        public override void withdraw( int amt,int displayLog=1)
        {
            try
            {
                if (this.Balance - amt < 1000)
                    throw new MinBalException("Minimum balance after withdrawal must be 1000");
                else
                    this.Balance = this.Balance - amt;
                if (displayLog == 1)
                {
                    Console.WriteLine("Withdraw of " + amt + " success for " + this.Username);
                    Console.WriteLine("Balance is " + this.Balance);
                    Console.WriteLine(Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                if (displayLog == 1)
                {
                    Console.WriteLine("Withdraw failed for " + this.Username);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(Environment.NewLine);
                }
                else
                {
                    throw ex;
                }
            }
        }
        public double getRateOfInterest()
        {
            return Constants.ROI_SAVING;
        }
    }
}
