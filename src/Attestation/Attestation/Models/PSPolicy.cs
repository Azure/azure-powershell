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

namespace Microsoft.Azure.Commands.Attestation.Models
{
    public class PSPolicy
    {
        public PSPolicy(string jwt)
        {
            Jwt = jwt;
            JwtLength = Jwt?.Length ?? 0;
            Text = ExtractPolicyText(Jwt);
            TextLength = Text?.Length ?? 0;
            Algorithm = ExtractAlgorithm(Jwt);
        }

        public string Text { get; }

        public int TextLength { get; }

        public string Jwt { get; }

        public int JwtLength { get; }

        public string Algorithm { get; protected set; }

        private static string ExtractAlgorithm(string jwt)
        {
            var algorithm = string.Empty;
            if (!string.IsNullOrEmpty(jwt))
            {
                try
                {
                    algorithm = JoseHelper.ExtractJosePartField(jwt, 0, "alg").ToString();
                }
                catch (Exception)
                {
                    // Ignore on purpose
                }
            }
            return algorithm;
        }

        private static string ExtractPolicyText(string jwt)
        {
            string parsedPolicy = string.Empty;

            if (!string.IsNullOrEmpty(jwt))
            {
                try
                {
                    parsedPolicy = JoseHelper.ExtractJosePartField(jwt, 1, "AttestationPolicy").ToString();

                    // Policy is optionally double base64 URL encoded.  We will attempt
                    // to base64 URL decode a second time -- if this throws an exception,
                    // that's OK -- we should just use value as it stands now.
                    var doubleDecodedPolicy = Base64Url.DecodeString(parsedPolicy);
                    parsedPolicy = doubleDecodedPolicy;
                }
                catch (Exception)
                {
                    // Ignore on purpose
                }
            }

            return parsedPolicy;
        }
    }
}