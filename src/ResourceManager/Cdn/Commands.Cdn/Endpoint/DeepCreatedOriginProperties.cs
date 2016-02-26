////////////////////////////////////////////////////////////////////////////////
//
// Copyright (C) Microsoft Corporation. All rights reserved.
//
////////////////////////////////////////////////////////////////////////////////

using System.Globalization;
using Microsoft.Azure.Cdn.Common.EntityValidators;
using Microsoft.Azure.Cdn.Services.ResourceProvider.Validation;

namespace Microsoft.Azure.Cdn.Services.ResourceProvider.Models.EndpointModels
{
    /// <summary>
    /// The class represents the origin created with the endpoint.
    /// </summary>
    public class DeepCreatedOriginProperties
    {
        /// <summary>
        /// The host name of the origin.
        /// </summary>
        [EntityProperty(
            Required = true,
            CustomValidator = HostNameValidator.Name)]
        public string HostName { get; set; }

        /// <summary>
        /// The http port.
        /// </summary>
        [EntityProperty(
            Required = false,
            MinValue = 1,
            MaxValue = 65535)]
        public int? HttpPort { get; set; }

        /// <summary>
        /// The https port.
        /// </summary>
        [EntityProperty(
            Required = false,
            MinValue = 1,
            MaxValue = 65535)]
        public int? HttpsPort { get; set; }

        /// <summary>
        /// String representation of the origin properties.
        /// </summary>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "Properties {{{0}}}",
                new
                {
                    HostName,
                    HttpPort,
                    HttpsPort,
                });
        }
    }
}
