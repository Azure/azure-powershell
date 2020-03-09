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

using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    public class PSPolicySigners
    {
        public  PSPolicySigners(string jwt)
        {
            Jwt = jwt;
            (Algorithm, JKU) = ExtractHeaders(jwt);
            Certificates = ExtractCertificates(jwt);
            CertificateCount = Certificates.Length;
        }

        public int CertificateCount { get; protected set; }

        public string Jwt { get; protected set; }

        public string Algorithm { get; protected set; }

        public string JKU { get; set; }

        public string[] Certificates { get; protected set; }

        private static JObject ExtractJosePart(string jwt, int partIndex)
        {
            string[] joseParts = jwt.Split('.');
            var decodedBody = Encoding.UTF8.GetString(Base64Url.Decode(joseParts[partIndex]));
            JObject jsonBody = JObject.Parse(decodedBody);
            return jsonBody;
        }

        private static (string algorithm, string jku) ExtractHeaders(string jwt)
        {
            var algorithm = "";
            var jku = "";
            if (!string.IsNullOrEmpty(jwt))
            {
                var parsedHeader = ExtractJosePart(jwt, 0);
                algorithm = parsedHeader["alg"].ToString();
                jku = parsedHeader["jku"].ToString();
            }
            return (algorithm, jku);
        }
        private static string[] ExtractCertificates(string jwt)
        {
            if (string.IsNullOrEmpty(jwt))
            {
                return new string[0];
            }

            var parsedBody = ExtractJosePart(jwt, 1);
            var parsedCertificates = parsedBody["aas-policyCertificates"]["keys"].ToArray();
            return parsedCertificates.Select(c => c.ToString()).ToArray();
        }
    }
}