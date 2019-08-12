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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;
using Microsoft.Azure.Management.HealthcareApis.Models;
using Microsoft.Azure.Management.HealthcareApis;
using Microsoft.Azure.Commands.HealthcareApisService.Models;
using Microsoft.Azure.Commands.HealthcareApisService.Common;
using Microsoft.Azure.Commands.HealthcareApisService.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System;

namespace Microsoft.Azure.Commands.HealthcareApisService.Commands
{

    /// <summary>
    /// Class that creates a new instance of fhir service.
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HealthcareApisService", SupportsShouldProcess = true), OutputType(typeof(PSHealthcareApisService))]
    public class NewAzureRmHealthcareApisService : HealthcareApisBaseCmdlet
    {

        [Parameter(
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "HealthcareApis Service Name.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-z0-9][a-z0-9-]{1,21}[a-z0-9]$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "HealthcareApis Fhir Service Location.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.HealthcareApis/services")]
        public string Location { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Kind of HealthcareApis Service. The default value is Fhir")]
        [ValidateNotNullOrEmpty]
        public string Kind { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "List of Access Policy Object IDs.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^(([0-9A-Fa-f]{8}[-]?(?:[0-9A-Fa-f]{4}[-]?){3}[0-9A-Fa-f]{12}){1})+$")]
        public string[] AccessPolicyObjectId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service AllowCorsCredentials.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AllowCorsCredentials { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service Audience.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^((?:[hH][tT][tT][pP](?:[sS]|)\\:\\/\\/.+)|([0-9A-Fa-f]{8}[-]?(?:[0-9A-Fa-f]{4}[-]?){3}[0-9A-Fa-f]{12}))$")]
        public string Audience { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service Authority.")]
        [ValidateNotNullOrEmpty]
        public string Authority { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "HealthcareApis Fhir Service List of Cors Header.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsHeader { get; set; }


        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service Cors Max Age.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0,99999)]
        public int CorsMaxAge { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "HealthcareApis Fhir Service List of Cors Method.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsMethods { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service List of Cors Origin.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^(?:(?:(?:[hH][tT][tT][pP](?:[sS]|))\\:\\/\\/(?:[a-zA-Z0-9-]+[.]?)+(?:\\:[0-9]{1,5})?|[*]))$")]
        public string[] CorsOrigin { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "HealthcareApis Fhir Service CosmosOfferThroughput.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(400,10000)]
        public int? CosmosOfferThroughput { get; set; }


        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service EnableSmartProxy.")]
        public SwitchParameter EnableSmartProxy { get; set; }


        [Parameter(
            Mandatory = false,
            HelpMessage = "Fhir Version.")]
        [ValidateNotNullOrEmpty]
        public string FhirVersion { get; set; }


        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service Account Tags.")]
        [Alias(TagsAlias)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet as a job in the background.")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                if (AccessPolicyObjectId == null || AccessPolicyObjectId.Length == 0)
                {
                    AccessPolicyObjectId = new string[1];
                    string objectID = base.AccessPolicyID;
                    AccessPolicyObjectId[0] = objectID;
                }

                List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();
                foreach (string objectId in AccessPolicyObjectId)
                {
                    accessPolicies.Add(new ServiceAccessPolicyEntry(objectId));
                }

                ServicesDescription servicesDescription = new ServicesDescription()
                {
                    Kind = GetKind(),
                    Location = Location,
                    Tags = this.GetTags(),

                    Properties = new ServicesProperties()
                    {
                        AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo() { Authority = GetAuthority(), Audience = GetAudience(), SmartProxyEnabled = EnableSmartProxy.ToBool() },
                        CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo() { OfferThroughput = GetCosmosDBThroughput()},
                        CorsConfiguration = new ServiceCorsConfigurationInfo() { Origins = CorsOrigin, Headers = CorsHeader, Methods = CorsMethods, MaxAge = CorsMaxAge, AllowCredentials = AllowCorsCredentials },
                        AccessPolicies = accessPolicies
                    }
                };

                if (ShouldProcess(this.Name, Resources.createService))
                {

                    this.EnsureNameAvailabilityOrThrow();

                    var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(
                                    this.ResourceGroupName,
                                    this.Name,
                                    servicesDescription);

                    var healthCareFhirService = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);

                    WriteObject(healthCareFhirService);
                }
            });
        }

        private Kind GetKind()
        {
            if(this.Kind == null && this.FhirVersion!=null)
            {
                if (FhirVersion.ToLowerInvariant() == "r4")
                {
                    return Management.HealthcareApis.Models.Kind.FhirR4;
                }
                else if (FhirVersion.ToLowerInvariant() == "stu3")
                {
                    return Management.HealthcareApis.Models.Kind.FhirStu3;
                }
                else
                {
                    throw new PSArgumentException(Resources.createService_InvalidFhirVersionMessage);
                }
            }
            else if(this.Kind== null && this.FhirVersion == null)
            {
                return Management.HealthcareApis.Models.Kind.FhirR4;
            }
            else if(this.FhirVersion != null)
            {
                return parseKindFromVersion(this.FhirVersion);
            }

            return parseKind(this.Kind);
        }

        private Kind parseKindFromVersion(string fhirVersion)
        {
            return parseKind(FhirVersion);
        }

        private Kind parseKind(string kind)
        {
            if (kind.ToLowerInvariant().Equals("fhir"))
            {
                return Management.HealthcareApis.Models.Kind.Fhir;
            }
            else if (kind.ToLowerInvariant().Equals("fhir-stu3") || kind.ToLowerInvariant().Equals("stu3"))
            {
                return Management.HealthcareApis.Models.Kind.FhirStu3;
            }
            else if (kind.ToLowerInvariant().Equals("fhir-r4") || kind.ToLowerInvariant().Equals("r4"))
            {
                return Management.HealthcareApis.Models.Kind.FhirR4;
            }
            else
            {
                throw new PSArgumentException(Resources.createService_InvalidKindMessage);
            }
        }

        private int? GetCosmosDBThroughput()
        {
            if (CosmosOfferThroughput == null)
            {
                return PSHealthcareApisFhirServiceCosmosDbConfig.defaultOfferThroughput;
            }

            return CosmosOfferThroughput;
            
        }

        private string GetAudience()
        {
            if (string.IsNullOrEmpty(this.Audience))
            {
                return PSHealthcareApisFhirServiceAuthenticationConfig.defaultAudience;
            }

            return this.Audience;
        }

        private string GetAuthority()
        {
            if (string.IsNullOrEmpty(this.Authority))
            {
                return PSHealthcareApisFhirServiceAuthenticationConfig.defaultAuthorityPrefix + this.TenantID();
            }

            return this.Authority;
        }

        private void EnsureNameAvailabilityOrThrow()
        {
            var checkNameInputs = new CheckNameAvailabilityParameters(this.Name, ResourceTypeName);
            var nameAvailabilityInfo = this.HealthcareApisClient.Services.CheckNameAvailability(checkNameInputs);
            if (nameAvailabilityInfo.NameAvailable != true)
            {
                throw new PSArgumentException(nameAvailabilityInfo.Message);
            }
        }

        private IDictionary<string, string> GetTags()
        {
            if (this.Tag != null)
            {
                return TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            }
            return null;
        }
    }
}
