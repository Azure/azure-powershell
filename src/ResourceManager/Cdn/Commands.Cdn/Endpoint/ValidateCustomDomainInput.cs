////////////////////////////////////////////////////////////////////////////////
//
// Copyright (C) Microsoft Corporation. All rights reserved.
//
////////////////////////////////////////////////////////////////////////////////

using Microsoft.Azure.Cdn.Common.EntityValidators;
using Microsoft.Azure.Cdn.Services.ResourceProvider.Validation;

namespace Microsoft.Azure.Cdn.Services.ResourceProvider.Models.EndpointModels
{
    /// <summary>
    /// Represents the input of the action validate custom domain.
    /// </summary>
    public class ValidateCustomDomainInput
    {
        /// <summary>
        /// Gets or sets the host name of the custom domain.
        /// </summary>
        [EntityProperty(
            Required = true,
            CustomValidator = HostNameValidator.Name)]
        public string HostName { get; set; }
    }
}
