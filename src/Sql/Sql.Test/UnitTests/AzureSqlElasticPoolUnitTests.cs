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

using Microsoft.Azure.Commands.Sql.ElasticPool.Cmdlet;
using Microsoft.Azure.Commands.Sql.Test.Utilities;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using Microsoft.Azure.Commands.Sql.ElasticPool.Services;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlElasticPoolUnitTests
    {
        public AzureSqlElasticPoolUnitTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetPoolSkuName()
        {
            Assert.Equal(
                "BasicPool",
                AzureSqlElasticPoolAdapter.GetPoolSkuName("Basic"));
            Assert.Equal(
                "StandardPool",
                AzureSqlElasticPoolAdapter.GetPoolSkuName("Standard"));
            Assert.Equal(
                "PremiumPool",
                AzureSqlElasticPoolAdapter.GetPoolSkuName("Premium"));
            Assert.Equal(
                "GP",
                AzureSqlElasticPoolAdapter.GetPoolSkuName("GeneralPurpose"));
            Assert.Equal(
                "BC",
                AzureSqlElasticPoolAdapter.GetPoolSkuName("BusinessCritical"));
        }
    }
}
