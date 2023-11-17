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

using System.Collections.Generic;

namespace StaticAnalysis.UXMetadataAnalyzer
{
    internal class UXMetadata
    {
        public string ResourceType { get; set; }
        public string ApiVersion { get; set; }
        public UXMetadataLearnMore LearnMore { get; set; }
        public List<UXMetadataCommand> Commands { get; set; }
    }

    internal class UXMetadataLearnMore
    {
        public string Url { get; set; }
    }

    internal class UXMetadataCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public bool Confirmation { get; set; }
        public UXMetadataCommandHelp Help { get; set; }
        public List<UXMetadataCommandExample> Examples { get; set; }
    }

    internal class UXMetadataCommandExample
    {
        public string Description { get; set; }
        public List<UXMetadataCommandExamplePatameter> Parameters { get; set; }
    }

    internal class UXMetadataCommandExamplePatameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    internal class UXMetadataCommandHelp
    {
        public UXMetadataLearnMore LearnMore { get; set; }
        public List<UXMetadataCommandHelpParameterSet> ParameterSets { get; set; }
    }

    internal class UXMetadataCommandHelpParameterSet
    {
        public List<string> Parameters { get; set; }
    }
}
