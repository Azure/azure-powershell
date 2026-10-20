// ----------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the Apache License, Version 2.0 (the "License"); see LICENSE for details.
// ----------------------------------------------------------------------------------
//
// C1 customization helper for the custom Request-AzRedHatOpenShiftHcpClusterAdminCredential cmdlet.
//
// Pure string -> string YAML transforms (no file I/O — the PowerShell cmdlet does the I/O):
//   * PrepareKubeconfig : embed the locally-generated private key into the returned kubeconfig and
//                         rename the cluster/user/context to a stable, collision-free name.
//   * MergeKubeConfig   : AKS-style merge into an existing kubeconfig (ported from
//                         src/Aks/Aks/Commands/ImportAzureRmAksCredential.cs).
//
// Targets netstandard2.0 / C# 7.1 (module csproj). Uses YamlDotNet (same version as Az.Aks).

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.RepresentationModel;

namespace Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Custom
{
    public static class KubeConfigHelper
    {
        private const string Clusters = "clusters";
        private const string Users = "users";
        private const string Contexts = "contexts";
        private const string CurrentContext = "current-context";

        /// <summary>
        /// Embed the private key into the admin user and give the single cluster/user/context a stable,
        /// collision-free name so multiple HCP clusters can coexist in one kubeconfig.
        /// </summary>
        public static string PrepareKubeconfig(string kubeconfigYaml, string privateKeyPem, string name)
        {
            if (string.IsNullOrWhiteSpace(kubeconfigYaml))
            {
                throw new ArgumentException("The returned kubeconfig was empty.", nameof(kubeconfigYaml));
            }

            var stream = Load(kubeconfigYaml);
            var root = (YamlMappingNode)stream.Documents[0].RootNode;
            var keyData = Convert.ToBase64String(Encoding.UTF8.GetBytes(privateKeyPem));

            var user0 = (YamlMappingNode)First(root, Users);
            user0.Children[new YamlScalarNode("name")] = new YamlScalarNode(name);
            var userInner = (YamlMappingNode)user0.Children[new YamlScalarNode("user")];
            userInner.Children.Remove(new YamlScalarNode("client-key"));
            userInner.Children[new YamlScalarNode("client-key-data")] = new YamlScalarNode(keyData);

            var cluster0 = (YamlMappingNode)First(root, Clusters);
            cluster0.Children[new YamlScalarNode("name")] = new YamlScalarNode(name);

            var context0 = (YamlMappingNode)First(root, Contexts);
            context0.Children[new YamlScalarNode("name")] = new YamlScalarNode(name);
            var contextInner = (YamlMappingNode)context0.Children[new YamlScalarNode("context")];
            contextInner.Children[new YamlScalarNode("cluster")] = new YamlScalarNode(name);
            contextInner.Children[new YamlScalarNode("user")] = new YamlScalarNode(name);

            root.Children[new YamlScalarNode(CurrentContext)] = new YamlScalarNode(name);

            return Serialize(stream);
        }

        /// <summary>
        /// Merge <paramref name="additions"/> into <paramref name="original"/> by name for clusters, users
        /// and contexts (new entries win on name collision), and adopt the new current-context.
        /// </summary>
        public static string MergeKubeConfig(string original, string additions)
        {
            var originalStream = Load(original);
            var newStream = Load(additions);
            var originalMapping = (YamlMappingNode)originalStream.Documents[0].RootNode;
            var newMapping = (YamlMappingNode)newStream.Documents[0].RootNode;

            foreach (var key in new[] { Clusters, Users, Contexts })
            {
                var merged = MergeNamedItems(originalMapping, newMapping, key);
                originalMapping.Children.Remove(new YamlScalarNode(key));
                originalMapping.Children.Add(new YamlScalarNode(key), merged);
            }

            originalMapping.Children.Remove(new YamlScalarNode(CurrentContext));
            originalMapping.Children.Add(new YamlScalarNode(CurrentContext),
                newMapping.Children[new YamlScalarNode(CurrentContext)]);

            return Serialize(originalStream);
        }

        private static YamlSequenceNode MergeNamedItems(YamlMappingNode original, YamlMappingNode addition, string key)
        {
            var keyNode = new YamlScalarNode(key);
            if (!original.Children.ContainsKey(keyNode) || !(original.Children[keyNode] is YamlSequenceNode))
            {
                throw new InvalidOperationException(
                    "The existing kubeconfig is malformed: missing or invalid '" + key + "' section. " +
                    "See https://kubernetes.io/docs/concepts/configuration/organize-cluster-access-kubeconfig/");
            }

            var named = new Dictionary<string, YamlMappingNode>(StringComparer.Ordinal);
            CollectNamed((YamlSequenceNode)original.Children[keyNode], named, false);
            if (addition.Children.ContainsKey(keyNode) && addition.Children[keyNode] is YamlSequenceNode)
            {
                CollectNamed((YamlSequenceNode)addition.Children[keyNode], named, true);
            }

            var result = new YamlSequenceNode();
            foreach (var item in named.Values)
            {
                result.Add(item);
            }
            return result;
        }

        private static void CollectNamed(YamlSequenceNode items, IDictionary<string, YamlMappingNode> into, bool overwrite)
        {
            foreach (var node in items.Children)
            {
                var mapping = (YamlMappingNode)node;
                var name = ((YamlScalarNode)mapping.Children[new YamlScalarNode("name")]).Value;
                if (overwrite || !into.ContainsKey(name))
                {
                    into[name] = mapping;
                }
            }
        }

        private static YamlNode First(YamlMappingNode root, string sequenceKey)
        {
            var keyNode = new YamlScalarNode(sequenceKey);
            if (!root.Children.ContainsKey(keyNode) || !(root.Children[keyNode] is YamlSequenceNode))
            {
                throw new InvalidOperationException("The returned kubeconfig is missing its '" + sequenceKey + "' section.");
            }
            var seq = (YamlSequenceNode)root.Children[keyNode];
            if (seq.Children.Count == 0)
            {
                throw new InvalidOperationException("The returned kubeconfig has an empty '" + sequenceKey + "' section.");
            }
            return seq.Children[0];
        }

        private static YamlStream Load(string yaml)
        {
            var stream = new YamlStream();
            stream.Load(new StringReader(yaml));
            if (stream.Documents.Count == 0)
            {
                throw new InvalidOperationException("The kubeconfig content contained no YAML documents.");
            }
            return stream;
        }

        private static string Serialize(YamlStream stream)
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                stream.Save(sw, false);
            }
            return sb.ToString();
        }
    }
}
