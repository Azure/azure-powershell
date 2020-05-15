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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    public class TemplateSpecCmdletBase : AzureRMCmdlet
    {
        private TemplateSpecsSdkClient templateSpecsSdkClient;

        /// <summary>
        /// Gets or sets the Template Specs Azure sdk client wrapper
        /// </summary>
        public TemplateSpecsSdkClient TemplateSpecsSdkClient
        {
            get
            {
                if (this.templateSpecsSdkClient == null)
                {
                    this.templateSpecsSdkClient = new TemplateSpecsSdkClient(DefaultContext);
                }

                return this.templateSpecsSdkClient;
            }

            set { this.templateSpecsSdkClient = value; }
        }

        /// <summary>
        /// Override method to extract inner errors.
        /// </summary>
        /// <param name="ex">exception</param>
        protected override void WriteExceptionError(Exception ex)
        {
            var aggEx = ex as AggregateException;

            if (aggEx != null && aggEx.InnerExceptions != null)
            {
                foreach (var e in aggEx.Flatten().InnerExceptions)
                {
                    WriteExceptionError(e);
                }

                return;
            }

            base.WriteExceptionError(ex);
        }
    }
}
