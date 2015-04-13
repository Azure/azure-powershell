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
using System.Management.Automation;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// this commandlet returns all resources available in your subscription
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleResource"), OutputType(typeof(IEnumerable<ResourceCredentials>), typeof(ResourceCredentials))]
    public class GetAzureStorSimpleResource : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = false, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        //suppress resource check for this commandlet
        public GetAzureStorSimpleResource() : base(false) { }

        public override void ExecuteCmdlet()
        {
            try
            {              
                var serviceList = StorSimpleClient.GetAllResources().Cast<ResourceCredentials>().ToList();
                if(serviceList == null 
                    || serviceList.Count() == 0)
                {
                    //This is not an error scenario. Hence writing verbose is fine
                    WriteVerbose(Resources.NoResourceFoundInSubscriptionMessage);
                    WriteObject(null);
                    return;
                }

                if(ParameterSetName == StorSimpleCmdletParameterSet.IdentifyByName)
                {
                    serviceList = serviceList.Where(x => x.ResourceName.Equals(ResourceName, System.StringComparison.InvariantCultureIgnoreCase)).Cast<ResourceCredentials>().ToList();
                    if (serviceList.Count() == 0)
                    {
                        throw new ArgumentException(string.Format(Resources.NoResourceFoundWithGivenNameInSubscriptionMessage, ResourceName));
                    }
                }
                this.WriteObject(serviceList, true);
                WriteVerbose(string.Format(Resources.ResourceGet_StatusMessage, serviceList.Count(),(serviceList.Count() > 1 ? "s" : string.Empty)));
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
