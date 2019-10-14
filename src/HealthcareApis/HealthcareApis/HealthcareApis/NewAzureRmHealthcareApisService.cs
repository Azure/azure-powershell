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
using Microsoft.Azure.Commands.HealthcareApis.Models;
using Microsoft.Azure.Commands.HealthcareApis.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.HealthcareApis.Properties;
using System;
using Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Common;

namespace Microsoft.Azure.Commands.HealthcareApis.Commands
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
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "HealthcareApis Service Location.")]
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
        public string[] AccessPolicyObjectId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service AllowCorsCredentials.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AllowCorsCredential { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service Audience.")]
        [ValidateNotNullOrEmpty]
        public string Audience { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service Authority.")]
        [ValidateNotNullOrEmpty]
        public string Authority { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "HealthcareApis Fhir Service List of Cors Header. Specify HTTP headers which can be used during the request. Use \" * \" for any header.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsHeader { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service Cors Max Age. Specify how long a result from a request can be cached in seconds. Example: 600 means 10 minutes.")]
        [ValidateNotNullOrEmpty]
        public int CorsMaxAge { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "HealthcareApis Fhir Service List of Cors Method.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsMethod { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "HealthcareApis Fhir Service List of Cors Origin. Specify URLs of origin sites that can access this API, or use \" * \" to allow access from any site.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsOrigin { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "HealthcareApis Fhir Service CosmosOfferThroughput.")]
        [ValidateNotNullOrEmpty]
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
            try
            {
                base.ExecuteCmdlet();

                RunCmdLet(() =>
                {
                    List<ServiceAccessPolicyEntry> accessPolicies = GetAccessPolicies();

                    ServicesDescription servicesDescription = new ServicesDescription()
                    {
                        Kind = GetKind(),
                        Location = Location,
                        Tags = this.GetTags(),

                        Properties = new ServicesProperties()
                        {
                            AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo() { Authority = GetAuthority(), Audience = GetAudience(), SmartProxyEnabled = EnableSmartProxy.ToBool() },
                            CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo() { OfferThroughput = GetCosmosDBThroughput() },
                            CorsConfiguration = new ServiceCorsConfigurationInfo() { Origins = CorsOrigin, Headers = CorsHeader, Methods = CorsMethod, MaxAge = CorsMaxAge, AllowCredentials = AllowCorsCredential },
                            AccessPolicies = accessPolicies
                        }
                    };

                    if (ShouldProcess(this.Name, Resources.createService))
                    {

                        this.EnsureNameAvailabilityOrThrow();

                        try
                        {
                            var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(
                                            this.ResourceGroupName,
                                            this.Name,
                                            servicesDescription);

                            var healthCareFhirService = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);
                            WriteHealthcareApisAccount(healthCareFhirService);
                        }
                        catch (ErrorDetailsException wex)
                        {
                            WriteError(WriteErrorforBadrequest(wex));
                        }
                    }
                });
            }
            catch (KeyNotFoundException ex)
            {
                WriteError(new ErrorRecord(ex, Resources.keyNotFoundExceptionMessage, ErrorCategory.OpenError, ex));
            }
            catch (NullReferenceException ex)
            {
                WriteError(new ErrorRecord(ex, Resources.nullPointerExceptionMessage, ErrorCategory.OpenError, ex));
            }
        }

        private List<ServiceAccessPolicyEntry> GetAccessPolicies()
        {
            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();

            if (AccessPolicyObjectId == null || AccessPolicyObjectId.Length == 0)
            {
                string objectID = base.AccessPolicyID;
                accessPolicies.Add(new ServiceAccessPolicyEntry(objectID));
                return accessPolicies;
            }

            foreach (var objectID in AccessPolicyObjectId)
            {
                HealthcareApisArgumentValidator.ValidateObjectId(objectID);
                accessPolicies.Add(new ServiceAccessPolicyEntry(objectID));
            }

            return accessPolicies;
        }

        private Kind GetKind()
        {
            if (this.Kind == null && this.FhirVersion != null)
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
            else if (this.Kind == null && this.FhirVersion == null)
            {
                return Management.HealthcareApis.Models.Kind.FhirR4;
            }
            else if (this.FhirVersion != null)
            {
                return ParseKindFromVersion(this.FhirVersion);
            }

            return ParseKind(this.Kind);
        }

        private Kind ParseKindFromVersion(string fhirVersion)
        {
            return ParseKind(FhirVersion);
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
                return PSHealthcareApisFhirServiceAuthenticationConfig.defaultAuthorityPrefix + base.TenantID;
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
