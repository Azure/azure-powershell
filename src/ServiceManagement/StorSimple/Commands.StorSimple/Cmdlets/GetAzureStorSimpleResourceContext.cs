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

using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using System;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// This commandlet will return the currently selected resource. If no resource is selected will throw a ResourceContextNotFoundException
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleResourceContext"),OutputType(typeof(StorSimpleResourceContext))]
    public class GetAzureStorSimpleResourceContext : StorSimpleCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            try
            {
                var currentContext = StorSimpleClient.GetResourceContext();
                this.WriteObject(currentContext);
                this.WriteVerbose(string.Format(Resources.ResourceContextFound,currentContext.ResourceName, currentContext.ResourceId));
            }

            catch(Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
