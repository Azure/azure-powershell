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
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// The class represents a name-value pair of a parameter.
    /// </summary>
    struct Parameter : IEquatable<Parameter>
    {
        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the valus of the parameter.
        /// null if there is no valud is expected or set for this parameter.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets the value to indicate whether it's a positional parameter.
        /// </summary>
        public bool IsPositional { get; }

        /// <summary>
        /// Creates a new instance of <see cref="Parameter"/>
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The value of the parameter. If the parameter is a switch parameter, it's null.</param>
        /// <param name="isPositional">The value indicating whether it's a positional parameter.</param>
        public Parameter(string name, string value, bool isPositional)
        {
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(name) || string.Equals(name, AzPredictorConstants.DashParameterName, StringComparison.Ordinal), $"{nameof(name)} cannot be null or whitespace");

            Name = name;
            Value = value;
            IsPositional = isPositional;
        }

        public override int GetHashCode()
        {
            int hashCode = 17;

            hashCode = hashCode * 23 + Name.GetHashCode();
            hashCode = hashCode * 23 + IsPositional.GetHashCode();

            if (Value != null)
            {
                hashCode = hashCode * 23 + Value.GetHashCode();
            }

            return hashCode;
        }

        public override bool Equals(object other)
        {
            if (other is Parameter o)
            {
                return Equals(o);
            }

            return false;
        }

        public bool Equals(Parameter other)
        {
            return string.Equals(Name, other.Name)
                && string.Equals(Value, other.Value)
                && IsPositional == other.IsPositional;

        }
    }
}
