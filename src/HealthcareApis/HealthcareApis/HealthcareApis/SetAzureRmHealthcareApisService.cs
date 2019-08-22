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

using Microsoft.Azure.Commands.HealthcareApis.Common;
using Microsoft.Azure.Commands.HealthcareApis.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HealthcareApis;
using Microsoft.Azure.Management.HealthcareApis.Models;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HealthcareApis.Commands
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HealthcareApisService", DefaultParameterSetName = ServiceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSHealthcareApisService))]
    public class SetAzureRmHealthcareApisService : HealthcareApisBaseCmdlet
    {
        protected const string ServiceNameParameterSet = "ServiceNameParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis Service Name.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-z0-9][a-z0-9-]{1,21}[a-z0-9]$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis Service Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService CosmosOfferThroughput.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService CosmosOfferThroughput.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(400, 10000)]
        public int? CosmosOfferThroughput { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService Authority.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService Authority.")]
        [ValidateNotNullOrEmpty]
        public string Authority { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService Audience.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService Audience.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^((?:[hH][tT][tT][pP](?:[sS]|)\\:\\/\\/.+)|([0-9A-Fa-f]{8}[-]?(?:[0-9A-Fa-f]{4}[-]?){3}[0-9A-Fa-f]{12}))$")]
        public string Audience { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService EnableSmartProxy.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "SmartProxyEnabled.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableSmartProxy { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService List of Cors Origins.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService List of Cors Origins.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^(?:(?:(?:[hH][tT][tT][pP](?:[sS]|))\\:\\/\\/(?:[a-zA-Z0-9-]+[.]?)+(?:\\:[0-9]{1,5})?|[*]))$")]
        public string[] CorsOrigin { get; set; }

        [Parameter(Mandatory = false,ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService List of Cors Headers.")]
        [Parameter(Mandatory = false,ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService List of Cors Headers.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsHeader { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet,HelpMessage = "HealthcareApis FhirService List of Cors Methods.")]
        [Parameter(Mandatory = false,ParameterSetName = ResourceIdParameterSet,HelpMessage = "HealthcareApis FhirService List of Cors Methods.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsMethod { get; set; }

        [Parameter(Mandatory = false,ParameterSetName = ServiceNameParameterSet,HelpMessage = "HealthcareApis FhirService Cors Max Age.")]
        [Parameter(Mandatory = false,ParameterSetName = ResourceIdParameterSet,HelpMessage = "HealthcareApis FhirService Cors Max Age.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, 99999)]
        public int? CorsMaxAge { get; set; }

        [Parameter(Mandatory = false,ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService AllowCorsCredentials.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService AllowCorsCredentials.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AllowCorsCredential { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "List of Access Policy Object IDs.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "List of Access Policy Object IDs.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^(([0-9A-Fa-f]{8}[-]?(?:[0-9A-Fa-f]{4}[-]?){3}[0-9A-Fa-f]{12}){1})+$")]
        public string[] AccessPolicyObjectId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = ServiceNameParameterSet,
            HelpMessage = "HealthcareApis Fhir Service Account Tags.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "HealthcareApis Fhir Service Account Tags.")]
        [Alias(TagsAlias)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "HealthcareApis fhir service piped from Get-AzHealthcareApisFhirService.", ValueFromPipeline = true)]
        public PSHealthcareApisService InputObject { get; set; }


        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis Fhir Service ResourceId.")]
        [ResourceIdCompleter("Microsoft.HealthcareApis/services")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
         Mandatory = false,
         HelpMessage = "Run cmdlet as a job in the background.")]
        public SwitchParameter AsJob { get; set; }

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
                            if (AccessPolicyObjectId != null && AccessPolicyObjectId.Length > 0)
                            {
                                foreach (string objectId in AccessPolicyObjectId)
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
                    case ResourceIdParameterSet:
                        {
                            string rgName = null;
                            string name = null;
                            ValidateAndExtractName(this.ResourceId, out rgName, out name);

                            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();
                            if (AccessPolicyObjectId != null && AccessPolicyObjectId.Length > 0)
                            {
                                foreach (string objectId in AccessPolicyObjectId)
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
                            IList<PSHealthcareApisFhirServiceAccessPolicyEntry> entries = InputObject.Properties.AccessPolicies;
                            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();

                            foreach (PSHealthcareApisFhirServiceAccessPolicyEntry entry in entries)
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
                        SmartProxyEnabled = EnableSmartProxy.ToBool() != healthcareApisAccount.Properties.AuthenticationConfiguration.SmartProxyEnabled ? healthcareApisAccount.Properties.AuthenticationConfiguration.SmartProxyEnabled : this.EnableSmartProxy.ToBool()
                    },
                    CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo()
                    {
                        OfferThroughput = CosmosOfferThroughput ?? healthcareApisAccount.Properties.CosmosDbConfiguration.OfferThroughput
                    },
                    CorsConfiguration = new ServiceCorsConfigurationInfo()
                    {
                        Origins = CorsOrigin ?? healthcareApisAccount.Properties.CorsConfiguration.Origins,
                        Headers = CorsHeader ?? healthcareApisAccount.Properties.CorsConfiguration.Headers,
                        Methods = CorsMethod ?? healthcareApisAccount.Properties.CorsConfiguration.Methods,
                        MaxAge = CorsMaxAge ?? healthcareApisAccount.Properties.CorsConfiguration.MaxAge,
                        AllowCredentials = AllowCorsCredential != healthcareApisAccount.Properties.CorsConfiguration.AllowCredentials ? healthcareApisAccount.Properties.CorsConfiguration.AllowCredentials : this.AllowCorsCredential.ToBool()
                    },
                    AccessPolicies = accessPolicies
                },
                Kind = healthcareApisAccount.Kind
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
                        OfferThroughput = InputObject.Properties.CosmosDbConfiguration.OfferThroughput ?? healthcareApisAccount.Properties.CosmosDbConfiguration.OfferThroughput
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
                },
                Kind = InputObject.Kind
            };
        }
    }
}
