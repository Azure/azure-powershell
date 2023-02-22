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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ManagedInstanceDtc.Model;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceDtc.Services
{
    public class AzureSqlManagedInstanceDtcAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlManagedInstanceDtcCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public AzureSqlManagedInstanceDtcAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlManagedInstanceDtcCommunicator(Context);
        }

        public AzureSqlManagedInstanceDtcModel GetManagedInstanceDtc(string resourceGroup, string managedInstanceName)
        {
            var resp = Communicator.Get(resourceGroup, managedInstanceName);
            return CreateManagedInstanceDtcModelFromResponse(resourceGroup, managedInstanceName, resp);
        }

        public AzureSqlManagedInstanceDtcModel SetManagedInstanceDtc(string resourceGroup, string managedInstanceName, AzureSqlManagedInstanceDtcModel dtcModel )
        {
            Management.Sql.Models.ManagedInstanceDtc parameters = new Management.Sql.Models.ManagedInstanceDtc()
            {
                DtcEnabled = dtcModel.DtcEnabled,
                ExternalDnsSuffixSearchList = dtcModel.ExternalDnsSuffixSearchList,
                SecuritySettings = dtcModel.SecuritySettings,

            };

            var resp = Communicator.CreateOrUpdate(resourceGroup, managedInstanceName, parameters);
            return CreateManagedInstanceDtcModelFromResponse(resourceGroup, managedInstanceName, resp);
        }

        private AzureSqlManagedInstanceDtcModel CreateManagedInstanceDtcModelFromResponse(string resourceGroup, string managedInstanceName, Management.Sql.Models.ManagedInstanceDtc managedInstanceDtc)
        {
            AzureSqlManagedInstanceDtcModel managedInstanceDtcModel = new AzureSqlManagedInstanceDtcModel();
            managedInstanceDtcModel.ManagedInstanceName = managedInstanceName;
            managedInstanceDtcModel.Id = managedInstanceDtc.Id;
            managedInstanceDtcModel.ResourceGroupName= resourceGroup;
            managedInstanceDtcModel.DtcEnabled = managedInstanceDtc.DtcEnabled.GetValueOrDefault();

            // Due to a bug in the API, the dtcHostName is returned as the DtcHostNameDnsSuffix property. Also the DtcHostName doesn't exist as a property of the response currently.
            // The new API versions (with a fix) should return DtcHostName property and the correct value for DtcHostNameDnsSuffix.
            // Currently, as a workaround we check if the DtcHostName property exists on the response.
            // If it doesn't exist, we use the DtcHostNameDnsSuffix from the response as the DtcHostName. The model's DtcHostNameDnsSuffix (the actual suffix) needs to be
            // extracted from the response's DtcHostNameDnsSuffix.
            // If it exists, we just take those values from the API response directly.
            var managedInstanceDtcHostName = managedInstanceDtc.GetType().GetProperty("DtcHostName");
            if (managedInstanceDtcHostName == null)
            {
                managedInstanceDtcModel.DtcHostName = managedInstanceDtc.DtcHostNameDnsSuffix;
                managedInstanceDtcModel.DtcHostNameDnsSuffix = managedInstanceDtc.DtcHostNameDnsSuffix.Substring(managedInstanceDtc.DtcHostNameDnsSuffix.IndexOf('.') + 1);
            }
            else
            {
                // After the new version of API gets released, next line should be changed to:
                // managedInstanceDtcModel.DtcHostName = managedInstanceDtc.DtcHostName
                managedInstanceDtcModel.DtcHostName = (string)managedInstanceDtcHostName.GetValue(managedInstanceDtc);
                managedInstanceDtcModel.DtcHostNameDnsSuffix = managedInstanceDtc.DtcHostNameDnsSuffix;
            }
            managedInstanceDtcModel.ExternalDnsSuffixSearchList = managedInstanceDtc.ExternalDnsSuffixSearchList.ToList<string>();
            managedInstanceDtcModel.SecuritySettings = managedInstanceDtc.SecuritySettings;

            return managedInstanceDtcModel;
        }
    }
}
