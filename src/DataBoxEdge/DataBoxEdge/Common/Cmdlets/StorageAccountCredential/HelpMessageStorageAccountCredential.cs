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


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.StorageAccountCredential
{
    internal class HelpMessageStorageAccountCredential
    {
        internal const string StorageAccountNameHelpMessage = "Name of the storage account to be used";
        internal const string ObjectName = "StorageAccountCredential";
        internal const string StorageAccountTypeHelpMessage = "Possible Storage Access type are GeneralPurposeStorage, BlockStorage";

        internal const string StorageAccountAccessKeyHelpMessage = "provide storage account access key";

        /*"To enable/ disable ssl status message, possible values are Enabled/Disabled";*/
        internal const string SslStatus = "Enabled";
    }
}