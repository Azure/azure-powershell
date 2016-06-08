﻿﻿// ----------------------------------------------------------------------------------  
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
namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects
{
    /// <summary>  
    ///     Represents an AzureHDInsightConfigAction.  
    /// </summary>  
    public abstract class AzureHDInsightConfigAction
    {
        /// <summary>  
        ///     Gets or sets the name of the config action.  
        /// </summary>  
        public string Name { get; set; }

        /// <summary>  
        ///     Gets or sets the affected nodes of the config action.  
        /// </summary>  
        public ClusterNodeType[] ClusterRoleCollection { get; set; }

        /// <summary>  
        ///     Convert this config action to SDK recognizable.  
        /// </summary>  
        public abstract ConfigAction ToSDKConfigAction();
    }
}