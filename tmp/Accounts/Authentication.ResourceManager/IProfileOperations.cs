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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication.ResourceManager
{
    public interface IProfileOperations : IDisposable
    {
        AzureRmProfile ToProfile();
        bool TryAddContext(string name, IAzureContext context);
        bool TryAddContext(IAzureContext context, out string name);
        bool TryFindContext(IAzureContext context, out string name);
        bool TryGetContextName(IAzureContext context, out string name);
        bool TryRemoveContext(string name);
        bool TryRenameContext(string sourceName, string TargetName);
        bool TrySetContext(string name, IAzureContext context);
        bool TrySetContext(IAzureContext context, out string name);
        bool TrySetDefaultContext(string name);
        bool TrySetDefaultContext(IAzureContext context);

        bool TrySetDefaultContext(string name, IAzureContext context);
        bool TrySetEnvironment(IAzureEnvironment environment, out IAzureEnvironment mergedEnvironment);
        IAzureContext DefaultContext { get; }
        bool HasEnvironment(string name);
        bool TryGetEnvironment(string name, out IAzureEnvironment environment);
        bool TryRemoveEnvironment(string name, out IAzureEnvironment environment);

        bool TryCopyProfile(AzureRmProfile other);
        IEnumerable<IAzureEnvironment> Environments { get; }
    }
}
