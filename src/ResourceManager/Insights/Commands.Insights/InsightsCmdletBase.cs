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

using Microsoft.Azure.Commands.ResourceManager.Common;
using System;

namespace Microsoft.Azure.Commands.Insights
{
    /// <summary>
    /// Base class for the Azure Insights SDK Cmdlets
    /// </summary>
    public abstract class InsightsCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// Executes the Cmdlet. This is a callback function to simplify the exception handling
        /// </summary>
        protected abstract void ProcessRecordInternal();

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.ProcessRecordInternal();
            }
            catch (AggregateException ex)
            {
                throw ex.Flatten().InnerException;
            }
        }
    }
}
