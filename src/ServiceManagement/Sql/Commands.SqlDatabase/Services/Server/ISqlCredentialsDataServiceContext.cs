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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server
{
    using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
    using DatabaseCopyModel = Model.DatabaseCopy;

    /// <summary>
    /// Common interface for all server based operations.
    /// </summary>
    public interface ISqlCredentialsDataServiceContext : IServerDataServiceContext
    {
        /// <summary>
        /// Gets the Credentials for this context
        /// </summary>
        SqlAuthenticationCredentials SqlCredentials { get; }
    }
}
