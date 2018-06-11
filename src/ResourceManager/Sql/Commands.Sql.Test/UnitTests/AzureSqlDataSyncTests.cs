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

using Microsoft.Azure.Commands.Sql.DataSync.Cmdlet;
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlDataSyncTests
    {
        public AzureSqlDataSyncTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParseSyncGroupSchema()
        {
            string schema = @"{
                ""mastersyncMemberNAME"": ""masterMember"",
                ""Tables"": [
                    {
                        ""QUOTEDNAME"": ""testTable"",
                        ""columns"": [
                            {
                                ""QuotedName"": ""testColumn""
                            }
                        ]
                    }
                ]
            }";

            var cmdlet = new UpdateAzureSqlSyncGroup();
            AzureSqlSyncGroupSchemaModel schemaModel = AzureSqlSyncGroupCmdletBase.ConstructSchemaFromJObject(JObject.Parse(schema));

            Assert.Equal("masterMember", schemaModel.MasterSyncMemberName);
            Assert.Equal(1, schemaModel.Tables.Count);
            Assert.Equal("testTable", schemaModel.Tables[0].QuotedName);
            Assert.Equal(1, schemaModel.Tables[0].Columns.Count);
            Assert.Equal("testColumn", schemaModel.Tables[0].Columns[0].QuotedName);
        }
    }
}
