using AkkaNetDemo;
using AkkaNetDemo.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GaneshWcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            new iner("99");
            List<iner> li = new List<iner>();
                li.Add(new iner("99"));
            c4 responseTradeMessage = CalcService.Start(li);
           // Console.WriteLine(JsonConvert.SerializeObject(responseTradeMessage, Newtonsoft.Json.Formatting.Indented));
            return string.Format("time taken: {0}", responseTradeMessage.Message);

        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
