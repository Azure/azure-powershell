using Microsoft.Azure.Management.CosmosDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB
{
    public class PSMongoPrivilegeResource
    {
        public PSMongoPrivilegeResource()
        {
        }

        public  PSMongoPrivilegeResource(PrivilegeResource privilegeResource)
        {
            Db = privilegeResource.Db;
            Collection = privilegeResource.Collection;
        }

        /// <summary>
        /// Gets or sets Database name of the Cosmos DB MongoDB Role Definition Privilege
        /// </summary>
        public string Db { get; set; }

        /// <summary>
        /// Gets or sets Collection Name of the Cosmos DB MongoDB Role Definition
        /// </summary>
        public string Collection { get; set; }

        public static PrivilegeResource ToSDKModel(PSMongoPrivilegeResource pSMongoResource)
        {
            PrivilegeResource privilegeResource = new PrivilegeResource(pSMongoResource.Db, pSMongoResource.Collection);

            return privilegeResource;
        }
    }
}
