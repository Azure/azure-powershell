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
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Extensions
{
    public static class ManagedServicesUtility
    {
        // TODO: Remove these three string as well as breaking changes attributes for Oct. 27th change
        public const string UpcomingVersion = "1.0.3";
        public const string UpcomingVersionReleaseDate = "10/27/2020";
        public const string DeprecatedParameterDescription = "Parameter is being deprecated without being replaced";

        public static readonly Regex AssignmentRegex = new Regex(@"(.*?)/providers/microsoft.managedservices/registrationAssignments/(?<assignmentName>[^/]+)",
    RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex DefinitionRegex = new Regex(@"(.*?)/providers/microsoft.managedservices/registrationDefinitions/(?<definitionName>[^/]+)",
    RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static bool TryParseAssignmentScopeFromResourceId(string resourceId, out string scope)
        {
            return TryParseScopeFromResourceId(AssignmentRegex, resourceId, out scope);
        }

        public static bool TryParseDefinitionScopeFromResourceId(string resourceId, out string scope)
        {
            return TryParseScopeFromResourceId(DefinitionRegex, resourceId, out scope);
        }

        private static bool TryParseScopeFromResourceId(Regex regex, string resourceId, out string scope)
        {
            if (regex == null)
            {
                throw new ArgumentException("regex cannot be null");
            }

            if (resourceId == null)
            {
                throw new ArgumentException("resourceId cannot be be null");
            }

            scope = null;
            var match = regex.Match(resourceId);
            if (match.Success && match.Groups[1] != null)
            {
                scope = match.Groups[1].Value;
                return true;
            }

            return false;
        }
    }
}
