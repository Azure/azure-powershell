using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    public class PrivateEndpointConnectionBaseCmdlet : PrivateLinkServiceBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByResourceId",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("ResourceName")]
        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The private link service name.",
           ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "ByResource")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The private link resource type.",
          ParameterSetName = "ByResource")]
        public string PrivateLinkResourceType { get; set; }

        protected IPrivateLinkProvider BuildProvider(string resourceType)
        {
            IPrivateLinkProvider provider = null;

            switch (resourceType.ToLower())
            {
                case "microsoft.sql/servers":
                    provider = new SqlProvider(this);
                    break;
                case "microsoft.network/privatelinkservices":
                default:
                    provider = new NetworkingProvider(this);
                    break;
            }

            return provider;
        }
    }
}
