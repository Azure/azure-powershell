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

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public enum PSSearchBypass
    {
        None = 0,
        AzureServices = 1,
    }

    internal static class PSSearchBypassEnumExtension
    {
        internal static string ToString(this PSSearchBypass value)
        {
            switch (value)
            {
                case PSSearchBypass.None:
                    return "None";
                case PSSearchBypass.AzureServices:
                    return "AzureServices";
            }
            return null;
        }
    }
}
