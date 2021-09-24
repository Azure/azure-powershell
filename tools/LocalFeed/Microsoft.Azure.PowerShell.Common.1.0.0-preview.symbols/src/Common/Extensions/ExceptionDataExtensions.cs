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

using System.Collections;

namespace Microsoft.Azure.Commands.Common
{
    internal static class ExceptionDataExtensions
    {
        public static T GetValue<T>(this IDictionary data, string key) where T : class
        {
            return data.Contains(key) ? data[key] as T : null;
        }

        public static T? GetNullableValue<T>(this IDictionary data, string key) where T : struct
        {
            return data.Contains(key) ? (T?)data[key] : null;
        }

        public static void SetValue<T>(this IDictionary data, string key, T value)
        {
            if (value != null)
            {
                data[key] = value;
            }
            else if (data.Contains(key)) //remove key if value is null
            {
                data.Remove(key);
            }
        }
    }
}
