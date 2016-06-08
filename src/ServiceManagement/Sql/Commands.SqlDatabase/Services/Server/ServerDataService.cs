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
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server
{
    /// <summary>
    /// Common abstract class for the generated <see cref="ServerContextInternal"/> class.
    /// </summary>
    public abstract class ServerDataServiceContext : ServerContextInternal
    {
        #region Constants

        /// <summary>
        /// The default dataservicecontext request timeout.
        /// </summary>
        private const int DefaultDataServiceContextTimeoutInSeconds = 180;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerDataServiceContext"/> class.
        /// </summary>
        /// <param name="serviceUri">The service's base <see cref="Uri"/>.</param>
        protected ServerDataServiceContext(Uri serviceUri)
            : base(serviceUri)
        {

#pragma warning disable 618
            // SendingRequest has been deprecated in favor of SendingRequest2, but SendingRequest2 does not
            // currently expose functionality we depend on, such as the ability to set UserAgent.
            this.SendingRequest += new EventHandler<SendingRequestEventArgs>(this.BeforeSendingRequest);
#pragma warning restore 618

            // Set the default timeout for the context.
            this.Timeout = DefaultDataServiceContextTimeoutInSeconds;

            // Allow this client model to talk to newer versions of server model
            this.IgnoreMissingProperties = true;
        }

        /// <summary>
        /// Handler to add additional headers and properties to the request.
        /// </summary>
        /// <param name="request">The request to enhance.</param>
        protected virtual void OnEnhanceRequest(HttpWebRequest request)
        {
        }

        #region Entity Refresh/Revert Helpers

        /// <summary>
        /// Refresh the object by requerying for the object and merge changes.
        /// </summary>
        /// <param name="database">The object to refresh.</param>
        /// <returns>The object with refreshed properties from the server.</returns>
        protected Database RefreshEntity(Database database)
        {
            MergeOption tempOption = this.MergeOption;
            this.MergeOption = MergeOption.OverwriteChanges;
            this.Databases.Where(s => s.Id == database.Id).SingleOrDefault();
            this.MergeOption = tempOption;

            return database;
        }

        /// <summary>
        /// Revert the changes made to the given object, detach it from the context.
        /// </summary>
        /// <param name="database">The object that is being operated on.</param>
        protected void RevertChanges(Database database)
        {
            // Revert the object by requerying for the object and clean up tracking
            if (database != null)
            {
                this.RefreshEntity(database);
            }

            this.ClearTrackedEntity(database);
        }

        /// <summary>
        /// Refresh the object by requerying for the object and merge changes.
        /// </summary>
        /// <param name="databaseCopy">The object to refresh.</param>
        /// <returns>The object with refreshed properties from the server.</returns>
        protected DatabaseCopy RefreshEntity(DatabaseCopy databaseCopy)
        {
            MergeOption tempOption = this.MergeOption;
            this.MergeOption = MergeOption.OverwriteChanges;
            databaseCopy = this.DatabaseCopies
                .Where(copy => copy.SourceServerName == databaseCopy.SourceServerName)
                .Where(copy => copy.SourceDatabaseName == databaseCopy.SourceDatabaseName)
                .Where(copy => copy.DestinationServerName == databaseCopy.DestinationServerName)
                .Where(copy => copy.DestinationDatabaseName == databaseCopy.DestinationDatabaseName)
                .SingleOrDefault();
            this.MergeOption = tempOption;

            return databaseCopy;
        }

        /// <summary>
        /// Revert the changes made to the given object, detach it from the context.
        /// </summary>
        /// <param name="databaseCopy">The object that is being operated on.</param>
        protected void RevertChanges(DatabaseCopy databaseCopy)
        {
            // Revert the object by requerying for the object and clean up tracking
            if (databaseCopy != null)
            {
                this.RefreshEntity(databaseCopy);
            }

            this.ClearTrackedEntity(databaseCopy);
        }

        #endregion

        /// <summary>
        /// Handler that appends the token to every data access context request.
        /// </summary>
        /// <param name="sender">The issuer of the request.</param>
        /// <param name="e">Additional info for the request.</param>
        private void BeforeSendingRequest(object sender, SendingRequestEventArgs e)
        {
            HttpWebRequest request = e.Request as HttpWebRequest;

            if (request != null)
            {
                this.OnEnhanceRequest(request);
            }
        }
    }
}
