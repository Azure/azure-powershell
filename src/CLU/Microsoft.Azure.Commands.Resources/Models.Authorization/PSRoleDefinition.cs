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

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    public class PSRoleDefinition
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public bool IsCustom { get; set; }

        public string Description { get; set; }

        public List<string> Actions { get; set; }

        public string ActionsText
        {
            get
            {
                return FormatList(Actions);
            }
        }

        public List<string> NotActions { get; set; }

        public string NotActionsText
        {
            get
            {
                return FormatList(NotActions);
            }
        }

        public List<string> AssignableScopes { get; set; }

        public string AssignableScopesText
        {
            get
            {
                return FormatList(AssignableScopes);
            }
        }

        private string FormatList(IList<string> list)
        {
            if(list.Count <=1)
            {
                return string.Format("[{0}]", list.Count == 0 ? "" : string.Format("\"{0}\"",list.First()));
            }
            var sb = new StringBuilder();
            sb.AppendLine("[");
            foreach (var textLine in list.Select(s => string.Format("    \"{0}\",", s)))
            {
                sb.AppendLine(textLine);
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
