//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.Common
{
    using Hyak.Common;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    public class TestEnvironment
    {
        private bool CustomUri = false;
        private Uri _BaseUri;

        public Uri BaseUri
        {
            get
            {
                return this._BaseUri;
            }

            set
            {
                this.CustomUri = true;
                this._BaseUri = value;
            }
        }

        public Uri GalleryUri
        {
            get;
            set;
        }

        public Uri ActiveDirectoryEndpoint
        {
            get;
            set;
        }

        public CloudCredentials Credentials
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string StorageAccount
        {
            get;
            set;
        }

        public string SubscriptionId
        {
            get;
            set;
        }

        public bool UsesCustomUri()
        {
            return this.CustomUri;
        }

        public AuthenticationResult AuthenticationResult { get; set; } 
    }
}
