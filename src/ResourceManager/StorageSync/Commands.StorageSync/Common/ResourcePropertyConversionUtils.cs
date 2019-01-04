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

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public static class ResourcePropertyConversionUtils
    {
        #region Property Handling Helpers

        /// <summary>
        /// Serializes nullable value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeNullableValue<T>(T? value) where T : struct
        {
            if (!value.HasValue)
            {
                return null;
            }

            return ResourcePropertyConversionUtils.SerializeValue(value.Value);
        }

        /// <summary>
        /// Serialize arbitrary value to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeValue<T>(T value)
        {
            if (typeof(T).IsEnum)
            {
                return value.ToString();
            }

            if (value != null)
            {
                return JsonConvert.SerializeObject(value);
            }

            return null;
        }

        public static Nullable<T> DeserializeNullableValue<T>(string stringValue) where T: struct
        {
            if (stringValue == null)
            {
                return null;
            }

            return DeserializeValue<T>(stringValue);
        }

        public static T DeserializeValue<T>(string stringValue)
        {
            if (typeof(T) == typeof(string))
            {
                return (T)(object)stringValue;
            }

            if (stringValue == null)
            {
                return default(T);
            }

            if (typeof(T).IsEnum && Enum.IsDefined(typeof(T), stringValue))
            {
                return (T)Enum.Parse(typeof(T), stringValue, true);
            }

            return JsonConvert.DeserializeObject<T>(stringValue);
        }

        public static Dictionary<string, string> GetCopyOrNull(IDictionary<string, string> input)
        {
            return input != null ? new Dictionary<string, string>(input) : null;
        }

        public static Dictionary<string, string> GetCopyOrEmpty(IDictionary<string, string> input)
        {
            return input != null ? new Dictionary<string, string>(input) : new Dictionary<string, string>();
        }
        #endregion
    }
}
