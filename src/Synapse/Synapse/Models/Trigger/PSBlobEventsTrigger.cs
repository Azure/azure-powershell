using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    using global::Azure.Analytics.Synapse.Artifacts.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
        using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [Rest.Serialization.JsonTransformation]
    public partial class PSBlobEventsTrigger : PSMultiplePipelineTrigger
    {
        public PSBlobEventsTrigger()
        {
            CustomInit();
        }

        partial void CustomInit();

        [JsonProperty(PropertyName = "typeProperties.blobPathBeginsWith")]
        public string BlobPathBeginsWith { get; set; }

        [JsonProperty(PropertyName = "typeProperties.blobPathEndsWith")]
        public string BlobPathEndsWith { get; set; }

        [JsonProperty(PropertyName = "typeProperties.ignoreEmptyBlobs")]
        public bool? IgnoreEmptyBlobs { get; set; }

        [JsonProperty(PropertyName = "typeProperties.events")]
        public IList<string> Events { get; set; }

        [JsonProperty(PropertyName = "typeProperties.scope")]
        public string Scope { get; set; }
    }
}
