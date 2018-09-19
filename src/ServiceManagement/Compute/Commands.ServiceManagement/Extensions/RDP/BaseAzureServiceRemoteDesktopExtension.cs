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
using System.Management.Automation;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    public abstract class BaseAzureServiceRemoteDesktopExtensionCmdlet : BaseAzureServiceExtensionCmdlet
    {
        protected const string UserNameElemStr = "UserName";
        protected const string ExpirationElemStr = "Expiration";
        protected const string PasswordElemStr = "Password";
        protected const string RDPExtensionNamespace = "Microsoft.Windows.Azure.Extensions";
        protected const string RDPExtensionType = "RDP";

        public virtual PSCredential Credential { get; set; }
        public virtual DateTime Expiration { get; set; }

        public BaseAzureServiceRemoteDesktopExtensionCmdlet()
            : base()
        {
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            ProviderNamespace = RDPExtensionNamespace;
            ExtensionName = RDPExtensionType;

            PublicConfigurationXmlTemplate = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XProcessingInstruction("xml-stylesheet", @"type=""text/xsl"" href=""style.xsl"""),
                new XElement(PublicConfigStr,
                    new XElement(UserNameElemStr, string.Empty),
                    new XElement(ExpirationElemStr, string.Empty)
                )
            );

            PrivateConfigurationXmlTemplate = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XProcessingInstruction("xml-stylesheet", @"type=""text/xsl"" href=""style.xsl"""),
                new XElement(PrivateConfigStr,
                    new XElement(PasswordElemStr, string.Empty)
                )
            );
        }

        protected override void ValidateConfiguration()
        {
            PublicConfigurationXml = new XDocument(PublicConfigurationXmlTemplate);
            SetPublicConfigValue(UserNameElemStr, Credential.UserName);
            SetPublicConfigValue(ExpirationElemStr, Expiration.ToString("yyyy-MM-dd"));
            PublicConfiguration = PublicConfigurationXml.ToString();

            PrivateConfigurationXml = new XDocument(PrivateConfigurationXmlTemplate);
            SetPrivateConfigValue(PasswordElemStr, Credential.Password.ConvertToUnsecureString());
            PrivateConfiguration = PrivateConfigurationXml.ToString();
        }
    }
}
