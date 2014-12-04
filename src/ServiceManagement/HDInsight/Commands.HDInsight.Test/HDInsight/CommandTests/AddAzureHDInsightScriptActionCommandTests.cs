//----------------------------------------------------------------------------------  
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
namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CommandTests
{
    using CmdLetTests;
    using Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
    using Management.HDInsight.Cmdlet.DataObjects;
    using Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
    using Management.HDInsight.Cmdlet.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using System;
    using System.Linq;
    using VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddHDInsightScriptActionCommandTests : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanAddScriptAction()
        {
            var config = new AzureHDInsightConfig();
            IAddAzureHDInsightScriptActionCommand scriptActionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddScriptAction();

            scriptActionCommand.Name = "test";
            scriptActionCommand.Uri = new Uri("http://test.com");
            scriptActionCommand.Parameters = "test parameters";
            scriptActionCommand.Config = config;
            scriptActionCommand.EndProcessing();

            AzureHDInsightConfig newConfig = scriptActionCommand.Output.First();

            Assert.AreEqual(config.ClusterSizeInNodes, newConfig.ClusterSizeInNodes);
            Assert.AreEqual(config.DefaultStorageAccount, newConfig.DefaultStorageAccount);
            Assert.IsTrue(config.ConfigActions.Count == newConfig.ConfigActions.Count && config.ConfigActions.Count == 1);
            Assert.IsTrue(newConfig.ConfigActions.ElementAt(0) is AzureHDInsightScriptAction);
            Assert.IsTrue(newConfig.ConfigActions.ElementAt(0).Name == "test" &&
                ((AzureHDInsightScriptAction)newConfig.ConfigActions.ElementAt(0)).Uri == new Uri("http://test.com") &&
                ((AzureHDInsightScriptAction)newConfig.ConfigActions.ElementAt(0)).Parameters == "test parameters");

        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanAddRoleCollectionToScriptAction()
        {
            var config = new AzureHDInsightConfig();
            IAddAzureHDInsightScriptActionCommand scriptActionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddScriptAction();

            scriptActionCommand.ClusterRoleCollection =
                new ClusterNodeType[] { ClusterNodeType.HeadNode, ClusterNodeType.DataNode };
            scriptActionCommand.Name = "test";
            scriptActionCommand.Uri = new Uri("http://test.com");
            scriptActionCommand.Parameters = "test parameters";
            scriptActionCommand.Config = config;
            scriptActionCommand.EndProcessing();

            AzureHDInsightConfig newConfig = scriptActionCommand.Output.First();

            Assert.AreEqual(config.ClusterSizeInNodes, newConfig.ClusterSizeInNodes);
            Assert.AreEqual(config.DefaultStorageAccount, newConfig.DefaultStorageAccount);
            Assert.IsTrue(config.ConfigActions.Count == newConfig.ConfigActions.Count && config.ConfigActions.Count == 1);
            Assert.IsTrue(newConfig.ConfigActions.ElementAt(0) is AzureHDInsightScriptAction);
            Assert.IsTrue(newConfig.ConfigActions.ElementAt(0).Name == "test" &&
                ((AzureHDInsightScriptAction)newConfig.ConfigActions.ElementAt(0)).Uri == new Uri("http://test.com") &&
                ((AzureHDInsightScriptAction)newConfig.ConfigActions.ElementAt(0)).Parameters == "test parameters");
            Assert.IsTrue(Enumerable.SequenceEqual(newConfig.ConfigActions.ElementAt(0).ClusterRoleCollection,
                new ClusterNodeType[] { ClusterNodeType.HeadNode, ClusterNodeType.DataNode }));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanAddComplexScriptAction()
        {
            var config = new AzureHDInsightConfig();
            IAddAzureHDInsightScriptActionCommand scriptActionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddScriptAction();

            scriptActionCommand.ClusterRoleCollection =
                new ClusterNodeType[] { ClusterNodeType.HeadNode };
            scriptActionCommand.Config = config;
            scriptActionCommand.EndProcessing();

            AzureHDInsightConfig newConfig = scriptActionCommand.Output.First();

            Assert.AreEqual(config.ClusterSizeInNodes, newConfig.ClusterSizeInNodes);
            Assert.AreEqual(config.DefaultStorageAccount, newConfig.DefaultStorageAccount);
            Assert.IsTrue(config.ConfigActions.Count == newConfig.ConfigActions.Count && config.ConfigActions.Count == 1);
            Assert.IsTrue(newConfig.ConfigActions.ElementAt(0) is AzureHDInsightScriptAction);
            Assert.IsTrue(Enumerable.SequenceEqual(newConfig.ConfigActions.ElementAt(0).ClusterRoleCollection,
                new ClusterNodeType[] { ClusterNodeType.HeadNode }));
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}