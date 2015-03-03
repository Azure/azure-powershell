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

using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Websites.Test
{
    public static class WebsitesTestHelpers
    {
        public static void CreateAccountResource(string accountName, string resourceGroupName, Hashtable[] tags = null)
        {
            string tenantUrlEnding = "batch-test.windows-int.net";
            string endpoint = string.Format("{0}.{1}", accountName, tenantUrlEnding);
            string subscription = "00000000-0000-0000-0000-000000000000";
            string resourceGroup = resourceGroupName;
        }
    }
}
