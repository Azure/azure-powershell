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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using VersionController.Netcore.Models;

namespace Tools.Common.Models
{
    /// <summary>
    /// Information about a parameter in a parameter set
    /// </summary>
    [Serializable]
    public class ParameterSetMetadata
    {
        private List<Parameter> _parameters = new List<Parameter>();

        /// <summary>
        /// Name of the parameter set
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The set of parameters in the parameter set
        /// </summary>
        public List<Parameter> Parameters { get { return _parameters; } }

        /// <summary>
        /// Checks if two ParameterSetMetadata objects are equal by comparing
        /// each of the properties.
        /// </summary>
        /// <param name="other">The ParameterSetMetadata object being compared to this object.</param>
        /// <returns>True if the two objects are equal, false otherwise.</returns>
        public override bool Equals(Object obj)
        {
            var other = obj as ParameterSetMetadata;
            if (other == null)
            {
                return false;
            }

            var paramsSetEqual = true;
            foreach (var thisParameter in this.Parameters)
            {
                var thisParameterNames = new Dictionary<string, bool>();
                thisParameterNames.Add(thisParameter.ParameterMetadata.Name, true);
                thisParameter.ParameterMetadata.AliasList.ForEach(a => thisParameterNames.Add(a, true));
                var otherParameter = other.Parameters.Find(p => thisParameterNames.ContainsKey(p.ParameterMetadata.Name) || p.ParameterMetadata.AliasList.Find(a => thisParameterNames.ContainsKey(a)) != null);
                if (otherParameter == null)
                {
                    // Console.WriteLine($"Parameter {thisParameter.ParameterMetadata.Name} in parameter set {this.Name} is not found in new module.");
                    return false;
                }
                paramsSetEqual &= thisParameter.Equals(otherParameter);
            }

            var curParameters = this.Parameters.Where(p => !CommonInfo.ExcludedParameters.Contains(p.ParameterMetadata.Name)).ToList();
            var otherParameters = other.Parameters.Where(p => !CommonInfo.ExcludedParameters.Contains(p.ParameterMetadata.Name)).ToList();
            /*if (curParameters.Count != otherParameters.Count)
            {
                Console.WriteLine($"The number of parameters in parameter set {this.Name} is not same.");
                Console.WriteLine("Parameters in old version: ");
                this.Parameters.ForEach(p => Console.Write(p.ParameterMetadata.Name + " "));
                Console.WriteLine(Environment.NewLine + "Parameters in new version: ");
                other.Parameters.ForEach(p => Console.Write(p.ParameterMetadata.Name + " "));
                Console.WriteLine();
            }*/
            paramsSetEqual &= curParameters.Count == otherParameters.Count;
            return paramsSetEqual;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// For all mandatory parameters in this parameter set, check if you can find corresponding
        /// mandatory parameter in another parameter set and their mandatory parameters are exactly the same.
        /// </summary>
        /// <param name="other">The ParameterSetMetadata object being compared to this object.</param>
        /// <returns>True if the two objects are mandatory equal, false otherwise.</returns>
        public bool AllMandatoryParemeterEquals(object obj)
        {
            var other = obj as ParameterSetMetadata;
            if (other == null)
            {
                return false;
            }
            var mandatoryCount = 0;
            var mandatoryOtherCount = 0;
            foreach (var parameter in Parameters)
            {
                if (parameter.Mandatory)
                {
                    mandatoryCount++;
                }
            }
            foreach (var parameterOther in other.Parameters)
            {
                if (parameterOther.Mandatory)
                {
                    mandatoryOtherCount++;
                }
            }
            if (mandatoryCount != mandatoryOtherCount)
            {
                return false;
            }

            foreach (var parameter in Parameters)
            {
                if (parameter.Mandatory)
                {
                    var containParameter = false;
                    foreach (var parameterOther in other.Parameters)
                    {
                        if (parameterOther.Mandatory && parameterOther.EqualsIncludeName(parameter))
                        {
                            containParameter = true;
                            break;
                        }
                    }
                    if (!containParameter)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// For all mandatory parameters in this parameter set, check if you can find corresponding
        /// mandatory or optional parameter in another parameter set and the count of mandatory parameters
        /// in this parameter set must lager than another parameter set
        /// </summary>
        /// <param name="other">The ParameterSetMetadata object being compared to this object.</param>
        /// <returns>True if the two objects are lenient mandatory equal, false otherwise.</returns>
        public bool AllMandatoryParemeterLenientEquals(object obj)
        {
            var other = obj as ParameterSetMetadata;
            if (other == null)
            {
                return false;
            }
            var mandatoryCount = 0;
            var mandatoryOtherCount = 0;
            foreach (var parameter in Parameters)
            {
                if (parameter.Mandatory)
                {
                    mandatoryCount++;
                }
            }
            foreach (var parameterOther in other.Parameters)
            {
                if (parameterOther.Mandatory)
                {
                    mandatoryOtherCount++;
                }
            }
            if (mandatoryCount <= mandatoryOtherCount)
            {
                return false;
            }

            foreach (var parameter in Parameters)
            {
                if (parameter.Mandatory)
                {
                    var containParameter = false;
                    foreach (var parameterOther in other.Parameters)
                    {
                        if (parameterOther.EqualsIncludeName(parameter))
                        {
                            containParameter = true;
                            break;
                        }
                    }
                    if (!containParameter)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    [Serializable]
    public class Parameter
    {
        /// <summary>
        /// Contains information shared among the parameter throughout
        /// all of the parameter sets it may be apart of
        /// </summary>
        public ParameterMetadata ParameterMetadata { get; set; }

        /// <summary>
        /// Specifies if the parameter is mandatory in the given parameter set
        /// </summary>
        public bool Mandatory { get; set; }

        /// <summary>
        /// Position of the parameter in the parameter set
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Indicates whether the parameter takes its value from a
        /// pipeline object
        /// </summary>
        public bool ValueFromPipeline { get; set; }

        /// <summary>
        /// Indicates whether the parameter takes its value from a property
        /// of a pipeline object that has either the same name or the same
        /// alias as this parameter
        /// </summary>
        public bool ValueFromPipelineByPropertyName { get; set; }

        /// <summary>
        /// Checks if two Parameter objects are equal by comparing
        /// each of the properties.
        /// </summary>
        /// <param name="other">The Parameter object being compared to this object.</param>
        /// <returns>True if the two objects are equal, false otherwise.</returns>
        public override bool Equals(Object obj)
        {
            var other = obj as Parameter;
            if (other == null)
            {
                return false;
            }
            var paramsEqual = true;
            paramsEqual &= this.Mandatory == other.Mandatory &&
                           this.Position == other.Position &&
                           this.ValueFromPipeline == other.ValueFromPipeline &&
                           this.ValueFromPipelineByPropertyName == other.ValueFromPipelineByPropertyName &&
                           this.ParameterMetadata.Equals(other.ParameterMetadata);
            // if (!paramsEqual) Console.WriteLine($"The attributes of {this.ParameterMetadata.Name} is different in new version");
            return paramsEqual;
        }

        /// <summary>
        /// Checks if two Parameter objects are equal by comparing
        /// each of the properties and also their names.
        /// </summary>
        /// <param name="other">The Parameter object being compared to this object.</param>
        /// <returns>True if the two objects are equal include name, false otherwise.</returns>
        public bool EqualsIncludeName(Object obj)
        {
            var other = obj as Parameter;
            if (other == null)
            {
                return false;
            }

            var paramsEqual = true;
            paramsEqual &= this.Equals(other) &&
                           this.ParameterMetadata.Name == other.ParameterMetadata.Name;
            
            return paramsEqual;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
