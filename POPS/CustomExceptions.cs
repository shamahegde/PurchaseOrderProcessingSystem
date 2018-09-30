using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPS
{
    public class MinBalException:Exception
    {
        public MinBalException():base("Minimum balance should be 1000")
        {

        }
        public MinBalException(string msg) : base(msg)
        {

        }
    }
    public class BalanceNotZeroException : Exception
    {
        public BalanceNotZeroException() : base("Balance must be 0 to remove an account!")
        {

        }
    }
    public class InvalidAccNumberException : Exception
    {
        public InvalidAccNumberException() : base("Invalid Account Number!")
        {

        }
    }
}
