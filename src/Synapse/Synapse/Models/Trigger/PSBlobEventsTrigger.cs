using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    using global::Azure.Analytics.Synapse.Artifacts.Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [Newtonsoft.Json.JsonObject("BlobEventsTrigger")]
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

        public override Trigger ToSdkObject()
        {
            var trigger = new BlobEventsTrigger(this.Events.Select(element => new BlobEventTypes(element)), this.Scope);
            trigger.Description = this.Description;
            trigger.BlobPathBeginsWith = this.BlobPathBeginsWith;
            trigger.BlobPathEndsWith = this.BlobPathEndsWith;
            this.IgnoreEmptyBlobs = this.IgnoreEmptyBlobs;
            foreach (var item in this.Pipelines)
            {
                trigger.Pipelines.Add(item);
            }
            foreach (var item in this.Annotations)
            {
                trigger.Annotations.Add(item);
            }
            return trigger;
        }
    }
}
