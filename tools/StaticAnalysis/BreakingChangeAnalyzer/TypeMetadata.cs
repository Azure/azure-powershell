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
using System.Reflection;

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    /// <summary>
    /// Encapsulates the important information about a type without requiring the assembly containing the
    /// type to be loaded. Used for transferring type metadat across AppDomain boundaries.
    /// </summary>
    [Serializable]
    public class TypeMetadata
    {
        private Dictionary<string, string> _properties = new Dictionary<string, string>();
        private List<string> _genericTypeArguments = new List<string>();

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

        public TypeMetadata(Type inputType)
        {
            Namespace = inputType.Namespace;
            Name = inputType.Name;
            AssemblyQualifiedName = inputType.AssemblyQualifiedName;

            // Get the properties of the type
            var properties = inputType.GetProperties();

            // Sort the properties by name to retain ordering when loading cmdlets
            Array.Sort(properties, delegate (PropertyInfo p1, PropertyInfo p2)
                                    {
                                        return p1.Name.CompareTo(p2.Name);
                                    });

            ModuleMetadata moduleMetadata = CmdletBreakingChangeLoader.ModuleMetadata;

            // If the type is an array
            if (inputType.HasElementType)
            {
                // Get the element type of the array
                ElementType = inputType.GetElementType().ToString();

                // If the element type is not in the type dictionary,
                // add it and check its properties
                if (!moduleMetadata.TypeDictionary.ContainsKey(ElementType))
                {
                    moduleMetadata.TypeDictionary.Add(ElementType, null);
                    var typeMetadata = new TypeMetadata(inputType.GetElementType());
                    moduleMetadata.TypeDictionary[ElementType] = typeMetadata;
                }

                return;
            }

            // If the type is a generic
            if (inputType.IsGenericType)
            {
                // Get the generic type name
                Name = inputType.Name.Substring(0, inputType.Name.IndexOf('`'));

                // Get the argument types
                var genericTypeArguments = inputType.GetGenericArguments();

                // For each of the arguments, add them to the list of arguments
                // and check if the type is in the type dictionary
                foreach (var arg in genericTypeArguments)
                {
                    _genericTypeArguments.Add(arg.ToString());

                    if (!moduleMetadata.TypeDictionary.ContainsKey(arg.ToString()))
                    {
                        moduleMetadata.TypeDictionary.Add(arg.ToString(), null);
                        var typeMetadata = new TypeMetadata(arg);
                        moduleMetadata.TypeDictionary[arg.ToString()] = typeMetadata;
                    }
                }

                return;
            }

            // For each property, check to see if we have already processed its type before,
            // and if not, we will add it to the global dictionary and process the TypeMetadata.
            foreach (var property in properties)
            {
                // Get the property type
                var propertyType = property.PropertyType;
                
                // If the type has not been seen before, we will map it to a null value in the
                // global dictionary so we don't repeat the computation, and then create the
                // TypeMetadata object associated with it, and finally set it as the value
                // associated with the type name key in the dictionary.
                if (!moduleMetadata.TypeDictionary.ContainsKey(propertyType.ToString()))
                {
                    moduleMetadata.TypeDictionary.Add(propertyType.ToString(), null);
                    var typeMetadata = new TypeMetadata(propertyType);
                    moduleMetadata.TypeDictionary[propertyType.ToString()] = typeMetadata;    
                }

                // Add the property to the dictionary
                _properties.Add(property.Name, propertyType.ToString());
            }
        }

        public string Namespace { get; set; }
        public string Name { get; set; }
        public string AssemblyQualifiedName { get; set; }
        public Dictionary<string, string> Properties { get { return _properties; } }
        public string ElementType { get; set; }
        public List<string> GenericTypeArguments { get { return _genericTypeArguments; } }
    }
}
