using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PsDeploymentScript : PsAzureScriptBase
    {
        public ManagedServiceIdentity Identity { get; set; }

        public string Location { get; set; }

        public IDictionary<string,string> Tags { get; set; }

    }
}
