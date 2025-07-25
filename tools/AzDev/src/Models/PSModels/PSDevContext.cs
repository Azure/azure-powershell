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

namespace AzDev.Models.PSModels
{
    public class PSDevContext
    {
        public string AzurePowerShellRepositoryRoot { get; set; }
        public string AzurePowerShellCommonRepositoryRoot { get; set; }
        public string ContextPath { get; set; }

        public PSDevContext(DevContext context, string path)
        {
            AzurePowerShellRepositoryRoot = context.AzurePowerShellRepositoryRoot;
            AzurePowerShellCommonRepositoryRoot = context.AzurePowerShellCommonRepositoryRoot;
            ContextPath = path;
        }
    }
}
