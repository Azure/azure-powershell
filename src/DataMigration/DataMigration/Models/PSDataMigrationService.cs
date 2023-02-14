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

using System;
using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Models
{
    public class PSDataMigrationService
    {
        private DataMigrationService service;
        private DmsResourceIdentifier ids;

        public PSDataMigrationService(DataMigrationService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service");
            }

            this.service = service;
            this.ids = new DmsResourceIdentifier(service.Id);
            this.ResourceGroupName = ids.ResourceGroupName;
        }

        public DataMigrationService Service => service;

        public string ResourceGroupName { get; private set; }

        public string Name
        {
            get
            {
                return Service.Name;
            }
        }

        public string Location
        {
            get
            {
                return Service.Location;
            }
        }
    }
}
