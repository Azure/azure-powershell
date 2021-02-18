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


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.EdgeStorageContainers
{
    internal class HelpMessageEdgeStorageContainer
    {
        internal const string ObjectName = "EdgeStrorageContainer";
        internal const string EdgeStorageAccountHelpMessage = "Provide existing EdgeStorageAccount's Name";
        internal const string EdgeStorageAccountObjectHelpMessage = "Provide existing EdgeStorageAccount Object";

        internal const string NameHelpMessage = "Name of the EdgeStorageContainer";
        internal const string DataFormatHelpMessage = "Set Data Format ex: PageBlob, BlobBlob";
        internal const string RefreshDataHelpMessage = "Refresh Container Metadata with the data from the cloud";

        //Aliases
        internal const string EdgeStorageAccountAlias = "EdgeStorageAccount";
        internal const string EdgeStorageContainerAlias = "EdgeStorageContainer";
        internal const string EdgeStorageContainerNameAlias = "EdgeContainerName";
    }
}