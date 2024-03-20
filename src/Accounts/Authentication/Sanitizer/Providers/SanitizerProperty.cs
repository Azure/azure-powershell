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
using System.Reflection;

namespace Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Providers
{
    public class SanitizerProperty
    {
        public string PropertyName { get; private set; }

        public Type PropertyType { get; private set; }

        internal PropertyInfo ValueSupplier { get; private set; }

        internal SanitizerProperty ParentProperty { get; set; }

        public SanitizerProperty(PropertyInfo property)
        {
            var fullPropName = property.Name;
            PropertyName = fullPropName.Contains(".") ? fullPropName.Substring(fullPropName.LastIndexOf('.') + 1) : fullPropName;
            PropertyType = property.PropertyType;
            ValueSupplier = property;
        }

        public object GetValue(object instance)
        {
            try
            {
                return ValueSupplier.GetValue(instance);
            }
            catch
            {
                // Ignore exceptions
            }

            return null;
        }
    }
}
