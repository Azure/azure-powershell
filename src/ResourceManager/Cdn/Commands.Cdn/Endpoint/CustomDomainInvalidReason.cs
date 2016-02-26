////////////////////////////////////////////////////////////////////////////////
//
// Copyright (C) Microsoft Corporation. All rights reserved.
//
////////////////////////////////////////////////////////////////////////////////

namespace Microsoft.Azure.Cdn.Services.ResourceProvider.Models.EndpointModels
{
    /// <summary>
    /// Represents the reason why the custom domain is not valid.
    /// </summary>
    public enum CustomDomainInvalidReason
    {
        /// <summary>
        /// The format of the host name of the custom domain is not valid.
        /// </summary>
        InvalidFormat,

        /// <summary>
        /// The DNS mapping of the custom domain does not point to CDN endpoint
        /// or the designated domain name.
        /// </summary>
        IncorrectMapping,
    }
}
