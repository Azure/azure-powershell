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

    public class PsApiManagementUserToken
    {
        /// <summary>
        /// UserId for which the token was generated
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Expiry of the Token in UTC
        /// </summary>
        public DateTime TokenExpiry { get; set; }

        /// <summary>
        /// The Key used to generate the Token
        /// </summary>
        public PsApiManagementUserKeyType KeyType { get; set; }

        /// <summary>
        /// Shared Access Authorization token for the User
        /// </summary>
        public string UserToken { get; set; }
    }
}
