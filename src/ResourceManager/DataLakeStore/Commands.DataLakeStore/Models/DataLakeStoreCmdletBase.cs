﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// The base class for all Microsoft Azure DataLakeStore Management cmdlets
    /// </summary>
    public abstract class DataLakeStoreCmdletBase : AzureRMCmdlet
    {
        private DataLakeStoreClient dataLakeClient;

        public DataLakeStoreClient DataLakeStoreClient
        {
            get
            {
                if (dataLakeClient == null)
                {
                    dataLakeClient = new DataLakeStoreClient(DefaultProfile.Context);
                }
                return dataLakeClient;
            }

            set { dataLakeClient = value; }
        }
    }
}