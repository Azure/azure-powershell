using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Cmdlets.Websites.Helper.PrivateDns;
using Microsoft.Azure.PowerShell.Cmdlets.Websites.Helper.PrivateDns.Models;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    public class PrivateDnsClient
    {
        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public PrivateDnsClient(IAzureContext context)
        {
            this.WrappedPrivateDnsClient = AzureSession.Instance.ClientFactory.CreateArmClient<PrivateDnsManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public PrivateDnsManagementClient WrappedPrivateDnsClient
        {
            get;
            private set;
        }

        public void CreateAppServiceEnvironmentPrivateDnsZone(string resourceGroupName, string appServiceEnvironmentName, string virtualNetworkResourceId, string inboundPrivateIP)
        {
            var zoneName = $"{appServiceEnvironmentName}.appserviceenvironment.net";
            var privateZone = new PrivateZone(location: "Global");
            WrappedPrivateDnsClient.PrivateZones.CreateOrUpdate(resourceGroupName, zoneName, privateZone);

            var virtualNetworkLinkName = $"{appServiceEnvironmentName}_link";
            var virtualNetworkLinks = WrappedPrivateDnsClient.VirtualNetworkLinks.List(resourceGroupName, zoneName);
            bool foundLink = false;
            foreach (var link in virtualNetworkLinks)
            {
                if (link.VirtualNetwork.Id.ToLower() == virtualNetworkResourceId.ToLower())
                {
                    foundLink = true;
                    break;
                }
            }

            if (!foundLink)
            {
                var virtualNetwork = new SubResource(virtualNetworkResourceId);
                var virtualNetworkLink = new VirtualNetworkLink(location: "Global", virtualNetwork: virtualNetwork, registrationEnabled: false);
                WrappedPrivateDnsClient.VirtualNetworkLinks.CreateOrUpdate(resourceGroupName, zoneName, virtualNetworkLinkName, virtualNetworkLink, ifNoneMatch: "*");
            }

            var aseRecord = new ARecord(ipv4Address: inboundPrivateIP);
            var recordSet = new RecordSet(ttl: 3600);
            recordSet.ARecords = new List<ARecord>() { aseRecord };
            WrappedPrivateDnsClient.RecordSets.CreateOrUpdate(resourceGroupName, zoneName, RecordType.A, "*", recordSet);
            WrappedPrivateDnsClient.RecordSets.CreateOrUpdate(resourceGroupName, zoneName, RecordType.A, "@", recordSet);
            WrappedPrivateDnsClient.RecordSets.CreateOrUpdate(resourceGroupName, zoneName, RecordType.A, "*.scm", recordSet);
        }

        private void WriteVerbose(string verboseFormat, params object[] args)
        {
            if (VerboseLogger != null)
            {
                VerboseLogger(string.Format(verboseFormat, args));
            }
        }

        private void WriteWarning(string warningFormat, params object[] args)
        {
            if (WarningLogger != null)
            {
                WarningLogger(string.Format(warningFormat, args));
            }
        }

        private void WriteError(string errorFormat, params object[] args)
        {
            if (ErrorLogger != null)
            {
                ErrorLogger(string.Format(errorFormat, args));
            }
        }
    }
}
