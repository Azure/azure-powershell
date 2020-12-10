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

        public string BlobPathBeginsWith { get; set; }

        public string BlobPathEndsWith { get; set; }

        public bool? IgnoreEmptyBlobs { get; set; }

        public IList<string> Events { get; set; }

        public string Scope { get; set; }
    }
}
