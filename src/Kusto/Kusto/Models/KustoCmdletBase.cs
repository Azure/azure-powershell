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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Kusto.Properties;

namespace Microsoft.Azure.Commands.Kusto.Models
{
    /// <summary>
    /// The base class for all Microsoft Azure Kusto Management cmdlets
    /// </summary>
    public abstract class KustoCmdletBase : AzureRMCmdlet
    {
        private KustoClient kustoClient;

        public KustoClient KustoClient
        {
            get
            {
                if (kustoClient == null)
                {
                    kustoClient = new KustoClient(DefaultProfile.DefaultContext);
                }
                return kustoClient;
            }

            set { kustoClient = value; }
        }

        protected void EnsureResourceGroupSpecified(string resourceGroupName, string resourceGroupParameterName = "ResourceGroupName")
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                WriteExceptionError(new PSArgumentNullException(resourceGroupParameterName, Microsoft.Azure.Commands.Kusto.Properties.Resources.ResourceGroupNotSpecified));
            }
        }
        protected void EnsureClusterAndResourceGroupSpecified(string resourceGroupName, string clusterName, string clusterParameterName = "Name")
        {
            EnsureResourceGroupSpecified(resourceGroupName);

            EnsureClusterSpecified(clusterName, clusterParameterName);
        }

        protected void EnsureDatabaseClusterResourceGroupSpecified(string resourceGroupName, string clusterName,string databaseName , string databaseParameterName = "Name")
        {
            EnsureClusterAndResourceGroupSpecified(resourceGroupName, clusterName, "ClusterName");

            if (string.IsNullOrEmpty(databaseParameterName))
            {
                WriteExceptionError(new PSArgumentNullException(databaseParameterName, Microsoft.Azure.Commands.Kusto.Properties.Resources.DatabaseNameNotSpecified));
            }
        }
        protected void EnsureClusterSpecified(string clusterName, string clusterParameterName = "Name")
        {
            if (string.IsNullOrEmpty(clusterName))
            {
                WriteExceptionError(new PSArgumentNullException(clusterParameterName, Microsoft.Azure.Commands.Kusto.Properties.Resources.ClusterNameNotSpecified));
            }
        }

        protected void EnsureLocationSpecified(string location, string locationParameterName = "Location")
        {
            if (string.IsNullOrEmpty(location))
            {
                WriteExceptionError(new PSArgumentNullException(locationParameterName, Microsoft.Azure.Commands.Kusto.Properties.Resources.DatabaseNameNotSpecified));
            }
        }

        /***
         *  if (string.IsNullOrEmpty(location))
            {
                throw new CloudException(string.Format(Resources.KustoClusterExists, Name));
            }
            if (string.IsNullOrEmpty(clusterName))
            {
                throw new CloudException(string.Format(Resources.KustoClusterExists, Name));
            }
         */

        internal static TClient CreateAsClient<TClient>(IAzureContext context, string endpoint, bool parameterizedBaseUri = false) where TClient : Rest.ServiceClient<TClient>
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.NoSubscriptionInContext);
            }

            TClient client = AzureSession.Instance.ClientFactory.CreateArmClient<TClient>(context, endpoint);
            return client;
        }
    }
}