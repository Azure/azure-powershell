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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Xml.Linq;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    public class VirtualMachineExtensionCmdletBase : VirtualMachineConfigurationCmdletBase
    {
        protected const string PublicConfigurationKeyStr = "PublicConfiguration";
        protected const string PrivateConfigurationKeyStr = "PrivateConfiguration";
        protected const string PublicTypeStr = "Public";
        protected const string PrivateTypeStr = "Private";
        public const string ReferenceDisableStateStr = "Disable";
        public const string ReferenceEnableStateStr = "Enable";
        public const string ReferenceUninstallStateStr = "Uninstall";

        protected static VirtualMachineExtensionImageContext[] LegacyExtensionImages;

        protected string extensionName;
        protected string publisherName;

        public virtual string ExtensionName
        {
            get
            {
                return extensionName;
            }

            set
            {
                extensionName = value;
            }
        }

        public virtual string Publisher
        {
            get
            {
                return publisherName;
            }

            set
            {
                publisherName = value;
            }
        }

        public virtual string Version { get; set; }
        public virtual string ReferenceName { get; set; }
        public virtual string PublicConfigKey { get; set; }
        public virtual string PrivateConfigKey { get; set; }
        public virtual string PublicConfiguration { get; set; }
        public virtual string PrivateConfiguration { get; set; }
        public virtual string PublicConfigPath { get; set; }
        public virtual string PrivateConfigPath { get; set; }
        public virtual SwitchParameter Disable { get; set; }
        public virtual SwitchParameter Uninstall { get; set; }
        public virtual SwitchParameter ForceUpdate { get; set; }

        static VirtualMachineExtensionCmdletBase()
        {
            LegacyExtensionImages = new VirtualMachineExtensionImageContext[2]
            {
                new VirtualMachineExtensionImageContext
                {
                    ExtensionName = "VMAccessAgent",
                    Publisher = "Microsoft.Compute",
                    Version = "0.1"
                },

                new VirtualMachineExtensionImageContext
                {
                    ExtensionName = "DiagnosticsAgent",
                    Publisher = "Microsoft.Compute",
                    Version = "0.1"
                }
            };
        }

        protected bool IsLegacyExtension()
        {
            return IsLegacyExtension(this.ExtensionName, this.Publisher, this.Version);
        }

        protected bool IsLegacyExtension(string name, string publisher, string version)
        {
            Func<string, string, bool> eq =
                (x, y) => string.Equals(x, y, StringComparison.OrdinalIgnoreCase);

            return LegacyExtensionImages == null ? false
                 : LegacyExtensionImages.Any(r => eq(r.ExtensionName, name)
                                               && eq(r.Publisher, publisher)
                                               && eq(r.Version, version));
        }

        protected bool IsXmlExtension(string version)
        {
            if (string.IsNullOrEmpty(version))
            {
                return false;
            }
            return version.StartsWith("1");
        }

        protected ResourceExtensionReferenceList ResourceExtensionReferences
        {
            get
            {
                if (VM.GetInstance().ResourceExtensionReferences == null)
                {
                    VM.GetInstance().ResourceExtensionReferences = new ResourceExtensionReferenceList();
                }

                return VM.GetInstance().ResourceExtensionReferences;
            }
        }

        protected Func<ResourceExtensionReference, bool> ExtensionPredicate
        {
            get
            {
                Func<string, string, bool> eq =
                    (x, y) => string.Equals(x, y, StringComparison.OrdinalIgnoreCase);

                return string.IsNullOrEmpty(this.ExtensionName) ?
                       (Func<ResourceExtensionReference, bool>)
                       (r => eq(r.ReferenceName, this.ReferenceName))
                     : (r => eq(r.Name, this.ExtensionName)
                          && eq(r.Publisher, this.Publisher));
            }
        }

        protected List<ResourceExtensionReference> GetPredicateExtensionList()
        {
            List<ResourceExtensionReference> extensionRefs = null;
            if (!ResourceExtensionReferences.Any())
            {
                WriteWarning(Resources.ResourceExtensionReferencesIsNullOrEmpty);
                return extensionRefs;
            }

            extensionRefs = ResourceExtensionReferences.FindAll(
                r => ExtensionPredicate(r));
            if (!extensionRefs.Any())
            {
                WriteWarning(Resources.ResourceExtensionReferenceCannotBeFound);
            }

            return extensionRefs;
        }

        protected ResourceExtensionReference GetPredicateExtension()
        {
            ResourceExtensionReference extensionRef = null;
            if (!ResourceExtensionReferences.Any())
            {
                WriteWarning(Resources.ResourceExtensionReferencesIsNullOrEmpty);
            }
            else
            {
                extensionRef = ResourceExtensionReferences.FirstOrDefault(ExtensionPredicate);
            }

            return extensionRef;
        }

        protected void AddResourceExtension()
        {
            ResourceExtensionReferences.Add(NewResourceExtension());
        }

        protected void RemovePredicateExtensions()
        {
            ResourceExtensionReferences.RemoveAll(r => ExtensionPredicate(r));
        }

        protected ResourceExtensionReference NewResourceExtension()
        {
            var extensionRef = new ResourceExtensionReference();

            extensionRef.Name = this.ExtensionName;
            extensionRef.Publisher = this.Publisher;
            extensionRef.Version = this.Version;
            extensionRef.State = IsLegacyExtension() ? null :
                this.Uninstall.IsPresent ? ReferenceUninstallStateStr :
                this.Disable.IsPresent ? ReferenceDisableStateStr : ReferenceEnableStateStr;
            extensionRef.ResourceExtensionParameterValues = new ResourceExtensionParameterValueList();

            if (!string.IsNullOrEmpty(this.ReferenceName))
            {
                extensionRef.ReferenceName = this.ReferenceName;
            }
            else
            {
                extensionRef.ReferenceName = extensionRef.Name;
            }

            if (!string.IsNullOrEmpty(this.PublicConfigPath))
            {
                this.PublicConfiguration = FileUtilities.DataStore.ReadFileAsText(this.PublicConfigPath);
            }

            if (!string.IsNullOrEmpty(this.PublicConfiguration))
            {
                extensionRef.ResourceExtensionParameterValues.Add(
                    new ResourceExtensionParameterValue
                    {
                        Key = !string.IsNullOrEmpty(this.PublicConfigKey) ? this.PublicConfigKey
                            : ExtensionName + (IsLegacyExtension() ? string.Empty : PublicTypeStr) + "ConfigParameter",
                        Type = IsLegacyExtension() ? null : PublicTypeStr,
                        Value = PublicConfiguration
                    });
            }

            if (!string.IsNullOrEmpty(this.PrivateConfigPath))
            {
                this.PrivateConfiguration = FileUtilities.DataStore.ReadFileAsText(this.PrivateConfigPath);
            }

            if (!string.IsNullOrEmpty(this.PrivateConfiguration))
            {
                extensionRef.ResourceExtensionParameterValues.Add(
                    new ResourceExtensionParameterValue
                    {
                        Key = !string.IsNullOrEmpty(this.PrivateConfigKey) ? this.PrivateConfigKey
                            : ExtensionName + (IsLegacyExtension() ? string.Empty : PrivateTypeStr) + "ConfigParameter",
                        Type = IsLegacyExtension() ? null : PrivateTypeStr,
                        SecureValue = SecureStringHelper.GetSecureString(PrivateConfiguration)
                    });
            }

            if (this.ForceUpdate.IsPresent)
            {
                extensionRef.ForceUpdate = true;
            }

            return extensionRef;
        }

        protected string GetConfiguration(
            ResourceExtensionParameterValueList paramValList,
            string typeStr)
        {
            string config = string.Empty;
            if (paramValList != null && paramValList.Any())
            {
                var paramVal = paramValList.FirstOrDefault(
                    p => string.IsNullOrEmpty(typeStr) ? true :
                         string.Equals(p.Type, typeStr, StringComparison.OrdinalIgnoreCase));
                config = SecureStringHelper.GetPlainString(paramVal);
            }

            return config;
        }

        protected string GetConfiguration(
            ResourceExtensionReference extensionRef)
        {
            return extensionRef == null ? string.Empty : GetConfiguration(
                extensionRef.ResourceExtensionParameterValues, null);
        }

        protected string GetConfiguration(
            ResourceExtensionReference extensionRef,
            string typeStr)
        {
            return extensionRef == null ? string.Empty : GetConfiguration(
                extensionRef.ResourceExtensionParameterValues,
                typeStr);
        }

        protected virtual void ValidateParameters()
        {
            // GA must be enabled before setting extensions
            if (VM.GetInstance().ProvisionGuestAgent != null && !VM.GetInstance().ProvisionGuestAgent.Value)
            {
                throw new ArgumentException(Resources.ProvisionGuestAgentMustBeEnabledBeforeSettingIaaSVMAccessExtension);
            }

            if (string.IsNullOrEmpty(this.ReferenceName))
            {
                var extensionRef = GetPredicateExtension();
                if (extensionRef != null)
                {
                    this.ReferenceName = extensionRef.ReferenceName;
                }
            }
        }

        protected virtual void GetExtensionValues(ResourceExtensionReference extensionRef)
        {
            if (extensionRef != null && extensionRef.ResourceExtensionParameterValues != null)
            {
                Disable = string.Equals(extensionRef.State, ReferenceDisableStateStr);
                GetExtensionValues(extensionRef.ResourceExtensionParameterValues);
            }
            else
            {
                Disable = extensionRef == null ? true : string.Equals(extensionRef.State, ReferenceDisableStateStr);
            }
        }

        protected virtual void GetExtensionValues(ResourceExtensionParameterValueList paramVals)
        {
            if (paramVals != null && paramVals.Any())
            {
                var publicParamVal = paramVals.FirstOrDefault(
                    r => !string.IsNullOrEmpty(r.Value) && string.Equals(r.Type, PublicTypeStr));
                if (publicParamVal != null && !string.IsNullOrEmpty(publicParamVal.Value))
                {
                    this.PublicConfiguration = publicParamVal.Value;
                }

                var privateParamVal = paramVals.FirstOrDefault(
                    r => !string.IsNullOrEmpty(r.Value) && string.Equals(r.Type, PrivateTypeStr));
                if (privateParamVal != null && !string.IsNullOrEmpty(privateParamVal.Value))
                {
                    this.PrivateConfiguration = privateParamVal.Value;
                }
            }
        }

        protected static string GetConfigValue(string xmlText, string element)
        {
            XDocument config = XDocument.Parse(xmlText);

            var result = from d in config.Descendants()
                         where d.Name.LocalName == element
                         select d.Descendants().Any() ? d.ToString() : d.Value;

            return result.FirstOrDefault();
        }

        protected static string GetJsonConfigValue(string jsonText, string element)
        {
            if (string.IsNullOrEmpty(jsonText))
            {
                return null;
            }
            var jsonObject = JObject.Parse(jsonText);
            return jsonObject[element].Value<string>();
        }
    }
}
