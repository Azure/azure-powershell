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

using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    internal class JoseHelper
    {
        public static JObject ExtractJosePart(string jwt, int partIndex)
        {
            string[] joseParts = jwt.Split('.');
            var decodedPart = Base64Url.DecodeString(joseParts[partIndex]);
            JObject jsonPart = JObject.Parse(decodedPart);
            return jsonPart;
        }
        public static JToken ExtractJosePartField(string jwt, int partIndex, string fieldName)
        {
            var part = ExtractJosePart(jwt, partIndex);
            return part[fieldName];
        }
    }
}
