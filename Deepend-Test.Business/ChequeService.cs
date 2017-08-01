using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using Deepend_Test.Business.Config;
using Deepend_Test.Business.Domain;
using Deepend_Test.Business.Utility;

namespace Deepend_Test.Business
{
    public class ChequeService : IChequeService
    {
        public ChequeInfoList GetAllChequeList()
        {
            if (!File.Exists(FileDataConfig.DataSource))
            {
                throw new FileNotFoundException($"file not found: {FileDataConfig.DataSource}", Path.GetFileName(FileDataConfig.DataSource));
            }
            else
            {
                FileStream fs = null;
                BufferedStream bs = null;
                StreamReader sr = null;

                try
                {
                    using (fs = File.Open(FileDataConfig.DataSource, FileMode.Open, FileAccess.Read))
                    using (bs = new BufferedStream(fs))
                    using (sr = new StreamReader(bs))
                    {
                        string jsonString = sr.ReadToEnd();
                        var data = new JavaScriptSerializer().Deserialize<ChequeInfoList>(jsonString);

                        data.ChequeModel.ForEach(x =>
                        {
                            x.Pay = DataFormatConverter.ConvertMoneyToEnglishWords(x.Amount);
                        });

                        return data;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    sr?.Dispose();
                    bs?.Dispose();
                    fs?.Dispose();
                }
            }
        }
    }
}
