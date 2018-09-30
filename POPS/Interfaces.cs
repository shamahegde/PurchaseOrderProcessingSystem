using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPS
{
    public interface IROI
    {
        string typeOfAccount { get; }
        double getRateOfInterest();
    }
    public interface ITransaction
    {
        void TransferAmount( long destAccNum, int amt);
    }
}
