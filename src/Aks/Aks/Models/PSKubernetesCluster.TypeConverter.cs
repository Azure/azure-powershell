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
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Aks.Models
{
    class PSKubernetesClusterTypeConverter : PSTypeConverter
    {
        public override bool CanConvertFrom(object sourceValue, Type destinationType)
        {
            return CanConvertFrom(sourceValue);
        }

        private bool CanConvertFrom(dynamic sourceValue)
        {
            if (null == sourceValue)
            {
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
                return false;
            }

            return false;
        }

        public override bool CanConvertTo(object sourceValue, Type destinationType)
        {
            throw new NotImplementedException();
        }

        public override object ConvertFrom(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            return ConvertFrom(sourceValue);
        }

        private object ConvertFrom(dynamic sourceValue)
        {
            if (null == sourceValue)
            {
                return null;
            }

            try
            {
                return PSKubernetesCluster.FromJsonString(typeof(string) == sourceValue.GetType() ? sourceValue : sourceValue.ToJsonString()); ;
            }
            catch
            {
                // Unable to use JSON pattern
            }
            return null;
        }

        public override object ConvertTo(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            throw new NotImplementedException();
        }
    }
}
