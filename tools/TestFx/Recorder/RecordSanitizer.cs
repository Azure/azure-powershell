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

using Microsoft.Security.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.TestFx.Recorder
{
    public class RecordSanitizer
    {
        private readonly SecretMasker _masker;

        public RecordSanitizer(string redactionToken = null)
        {
            var defaultRedactionToken = string.IsNullOrWhiteSpace(redactionToken) ? "Sanitized" : redactionToken;

            _masker = new SecretMasker(
                regexSecrets: WellKnownRegexPatterns.HighConfidenceMicrosoftSecurityModels,
                defaultRegexRedactionToken: defaultRedactionToken);
        }

        public void ProcessJsonToken(JToken token)
        {
            if (token == null)
                return;

            switch (token.Type)
            {
                case JTokenType.Array:
                    ProcessArrayToken(token);
                    break;
                case JTokenType.Object:
                    ProcessObjectToken(token);
                    break;
                case JTokenType.String:
                    ProcessStringToken(token);
                    break;
            }
        }

        private void ProcessArrayToken(JToken token)
        {
            foreach (var item in token.Children())
            {
                ProcessJsonToken(item);
            }
        }

        private void ProcessObjectToken(JToken token)
        {
            foreach (var property in token.Children<JProperty>())
            {
                ProcessJsonToken(property.Value);
            }
        }

        private void ProcessStringToken(JToken token)
        {
            if (TrySanitizeTokenValue(token, out var sanitizedData))
            {
                ((JValue)token).Value = sanitizedData;
            }
        }

        private bool TrySanitizeTokenValue(JToken token, out string sanitizedData)
        {
            sanitizedData = null;
            var jsonString = token?.Value<string>();

            if (string.IsNullOrWhiteSpace(jsonString))
                return false;

            try
            {
                var detectionResults = _masker.DetectSecrets(jsonString);
                if (!detectionResults.Any())
                    return false;

                sanitizedData = _masker.MaskSecrets(jsonString);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while sanitizing the test recording file:");
                Console.WriteLine($"Raw token: {jsonString}");
                Console.WriteLine($"Error message: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");

                return false;
            }
        }
    }
}
