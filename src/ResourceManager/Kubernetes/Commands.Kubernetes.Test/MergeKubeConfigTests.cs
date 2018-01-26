using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Kubernetes;
using Xunit;
using YamlDotNet.RepresentationModel;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;

namespace Commands.Kubernetes.Test
{
    public class ConfigFixture
    {
        private readonly YamlNode _rootNode;

        public ConfigFixture()
        {
            var merged = ImportAzureRmKubernetesCredential.MergeKubeConfig(File.ReadAllText("./Fixtures/config.yaml"), File.ReadAllText("./Fixtures/additional_kube_config.yaml"));
            _rootNode = RootNodeFromString(merged);
        }

        public YamlNode RootNode { get { return _rootNode;  } }

        private static YamlMappingNode RootNodeFromString(string content)
        {
            var yaml = new YamlStream();
            yaml.Load(new StringReader(content));
            return (YamlMappingNode)yaml.Documents[0].RootNode;
        }

    }

    public class MergedKubeConfigTests : IClassFixture<ConfigFixture>
    {
        ConfigFixture _configFixture;

        public MergedKubeConfigTests(ConfigFixture fixture)
        {
            _configFixture = fixture;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MergedKubeConfigOverwriteClustersTest()
        {
            var clustersByName = DictOfNamedItems(_configFixture.RootNode, "clusters", "cluster");
            var helloCluster = clustersByName["hello"];
            Assert.True(GetScalar(helloCluster, "server").Value == "overwritten");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MergedKubeConfigOverwriteUsersTest()
        {
            var usersByName = DictOfNamedItems(_configFixture.RootNode, "users", "user");
            var clusterUser = usersByName["clusterUser_test_hello"];
            Assert.True(GetScalar(clusterUser, "token").Value == "boo");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MergedKubeConfigOverwriteContextTest()
        {
            var contextByName = DictOfNamedItems(_configFixture.RootNode, "contexts", "context");
            var helloContext = contextByName["hello"];
            Assert.True(GetScalar(helloContext, "cluster").Value == "hello");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MergedKubeConfigAdditiveClustersTest()
        {
            var clustersByName = DictOfNamedItems(_configFixture.RootNode, "clusters", "cluster");
            var newCluster = clustersByName["something-new"];
            Assert.True(GetScalar(newCluster, "server").Value == "new-server");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MergedKubeConfigAdditiveUsersTest()
        {
            var usersByName = DictOfNamedItems(_configFixture.RootNode, "users", "user");
            var clusterUser = usersByName["new-user"];
            Assert.True(GetScalar(clusterUser, "token").Value == "boo1");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MergedKubeConfigAdditiveContextTest()
        {
            var contextByName = DictOfNamedItems(_configFixture.RootNode, "contexts", "context");
            var helloContext = contextByName["new-context"];
            Assert.True(GetScalar(helloContext, "cluster").Value == "something-new");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MergedKubeConfigOverwriteCurrentContextTest()
        {
            Assert.True(GetScalar(_configFixture.RootNode, "current-context").Value == "baz");
        }

        private static IDictionary<string, YamlNode> DictOfNamedItems(YamlNode yaml, string category, string itemName)
        {
            return ((YamlSequenceNode)yaml[new YamlScalarNode(category)])
                .Children
                .Cast<YamlMappingNode>()
                .ToDictionary(x =>
                {
                    var nameNode = (YamlScalarNode) x.Children[new YamlScalarNode("name")];
                    return nameNode.Value;
                }, el => el.Children[new YamlScalarNode(itemName)]);
        }

        private static YamlScalarNode GetScalar(YamlNode node, string key)
        {
            return (YamlScalarNode) node[new YamlScalarNode(key)];
        }
    }
}