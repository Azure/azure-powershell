using Microsoft.Azure.Commands.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.Azure.PowerShell.Cmdlets.CosmosDB
{
    public partial class CosmosClient : FluentServiceClientBase<CosmosClient>, ICosmosDB, IAzureClient
    {
        private Management.CosmosDB.Fluent.CosmosDB cosmosDB;

        /// <summary>
        /// Initializes a new instance of the CosmosClient class.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public CosmosClient(
            Uri baseUri,
            ServiceClientCredentials serviceClientCredentials,
            DelegatingHandler[] delegatingHandlers) : base(GetClient(baseUri, serviceClientCredentials, delegatingHandlers))
        {
            if (serviceClientCredentials == null)
            {
                throw new System.ArgumentNullException("serviceClientCredentials");
            }
            else if (serviceClientCredentials != null)
            {
                serviceClientCredentials.InitializeServiceClient(this);
            }
            cosmosDB = new Management.CosmosDB.Fluent.CosmosDB(_restClient);
        }

        /// <summary>
        /// Initializes a new instance of the CosmosClient class.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public CosmosClient(RestClient restClient) : base(restClient)
        {
        }
        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings {
            get
            {
                return cosmosDB.SerializationSettings;
            }
        }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings
        {
            get
            {
                return cosmosDB.DeserializationSettings;
            }
        }

        /// <summary>
        /// Azure subscription ID.
        /// </summary>
        public string SubscriptionId
        {
            get
            {
                return cosmosDB.SubscriptionId;
            }
            set
            {
                cosmosDB.SubscriptionId = value;
            }
        }

        /// <summary>
        /// Version of the API to be used with the client request. The current version
        /// is 2015-04-08.
        /// </summary>
        public string ApiVersion
        {
            get
            {
                return cosmosDB.ApiVersion;
            }
        }

        /// <summary>
        /// The preferred language for the response.
        /// </summary>
        public string AcceptLanguage
        {
            get
            {
                return cosmosDB.AcceptLanguage;
            }
            set
            {
                cosmosDB.AcceptLanguage = value;
            }
        }

        /// <summary>
        /// The retry timeout in seconds for Long Running Operations. Default value is
        /// 30.
        /// </summary>
        public int? LongRunningOperationRetryTimeout
        {
            get
            {
                return cosmosDB.LongRunningOperationRetryTimeout;
            }
            set
            {
                cosmosDB.LongRunningOperationRetryTimeout = value;
            }
        }

        /// <summary>
        /// Whether a unique x-ms-client-request-id should be generated. When set to
        /// true a unique x-ms-client-request-id value is generated and included in
        /// each request. Default is true.
        /// </summary>
        public bool? GenerateClientRequestId
        {
            get
            {
                return cosmosDB.GenerateClientRequestId;
            }
            set
            {
                cosmosDB.GenerateClientRequestId = value;
            }
        }

        /// <summary>
        /// Gets the IDatabaseAccountsOperations.
        /// </summary>
        public virtual IDatabaseAccountsOperations DatabaseAccounts
        {
            get
            {
                return cosmosDB.DatabaseAccounts;
            }
        }

        /// <summary>
        /// Gets the IOperations.
        /// </summary>
        public virtual IOperations Operations
        {
            get
            {
                return cosmosDB.Operations;
            }
        }

        /// <summary>
        /// Gets the IDatabaseOperations.
        /// </summary>
        public virtual IDatabaseOperations Database
        {
            get
            {
                return cosmosDB.Database;
            }
        }

        /// <summary>
        /// Gets the ICollectionOperations.
        /// </summary>
        public virtual ICollectionOperations Collection
        {
            get
            {
                return cosmosDB.Collection;
            }
        }

        /// <summary>
        /// Gets the ICollectionRegionOperations.
        /// </summary>
        public virtual ICollectionRegionOperations CollectionRegion
        {
            get
            {
                return cosmosDB.CollectionRegion;
            }
        }

        /// <summary>
        /// Gets the IDatabaseAccountRegionOperations.
        /// </summary>
        public virtual IDatabaseAccountRegionOperations DatabaseAccountRegion
        {
            get
            {
                return cosmosDB.DatabaseAccountRegion;
            }
        }

        /// <summary>
        /// Gets the IPercentileSourceTargetOperations.
        /// </summary>
        public virtual IPercentileSourceTargetOperations PercentileSourceTarget
        {
            get
            {
                return cosmosDB.PercentileSourceTarget;
            }
        }

        /// <summary>
        /// Gets the IPercentileTargetOperations.
        /// </summary>
        public virtual IPercentileTargetOperations PercentileTarget
        {
            get
            {
                return cosmosDB.PercentileTarget;
            }
        }

        /// <summary>
        /// Gets the IPercentileOperations.
        /// </summary>
        public virtual IPercentileOperations Percentile
        {
            get
            {
                return cosmosDB.Percentile;
            }
        }

        /// <summary>
        /// Gets the ICollectionPartitionRegionOperations.
        /// </summary>
        public virtual ICollectionPartitionRegionOperations CollectionPartitionRegion
        {
            get
            {
                return cosmosDB.CollectionPartitionRegion;
            }
        }

        /// <summary>
        /// Gets the ICollectionPartitionOperations.
        /// </summary>
        public virtual ICollectionPartitionOperations CollectionPartition
        {
            get
            {
                return cosmosDB.CollectionPartition;
            }
        }

        /// <summary>
        /// Gets the IPartitionKeyRangeIdOperations.
        /// </summary>
        public virtual IPartitionKeyRangeIdOperations PartitionKeyRangeId
        {
            get
            {
                return cosmosDB.PartitionKeyRangeId;
            }
        }

        /// <summary>
        /// Gets the IPartitionKeyRangeIdRegionOperations.
        /// </summary>
        public virtual IPartitionKeyRangeIdRegionOperations PartitionKeyRangeIdRegion
        {
            get
            {
                return cosmosDB.PartitionKeyRangeIdRegion;
            }
        }

        public new virtual Uri BaseUri
        {
            get
            {
                return cosmosDB.BaseUri;
            }
            set
            {
                cosmosDB.BaseUri = value;
            }
        }

        public new virtual ServiceClientCredentials Credentials { get; private set; }

        private static RestClient GetClient(Uri baseUri, ServiceClientCredentials serviceClientCredentials, DelegatingHandler[] delegatingHandlers)
        {
            return RestClient.Configure()
                .WithBaseUri(baseUri.ToString())
                .WithDelegatingHandlers(delegatingHandlers)
                .WithCredentials(new AzureCredentials(serviceClientCredentials, serviceClientCredentials, "", AzureEnvironment.AzureGlobalCloud))
                .Build();
        }

        protected override void Initialize()
        {
        }
    }
}
