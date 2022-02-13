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

using Microsoft.Azure.Commands.Common.Exceptions;

namespace Microsoft.Azure.Commands.Aks.Commands
{
    internal static class Utilities
    {
        public static string GetParentResourceName(string parentResource, string parameterSource)
        {
            if (string.IsNullOrWhiteSpace(parentResource))
                throw new AzPSArgumentNullException(
                    Properties.Resources.ParentResourceMustNotBeEmpty,
                    parameterSource,
                    desensitizedMessage: Properties.Resources.ParentResourceMustNotBeEmpty);

            var items = parentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            return items.Length > 0 ? items[items.Length - 1] : null;
        }
    }
}
