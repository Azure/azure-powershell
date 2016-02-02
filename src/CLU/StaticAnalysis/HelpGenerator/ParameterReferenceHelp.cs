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
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace StaticAnalysis.HelpGenerator
{
    public class ParameterReferenceHelp
    {
        public ParameterHelp Parameter { get; set; }
        public int? Order { get; set; }
        public bool Required { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if (!Required)
            {
                builder.Append("[");
            }
            if (Order.HasValue && Parameter.Type != typeof(SwitchParameter))
            {
                builder.Append("[");
            }
            builder.Append("-");
            if (Parameter.PreferredName.Length > 1)
            {
                builder.Append("-");
            }
            builder.Append(Parameter.PreferredName.ToCamelCase());
            if (Order.HasValue && Parameter.Type != typeof(SwitchParameter))
            {
                builder.Append("]");
            }
            if (!Parameter.IsSwitch)
            {
                builder.Append($" <{Parameter.Name.ToCamelCase()}>");
            }
            if (!Required)
            {
                builder.Append("]");
            }

            return builder.ToString();

        }
    }
}
