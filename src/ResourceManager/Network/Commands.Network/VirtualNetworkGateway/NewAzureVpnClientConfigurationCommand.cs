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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmVpnClientConfiguration"), OutputType(typeof(string))]
    public class NewAzureVpnClientConfigurationCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "ResourceGroup name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "VirtualNetworkGateway name")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkGatewayName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ProcessorArchitecture")]
        [ValidateSet(
            MNM.ProcessorArchitecture.Amd64,
            MNM.ProcessorArchitecture.X86,
            IgnoreCase = true)]
        public string ProcessorArchitecture { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Authentication Method")]
        [ValidateSet(
            MNM.AuthenticationMethod.EAPTLS,
            MNM.AuthenticationMethod.EAPMSCHAPv2,
            IgnoreCase = true)]
        public string AuthenticationMethod { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Radius server root certificate path")]
        public string RadiusRootCert { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A list of client root certificate paths")]
        public List<string> ClientRootCertificates { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            PSVpnClientParameters vpnClientParams = new PSVpnClientParameters();

            vpnClientParams.ProcessorArchitecture = string.IsNullOrWhiteSpace(this.ProcessorArchitecture) ? 
                MNM.ProcessorArchitecture.Amd64.ToString() :
                this.ProcessorArchitecture;

            vpnClientParams.AuthenticationMethod = string.IsNullOrWhiteSpace(this.AuthenticationMethod)
                ? MNM.AuthenticationMethod.EAPTLS.ToString()
                : this.AuthenticationMethod;

            // Read the radius server root certificate if present
            if (!string.IsNullOrWhiteSpace(RadiusRootCert))
            {
                if (File.Exists(RadiusRootCert))
                {
                    try
                    {
                        X509Certificate2 radiusRootCertificate = new X509Certificate2(RadiusRootCert);
                        vpnClientParams.RadiusServerAuthCertificate = Convert.ToBase64String(radiusRootCertificate.Export(X509ContentType.Cert));
                    }
                    catch (Exception)
                    {
                        WriteWarning("Invalid radius root certificate specified at path " +
                                     RadiusRootCert);
                    }
                }
                else
                {
                    WriteWarning("Cannot find radius root certificate with path " +
                                 RadiusRootCert);
                }
            }

            // Read the radius server root certificate if present
            if (this.ClientRootCertificates != null)
            {
                foreach (string clientRootCertPath in this.ClientRootCertificates)
                {
                    vpnClientParams.ClientRootCertificates = new List<string>();
                    if (File.Exists(clientRootCertPath))
                    {
                        try
                        {
                            X509Certificate2 clientRootCertificate = new X509Certificate2(clientRootCertPath);
                            vpnClientParams.ClientRootCertificates.Add(
                                Convert.ToBase64String(clientRootCertificate.Export(X509ContentType.Cert)));
                        }
                        catch (Exception)
                        {
                            WriteWarning("Invalid cer file specified for client root certificate with path " +
                                         clientRootCertPath);
                        }
                    }
                    else
                    {
                        WriteWarning("Cannot find client root certificate with path " +
                                     clientRootCertPath);
                    }
                }
            }

            var vnetVpnClientParametersModel = Mapper.Map<MNM.VpnClientParameters>(vpnClientParams);

            string packageUrl = this.NetworkClient.GenerateVpnProfile(ResourceGroupName, VirtualNetworkGatewayName, vnetVpnClientParametersModel);

            WriteObject(packageUrl);
        }
    }
}

