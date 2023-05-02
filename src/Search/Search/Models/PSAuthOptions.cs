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

using Microsoft.Azure.Management.Search.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSAuthOptions
    {
        [Ps1Xml(Label = "ApiKeyOnly", Target = ViewControl.List, Position = 0)]
        public PSObject ApiKeyOnly { get; set; }

        [Ps1Xml(Label = "AadOrApiKey", Target = ViewControl.List, Position = 0)]
        public PsAadOrApiKeyAuthOption AadOrApiKey { get; set; }

        public static explicit operator PSAuthOptions(DataPlaneAuthOptions v)
        {
            object apiKeyOnly = v?.ApiKeyOnly;
            DataPlaneAadOrApiKeyAuthOption aadOrApiKey = v?.AadOrApiKey;
            
            if (v == null)
            {
                return null;
            }
            else if (apiKeyOnly != null)
            {
                return new PSAuthOptions
                {
                    ApiKeyOnly = new PSObject()
                };
            }
            else if (aadOrApiKey != null)
            {
                return new PSAuthOptions
                {
                    AadOrApiKey = (PsAadOrApiKeyAuthOption)aadOrApiKey
                };
            }
            else
            {
                return new PSAuthOptions();
            }
        }

        public static explicit operator DataPlaneAuthOptions(PSAuthOptions v)
        {
            PSObject apiKeyOnly = v?.ApiKeyOnly;
            PsAadOrApiKeyAuthOption aadOrApiKey = v?.AadOrApiKey;

            if (v == null)
            {
                return null;
            }
            else if (apiKeyOnly != null)
            {
                return new DataPlaneAuthOptions { ApiKeyOnly = new { } };
            }
            else if (aadOrApiKey != null)
            {
                return new DataPlaneAuthOptions { AadOrApiKey = (DataPlaneAadOrApiKeyAuthOption)aadOrApiKey };
            }
            else
            {
                return new DataPlaneAuthOptions();
            }
        }
    }
}
