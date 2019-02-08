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
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


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

        public static bool CanConvertFrom(dynamic sv)
        {
            var result = true;
            try
            {
                // check if this has required parameters...
                sv?.Id?.GetType();
                sv?.Message?.GetType();
                sv?.Parameter?.GetType();
                sv?.Value?.GetType();
                sv?.RequestMessage?.GetType();
                sv?.ResponseMessage?.GetType();
                sv?.Cancel?.GetType();
            }
            catch
            {
                return false;
            }
            return result;
        }

        public static EventData ConvertFrom(dynamic sv)
        {
            try
            {
                return new EventData
                {
                    Id = sv.Id,
                    Message = sv.Message,
                    Parameter = sv.Parameter,
                    Value = sv.Value,
                    RequestMessage = sv.RequestMessage,
                    ResponseMessage = sv.ResponseMessage,
                    Cancel = sv.Cancel
                };
            }
            catch
            {
            }
            return null;
        }
    }

}