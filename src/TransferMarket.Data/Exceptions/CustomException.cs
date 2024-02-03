using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferMarket.Data.Exceptions
{
    public class CustomException
    {
        public int Code { get; init; }
        public string Message { get; init; }
    }
}
