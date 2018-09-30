using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPS
{
    public static class AppData
    {
        public static long nextAccNum;
        public static Dictionary<long,Account> accountsData=new Dictionary<long,Account>();

        static AppData()
        {
            nextAccNum = 100000000000;
        }

        public static long GetNextAccNum()
        {
            nextAccNum+=1;
            return nextAccNum;
        }

        public static void RemoveAccount(long AccNum)
        {
            try
            {
                if (accountsData[AccNum] != null && accountsData[AccNum].Balance == 0)
                {
                    accountsData.Remove(AccNum);
                }
                else
                {
                    if (accountsData[AccNum].Balance != 0)
                        throw new BalanceNotZeroException();
                    else if (accountsData[AccNum] == null)
                        throw new InvalidAccNumberException();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Remove account failed for "+ AccNum);
                Console.WriteLine(ex.Message);
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
