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
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    public class ExtensionManager
    {
        public const int ExtensionIdLiveCycleCount = 3;
        private const string ExtensionCertificateSubject = "DC=Microsoft Azure Service Management for Extensions";
        private const string ThumbprintAlgorithmStr = "sha1";
        private const string ExtensionDefaultVersion = "1.*";

        protected ServiceManagementBaseCmdlet Cmdlet { get; private set; }
        protected string SubscriptionId { get; private set; }
        protected string ServiceName { get; private set; }
        protected IList<HostedServiceListExtensionsResponse.Extension> ExtendedExtensionList { get; private set; }

        public ExtensionManager(ServiceManagementBaseCmdlet cmdlet, string serviceName)
        {
            if (cmdlet == null || cmdlet.Profile.Context.Subscription == null)
            {
                throw new ArgumentNullException("cmdlet");
            }

            if (string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentNullException("serviceName");
            }

            Cmdlet = cmdlet;
            SubscriptionId = cmdlet.Profile.Context.Subscription.Id.ToString();
            ServiceName = serviceName;
        }

        public HostedServiceListExtensionsResponse.Extension GetExtension(string extensionId)
        {
            if (ExtendedExtensionList == null)
            {
                ExtendedExtensionList = Cmdlet.ComputeClient.HostedServices.ListExtensions(ServiceName).Extensions;
            }

            return ExtendedExtensionList == null || !ExtendedExtensionList.Any(e => e.Id == extensionId) ? null : ExtendedExtensionList.First(e => e.Id == extensionId);
        }

        public void DeleteExtension(string extensionId)
        {
            var operationResponse = Cmdlet.ComputeClient.HostedServices.DeleteExtension(ServiceName, extensionId);
        }

        public void AddExtension(HostedServiceAddExtensionParameters extensionInput)
        {
            var operationResponse = Cmdlet.ComputeClient.HostedServices.AddExtension(ServiceName, extensionInput);
        }

        public bool CheckNameSpaceType(HostedServiceListExtensionsResponse.Extension extension, string nameSpace, string type)
        {
            return extension != null
                && (!string.IsNullOrEmpty(nameSpace) && string.Equals(extension.ProviderNamespace, nameSpace, StringComparison.OrdinalIgnoreCase))
                && (!string.IsNullOrEmpty(type) && string.Equals(extension.Type, type, StringComparison.OrdinalIgnoreCase));
        }

        public ExtensionConfigurationBuilder GetBuilder()
        {
            return new ExtensionConfigurationBuilder(this);
        }

        public ExtensionConfigurationBuilder GetBuilder(Microsoft.WindowsAzure.Management.Compute.Models.ExtensionConfiguration config)
        {
            return new ExtensionConfigurationBuilder(this, config);
        }

        private void GetThumbprintAndAlgorithm(IList<HostedServiceListExtensionsResponse.Extension> extensionList, string extensionId, ref string thumbprint, ref string thumbprintAlgorithm)
        {
            var existingExtension = extensionList == null || !extensionList.Any(e => e.Id == extensionId) ? null : extensionList.First(e => e.Id == extensionId);
            if (existingExtension != null)
            {
                thumbprint = existingExtension.Thumbprint;
                thumbprintAlgorithm = existingExtension.ThumbprintAlgorithm;
            }
            else if (extensionList.Any())
            {
                thumbprint = extensionList.First().Thumbprint;
                thumbprintAlgorithm = extensionList.First().ThumbprintAlgorithm;
            }
            else if (ExtendedExtensionList != null && ExtendedExtensionList.Any())
            {
                thumbprint = ExtendedExtensionList.First().Thumbprint;
                thumbprintAlgorithm = ExtendedExtensionList.First().ThumbprintAlgorithm;
            }

            var certList = Cmdlet.ComputeClient.ServiceCertificates.List(ServiceName).Certificates;
            string extThumbprint = thumbprint;
            string extThumbprintAlgorithm = thumbprintAlgorithm;
            var cert = certList == null || !certList.Any(c => c.Thumbprint == extThumbprint && c.ThumbprintAlgorithm == extThumbprintAlgorithm)
                                         ? null : certList.First(c => c.Thumbprint == extThumbprint && c.ThumbprintAlgorithm == extThumbprintAlgorithm);
            cert = cert != null ? cert : certList.FirstOrDefault(c =>
            {
                byte[] bytes = c.Data;
                X509Certificate2 x509cert = null;
                try
                {
                    x509cert = new X509Certificate2(bytes);
                }
                catch (CryptographicException)
                {
                    // Do nothing
                }
                return x509cert != null && ExtensionCertificateSubject.Equals(x509cert.Subject);
            });

            if (cert != null)
            {
                thumbprint = cert.Thumbprint;
                thumbprintAlgorithm = cert.ThumbprintAlgorithm;
            }
            else
            {
                thumbprint = string.Empty;
                thumbprintAlgorithm = string.Empty;
            }
        }

        public ExtensionConfiguration InstallExtension(ExtensionConfigurationInput context, string slot,
            ExtensionConfiguration extConfig, ExtensionConfiguration secondSlotExtConfig)
        {
            ExtensionConfigurationBuilder builder = GetBuilder(extConfig);
            ExtensionConfigurationBuilder secondSlotConfigBuilder = null;
            if (secondSlotExtConfig != null)
            {
                secondSlotConfigBuilder = GetBuilder(secondSlotExtConfig);
            }

            foreach (ExtensionRole r in context.Roles)
            {
                var extensionIds = (from index in Enumerable.Range(0, ExtensionIdLiveCycleCount)
                                    select r.GetExtensionId(context.Type, slot, index)).ToList();

                string availableId = context.Id
                                     ?? (from extensionId in extensionIds
                                         where
                                             !builder.ExistAny(extensionId) &&
                                             (secondSlotConfigBuilder == null ||
                                              !secondSlotConfigBuilder.ExistAny(extensionId))
                                         select extensionId).FirstOrDefault();

                var extensionList = (from id in extensionIds
                                     let e = GetExtension(id)
                                     where e != null
                                     select e).ToList();

                string thumbprint = context.CertificateThumbprint;
                string thumbprintAlgorithm = context.ThumbprintAlgorithm;

                if (context.X509Certificate != null)
                {
                    thumbprint = context.X509Certificate.Thumbprint;
                }
                else
                {
                    GetThumbprintAndAlgorithm(extensionList, availableId, ref thumbprint, ref thumbprintAlgorithm);
                }

                context.CertificateThumbprint = string.IsNullOrWhiteSpace(context.CertificateThumbprint) ? thumbprint : context.CertificateThumbprint;
                context.ThumbprintAlgorithm = string.IsNullOrWhiteSpace(context.ThumbprintAlgorithm) ? thumbprintAlgorithm : context.ThumbprintAlgorithm;

                if (!string.IsNullOrWhiteSpace(context.CertificateThumbprint) && string.IsNullOrWhiteSpace(context.ThumbprintAlgorithm))
                {
                    context.ThumbprintAlgorithm = ThumbprintAlgorithmStr;
                }
                else if (string.IsNullOrWhiteSpace(context.CertificateThumbprint) && !string.IsNullOrWhiteSpace(context.ThumbprintAlgorithm))
                {
                    context.ThumbprintAlgorithm = string.Empty;
                }

                var existingExtension = extensionList.Find(e => e.Id == availableId);
                if (existingExtension != null)
                {
                    DeleteExtension(availableId);
                }

                if (r.Default)
                {
                    Cmdlet.WriteVerbose(string.Format(Resources.ServiceExtensionSettingForDefaultRole, context.Type));
                }
                else
                {
                    Cmdlet.WriteVerbose(string.Format(Resources.ServiceExtensionSettingForSpecificRole, context.Type, r.RoleName));
                }

                AddExtension(new HostedServiceAddExtensionParameters
                {
                    Id = availableId,
                    Thumbprint = context.CertificateThumbprint,
                    ThumbprintAlgorithm = context.ThumbprintAlgorithm,
                    ProviderNamespace = context.ProviderNameSpace,
                    Type = context.Type,
                    PublicConfiguration = context.PublicConfiguration,
                    PrivateConfiguration = context.PrivateConfiguration,
                    Version = string.IsNullOrEmpty(context.Version) ? ExtensionDefaultVersion : context.Version
                });

                if (r.Default)
                {
                    builder.RemoveDefault(context.ProviderNameSpace, context.Type);
                    builder.AddDefault(availableId);
                }
                else
                {
                    builder.Remove(r.RoleName, context.ProviderNameSpace, context.Type);
                    builder.Add(r.RoleName, availableId);
                }
            }

            return builder.ToConfiguration();
        }

        public ExtensionConfiguration InstallExtension(ExtensionConfigurationInput context, string slot,
            DeploymentGetResponse deployment, DeploymentGetResponse peerDeployment)
        {
            Func<DeploymentGetResponse, ExtensionConfiguration> func = (d) => d == null ? null : d.ExtensionConfiguration;

            ExtensionConfiguration extConfig = func(deployment);
            ExtensionConfiguration secondSlotExtConfig = func(peerDeployment);

            return InstallExtension(context, slot, extConfig, secondSlotExtConfig);
        }

        public void Uninstall(string nameSpace, string type, Microsoft.WindowsAzure.Management.Compute.Models.ExtensionConfiguration extConfig)
        {
            var extBuilder = GetBuilder(extConfig);
            var extensions = Cmdlet.ComputeClient.HostedServices.ListExtensions(ServiceName).Extensions;
            if (extensions != null)
            {
                extensions.ForEach(
                    e =>
                    {
                        if (CheckNameSpaceType(e, nameSpace, type) && !extBuilder.ExistAny(e.Id))
                        {
                            DeleteExtension(e.Id);
                        }
                    });
            }
        }

        public ExtensionConfiguration Set(DeploymentGetResponse currentDeployment, DeploymentGetResponse peerDeployment, ExtensionConfigurationInput[] inputs, string slot)
        {
            string errorConfigInput = null;
            if (!Validate(inputs, out errorConfigInput))
            {
                throw new Exception(string.Format(Resources.ServiceExtensionCannotApplyExtensionsInSameType, errorConfigInput));
            }

            ExtensionConfigurationBuilder configBuilder = this.GetBuilder();
            foreach (ExtensionConfigurationInput context in inputs)
            {
                if (context != null)
                {
                    ExtensionConfiguration currentConfig = this.InstallExtension(context, slot, currentDeployment, peerDeployment);

                    foreach (var r in currentConfig.AllRoles)
                    {
                        if (currentDeployment == null || !this.GetBuilder(currentDeployment.ExtensionConfiguration).ExistAny(r.Id))
                        {
                            configBuilder.AddDefault(r.Id);
                        }
                    }
                    foreach (var r in currentConfig.NamedRoles)
                    {
                        foreach (var e in r.Extensions)
                        {
                            if (currentDeployment == null || !this.GetBuilder(currentDeployment.ExtensionConfiguration).ExistAny(e.Id))
                            {
                                configBuilder.Add(r.RoleName, e.Id);
                            }
                        }
                    }
                }
            }

            var extConfig = configBuilder.ToConfiguration();

            return extConfig;
        }

        public ExtensionConfiguration Add(DeploymentGetResponse deployment, DeploymentGetResponse peerDeployment, ExtensionConfigurationInput[] inputs, string slot)
        {
            string errorConfigInput = null;
            if (!Validate(inputs, out errorConfigInput))
            {
                throw new Exception(string.Format(Resources.ServiceExtensionCannotApplyExtensionsInSameType, errorConfigInput));
            }

            var oldExtConfig = deployment.ExtensionConfiguration;

            ExtensionConfigurationBuilder configBuilder = this.GetBuilder();
            foreach (ExtensionConfigurationInput context in inputs)
            {
                if (context != null)
                {
                    ExtensionConfiguration currentConfig = this.InstallExtension(context, slot, deployment, peerDeployment);

                    foreach (var r in currentConfig.AllRoles)
                    {
                        if (!this.GetBuilder(oldExtConfig).ExistAny(r.Id))
                        {
                            configBuilder.AddDefault(r.Id);
                        }
                    }
                    foreach (var r in currentConfig.NamedRoles)
                    {
                        foreach (var e in r.Extensions)
                        {
                            if (!this.GetBuilder(oldExtConfig).ExistAny(e.Id))
                            {
                                configBuilder.Add(r.RoleName, e.Id);
                            }
                        }
                    }
                }
            }
            var extConfig = configBuilder.ToConfiguration();

            return extConfig;
        }

        public ExtensionConfiguration UpdateExtensionState(ExtensionConfigurationInput input)
        {
            var extConfig = new ExtensionConfiguration();
            if (input.Roles == null || input.Roles.Count == 1 && input.Roles[0].RoleType == ExtensionRoleType.AllRoles)
            {

                extConfig.AllRoles = new List<ExtensionConfiguration.Extension>();
                extConfig.AllRoles.Add(new ExtensionConfiguration.Extension
                {
                    Id = input.Id,
                    State = input.State
                });
            }
            else
            {
                extConfig.NamedRoles = new List<ExtensionConfiguration.NamedRole>();
                foreach (var role in input.Roles)
                {
                    var ext = new List<ExtensionConfiguration.Extension>();
                    ext.Add(new ExtensionConfiguration.Extension
                    {
                        Id = input.Id,
                        State = input.State
                    });
                    extConfig.NamedRoles.Add(new ExtensionConfiguration.NamedRole
                    {
                        RoleName = role.RoleName,
                        Extensions = ext
                    });
                }
            }
            return extConfig;
        }

        public static bool Validate(ExtensionConfigurationInput[] inputs, out string errorConfigInput)
        {
            var roleList = (from c in inputs
                            where c != null
                            from r in c.Roles
                            select r).GroupBy(r => r.ToString()).Select(g => g.First());

            foreach (var role in roleList)
            {
                var result = from c in inputs
                             where c != null && c.Roles.Any(r => r.ToString() == role.ToString())
                             select string.Format("{0}.{1}", c.ProviderNameSpace, c.Type);
                foreach (var s in result)
                {
                    if (result.Count(t => t == s) > 1)
                    {
                        errorConfigInput = s;
                        return false;
                    }
                }
            }

            errorConfigInput = null;
            return true;
        }
    }
}
