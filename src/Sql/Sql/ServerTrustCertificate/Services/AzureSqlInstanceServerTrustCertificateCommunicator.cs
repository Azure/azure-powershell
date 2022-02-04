using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlInstanceServerTrustCertificateCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Instance Server Trust Certificate
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
        public AzureSqlInstanceServerTrustCertificateCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Creates or updates a Managed instance
        /// </summary>
        public Management.Sql.Models.ServerTrustCertificate CreateOrUpdate(string resourceGroupName, string managedInstanceName, string certificateName, Management.Sql.Models.ServerTrustCertificate parameters)
        {
            return GetCurrentSqlClient().ServerTrustCertificates.CreateOrUpdate(resourceGroupName, managedInstanceName, certificateName, parameters);
        }
        /// <summary>
        /// Gets the Managed instance
        /// </summary>
        public Management.Sql.Models.ServerTrustCertificate Get(string resourceGroupName, string managedInstanceName, string certificateName)
        {
            return GetCurrentSqlClient().ServerTrustCertificates.Get(resourceGroupName, managedInstanceName, certificateName);
        }

        /// <summary>
        /// Lists Managed instances
        /// </summary>
        public IList<Management.Sql.Models.ServerTrustCertificate> List(string resourceGroupName, string managedInstanceName)
        {
            return GetCurrentSqlClient().ServerTrustCertificates.ListByInstance(resourceGroupName, managedInstanceName).ToList();
        }

        /// <summary>
        /// Deletes a user certificate from MI
        /// </summary>
        public void Remove(string resourceGroupName, string managedInstanceName, string certificateName)
        {
            GetCurrentSqlClient().ServerTrustCertificates.Delete(resourceGroupName, managedInstanceName, certificateName);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }
    }
}
