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

using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Hyak.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    public abstract class BaseAzureServiceExtensionCmdlet : ServiceManagementBaseCmdlet
    {
        protected const string PublicConfigStr = "PublicConfig";
        protected const string PrivateConfigStr = "PrivateConfig";
        protected const string ChangeConfigurationModeStr = "Auto";
        protected const string XmlNameSpaceAttributeStr = "xmlns";

        protected const string NewExtensionParameterSetName = "NewExtension";
        protected const string NewExtensionUsingThumbprintParameterSetName = "NewExtensionUsingThumbprint";
        protected const string UpdateExtensionStatusParameterSetName = "UpdateExtensionStatusParameterSetName";
        protected const string SetExtensionParameterSetName = "SetExtension";
        protected const string SetExtensionUsingThumbprintParameterSetName = "SetExtensionUsingThumbprint";
        protected const string SetExtensionUsingDiagnosticsConfigurationParameterSetName = "SetExtensionUsingDiagnosticsConfiguration";
        protected const string RemoveByRolesParameterSet = "RemoveByRoles";
        protected const string RemoveAllRolesParameterSet = "RemoveAllRoles";

        protected ExtensionManager ExtensionManager { get; set; }
        protected XDocument PublicConfigurationXmlTemplate { get; set; }
        protected XDocument PrivateConfigurationXmlTemplate { get; set; }
        protected XDocument PublicConfigurationXml { get; set; }
        protected XDocument PrivateConfigurationXml { get; set; }
        protected DeploymentGetResponse Deployment { get; set; }
        protected DeploymentGetResponse PeerDeployment { get; set; }

        public virtual string ServiceName { get; set; }
        public virtual string Slot { get; set; }
        public virtual string[] Role { get; set; }
        public virtual X509Certificate2 X509Certificate { get; set; }
        public virtual string CertificateThumbprint { get; set; }
        public virtual string ThumbprintAlgorithm { get; set; }
        public virtual SwitchParameter UninstallConfiguration { get; set; }
        public virtual string PublicConfiguration { get; set; }
        public virtual string PrivateConfiguration { get; set; }
        public virtual string ProviderNamespace { get; set; }
        public virtual string ExtensionName { get; set; }
        public virtual string Version { get; set; }
        public virtual string ExtensionId { get; set; }
        public virtual string ExtensionState { get; set; }

        public BaseAzureServiceExtensionCmdlet()
            : base()
        {
            ServiceManagementProfile.Initialize();
        }

        protected virtual void ValidateParameters()
        {
        }

        protected void ValidateService()
        {
            string serviceName;
            CommonUtilities.GetDefaultSettings(CommonUtilities.TryGetServiceRootPath(CurrentPath()),
                ServiceName, null, null, null, null, Profile.Context.Subscription.Id.ToString(), out serviceName);

            if (string.IsNullOrEmpty(serviceName))
            {
                throw new Exception(string.Format(Resources.ServiceExtensionCannotFindServiceName, ServiceName));
            }
            else
            {
                ServiceName = serviceName;
                if (ComputeClient.HostedServices.CheckNameAvailability(ServiceName).IsAvailable)
                {
                    throw new Exception(string.Format(Resources.ServiceExtensionCannotFindServiceName, ServiceName));
                }
            }

            ExtensionManager = new ExtensionManager(this, ServiceName);
        }

        protected void ValidateDeployment()
        {
            Slot = string.IsNullOrEmpty(Slot) ? DeploymentSlot.Production.ToString() : Slot;

            Deployment = GetDeployment(Slot);
            if (!UninstallConfiguration)
            {
                if (Deployment == null)
                {
                    throw new Exception(string.Format(Resources.ServiceExtensionCannotFindDeployment, ServiceName, Slot));
                }
                Deployment.ExtensionConfiguration = Deployment.ExtensionConfiguration ?? new Microsoft.WindowsAzure.Management.Compute.Models.ExtensionConfiguration();
            }

            PeerDeployment = GetPeerDeployment(Slot);
        }

        protected void ValidateRoles(string[] roles)
        {
            foreach (string roleName in roles)
            {
                if (Deployment.Roles == null || !Deployment.Roles.Any(r => r.RoleName == roleName))
                {
                    throw new Exception(string.Format(Resources.ServiceExtensionCannotFindRole, roleName, Slot, ServiceName));
                }

                if (string.IsNullOrWhiteSpace(roleName))
                {
                    throw new Exception(Resources.ServiceExtensionCannotFindRoleName);
                }
            }
        }

        protected void ValidateRoles()
        {
            Role = Role == null ? new string[0] : Role.Select(r => r == null ? string.Empty : r.Trim()).Distinct().ToArray();
            ValidateRoles(Role);
        }

        protected void ValidateThumbprint(bool uploadCert)
        {
            if (X509Certificate != null)
            {
                var operationDescription = string.Format(Resources.ServiceExtensionUploadingCertificate, CommandRuntime, X509Certificate.Thumbprint);
                if (uploadCert)
                {
                    ExecuteClientActionNewSM(
                        null,
                        CommandRuntime.ToString(),
                        () => this.ComputeClient.ServiceCertificates.Create(this.ServiceName, CertUtilsNewSM.Create(X509Certificate)));
                }

                CertificateThumbprint = X509Certificate.Thumbprint;
            }
            else
            {
                CertificateThumbprint = CertificateThumbprint ?? string.Empty;
            }

            ThumbprintAlgorithm = ThumbprintAlgorithm ?? string.Empty;
        }

        protected virtual void ValidateConfiguration()
        {
        }

        private static string GetConfigValue(string xmlText, string element)
        {
            XDocument config = XDocument.Parse(xmlText);
            var result = from d in config.Descendants()
                         where d.Name.LocalName == element
                         select d.Descendants().Any() ? d.ToString() : d.Value;
            return result.FirstOrDefault();
        }

        protected string GetPublicConfigValue(HostedServiceListExtensionsResponse.Extension extension, string element)
        {
            return extension == null ? string.Empty : GetConfigValue(extension.PublicConfiguration, element);
        }

        private void SetConfigValue(XDocument config, string element, Object value)
        {
            if (config != null && value != null)
            {
                config.Descendants().ForEach(e =>
                {
                    if (e.Name.LocalName == element)
                    {
                        if (value.GetType().Equals(typeof(XmlDocument)))
                        {
                            e.ReplaceAll(XElement.Load(new XmlNodeReader(value as XmlDocument)));
                            e.Descendants().ForEach(d =>
                            {
                                if (string.IsNullOrEmpty(d.Name.NamespaceName))
                                {
                                    d.Name = config.Root.Name.Namespace + d.Name.LocalName;
                                }
                            });
                        }
                        else
                        {
                            e.SetValue(value.ToString());
                        }
                    }
                });
            }
        }

        private void SetConfigAttribute(XDocument config, string element, string attribute, Object value)
        {
            if (config == null || value == null)
            {
                return;
            }

            config.Descendants().ForEach(e =>
            {
                if (e.Name.LocalName == element)
                {
                    if (!e.HasAttributes)
                    {
                        return;
                    }
                    e.Attributes().ForEach(a =>
                    {
                        if (a.Name.LocalName == attribute)
                        {
                            a.SetValue(value.ToString());
                        }
                    });
                }
            });
        }

        protected void SetPublicConfigValue(string element, Object value)
        {
            SetConfigValue(PublicConfigurationXml, element, value);
        }

        protected void SetPrivateConfigValue(string element, Object value)
        {
            SetConfigValue(PrivateConfigurationXml, element, value);
        }

        protected void SetPublicConfigAttribute(string element, string attribute, Object value)
        {
            SetConfigAttribute(PublicConfigurationXml, element, attribute, value);
        }

        protected void SetPrivateConfigAttribute(string element, string attribute, Object value)
        {
            SetConfigAttribute(PrivateConfigurationXml, element, attribute, value);
        }

        protected void ChangeDeployment(ExtensionConfiguration extConfig)
        {
            DeploymentChangeConfigurationParameters changeConfigInput = new DeploymentChangeConfigurationParameters
            {
                Configuration = Deployment.Configuration,
                ExtensionConfiguration = Deployment.ExtensionConfiguration = extConfig,
                Mode = DeploymentChangeConfigurationMode.Auto,
                TreatWarningsAsError = false
            };

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.Deployments.ChangeConfigurationBySlot(
                    ServiceName,
                    (DeploymentSlot)Enum.Parse(typeof(DeploymentSlot), Slot, true),
                    changeConfigInput));
        }

        protected DeploymentGetResponse GetDeployment(string slot)
        {
            var slotType = (DeploymentSlot)Enum.Parse(typeof(DeploymentSlot), slot, true);

            DeploymentGetResponse d = null;
            InvokeInOperationContext(() =>
            {
                try
                {
                    d = this.ComputeClient.Deployments.GetBySlot(this.ServiceName, slotType);
                }
                catch (CloudException ex)
                {
                    if (ex.Response.StatusCode != HttpStatusCode.NotFound && IsVerbose() == false)
                    {
                        WriteExceptionError(ex);
                    }
                }
            });

            return d;
        }

        protected DeploymentGetResponse GetPeerDeployment(string currentSlot)
        {
            var currentSlotType = (DeploymentSlot)Enum.Parse(typeof(DeploymentSlot), currentSlot, true);
            var peerSlot = currentSlotType == DeploymentSlot.Production ? DeploymentSlot.Staging : DeploymentSlot.Production;
            var peerSlotStr = peerSlot.ToString();

            return GetDeployment(peerSlotStr);
        }

        protected SecureString GetSecurePassword(string password)
        {
            SecureString securePassword = new SecureString();
            if (!string.IsNullOrEmpty(password))
            {
                foreach (char c in password)
                {
                    securePassword.AppendChar(c);
                }
            }
            return securePassword;
        }

        protected string Serialize(object config)
        {
            string result = null;
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(config.GetType());
                serializer.Serialize(sw, config);
                result = sw.ToString();
            }

            return result;
        }

        protected object Deserialize(string config, Type type)
        {
            object result = null;
            using (StringReader sr = new StringReader(config))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                result = serializer.Deserialize(sr);
            }

            return result;
        }

        protected virtual ExtensionContext GetContext(OperationStatusResponse op, ExtensionRole role, HostedServiceListExtensionsResponse.Extension ext)
        {
            return new ExtensionContext
            {
                OperationId = op.Id,
                OperationDescription = CommandRuntime.ToString(),
                OperationStatus = op.Status.ToString(),
                Extension = ext.Type,
                ProviderNameSpace = ext.ProviderNamespace,
                Id = ext.Id
            };
        }

        protected void RemoveExtension()
        {
            ExtensionConfigurationBuilder configBuilder = ExtensionManager.GetBuilder(Deployment != null ? Deployment.ExtensionConfiguration : null);
            if (UninstallConfiguration && configBuilder.ExistAny(ProviderNamespace, ExtensionName))
            {
                configBuilder.RemoveAny(ProviderNamespace, ExtensionName);
                WriteWarning(string.Format(Resources.ServiceExtensionRemovingFromAllRoles, ExtensionName, ServiceName));
                ChangeDeployment(configBuilder.ToConfiguration());
            }
            else if (configBuilder.Exist(Role, ProviderNamespace, ExtensionName))
            {
                configBuilder.Remove(Role, ProviderNamespace, ExtensionName);
                if (Role == null || !Role.Any())
                {
                    WriteWarning(string.Format(Resources.ServiceExtensionRemovingFromAllRoles, ExtensionName, ServiceName));
                }
                else
                {
                    bool defaultExists = configBuilder.ExistDefault(ProviderNamespace, ExtensionName);
                    foreach (var r in Role)
                    {
                        WriteWarning(string.Format(Resources.ServiceExtensionRemovingFromSpecificRoles, ExtensionName, r, ServiceName));
                        if (defaultExists)
                        {
                            WriteWarning(string.Format(Resources.ServiceExtensionRemovingSpecificAndApplyingDefault, ExtensionName, r));
                        }
                    }
                }

                ChangeDeployment(configBuilder.ToConfiguration());
            }
            else
            {
                WriteWarning(string.Format(Resources.ServiceExtensionNoExistingExtensionsEnabledOnRoles, ProviderNamespace, ExtensionName));
            }

            if (UninstallConfiguration)
            {
                var allConfig = ExtensionManager.GetBuilder();
                var deploymentList = (from slot in (new string[] { DeploymentSlot.Production.ToString(), DeploymentSlot.Staging.ToString() })
                                      let d = GetDeployment(slot)
                                      where d != null
                                      select d).ToList();
                deploymentList.ForEach(d => allConfig.Add(d.ExtensionConfiguration));
                ExtensionManager.Uninstall(ProviderNamespace, ExtensionName, allConfig.ToConfiguration());
            }
        }
    }
}
