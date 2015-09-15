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
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    /// <summary>
    /// These tests prevent regression in parameter validation attributes.
    /// </summary>
    [TestClass]
    public class DatabaseCmdletAttributionTests : SMTestBase
    {
        [TestInitialize]
        public void SetupTest()
        {
        }

        [TestMethod]
        public void NewAzureSqlDatabaseServerContextAttributeTest()
        {
            Type cmdlet = typeof(NewAzureSqlDatabaseServerContext);
            UnitTestHelper.CheckConfirmImpact(cmdlet, ConfirmImpact.None);
            UnitTestHelper.CheckCmdletModifiesData(cmdlet, false);
        }

        [TestMethod]
        public void GetAzureSqlDatabaseAttributeTest()
        {
            Type cmdlet = typeof(GetAzureSqlDatabase);
            UnitTestHelper.CheckConfirmImpact(cmdlet, ConfirmImpact.None);
            UnitTestHelper.CheckCmdletModifiesData(cmdlet, false);
        }

        [TestMethod]
        public void NewAzureSqlDatabaseAttributeTest()
        {
            Type cmdlet = typeof(NewAzureSqlDatabase);
            UnitTestHelper.CheckConfirmImpact(cmdlet, ConfirmImpact.Low);
            UnitTestHelper.CheckCmdletModifiesData(cmdlet, true);
        }

        [TestMethod]
        public void RemoveAzureSqlDatabaseAttributeTest()
        {
            Type cmdlet = typeof(RemoveAzureSqlDatabase);
            UnitTestHelper.CheckConfirmImpact(cmdlet, ConfirmImpact.High);
            UnitTestHelper.CheckCmdletModifiesData(cmdlet, true);
        }

        [TestMethod]
        public void SetAzureSqlDatabaseAttributeTest()
        {
            Type cmdlet = typeof(SetAzureSqlDatabase);
            UnitTestHelper.CheckConfirmImpact(cmdlet, ConfirmImpact.Medium);
            UnitTestHelper.CheckCmdletModifiesData(cmdlet, true);
        }

        /// <summary>
        /// Tests the attributes of the Export-AzureSqlDatabase cmdlet
        /// </summary>
        [TestMethod]
        public void ExportAzureSqlDatabaseAttributeTest()
        {
            Type cmdlet = typeof(StartAzureSqlDatabaseExport);
            UnitTestHelper.CheckConfirmImpact(cmdlet, ConfirmImpact.Medium);
            UnitTestHelper.CheckCmdletModifiesData(cmdlet, false);
        }

        /// <summary>
        /// Tests the attributes of the Start-AzureSqlDatabaseImport cmdlet
        /// </summary>
        [TestMethod]
        public void ImportAzureSqlDatabaseAttributeTest()
        {
            Type cmdlet = typeof(StartAzureSqlDatabaseImport);
            UnitTestHelper.CheckConfirmImpact(cmdlet, ConfirmImpact.Medium);
            UnitTestHelper.CheckCmdletModifiesData(cmdlet, false);
        }

        /// <summary>
        /// Tests the attributes of the Get-AzureSqlDatabaseImportExport cmdlet
        /// </summary>
        [TestMethod]
        public void GetAzureSqlDatabaseIEStatusAttributeTest()
        {
            Type cmdlet = typeof(GetAzureSqlDatabaseImportExportStatus);
            UnitTestHelper.CheckConfirmImpact(cmdlet, ConfirmImpact.None);
            UnitTestHelper.CheckCmdletModifiesData(cmdlet, false);
        }
        
        /// <summary>
        /// Tests the attributes of the Get-AzureSqlDatabaseServiceObjective cmdlet
        /// </summary>
        [TestMethod]
        public void GetAzureSqlDatabaseServiceObjectiveAttributeTest()
        {
            Type cmdlet = typeof(GetAzureSqlDatabaseServiceObjective);
            UnitTestHelper.CheckConfirmImpact(cmdlet, ConfirmImpact.None);
            UnitTestHelper.CheckCmdletModifiesData(cmdlet, false);

            object[] cmdletAttributes = cmdlet.GetCustomAttributes(typeof(CmdletAttribute), true);
            Assert.AreEqual(1, cmdletAttributes.Length);
            CmdletAttribute attribute = (CmdletAttribute)cmdletAttributes[0];
            Assert.AreEqual("ByConnectionContext", attribute.DefaultParameterSetName);
        }
    }
}
