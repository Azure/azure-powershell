// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Commands.Cdn.Models.Profile;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnEndpoint", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSEndpoint))]
    public class NewAzureRmCdnEndpoint : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Azure CDN endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN profile name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group of the Azure CDN Profile.", ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Azure CDN profile object.", ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSProfile CdnProfile { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location of the CDN endpoint.", ParameterSetName = FieldsParameterSet)]
        [LocationCompleter("Microsoft.Cdn/profiles/endpoints")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The origin host header of the Azure CDN endpoint.")]
        public string OriginHostHeader { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The origin path Azure CDN endpoint.")]
        public string OriginPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The list of MIME types that need to be compressed by CDN edge nodes.")]
        public string[] ContentTypesToCompress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indiciates if compression should be enabled for this endpoint.")]
        public bool? IsCompressionEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates if HTTP should be enabled for this endpoint.")]
        public bool? IsHttpAllowed { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates if HTTPS should be enabled for this endpoint.")]
        public bool? IsHttpsAllowed { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Determines caching behavior for requests with query string. Valid values are IgnoreQueryString, BypassCaching, and UseQueryString.")]
        public PSQueryStringCachingBehavior? QueryStringCachingBehavior { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the origin. For display only.")]
        public string OriginName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The host name (address) of the origin.")]
        public string OriginHostName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The port used for HTTP traffic on the origin server.")]
        public int? HttpPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The port used for HTTPS traffic on the origin server.")]
        public int? HttpsPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies any optimization this endpoint has.")]
        public string OptimizationType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies the probe path for Dynamic Site Acceleration")]
        public string ProbePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The list of geo filters that applies to this endpoint.")]
        public PSGeoFilter[] GeoFilters { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The delivery policy for this endpoint.")]
        public PSDeliveryPolicy DeliveryPolicy { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure CDN endpoint.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The default origin group.")]
        [ValidateNotNullOrEmpty]
        public string DefaultOriginGroup { get; set; } 

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin priority.")]
        [ValidateNotNullOrEmpty]
        public int? Priority { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin weight.")]
        [ValidateNotNullOrEmpty]
        public int? Weight { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A custom message to be included in the approval request to connect to the Private Link.")]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkApprovalMessage { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin private link location.")]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkLocation { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin private link resource id.")]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin group ids.")]
        [ValidateNotNullOrEmpty]
        public List<string> OriginId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the origin group.")]
        public string OriginGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The number of seconds between health probes.")]
        [ValidateNotNullOrEmpty]
        public int OriginGroupProbeIntervalInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The path relative to the origin that is used to determine the health of the origin.")]
        [ValidateNotNullOrEmpty]
        public string OriginGroupProbePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Protocol to use for health probe.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Http", "Https")]
        public string OriginGroupProbeProtocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The type of health probe request that is made.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("GET", "HEAD")]
        public string OriginGroupProbeRequestType { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ProfileName = CdnProfile.Name;
                ResourceGroupName = CdnProfile.ResourceGroupName;
                Location = CdnProfile.Location;
            }

            var checkExists = CdnManagementClient.CheckNameAvailability(EndpointName);

            if (!checkExists.NameAvailable.Value)
            {
                throw new PSArgumentException(string.Format(
                    Resources.Error_CreateExistingEndpoint,
                    EndpointName));
            }

            ConfirmAction(MyInvocation.InvocationName,
                EndpointName,
                () => NewEndpoint());

        }

        private void NewEndpoint()
        {
            try
            {
                Management.Cdn.Models.Endpoint endpoint = new Management.Cdn.Models.Endpoint();
                endpoint.ContentTypesToCompress = ContentTypesToCompress;
                endpoint.IsCompressionEnabled = IsCompressionEnabled;
                endpoint.IsHttpAllowed = IsHttpAllowed;
                endpoint.IsHttpsAllowed = IsHttpsAllowed;
                endpoint.Location = Location;
                endpoint.OriginHostHeader = OriginHostHeader;
                endpoint.OriginPath = OriginPath;
                endpoint.OptimizationType = OptimizationType;
                endpoint.ProbePath = ProbePath;
                endpoint.DeliveryPolicy = DeliveryPolicy?.ToSdkDeliveryPolicy();
                endpoint.GeoFilters = GeoFilters?.Select(g => g.ToSdkGeoFilter()).ToList();
                endpoint.Tags = Tag.ToDictionaryTags();

                endpoint.Origins = new List<DeepCreatedOrigin>();
                endpoint.Origins.Add(CreateOrigin());

                if (!String.IsNullOrWhiteSpace(OriginGroupName))
                {
                    endpoint.OriginGroups = new List<DeepCreatedOriginGroup>();
                    endpoint.OriginGroups.Add(CreateOriginGroup());
                }
               
                if (QueryStringCachingBehavior != null)
                {
                    endpoint.QueryStringCachingBehavior = QueryStringCachingBehavior.Value.CastEnum<PSQueryStringCachingBehavior, QueryStringCachingBehavior>();
                }
                else
                {
                    endpoint.QueryStringCachingBehavior = (QueryStringCachingBehavior?)null;
                }

                if(!String.IsNullOrWhiteSpace(DefaultOriginGroup))
                {
                    endpoint.DefaultOriginGroup = new ResourceReference(DefaultOriginGroup);
                }


                var createdEndpoint = CdnManagementClient.Endpoints.Create(ResourceGroupName, ProfileName, EndpointName, endpoint);

                WriteVerbose(Resources.Success);
                WriteObject(createdEndpoint.ToPsEndpoint());
            }
            catch (ErrorResponseException e)
            {
                throw new PSArgumentException(string.Format("Error response received.Error Message: '{0}'",
                                     e.Response.Content));
            }
        }

        private DeepCreatedOrigin CreateOrigin()
        {
            DeepCreatedOrigin origin = new DeepCreatedOrigin();
            origin.Name = OriginName;
            origin.HostName = OriginHostName;
            origin.HttpPort = HttpPort;
            origin.HttpsPort = HttpsPort;
            origin.Priority = Priority;
            origin.Weight = Weight;
            origin.PrivateLinkApprovalMessage = PrivateLinkApprovalMessage;
            origin.PrivateLinkLocation = PrivateLinkLocation;
            origin.PrivateLinkResourceId = PrivateLinkResourceId;

            return origin;
        }

        private DeepCreatedOriginGroup CreateOriginGroup()
        {
            DeepCreatedOriginGroup originGroup = new DeepCreatedOriginGroup();

            originGroup.Name = OriginGroupName;

            originGroup.Origins = new List<ResourceReference>();

            if (OriginId != null)
            {
                // OriginId refers to the list of origin ids, needed to be singular name per PS guidelines
                foreach (string originId in OriginId)
                {
                    ResourceReference originIdResourceReference = new ResourceReference(originId);
                    originGroup.Origins.Add(originIdResourceReference);
                }
            }

            bool isProbeIntervalInSecondsNotZero = OriginGroupProbeIntervalInSeconds != 0 ? true : false;

            if (isProbeIntervalInSecondsNotZero || !String.IsNullOrWhiteSpace(OriginGroupProbePath) || !String.IsNullOrWhiteSpace(OriginGroupProbeProtocol) || !String.IsNullOrWhiteSpace(OriginGroupProbeRequestType))
            {
                int probeIntervalCopy = OriginGroupProbeIntervalInSeconds;

                // when probe interval is 0 or not specified, set the probe interval to the default value
                if (!isProbeIntervalInSecondsNotZero)
                {
                    probeIntervalCopy = 240;
                }

                originGroup.HealthProbeSettings = new HealthProbeParameters
                {
                    ProbeIntervalInSeconds = probeIntervalCopy,
                    ProbePath = OriginGroupProbePath,
                    ProbeProtocol = OriginGroupUtilities.NormalizeProbeProtocol(OriginGroupProbeProtocol),
                    ProbeRequestType = OriginGroupUtilities.NormalizeProbeRequestType(OriginGroupProbeRequestType)
                };
            }

            return originGroup;
        }
    }
}
