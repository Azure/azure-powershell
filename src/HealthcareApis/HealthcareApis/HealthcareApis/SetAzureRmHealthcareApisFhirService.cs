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

using Microsoft.Azure.Commands.HealthcareApisFhirService.Common;
using Microsoft.Azure.Commands.HealthcareApisFhirService.Models;
using Microsoft.Azure.Management.HealthcareApis;
using Microsoft.Azure.Management.HealthcareApis.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HealthcareApisFhirService.Commands
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HealthcareApisFhirService", DefaultParameterSetName = ServiceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSFhirAccount))]
    public class SetAzureRmHealthcareApisFhirService : HealthcareApisBaseCmdlet
    {

        protected const string ServiceConfigParameterSet = "ServiceConfigParameterSet";
        protected const string ServiceNameParameterSet = "ServiceNameParameterSet";
        protected const string ResourceIdConfigParameterSet = "ResourceIdConfigParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string InoutObjectParameterSet = "InoutObjectParameterSet";

        [Parameter( Mandatory = true,
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
           Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
           HelpMessage = "CosmosOfferThroughput.")]
        [Parameter(
           Mandatory = false,
              ParameterSetName = ResourceIdParameterSet,
           HelpMessage = "CosmosOfferThroughput.")]
        [ValidateNotNullOrEmpty]
        public int CosmosOfferThroughput { get; set; }

        [Parameter(
            Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
            HelpMessage = "Authority.")]
        [Parameter(
           Mandatory = false,
              ParameterSetName = ResourceIdParameterSet,
           HelpMessage = "Authority.")]
        [ValidateNotNullOrEmpty]
        public string Authority { get; set; }


        [Parameter(
            Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
            HelpMessage = "Audience.")]
        [Parameter(
           Mandatory = false,
              ParameterSetName = ResourceIdParameterSet,
           HelpMessage = "Audience.")]
        [ValidateNotNullOrEmpty]
        public string Audience { get; set; }

        [Parameter(
          Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
          HelpMessage = "SmartyProxyEnabled.")]
        [Parameter(
           Mandatory = false,
              ParameterSetName = ResourceIdParameterSet,
           HelpMessage = "SmartProxyEnabled.")]
        [ValidateNotNullOrEmpty]
        public bool SmartProxyEnabled { get; set; }

        [Parameter(
         Mandatory = false,
              ParameterSetName = ServiceNameParameterSet,
         HelpMessage = "List of Cors Origins.")]
        [Parameter(
           Mandatory = false,
              ParameterSetName = ResourceIdParameterSet,
           HelpMessage = "List of Cors Origins.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsOrigins { get; set; }

        [Parameter(Mandatory = false,ParameterSetName = ServiceNameParameterSet,
        HelpMessage = "List of Cors Headers.")]
        [Parameter(
           Mandatory = false,
              ParameterSetName = ResourceIdParameterSet,
           HelpMessage = "List of Cors Headers.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsHeaders { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet,HelpMessage = "List of Cors Methods.")]
        [Parameter(Mandatory = false,ParameterSetName = ResourceIdParameterSet,HelpMessage = "List of Cors Methods.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsMethods { get; set; }

        [Parameter(Mandatory = false,ParameterSetName = ServiceNameParameterSet,HelpMessage = "Cors Max Age.")]
        [Parameter(Mandatory = false,ParameterSetName = ResourceIdParameterSet,HelpMessage = "Cors Max Age.")]
        [ValidateNotNullOrEmpty]
        public int CorsMaxAge { get; set; }

        [Parameter(Mandatory = false,ParameterSetName = ServiceNameParameterSet, HelpMessage = "Cors Allow Credentials.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Cors Allow Credentials.")]
        [ValidateNotNullOrEmpty]
        public bool CorsAllowCredentials { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "List of Access Policy Object IDs.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "List of Access Policy Object IDs.")]
        [ValidateNotNullOrEmpty]
        public string[] AccessPolicyObjectIds { get; set; }

        [Parameter(Mandatory = false,
        ParameterSetName = ServiceConfigParameterSet,
        HelpMessage = "Config Object")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "List of tags.")]
        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "List of tags.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdConfigParameterSet, HelpMessage = "List of tags.")]
        [Parameter(Mandatory = false, ParameterSetName = InoutObjectParameterSet, HelpMessage = "List of tags.")]
        [ValidateNotNullOrEmpty]
        public string[] Tags { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = ServiceConfigParameterSet,HelpMessage = "FhirServiceConfig.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdConfigParameterSet, HelpMessage = "FhirServiceConfig.")]
        [ValidateNotNullOrEmpty]
        public PSServiceConfig FhirServiceConfig { get; set; }


        [Parameter(ParameterSetName = InoutObjectParameterSet, HelpMessage = "HealthcareApis fhir service piped from Get-AzHealthcareApisFhirService.", ValueFromPipeline = true)]
        public PSFhirAccount InputObject { get; set; }


         [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ResourceIdConfigParameterSet, HelpMessage = "HealthcareApis Fhir Service ResourceId.")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis Fhir Service ResourceId.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                switch (ParameterSetName)
                {
                    case ServiceNameParameterSet:
                    {
                            if (AccessPolicyObjectIds != null && AccessPolicyObjectIds.Length > 0)
                            {
                                List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();

                                foreach (string objectId in AccessPolicyObjectIds)
                                {
                                    accessPolicies.Add(new ServiceAccessPolicyEntry(objectId));
                                }
                            }

                            var healthcareApisAccount = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);

                            ServicesDescription servicesDescription = new ServicesDescription()
                            {
                                Location = healthcareApisAccount.Location,
                                Properties = new ServicesProperties()
                                {
                                    AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo() { Authority = Authority, Audience = Audience },
                                    CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo() { OfferThroughput = CosmosOfferThroughput },
                                    CorsConfiguration = new ServiceCorsConfigurationInfo() { Origins = CorsOrigins, Headers = CorsHeaders, Methods = CorsMethods, MaxAge = CorsMaxAge, AllowCredentials = CorsAllowCredentials },
                                    AccessPolicies = null
                                }
                            };

                            var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(
                                                InputObject.ResourceGroupName,
                                                InputObject.Name,
                                                servicesDescription);

                            break;
                        }
                    case ServiceConfigParameterSet:
                    {
                            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();
                            if (AccessPolicyObjectIds != null && AccessPolicyObjectIds.Length > 0)
                            {


                                foreach (string objectId in AccessPolicyObjectIds)
                                {
                                    accessPolicies.Add(new ServiceAccessPolicyEntry(objectId));
                                }
                            }

                            var healthcareApisAccount = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);

                            ServicesDescription servicesDescription = new ServicesDescription()
                            {
                                Location = healthcareApisAccount.Location,
                                Properties = new ServicesProperties()
                                {
                                    AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo() { Authority = FhirServiceConfig.AuthenticationConfiguration.Authority, Audience = FhirServiceConfig.AuthenticationConfiguration.Audience },
                                    CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo() { OfferThroughput = FhirServiceConfig.CosmosDbConfiguration.OfferThroughput },
                                    CorsConfiguration = new ServiceCorsConfigurationInfo() { Origins = FhirServiceConfig.CorsConfiguration.Origins, Headers = FhirServiceConfig.CorsConfiguration.Headers, Methods = FhirServiceConfig.CorsConfiguration.Methods, MaxAge = FhirServiceConfig.CorsConfiguration.MaxAge, AllowCredentials = FhirServiceConfig.CorsConfiguration.AllowCredentials },
                                    AccessPolicies = accessPolicies
                                }
                            };
                            var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(
                                             InputObject.ResourceGroupName,
                                             InputObject.Name,
                                             servicesDescription);
                            break;
                        }
                    case ResourceIdConfigParameterSet:
                    {
                        string rgName = null;
                        string name = null;
                        ValidateAndExtractName(this.ResourceId, out rgName, out name);

                            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();
                            if (AccessPolicyObjectIds != null && AccessPolicyObjectIds.Length > 0)
                            {
                                

                                foreach (string objectId in AccessPolicyObjectIds)
                                {
                                    accessPolicies.Add(new ServiceAccessPolicyEntry(objectId));
                                }
                            }

                            var healthcareApisAccount = this.HealthcareApisClient.Services.Get(rgName, name);

                            ServicesDescription servicesDescription = new ServicesDescription()
                            {
                                Location = healthcareApisAccount.Location,
                                Properties = new ServicesProperties()
                                {
                                    AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo() { Authority = FhirServiceConfig.AuthenticationConfiguration.Authority, Audience = FhirServiceConfig.AuthenticationConfiguration.Audience },
                                    CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo() { OfferThroughput = FhirServiceConfig.CosmosDbConfiguration.OfferThroughput },
                                    CorsConfiguration = new ServiceCorsConfigurationInfo() { Origins = FhirServiceConfig.CorsConfiguration.Origins, Headers = FhirServiceConfig.CorsConfiguration.Headers, Methods = FhirServiceConfig.CorsConfiguration.Methods, MaxAge = FhirServiceConfig.CorsConfiguration.MaxAge, AllowCredentials = FhirServiceConfig.CorsConfiguration.AllowCredentials },
                                    AccessPolicies = accessPolicies
                                }
                            };
                            var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(
                                             InputObject.ResourceGroupName,
                                             InputObject.Name,
                                             servicesDescription);
                            break;
                    }
                    case ResourceIdParameterSet:
                    {
                        string rgName = null;
                        string name = null;
                        ValidateAndExtractName(this.ResourceId, out rgName, out name);

                        if (AccessPolicyObjectIds != null && AccessPolicyObjectIds.Length > 0)
                        { List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();
                           
                            foreach (string objectId in AccessPolicyObjectIds)
                            {
                                accessPolicies.Add(new ServiceAccessPolicyEntry(objectId));
                            }
                        }

                        var healthcareApisAccount = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);

                        ServicesDescription servicesDescription = new ServicesDescription()
                        {
                            Location = healthcareApisAccount.Location,
                            Properties = new ServicesProperties()
                            {
                                AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo() { Authority = Authority, Audience = Audience },
                                CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo() { OfferThroughput = CosmosOfferThroughput },
                                CorsConfiguration = new ServiceCorsConfigurationInfo() { Origins = CorsOrigins, Headers = CorsHeaders, Methods = CorsMethods, MaxAge = CorsMaxAge, AllowCredentials = CorsAllowCredentials },
                                AccessPolicies = null
                            }
                        };

                        var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(
                                            InputObject.ResourceGroupName,
                                            InputObject.Name,
                                            servicesDescription);

                            break;
                        }
                    case InoutObjectParameterSet:
                        {
                            IList<PSAccessPolicyEntry> entries = InputObject.Properties.AccessPolicies;
                            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();

                            foreach (PSAccessPolicyEntry entry in entries)
                            {
                                accessPolicies.Add(new ServiceAccessPolicyEntry(entry.ObjectId));
                            }
                            ServicesDescription servicesDescription = new ServicesDescription()
                            {
                                Location = InputObject.Location,
                                Properties = new ServicesProperties()
                                {
                                    AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo() { Authority = InputObject.Properties.AuthenticationConfiguration.Authority, Audience = InputObject.Properties.AuthenticationConfiguration.Audience },
                                    CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo() { OfferThroughput = InputObject.Properties.CosmosDbConfiguration.OfferThroughput },
                                    CorsConfiguration = new ServiceCorsConfigurationInfo() { Origins = InputObject.Properties.CorsConfiguration.Origins, Headers = InputObject.Properties.CorsConfiguration.Headers, Methods = InputObject.Properties.CorsConfiguration.Methods, MaxAge = InputObject.Properties.CorsConfiguration.MaxAge, AllowCredentials = InputObject.Properties.CorsConfiguration.AllowCredentials },
                                    AccessPolicies = accessPolicies
                                }
                            };
                            var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(
                                             InputObject.ResourceGroupName,
                                             InputObject.Name,
                                             servicesDescription);
                            break;
                    }
                }
            });
        }
    }
}
