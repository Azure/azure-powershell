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

namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// A PowerShell PSTypeConverter to adapt an <c>EventData</c> object that has been passed.
    /// Usually used between modules.
    /// </summary>
    public class EventDataConverter : System.Management.Automation.PSTypeConverter
    {
        public override bool CanConvertTo(object sourceValue, Type destinationType) => false;
        public override object ConvertTo(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase) => null;
        public override bool CanConvertFrom(dynamic sourceValue, Type destinationType) => destinationType == typeof(EventData) && CanConvertFrom(sourceValue);
        public override object ConvertFrom(dynamic sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase) => ConvertFrom(sourceValue);

        /// <summary>
        ///  Verifies that a given object has the required members to convert it to the target type (EventData)
        /// 
        ///  Uses a dynamic type so that it is able to use the simplest code without excessive checking.
        /// </summary>
        /// <param name="sourceValue">The instance to verify</param>
        /// <returns>True, if the object has all the required parameters.</returns>
        public static bool CanConvertFrom(dynamic sourceValue)
        {
            try
            {
                // check if this has *required* parameters...
                sourceValue?.Id?.GetType();
                sourceValue?.Message?.GetType();
                sourceValue?.Cancel?.GetType();

                // remaining parameters are not *required*, 
                // but if they have values, it will copy them at conversion time.
            }
            catch
            {
                // if anything throws an exception (because it's null, or doesn't have that member)
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns result of the delegate as the expected type, or default(T)
        /// 
        /// This isolates any exceptions from the consumer.
        /// </summary>
        /// <param name="srcValue">A delegate that returns a value</param>
        /// <typeparam name="T">The desired output type</typeparam>
        /// <returns>The value from the function if the type is correct</returns>
        private static T To<T>(Func<T> srcValue)
        {
            try { return srcValue(); }
            catch { return default(T); }
        }

        /// <summary>
        /// Converts an incoming object to the expected type by treating the incoming object as a dynamic, and coping the expected values.
        /// </summary>
        /// <param name="sourceValue">the incoming object</param>
        /// <returns>EventData</returns>
        public static EventData ConvertFrom(dynamic sourceValue)
        {
            return new EventData
            {
                Id = To<string>(() => sourceValue.Id),
                Message = To<string>(() => sourceValue.Message),
                Parameter = To<string>(() => sourceValue.Parameter),
                Value = To<double>(() => sourceValue.Value),
                RequestMessage = To<System.Net.Http.HttpRequestMessage>(() => sourceValue.RequestMessage),
                ResponseMessage = To<System.Net.Http.HttpResponseMessage>(() => sourceValue.ResponseMessage),
                Cancel = To<Action>(() => sourceValue.Cancel),
            };
        }
    }

}