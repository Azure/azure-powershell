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

using System.Collections.Generic;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class StorSimpleClient
    {
        public TaskStatusInfo ConfigureService(ServiceConfiguration serviceConfig)
        {
            return GetStorSimpleClient().ServiceConfig.Create(serviceConfig, GetCustomRequestHeaders());
        }

        public TaskResponse ConfigureServiceAsync(ServiceConfiguration serviceConfig)
        {
            return GetStorSimpleClient().ServiceConfig.BeginCreating(serviceConfig, GetCustomRequestHeaders());
        }

        public IList<AccessControlRecord> GetAllAccessControlRecords()
        {
            var sc = GetStorSimpleClient().ServiceConfig.Get(GetCustomRequestHeaders());
            if (sc == null || sc.AcrChangeList == null)
            {
                return null;
            }
            return sc.AcrChangeList.Updated;
        }

        public IList<StorageAccountCredentialResponse> GetAllStorageAccountCredentials()
        {
            var sc = GetStorSimpleClient().ServiceConfig.Get(GetCustomRequestHeaders());
            if (sc == null || sc.CredentialChangeList == null)
            {
                return null;
            }
            return sc.CredentialChangeList.Updated;
        }
    }
}
