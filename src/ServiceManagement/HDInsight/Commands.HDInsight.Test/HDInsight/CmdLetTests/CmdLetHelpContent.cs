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

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    public enum PipelineValue
    {
        False,
        TrueByValue,
        TrueByName
    }

    public class CmdletParameterValue
    {
        public bool Required { get; set; }
        public bool VariableLength { get; set; }
        public string DataType { get; set; }
    }

    public class CmdletParameter : CmdletParameterValue
    {
        public string Name { get; set; }
        public int Location { get; set; }
        public bool ValueFromPipeline { get; set; }
        public string Description { get; set; }
        public CmdletParameterValue Value { get; set; }
    }

    public class CmdletSyntax
    {
        public CmdletSyntax()
        {
            this.Parameters = new List<CmdletParameter>();
        }
        public string Name { get; set; }
        public IEnumerable<CmdletParameter> Parameters { get; private set; }
    }

    public class CmdletHelpContent
    {
        public CmdletHelpContent()
        {
            this.Syntax = new List<CmdletSyntax>();
            this.Parameters = new List<CmdletParameter>();
        }
        public string Name { get; set; }
        public string Verb { get; set; }
        public string Nown { get; set; }
        public string Description { get; set; }
        public IEnumerable<CmdletSyntax> Syntax { get; private set; }
        public IEnumerable<CmdletParameter> Parameters { get; private set; }
    }
}
