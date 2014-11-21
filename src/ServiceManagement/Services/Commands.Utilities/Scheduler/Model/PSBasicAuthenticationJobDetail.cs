using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Model
{
    public class PSBasicAuthenticationJobDetail : PSHttpJobDetail
    {
        public string AuthenticationType = "Basic Authentication";

        public string Username { get; internal set; }

        public PSBasicAuthenticationJobDetail (PSHttpJobDetail jobDetail)
        {
            foreach(PropertyInfo prop in jobDetail.GetType().GetProperties())
            {
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(jobDetail, null), null);
            }
        }

        public PSBasicAuthenticationJobDetail()
        {            
        }
    }
}
