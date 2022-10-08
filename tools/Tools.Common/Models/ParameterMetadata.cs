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

using System;
using System.Collections.Generic;

namespace Tools.Common.Models
{
    /// <summary>
    /// Information about cmdlet parameters
    /// </summary>
    [Serializable]
    public class ParameterMetadata
    {
        private List<string> _aliases = new List<string>();
        private List<string> _validateSet = new List<string>();

        /// <summary>
        /// The parameter name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The set of aliases
        /// </summary>
        public List<string> AliasList { get { return _aliases; } }

        /// <summary>
        /// The parameter type
        /// </summary>
        public TypeMetadata Type { get; set; }

        /// <summary>
        /// The set of valid arguments for the parameter
        /// </summary>
        public List<string> ValidateSet { get { return _validateSet; } }

        /// <summary>
        /// If the parameter implements ValidateRange, specifies the minimum value
        /// in the range; otherwise, the value is null
        /// </summary>
        public long? ValidateRangeMin { get; set; }

        /// <summary>
        /// If the parameter implements ValidateRange, specifies the maximum value
        /// in the range; otherwise, the value is null
        /// </summary>
        public long? ValidateRangeMax { get; set; }

        /// <summary>
        /// Specifies if the parameter has the ValidateNotNullOrEmpty attribute
        /// </summary>
        public bool ValidateNotNullOrEmpty { get; set; }

        /// <summary>
        /// Checks if two ParameterMetadata objects are equal by comparing
        /// each of the properties.
        /// </summary>
        /// <param name="other">The ParameterMetadata object being compared to this object.</param>
        /// <returns>True if the two objects are equal, false otherwise.</returns>
        public override bool Equals(Object obj)
        {
            var other = obj as ParameterMetadata;
            if (other == null)
            {
                return false;
            }

            var paramsEqual = true;
            var thisNames = new Dictionary<string, bool>();
            thisNames.Add(this.Name, true);
            this.AliasList.ForEach(a => thisNames.Add(a, true));
            var otherNames = new Dictionary<string, bool>();
            otherNames.Add(other.Name, true);
            other.AliasList.ForEach(a => otherNames.Add(a, true));
            paramsEqual &= thisNames.Count == otherNames.Count &&
                           this.ValidateRangeMin == other.ValidateRangeMin &&
                           this.ValidateRangeMax == other.ValidateRangeMax &&
                           this.ValidateNotNullOrEmpty == other.ValidateNotNullOrEmpty &&
                           this.ValidateSet.Count == other.ValidateSet.Count &&
                           this.Type.Equals(other.Type, true);
            return paramsEqual;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
