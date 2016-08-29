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
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Hyak.Common;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{   
    /// <summary>
    /// Class hosting helper methods for policy related cmdlets.
    /// </summary>
    public class PolicyCmdletHelpers 
    {
        public static Regex policyNameRgx = new Regex(@"^[A-Za-z][-A-Za-z0-9]*[A-Za-z0-9]$");

        /// <summary>
        /// Validates name of the policy
        /// </summary>
        /// <param name="policyName">Name of the policy</param>
        public static void ValidateProtectionPolicyName(string policyName)
        {
            if(string.IsNullOrEmpty(policyName))
            {
                throw new ArgumentException(Resources.PolicyNameIsEmptyOrNull);
            }

            if (policyName.Length < PolicyConstants.MinPolicyNameLength || 
                policyName.Length > PolicyConstants.MaxPolicyNameLength)
            {
                throw new ArgumentException(Resources.ProtectionPolicyNameLengthException);
            }

            if (!policyNameRgx.IsMatch(policyName))
            {
                throw new ArgumentException(Resources.ProtectionPolicyNameException);
            }
        }

        /// <summary>
        /// Fetches policies by name
        /// </summary>
        /// <param name="policyName">Name of the policy to be fetched</param>
        /// <param name="serviceClientAdapter">Service client adapter with which to make calls</param>
        /// <returns></returns>
        public static ProtectionPolicyResponse GetProtectionPolicyByName(string policyName,
                                                 ServiceClientAdapter serviceClientAdapter)
        {
            ProtectionPolicyResponse response = null;

            try
            {                
                response = serviceClientAdapter.GetProtectionPolicy(policyName);
                Logger.Instance.WriteDebug("Successfully fetched policy from service: " + policyName);
            }
            catch (AggregateException exception)
            {
                // if http response is NotFound - then ignore and return NULL response
                if (exception.InnerException != null && exception.InnerException is CloudException)
                {
                    var cloudEx = exception.InnerException as CloudException;
                    if (cloudEx.Response != null)
                    {
                        if (cloudEx.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            Logger.Instance.WriteDebug("CloudException Response statusCode: " +
                                                        cloudEx.Response.StatusCode);
                            throw;
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
                else
                {
                    throw;
                }
            }

            return response;
        }
    }
}
