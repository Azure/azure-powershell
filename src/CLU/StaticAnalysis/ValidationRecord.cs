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

namespace StaticAnalysis
{
    public class ValidationRecord
    {
        public string Validator { get; set; }
        public string Assembly { get; set; }
        public string Target { get; set; }
        public int Severity { get; set; }
        public string Description { get; set; }
        public string Remediation { get; set; }

        public override string ToString()
        {
            return $"\"{Validator}\",\"{Assembly}\",\"{Target}\",\"{Severity}\",\"{Description}\",\"{Remediation}\"";
        }

        public string PrintHeaders()
        {
            return $"{nameof(Validator)},{nameof(Assembly)},{nameof(Target)},{nameof(Severity)},{nameof(Description)},{nameof(Remediation)}";
        }
    }
}
