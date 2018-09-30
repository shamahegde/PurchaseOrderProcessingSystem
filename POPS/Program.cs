using System;

namespace POPS
{
    class Program
    {
        public enum AccType { Savings=0,Current};
        static void Main(string[] args)
        {
            //create savings account
            createAccount(AccType.Savings,1100,"Shama");
            //create current account
            createAccount(AccType.Current, 2000, "Jane");
            //throw exception if account is opened with bal<1000
            createAccount(AccType.Savings, 10, "Vani");

            createAccount(AccType.Savings, 5000, "Philip");
            //remove account
            AppData.RemoveAccount(100000000001);
            //withdraw
            Account accObjJane = AppData.accountsData[100000000002];
            accObjJane.withdraw(1000);
            //withdraw again
            accObjJane.withdraw( 600);

            //withdraw from savings account
            Account accObjShama = AppData.accountsData[100000000001];
            accObjShama.withdraw(100);
            accObjShama.withdraw(100);
            //deposit
            SavingsAccount accObjPhilip = (SavingsAccount)AppData.accountsData[100000000003];
            accObjPhilip.deposit( 1000);

            //transfer from Philip to Jane
            Console.WriteLine("Before Transfer");
            accObjPhilip.getAccountDetails();
            accObjJane.getAccountDetails();
            accObjPhilip.TransferAmount(100000000002, 2000);
            Console.WriteLine("After Transfer");
            accObjPhilip.getAccountDetails();
            accObjJane.getAccountDetails();


            //edit account
            Console.WriteLine(Environment.NewLine);
            accObjJane.getAccountDetails();
            accObjJane.editAccount("Jovie");
            accObjJane.getAccountDetails();
            Console.ReadLine();
        }

        public static void createAccount(AccType actype,int bal,string uname)
        {
            try
            {
                if (actype == AccType.Savings)
                {
                    SavingsAccount s1 = new SavingsAccount();
                    s1.openAccount(bal, uname);
                }
                else if(actype == AccType.Current)
                {
                    CurrentAccount s1 = new CurrentAccount();
                    s1.openAccount(bal, uname);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
