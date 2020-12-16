﻿using Azure;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Synapse.Common
{
    public static class Utils
    {
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

        internal static string NormalizeUrl(string url, bool shouldReportError = false)
        {
            if (AbfsUri.IsType(url))
            {
                return AbfsUri.Parse(url).GetUri().AbsoluteUri;
            }

            if (shouldReportError)
            {
                throw new SynapseException(string.Format(Resources.InvalidStorageUri, url));
            }
            else
            {
                return url;
            }
        }

        internal static string ReadFileAsText(this SynapseCmdletBase cmdlet, string filePath)
        {
            var powerShellDestinationPath = cmdlet.SessionState.Path.GetUnresolvedProviderPathFromPSPath(filePath);
            if (!AzureSession.Instance.DataStore.FileExists(powerShellDestinationPath))
            {
                throw new SynapseException(string.Format(Resources.FilePathDoesNotExist, powerShellDestinationPath));
            }

            return AzureSession.Instance.DataStore.ReadFileAsText(powerShellDestinationPath);
        }

        internal static SynapseException CreateSynapseException(this ErrorContractException ex)
        {
            var message = GetAggregatedErrorMessage(ex.Message, ex.Body?.Error?.Message, ex.Body?.Error?.Details?.Select(d => d.Message));
            return SynapseException.Create(ex.Response.StatusCode, message, ex);
        }

        internal static SynapseException CreateSynapseException(this CloudException ex)
        {
            var message = GetAggregatedErrorMessage(ex.Message, ex.Body?.Message, ex.Body?.Details?.Select(d => d.Message));
            return SynapseException.Create(ex.Response.StatusCode, message, ex);
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

        private static string GetAggregatedErrorMessage(string message, string innerMessage, IEnumerable<string> detailedMessages)
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

        public static Operation<T> Poll<T>(this Operation<T> operation)
        {
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
                System.Threading.Thread.Sleep(SynapseConstants.DefaultPollingInterval);
            }

            return operation;
        }
    }
}
