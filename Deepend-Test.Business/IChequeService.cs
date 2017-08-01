using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deepend_Test.Business.Domain;

namespace Deepend_Test.Business
{
    public interface IChequeService
    {
        ChequeInfoList GetAllChequeList();
    }
}
