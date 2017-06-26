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

using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlCmdletBaseBaseUnitTests
    {
        /// <summary>
        /// Mock class to expose the GetResourceId method for testing with an IEnumerable{} model
        /// </summary>
        public class MockCmdletBaseBase : AzureSqlCmdletBaseBase<AzureSqlDatabaseModel, object>
        {
            public MockCmdletBaseBase()
            {
            }

            protected override AzureSqlDatabaseModel GetEntity()
            {
                throw new NotImplementedException();
            }

            protected override object InitModelAdapter(IAzureSubscription subscription)
            {
                throw new NotImplementedException();
            }

            public new string GetResourceId(AzureSqlDatabaseModel model)
            {
                return base.GetResourceId(model);
            }
        }

        /// <summary>
        /// Mock class to expose the GetResourceId method for testing with an IEnumerable<> model
        /// </summary>
        public class MockCmdletBaseBase2 : AzureSqlCmdletBaseBase<IEnumerable<AzureSqlDatabaseModel>, object>
        {
            protected override IEnumerable<AzureSqlDatabaseModel> GetEntity()
            {
                throw new NotImplementedException();
            }

            protected override object InitModelAdapter(IAzureSubscription subscription)
            {
                throw new NotImplementedException();
            }
            public new string GetResourceId(IEnumerable<AzureSqlDatabaseModel> model)
            {
                return base.GetResourceId(model);
            }
        }
        
        public AzureSqlCmdletBaseBaseUnitTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        /// <summary>
        /// Test that getting the resource ID works successfully for both Single entity models and IEnumerable{} Models
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceId()
        {
            // Test single model
            //
            AzureSqlDatabaseModel singleModel = new AzureSqlDatabaseModel("myRg", "myServer", new Management.Sql.LegacySdk.Models.Database()
            {
                Name = "myDb",
                Properties = new Management.Sql.LegacySdk.Models.DatabaseProperties()
            });
            
            MockCmdletBaseBase m1 = new MockCmdletBaseBase();
            string output1 = m1.GetResourceId(singleModel);
            Assert.Equal("myServer.myDb", output1);

            // Test IEnumerable{} model
            IList<AzureSqlDatabaseModel> multipleModel = new List<AzureSqlDatabaseModel>();
            multipleModel.Add(new AzureSqlDatabaseModel("myRg1", "myServer1", new Management.Sql.LegacySdk.Models.Database()
            {
                Name = "myDb1",
                Properties = new Management.Sql.LegacySdk.Models.DatabaseProperties()
            }));

            MockCmdletBaseBase2 m2 = new MockCmdletBaseBase2();
            string output2 = m2.GetResourceId(multipleModel);
            Assert.Equal("myServer1.myDb1", output2);
        }
    }
}
