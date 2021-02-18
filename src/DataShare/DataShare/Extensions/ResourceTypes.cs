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

namespace Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions
{
    public static class ResourceTypes
    {
        public const string Account = "Microsoft.DataShare/accounts";
        public const string Share = "Microsoft.DataShare/shares";
        public const string Invitation = "Microsoft.DataShare/invitations";
        public const string DataSet = "Microsoft.DataShare/datasets";
        public const string DataSetMapping = "Microsoft.DataShare/datasetmappings";
        public const string ShareSubscription = "Microsoft.DataShare/sharesubscriptions";
        public const string SynchronizationSetting = "Microsoft.DataShare/synchronizationSettings";
        public const string Trigger = "Microsoft.DataShare/triggers";
        public const string StorageAccount = "Microsoft.Storage/storageAccounts";
    }
}
