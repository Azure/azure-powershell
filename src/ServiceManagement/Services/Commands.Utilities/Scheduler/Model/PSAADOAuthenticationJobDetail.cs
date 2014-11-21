using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Model
{
    public class PSAADOAuthenticationJobDetail : PSHttpJobDetail
    {
        public string AuthenticationType = "AAD OAuthentication";

        public string Tenant { get; internal set; }

        public string Audience { get; internal set; }

        public string ClientId { get; internal set; }

        public PSAADOAuthenticationJobDetail (PSHttpJobDetail jobDetail)
        {
            foreach(PropertyInfo prop in jobDetail.GetType().GetProperties())
            {
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(jobDetail, null), null);
            }
        }

        public PSAADOAuthenticationJobDetail()
        {            
        }
    }
}
