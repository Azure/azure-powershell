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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Methods for all extensible models - allows retrieving and setting extension proeprties without knowing the underlying implementation
    /// </summary>
    public static class ModelExtensions
    {
        /// <summary>
        /// Safely get the given property for the model
        /// </summary>
        /// <param name="model">The model to search</param>
        /// <param name="propertyKey">The given key of the property</param>
        /// <returns>The value of the property in the given model, or null if the property is not set</returns>
        public static string GetProperty(this IExtensibleModel model, string propertyKey)
        {
            string result = null;
            if (model.IsPropertySet(propertyKey))
            {
                result = model.ExtendedProperties.GetProperty(propertyKey);
            }

            return result;
        }

        /// <summary>
        /// Safely get the given property for the model as an array of string.
        /// </summary>
        /// <param name="model">The model to search</param>
        /// <param name="propertyKey">The given key of the property</param>
        /// <returns>The value of the property in the given model, or an empty array if the property is not set</returns>
        public static string[] GetPropertyAsArray(this IExtensibleModel model, string propertyKey)
        {
            string[] result = new string[0];
            if (model.IsPropertySet(propertyKey))
            {
                result = model.ExtendedProperties.GetPropertyAsArray(propertyKey);
            }

            return result;
        }

        /// <summary>
        /// Safely set the given property for the model to the given values.  If more than one value is provided, values are 
        /// represented as a comma-separated list
        /// </summary>
        /// <param name="model">The model to change.</param>
        /// <param name="propertyKey">The property to set</param>
        /// <param name="values">The value(s) to set for the property</param>
        public static void SetProperty(this IExtensibleModel model, string propertyKey, params string[] values)
        {
            if (propertyKey != null)
            {
                model.ExtendedProperties.SetProperty(propertyKey, values);
            }
        }

        /// <summary>
        /// Merge the given values with the current property value in the given model.  If the property is not set, 
        /// the value is replaced
        /// </summary>
        /// <param name="model">The model to change.</param>
        /// <param name="propertyKey">The property to set</param>
        /// <param name="values">The value(s) to set for the property</param>
        public static void SetOrAppendProperty(this IExtensibleModel model, string propertyKey, params string[] values)
        {
            if (propertyKey != null)
            {
                model.ExtendedProperties.SetOrAppendProperty(propertyKey, values);
            }
        }

        /// <summary>
        /// Determine if the given proeprty is set in the model
        /// </summary>
        /// <param name="model">The model to check</param>
        /// <param name="propertyKey">The property to check</param>
        /// <returns>True if the property is set, otherwise false</returns>
        public static bool IsPropertySet(this IExtensibleModel model, string propertyKey)
        {
            bool result = false;
            if (propertyKey != null)
            {
                result = model.ExtendedProperties.IsPropertySet(propertyKey);
            }

            return result;
        }

        /// <summary>
        /// Copy the properties from the given model object
        /// </summary>
        /// <param name="model"></param>
        /// <param name="source"></param>
        public static void CopyPropertiesFrom(this IExtensibleModel model, IExtensibleModel source)
        {
            if (model != null && source != null)
            {
                foreach (var item in source.ExtendedProperties)
                {
                    model.ExtendedProperties[item.Key] = item.Value;
                }
            }
        }

        /// <summary>
        /// Copy Unset propeties from another extensible model to this one
        /// </summary>
        /// <param name="model"></param>
        /// <param name="newModel"></param>
        public static void UpdateProperties(this IExtensibleModel model, IExtensibleModel newModel)
        {
            if (model != null && newModel != null)
            {
                foreach (var item in newModel.ExtendedProperties)
                {
                    model.SetProperty(item.Key, item.Value);
                }
            }
        }
    }
}
