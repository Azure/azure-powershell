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
using System.Linq;

namespace Microsoft.Azure.Commands.DataFactories.Models
{
    /// <summary>
    /// A PowerShell wrapper class on top of the data slice run log SAS url
    /// </summary>
    public class PSRunLogInfo
    {
        private Uri _runLogUri;

        public PSRunLogInfo()
        {
        }

        public PSRunLogInfo(Uri runLogUri)
        {
            if (runLogUri == null)
            {
                throw new ArgumentNullException("runLogUri");
            }

            this._runLogUri = runLogUri;
        }

        public string SasUri
        {
            get
            {
                return this._runLogUri.AbsoluteUri;
            }
        }

        public string StorageAccountName
        {
            get
            {
                return this._runLogUri.Host.Split('.').FirstOrDefault();
            }
        }

        public string Container
        {
            get
            {
                return this._runLogUri.AbsolutePath.TrimStart('/');
            }
        }

        public string SasToken
        {
            get
            {
                return this._runLogUri.Query;
            }
        }
    }
}
