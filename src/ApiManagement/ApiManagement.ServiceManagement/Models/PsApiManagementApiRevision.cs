//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models
{
    using System;

    public class PsApiManagementApiRevision
    {
        public string ApiId { get; private set; }

        public string ApiRevision { get; private set; }

        public DateTime? CreatedDateTime { get; private set; }

        public DateTime? UpdatedDateTime { get; private set; }

        public string Description { get; private set; }

        public string PrivateUrl { get; private set; }

        public bool? IsOnline { get; private set; }

        public bool? IsCurrent { get; private set; }
    }
}
