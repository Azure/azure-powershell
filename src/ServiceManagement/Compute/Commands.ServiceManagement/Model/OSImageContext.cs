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
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class OSImageContext : ManagementOperationContext
    {
        public virtual string ImageName { get; set; }
        public virtual string OS { get; set; }
        public virtual Uri MediaLink { get; set; }
        public virtual int? LogicalSizeInGB { get; set; }
        public virtual string AffinityGroup { get; set; }
        public virtual string Category { get; set; }
        public virtual string Location { get; set; }
        public virtual string Label { get; set; }
        public virtual string Description { get; set; }
        public virtual string Eula { get; set; }
        public virtual string ImageFamily { get; set; }
        public virtual DateTime? PublishedDate { get; set; }
        public virtual bool? IsPremium { get; set; }
        public virtual string IconUri { get; set; }
        public virtual string SmallIconUri { get; set; }
        public virtual Uri PrivacyUri { get; set; }
        public virtual string RecommendedVMSize { get; set; }
        public virtual string PublisherName { get; set; }
        public virtual string IOType { get; set; }
        public virtual bool? ShowInGui { get; set; }

        public virtual string IconName
        {
            get
            {
                return IconUri;
            }
        }

        public virtual string SmallIconName
        {
            get
            {
                return SmallIconUri;
            }
        }
    }
}