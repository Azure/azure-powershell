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

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    /// <summary>
    /// Encapsulates the important information about a type without requiring the assembly containing the
    /// type to be loaded. Used for transferring type metadat across AppDomain boundaries.
    /// </summary>
    [Serializable]
    public class TypeMetadata
    {
        /// <summary>
        /// Allow easy conversion between types and type metadata objects.
        /// </summary>
        /// <param name="typeToProcess"></param>
        /// <returns>The capture type metadata</returns>
        public static implicit operator TypeMetadata(Type typeToProcess)
        {
            return new TypeMetadata(typeToProcess);
        }

        public TypeMetadata()
        {

        }

        private Dictionary<string, TypeMetadata> _properties = new Dictionary<string, TypeMetadata>();

        public TypeMetadata(Type inputType)
        {
            Namespace = inputType.Namespace;
            Name = inputType.Name;
            AssemblyQualifiedName = inputType.AssemblyQualifiedName;

            // Get the properties of the type
            var properties = inputType.GetProperties();

            // For each property, check if we have seen it before, and if so,
            // create a new TypeMetadata object that contains information about
            // the type EXCEPT for the properties (since we have already computed
            // this part of the type previously)
            // 
            // Using this method avoids issues with circular properties (e.g., type A
            // has a property of type B, and type B has a property of type A). This
            // will avoid serializing types that will keep repeating.
            foreach (var property in properties)
            {
                // Get the property type
                var propertyType = property.PropertyType;

                // If we have already seen this type before, create a new TypeMetadata
                // object without iterating over its properties
                if (CmdletBreakingChangeLoader.TypeSet.Contains(propertyType.ToString()))
                {
                    TypeMetadata foundType = new TypeMetadata()
                    {
                        Namespace = propertyType.Namespace,
                        Name = propertyType.Name,
                        AssemblyQualifiedName = propertyType.AssemblyQualifiedName
                    };

                    // Add the property to the dictionary
                    _properties.Add(property.Name, foundType);
                    continue;
                }

                // If we haven't seen the type before, add it to the set of types
                CmdletBreakingChangeLoader.TypeSet.Add(propertyType.ToString());
                // Create a new TypeMetadata object that will iterate over the type properties
                TypeMetadata newType = new TypeMetadata(property.PropertyType);
                // Add the property to the dictionary
                _properties.Add(property.Name, newType);
            }
        }

        public string Namespace { get; set; }
        public string Name { get; set; }
        public string AssemblyQualifiedName { get; set; }
        public Dictionary<string, TypeMetadata> Properties { get { return _properties; } }
    }
}
