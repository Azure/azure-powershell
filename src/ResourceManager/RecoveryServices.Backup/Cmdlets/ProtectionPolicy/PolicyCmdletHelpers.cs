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

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{   
    public class PolicyCmdletHelpers 
    {
        public static Regex rgx = new Regex(@"^[A-Za-z][-A-Za-z0-9]*[A-Za-z0-9]$");

        public static void ValidateProtectionPolicyName(string policyName)
        {
            if (policyName.Length < PolicyConstants.MinPolicyNameLength || 
                policyName.Length > PolicyConstants.MaxPolicyNameLength)
            {
                throw new ArgumentException(string.Format(
                                   "PolicyName length exception - should be within {0} and {1}",
                                    PolicyConstants.MinPolicyNameLength,
                                    PolicyConstants.MaxPolicyNameLength));                
            }

            if (!rgx.IsMatch(policyName))
            {
                var exception = new ArgumentException(
                    "The protection policy name should contain alphanumeric characters " +
                    "and cannot start with a number");
                throw exception;
            }
        }

        public static ProtectionPolicyResponse GetProtectionPolicyByName(string policyName,
                                                 HydraAdapter.HydraAdapter hydraAdapter,
                                                 string resourceGroupName,
                                                 string resourceName)
        {
            ProtectionPolicyResponse response = null;

            try
            {
                response = hydraAdapter.GetProtectionPolicy(resourceGroupName, resourceName, policyName);
            }
            catch
            {
                // if http response is NotFound - then ignore
                // else rethrow the exception - TBD
            }

            return response;
        }
    }
}
