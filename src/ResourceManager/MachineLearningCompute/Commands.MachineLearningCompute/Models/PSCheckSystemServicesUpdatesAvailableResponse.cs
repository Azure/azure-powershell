using Microsoft.Azure.Management.MachineLearningCompute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.MachineLearningCompute.Models
{
    class PSCheckSystemServicesUpdatesAvailableResponse : CheckSystemServicesUpdatesAvailableResponse
    {
        public PSCheckSystemServicesUpdatesAvailableResponse(CheckSystemServicesUpdatesAvailableResponse response)
            : base(response.UpdatesAvailable)
        {

        }
    }
}
