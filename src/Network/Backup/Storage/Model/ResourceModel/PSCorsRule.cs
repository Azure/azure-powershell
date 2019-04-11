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

using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using XTable = Microsoft.Azure.Cosmos.Table;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel
{
    public class PSCorsRule
    {
        public string[] AllowedOrigins { get; set; }

        public string[] AllowedHeaders { get; set; }

        public string[] ExposedHeaders { get; set; }

        public string[] AllowedMethods { get; set; }

        public int MaxAgeInSeconds { get; set; }

        /// <summary>
        /// Parse Cors Rules from XSCL to PSCorsRule Array
        /// </summary>
        /// <param name="corsProperties">Cors Rules from XSCL</param>
        /// <returns>PSCorsRule Array</returns>
        public static PSCorsRule[] ParseCorsRules(CorsProperties corsProperties)
        {
            List<PSCorsRule> ruleList = new List<PSCorsRule>();

            if (corsProperties != null && corsProperties.CorsRules != null)
            {
                foreach (var corsRule in corsProperties.CorsRules)
                {
                    PSCorsRule psCorsRule = new PSCorsRule();
                    psCorsRule.AllowedOrigins = ListToArray(corsRule.AllowedOrigins);
                    psCorsRule.AllowedHeaders = ListToArray(corsRule.AllowedHeaders);
                    psCorsRule.ExposedHeaders = ListToArray(corsRule.ExposedHeaders);
                    psCorsRule.AllowedMethods = ConvertCorsHttpMethodToString(corsRule.AllowedMethods);
                    psCorsRule.MaxAgeInSeconds = corsRule.MaxAgeInSeconds;
                    ruleList.Add(psCorsRule);
                }
            }

            return ruleList.ToArray();
        }

        /// <summary>
        /// Parse Cors Rules from OLD XSCL to PSCorsRule Array
        /// </summary>
        /// <param name="corsProperties">Cors Rules from XSCL</param>
        /// <returns>PSCorsRule Array</returns>
        public static PSCorsRule[] ParseCorsRules(XTable.CorsProperties corsProperties)
        {
            List<PSCorsRule> ruleList = new List<PSCorsRule>();

            if (corsProperties != null && corsProperties.CorsRules != null)
            {
                foreach (var corsRule in corsProperties.CorsRules)
                {
                    PSCorsRule psCorsRule = new PSCorsRule();
                    psCorsRule.AllowedOrigins = ListToArray(corsRule.AllowedOrigins);
                    psCorsRule.AllowedHeaders = ListToArray(corsRule.AllowedHeaders);
                    psCorsRule.ExposedHeaders = ListToArray(corsRule.ExposedHeaders);
                    psCorsRule.AllowedMethods = ConvertCorsHttpMethodToString(corsRule.AllowedMethods);
                    psCorsRule.MaxAgeInSeconds = corsRule.MaxAgeInSeconds;
                    ruleList.Add(psCorsRule);
                }
            }

            return ruleList.ToArray();
        }

        /// <summary>
        /// Parse CorsHttpMethods from XSCL to String Array
        /// </summary>
        /// <param name="methods">CorsHttpMethods from XSCL</param>
        /// <returns>String Array</returns>
        private static string[] ConvertCorsHttpMethodToString(CorsHttpMethods methods)
        {
            List<string> methodList = new List<string>();

            foreach (CorsHttpMethods methodValue in Enum.GetValues(typeof(CorsHttpMethods)).Cast<CorsHttpMethods>())
            {
                if (methodValue != CorsHttpMethods.None && (methods & methodValue) != 0)
                {
                    methodList.Add(methodValue.ToString());
                }
            }

            return methodList.ToArray();
        }

        /// <summary>
        /// Parse CorsHttpMethods from OLD XSCL to String Array
        /// </summary>
        /// <param name="methods">CorsHttpMethods from XSCL</param>
        /// <returns>String Array</returns>
        private static string[] ConvertCorsHttpMethodToString(XTable.CorsHttpMethods methods)
        {
            List<string> methodList = new List<string>();

            foreach (XTable.CorsHttpMethods methodValue in Enum.GetValues(typeof(XTable.CorsHttpMethods)).Cast<XTable.CorsHttpMethods>())
            {
                if (methodValue != XTable.CorsHttpMethods.None && (methods & methodValue) != 0)
                {
                    methodList.Add(methodValue.ToString());
                }
            }

            return methodList.ToArray();
        }

        /// <summary>
        /// Parse String list to String Array for parse CorsRule 
        /// </summary>
        /// <param name="stringList">String list</param>
        /// <returns>String Array</returns>
        private static string[] ListToArray(IList<string> stringList)
        {
            if (null == stringList)
            {
                return null;
            }

            string[] stringArray = new string[stringList.Count];
            stringList.CopyTo(stringArray, 0);
            return stringArray;
        }
    }
}
