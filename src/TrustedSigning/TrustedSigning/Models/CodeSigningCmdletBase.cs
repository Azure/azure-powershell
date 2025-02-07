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
using System.IO;
using System.Linq;
using System.Management.Automation;
using Azure.Core.Diagnostics;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.CodeSigning.Models
{
    public class CodeSigningCmdletBase : AzureRMCmdlet
    {
        public static readonly DateTime EpochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private AzureEventSourceListener _azureEventSourceListener;

        internal ICodeSigningServiceClient CodeSigningServiceClient
        {
            get
            {
                if (codeSigningServiceClient == null)
                {
                    this.codeSigningServiceClient = new CodeSigningServiceClient(
                        AzureSession.Instance.AuthenticationFactory,
                        DefaultContext);
                }

                return this.codeSigningServiceClient;
            }
            set
            {
                this.codeSigningServiceClient = value;
            }
        }

        protected string ResolvePath(string path)
        {
            // See http://stackoverflow.com/a/8506768/59641 for a good primer
            // on how to resolve paths in Powershell cmdlets.
            string basePath = SessionState.Path.CurrentFileSystemLocation.ProviderPath;
            string fullPath = Path.Combine(basePath, path);
            return Path.GetFullPath(fullPath); // normalize
        }

        protected string GetDefaultFileForOperation(string operationName, string vaultName, string entityName)
        {
            // caller is responsible for parameter validation
            var currentPath = CurrentPath();
            var filename = string.Format("{0}\\{1}-{2}-{3}", currentPath, vaultName, entityName, DateTime.UtcNow.Subtract(EpochDate).TotalSeconds);

            return filename;
        }

        private ICodeSigningServiceClient codeSigningServiceClient;

        public List<T> ResourceWildcardFilter<T>(string name, IEnumerable<T> resources)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IEnumerable<T> output = resources;
                WildcardPattern pattern = new WildcardPattern(name, WildcardOptions.IgnoreCase);
                output = output.Where(t => IsMatch(t, "Name", pattern));

                return output.ToList();
            }
            else
            {
                return resources.ToList();
            }
        }

        private bool IsMatch<T>(T resource, string property, WildcardPattern pattern)
        {
            var value = (string)GetPropertyValue(resource, property);
            return !string.IsNullOrEmpty(value) && pattern.IsMatch(value);
        }

        private object GetPropertyValue<T>(T resource, string property)
        {
            System.Reflection.PropertyInfo pi = typeof(T).GetProperty(property);
            if (pi != null)
            {
                return pi.GetValue(resource, null);
            }

            return null;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && _azureEventSourceListener != null)
            {
                _azureEventSourceListener.Dispose();
                _azureEventSourceListener = null;
            }
        }
    }
}
