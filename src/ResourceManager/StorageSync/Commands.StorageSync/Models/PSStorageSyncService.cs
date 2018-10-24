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

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StorageSync.Models
{
    public class PSStorageSyncService : PSResourceBase
    {
        [Ps1Xml(Label = "Location", Target = ViewControl.Table, Position = 4)]
        public string Location { get; set; }

        [Ps1Xml(Label = "StorageSyncServiceName ", Target = ViewControl.Table, Position = 5)]
        public string StorageSyncServiceName { get; set; }

        public IDictionary<string, string> Tags { get; set; }

    }
}
