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

using Azure;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using static Microsoft.Azure.Commands.Synapse.Models.SynapseConstants;
using Operation = Azure.Operation;

namespace Microsoft.Azure.Commands.Synapse.Common
{
    public static class Utils
    {
        public static string ReadJsonFileContent(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            using (TextReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        public static Dictionary<string, string> ToDictionary(this Hashtable table)
        {
            if (table == null)
            {
                return new Dictionary<string, string>();
            }

            return table
              .Cast<DictionaryEntry>()
              .ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value);
        }

        internal static void CategorizedFiles(string[] referenceFiles, out IList<string> jars, out IList<string> files)
        {
            jars = new List<string>();
            files = new List<string>();
            foreach (var file in referenceFiles ?? new string[0])
            {
                var referenceFile = file.Trim();
                if (!string.IsNullOrEmpty(referenceFile))
                {
                    if (referenceFile.EndsWith(SynapseConstants.JarExtention))
                    {
                        jars.Add(referenceFile);
                    }
                    else
                    {
                        files.Add(referenceFile);
                    }
                }
            }
        }

        internal static string NormalizeUrl(string url)
        {
            if (AbfsUri.IsType(url))
            {
                return AbfsUri.Parse(url).GetUri().AbsoluteUri;
            }

            return url;
        }

        internal static string ReadFileAsText(this SynapseCmdletBase cmdlet, string filePath)
        {
            var powerShellDestinationPath = cmdlet.SessionState.Path.GetUnresolvedProviderPathFromPSPath(filePath);
            if (!AzureSession.Instance.DataStore.FileExists(powerShellDestinationPath))
            {
                throw new AzPSFileNotFoundException(string.Format(Resources.FilePathDoesNotExist, powerShellDestinationPath), filePath);
            }

            return AzureSession.Instance.DataStore.ReadFileAsText(powerShellDestinationPath);
        }

        internal static Exception CreateAzurePowerShellException(ErrorResponseException ex)
        {
            var message = GetAggregatedErrorMessage(ex.Message, ex.Body?.Error?.Message, ex.Body?.Error?.Details?.Select(d => d.Message));
            return CreateAzurePowerShellException(ex.Response.StatusCode, message, ex);
        }

        internal static Exception CreateAzurePowerShellException(this CloudException ex)
        {
            var message = GetAggregatedErrorMessage(ex.Message, ex.Body?.Message, ex.Body?.Details?.Select(d => d.Message));
            return CreateAzurePowerShellException(ex.Response.StatusCode, message, ex);
        }

        internal static Exception CreateAzurePowerShellException(RequestFailedException ex)
        {
            var message = GetAggregatedErrorMessage(ex.Message);
            return CreateAzurePowerShellException((HttpStatusCode)ex.Status, message, ex);
        }

        private static Exception CreateAzurePowerShellException(HttpStatusCode statusCode, string message, Exception ex)
        {
            switch (statusCode)
            {
                case HttpStatusCode.NotFound:
                    return new AzPSResourceNotFoundCloudException(message, null, ex);

                default:

                    // Handle client side exceptions
                    if (((int)statusCode) >= 400 && ((int)statusCode) < 500)
                    {
                        return new AzPSException(message, ErrorKind.UserError, ex);
                    }

                    // Handle server side exceptions
                    else if (((int)statusCode) >= 500)
                    {
                        return new AzPSException(message, ErrorKind.ServiceError, ex);
                    }

                    return new AzPSException(message, ErrorKind.InternalError, ex);
            }
        }

        internal static string ConstructResourceId(
            string subscriptionId,
            string resourceGroupName,
            string resourceType,
            string resourceName,
            string parentResource = null)
        {
            return new ResourceIdentifier
            {
                Subscription = subscriptionId,
                ResourceGroupName = resourceGroupName,
                ResourceType = resourceType,
                ParentResource = parentResource,
                ResourceName = resourceName
            }.ToString();
        }

        private static string GetAggregatedErrorMessage(string message, string innerMessage = null, IEnumerable<string> detailedMessages = null)
        {
            string errorContent = message;
            if (innerMessage != null)
            {
                errorContent += " " + innerMessage;
            }

            if (detailedMessages != null)
            {
                foreach (var detail in detailedMessages)
                {
                    errorContent += " " + detail;
                }
            }

            return errorContent;
        }

        public static bool IsNextPageLink(this string nextLink)
        {
            return !string.IsNullOrEmpty(nextLink);
        }

        public static bool IsEmptyOrWhiteSpace(this string value)
        {
            return value.All(char.IsWhiteSpace);
        }

        public static bool AreEmailAddressesInCorrectFormat(string[] emailAddresses)
        {
            if (emailAddresses == null)
            {
                return true;
            }

            var emailRegex =
                new Regex(string.Format("{0}{1}",
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"));
            return !emailAddresses.Any(e => !emailRegex.IsMatch(e.ToLower()));
        }

        public static string[] ProcessExcludedDetectionTypes(string[] excludedDetectionTypes)
        {
            if (excludedDetectionTypes == null || excludedDetectionTypes.Length == 0)
            {
                return excludedDetectionTypes;
            }

            if (excludedDetectionTypes.Length == 1)
            {
                if (excludedDetectionTypes[0] == SynapseConstants.DetectionType.None)
                {
                    return new string[] { };
                }
            }
            else
            {
                if (excludedDetectionTypes.Contains(SynapseConstants.DetectionType.None))
                {
                    throw new Exception(string.Format(Resources.InvalidExcludedDetectionTypeSet, SynapseConstants.DetectionType.None));
                }
            }
            return excludedDetectionTypes;
        }

        public static Response<T> Poll<T>(this Operation<T> operation)
        {
            return operation.WaitForCompletionAsync().Result;
        }

        public static Response Poll(this Operation operation)
        {
            var result = operation.WaitForCompletionResponseAsync().Result;
            var responseContent = result.Content;
            if (responseContent?.ToString().IsEmptyOrWhiteSpace() == false)
            {
                throw new Exception(responseContent?.ToString());
            }
            return result;
        }

        public static string GetItemTypeString(this WorkspaceItemType itemType)
        {
            string itemTypeString = null;
            switch (itemType)
            {
                case WorkspaceItemType.ApacheSparkPool:
                    itemTypeString = "bigDataPools";
                    break;
                case WorkspaceItemType.IntegrationRuntime:
                    itemTypeString = "integrationRuntimes";
                    break;
                case WorkspaceItemType.LinkedService:
                    itemTypeString = "linkedServices";
                    break;
                case WorkspaceItemType.Credential:
                    itemTypeString = "credentials";
                    break;
            }

            return itemTypeString;
        }
    }
}
