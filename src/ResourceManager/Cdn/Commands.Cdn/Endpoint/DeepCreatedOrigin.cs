////////////////////////////////////////////////////////////////////////////////
//
// Copyright (C) Microsoft Corporation. All rights reserved.
//
////////////////////////////////////////////////////////////////////////////////

using System.Globalization;
using Microsoft.Azure.Cdn.Common.EntityValidators;

namespace Microsoft.Azure.Cdn.Services.ResourceProvider.Models.EndpointModels
{
    public class DeepCreatedOrigin
    {
        /// <summary>
        /// Gets or sets the origin name.
        /// Note the maximium length for Name is 260. The name cannot include 
        /// &lt; &gt; '*'; '%'; '&'; ':'; '\\'; '?'; '+'; '/' and any control characters.
        /// </summary>
        [EntityProperty(
            Required = true,
            MaxLength = 260,
            Regex = ResourceProviderConstant.ResourceNameRegex)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the properties of the origin
        /// </summary>
        public DeepCreatedOriginProperties Properties { get; set; }

        /// <summary>
        /// Gets a deep clone of the object.
        /// </summary>
        public DeepCreatedOrigin Clone()
        {
            return new DeepCreatedOrigin
            {
                Name = Name,
                Properties = new DeepCreatedOriginProperties
                {
                    HostName = Properties.HostName,
                    HttpPort = Properties.HttpPort,
                    HttpsPort = Properties.HttpsPort
                }
            };
        }

        /// <summary>
        /// String representation of the Origin.
        /// </summary>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "Properties {{{0}}}",
                new
                {
                    Name,
                    Properties,
                });
        }
    }
}
