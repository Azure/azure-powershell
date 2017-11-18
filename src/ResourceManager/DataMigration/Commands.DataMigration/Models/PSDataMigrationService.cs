// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSDataMigrationService.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Management.DataMigration.Models;
using System;

namespace Microsoft.Azure.Commands.DataMigration.Models
{
    public class PSDataMigrationService
    {
        private DataMigrationService service;
        private DmsResourceIdentifier ids;

        public PSDataMigrationService(DataMigrationService service)
        {
            this.service = service ?? throw new ArgumentNullException("service");
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
