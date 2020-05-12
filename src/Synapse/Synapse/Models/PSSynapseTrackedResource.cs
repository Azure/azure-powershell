using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public abstract class PSSynapseTrackedResource : PSSynapseResource
    {
        public PSSynapseTrackedResource(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>))
            : base(id, name, type)
        {
            Tags = TagsConversionHelper.CreateTagHashtable(tags);
            Location = location;
        }

        /// <summary>
        /// Gets or sets resource tags.
        /// </summary>
        public Hashtable Tags { get; set; }

        public string TagsTable => ResourcesExtensions.ConstructTagsTable(Tags);

        /// <summary>
        /// Gets or sets the geo-location where the resource lives
        /// </summary>
        public string Location { get; set; }
    }
}
