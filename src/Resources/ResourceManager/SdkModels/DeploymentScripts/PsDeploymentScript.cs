using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PsDeploymentScript : PsAzureResourceBase
    {
        public string Identity { get; set; }

        public string Location { get; set; }

        public string Tags { get; set; }

    }
}
