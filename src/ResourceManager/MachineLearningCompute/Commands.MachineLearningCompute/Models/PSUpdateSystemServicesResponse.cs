using Microsoft.Azure.Management.MachineLearningCompute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.MachineLearningCompute.Models
{
    class PSUpdateSystemServicesResponse : UpdateSystemServicesResponse
    {
        public PSUpdateSystemServicesResponse(UpdateSystemServicesResponse response)
            : base(response.UpdateStatus, response.UpdateStartedOn, response.UpdateCompletedOn)
        {

        }
    }
}
