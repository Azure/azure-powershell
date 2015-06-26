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

using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{

    public class TemplateImageComparer : IComparer<TemplateImage>
    {
        public int Compare(TemplateImage first, TemplateImage second)
        {
            if (first == null)
            {
                if (second == null)
                {
                    return 0; // both null are equal
                }
                else
                {
                    return -1; // second is greateer
                }
            }
            else
            {
                if (second == null)
                {
                    return 1; // first is greater as it is not null
                }
            }

            return string.Compare(first.Name, second.Name, StringComparison.OrdinalIgnoreCase);
        }
    }

    public class GoldImage : RdsCmdlet
    {
        public enum Operation
        {
            Create,
            Update,
            Remove,
            Resume,
        }

        protected TemplateImage FilterTemplateImage(string TemplateImageName, Operation op)
        {
            TemplateImageListResult response = null;
            TemplateImage matchingTemplate = null;
            string errorMessage = null;
            ErrorCategory category = ErrorCategory.NotSpecified;

            response = CallClient_ThrowOnError(() => Client.TemplateImages.List());

            foreach (TemplateImage template in response.RemoteAppTemplateImageList)
            {
                if (String.Equals(template.Name, TemplateImageName, StringComparison.OrdinalIgnoreCase))
                {
                    matchingTemplate = template;
                    break;
                }
            }

            switch (op)
            {
                case Operation.Remove:
                case Operation.Update:
                {
                    if (matchingTemplate == null)
                    {
                        errorMessage = String.Format("Template {0} does not exist.", TemplateImageName);
                        category = ErrorCategory.ObjectNotFound;
                    }
                    break;
                }
                case Operation.Create:
                {
                    if (matchingTemplate !=null)
                    {
                        errorMessage = String.Format("There is an existing template named {0}.", TemplateImageName);
                        category = ErrorCategory.ResourceExists;
                    }
                    break;
                }
                case Operation.Resume:
                {
                    if (matchingTemplate == null)
                    {
                        errorMessage = String.Format("Template {0} does not exist.", TemplateImageName);
                        category = ErrorCategory.ObjectNotFound;
                    }
                    else if (matchingTemplate.Status != TemplateImageStatus.UploadPending &&
                             matchingTemplate.Status != TemplateImageStatus.UploadInProgress)
                    {
                        errorMessage = String.Format(
                                          "Unable to resume uploading this template {0}." +
                                          "It is in the wrong state {1}, it should be either UploadPending or UploadInProgress",
                                           matchingTemplate.Name,
                                           matchingTemplate.Status.ToString());
                        category = ErrorCategory.InvalidOperation;
                    }
                    else if (DateTime.UtcNow >= matchingTemplate.SasExpiry)
                    {
                        errorMessage = String.Format(
                                          "Unable to resume uploading this template {0}. The time limit has expired at {1}",
                                          matchingTemplate.Name,
                                          matchingTemplate.SasExpiry.ToString());
                        category = ErrorCategory.InvalidOperation;
                    }
                    break;
                }
            }

            if (errorMessage != null)
            {
                throw new RemoteAppServiceException(errorMessage, category);
            }

            return matchingTemplate;
        }
    }
}
