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

using Microsoft.Azure.Management.ResourceManager.Models;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    public static class PageExtensions
    {
        public static void SetItemValue<T>(this Page<T> pagableObj, List<T> collection)
        {
            var property = typeof(Page<T>).GetProperty("Items", BindingFlags.Instance | BindingFlags.NonPublic);
            property.SetValue(pagableObj, collection);
        }
    }
}
