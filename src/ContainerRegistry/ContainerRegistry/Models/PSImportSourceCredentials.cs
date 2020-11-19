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

using Microsoft.Azure.Management.ContainerRegistry.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSImportSourceCredentials
    {
        public PSImportSourceCredentials(string password, string username = default(string))
        {
            Username = username;
            Password = password;
            Validate();
        }

        public PSImportSourceCredentials() { }

        public string Username { get; set; }

        public string Password { get; set; }

        private void Validate()
        {
            if (Password == null)
            {
                throw new PSArgumentNullException("Password of ImportSourceCredentials cannot be null");
            }
        }

        public ImportSourceCredentials GetImportSourceCredentials()
        {
            return new ImportSourceCredentials
            {
                Username = this.Username,
                Password = this.Password
            };
        }
    }
}
