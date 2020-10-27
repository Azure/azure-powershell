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

namespace Microsoft.Azure.Commands.HDInsight
{
    using System;
    using System.Collections.Generic;

    public static class DefaultVmSizes
    {
        public static class HeadNode
        {
            private const string DefaultSizeIfNotSpecified = "Large";

            private static readonly Dictionary<string, string> DefaultSizes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"hadoop", "Standard_D3_v2"},
                {"spark", "Standard_D12_v2"},
                {"rserver", "Standard_D12_v2"},
                {"mlservices", "Standard_D12_v2"},
                {"InteractiveHive", "Standard_D13_v2"},
                {"Sandbox", "Standard_D13_V2"}
            };

            public static string GetSize(string clusterType)
            {
                if (!DefaultSizes.TryGetValue(clusterType.ToLowerInvariant(), out string nodeSize))
                {
                    nodeSize = DefaultSizeIfNotSpecified;
                }

                return nodeSize;
            }
        }

        public static class WorkerNode
        {
            private const string DefaultSizeIfNotSpecified = "Standard_D3_v2";

            private static readonly Dictionary<string, string> DefaultSizes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"spark", "Standard_D12_v2"},
                {"rserver", "Standard_D4_v2"},
                {"mlservices", "Standard_D4_v2"},
                {"InteractiveHive", "Standard_D13_v2"},
            };

            public static string GetSize(string clusterType)
            {
                if (!DefaultSizes.TryGetValue(clusterType.ToLowerInvariant(), out string nodeSize))
                {
                    nodeSize = DefaultSizeIfNotSpecified;
                }

                return nodeSize;
            }
        }

        public static class ZookeeperNode
        {
            private const string DefaultSizeIfNotSpecified = "Standard_A2_v2";

            private static readonly Dictionary<string, string> DefaultSizes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"kafka", "Standard_A4_v2"}
            };

            public static string GetSize(string clusterType)
            {
                if (!DefaultSizes.TryGetValue(clusterType.ToLowerInvariant(), out string nodeSize))
                {
                    nodeSize = DefaultSizeIfNotSpecified;
                }

                return nodeSize;
            }
        }

        public static class EdgeNode
        {
            private const string DefaultSizeIfNotSpecified = "Standard_D4_v2";

            private static readonly Dictionary<string, string> DefaultSizes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            public static string GetSize(string clusterType)
            {
                if (!DefaultSizes.TryGetValue(clusterType.ToLowerInvariant(), out string nodeSize))
                {
                    nodeSize = DefaultSizeIfNotSpecified;
                }

                return nodeSize;
            }
        }
    }
}
