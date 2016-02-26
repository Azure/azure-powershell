////////////////////////////////////////////////////////////////////////////////
//
// Copyright (C) Microsoft Corporation. All rights reserved.
//
////////////////////////////////////////////////////////////////////////////////

namespace Microsoft.Azure.Cdn.Services.ResourceProvider.Models.EndpointModels
{
    /// <summary>
    /// This is the settings on query string caching. There are three values allowed here.
    /// </summary>
    public enum QueryStringCachingBehavior
    {
        /// <summary>
        /// This mode ignores query strings in the URL when caching assets.
        /// </summary>
        IgnoreQueryString,

        /// <summary>
        /// This mode prevents requests containing query strings from being cached.
        /// </summary>
        BypassCaching,

        /// <summary>
        /// This mode caches an asset for each request made with a unique URL.
        /// </summary>
        UseQueryString,

        /// <summary>
        /// Behavior is not set.
        /// Used by the Premium SKU endpoints to indicate that the property value
        /// cannot be set via the API. It can be configured only via the SSO Portal.
        /// </summary>
        NotSet
    }
}