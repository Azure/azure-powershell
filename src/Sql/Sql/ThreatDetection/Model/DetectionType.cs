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

namespace Microsoft.Azure.Commands.Sql.ThreatDetection.Model
{
    /// <summary>
    /// The possible disable alert types
    /// </summary> 
    public static class DetectionType
    {
        public const string Sql_Injection = "Sql_Injection";
        public const string Sql_Injection_Vulnerability = "Sql_Injection_Vulnerability";
        public const string Access_Anomaly = "Access_Anomaly";
        public const string Data_Exfiltration = "Data_Exfiltration";
        public const string Unsafe_Action = "Unsafe_Action";
        public const string None = "None";
    }
}
