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
using Microsoft.Azure.Commands.HealthcareApis.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HealthcareApis;
using Microsoft.Azure.Management.HealthcareApis.Models;
using Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Common;
using System;
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
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis Service Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService CosmosOfferThroughput.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService CosmosOfferThroughput.")]
        [ValidateNotNullOrEmpty]
        public int? CosmosOfferThroughput { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService Authority.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService Authority.")]
        [ValidateNotNullOrEmpty]
        public string Authority { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService Audience.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService Audience.")]
        [ValidateNotNullOrEmpty]
        public string Audience { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService EnableSmartProxy.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "SmartProxyEnabled.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableSmartProxy { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService DisableSmartProxy.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService DisableSmartProxy.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DisableSmartProxy { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService List of Cors Origins. Specify URLs of origin sites that can access this API, or use \" * \" to allow access from any site.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService List of Cors Origins. Specify URLs of origin sites that can access this API, or use \" * \" to allow access from any site.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsOrigin { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService List of Cors Headers. Specify HTTP headers which can be used during the request. Use \" * \" for any header.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService List of Cors Headers. Specify HTTP headers which can be used during the request. Use \" * \" for any header.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsHeader { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService List of Cors Methods.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService List of Cors Methods.")]
        [ValidateNotNullOrEmpty]
        public string[] CorsMethod { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService Cors Max Age. Specify how long a result from a request can be cached in seconds. Example: 600 means 10 minutes.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService Cors Max Age. Specify how long a result from a request can be cached in seconds. Example: 600 means 10 minutes.")]
        [ValidateNotNullOrEmpty]
        public int? CorsMaxAge { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService AllowCorsCredentials.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService AllowCorsCredentials.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AllowCorsCredential { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "HealthcareApis FhirService CorsCredentials Not Allowed.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "HealthcareApis FhirService CorsCredentials Not Allowed.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DisableCorsCredential { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ServiceNameParameterSet, HelpMessage = "List of Access Policy Object IDs.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "List of Access Policy Object IDs.")]
        [ValidateNotNullOrEmpty]
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
            try
            {
                base.ExecuteCmdlet();

                RunCmdLet(() =>
                {
                    switch (ParameterSetName)
                    {
                        case ServiceNameParameterSet:
                            {
                                var healthcareApisAccount = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);

                                IList<ServiceAccessPolicyEntry> accessPolicies = GetAccessPolicies(healthcareApisAccount);

                                ServicesDescription servicesDescription = GenerateServiceDescription(healthcareApisAccount, accessPolicies);

                                try
                                {
                                    var createAccountResponse = this.HealthcareApisClient.Services.CreateOrUpdate(this.ResourceGroupName, this.Name, servicesDescription);
                                    var healthCareFhirService = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);
                                    WriteHealthcareApisAccount(healthCareFhirService);
                                }
                                catch (ErrorDetailsException wex)
                                {
                                    WriteError(WriteErrorforBadrequest(wex));
                                }

                                break;
                            }
                        case ResourceIdParameterSet:
                            {
                                string rgName = null;
                                string name = null;
                                ValidateAndExtractName(this.ResourceId, out rgName, out name);

                                var healthcareApisAccount = this.HealthcareApisClient.Services.Get(rgName, name);

                                IList<ServiceAccessPolicyEntry> accessPolicies = GetAccessPolicies(healthcareApisAccount);

                                ServicesDescription servicesDescription = GenerateServiceDescription(healthcareApisAccount, accessPolicies);

                                try
                                {
                                    var healthcareApisFhirServiceUpdateAccount = this.HealthcareApisClient.Services.CreateOrUpdate(
                                                    rgName,
                                                    name,
                                                    servicesDescription);
                                    var healthCareFhirService = this.HealthcareApisClient.Services.Get(rgName, name);
                                    WriteHealthcareApisAccount(healthCareFhirService);
                                }
                                catch (ErrorDetailsException wex)
                                {
                                    WriteError(WriteErrorforBadrequest(wex));
                                }

                                break;
                            }
                        case InputObjectParameterSet:
                            {
                                IList<PSHealthcareApisFhirServiceAccessPolicyEntry> entries = InputObject.AccessPolicies;
                                List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();

                                foreach (PSHealthcareApisFhirServiceAccessPolicyEntry entry in entries)
                                {
                                    accessPolicies.Add(new ServiceAccessPolicyEntry(entry.ObjectId));
                                }

                                var healthcareApisAccount = this.HealthcareApisClient.Services.Get(InputObject.ResourceGroupName,
                                                 InputObject.Name);


                                ServicesDescription servicesDescription = InputObjectToServiceDescription(healthcareApisAccount, accessPolicies);

                                try
                                {
                                    var healthcareApisFhirServiceUpdateAccount = this.HealthcareApisClient.Services.CreateOrUpdate(
                                                     InputObject.ResourceGroupName,
                                                     InputObject.Name,
                                                     servicesDescription);

                                    WriteHealthcareApisAccount(healthcareApisFhirServiceUpdateAccount);
                                }
                                catch (ErrorDetailsException wex)
                                {
                                    WriteError(WriteErrorforBadrequest(wex));
                                }
                                break;
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

        private IList<ServiceAccessPolicyEntry> GetAccessPolicies(ServicesDescription healthcareApisAccount)
        {
            List<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();
            if (AccessPolicyObjectId != null && AccessPolicyObjectId.Length > 0)
            {
                foreach (string objectId in AccessPolicyObjectId)
                {
                    HealthcareApisArgumentValidator.ValidateObjectId(objectId);
                    accessPolicies.Add(new ServiceAccessPolicyEntry(objectId));
                }

                return accessPolicies;
            }

            return healthcareApisAccount.Properties.AccessPolicies;
        }

        private ServicesDescription GenerateServiceDescription(ServicesDescription healthcareApisAccount, IList<ServiceAccessPolicyEntry> accessPolicies)
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
                        SmartProxyEnabled = IsSmartOnFhirEnabled(healthcareApisAccount.Properties.AuthenticationConfiguration.SmartProxyEnabled)
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
                        AllowCredentials = IsCorsCredentialsAllowed(healthcareApisAccount.Properties.CorsConfiguration.AllowCredentials)
                    },
                    AccessPolicies = accessPolicies
                },
                Kind = healthcareApisAccount.Kind,
                Tags = GetTags(healthcareApisAccount)
            };
        }

        private IDictionary<string, string> GetTags(ServicesDescription healthcareApisAccount)
        {
            if (this.Tag != null && this.Tag.Count > 0)
            {
                Dictionary<string, string> tags = new Dictionary<string, string>();
                foreach (DictionaryEntry tag in this.Tag)
                {
                    tags.Add((string)tag.Key, (string)tag.Value);
                }

                return tags;
            }

            return healthcareApisAccount.Tags;
        }

        private bool? IsSmartOnFhirEnabled(bool? currentSmartOnFhirValue)
        {
            if (EnableSmartProxy.IsPresent && DisableSmartProxy.IsPresent)
            {
                throw new PSArgumentException(Resources.updatedService_InvalidSmartOnProxyInput);
            }
            else if (EnableSmartProxy.IsPresent)
            {
                return true;
            }
            else if (DisableSmartProxy.IsPresent)
            {
                return false;
            }
            return currentSmartOnFhirValue;
        }

        private bool? IsCorsCredentialsAllowed(bool? currentAllowCorsCrendentialsValue)
        {
            if (AllowCorsCredential.IsPresent && DisableCorsCredential.IsPresent)
            {
                throw new PSArgumentException(Resources.updatedService_InvalidAllowCorsCredentialsInput);
            }
            else if (AllowCorsCredential.IsPresent)
            {
                return true;
            }
            else if (DisableCorsCredential.IsPresent)
            {
                return false;
            }
            return currentAllowCorsCrendentialsValue;
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
                        Authority = InputObject.Authority ?? healthcareApisAccount.Properties.AuthenticationConfiguration.Authority,
                        Audience = InputObject.Audience ?? healthcareApisAccount.Properties.AuthenticationConfiguration.Audience,
                        SmartProxyEnabled = InputObject.SmartProxyEnabled != healthcareApisAccount.Properties.AuthenticationConfiguration.SmartProxyEnabled ? InputObject.SmartProxyEnabled : healthcareApisAccount.Properties.AuthenticationConfiguration.SmartProxyEnabled
                    },
                    CosmosDbConfiguration = new ServiceCosmosDbConfigurationInfo()
                    {
                        OfferThroughput = InputObject.CosmosDbOfferThroughput ?? healthcareApisAccount.Properties.CosmosDbConfiguration.OfferThroughput
                    },
                    CorsConfiguration = new ServiceCorsConfigurationInfo()
                    {
                        Origins = InputObject.CorsOrigins ?? healthcareApisAccount.Properties.CorsConfiguration.Origins,
                        Headers = InputObject.CorsHeaders ?? healthcareApisAccount.Properties.CorsConfiguration.Headers,
                        Methods = InputObject.CorsMethods ?? healthcareApisAccount.Properties.CorsConfiguration.Methods,
                        MaxAge = InputObject.CorsMaxAge ?? healthcareApisAccount.Properties.CorsConfiguration.MaxAge,
                        AllowCredentials = InputObject.CorsAllowCredentials ?? healthcareApisAccount.Properties.CorsConfiguration.AllowCredentials
                    },
                    AccessPolicies = accessPolicies
                },
                Kind = ParseKind(InputObject.Kind),
                Tags = InputObject.Tags
            };
        }
    }
}
