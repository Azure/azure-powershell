using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Model
{
    public class AzureSqlServerTrustGroupModel
    {
        /// <summary>
        /// Gets or sets the Id of the Server Trust Group.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the Server Trust Group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Server Trust Group members.
        /// </summary>
        public IList<string> GroupMember { get; set; }

        /// <summary>
        /// Gets or sets Server Trust Group trust scope.
        /// </summary>
        public IList<string> TrustScope { get; set; }
    }
}
