//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{

    public class PSCommunityGalleryImage 
    {
        public OperatingSystemTypes OsType { get; set; }
        public OperatingSystemStateTypes OsState { get; set; }
        public DateTime? EndOfLifeDate { get; set; }
        public GalleryImageIdentifier Identifier { get; set; }
        public RecommendedMachineConfiguration Recommended { get; set; }
        public Disallowed Disallowed { get; set; }
        public string HyperVGeneration { get; set; }
        public IList<GalleryImageFeature> Features { get; set; }
        public ImagePurchasePlan PurchasePlan { get; set; }
        public string Architecture { get; set; }
        public string PrivacyStatementUri { get; set; }
        public string Eula { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string UniqueId { get; set; }
    }

    public class PSCommunityGalleryImageList : PSCommunityGalleryImage
    {
        public PSCommunityGalleryImage ToPSCommunityGalleryImage()
        {
            return ComputeAutomationAutoMapperProfile.Mapper.Map<PSCommunityGalleryImage>(this);
        }
    }
}