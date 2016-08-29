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

using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    public class AzureHDInsightRuntimeScriptActionOperationResource : AzureHDInsightRuntimeScriptAction
    {
        public AzureHDInsightRuntimeScriptActionOperationResource(RuntimeScriptAction runtimeScriptAction, OperationResource operationResource)
            : base(runtimeScriptAction)
        {
            if (operationResource.ErrorInfo != null)
            {
                ErrorMessage = operationResource.ErrorInfo.Message;
            }

            OperationState = operationResource.State.ToString();
        }

        public string OperationState { get; set; }

        public string ErrorMessage { get; set; }
    }
}
