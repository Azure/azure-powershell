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

using Microsoft.Azure.Management.HealthcareApis.Models;
using Microsoft.Azure.Management.HealthcareApis;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.HealthcareApisFhirService.Properties;
using Microsoft.Azure.Commands.HealthcareApisFhirService.Models;
using Microsoft.Azure.Commands.HealthcareApisFhirService.Common;

namespace Microsoft.Azure.Commands.HealthcareApisFhirService.Commands
{

    /// <summary>
    /// Class that creates a new instance of fhir service.
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMStoragePrefix + "HealthcareApisFhirService", DefaultParameterSetName = ServiceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSFhirAccount))]
    public class NewAzureRmHealthcareApisFhirService : HealthcareApisBaseCmdlet
    {

        protected const string ServiceConfigParameterSet = "ServiceConfigParameterSet";
        protected const string ServiceNameParameterSet = "ServiceNameParameterSet";


        [Parameter(
          Mandatory = true,
          ParameterSetName = ServiceNameParameterSet,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "HealthcareApiFhirService Name.")]
        [Parameter(
          Mandatory = true,
          ParameterSetName = ServiceConfigParameterSet,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "HealthcareApiFhirService Name.")]
        [Alias(HealthcareApisAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-zA-Z0-9][a-zA-Z0-9_.-]*$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ParameterSetName = ServiceNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource Group Name.")]
        [Parameter(
           Mandatory = true,
           ParameterSetName = ServiceConfigParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ParameterSetName = ServiceNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Location.")]

        [Parameter(
           Mandatory = true,
           ParameterSetName = ServiceConfigParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
           Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
           HelpMessage = "CosmosOfferThroughput.")]
        [ValidateNotNullOrEmpty]
        public int CosmosOfferThroughput { get; set; }

        [Parameter(
            Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
            HelpMessage = "Authority.")]
        [ValidateNotNullOrEmpty]
        public string Authority { get; set; }


        [Parameter(
            Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
            HelpMessage = "Audience.")]
        [ValidateNotNullOrEmpty]
        public string Audience { get; set;}

        [Parameter(
          Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
          HelpMessage = "SmartyProxyEnabled.")]
        [ValidateNotNullOrEmpty]
        public bool SmartProxyEnabled { get; set; }

        [Parameter(
         Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
         HelpMessage = "List of Cors Origins.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsOrigins { get; set; }

        [Parameter(
        Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
        HelpMessage = "List of Cors Headers.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsHeaders { get; set; }

        [Parameter(
        Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
        HelpMessage = "List of Cors Methods.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsMethods { get; set; }

        [Parameter(
        Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
        HelpMessage = "Cors Max Age.")]
        [ValidateNotNullOrEmpty]
        public int CorsMaxAge { get; set; }

        [Parameter(
        Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
        HelpMessage = "Cors Allow Credentials.")]
        [ValidateNotNullOrEmpty]
        public bool CorsAllowCredentials { get; set; }

        [Parameter(
        Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
        HelpMessage = "List of Access Policy Object IDs.")]
        [ValidateNotNullOrEmpty]
        public string[] AccessPolicyObjectIds { get; set; }

        [Parameter(Mandatory = false,
        ParameterSetName = ServiceNameParameterSet,
        HelpMessage = "Config Object")]
        [Parameter(Mandatory = false, ParameterSetName = ServiceConfigParameterSet, HelpMessage = "List of tags.")]
        [ValidateNotNullOrEmpty]
        public string[] Tags { get; set; }


        [Parameter( Mandatory = false,
        ParameterSetName = ServiceNameParameterSet,
        HelpMessage = "List of tags.")]
        [Parameter( Mandatory = false, ParameterSetName = ServiceConfigParameterSet, HelpMessage = "List of tags.")]
        [ValidateNotNullOrEmpty]
        public PSServiceConfig FhirServiceConfig { get; set; }

        [Parameter(
        Mandatory = false,
        ParameterSetName = ServiceNameParameterSet,
        HelpMessage = "Fhir Version.")]
        [Parameter(
        Mandatory = false,
        ParameterSetName = ServiceConfigParameterSet,
        HelpMessage = "Fhir Version.")]
        [ValidateNotNullOrEmpty]
        public string FhirVersion { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                switch (ParameterSetName)
                {
                    case ServiceNameParameterSet:
                        {
                           if(AccessPolicyObjectIds==null || AccessPolicyObjectIds.Length == 0)
                            {
                                string objectID = base.AccessPolicyID;
                                AccessPolicyObjectIds[0] = objectID;
                            }

                            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();
                            foreach(string objectId in AccessPolicyObjectIds)
                            {
                                accessPolicies.Add(new ServiceAccessPolicyEntry(objectId));
                            }


                            ServicesDescription servicesDescription = new ServicesDescription()
                            {
                                Location = Location,
                                Properties = new ServicesProperties()
                                {
                                    AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo() { Authority = Authority, Audience = Audience },
                                    CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo() { OfferThroughput = CosmosOfferThroughput },
                                    CorsConfiguration = new ServiceCorsConfigurationInfo() { Origins = CorsOrigins, Headers = CorsHeaders, Methods = CorsMethods, MaxAge = CorsMaxAge, AllowCredentials = CorsAllowCredentials },
                                    AccessPolicies = accessPolicies
                                }
                            };

                            if (ShouldProcess(this.Name, Properties.Resources.createService))
                            {
                                var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(
                                               this.ResourceGroupName,
                                               this.Name,
                                               servicesDescription);

                                var healthcareApisFhirServiceAccount = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);

                                WriteObject(healthcareApisFhirServiceAccount);
                            }
                            break;
                        }
                    case ServiceConfigParameterSet:
                        {

                            IList<PSAccessPolicyEntry> entries = FhirServiceConfig.AccessPolicies;
                            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();

                            foreach(PSAccessPolicyEntry entry in entries)
                            {
                                accessPolicies.Add(new ServiceAccessPolicyEntry(entry.ObjectId));
                            }

                            if (accessPolicies.Count == 0)
                            {
                                accessPolicies.Add(new ServiceAccessPolicyEntry(base.AccessPolicyID));
                            }

                            ServicesDescription servicesDescription = new ServicesDescription()
                            {
                                Location = Location,
                                Properties = new ServicesProperties()
                                {
                                    AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo() { Authority = FhirServiceConfig.AuthenticationConfiguration.Authority, Audience = FhirServiceConfig.AuthenticationConfiguration.Audience },
                                    CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo() { OfferThroughput = FhirServiceConfig.CosmosDbConfiguration.OfferThroughput },
                                    CorsConfiguration = new ServiceCorsConfigurationInfo() { Origins = FhirServiceConfig.CorsConfiguration.Origins, Headers = FhirServiceConfig.CorsConfiguration.Headers, Methods = FhirServiceConfig.CorsConfiguration.Methods, MaxAge = FhirServiceConfig.CorsConfiguration.MaxAge, AllowCredentials = FhirServiceConfig.CorsConfiguration.AllowCredentials },
                                    AccessPolicies = accessPolicies
                                }
                            };


                            if (ShouldProcess(this.Name, Resources.createService))
                            {
                                var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(
                                               this.ResourceGroupName,
                                               this.Name,
                                               servicesDescription);

                                var healthcareApisFhirServiceAccount = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);

                                WriteObject(healthcareApisFhirServiceAccount);
                            }
                            break;

                        }
                }
            
            });
        
        }
    }
}
