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
