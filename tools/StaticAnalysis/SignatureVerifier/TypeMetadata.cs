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

namespace StaticAnalysis.SignatureVerifier
{
    /// <summary>
    /// Encapsulates the important information about a type without requiring the assembly containing the 
    /// type to be loaded.  Used for transferring type metadata across AppDomain boundaries.
    /// </summary>
    [Serializable]
    public class TypeMetadata
    {
        /// <summary>
        /// Allow easy conversion between types and type metadata objects.
        /// </summary>
        /// <param name="typeToProcess">The type to capture metadata for</param>
        /// <returns>The captured type metadata</returns>
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
        }

        public string Namespace { get; set; }

        public string Name { get; set; }

        public string AssemblyQualifiedName { get; set; }
    }
}
