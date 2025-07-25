using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Sql;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Services
{
	/// <summary>
	/// This class is responsible for all the REST communication with the audit REST endpoints
	/// </summary>
	class AzureSqlServerTrustGroupCommunicator
	{
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static Management.Sql.SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Server Trust Group
        /// </summary>
        public AzureSqlServerTrustGroupCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Server Trust Group
        /// </summary>
        public Management.Sql.Models.ServerTrustGroup Get(string resourceGroupName, string locationName, string serverTrustGroupName)
        {
            return GetCurrentSqlClient().ServerTrustGroups.Get(resourceGroupName, locationName, serverTrustGroupName);
        }

        /// <summary>
        /// Creates the Azure Sql Server Trust Group
        /// </summary>
        public Management.Sql.Models.ServerTrustGroup Create(string resourceGroupName, string locationName, string serverTrustGroupName, Management.Sql.Models.ServerTrustGroup parameters)
        {
            return GetCurrentSqlClient().ServerTrustGroups.CreateOrUpdate(resourceGroupName, locationName, serverTrustGroupName, parameters);
        }

        /// <summary>
        /// Deletes the Azure Sql Server Trust Group
        /// </summary>
        public void Delete(string resourceGroupName, string locationName, string serverTrustGroupName)
        {
            GetCurrentSqlClient().ServerTrustGroups.Delete(resourceGroupName, locationName, serverTrustGroupName);
        }

        /// <summary>
        /// Gets the Azure Sql Server Trust Groups by Instance
        /// </summary>
        public IPage<Management.Sql.Models.ServerTrustGroup> ListGroupsByInstance(string resourceGroupName, string managedInstanceName)
        {
            return GetCurrentSqlClient().ServerTrustGroups.ListByInstance(resourceGroupName, managedInstanceName);
        }

        /// <summary>
        /// Gets the Azure Sql Server Trust Groups by Location
        /// </summary>
        public IPage<Management.Sql.Models.ServerTrustGroup> ListGroupsByLocation(string resourceGroupName, string location)
        {
            return GetCurrentSqlClient().ServerTrustGroups.ListByLocation(resourceGroupName, location);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }

    }
}
