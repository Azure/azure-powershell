using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Automation.Model
{
    public class HybridRunbookWorker : object
    {
        public HybridRunbookWorker()
        {

        }
        public HybridRunbookWorker(string ipAddress, string name, DateTimeOffset registrationDataTime)
        {
            this.IpAddress = ipAddress;
            this.Name = name;
            this.RegistrationDateTime = registrationDataTime;
        }
        public string IpAddress { get; set; }
        //
        // Summary:
        //     Optional. Gets or sets the worker machine name.
        public string Name { get; set; }
        //
        // Summary:
        //     Optional. Gets or sets the registration time of the worker machine.
        public DateTimeOffset RegistrationDateTime { get; set; }

    }
}
