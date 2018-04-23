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
using System.Xml.Serialization;

namespace NetCoreCsProjSync.NewModel
{
    [Serializable]
    public class NewPropertyGroup
    {
        [XmlElement("TargetFramework")]
        public string TargetFramework { get; set; }

        [XmlElement("AssemblyName")]
        public string AssemblyName { get; set; }

        [XmlElement("RootNamespace")]
        public string RootNamespace { get; set; }

        [XmlElement("GenerateAssemblyInfo")]
        public XmlBool GenerateAssemblyInfo { get; set; }

        [XmlElement("AllowUnsafeBlocks")]
        public XmlBool AllowUnsafeBlocks { get; set; }

        [XmlElement("CopyLocalLockFileAssemblies")]
        public XmlBool CopyLocalLockFileAssemblies { get; set; }

        [XmlElement("AppendTargetFrameworkToOutputPath")]
        public XmlBool AppendTargetFrameworkToOutputPath { get; set; }

        [XmlAttribute("Condition")]
        public string Condition { get; set; }

        [XmlElement("OutputPath")]
        public string OutputPath { get; set; }

        [XmlElement("DocumentationFile")]
        public string DocumentationFile { get; set; }

        [XmlElement("SignAssembly")]
        public XmlBool SignAssembly { get; set; }

        [XmlElement("DelaySign")]
        public XmlBool DelaySign { get; set; }

        [XmlElement("AssemblyOriginatorKeyFile")]
        public string AssemblyOriginatorKeyFile { get; set; }

        [XmlElement("DefineConstants")]
        public string DefineConstants { get; set; }
    }
}
