using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class TagSettings
    {
        public IDictionary<string, string> Tags { get; set; }

        public TagOperators FilterOperator { get; set; }

        public TagSettings() { }

        public TagSettings(Hashtable tags, TagOperators filterOperator)
        {
            Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);
            FilterOperator = filterOperator;
        }

        public bool HasTags => Tags != null && Tags.Count > 0;
    }
}
