using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepend_Test.Business.Domain
{
    public class ChequeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public double Amount { get; set; }

        public string Pay { get; set; }
    }

    public class ChequeInfoList
    {
        public List<ChequeModel> ChequeModel { get; set; }
    }
}
