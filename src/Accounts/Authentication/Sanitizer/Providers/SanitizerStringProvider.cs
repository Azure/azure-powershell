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

using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Services;
using Microsoft.WindowsAzure.Commands.Common.Sanitizer;

namespace Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Providers
{
    internal class SanitizerStringProvider : SanitizerProviderBase
    {
        internal override SanitizerProviderType ProviderType => SanitizerProviderType.String;

        public SanitizerStringProvider(ISanitizerService service) : base(service) { }

        public override void SanitizeValue(object sanitizingObject, Stack<object> sanitizingStack, ISanitizerProviderResolver resolver, SanitizerProperty property, SanitizerTelemetry telemetry)
        {
            var propertyValue = property?.GetValue(sanitizingObject) ?? sanitizingObject;
            if (propertyValue is string data)
            {
                if (Service.TrySanitizeData(data, out string sanitizedData))
                {
                    telemetry.SecretsDetected = true;
                    var propertyPath = ResolvePropertyPath(property);
                    if (!string.IsNullOrEmpty(propertyPath))
                    {
                        telemetry.DetectedProperties.Add(propertyPath);
                    }
                }
            }
        }
    }
}
