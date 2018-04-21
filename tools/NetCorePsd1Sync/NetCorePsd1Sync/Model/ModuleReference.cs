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
using System.ComponentModel;
using NetCorePsd1Sync.Utility;
using static NetCorePsd1Sync.Model.PsDefinitionConstants;

namespace NetCorePsd1Sync.Model
{
    public class ModuleReference
    {
        [DisplayName("ModuleName")]
        public string ModuleName { get; set; }

        [DisplayName("ModuleVersion")]
        public Version ModuleVersion { get; set; }

        [DisplayName("GUID")]
        public Guid? Guid { get; set; }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(ModuleName))
            {
                throw new ArgumentException($"{nameof(ModuleName)} cannot be null or empty");
            }

            if (ModuleVersion == null && Guid == null)
            {
                return $"{ElementPrefix}{ModuleName}{ElementPostfix}";
            }

            var moduleDisplayName = AttributeHelper.GetPropertyAttributeValue<ModuleReference, string, DisplayNameAttribute, string>(mr => mr.ModuleName, attr => attr.DisplayName, nameof(ModuleName));
            var line = $"{ObjectPrefix}{moduleDisplayName}{NameValueDelimiter}{ElementPrefix}{ModuleName}{ElementPostfix}{NameValuePostfix}";
            if (ModuleVersion != null)
            {
                var versionDisplayName = AttributeHelper.GetPropertyAttributeValue<ModuleReference, Version, DisplayNameAttribute, string>(mr => mr.ModuleVersion, attr => attr.DisplayName, nameof(ModuleVersion));
                line += $"{versionDisplayName}{NameValueDelimiter}{ElementPrefix}{ModuleVersion}{ElementPostfix}{NameValuePostfix}";
            }
            // ReSharper disable once InvertIf
            if (Guid != null)
            {
                var guidDisplayName = AttributeHelper.GetPropertyAttributeValue<ModuleReference, Guid?, DisplayNameAttribute, string>(mr => mr.Guid, attr => attr.DisplayName, nameof(Guid));
                line += $"{guidDisplayName}{NameValueDelimiter}{ElementPrefix}{Guid}{ElementPostfix}{NameValuePostfix}";
            }
            return $"{line}{ObjectPostfix}";
        }
    }
}
