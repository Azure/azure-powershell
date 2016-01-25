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
using System.Text;
using System.Threading.Tasks;

namespace StaticAnalysis.HelpGenerator
{
    public class ParameterSetHelp
    {
        IList<ParameterReferenceHelp> _parameters = new List<ParameterReferenceHelp>();
        public string Name { get; set; }
        public IList<ParameterReferenceHelp> Parameters
        {
            get { return _parameters; }
        }
        public bool IsDefault { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            IOrderedEnumerable<ParameterReferenceHelp> orderedParams = _parameters.OrderBy( p => p.Required? 0 : 1);
            if (_parameters.Any(p => p.Order.HasValue))
            {
                orderedParams = _parameters.OrderBy(p => p.Order.HasValue ? p.Order  : int.MaxValue);
            }
            foreach (var parameter in orderedParams)
            {
                builder.Append($"{parameter} ");
            }

            return builder.ToString().TrimEnd(' ');
        }
    }
}
