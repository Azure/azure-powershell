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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.PolicyInsights.Models.Attestations;
using Microsoft.Azure.Commands.PolicyInsights.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.PolicyInsights.Common
{
    public abstract class AttestationCmdletBase : PolicyInsightsCmdletBase
    {
        /// <summary>
        /// The fully qualified resource type of the attestations resource.
        /// </summary>
        protected const string AttestationsFullyQualifiedResourceType = "Microsoft.PolicyInsights/attestations";

        /// <summary>
        /// Gets the root scope of the attestation that is being acted upon.
        /// </summary>
        /// <param name="scope">The full scope</param>
        /// <param name="resourceId">The full resource ID of the attestation resource</param>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="inputObject">The attestation input object</param>
        protected string GetRootScope(string scope = null, string resourceId = null, string resourceGroupName = null, PSAttestation inputObject = null)
        {
            string rootScope = null;
            if (!string.IsNullOrEmpty(resourceId))
            {
                rootScope = ResourceIdHelper.GetRootScope(resourceId: resourceId, fullyQualifiedResourceType: AttestationCmdletBase.AttestationsFullyQualifiedResourceType);
                if (rootScope == null)
                {
                    throw new AzPSArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.Error_InvalidResourceId, AttestationCmdletBase.AttestationsFullyQualifiedResourceType), paramName: "ResourceId");
                }
            }
            else if (!string.IsNullOrEmpty(scope))
            {
                rootScope = scope.TrimEnd('/');
            }
            else if (!string.IsNullOrEmpty(resourceGroupName))
            {
                rootScope = ResourceIdHelper.GetResourceGroupScope(subscriptionId: this.DefaultContext.Subscription.Id, resourceGroupName: resourceGroupName);
            }
            else if (inputObject != null)
            {
                rootScope = ResourceIdHelper.GetRootScope(resourceId: inputObject.Id, fullyQualifiedResourceType: AttestationCmdletBase.AttestationsFullyQualifiedResourceType);
            }
            else
            {
                // Subscription based retrieval is the default, pulls the subscription ID from context
                rootScope = ResourceIdHelper.GetSubscriptionScope(subscriptionId: this.DefaultContext.Subscription.Id);
            }

            return rootScope;
        }


        /// <summary>
        /// Gets the name of the attestation that is being acted upon.
        /// </summary>
        /// <param name="name">The provided attestation name</param>
        /// <param name="resourceId">The full resource ID of the attestation resource</param>
        /// <param name="inputObject">The attestation input object</param>
        protected string GetAttestationName(string name = null, string resourceId = null, PSAttestation inputObject = null)
        {
            string attestationName = null;
            if (!string.IsNullOrEmpty(name))
            {
                attestationName = name;
            }
            else if (!string.IsNullOrEmpty(resourceId))
            {
                attestationName = ResourceIdHelper.GetResourceName(resourceId: resourceId);
                if (attestationName == null)
                {
                    throw new AzPSArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.Error_InvalidResourceId, AttestationCmdletBase.AttestationsFullyQualifiedResourceType), paramName: "ResourceId");
                }
            }
            else if (inputObject != null)
            {
                attestationName = inputObject.Name;
            }

            return attestationName;
        }

        protected JObject ConvertToMetadataJObject(string metadata)
        {
            Uri outUri = null;
            JObject result;
            if (Uri.TryCreate(metadata, UriKind.Absolute, out outUri))
            {
                if (outUri.Scheme == Uri.UriSchemeFile)
                {
                    string filePath = this.TryResolvePath(metadata);
                    if (File.Exists(filePath))
                    {
                        result = JToken.Parse(FileUtilities.DataStore.ReadFileAsText(filePath)) as JObject;
                    }
                    else
                    {
                        throw new AzPSInvalidOperationException(string.Format(Resources.InvalidFilePath, metadata));
                    }
                }
                else if (outUri.Scheme != Uri.UriSchemeHttp && outUri.Scheme != Uri.UriSchemeHttps)
                {
                    throw new AzPSInvalidOperationException(Resources.InvalidUriScheme);
                }
                else if (!Uri.IsWellFormedUriString(outUri.AbsoluteUri, UriKind.Absolute))
                {
                    throw new AzPSInvalidOperationException(string.Format(Resources.InvalidUriString, metadata));
                }
                else
                {
                    string contents = GeneralUtilities.DownloadFile(outUri.AbsoluteUri);
                    if (string.IsNullOrEmpty(contents))
                    {
                        throw new AzPSInvalidOperationException(string.Format(Resources.InvalidUriContent, metadata));
                    }

                    result = JToken.Parse(contents) as JObject;
                }
            }
            else
            {
                //for non absolute file paths
                string path = this.TryResolvePath(metadata);

                if (File.Exists(path))
                {
                    result = JToken.Parse(FileUtilities.DataStore.ReadFileAsText(path)) as JObject;
                }
                else
                {
                    result = JToken.Parse(metadata) as JObject;
                }

                if (result == null)
                {
                    throw new AzPSArgumentException(string.Format(Resources.JsonObjectExpected, nameof(metadata)), nameof(metadata));
                }
            }
            return result;
        }
    }
}
