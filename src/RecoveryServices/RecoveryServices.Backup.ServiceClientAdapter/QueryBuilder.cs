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
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    /// <summary>
    /// Utility to construct the OData query string to be used with the service adapter APIs.
    /// </summary>
    public class QueryBuilder
    {
        /// <summary>
        /// An instance of query builder object.
        /// </summary>
        public static QueryBuilder Instance
        {
            get
            {
                return new QueryBuilder();
            }
        }

        /// <summary>
        /// Constructs the query string given the query object - 
        /// whose properties are the query segments.
        /// </summary>
        /// <param name="queryObject">The query object.</param>
        /// <returns>Query string.</returns>
        public string GetQueryString(object queryObject)
        {
            var properties = queryObject.GetType().GetProperties(
                BindingFlags.Public | BindingFlags.Instance);
            string queryString = string.Empty;
            List<string> queryStrings = new List<string>();
            foreach (var property in properties)
            {
                var leftHandSide = property.Name.ToCamelCase();

                var rightHandSide = string.Empty;

                if (property.PropertyType.IsGenericType &&
                         property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var genericArguments = property.PropertyType.GetGenericArguments();
                    if (genericArguments.Any(type => type == typeof(DateTime)))
                    {
                        if (property.GetValue(queryObject) != null)
                        {
                            var dateTime = (DateTime)property.GetValue(queryObject);
                            DateTimeFormatInfo dateFormat = new CultureInfo("en-US").DateTimeFormat;
                            rightHandSide = string.Format(
                                "'{0}'",
                                dateTime.ToUniversalTime().ToString(
                                    "yyyy-MM-dd hh:mm:ss tt", dateFormat));
                        }
                        else
                        {
                            rightHandSide = null;
                        }
                    }
                    else if (genericArguments.Any(type => type.IsEnum))
                    {
                        rightHandSide = (property.GetValue(queryObject) != null) ?
                        string.Format("'{0}'", property.GetValue(queryObject).ToString()) : null;
                    }
                    else if (genericArguments.Any(type => type == typeof(bool)))
                    {
                        rightHandSide = (property.GetValue(queryObject) != null) ?
                        string.Format("'{0}'", property.GetValue(queryObject).ToString()) : null;
                    }
                }
                else
                {
                    rightHandSide = (property.GetValue(queryObject) != null) ?
                        string.Format("'{0}'", property.GetValue(queryObject).ToString()) : null;
                }

                if (!string.IsNullOrEmpty(rightHandSide))
                {
                    queryStrings.Add(leftHandSide + " eq " + rightHandSide);
                }
            }

            queryString = string.Join(" and ", queryStrings);

            return queryString;
        }
    }
}
