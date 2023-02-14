// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the IDictionary to provide a better output format for the PS command lets.
    /// </summary>
    public class PSDictionaryElement
    {
        /// <summary>
        /// Gets the Content of the object
        /// </summary>
        public IDictionary<string, string> Content { get; private set; }

        /// <summary>
        /// Initializes a new instance of the PSDictionaryElement class.
        /// </summary>
        /// <param name="inputDictionary">The input IDictionary</param>
        public PSDictionaryElement(IDictionary<string, string> inputDictionary)
        {
            this.Content = inputDictionary;
        }

        /// <summary>
        /// A string representation of the contained dictionary
        /// </summary>
        /// <returns>A string representation of the contained dictionary</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            if (this.Content != null && this.Content.Count > 0)
            {
                foreach (var keyValuePair in this.Content)
                {
                    output.AppendLine();
                    output.Append(string.Format("{0, -15}: {1}", keyValuePair.Key, keyValuePair.Value));
                }
            }
            return output.ToString();
        }

        /// <summary>
        /// A string representation of the contained dictionary
        /// </summary>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the contained dictionary</returns>
        public string ToString(int indentationTabs)
        {
            var output = new StringBuilder();
            if (this.Content != null && this.Content.Count > 0)
            {
                foreach (var keyValuePair in this.Content)
                {
                    output.AppendLine();
                    output.AddSpacesInFront(indentationTabs).Append(string.Format(CultureInfo.InvariantCulture, "{0, -15}: {1}", keyValuePair.Key, keyValuePair.Value));
                }
            }
            return output.ToString();
        }
    }
}
