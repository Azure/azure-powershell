/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    [System.ComponentModel.TypeConverter(typeof(AsyncOperationResponseTypeConverter))]
    public class AsyncOperationResponse
    {
        private string _target;
        public string Target { get => _target; set => _target = value; }
        public AsyncOperationResponse()
        {
        }
        internal AsyncOperationResponse(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json)
        {
            // pull target 
            { Target = If(json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("target"), out var _v) ? (string)_v : (string)Target; }
        }
        public string ToJsonString()
        {
            return $"{{ \"target\" : \"{this.Target}\" }}";
        }

        public static AsyncOperationResponse FromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json ? new AsyncOperationResponse(json) : null;
        }


        /// <summary>
        /// Creates a new instance of <see cref="AdministratorDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static AsyncOperationResponse FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode.Parse(jsonText));

    }

    public partial class AsyncOperationResponseTypeConverter : System.Management.Automation.PSTypeConverter
    {

        /// <summary>
        /// Determines if the converter can convert the <see cref="sourceValue"/> parameter to the <see cref="destinationType" />
        /// parameter.
        /// </summary>
        /// <param name="sourceValue">the <see cref="System.Object"/> to convert from</param>
        /// <param name="destinationType">the <see cref="System.Type" /> to convert to</param>
        /// <returns>
        /// <c>true</c> if the converter can convert the <see cref="sourceValue"/> parameter to the <see cref="destinationType" />
        /// parameter, otherwise <c>false</c>.
        /// </returns>
        public override bool CanConvertFrom(object sourceValue, global::System.Type destinationType) => CanConvertFrom(sourceValue);

        /// <summary>
        /// Determines if the converter can convert the <see cref="sourceValue"/> parameter to the <see cref="destinationType" />
        /// parameter.
        /// </summary>
        /// <param name="sourceValue">the <see cref="System.Object" /> instance to check if it can be converted to the <see cref="AsyncOperationResponse"
        /// /> type.</param>
        /// <returns>
        /// <c>true</c> if the instance could be converted to a <see cref="AsyncOperationResponse" /> type, otherwise <c>false</c>
        /// </returns>
        public static bool CanConvertFrom(dynamic sourceValue)
        {
            if (null == sourceValue)
            {
                return true;
            }
            global::System.Type type = sourceValue.GetType();
            if (typeof(System.Management.Automation.PSObject).IsAssignableFrom(type))
            {
                // we say yest to PSObjects
                return true;
            }
            if (typeof(global::System.Collections.IDictionary).IsAssignableFrom(type))
            {
                // we say yest to Hashtables/dictionaries
                return true;
            }
            try
            {
                if (null != sourceValue.ToJsonString())
                {
                    return true;
                }
            }
            catch
            {
                // Not one of our objects
            }
            try
            {
                string text = sourceValue.ToString()?.Trim();
                return true == text?.StartsWith("{") && true == text?.EndsWith("}") && Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode.Parse(text).Type == Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonType.Object;
            }
            catch
            {
                // Doesn't look like it can be treated as JSON
            }
            return false;
        }

        /// <summary>
        /// Determines if the <see cref="sourceValue" /> parameter can be converted to the <see cref="destinationType" /> parameter
        /// </summary>
        /// <param name="sourceValue">the <see cref="System.Object"/> to convert from</param>
        /// <param name="destinationType">the <see cref="System.Type" /> to convert to</param>
        /// <returns>
        /// <c>true</c> if the converter can convert the <see cref="sourceValue" /> parameter to the <see cref="destinationType" />
        /// parameter, otherwise <c>false</c>
        /// </returns>
        public override bool CanConvertTo(object sourceValue, global::System.Type destinationType) => false;

        /// <summary>
        /// Converts the <see cref="sourceValue" /> parameter to the <see cref="destinationType" /> parameter using <see cref="formatProvider"
        /// /> and <see cref="ignoreCase" />
        /// </summary>
        /// <param name="sourceValue">the <see cref="System.Object"/> to convert from</param>
        /// <param name="destinationType">the <see cref="System.Type" /> to convert to</param>
        /// <param name="formatProvider">not used by this TypeConverter.</param>
        /// <param name="ignoreCase">when set to <c>true</c>, will ignore the case when converting.</param>
        /// <returns>
        /// an instance of <see cref="AsyncOperationResponse" />, or <c>null</c> if there is no suitable conversion.
        /// </returns>
        public override object ConvertFrom(object sourceValue, global::System.Type destinationType, global::System.IFormatProvider formatProvider, bool ignoreCase) => ConvertFrom(sourceValue);

        /// <summary>
        /// Converts the <see cref="sourceValue" /> parameter to the <see cref="destinationType" /> parameter using <see cref="formatProvider"
        /// /> and <see cref="ignoreCase" />
        /// </summary>
        /// <param name="sourceValue">the value to convert into an instance of <see cref="AsyncOperationResponse" />.</param>
        /// <returns>
        /// an instance of <see cref="AsyncOperationResponse" />, or <c>null</c> if there is no suitable conversion.
        /// </returns>
        public static object ConvertFrom(dynamic sourceValue)
        {
            if (null == sourceValue)
            {
                return null;
            }
            global::System.Type type = sourceValue.GetType();
            if (typeof(AsyncOperationResponse).IsAssignableFrom(type))
            {
                return sourceValue;
            }
            try
            {
                return AsyncOperationResponse.FromJsonString(typeof(string) == sourceValue.GetType() ? sourceValue : sourceValue.ToJsonString()); ;
            }
            catch
            {
                // Unable to use JSON pattern
            }

            if (typeof(System.Management.Automation.PSObject).IsAssignableFrom(type))
            {
                return new AsyncOperationResponse { Target = (sourceValue as System.Management.Automation.PSObject).GetValueForProperty<string>("target", "", global::System.Convert.ToString) };
            }
            if (typeof(global::System.Collections.IDictionary).IsAssignableFrom(type))
            {
                return new AsyncOperationResponse { Target = (sourceValue as global::System.Collections.IDictionary).GetValueForProperty<string>("target", "", global::System.Convert.ToString) };
            }
            return null;
        }

        /// <summary>NotImplemented -- this will return <c>null</c></summary>
        /// <param name="sourceValue">the <see cref="System.Object"/> to convert from</param>
        /// <param name="destinationType">the <see cref="System.Type" /> to convert to</param>
        /// <param name="formatProvider">not used by this TypeConverter.</param>
        /// <param name="ignoreCase">when set to <c>true</c>, will ignore the case when converting.</param>
        /// <returns>will always return <c>null</c>.</returns>
        public override object ConvertTo(object sourceValue, global::System.Type destinationType, global::System.IFormatProvider formatProvider, bool ignoreCase) => null;
    }
}