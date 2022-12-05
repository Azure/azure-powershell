using Microsoft.Azure.Management.CosmosDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB
{
    public class PSMongoPrivilege
    {
        public PSMongoPrivilege()
        {

        }

        public PSMongoPrivilege(Privilege privilege)
        {
            Resource = new PSMongoPrivilegeResource(privilege.Resource);
            Actions = privilege.Actions;
        }

        /// <summary>
        /// Gets or sets Resources(DB and Collection names) for the Cosmos DB MongoDB Role Definition Privilege
        /// </summary>
        public PSMongoPrivilegeResource Resource { get; set; }

        /// <summary>
        /// Gets or sets Actions(insert/update etc) for the Cosmos DB MongoDB Role Definition Privilege
        /// </summary>
        public IList<string> Actions { get; set; }

        public static Privilege ToSDKModel(PSMongoPrivilege pSMongoPrivileges)
        {
            Privilege privilege = new Privilege(PSMongoPrivilegeResource.ToSDKModel(pSMongoPrivileges.Resource), pSMongoPrivileges.Actions);

            return privilege;
        }
    }
}
