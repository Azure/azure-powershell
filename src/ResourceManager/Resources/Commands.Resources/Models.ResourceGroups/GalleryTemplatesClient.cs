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

using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Common.OData;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Gallery.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public class GalleryTemplatesClient
    {
        public IGalleryClient GalleryClient { get; set; }

        public GalleryTemplatesClient(AzureContext context)
            : this(AzureSession.ClientFactory.CreateClient<GalleryClient>(context, AzureEnvironment.Endpoint.Gallery))
        {

        }

        public GalleryTemplatesClient(IGalleryClient galleryClient)
        {
            GalleryClient = galleryClient;
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public GalleryTemplatesClient()
        {

        }
    }
}