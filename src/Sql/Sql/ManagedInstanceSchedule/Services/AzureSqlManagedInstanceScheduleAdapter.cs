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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Model;
using System.Linq;


namespace Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Services
{
    public class AzureSqlManagedInstanceScheduleAdapter
    {
        private AzureSqlManagedInstanceScheduleCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }


        public AzureSqlManagedInstanceScheduleAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlManagedInstanceScheduleCommunicator(context);
        }

        public IList<AzureSqlManagedInstanceScheduleModel> ListSchedule(string resourceGroupName, string managedInstanceName)
        {
            return Communicator.ListSchedule(resourceGroupName, managedInstanceName)
                .Select(sdkSchedule => new AzureSqlManagedInstanceScheduleModel(sdkSchedule))
                .ToList();
        }

        public AzureSqlManagedInstanceScheduleModel CreateOrUpdateSchedule(string resourceGroupName,
                                                                           string managedInstanceName,
                                                                           string timezone,
                                                                           string description,
                                                                           ScheduleItem[] ScheduleList)
        {
            var response = Communicator.SetSchedule(resourceGroupName, managedInstanceName, new AzureSqlManagedInstanceScheduleModel()
            {
                Description = description,
                TimeZoneId = timezone,
                ScheduleList = ScheduleList
            });

            return new AzureSqlManagedInstanceScheduleModel(response);
        }

        public void RemoveSchedule(string resourceGroupName, string managedInstanceName)
        {
            Communicator.RemoveSchedule(resourceGroupName, managedInstanceName);
        }

    }
}
