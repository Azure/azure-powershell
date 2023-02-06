﻿// ----------------------------------------------------------------------------------
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

// using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01.Models;
using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class VaultCreationOrUpdateParameters
    {
        public string Name { get; set; }
        public string ResourceGroupName { get; set; }
        public string Location { get; set; }
        public Hashtable Tags { get; set; }
        public string SkuName { get; set; }
        public string SkuFamilyName { get; set; }
        public bool? EnabledForDeployment { get; set; }
        public bool? EnabledForTemplateDeployment { get; set; }
        public bool? EnabledForDiskEncryption { get; set; }
        public bool? EnableSoftDelete { get; set; }
        public bool? EnablePurgeProtection { get; set; }
        public bool? EnableRbacAuthorization { get; set; }
        public int? SoftDeleteRetentionInDays { get; set; }
        public string PublicNetworkAccess { get; set; }
        public Guid TenantId { get; set; }
        public AccessPolicyEntry AccessPolicy { get; set; }
        public NetworkRuleSet NetworkAcls { get; set; }
        public MHSMNetworkRuleSet MhsmNetworkAcls { get; set; }
        public CreateMode? CreateMode { get; set; }
        public string[] Administrator { get; set; }
        // public string TemplateFile { get; set; }
        public DeploymentMode DeploymentMode { get; set; }
        public string QueryString { get; set; }
        public Hashtable TemplateObject { get; set; }
        public Hashtable TemplateParameterObject { get; set; }
        public string ParameterUri { get; set; }
        public string DeploymentDebugLogLevel { get; set; }
        public OnErrorDeployment OnErrorDeployment { get; set; }
        // public IDictionary<string, string> Tags { get; set; }
    }
}
