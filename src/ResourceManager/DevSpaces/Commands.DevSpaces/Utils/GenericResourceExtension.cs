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
using Microsoft.Azure.Commands.DevSpaces.Properties;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.DevSpaces.Utils
{
    public static class GenericResourceExtension
    {
        public static bool IsDevSpacesSupported(this GenericResource genericResource, out string reason)
        {
            reason = string.Empty;
            dynamic properties = genericResource?.Properties;
            dynamic httpApplicationRouting = properties?.addonProfiles?.httpApplicationRouting;
            if (httpApplicationRouting?.enabled != true)
            {
                reason = Resources.HttpRoutingNotEnabled;
                return false;
            }

            return true;
        }
    }
}
