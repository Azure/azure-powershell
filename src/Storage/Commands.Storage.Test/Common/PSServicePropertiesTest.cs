// ----------------------------------------------------------------------------------
//
// Copyright 2012 Microsoft Corporation
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.File;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common
{
    /// <summary>
    /// Unit test for Access Policy helper
    /// </summary>
    [TestClass]
    public class PSServicePropertiesTest : StorageTestBase
    {
        /// <summary>
        /// unit test for ParseCorsRules() functional 
        /// </summary>
        [TestMethod]
        public void ValidateParseCorsRulesTest()
        {
            CorsProperties coresproperties = PrepareCoresproperties();
            PSCorsRule[] pscores = PSCorsRule.ParseCorsRules(coresproperties);
            CompareCors(pscores, coresproperties);

            coresproperties = new CorsProperties();
            pscores = PSCorsRule.ParseCorsRules(coresproperties);
            CompareCors(pscores, coresproperties);

            coresproperties = null;
            pscores = PSCorsRule.ParseCorsRules(coresproperties);
            CompareCors(pscores, coresproperties);
        }

        /// <summary>
        /// unit test for new PSSeriviceProperties() functional 
        /// </summary>
        [TestMethod]
        public void ValidateParseServicePropertiesTest()
        {
            ServiceProperties serviceProperties = new ServiceProperties();
            serviceProperties.Cors = PrepareCoresproperties();
            serviceProperties.HourMetrics = new MetricsProperties("1.0");
            serviceProperties.HourMetrics.MetricsLevel = MetricsLevel.ServiceAndApi;
            serviceProperties.HourMetrics.RetentionDays = 1;
            serviceProperties.MinuteMetrics = new MetricsProperties("1.0");
            serviceProperties.MinuteMetrics.MetricsLevel = MetricsLevel.Service;
            serviceProperties.MinuteMetrics.RetentionDays = 3;
            serviceProperties.Logging = new LoggingProperties("1.0");
            serviceProperties.Logging.LoggingOperations = LoggingOperations.All;
            serviceProperties.Logging.RetentionDays = 5;
            serviceProperties.DefaultServiceVersion = "2017-04-17";
            PSSeriviceProperties pSSeriviceProperties = new PSSeriviceProperties(serviceProperties);
            CompareServiceProperties(pSSeriviceProperties, serviceProperties);

            serviceProperties = new ServiceProperties();
            pSSeriviceProperties = new PSSeriviceProperties(serviceProperties);
            CompareServiceProperties(pSSeriviceProperties, serviceProperties);

            serviceProperties = null;
            pSSeriviceProperties = new PSSeriviceProperties(serviceProperties);
            CompareServiceProperties(pSSeriviceProperties, serviceProperties);
        }

        /// <summary>
        /// Comapare PSServiceProperties and ServiceProperties, to make sure they are same content
        /// </summary>
        static private void CompareServiceProperties(PSSeriviceProperties pSSeriviceProperties, ServiceProperties serviceProperties)
        {
            if ((pSSeriviceProperties != null && pSSeriviceProperties.HourMetrics != null) || (serviceProperties != null && serviceProperties.HourMetrics != null))
            {
                Assert.AreEqual(serviceProperties.HourMetrics.Version, pSSeriviceProperties.HourMetrics.Version);
                Assert.AreEqual(serviceProperties.HourMetrics.MetricsLevel, pSSeriviceProperties.HourMetrics.MetricsLevel);
                Assert.AreEqual(serviceProperties.HourMetrics.RetentionDays, pSSeriviceProperties.HourMetrics.RetentionDays);
            }
            if ((pSSeriviceProperties != null && pSSeriviceProperties.MinuteMetrics != null) || (serviceProperties != null && serviceProperties.MinuteMetrics != null))
            {
                Assert.AreEqual(serviceProperties.MinuteMetrics.Version, pSSeriviceProperties.MinuteMetrics.Version);
                Assert.AreEqual(serviceProperties.MinuteMetrics.MetricsLevel, pSSeriviceProperties.MinuteMetrics.MetricsLevel);
                Assert.AreEqual(serviceProperties.MinuteMetrics.RetentionDays, pSSeriviceProperties.MinuteMetrics.RetentionDays);
            }
            if ((pSSeriviceProperties != null && pSSeriviceProperties.Logging != null) || (serviceProperties != null && serviceProperties.Logging != null))
            {
                Assert.AreEqual(serviceProperties.Logging.Version, pSSeriviceProperties.Logging.Version);
                Assert.AreEqual(serviceProperties.Logging.LoggingOperations, pSSeriviceProperties.Logging.LoggingOperations);
                Assert.AreEqual(serviceProperties.Logging.RetentionDays, pSSeriviceProperties.Logging.RetentionDays);
            }
            if ((pSSeriviceProperties != null && pSSeriviceProperties.Cors != null) || (serviceProperties != null && serviceProperties.Cors != null))
            {
                CompareCors(pSSeriviceProperties.Cors, serviceProperties.Cors);
            }
            if ((pSSeriviceProperties != null && pSSeriviceProperties.DefaultServiceVersion != null) || (serviceProperties != null && serviceProperties.DefaultServiceVersion != null))
            {
                Assert.AreEqual(serviceProperties.DefaultServiceVersion, pSSeriviceProperties.DefaultServiceVersion);
            }
        }

        /// <summary>
        /// Comapare PSCorsRule and CorsProperties, to make sure they are same content
        /// </summary>
        static private void CompareCors(PSCorsRule[] psCorsRules, CorsProperties corsProperties)
        {
            if ((psCorsRules == null || psCorsRules.Length == 0) 
                && (corsProperties == null || corsProperties.CorsRules == null || corsProperties.CorsRules.Count == 0))
            {
                return;
            }
            Assert.AreEqual(psCorsRules.Length, corsProperties.CorsRules.Count);
            int i = 0;
            foreach (CorsRule CorsRule in corsProperties.CorsRules)
            {
                PSCorsRule psCorsRule = psCorsRules[i];
                i++;
                CompareStrings(psCorsRule.AllowedHeaders, CorsRule.AllowedHeaders);
                CompareStrings(psCorsRule.ExposedHeaders, CorsRule.ExposedHeaders);
                CompareStrings(psCorsRule.AllowedOrigins, CorsRule.AllowedOrigins);
                Assert.AreEqual(psCorsRule.MaxAgeInSeconds, CorsRule.MaxAgeInSeconds);

                CorsHttpMethods psAllowedMethods = CorsHttpMethods.None;
                foreach (string method in psCorsRule.AllowedMethods)
                {
                    CorsHttpMethods allowedCorsMethod = CorsHttpMethods.None;
                    if (Enum.TryParse<CorsHttpMethods>(method, true, out allowedCorsMethod))
                    {
                        psAllowedMethods |= allowedCorsMethod;
                    }
                    else
                    {
                        throw new InvalidOperationException(string.Format("Can't parse {0} to CorsHttpMethods.", method));
                    }
                }

                Assert.AreEqual(psAllowedMethods, CorsRule.AllowedMethods);
            }
        }

        /// <summary>
        /// Comapare String Array and String List, to make sure they are same content
        /// </summary>
        static private void CompareStrings(string[] stringArray, IList<String> stringList)
        {
            if ((stringArray == null || stringArray.Length == 0) && (stringList == null || stringList.Count == 0))
            {
                return;
            }
            string[] stringArray2 = new string[stringList.Count];
            stringList.CopyTo(stringArray2, 0);
            Assert.AreEqual(stringArray.Length, stringArray2.Length);

            for(int i=0; i< stringArray.Length; i++)
            {
                Assert.AreEqual(stringArray[i], stringArray2[i]);
            }
        }

        /// <summary>
        /// Create a set of CorsRule that containers different parameters combination
        /// </summary>
        static private CorsProperties PrepareCoresproperties()
        {
            CorsProperties coresproperties = new CorsProperties();
            coresproperties.CorsRules.Add(
                    new CorsRule()
                    {
                        AllowedHeaders = new List<string>
                        {
                        "x-ms-meta-data*",
                        "x -ms-meta-target*",
                        "x -ms-meta-abc"
                        },
                        AllowedMethods = CorsHttpMethods.Connect | CorsHttpMethods.Delete | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Merge,
                        AllowedOrigins = new List<string>
                        {
                        "http://www.contoso.com",
                        "http://www.fabrikam.com"
                        },
                        ExposedHeaders = new List<string>
                        {
                        "x-ms-meta-*"
                        },
                        MaxAgeInSeconds = 100
                    });
            coresproperties.CorsRules.Add(
                new CorsRule()
                {
                    AllowedHeaders = new List<string>
                    {
                        "x -ms-meta-12345675754564*"
                    },
                    AllowedMethods = CorsHttpMethods.None,
                    AllowedOrigins = new List<string>
                    {
                        "http://www.abc23.com",
                        "https://www.fabrikam.com/*"
                    },
                    ExposedHeaders = new List<string>
                    {
                        "x-ms-meta-data*",
                        "x -ms-meta-target*",
                        "x -ms-meta-abc"
                    },
                    MaxAgeInSeconds = 2000
                });
            coresproperties.CorsRules.Add(
                new CorsRule()
                {
                    AllowedHeaders = new List<string>
                    {
                        "*"
                    },
                    AllowedMethods = CorsHttpMethods.Options | CorsHttpMethods.Post | CorsHttpMethods.Put | CorsHttpMethods.Trace,
                    AllowedOrigins = new List<string>
                    {
                        "*"
                    },
                    ExposedHeaders = new List<string>
                    {
                        "*",
                    },
                    MaxAgeInSeconds = 0
                });
            return coresproperties;
        }
    }
}
