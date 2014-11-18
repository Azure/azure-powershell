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

using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class RoleConfiguration
    {
        private readonly XNamespace ns = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration";

        public RoleConfiguration(XElement data)
        {
            this.Name = data.Attribute("name").Value;
            this.InstanceCount = int.Parse(data.Element(this.ns + "Instances").Attribute("count").Value, CultureInfo.InvariantCulture);

            this.Settings = new Dictionary<string, string>();

            if (data.Element(this.ns + "ConfigurationSettings") != null)
            {
                foreach (var setting in data.Element(this.ns + "ConfigurationSettings").Descendants())
                {
                    this.Settings.Add(setting.Attribute("name").Value, setting.Attribute("value").Value);
                }
            }

            this.Certificates = new Dictionary<string, CertificateConfiguration>();

            if (data.Element(this.ns + "Certificates") != null)
            {
                foreach (var setting in data.Element(this.ns + "Certificates").Descendants())
                {
                    var certificate = new CertificateConfiguration
                    {
                        Thumbprint = setting.Attribute("thumbprint").Value,
                        ThumbprintAlgorithm = setting.Attribute("thumbprintAlgorithm").Value
                    };

                    this.Certificates.Add(setting.Attribute("name").Value, certificate);
                }
            }
        }

        public string Name
        {
            get;
            set;
        }

        public int InstanceCount
        {
            get;
            set;
        }

        public Dictionary<string, string> Settings
        {
            get;
            protected set;
        }

        public Dictionary<string, CertificateConfiguration> Certificates
        {
            get;
            protected set;
        }

        internal XElement Serialize()
        {
            XElement roleElement = new XElement(this.ns + "Role");
            roleElement.SetAttributeValue("name", this.Name);
            XElement instancesElement = new XElement(this.ns + "Instances");
            instancesElement.SetAttributeValue("count", this.InstanceCount);
            roleElement.Add(instancesElement);

            XElement configurationSettingsElement = new XElement(this.ns + "ConfigurationSettings");
            roleElement.Add(configurationSettingsElement);

            foreach (var setting in this.Settings)
            {
                XElement settingElement = new XElement(this.ns + "Setting");
                settingElement.SetAttributeValue("name", setting.Key);
                settingElement.SetAttributeValue("value", setting.Value);
                configurationSettingsElement.Add(settingElement);
            }

            XElement certificatesElement = new XElement(this.ns + "Certificates");
            roleElement.Add(certificatesElement);

            foreach (var certificate in this.Certificates)
            {
                XElement certificateElement = new XElement(this.ns + "Certificate");
                certificateElement.SetAttributeValue("name", certificate.Key);
                certificateElement.SetAttributeValue("thumbprint", certificate.Value.Thumbprint);
                certificateElement.SetAttributeValue("thumbprintAlgorithm", certificate.Value.ThumbprintAlgorithm);
                certificatesElement.Add(certificateElement);
            }

            return roleElement;
        }
    }
}