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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway.Model
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.IO;
    using System.Globalization;
    using System.Text;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// This class represents the Application Gateway configuration. The configuration includes the frontend points including the listeners on which the gateway 
    /// can receive traffic, the backend servers and the load balancing rules which forward the incoming traffic to the backend servers
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class ApplicationGatewayConfiguration : ConfigurationElement
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public IEnumerable<FrontendIPConfiguration> FrontendIPConfigurations { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public IEnumerable<FrontendPort> FrontendPorts { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public IEnumerable<Probe> Probes { get; set; }

        /// <summary>
        /// Collection of backend address pools. See backendAddressPools in the NRP spec
        /// </summary>
        [DataMember(Order = 4, IsRequired = true)]
        public IEnumerable<BackendAddressPool> BackendAddressPools { get; set; }

        [DataMember(Order = 5, IsRequired = true)]
        public IEnumerable<BackendHttpSettings> BackendHttpSettingsList { get; set; }

        [DataMember(Order = 6, IsRequired = true)]
        public IEnumerable<HttpListener> HttpListeners { get; set; }

        [DataMember(Order = 7, IsRequired = true)]
        public IEnumerable<HttpLoadBalancingRule> HttpLoadBalancingRules { get; set; }

        public ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        public ApplicationGatewayConfiguration()
        {
        }

        public void ProcessConfiguration()
        {
            this.ConfigurationContext = new ApplicationGatewayConfigurationContext(this);
            this.ConfigurationContext.ProcessConfigurationElements();
        }

        public override void Validate()
        {
            if (this.FrontendIPConfigurations != null && this.FrontendIPConfigurations.Count() > 2)
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    "Maximum two FrontendIPConfiguration can be specified");
            }

            //Validate that atleast one of each configuration element is present
            if (!this.FrontendPorts.Any())
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    "Atleast one FrontendPort must be specified");
            }

            if (!this.BackendAddressPools.Any())
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    "Atleast one BackendAddressPool must be specified");
            }

            if (!this.BackendHttpSettingsList.Any())
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    "Atleast one BackendHttpSettings must be specified");
            }

            if (!this.HttpListeners.Any())
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    "Atleast one HttpListener must be specified");
            }

            if (!this.HttpLoadBalancingRules.Any())
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    "Atleast one HttpLoadBalancingRule must be specified");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (null != FrontendIPConfigurations)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "FrontendIPConfigurations:");
                foreach (FrontendIPConfiguration frontendIPConfiguration in FrontendIPConfigurations)
                {
                    sb.AppendFormat("{0}", frontendIPConfiguration == null ? "null" : frontendIPConfiguration.ToString());
                }
            }

            sb.AppendFormat(CultureInfo.InvariantCulture, "FrontEndPorts:");
            foreach (FrontendPort frontEndPort in FrontendPorts)
            {
                sb.AppendFormat("{0}", frontEndPort == null ? "null" : frontEndPort.ToString());
            }

            if (null != Probes)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "Probes:");
                foreach (Probe probe in Probes)
                {
                    sb.AppendFormat("{0}", probe == null ? "null" : probe.ToString());
                }
            }

            sb.AppendFormat(CultureInfo.InvariantCulture, "BackendAddressPools:");
            foreach (BackendAddressPool backendAddressPool in BackendAddressPools)
            {
                sb.AppendFormat("{0}", backendAddressPool == null ? "null" : backendAddressPool.ToString());
            }

            sb.AppendFormat(CultureInfo.InvariantCulture, "BackendHttpSettings:");
            foreach (BackendHttpSettings backendHttpSettings in BackendHttpSettingsList)
            {
                sb.AppendFormat("{0}", backendHttpSettings == null ? "null" : backendHttpSettings.ToString());
            }

            sb.AppendFormat(CultureInfo.InvariantCulture, "HttpListeners:");
            foreach (HttpListener httpListener in HttpListeners)
            {
                sb.AppendFormat("{0}", httpListener == null ? "null" : httpListener.ToString());
            }

            sb.AppendFormat(CultureInfo.InvariantCulture, "HttpLoadBalancingRules:");
            foreach (HttpLoadBalancingRule httpLoadBalancingRule in HttpLoadBalancingRules)
            {
                sb.AppendFormat("{0}", httpLoadBalancingRule == null ? "null" : httpLoadBalancingRule.ToString());
            }

            return sb.ToString();
        }

        public static ApplicationGatewayConfiguration Deserialize(string xmlConfig)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(xmlConfig);
            MemoryStream stream = new MemoryStream(byteArray);

            DataContractSerializer serializer = new DataContractSerializer(typeof(ApplicationGatewayConfiguration));
            ApplicationGatewayConfiguration deserializedConfig = null;
            try
            {
                deserializedConfig = (ApplicationGatewayConfiguration)serializer.ReadObject(stream);
            }
            catch (Exception e)
            {
                throw new ApplicationGatewayConfigurationException(
                    string.Format("Error deserializing config: {0}", xmlConfig), e);
            }

            return deserializedConfig;
        }

        public static string Print(ApplicationGatewayConfiguration config)
        {
            MemoryStream stream = new MemoryStream();

            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "    "
            };

            DataContractSerializer serializer = new DataContractSerializer(typeof(ApplicationGatewayConfiguration));

            using (var writer = XmlWriter.Create(stream, settings))
            {
                try
                {
                    serializer.WriteObject(writer, config);
                }
                catch (Exception e)
                {
                    throw new ApplicationGatewayConfigurationException(
                        string.Format("Error Serializing config: {0}", config.ToString()), e);
                }
            }

            stream.Position = 0;
            var sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }

        public List<string> GetSslCertNamesFromListeners()
        {
            List<string> certnames = new List<String>();

            foreach (HttpListener httpListener in HttpListeners)
            {
                if (httpListener.Protocol == Protocol.Https)
                {
                    certnames.Add(httpListener.SslCert);
                }
            }
            return certnames;
        }

        public bool IsCertInUse(string certName)
        {
            foreach (HttpListener httpListener in HttpListeners)
            {
                if ((httpListener.Protocol == Protocol.Https) &&
                    string.Equals(certName, httpListener.SslCert, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}