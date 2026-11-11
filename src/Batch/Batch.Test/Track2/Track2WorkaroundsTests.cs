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

using Microsoft.Azure.Commands.Batch.Track2.Workarounds;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xunit;
using AzureNamedKeyCredential = Azure.AzureNamedKeyCredential;
using HttpClientTransport = Azure.Core.Pipeline.HttpClientTransport;
using T2 = Azure.Compute.Batch;

namespace Microsoft.Azure.Commands.Batch.Test.Track2
{
    public class Track2WorkaroundsTests
    {
        private const string AccountUrl = "https://account.westus.batch.azure.com";

        private const string RegistryServerPath = "virtualMachineConfiguration.containerConfiguration.containerRegistries[0].registryServer";

        private static readonly string Key = Convert.ToBase64String(Encoding.UTF8.GetBytes("account-key-not-a-real-key-00000"));

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("job", false)]
        [InlineData("job", true)]
        [InlineData("schedule", false)]
        [InlineData("schedule", true)]
        [InlineData("task", false)]
        [InlineData("task", true)]
        [InlineData("pool", false)]
        [InlineData("pool", true)]
        [InlineData("files", false)]
        [InlineData("files", true)]
        public void Int64ValuesAreReadAsTheServiceSendsThem(string kind, bool asText)
        {
            RecordingHandler handler = new RecordingHandler().On(Route(kind), HttpStatusCode.OK, Answer(kind, asText));

            Assert.Equal(Expected(kind), Read(NewContext(handler).Track2Client, kind));

            // The service sends numbers, which Azure.Compute.Batch 1.0.0 can't read. When this starts to pass for
            // numbers too, a newer SDK fixed it and the workaround can go.
            if (asText)
            {
                Assert.Equal(Expected(kind), Read(ClientWithoutWorkarounds(handler), kind));
            }
            else
            {
                Assert.Throws<InvalidOperationException>(() => Read(ClientWithoutWorkarounds(handler), kind));
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("/jobs/job1/tasks/task1/files/result.json")]
        [InlineData("/pools/pool1/nodes/node1/files/startup%2Fstdout.txt")]
        public void FileContentIsNeverChanged(string path)
        {
            string content = "{\"contentLength\":5,\"readIOps\":1,\"settings\":{\"port\":80}}";
            RecordingHandler handler = new RecordingHandler().On("GET " + path, HttpStatusCode.OK, content);
            T2.BatchClient client = NewContext(handler).Track2Client;

            BinaryData file = path.StartsWith("/jobs/", StringComparison.Ordinal)
                ? client.GetTaskFile("job1", "task1", "result.json").Value
                : client.GetNodeFile("pool1", "node1", "startup/stdout.txt").Value;

            Assert.Equal(content, file.ToString());
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("myregistry.azurecr.io")]
        [InlineData("https://myregistry.azurecr.io")]
        [InlineData("myregistry.azurecr.io:5000")]
        [InlineData("docker.io")]
        public void RegistryServerIsSentAsTyped(string registryServer)
        {
            RecordingHandler handler = new RecordingHandler().On("POST /pools", HttpStatusCode.Created);

            NewContext(handler).Track2Client.CreatePool(PoolWithRegistry(Track2Workarounds.ToExactUrl(registryServer)));

            Assert.Equal(registryServer, (string)SentPool(handler).SelectToken(RegistryServerPath));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WithoutTheWorkaroundTheRegistryServerFailsOrChanges()
        {
            RecordingHandler handler = new RecordingHandler().On("POST /pools", HttpStatusCode.Created);
            T2.BatchClient client = ClientWithoutWorkarounds(handler);

            // When these stop failing or changing the text, a newer SDK fixed it and the workaround can go.
            Assert.Throws<InvalidOperationException>(() => client.CreatePool(PoolWithRegistry(new Uri("myregistry.azurecr.io", UriKind.RelativeOrAbsolute))));
            client.CreatePool(PoolWithRegistry(new Uri("https://myregistry.azurecr.io")));
            Assert.Equal("https://myregistry.azurecr.io/", (string)SentPool(handler).SelectToken(RegistryServerPath));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("myregistry.azurecr.io")]
        [InlineData("https://myregistry.azurecr.io")]
        public void RegistryServerIsReadAsSent(string registryServer)
        {
            string pool = PoolJson("\"containerConfiguration\":{\"type\":\"dockerCompatible\",\"containerRegistries\":[{\"registryServer\":\"" + registryServer + "\",\"username\":\"user\"}]}");
            RecordingHandler handler = new RecordingHandler().On("GET /pools/pool1", HttpStatusCode.OK, pool);
            Track2TestContext context = NewContext(handler);

            T2.ContainerRegistryReference registry = context.Track2Client.GetPool("pool1").Value.VirtualMachineConfiguration.ContainerConfiguration.ContainerRegistries.Single();

            Assert.Equal(registryServer, registry.RegistryServerUri.OriginalString);
            Assert.Equal(registryServer, context.BatchOMClient.PoolOperations.GetPool("pool1").VirtualMachineConfiguration.ContainerConfiguration.ContainerRegistries.Single().RegistryServer);
        }

        // The extensions of the live check on Nov 10 (bug 40599114): Key Vault as the Batch docs show it, and Application
        // Health; and one with a date-like text, a decimal, false and null.
        public static IEnumerable<object[]> Settings => new List<object[]>
        {
            new object[] { "{\"secretsManagementSettings\":{\"pollingIntervalInS\":\"3600\",\"certificateStoreLocation\":\"/var/lib/waagent/Microsoft.Azure.KeyVault.Store\",\"requireInitialSync\":true,\"observedCertificates\":[\"https://example.vault.azure.net/secrets/cert1\"]}}" },
            new object[] { "{\"protocol\":\"http\",\"port\":80,\"requestPath\":\"/\"}" },
            new object[] { "{\"since\":\"2026-11-10T00:00:00Z\",\"ratio\":0.25,\"enabled\":false,\"nothing\":null}" },
        };

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [MemberData(nameof(Settings))]
        public void ExtensionSettingsAreReadAsTrack1ReadsThem(string settings)
        {
            string pool = PoolJson("\"extensions\":[{\"name\":\"extension1\",\"publisher\":\"Microsoft.ManagedServices\",\"type\":\"ApplicationHealthLinux\",\"typeHandlerVersion\":\"2.0\",\"settings\":" + settings + "}]");
            RecordingHandler handler = new RecordingHandler()
                .On("GET /pools/pool1", HttpStatusCode.OK, pool)
                .On("GET /pools", HttpStatusCode.OK, "{\"value\":[" + pool + "]}");
            Track2TestContext context = NewContext(handler);

            T2.VMExtension extension = context.Track2Client.GetPool("pool1").Value.VirtualMachineConfiguration.Extensions.Single();
            Assert.Single(context.Track2Client.GetPools());
            object track1 = context.BatchOMClient.PoolOperations.GetPool("pool1").VirtualMachineConfiguration.Extensions.Single().Settings;

            Assert.True(JToken.DeepEquals(Assert.IsAssignableFrom<JToken>(track1), Track2Workarounds.FromSettings(extension.Settings)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WithoutTheWorkaroundExtensionSettingsThatArentTextFail()
        {
            string pool = PoolJson("\"extensions\":[{\"name\":\"extension1\",\"publisher\":\"Microsoft.ManagedServices\",\"type\":\"ApplicationHealthLinux\",\"settings\":{\"port\":80}}]");
            RecordingHandler handler = new RecordingHandler().On("GET /pools/pool1", HttpStatusCode.OK, pool);

            // Bug 40599114. When this stops failing, a newer SDK fixed it and the workaround can go.
            Assert.Throws<InvalidOperationException>(() => ClientWithoutWorkarounds(handler).GetPool("pool1"));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [MemberData(nameof(Settings))]
        public void ExtensionSettingsAreSentAsGiven(string settings)
        {
            RecordingHandler handler = new RecordingHandler().On("POST /pools", HttpStatusCode.Created);
            T2.VMExtension extension = new T2.VMExtension("extension1", "Microsoft.ManagedServices", "ApplicationHealthLinux");
            foreach (KeyValuePair<string, string> setting in Track2Workarounds.ToSettings(JObject.Parse(settings)))
            {
                extension.Settings.Add(setting);
            }

            NewContext(handler).Track2Client.CreatePool(NewPool(vm => vm.Extensions.Add(extension)));

            Assert.True(JToken.DeepEquals(JObject.Parse(settings), SentPool(handler).SelectToken("virtualMachineConfiguration.extensions[0].settings")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OnlyTheseValuesChange()
        {
            string answer = "{\"id\":\"job1\",\"displayName\":\"<b>caf\u00e9</b> & \\\"tea\\\"\",\"creationTime\":\"2026-11-10T00:00:00.1234567Z\",\"stats\":{\"readIOps\":12,\"readIOGiB\":2.123456789}}";

            using (JsonDocument fixedAnswer = JsonDocument.Parse(Track2Workarounds.FixAnswer(Encoding.UTF8.GetBytes(answer))))
            {
                JsonElement job = fixedAnswer.RootElement;
                Assert.Equal("<b>caf\u00e9</b> & \"tea\"", job.GetProperty("displayName").GetString());
                Assert.Equal("2026-11-10T00:00:00.1234567Z", job.GetProperty("creationTime").GetString());
                Assert.Equal("12", job.GetProperty("stats").GetProperty("readIOps").GetString());
                Assert.Equal("2.123456789", job.GetProperty("stats").GetProperty("readIOGiB").GetRawText());
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OtherBodiesAreLeftAsTheyAre()
        {
            Assert.Null(Track2Workarounds.FixAnswer(Encoding.UTF8.GetBytes("{\"id\":\"pool1\",\"state\":\"active\"}")));
            Assert.Null(Track2Workarounds.FixAnswer(Encoding.UTF8.GetBytes("<html>\"readIOps\"</html>")));
            Assert.Null(Track2Workarounds.FixAnswer(Encoding.UTF8.GetBytes("{\"readIOps\":\"12\",\"settings\":{\"a\":\"b\"}}")));
            Assert.Null(Track2Workarounds.FixRequest(Encoding.UTF8.GetBytes("{\"id\":\"pool1\",\"vmSize\":\"standard_d2s_v3\"}")));
        }

        private static string Route(string kind)
        {
            switch (kind)
            {
                case "job": return "GET /jobs/job1";
                case "schedule": return "GET /jobschedules/schedule1";
                case "task": return "GET /jobs/job1/tasks/task1";
                case "pool": return "GET /pools/pool1";
                case "files": return "GET /jobs/job1/tasks/task1/files";
                default: throw new ArgumentException(kind);
            }
        }

        // Answers in the form the service sends them, with the int64 values as numbers or as text.
        private static string Answer(string kind, bool asText)
        {
            Func<long, string> value = v => asText ? "\"" + v + "\"" : v.ToString();
            string times = "\"startTime\":\"2026-11-10T00:00:00Z\",\"lastUpdateTime\":\"2026-11-10T01:00:00Z\"";
            string times2 = times + ",\"userCPUTime\":\"PT1M\",\"kernelCPUTime\":\"PT2S\",\"wallClockTime\":\"PT3M\",\"waitTime\":\"PT4S\",\"readIOGiB\":1.5,\"writeIOGiB\":2.5";
            string io = "\"readIOps\":" + value(12) + ",\"writeIOps\":" + value(34);
            string counts = "\"numSucceededTasks\":" + value(5) + ",\"numFailedTasks\":" + value(1) + ",\"numTaskRetries\":" + value(2);
            switch (kind)
            {
                case "job":
                    return "{\"id\":\"job1\",\"stats\":{\"url\":\"" + AccountUrl + "/jobs/job1\"," + times2 + "," + io + "," + counts + "}}";
                case "schedule":
                    return "{\"id\":\"schedule1\",\"stats\":{\"url\":\"" + AccountUrl + "/jobschedules/schedule1\"," + times2 + "," + io + "," + counts + "}}";
                case "task":
                    return "{\"id\":\"task1\",\"stats\":{\"url\":\"" + AccountUrl + "/jobs/job1/tasks/task1\"," + times2 + "," + io + "}}";
                case "pool":
                    return "{\"id\":\"pool1\",\"stats\":{\"url\":\"" + AccountUrl + "/pools/pool1\"," + times + ",\"resourceStats\":{" + times
                        + ",\"avgCPUPercentage\":2.5,\"avgMemoryGiB\":1,\"peakMemoryGiB\":2,\"avgDiskGiB\":3,\"peakDiskGiB\":4,\"diskReadIOps\":" + value(100)
                        + ",\"diskWriteIOps\":" + value(200) + ",\"diskReadGiB\":5,\"diskWriteGiB\":6,\"networkReadGiB\":7,\"networkWriteGiB\":8}}}";
                case "files":
                    return "{\"value\":[{\"name\":\"stdout.txt\",\"url\":\"" + AccountUrl + "/jobs/job1/tasks/task1/files/stdout.txt\",\"isDirectory\":false,"
                        + "\"properties\":{\"lastModified\":\"2026-11-10T00:00:00Z\",\"contentLength\":" + value(123) + ",\"contentType\":\"text/plain\"}}]}";
                default:
                    throw new ArgumentException(kind);
            }
        }

        private static long[] Expected(string kind)
        {
            switch (kind)
            {
                case "job":
                case "schedule":
                    return new long[] { 12, 34, 5, 1, 2 };
                case "task":
                    return new long[] { 12, 34 };
                case "pool":
                    return new long[] { 100, 200 };
                case "files":
                    return new long[] { 123 };
                default:
                    throw new ArgumentException(kind);
            }
        }

        private static long[] Read(T2.BatchClient client, string kind)
        {
            string[] stats = { "stats" };
            switch (kind)
            {
                case "job":
                    T2.BatchJobStatistics job = client.GetJob("job1", expand: stats).Value.JobStatistics;
                    return new[] { job.ReadIops, job.WriteIops, job.SucceededTasksCount, job.FailedTasksCount, job.TaskRetriesCount };
                case "schedule":
                    T2.BatchJobScheduleStatistics schedule = client.GetJobSchedule("schedule1", expand: stats).Value.JobScheduleStatistics;
                    return new[] { schedule.ReadIops, schedule.WriteIops, schedule.SucceededTasksCount, schedule.FailedTasksCount, schedule.TaskRetriesCount };
                case "task":
                    T2.BatchTaskStatistics task = client.GetTask("job1", "task1", expand: stats).Value.TaskStatistics;
                    return new[] { task.ReadIops, task.WriteIops };
                case "pool":
                    T2.BatchPoolResourceStatistics pool = client.GetPool("pool1", expand: stats).Value.PoolStatistics.ResourceStatistics;
                    return new[] { pool.DiskReadIops, pool.DiskWriteIops };
                case "files":
                    return client.GetTaskFiles("job1", "task1").Select(f => f.Properties.ContentLength).ToArray();
                default:
                    throw new ArgumentException(kind);
            }
        }

        private static string PoolJson(string virtualMachineConfigurationParts)
        {
            return "{\"id\":\"pool1\",\"vmSize\":\"standard_d2s_v3\",\"virtualMachineConfiguration\":{\"imageReference\":{\"publisher\":\"canonical\","
                + "\"offer\":\"ubuntu\",\"sku\":\"22_04-lts\"},\"nodeAgentSKUId\":\"batch.node.ubuntu 22.04\"," + virtualMachineConfigurationParts + "}}";
        }

        private static T2.BatchPoolCreateOptions PoolWithRegistry(Uri registryServer)
        {
            T2.BatchContainerConfiguration containers = new T2.BatchContainerConfiguration(T2.ContainerType.DockerCompatible);
            containers.ContainerRegistries.Add(new T2.ContainerRegistryReference { RegistryServerUri = registryServer, Username = "user" });
            return NewPool(vm => vm.ContainerConfiguration = containers);
        }

        private static T2.BatchPoolCreateOptions NewPool(Action<T2.VirtualMachineConfiguration> configure)
        {
            T2.VirtualMachineConfiguration vm = new T2.VirtualMachineConfiguration(
                new T2.BatchVmImageReference { Publisher = "canonical", Offer = "ubuntu", Sku = "22_04-lts" }, "batch.node.ubuntu 22.04");
            configure(vm);
            return new T2.BatchPoolCreateOptions("pool1", "standard_d2s_v3") { VirtualMachineConfiguration = vm };
        }

        private static JObject SentPool(RecordingHandler handler)
        {
            return JObject.Parse(handler.Requests.Last().Body);
        }

        private static Track2TestContext NewContext(RecordingHandler handler)
        {
            return new Track2TestContext(null, "account", AccountUrl, handler, Key);
        }

        // A Track 2 client as Azure.Compute.Batch 1.0.0 comes, without the workarounds.
        private static T2.BatchClient ClientWithoutWorkarounds(RecordingHandler handler)
        {
            T2.BatchClientOptions options = new T2.BatchClientOptions { Transport = new HttpClientTransport(new HttpClient(handler)) };
            options.Retry.MaxRetries = 0;
            return new T2.BatchClient(new Uri(AccountUrl), new AzureNamedKeyCredential("account", Key), options);
        }
    }
}
