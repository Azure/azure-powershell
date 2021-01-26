using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Model
{
    public class AzureSqlServerTrustGroupModel
    {
        /// <summary>
        /// Gets or sets the name of the primary location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the Instance Failover Group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Server Trust Group members.
        /// </summary>
        public IList<string> GroupMembers { get; set; }

        /// <summary>
        /// Gets or sets Server Trust Group trust scope.
        /// </summary>
        public IList<string> TrustScope { get; set; }
    }
}
