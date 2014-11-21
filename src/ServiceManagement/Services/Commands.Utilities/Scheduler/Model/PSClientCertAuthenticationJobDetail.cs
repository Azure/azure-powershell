using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Model
{
    public class PSClientCertAuthenticationJobDetail : PSHttpJobDetail
    {
        public string AuthenticationType = "Client Certificate Authentication";

        public string ClientCertSubjectName { get; internal set; }

        public string ClientCertThumbprint { get; internal set; }

        public string ClientCertExpiryDate { get; internal set; }

        public PSClientCertAuthenticationJobDetail (PSHttpJobDetail jobDetail)
        {
            foreach(PropertyInfo prop in jobDetail.GetType().GetProperties())
            {
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(jobDetail, null), null);
            }
        }

        public PSClientCertAuthenticationJobDetail()
        {            
        }
    }
}
