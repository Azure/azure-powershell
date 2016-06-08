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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.MediaServices
{
    public class AzureMediaServicesHttpClientCommandBase : AzureSMCmdlet
    {
        protected virtual void OnProcessRecord()
        {
            // Intentionally left blank
        }
        protected override void ProcessRecord()
        {
            try
            {
                Validate.ValidateInternetConnection();
                ExecuteCmdlet();
                OnProcessRecord();
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
        protected static void CatchAggregatedExceptionFlattenAndRethrow(Action c)
        {
            try
            {
                c();
            }
            catch (AggregateException ex)
            {
                var flat = ex.Flatten();
                if (flat.InnerExceptions.Count == 1)
                {
                    throw flat.InnerException;
                }
                else
                {
                    throw flat;
                }
            }
        }
    }
}