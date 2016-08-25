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

namespace Microsoft.WindowsAzure.Commands.Common.Extensions.DSC
{
    /// <summary>
    /// Represents public settings. Serialized representation of this object stored as a plain text string on the VM.
    /// Part of the protocol between Set-AzureVMDscExtension cmdlet and DSC Extension handler.
    /// </summary>
    public class DscExtensionPublicSettings
    {
        /// <summary>
        /// Version 1.0.0.0 of DscExtensionPublicSettings. We keep it for backward compatability.
        /// </summary>
        internal class Version1
        {
            public string SasToken { get; set; }
            public string ModulesUrl { get; set; }
            public string ConfigurationFunction { get; set; }
            public Hashtable Properties { get; set; }

            /// <summary>
            /// Converting to the current version of DscExtensionPublicSettings.
            /// </summary>
            /// <returns></returns>
            public DscExtensionPublicSettings ToCurrentVersion()
            {
                var properties = new List<Property>();
                foreach (DictionaryEntry p in Properties)
                {
                    properties.Add(new Property
                    {
                        Name = p.Key.ToString(),
                        TypeName = p.Value.GetType().ToString(),
                        Value = p.Value
                    });
                }
                return new DscExtensionPublicSettings
                {
                    SasToken = SasToken,
                    ModulesUrl = ModulesUrl,
                    ConfigurationFunction = ConfigurationFunction,
                    Properties = properties.ToArray(),
                    ProtocolVersion = new Version(1, 0, 0, 0)
                };
            }
        }

        /// <summary>
        /// Defines an entry of DscExtensionPublicSettings.Properties array.
        /// </summary>
        public class Property
        {
            public string TypeName { get; set; }
            public string Name { get; set; }
            public object Value { get; set; }
        }

        /// <summary>
        /// SharedAccessSignature token that allows access of azure blob storage files.
        /// </summary>
        public string SasToken { get; set; }

        /// <summary>
        /// Url for archive with modules and configuration in azure blob storage.
        /// </summary>
        public string ModulesUrl { get; set; }

        /// <summary>
        /// String to define configuration in the format: "Module\NameOfConfiguration", where
        /// Module can be a path to the root of the module or .ps1 file or .psm1 file.
        /// </summary>
        public string ConfigurationFunction { get; set; }

        /// <summary>
        /// Configuration parameters
        /// </summary>
        public Property[] Properties { get; set; }

        /// <summary>
        /// Privacy parameters
        /// </summary>
        public Hashtable Privacy { get; set; }

        /// <summary>
        /// Version of the protocol (DscExtensionPublicSettings and DscExtensionPrivateSettings mostly).
        /// </summary>
        public Version ProtocolVersion { get; set; }

        /// <summary>
        /// Specifies the version of the Windows Management Framework (WMF) to install 
        /// on the VM.
        /// </summary>
        public string WmfVersion { get; set; }
    }
}
