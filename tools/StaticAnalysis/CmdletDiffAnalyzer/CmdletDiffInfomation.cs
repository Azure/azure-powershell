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

namespace StaticAnalysis.CmdletDiffAnalyzer
{
    public enum ChangeType
    {
        CmdletAdd,
        CmdletRemove,
        CmdletSupportsShouldProcessChange,
        CmdletSupportsPagingChange,
        AliasAdd,
        AliasRemove,
        ParameterAdd,
        ParameterRemove,
        ParameterAliasAdd,
        ParameterAliasRemove,
        ParameterTypeChange,
        ParameterAttributeChange,
        ParameterSetAdd,
        ParameterSetRemove,
        ParameterSetAttributePropertyChange,
        OutputTypeChange
    }
    public class CmdletDiffInformation
    {
        public string ModuleName { get; set; }
        public string CmdletName { get; set; }
        public ChangeType Type { get; set; }
        public string ParameterSetName { get; set; }
        public string ParameterName { get; set;}
        public List<string> Before { get; set; }
        public List<string> After { get; set; }
        public string PropertyName { get; set; }
    }
}