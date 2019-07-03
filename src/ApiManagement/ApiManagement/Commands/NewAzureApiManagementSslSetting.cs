//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using System.Collections;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using ResourceManager.Common;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementSslSetting")]
    [OutputType(typeof(PsApiManagementSslSetting))]
    public class NewAzureApiManagementSslSetting : AzureRMCmdlet
    {
        [Parameter(
          HelpMessage = "Frontend Security protocols settings. This parameter is optional.")]
        public Hashtable FrontendProtocol { get; set; }

        [Parameter(
          HelpMessage = "Backend Security protocol settings. This parameter is optional.")]
        public Hashtable BackendProtocol { get; set; }

        [Parameter(
               HelpMessage = "Ssl cipher suites settings in the specified order. This parameter is optional.")]
        public Hashtable CipherSuite { get; set; }

        [Parameter(
               HelpMessage = "Server protocol settings like Http2. This parameter is optional.")]
        public Hashtable ServerProtocol { get; set; }

        public override void ExecuteCmdlet()
        {
            var sslSettings = new PsApiManagementSslSetting();

            if (FrontendProtocol != null && FrontendProtocol.Count > 0)
            {
                sslSettings.FrontendProtocol = FrontendProtocol;
            }

            if (BackendProtocol != null && BackendProtocol.Count > 0)
            { 
                sslSettings.BackendProtocol = BackendProtocol;
            }

            if (CipherSuite != null && CipherSuite.Count > 0)
            {
                sslSettings.CipherSuite = CipherSuite;
            }

            if (ServerProtocol != null && ServerProtocol.Count > 0)
            {
                sslSettings.ServerProtocol = ServerProtocol;
            }

            WriteObject(sslSettings);
        }
    }
}
