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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    public class VirtualMachineAccessExtensionCmdletBase : VirtualMachineExtensionCmdletBase
    {
        protected const string VirtualMachineAccessExtensionNoun = "AzureVMAccessExtension";

        protected const string ExtensionDefaultPublisher = "Microsoft.Compute";
        protected const string ExtensionDefaultName = "VMAccessAgent";
        protected const string LegacyReferenceName = "MyPasswordResetExtension";
        protected const string ExtensionDefaultVersion = "2.*";

        protected const string VMAccessAgentLegacyVersion = "0.1";

        private const string ConfigurationElem = "Configuration";
        private const string PublicElem = "Public";
        private const string PublicConfigElem = "PublicConfig";
        private const string PrivateConfigElem = "PrivateConfig";
        private const string AccountElem = "Account";
        private const string EnabledElem = "Enabled";
        private const string UserNameElem = "UserName";
        private const string PasswordElem = "Password";

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public VirtualMachineAccessExtensionCmdletBase()
        {
            base.publisherName = ExtensionDefaultPublisher;
            base.extensionName = ExtensionDefaultName;
        }

        protected string GetLegacyConfiguration()
        {
            XDocument config = null;
            if (Disable.IsPresent)
            {
                config = new XDocument(
                    new XDeclaration("1.0", "utf-8", null),
                    new XElement(ConfigurationElem,
                        new XElement(EnabledElem, (!Disable.IsPresent).ToString().ToLower())
                    )
                );
            }
            else
            {
                config = new XDocument(
                    new XDeclaration("1.0", "utf-8", null),
                    new XElement(ConfigurationElem,
                        new XElement(EnabledElem, (!Disable.IsPresent).ToString().ToLower()),
                        new XElement(PublicElem,
                            new XElement(PublicConfigElem,
                                new XElement(AccountElem,
                                    new XElement(UserNameElem, UserName),
                                    new XElement(PasswordElem, Password)
                                )
                            )
                        )
                    )
                );
            }

            return config.ToString();
        }

        protected string GetPublicConfiguration()
        {
            XDocument config = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(PublicConfigElem,
                    new XElement(UserNameElem, UserName)
                )
            );

            return config.ToString();
        }

        protected string GetJsonPublicConfiguration()
        {
            Hashtable publicSettings = new Hashtable();
            publicSettings.Add(UserNameElem, UserName ?? "");

            return JsonConvert.SerializeObject(publicSettings);
        }

        protected string GetPrivateConfiguration()
        {
            XDocument config = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(PrivateConfigElem,
                    new XElement(PasswordElem, Password)
                )
            );

            return config.ToString();
        }
        protected string GetJsonPrivateConfiguration()
        {
            Hashtable privateSettings = new Hashtable();
            privateSettings.Add(PasswordElem, Password ?? "");

            return JsonConvert.SerializeObject(privateSettings);
        }

        protected void GetVMAccessExtensionValues(ResourceExtensionReference extensionRef)
        {
            if (extensionRef != null && extensionRef.ResourceExtensionParameterValues != null)
            {
                if (IsLegacyExtension(extensionRef.Name, extensionRef.Publisher, extensionRef.Version))
                {
                    GetVMAccessExtensionLegacyValues(extensionRef.ResourceExtensionParameterValues);
                }
                else
                {
                    Disable = string.Equals(extensionRef.State, ReferenceDisableStateStr);
                    GetVMAccessExtensionValues(extensionRef.ResourceExtensionParameterValues, IsXmlExtension(extensionRef.Version));
                }
            }
            else
            {
                Disable = extensionRef == null ? true : string.Equals(extensionRef.State, ReferenceDisableStateStr);
            }
        }

        private void GetVMAccessExtensionValues(ResourceExtensionParameterValueList paramVals, bool isXml)
        {
            if (paramVals != null && paramVals.Any())
            {
                var publicParamVal = paramVals.FirstOrDefault(
                    r => !string.IsNullOrEmpty(r.Value) && string.Equals(r.Type, PublicTypeStr));
                if (publicParamVal != null && !string.IsNullOrEmpty(publicParamVal.Value))
                {
                    this.PublicConfiguration = publicParamVal.Value;
                    this.UserName = (isXml)
                        ? GetConfigValue(this.PublicConfiguration, UserNameElem)
                        : GetJsonConfigValue(this.PublicConfiguration, UserNameElem);
                }

                var privateParamVal = paramVals.FirstOrDefault(
                    r => r.SecureValue != null && !string.IsNullOrEmpty(
                         r.SecureValue.ConvertToUnsecureString())
                      && string.Equals(r.Type, PrivateTypeStr));

                if (privateParamVal != null)
                {
                    this.PrivateConfiguration = privateParamVal.SecureValue.ConvertToUnsecureString();
                    this.Password = (isXml)
                        ? GetConfigValue(this.PrivateConfiguration, PasswordElem)
                        : GetJsonConfigValue(this.PrivateConfiguration, PasswordElem);
                }
            }
        }

        private bool ParseStrToBool(string value)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(value))
            {
                bool.TryParse(value, out result);
            }

            return result;
        }

        private void GetVMAccessExtensionLegacyValues(ResourceExtensionParameterValueList paramVals)
        {
            if (paramVals != null && paramVals.Any())
            {
                var paramVal = paramVals.FirstOrDefault(r => !string.IsNullOrEmpty(r.Value));
                if (paramVal != null && !string.IsNullOrEmpty(paramVal.Value))
                {
                    this.PublicConfiguration = paramVal.Value;
                    this.Disable = ParseStrToBool(GetConfigValue(this.PublicConfiguration, EnabledElem));
                    this.UserName = GetConfigValue(this.PublicConfiguration, UserNameElem);
                    this.Password = GetConfigValue(this.PublicConfiguration, PasswordElem);
                }
            }
        }
    }
}
