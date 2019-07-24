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
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

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
        public int? CorsMaxAge { get; set; }

        [Parameter(Mandatory = false,ParameterSetName = ServiceNameParameterSet, HelpMessage = "Cors Allow Credentials.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Cors Allow Credentials.")]
        [ValidateNotNullOrEmpty]
        public bool? CorsAllowCredentials { get; set; }

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
        [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSet, HelpMessage = "List of tags.")]
        [ValidateNotNullOrEmpty]
        public string[] Tags { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = ServiceConfigParameterSet,HelpMessage = "FhirServiceConfig.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdConfigParameterSet, HelpMessage = "FhirServiceConfig.")]
        [ValidateNotNullOrEmpty]
        public PSServiceConfig FhirServiceConfig { get; set; }


        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "HealthcareApis fhir service piped from Get-AzHealthcareApisFhirService.", ValueFromPipeline = true)]
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
                            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();
                            if (AccessPolicyObjectIds != null && AccessPolicyObjectIds.Length > 0)
                            {
                                foreach (string objectId in AccessPolicyObjectIds)
                                {
                                    accessPolicies.Add(new ServiceAccessPolicyEntry(objectId));
                                }
                            }

                            var healthcareApisAccount = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);

                            foreach (ServiceAccessPolicyEntry objectId in healthcareApisAccount.Properties.AccessPolicies)
                            {
                                accessPolicies.Add(objectId);
                            }

                            ServicesDescription servicesDescription = GenerateServiceDescription(healthcareApisAccount, accessPolicies);

                            var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(this.ResourceGroupName, this.Name, servicesDescription);

                            break;
                        }
                    case ServiceConfigParameterSet:
                    {
                            IList<PSAccessPolicyEntry> entries = FhirServiceConfig.AccessPolicies;
                            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();

                            if (entries != null && entries.Count > 0)
                            {
                                foreach (PSAccessPolicyEntry objectId in entries)
                                {
                                    accessPolicies.Add(new ServiceAccessPolicyEntry(objectId.ToString()));
                                }
                            }

                            var healthcareApisAccount = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);

                            foreach (ServiceAccessPolicyEntry objectId in healthcareApisAccount.Properties.AccessPolicies)
                            {
                                accessPolicies.Add(objectId);
                            }

                            ServicesDescription servicesDescription = ServiceConfigToServiceDescription(healthcareApisAccount, accessPolicies);

                            var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(this.ResourceGroupName, this.Name, servicesDescription);
                            break;
                        }
                    case ResourceIdConfigParameterSet:
                    {
                        string rgName = null;
                        string name = null;
                        ValidateAndExtractName(this.ResourceId, out rgName, out name);

                            IList<PSAccessPolicyEntry> entries = FhirServiceConfig.AccessPolicies;
                            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();

                            if (entries != null && entries.Count > 0)
                            {
                                foreach (PSAccessPolicyEntry objectId in entries)
                                {
                                    accessPolicies.Add(new ServiceAccessPolicyEntry(objectId.ToString()));
                                }
                            }

                            var healthcareApisAccount = this.HealthcareApisClient.Services.Get(rgName, name);

                            foreach (ServiceAccessPolicyEntry objectId in healthcareApisAccount.Properties.AccessPolicies)
                            {
                                accessPolicies.Add(objectId);
                            }

                            if (FhirServiceConfig != null)
                            {
                                ServicesDescription servicesDescription = ServiceConfigToServiceDescription(healthcareApisAccount, accessPolicies);

                                healthcareApisAccount = this.HealthcareApisClient.Services.CreateOrUpdate(rgName, name, servicesDescription);
                            }

                            WriteObject(healthcareApisAccount);

                            break;
                    }
                    case ResourceIdParameterSet:
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

                            foreach (ServiceAccessPolicyEntry objectId in healthcareApisAccount.Properties.AccessPolicies)
                            {
                                accessPolicies.Add(objectId);
                            }

                            ServicesDescription servicesDescription = GenerateServiceDescription(healthcareApisAccount, accessPolicies);

                            var healthcareApisFhirServiceUpdateAccount = this.HealthcareApisClient.Services.CreateOrUpdate(
                                                rgName,
                                                name,
                                                servicesDescription);
                            WriteObject(healthcareApisFhirServiceUpdateAccount);

                            break;
                        }
                    case InputObjectParameterSet:
                        {
                            IList<PSAccessPolicyEntry> entries = InputObject.Properties.AccessPolicies;
                            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();

                            foreach (PSAccessPolicyEntry entry in entries)
                            {
                                accessPolicies.Add(new ServiceAccessPolicyEntry(entry.ObjectId));
                            }

                            var healthcareApisAccount = this.HealthcareApisClient.Services.Get(InputObject.ResourceGroupName,
                                             InputObject.Name);

                            foreach (ServiceAccessPolicyEntry objectId in healthcareApisAccount.Properties.AccessPolicies)
                            {
                                accessPolicies.Add(objectId);
                            }

                           

                            ServicesDescription servicesDescription = InputObjectToServiceDescription(healthcareApisAccount,accessPolicies);
                            var healthcareApisFhirServiceUpdateAccount = this.HealthcareApisClient.Services.CreateOrUpdate(
                                             InputObject.ResourceGroupName,
                                             InputObject.Name,
                                             servicesDescription);

                            WriteObject(healthcareApisFhirServiceUpdateAccount);
                            break;
                        }
                }
            });
        }

        private ServicesDescription GenerateServiceDescription(ServicesDescription healthcareApisAccount, List<ServiceAccessPolicyEntry> accessPolicies)
        {
            return new ServicesDescription()
            {
                Location = healthcareApisAccount.Location,
                Properties = new ServicesProperties()
                {
                    AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo()
                    {
                        Authority = Authority ?? healthcareApisAccount.Properties.AuthenticationConfiguration.Authority,
                        Audience = Audience ?? healthcareApisAccount.Properties.AuthenticationConfiguration.Audience,
                        SmartProxyEnabled = SmartProxyEnabled != healthcareApisAccount.Properties.AuthenticationConfiguration.SmartProxyEnabled ? healthcareApisAccount.Properties.AuthenticationConfiguration.SmartProxyEnabled : this.SmartProxyEnabled
                    },
                    CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo()
                    {
                        OfferThroughput = CosmosOfferThroughput != healthcareApisAccount.Properties.CosmosDbConfiguration.OfferThroughput ? CosmosOfferThroughput : healthcareApisAccount.Properties.CosmosDbConfiguration.OfferThroughput
                    },
                    CorsConfiguration = new ServiceCorsConfigurationInfo()
                    {
                        Origins = CorsOrigins ?? healthcareApisAccount.Properties.CorsConfiguration.Origins,
                        Headers = CorsHeaders ?? healthcareApisAccount.Properties.CorsConfiguration.Headers,
                        Methods = CorsMethods ?? healthcareApisAccount.Properties.CorsConfiguration.Methods,
                        MaxAge = CorsMaxAge ?? healthcareApisAccount.Properties.CorsConfiguration.MaxAge,
                        AllowCredentials = CorsAllowCredentials ?? healthcareApisAccount.Properties.CorsConfiguration.AllowCredentials
                    },
                    AccessPolicies = accessPolicies
                }
            };
        }

        private ServicesDescription InputObjectToServiceDescription(ServicesDescription healthcareApisAccount, List<ServiceAccessPolicyEntry> accessPolicies)
        {
            return new ServicesDescription()
            {
                Location = InputObject.Location,
                Properties = new ServicesProperties()
                {
                    AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo()
                    {
                        Authority = InputObject.Properties.AuthenticationConfiguration.Authority?? healthcareApisAccount.Properties.AuthenticationConfiguration.Authority,
                        Audience = InputObject.Properties.AuthenticationConfiguration.Audience ?? healthcareApisAccount.Properties.AuthenticationConfiguration.Audience,
                        SmartProxyEnabled = InputObject.Properties.AuthenticationConfiguration.SmartProxyEnabled != healthcareApisAccount.Properties.AuthenticationConfiguration.SmartProxyEnabled ? InputObject.Properties.AuthenticationConfiguration.SmartProxyEnabled : healthcareApisAccount.Properties.AuthenticationConfiguration.SmartProxyEnabled
                    },
                    CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo()
                    {
                        OfferThroughput = InputObject.Properties.CosmosDbConfiguration.OfferThroughput != healthcareApisAccount.Properties.CosmosDbConfiguration.OfferThroughput ? InputObject.Properties.CosmosDbConfiguration.OfferThroughput : healthcareApisAccount.Properties.CosmosDbConfiguration.OfferThroughput
                    },
                    CorsConfiguration = new ServiceCorsConfigurationInfo()
                    {
                        Origins = InputObject.Properties.CorsConfiguration.Origins ?? healthcareApisAccount.Properties.CorsConfiguration.Origins,
                        Headers = InputObject.Properties.CorsConfiguration.Headers ?? healthcareApisAccount.Properties.CorsConfiguration.Headers,
                        Methods = InputObject.Properties.CorsConfiguration.Methods ?? healthcareApisAccount.Properties.CorsConfiguration.Methods,
                        MaxAge = InputObject.Properties.CorsConfiguration.MaxAge ?? healthcareApisAccount.Properties.CorsConfiguration.MaxAge,
                        AllowCredentials = InputObject.Properties.CorsConfiguration.AllowCredentials ?? healthcareApisAccount.Properties.CorsConfiguration.AllowCredentials
                    },
                    AccessPolicies = accessPolicies
                }
            };
        }

        private ServicesDescription ServiceConfigToServiceDescription(ServicesDescription healthcareApisAccount, List<ServiceAccessPolicyEntry> accessPolicies)
        {
            return new ServicesDescription()
            {
                Location = healthcareApisAccount.Location,
                Properties = new ServicesProperties()
                {
                    AuthenticationConfiguration = new ServiceAuthenticationConfigurationInfo()
                    {
                        Authority = FhirServiceConfig?.AuthenticationConfiguration?.Authority ?? healthcareApisAccount.Properties.AuthenticationConfiguration.Authority,
                        Audience = FhirServiceConfig?.AuthenticationConfiguration?.Audience ?? healthcareApisAccount.Properties.AuthenticationConfiguration.Audience,
                        SmartProxyEnabled = FhirServiceConfig?.AuthenticationConfiguration?.SmartProxyEnabled != healthcareApisAccount.Properties.AuthenticationConfiguration.SmartProxyEnabled ? healthcareApisAccount.Properties.AuthenticationConfiguration.SmartProxyEnabled : this.SmartProxyEnabled
                    },
                    CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo()
                    {
                        OfferThroughput = FhirServiceConfig?.CosmosDbConfiguration?.OfferThroughput != healthcareApisAccount.Properties.CosmosDbConfiguration.OfferThroughput ? FhirServiceConfig.CosmosDbConfiguration.OfferThroughput : healthcareApisAccount.Properties.CosmosDbConfiguration.OfferThroughput
                    },
                    CorsConfiguration = new ServiceCorsConfigurationInfo()
                    {
                        Origins = FhirServiceConfig?.CorsConfiguration?.Origins ?? healthcareApisAccount.Properties.CorsConfiguration.Origins,
                        Headers = FhirServiceConfig?.CorsConfiguration?.Headers ?? healthcareApisAccount.Properties.CorsConfiguration.Headers,
                        Methods = FhirServiceConfig?.CorsConfiguration?.Methods ?? healthcareApisAccount.Properties.CorsConfiguration.Methods,
                        MaxAge = FhirServiceConfig?.CorsConfiguration?.MaxAge ?? healthcareApisAccount.Properties.CorsConfiguration.MaxAge,
                        AllowCredentials = FhirServiceConfig?.CorsConfiguration?.AllowCredentials ?? healthcareApisAccount.Properties.CorsConfiguration.AllowCredentials
                    },
                    AccessPolicies = healthcareApisAccount.Properties.AccessPolicies
                }
            };
        }
    }
}
