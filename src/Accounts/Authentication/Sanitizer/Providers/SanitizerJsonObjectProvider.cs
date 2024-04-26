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

using Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Services;
using Microsoft.WindowsAzure.Commands.Common.Sanitizer;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Providers
{
    internal class SanitizerJsonObjectProvider : SanitizerProviderBase
    {
        internal override SanitizerProviderType ProviderType => SanitizerProviderType.JsonObject;

        public SanitizerJsonObjectProvider(ISanitizerService service) : base(service) { }

        public override void SanitizeValue(object sanitizingObject, Stack<object> sanitizingStack, ISanitizerProviderResolver resolver, SanitizerProperty property, SanitizerTelemetry telemetry)
        {
            if (sanitizingObject is JObject objJson)
            {
                foreach (var prop in objJson.Properties())
                {
                    var propValue = prop.Value;
                    if (propValue != null)
                    {
                        switch (propValue.Type)
                        {
                            case JTokenType.String:
                                if (Service.TrySanitizeData(propValue.Value<string>(), out string sanitizedData))
                                {
                                    telemetry.SecretsDetected = true;
                                    var propertyPath = ResolvePropertyPath(property);
                                    if (!string.IsNullOrEmpty(propertyPath))
                                    {
                                        telemetry.DetectedProperties.Add(propertyPath);
                                    }
                                }
                                break;
                            case JTokenType.Array:
                            case JTokenType.Object:
                                var provider = resolver.ResolveProvider(propValue.GetType());
                                provider?.SanitizeValue(propValue, sanitizingStack, resolver, property, telemetry);
                                break;
                        }
                    }
                }
            }
        }
    }
}
