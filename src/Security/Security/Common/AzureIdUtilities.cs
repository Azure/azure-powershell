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
// ------------------------------------

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.SecurityCenter.Common
{
    public static class AzureIdUtilities
    {
        private static Regex locationRegex = new Regex("/locations/(?<Location>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex rgRegex = new Regex("/resourceGroups/(?<RG>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex subscriptionRegex = new Regex("/subscriptions/(?<subscriptionId>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex regulatoryStandardRegex = new Regex("regulatoryComplianceStandards/(?<StandardName>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex regulatoryStandardControlRegex = new Regex("regulatoryComplianceControls/(?<ControlName>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex regulatoryStandardAssessmentRegex = new Regex("regulatoryComplianceAssessments/(?<AssessmentName>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex AssessmentNameRegex = new Regex("assessments/(?<AssessmentName>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex ExtendedResourceRegex = new Regex("(?<extendedId>.*?)/providers/microsoft.security.*?", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex iotHubNameRegex = new Regex("/iotHubs/(?<iotHubName>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex iotSolutionNameRegex = new Regex("/iotSecuritySolutions/(?<iotSolutionName>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        

        public static string GetResourceName(string id)
        {
            return id.Split('/').Last();
        }

        public static string GetIotHubResourceName(string id)
        {
            var match = iotHubNameRegex.Match(id);

            if (match.Success != true)
            {
                throw new ArgumentException("Invalid format of the resource identifier.", "id");
            }

            return match.Groups["iotHubName"].Value;
        }

        public static string GetIotSolutionResourceName(string id)
        {
            var match = iotSolutionNameRegex.Match(id);

            if (match.Success != true)
            {
                throw new ArgumentException("Invalid format of the resource identifier.", "id");
            }

            return match.Groups["iotSolutionName"].Value;
        }

        public static string GetResourceLocation(string id)
        {
            var match = locationRegex.Match(id);

            if (match.Success != true)
            {
                throw new ArgumentException("Invalid format of the resource identifier.", "id");
            }

            return match.Groups["Location"].Value;
        }

        public static string GetResourceGroup(string id)
        {
            var match = rgRegex.Match(id);

            if (match.Success != true)
            {
                return null;
            }

            return match.Groups["RG"].Value;
        }

        public static string GetResourceSubscription(string id)
        {
            var match = subscriptionRegex.Match(id);

            if (match.Success != true)
            {
                throw new ArgumentException("Invalid format of the resource identifier.", "id");
            }

            return match.Groups["subscriptionId"].Value;
        }

        public static string GetRegulatoryStandardName(string id)
        {
            var match = regulatoryStandardRegex.Match(id);

            if (match.Success != true)
            {
                throw new ArgumentException("Invalid format of the resource identifier.", "standardName");
            }

            return match.Groups["StandardName"].Value;
        }

        /// <summary>
        /// Parse from the resourceId the control name
        /// </summary>
        /// <param name="id">resource id</param>
        /// <param name="isLast">true if the control name is the last element in the id</param>
        /// <returns>Control name</returns>
        public static string GetRegulatoryStandardControlName(string id, bool isLast)
        {
            if (isLast)
            {
                return id.Split('/').Last();
            }
            else
            {
                var match = regulatoryStandardControlRegex.Match(id);

                if (match.Success != true)
                {
                    throw new ArgumentException("Invalid format of the resource identifier.", "ControlName");
                }

                return match.Groups["ControlName"].Value;
            }
        }

        /// <summary>
        /// Parse from the resourceId the assessment name
        /// </summary>
        /// <param name="id">resource id</param>
        /// <param name="isLast">true if the control name is the last element in the id</param>
        /// <returns>Assessment name</returns>
        public static string GetRegulatoryStandardAssessmentName(string id, bool isLast)
        {
            if (isLast)
            {
                return id.Split('/').Last();
            }
            else
            {
                var match = regulatoryStandardAssessmentRegex.Match(id);

                if (match.Success != true)
                {
                    throw new ArgumentException("Invalid format of the resource identifier.", "AssessmentName");
                }

                return match.Groups["AssessmentName"].Value;
            }
        }

        /// <summary>
        /// extracting the extended resource ID from an extension resource
        /// </summary>
        /// <param name="id">resource id</param>
        /// <returns>Assessment name</returns>
        public static string GetExtendedResourceId(string id)
        {
            var match = ExtendedResourceRegex.Match(id);

            if (match.Success != true)
            {
                throw new ArgumentException("Invalid format of the extension resource identifier.", nameof(id));
            }

            return match.Groups["extendedId"].Value;
        }

        /// <summary>
        /// Gets the name of the resource above the nested resource
        /// </summary>
        public static string GetAssessmentResourceName(string id)
        {
            var match = AssessmentNameRegex.Match(id);

            if (match.Success != true)
            {
                throw new ArgumentException("Invalid format of the extension resource identifier.", nameof(id));
            }

            return match.Groups["AssessmentName"].Value;
        }
    }
}
