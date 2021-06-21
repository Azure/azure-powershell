using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSSavedSearchParameters : OperationalInsightsParametersBase
    {
        public const string EtagWildCard = "*";
        public PSSavedSearchParameters(string resourceGroupName, string workspaceName, string savedSearchId, string category, string displayName, string query, long? version, string functionAlias, string functionParameter,string eTag, Hashtable tags)
        {
            WorkspaceName = workspaceName;
            ResourceGroupName = resourceGroupName;
            SavedSearchId = savedSearchId;
            DisplayName = displayName;
            Category = category;
            Query = query;
            Version = version;
            FunctionAlias = functionAlias;
            FunctionParameters = functionParameter;
            ETag = eTag;
            Tags = tags;
        }

        public string SavedSearchId { get; set; }

        public string DisplayName { get; set; }

        public string Category { get; set; }

        public string Query { get; set; }

        public long? Version { get; set; }

        public Hashtable Tags { get; set; }

        public string FunctionAlias { get; set; }

        public string FunctionParameters { get; set; }

        public string ETag { get; set; }


        public SavedSearch GetSavedSearchFromParameters()
        {
            SavedSearch savedSearch = new SavedSearch() {
                
                //Id = this.SavedSearchId,
                Category = this.Category,
                DisplayName = this.DisplayName,
                Query = this.Query,
                Version = this.Version,
                FunctionAlias = this.FunctionAlias,
                FunctionParameters = this.FunctionParameters,
                Etag = this.ETag,
                Tags = ConvertAndValidateTags(this.Tags)
            };

            return savedSearch;
        }

        /// <summary>
        /// Populate and validate SavedSearch.Properties.Tags from a Hashtable of tags specified in the cmdlet.
        /// </summary>
        /// <returns></returns>
        public static IList<Tag> ConvertAndValidateTags(Hashtable tags)
        {
            if (tags == null || tags.Count == 0)
            {
                return null;
            }

            IList<Tag> tagList = new List<Tag>();
            foreach (string key in tags.Keys)
            {
                if (tags[key] != null)
                {
                    tagList.Add(new Tag() { Name = key, Value = tags[key].ToString() });
                }
                else
                {
                    throw new PSArgumentException("Tag value can't be null.");
                }
            }

            return tagList;
        }
    }

}
