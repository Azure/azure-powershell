using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.HealthcareApis;
using System;

namespace Microsoft.Azure.Commands.HealthcareApisFhirService.Common
{
    public partial class HealthcareApisManagementClientWrapper
    {
        public IHealthcareApisManagementClient HealthcareApisManagementClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public HealthcareApisManagementClientWrapper(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<HealthcareApisManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public HealthcareApisManagementClientWrapper(IHealthcareApisManagementClient resourceManagementClient)
        {
            HealthcareApisManagementClient = resourceManagementClient;
        }
    }
}
