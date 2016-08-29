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
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    public class AzureHDInsightRuntimeScriptAction
    {
        public AzureHDInsightRuntimeScriptAction(RuntimeScriptAction runtimeScriptAction)
        {
            Name = runtimeScriptAction.Name;
            Uri = runtimeScriptAction.Uri;
            Parameters = runtimeScriptAction.Parameters;
            NodeTypes = runtimeScriptAction.Roles.ToArray();
            ApplicationName = runtimeScriptAction.ApplicationName;
        }

        public string Name { get; set; }

        public Uri Uri { get; set; }

        public string Parameters { get; set; }

        public string[] NodeTypes { get; set; }

        public string ApplicationName { get; set; }
    }
}
