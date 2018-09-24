﻿﻿// ----------------------------------------------------------------------------------
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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common
{
    public class ResourceNotFoundExceptionTest : StorageTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceNotFoundExceptionInitTest()
        {
            string message = string.Empty;

            ResourceNotFoundException exception = new ResourceNotFoundException(message);

            message = "ResourceNotFoundException";
            exception = new ResourceNotFoundException(message);
        }
    }
}
