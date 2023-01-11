namespace Microsoft.Azure.Commands.KeyVault.Extensions
{
    using System;
    using System.Collections;
    using System.Linq;

    /// <summary>
    /// Definition of a resource provider and its registration state
    /// </summary>
    public class PSResourceProvider
    {
        /// <summary>
        /// Gets or sets the namespace of the provider.
        /// </summary>
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets the registration state of the provider.
        /// </summary>
        public string RegistrationState { get; set; }

        /// <summary>
        /// Gets or sets the resource types belonging to this provider.
        /// </summary>
        public PSResourceProviderResourceType[] ResourceTypes { get; set; }

        /// <summary>
        /// Gets the locations for the provider.
        /// </summary>
        public string[] Locations
        {
            get
            {
                return this.ResourceTypes
                    .SelectMany(type => type.Locations)
                    .Distinct(StringComparer.InvariantCultureIgnoreCase)
                    .ToArray();
            }
        }

        /// <summary>
        /// Gets the zone mappings for the provider.
        /// </summary>
        public Hashtable ZoneMappings { get; set; }
    }
}