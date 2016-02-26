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
    /// Input for load action.
    /// </summary>
    public class LoadInput
    {
        /// <summary>
        /// The file paths for the load action.
        /// </summary>
        [EntityProperty
        (Required = true,
        CustomValidator = LoadContentPathsValidator.Name)]
        public ICollection<string> ContentPaths { get; set; }
    }
}
