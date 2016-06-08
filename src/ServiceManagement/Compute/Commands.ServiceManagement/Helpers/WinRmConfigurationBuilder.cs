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
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers
{
    public class WinRmConfigurationBuilder
    {
        private const string Http = "Http";
        private const string Https = "Https";

        public WindowsProvisioningConfigurationSet.WinRmConfiguration Configuration { get; private set; }

        public WinRmConfigurationBuilder()
        {
            Configuration = new WindowsProvisioningConfigurationSet.WinRmConfiguration
            {
                Listeners = new WindowsProvisioningConfigurationSet.WinRmListenerCollection()
            };
        }

        public WinRmConfigurationBuilder(WindowsProvisioningConfigurationSet.WinRmConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GetHttpsCertificateThumbprint()
        {
            var httpsListener = Configuration.Listeners.FirstOrDefault(l => l.Protocol == Https);
            if (httpsListener == null)
            {
                throw new ArgumentOutOfRangeException(Resources.MissingWinRMHttpsListener);
            }

            return httpsListener.CertificateThumbprint;
        }

        public void AddHttpListener()
        {
            if (Configuration.Listeners.FirstOrDefault(l=> l.Protocol == Http) != null)
            {
                throw new ArgumentOutOfRangeException(Resources.AlreadyExistingWinRMHttpListener);
            }
            var listener = new WindowsProvisioningConfigurationSet.WinRmListenerProperties
            {
                Protocol = Http
            };
            Configuration.Listeners.Add(listener);
        }


        public void AddHttpsListener(X509Certificate2 certificate)
        {
            if (certificate != null)
            {
                if(!certificate.HasPrivateKey)
                {
                    throw new ArgumentOutOfRangeException(Resources.MissingPrivateKeyInWinRMCertificate);
                }
                AddHttpsListener(certificate.Thumbprint);
            }
            else
            {
                AddHttpsListener();
            }
        }

        public void UpdateHttpsListener(X509Certificate2 certificate)
        {
            var httpsListener = Configuration.Listeners.FirstOrDefault(l => l.Protocol == Https);
            if (httpsListener == null)
            {
                throw new ArgumentOutOfRangeException(Resources.MissingWinRMHttpsListener);
            }
            httpsListener.CertificateThumbprint = certificate.Thumbprint;
        }

        public void AddHttpsListener()
        {
            if (Configuration.Listeners.FirstOrDefault(l => l.Protocol == Https) != null)
            {
                throw new ArgumentOutOfRangeException(Resources.AlreadyExistingWinRMHttpsListener);
            }
            var listener = new WindowsProvisioningConfigurationSet.WinRmListenerProperties
            {
                Protocol = WindowsProvisioningConfigurationSet.WinRmProtocol.Https.ToString()
            };
            Configuration.Listeners.Add(listener);
        }

        public void AddHttpsListener(string thumbprint)
        {
            if (Configuration.Listeners.FirstOrDefault(l => l.Protocol == Https) != null)
            {
                throw new ArgumentOutOfRangeException(Resources.AlreadyExistingWinRMHttpsListener);
            }
            var listener = new WindowsProvisioningConfigurationSet.WinRmListenerProperties
            {
                Protocol = WindowsProvisioningConfigurationSet.WinRmProtocol.Https.ToString(),
                CertificateThumbprint = thumbprint
            };
            Configuration.Listeners.Add(listener);
        }
    }
}