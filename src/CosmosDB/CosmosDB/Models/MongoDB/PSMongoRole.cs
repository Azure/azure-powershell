using Microsoft.Azure.Management.CosmosDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB
{
    public class PSMongoRole
    {
        public PSMongoRole()
        {
        }

        public PSMongoRole(Role role)
        {
            Db = role.Db;
            Role = role.RoleProperty;
        }

        /// <summary>
        /// Gets or sets Database name of the Cosmos DB MongoDB Role Definition Inherited Role
        /// </summary>
        public string Db { get; set; }

        /// <summary>
        /// Gets or sets Inherited Role Name(From previously created role) of the Cosmos DB MongoDB Role Definition Role
        /// </summary>
        public string Role { get; set; }

        public static Role ToSDKModel(PSMongoRole pSMongoRole)
        {
            Role role = new Role(pSMongoRole.Db, pSMongoRole.Role);

            return role;
        }
    }
}
