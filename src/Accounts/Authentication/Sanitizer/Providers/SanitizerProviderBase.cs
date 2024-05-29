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
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Providers
{
    public abstract class SanitizerProviderBase
    {
        private const int MaxDepth = 10;

        protected ISanitizerService Service { get; private set; }

        public SanitizerProviderBase(ISanitizerService service)
        {
            Service = service;
        }

        protected string ResolvePropertyPath(SanitizerProperty property)
        {
            if (property == null)
                return null;

            var propertyPath = property.PropertyName;
            var parentProperty = property.ParentProperty;
            while (parentProperty != null)
            {
                propertyPath = $"{parentProperty.PropertyName}.{propertyPath}";
                parentProperty = parentProperty.ParentProperty;
            }
            return propertyPath;
        }

        protected bool ShouldProcessProperty(SanitizerProperty property, SanitizerTelemetry telemetry)
        {
            if (property == null)
                return false;

            var currentProperty = property;
            var parentProperty = currentProperty.ParentProperty;

            for (var i = 0; i < MaxDepth; i++)
            {
                if (parentProperty == null)
                    return true;

                if (ReferenceEquals(property, parentProperty))
                    return false;

                currentProperty = parentProperty;
                parentProperty = currentProperty.ParentProperty;
            }

            telemetry.HasErrorInDetection = true;
            telemetry.DetectionError = new Exception($"Potential stack overflow exception may occurr on property: '{property.PropertyName}' declared in the object '{property.ValueSupplier.DeclaringType.FullName}' with type '{property.PropertyType.FullName}'");

            return false;
        }

        internal abstract SanitizerProviderType ProviderType { get; }

        public abstract void SanitizeValue(object sanitizingObject, Stack<object> sanitizingStack, ISanitizerProviderResolver resolver, SanitizerProperty property, SanitizerTelemetry telemetry);
    }
}
