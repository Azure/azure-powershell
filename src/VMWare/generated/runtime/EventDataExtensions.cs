/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime
{
    using System;

    [System.ComponentModel.TypeConverter(typeof(EventDataConverter))]
    /// <summary>
    /// PowerShell-specific data on top of the llc# EventData
    /// </summary>
    ///	<remarks>
    /// In PowerShell, we add on the EventDataConverter to support sending events between modules.
    /// Obviously, this code would need to be duplcated on both modules.
    /// This is preferable to sharing a common library, as versioning makes that problematic.
    /// </remarks>
    public partial class EventData : EventArgs
    {
    }

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
                // and if they have values, it will copy them at conversion time.
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
                Cancel = To<Action>(() => sourceValue.Cancel)
            };
        }
    }
}