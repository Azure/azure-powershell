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

namespace Microsoft.Azure.Commands.ApiManagement.Helpers
{
    public class Constants
    {
        /// <summary>
        /// Setting prefix for Frontend Protocol Settings
        /// </summary>
        public const string FrontendProtocolSettingPrefix = "Microsoft.WindowsAzure.ApiManagement.Gateway.Security.Protocols.";

        /// <summary>
        /// Setting prefix for Backend Protocol Settings
        /// </summary>
        public const string BackendProtocolSettingPrefix = "Microsoft.WindowsAzure.ApiManagement.Gateway.Security.Backend.Protocols.";

        /// <summary>
        /// Settings prefix for Cipher Settings
        /// </summary>
        public const string CipherSettingPrefix = "Microsoft.WindowsAzure.ApiManagement.Gateway.Security.Ciphers.";

        /// <summary>
        /// Settings prefix for Server Setting Prefix
        /// </summary>
        public const string ServerSettingPrefix = "Microsoft.WindowsAzure.ApiManagement.Gateway.Protocols.Server.";
    }
}
