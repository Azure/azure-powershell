﻿//  
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

using System.Collections;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models
{
    using System.Collections.Generic;

    public class PsApiManagementBackendCredential
    {
        public IEnumerable<string> Certificate { get; set; }

        public Hashtable Query { get; set; }

        public Hashtable Header { get; set; }

        public PsApiManagementAuthorizationHeaderCredential Authorization { get; set; }
    }
}