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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Collections;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Profile.Models
{
    public class AzureContextConverter : PSTypeConverter
    {

        bool IsContainerType(PSObject source)
        {
            return source.HasProperty("Context");
        }

        bool IsContextType(PSObject source)
        {
            return source.HasProperty( "Account") && source.HasProperty("Tenant");
        }

        public override bool CanConvertFrom(object sourceValue, Type destinationType)
        {
            bool result = false;
            if (sourceValue != null && destinationType != null)
            {
                PSObject sourceObject = sourceValue as PSObject;
                result = (IsContainerType(sourceObject) || IsContextType(sourceObject)) && destinationType == typeof(IAzureContextContainer);
            }

            return result;
        }

        public override bool CanConvertFrom(PSObject sourceValue, Type destinationType)
        {
            bool result = false;
            if (sourceValue != null && destinationType != null)
            {
                result = IsContainerType(sourceValue) || IsContextType(sourceValue) && destinationType == typeof(IAzureContextContainer);
            }

            return result;
        }

        public override bool CanConvertTo(object sourceValue, Type destinationType)
        {
            return false;
        }

        public override bool CanConvertTo(PSObject sourceValue, Type destinationType)
        {
            return false;
        }

        public override object ConvertFrom(PSObject sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            object result = null;
            if (CanConvertFrom(sourceValue, destinationType))
            {
                if (IsContainerType(sourceValue))
                {
                    result = ConvertContainerObject(sourceValue);
                }
                else if (IsContextType(sourceValue))
                {
                    result = ConvertContextObject(sourceValue);
                }
            }

            return result;
        }

        public override object ConvertFrom(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            object result = null;
            if (CanConvertFrom(sourceValue, destinationType))
            {
                var sourceObject = sourceValue as PSObject;
                if (IsContainerType(sourceObject))
                {
                    result = ConvertContainerObject(sourceObject);
                }
                else if (IsContextType(sourceObject))
                {
                    result = ConvertContextObject(sourceObject);
                }
            }

            return result;
        }

        public override object ConvertTo(PSObject sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            return null;
        }


        public override object ConvertTo(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            return null;
        }

        object ConvertContainerObject(PSObject source)
        {
            PSAzureProfile result = source?.BaseObject as PSAzureProfile;
            if (result == null)
            {
                result = new PSAzureProfile();
                Hashtable envs;
                if (source.TryGetProperty(nameof(PSAzureProfile.Environments), out envs))
                {
                    AddEnvironments(envs, result.Environments);
                }

                PSObject context;
                if (source.TryGetProperty(nameof(PSAzureProfile.Context), out context))
                {
                    result.Context = new PSAzureContext(context);
                }
            }

            return (AzureRmProfile)result;
        }

        object ConvertContextObject(PSObject source)
        {
            PSAzureProfile result = new PSAzureProfile();
            var contextSource = source?.BaseObject as PSAzureContext;
            if (contextSource != null)
            {
                result.Context = contextSource;
            }
            else
            {
                result.Context = new PSAzureContext(source);

            }

            return (AzureRmProfile)result;
        }

        void AddEnvironments(Hashtable source, IDictionary<string, PSAzureEnvironment>destination)
        {
            foreach (var key in source.Keys)
            {
                var name = key as string;
                if (name != null)
                {
                    var value = source[key] as PSObject;
                    if (value != null)
                    {
                        destination.Add(name, new PSAzureEnvironment(value));
                    }
                }
            }
        }
    }
}
