using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public class JsonConvertor
    {
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                //List<GetAdobeCorporateEntityRequest> items = JsonConvert.DeserializeObject<List<GetAdobeCorporateEntityRequest>>(json);
            }
        }
    }
}
