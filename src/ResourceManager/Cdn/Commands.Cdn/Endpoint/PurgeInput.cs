////////////////////////////////////////////////////////////////////////////////
//
// Copyright (C) Microsoft Corporation. All rights reserved.
//
////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using Microsoft.Azure.Cdn.Common.EntityValidators;
using Microsoft.Azure.Cdn.Services.ResourceProvider.Validation;

namespace Microsoft.Azure.Cdn.Services.ResourceProvider.Models.EndpointModels
{
    /// <summary>
    /// Input for purge action.
    /// </summary>
    public class PurgeInput
    {
        /// <summary>
        /// The file paths for the action.
        /// </summary>
        [EntityProperty
        (Required = true,
        CustomValidator = PurgeContentPathsValidator.Name)]
        public ICollection<string> ContentPaths { get; set; }
    }
}
