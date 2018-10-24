// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpHeaderConstants.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <summary>
//   Defines the HeaderConstants type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    /// <summary>
    /// The Http header constants.
    /// </summary>
    public class HttpHeaderConstants
    {
        public const string ReplicaId = "x-ms-replica-id";

        /// <summary>
        /// The date that the request was processed, in RFC 1123 format.
        /// </summary>
        public const string ProcessedDate = "Date";

        /// <summary>
        /// Set to application/json. This header is not required in responses that don’t have any content.
        /// </summary>
        public const string ContentType = "Content-Type";

        /// <summary>
        /// A unique identifier for the tracing correlation Id for the request.
        /// </summary>
        public const string CorrelationRequestId = "x-ms-correlation-request-id";

        /// <summary>
        /// Arm header x-ms-request-id, value is a guid
        /// </summary>
        public const string HttpHeaderRequestId = "x-ms-request-id";

        /// <summary>
        /// The http header authorization. Value is a key/certificate/token.
        /// </summary>
        public const string HttpHeaderAuthorization = "Authorization";

        /// <summary>
        /// The http header partnership id. Opaque value defining sync relationship.
        /// </summary>
        public const string HttpHeaderPartnershipId = "x-ms-partnership-id";

        /// <summary>
        /// The http header correlation id. Used to correlate requests across service boundaries.
        /// </summary>
        public const string HttpHeaderCorrelationId = "x-ms-client-correlation-id";

        /// <summary>
        /// The http header used to identify the partition where resource is located within CosmosDB
        /// </summary>
        public const string ResourceLocation = "x-ms-resource-location";

        /// <summary>
        /// The http header used to identify the partition where resource is located within CosmosDB using kind
        /// </summary>
        public const string ResourceLocationKind = "x-ms-resource-location-kind";

        /// <summary>
        /// The http header used to identify the partition where resource is located within CosmosDB using port
        /// </summary>
        public const string ResourceLocationPort = "x-ms-resource-location-port";

        /// <summary>
        /// The http header client request id. Used to correlate requests to ARM.
        /// </summary>
        public const string HttpHeaderClientRequestId = "x-ms-client-request-id";

        /// <summary>
        /// The http header effective user id.
        /// </summary>
        public const string HttpHeaderEffectiveUserId = "x-ms-effective-user-id";

        /// <summary>
        /// The http header ETag. It is sent as http response header.
        /// </summary>
        public const string HttpHeaderEtag = "ETag";

        /// <summary>
        /// The http header request error. It is sent in a response in case of an error.
        /// </summary>
        public const string HttpHeaderError = "x-ms-request-error";

        /// <summary>
        /// The originating protocol and port number of an HTTP request
        /// </summary>
        public const string ForwardedProto = "X-Forwarded-Proto";

        /// <summary>
        /// The originating host name of an HTTP request
        /// </summary>
        public const string ForwardedHost = "X-Forwarded-Host";

        /// <summary>
        /// The originating port number of an HTTP request
        /// </summary>
        public const string ForwardedPort = "X-Forwarded-Port";

        /// <summary>
        /// The version of the current on-premises server configuration. The service should return 412 if the configuration versions do not match.
        /// </summary>
        public const string IfMatch = "If-Match";

        /// <summary>
        /// Set to the full URI that the client connected to (which will be different than the RP URI, since it will have the public hostname instead of the RP hostname).
        /// This value can be used in generating FQDN for Location headers or other requests since RPs should not reference their endpoint name
        /// </summary>
        public const string Referer = "referer";

        /// <summary>
        /// Header used for Kailani test overrides
        /// </summary>
        public const string TestOverrides = "x-ms-test-overrides";

        /// <summary>
        /// Used to specify the client type for HFS mamagement requests
        /// </summary>
        public const string ClientType = "x-ms-client-type";

        /// <summary>
        /// Used to specify the client type for HFS mamagement requests
        /// </summary>
        public const string ClientName = "x-ms-client-name";

        /// <summary>
        /// Used to specify the client type for HFS mamagement requests
        /// </summary>
        public const string ClientVersion = "x-ms-client-version";

        /// <summary>
        /// Server uses this header to announce its supported scope for a job in the GET NextJob request.
        /// </summary>
        public const string ScopeId = "x-ms-scope-id";
       
        /// <summary>
        /// Server uses this header to announce its membership in a cluster with a provided clusterid.
        /// </summary>
        public const string ClusterId = "x-ms-cluster-id";

        /// <summary>
        /// HTTP header to indicate the uri location to check the result of an async operation.
        /// </summary>
        public const string Location = "x-ms-location";

        /// <summary>
        /// HTTP header to indicate the current subscription Id
        /// </summary>
        public const string SubscriptionId = "x-ms-subscription-id";

        /// <summary>
        /// HTTP header to indicate the current resource group name
        /// </summary>
        public const string ResourceGroupName = "x-ms-resourcegroup-name";

        /// <summary>
        /// HTTP header to indicate the current storage sync service name
        /// </summary>
        public const string StorageSyncServiceName = "x-ms-storagesyncservice-name";

        /// <summary>
        /// HTTP header to indicate the current storage sync service Universal Id Guid
        /// </summary>
        public const string StorageSyncServiceUid = "x-ms-storagesyncservice-uid";

        public const string AzureAsyncOperation = "Azure-AsyncOperation";

        public const string RetryAfter = "Retry-After";

        public const string IncludeStorageKey = "x-ms-include-sa-key";
    }
}
