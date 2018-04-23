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
using System.Xml.Serialization;

namespace NetCoreCsProjSync.OldModel
{
    [Serializable]
    //https://stackoverflow.com/questions/22083548/deserialize-a-portion-of-xml-into-classes#comment33618910_22085008
    [XmlRoot("Project", Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public class OldProjectDefinition
    {
        //https://stackoverflow.com/a/10518657/294804
        [XmlElement("PropertyGroup")]
        public List<OldPropertyGroup> PropertyGroups { get; set; }

        [XmlElement("ItemGroup")]
        public List<OldItemGroup> ItemGroups { get; set; }

        [XmlIgnore]
        public string FilePath { get; set; }
    }
}
