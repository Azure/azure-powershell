using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Kubernetes;
using Xunit;
using YamlDotNet.RepresentationModel;

namespace Commands.Kubernetes.Test.Netcore
{
    public class MergedKubeConfigTests
    {
        private readonly YamlNode _rootNode;

        public MergedKubeConfigTests()
        {
            var merged = ImportCredential.MergeKubeConfig(File.ReadAllText("./Fixtures/config.yaml"), File.ReadAllText("./Fixtures/additional_kube_config.yaml"));
            _rootNode = RootNodeFromString(merged);
        }

        [Fact]
        public void MergedKubeConfigOverwriteClustersTest()
        {
            var clustersByName = DictOfNamedItems(_rootNode, "clusters", "cluster");
            var helloCluster = clustersByName["hello"];
            Assert.True(GetScalar(helloCluster, "server").Value == "overwritten");
        }

        [Fact]
        public void MergedKubeConfigOverwriteUsersTest()
        {
            var usersByName = DictOfNamedItems(_rootNode, "users", "user");
            var clusterUser = usersByName["clusterUser_test_hello"];
            Assert.True(GetScalar(clusterUser, "token").Value == "boo");
        }

        [Fact]
        public void MergedKubeConfigOverwriteContextTest()
        {
            var contextByName = DictOfNamedItems(_rootNode, "contexts", "context");
            var helloContext = contextByName["hello"];
            Assert.True(GetScalar(helloContext, "cluster").Value == "hello");
        }

        [Fact]
        public void MergedKubeConfigAdditiveClustersTest()
        {
            var clustersByName = DictOfNamedItems(_rootNode, "clusters", "cluster");
            var newCluster = clustersByName["something-new"];
            Assert.True(GetScalar(newCluster, "server").Value == "new-server");
        }

        [Fact]
        public void MergedKubeConfigAdditiveUsersTest()
        {
            var usersByName = DictOfNamedItems(_rootNode, "users", "user");
            var clusterUser = usersByName["new-user"];
            Assert.True(GetScalar(clusterUser, "token").Value == "boo1");
        }

        [Fact]
        public void MergedKubeConfigAdditiveContextTest()
        {
            var contextByName = DictOfNamedItems(_rootNode, "contexts", "context");
            var helloContext = contextByName["new-context"];
            Assert.True(GetScalar(helloContext, "cluster").Value == "something-new");
        }


        [Fact]
        public void MergedKubeConfigOverwriteCurrentContextTest()
        {
            Assert.True(GetScalar(_rootNode, "current-context").Value == "baz");
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

        private static YamlMappingNode RootNodeFromString(string content)
        {
            var yaml = new YamlStream();
            yaml.Load(new StringReader(content));
            return (YamlMappingNode)yaml.Documents[0].RootNode;
        }
    }
}