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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Track2;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using T1 = Microsoft.Azure.Batch;
using T1C = Microsoft.Azure.Batch.Common;
using T2 = Azure.Compute.Batch;

namespace Microsoft.Azure.Commands.Batch.Test.Track2
{
    /// <summary>
    /// The PS objects that several groups of cmdlets share (start task, resource files, user identity, container
    /// settings and registry, identity reference, environment settings, application packages, metadata) must be the same
    /// whether Track 1 or Track 2 reads the service's answer, and must give the same request.
    /// </summary>
    public class Track2ModelMapperTests
    {
        private const string AccountUrl = "https://account.westus.batch.azure.com";

        private const string IdentityId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1";

        private const string HttpUrl = "https://account.blob.core.windows.net/container/file.txt?sv=2024-11-04&sig=a%2Bb%3D";

        private const string ContainerUrl = "https://account.blob.core.windows.net/container";

        private const string ResourceFileIdentity = ",\"identityReference\":{\"resourceId\":\"" + IdentityId + "\"}";

        private static readonly string Key = Convert.ToBase64String(Encoding.UTF8.GetBytes("account-key-not-a-real-key-00000"));

        // A pool with every shared part, in the form the service sends it.
        private static readonly string AllParts = Pool(
            "\"virtualMachineConfiguration\":{\"imageReference\":{\"publisher\":\"canonical\",\"offer\":\"ubuntu\",\"sku\":\"22_04-lts\"},\"nodeAgentSKUId\":\"batch.node.ubuntu 22.04\","
            + "\"containerConfiguration\":{\"type\":\"dockerCompatible\",\"containerImageNames\":[\"ubuntu\"],\"containerRegistries\":["
            + "{\"registryServer\":\"https://myregistry.azurecr.io\",\"username\":\"user1\",\"identityReference\":{\"resourceId\":\"" + IdentityId + "\"}}]}},"
            + "\"startTask\":{\"commandLine\":\"/bin/bash -c 'echo hello'\","
            + "\"containerSettings\":{\"imageName\":\"ubuntu\",\"containerRunOptions\":\"--rm\","
            + "\"registry\":{\"registryServer\":\"myregistry.azurecr.io\",\"username\":\"user1\",\"identityReference\":{\"resourceId\":\"" + IdentityId + "\"}},"
            + "\"workingDirectory\":\"taskWorkingDirectory\",\"containerHostBatchBindMounts\":[{\"source\":\"Shared\",\"isReadOnly\":true},{\"source\":\"Task\"}]},"
            + "\"resourceFiles\":[{\"httpUrl\":\"" + HttpUrl + "\",\"filePath\":\"file.txt\",\"fileMode\":\"0755\"},"
            + "{\"storageContainerUrl\":\"" + ContainerUrl + "\",\"blobPrefix\":\"inputs/\"" + ResourceFileIdentity + "},"
            + "{\"autoStorageContainerName\":\"container2\",\"filePath\":\"dir\"}],"
            + "\"environmentSettings\":[{\"name\":\"A\",\"value\":\"1\"},{\"name\":\"B\",\"value\":\"\"}],"
            + "\"userIdentity\":{\"autoUser\":{\"scope\":\"pool\",\"elevationLevel\":\"admin\"}},\"maxTaskRetryCount\":3,\"waitForSuccess\":true},"
            + "\"applicationPackageReferences\":[{\"applicationId\":\"app1\",\"version\":\"1.0\"},{\"applicationId\":\"app2\"}],"
            + "\"metadata\":[{\"name\":\"owner\",\"value\":\"keyan\"},{\"name\":\"empty\",\"value\":\"\"}]");

        private readonly ITestOutputHelper output;

        public Track2ModelMapperTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        public static IEnumerable<object[]> Pools => new List<object[]>
        {
            new object[] { "all parts", AllParts },
            new object[] { "user name", Pool("\"startTask\":{\"commandLine\":\"cmd /c echo hi\",\"userIdentity\":{\"username\":\"admin1\"}}") },
            new object[] { "setting without a value", Pool("\"startTask\":{\"commandLine\":\"cmd\",\"environmentSettings\":[{\"name\":\"B\"}]}") },
            new object[] { "empty lists", Pool(
                "\"virtualMachineConfiguration\":{\"containerConfiguration\":{\"type\":\"dockerCompatible\",\"containerRegistries\":[]}},"
                + "\"startTask\":{\"commandLine\":\"cmd\",\"resourceFiles\":[],\"environmentSettings\":[],\"containerSettings\":{\"imageName\":\"ubuntu\",\"containerHostBatchBindMounts\":[]}},"
                + "\"applicationPackageReferences\":[],\"metadata\":[]") },
            new object[] { "no parts", "{\"id\":\"pool1\"}" },
        };

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [MemberData(nameof(Pools))]
        public void SharedPartsReadThroughTrack2AreTheSameAsThroughTrack1(string name, string pool)
        {
            Track2TestContext context = NewContext(new RecordingHandler().On("GET /pools/pool1", HttpStatusCode.OK, pool));
            PSCloudPool track1 = new PSCloudPool(context.BatchOMClient.PoolOperations.GetPool("pool1"));
            T2.BatchPool track2 = context.Track2Client.GetPool("pool1").Value;

            List<string> differences = new List<string>();
            differences.AddRange(OutputComparer.Compare(track1.StartTask, Track2ModelMapper.ToPS(track2.StartTask), "StartTask"));
            differences.AddRange(OutputComparer.Compare(
                track1.ApplicationPackageReferences, Track2ModelMapper.ToList(track2.ApplicationPackageReferences, Track2ModelMapper.ToPS), "ApplicationPackageReferences"));
            differences.AddRange(OutputComparer.Compare(track1.Metadata, Track2ModelMapper.ToPS(track2.Metadata), "Metadata"));
            differences.AddRange(OutputComparer.Compare(
                track1.VirtualMachineConfiguration?.ContainerConfiguration?.ContainerRegistries,
                Track2ModelMapper.ToList(track2.VirtualMachineConfiguration?.ContainerConfiguration?.ContainerRegistries, Track2ModelMapper.ToPS),
                "ContainerRegistries"));
            differences.ForEach(this.output.WriteLine);

            Assert.Empty(differences);
            if (name == "all parts")
            {
                PSStartTask startTask = Track2ModelMapper.ToPS(track2.StartTask);
                Assert.Equal("myregistry.azurecr.io", startTask.ContainerSettings.Registry.RegistryServer);
                Assert.Equal(HttpUrl, startTask.ResourceFiles[0].HttpUrl);
                Assert.Equal(2, startTask.ContainerSettings.ContainerHostBatchBindMounts.Count);
                Assert.Equal(T1C.ElevationLevel.Admin, startTask.UserIdentity.AutoUser.ElevationLevel);
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("all parts")]
        [InlineData("user name")]
        [InlineData("empty collections")]
        [InlineData("no parts")]
        public void SharedPartsAreSentThroughTrack2AsThroughTrack1(string name)
        {
            RecordingHandler handler = new RecordingHandler().On("POST /pools", HttpStatusCode.Created);
            Track2TestContext context = NewContext(handler);

            SendThroughTrack1(context, NewParts(name));
            SendThroughTrack2(context, NewParts(name));

            AssertSameRequests(handler);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PartsReadThroughTrack2CanBeSentThroughTrack1()
        {
            // While the cmdlets move one group at a time, objects from a moved cmdlet go into cmdlets that still use
            // Track 1. They're backed by Track 1 objects, so both send what the service returned (except a resource
            // file's identity, which Track 1 drops today: ResourceFileIdentityIsSentByTrack2).
            string pool = AllParts.Replace(ResourceFileIdentity, string.Empty);
            RecordingHandler handler = new RecordingHandler()
                .On("GET /pools/pool1", HttpStatusCode.OK, pool)
                .On("POST /pools", HttpStatusCode.Created);
            Track2TestContext context = NewContext(handler);
            T2.BatchPool read = context.Track2Client.GetPool("pool1").Value;
            Func<Parts> parts = () => new Parts
            {
                StartTask = Track2ModelMapper.ToPS(read.StartTask),
                ApplicationPackageReferences = Track2ModelMapper.ToList(read.ApplicationPackageReferences, Track2ModelMapper.ToPS),
                Metadata = Track2ModelMapper.ToPS(read.Metadata),
            };

            SendThroughTrack1(context, parts());
            SendThroughTrack2(context, parts());

            AssertSameRequests(handler);
            JObject sent = JObject.Parse(handler.Requests.Last().Body);
            JObject original = JObject.Parse(pool);
            foreach (string part in new[] { "startTask", "applicationPackageReferences", "metadata" })
            {
                Assert.True(JToken.DeepEquals(original[part], sent[part]), part + ": " + sent[part]);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BindMountsSetThroughThePropertyAreSentByTrack2()
        {
            // Today Track 1 doesn't send a bind mount list set through the ContainerHostBatchBindMounts property: it sends
            // an empty list, which mounts no folder at all (only the constructor's list is sent; reported as a bug).
            // Track 2 sends what the property shows.
            RecordingHandler handler = new RecordingHandler().On("POST /pools", HttpStatusCode.Created);
            Track2TestContext context = NewContext(handler);
            Func<Parts> parts = () => new Parts
            {
                StartTask = new PSStartTask("cmd")
                {
                    ContainerSettings = new PSTaskContainerSettings("ubuntu")
                    {
                        ContainerHostBatchBindMounts = new List<PSContainerHostBatchBindMountEntry>
                        {
                            new PSContainerHostBatchBindMountEntry { Source = "Shared", IsReadOnly = true },
                        },
                    },
                },
            };

            SendThroughTrack1(context, parts());
            SendThroughTrack2(context, parts());

            string path = "startTask.containerSettings.containerHostBatchBindMounts";
            Assert.Equal("[]", JObject.Parse(handler.Requests[0].Body).SelectToken(path).ToString(Newtonsoft.Json.Formatting.None));
            Assert.Equal("[{\"source\":\"Shared\",\"isReadOnly\":true}]", JObject.Parse(handler.Requests[1].Body).SelectToken(path).ToString(Newtonsoft.Json.Formatting.None));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ASettingWithoutAValueIsSentByTrack2()
        {
            // The service allows an environment setting without a value, and both tracks read it as null. Today Track 1
            // can't send it: Utils.CreateSyncedDict fails with a NullReferenceException, for example when
            // Set-AzBatchPool sends such a pool back (reported as a bug). Track 2 sends it without a value.
            RecordingHandler handler = new RecordingHandler().On("POST /pools", HttpStatusCode.Created);
            Track2TestContext context = NewContext(handler);
            Func<Parts> parts = () => new Parts
            {
                StartTask = new PSStartTask("cmd") { EnvironmentSettings = new Dictionary<string, string> { { "B", null } } },
            };

            Assert.Throws<NullReferenceException>(() => SendThroughTrack1(context, parts()));
            SendThroughTrack2(context, parts());

            Assert.Equal("[{\"name\":\"B\"}]", JObject.Parse(handler.Requests.Single().Body).SelectToken("startTask.environmentSettings").ToString(Newtonsoft.Json.Formatting.None));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceFileIdentityIsSentByTrack2()
        {
            // Today Track 1 drops a resource file's identity reference when it sends a start task or a task
            // (Utils.ConvertResourceFile builds a new resource file without it), for example when Set-AzBatchPool sends
            // back a pool read from the service; the node then can't download the files (reported as a bug). Track 2 sends it.
            RecordingHandler handler = new RecordingHandler().On("POST /pools", HttpStatusCode.Created);
            Track2TestContext context = NewContext(handler);
            Func<Parts> parts = () => new Parts
            {
                StartTask = new PSStartTask("cmd")
                {
                    ResourceFiles = new List<PSResourceFile>
                    {
                        new PSResourceFile(T1.ResourceFile.FromStorageContainerUrl(ContainerUrl, new T1.ComputeNodeIdentityReference { ResourceId = IdentityId }, null, "inputs/", null)),
                    },
                },
            };

            SendThroughTrack1(context, parts());
            SendThroughTrack2(context, parts());

            string path = "startTask.resourceFiles[0].identityReference.resourceId";
            Assert.Null(JObject.Parse(handler.Requests[0].Body).SelectToken(path));
            Assert.Equal(IdentityId, (string)JObject.Parse(handler.Requests[1].Body).SelectToken(path));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TheComparerChecksTypes()
        {
            // Review on #30434: collections of another type (or with items of another type) are a difference too.
            Assert.Single(OutputComparer.Compare(new List<PSResourceFile>(), new PSResourceFile[0], "Items"));
            Assert.Single(OutputComparer.Compare(new List<string>(), new List<int>(), "Items"));
            Assert.Single(OutputComparer.Compare(new Dictionary<string, string>(), new Hashtable(), "Items"));
            Assert.Single(OutputComparer.Compare(new List<object> { 1 }, new List<object> { 1L }, "Items"));
            Assert.Empty(OutputComparer.Compare(new List<string> { "a" }, new List<string> { "a" }, "Items"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Rules()
        {
            Assert.Null(Track2ModelMapper.ToDateTimeOrNull(null));
            Assert.Null(Track2ModelMapper.ToDateTimeOrNull(default(DateTimeOffset)));
            DateTime? time = Track2ModelMapper.ToDateTimeOrNull(new DateTimeOffset(2026, 11, 10, 8, 0, 0, TimeSpan.FromHours(-8)));
            Assert.Equal(new DateTime(2026, 11, 10, 16, 0, 0, DateTimeKind.Utc), time);
            Assert.Equal(DateTimeKind.Utc, time.Value.Kind);

            Assert.Null(Track2ModelMapper.ToETag(default(global::Azure.ETag)));
            Assert.Equal("0x8DE1A2B3C4D5E6F", Track2ModelMapper.ToETag(new global::Azure.ETag("0x8DE1A2B3C4D5E6F")));
            Assert.Null(Track2ModelMapper.ToUrl(null));
            Assert.Equal("myregistry.azurecr.io", Track2ModelMapper.ToUrl(new Uri("myregistry.azurecr.io", UriKind.RelativeOrAbsolute)));

            ISet<string> selected = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "id", "state" };
            Assert.True(Track2ModelMapper.IsSelected(null, "currentDedicatedNodes"));
            Assert.True(Track2ModelMapper.IsSelected(selected, "state"));
            Assert.False(Track2ModelMapper.IsSelected(selected, "currentDedicatedNodes"));
        }

        private sealed class Parts
        {
            public PSStartTask StartTask { get; set; }

            public IList<PSApplicationPackageReference> ApplicationPackageReferences { get; set; }

            public IDictionary Metadata { get; set; }
        }

        // The shared parts as a script builds them.
        private static Parts NewParts(string name)
        {
            switch (name)
            {
                case "all parts":
                    return new Parts
                    {
                        StartTask = new PSStartTask("/bin/bash -c 'echo hello'")
                        {
                            ContainerSettings = new PSTaskContainerSettings(
                                "ubuntu",
                                "--rm",
                                new PSContainerRegistry("user1", "secret", "myregistry.azurecr.io", new PSComputeNodeIdentityReference { ResourceId = IdentityId }),
                                T1C.ContainerWorkingDirectory.TaskWorkingDirectory,
                                new List<T1.ContainerHostBatchBindMountEntry>
                                {
                                    new T1.ContainerHostBatchBindMountEntry { Source = "Shared", IsReadOnly = true },
                                    new T1.ContainerHostBatchBindMountEntry { Source = "Task" },
                                }),
                            EnvironmentSettings = new Dictionary<string, string> { { "A", "1" }, { "B", string.Empty } },
                            MaxTaskRetryCount = 3,
                            ResourceFiles = new List<PSResourceFile>
                            {
                                new PSResourceFile(T1.ResourceFile.FromUrl(HttpUrl, "file.txt", "0755")),
                                new PSResourceFile(T1.ResourceFile.FromStorageContainerUrl(ContainerUrl, null, "inputs/", null)),
                                new PSResourceFile(T1.ResourceFile.FromAutoStorageContainer("container2", "dir", null, null)),
                            },
                            UserIdentity = new PSUserIdentity(new PSAutoUserSpecification(T1C.AutoUserScope.Pool, T1C.ElevationLevel.Admin)),
                            WaitForSuccess = true,
                        },
                        ApplicationPackageReferences = new List<PSApplicationPackageReference>
                        {
                            new PSApplicationPackageReference { ApplicationId = "app1", Version = "1.0" },
                            new PSApplicationPackageReference { ApplicationId = "app2" },
                        },
                        Metadata = new Dictionary<string, string> { { "owner", "keyan" }, { "empty", string.Empty } },
                    };
                case "user name":
                    return new Parts { StartTask = new PSStartTask("cmd /c echo hi") { UserIdentity = new PSUserIdentity("admin1") } };
                case "empty collections":
                    return new Parts
                    {
                        StartTask = new PSStartTask("cmd")
                        {
                            ContainerSettings = new PSTaskContainerSettings("ubuntu", containerHostBatchBindMounts: new List<T1.ContainerHostBatchBindMountEntry>()),
                            EnvironmentSettings = new Dictionary<string, string>(),
                            ResourceFiles = new List<PSResourceFile>(),
                        },
                        ApplicationPackageReferences = new List<PSApplicationPackageReference>(),
                        Metadata = new Dictionary<string, string>(),
                    };
                case "no parts":
                    return new Parts();
                default:
                    throw new ArgumentException(name);
            }
        }

        // What New-AzBatchPool does with these parts today (BatchClient.CreatePool).
        private static void SendThroughTrack1(Track2TestContext context, Parts parts)
        {
            T1.CloudPool pool = context.BatchOMClient.PoolOperations.CreatePool();
            pool.Id = "pool1";
            pool.VirtualMachineSize = "standard_d2s_v3";
            if (parts.StartTask != null)
            {
                Utils.Utils.StartTaskSyncCollections(parts.StartTask);
                pool.StartTask = parts.StartTask.omObject;
            }

            if (parts.Metadata != null)
            {
                pool.Metadata = new List<T1.MetadataItem>();
                foreach (DictionaryEntry m in parts.Metadata)
                {
                    pool.Metadata.Add(new T1.MetadataItem(m.Key.ToString(), m.Value?.ToString()));
                }
            }

            if (parts.ApplicationPackageReferences != null)
            {
                pool.ApplicationPackageReferences = parts.ApplicationPackageReferences.ToList().ConvertAll(apr => apr.omObject);
            }

            pool.Commit();
        }

        private static void SendThroughTrack2(Track2TestContext context, Parts parts)
        {
            T2.BatchPoolCreateOptions pool = new T2.BatchPoolCreateOptions("pool1", "standard_d2s_v3")
            {
                StartTask = Track2ModelMapper.ToTrack2(parts.StartTask),
            };
            Track2ModelMapper.SetMetadata(pool.Metadata, parts.Metadata);
            Track2ModelMapper.SetList(pool.ApplicationPackageReferences, parts.ApplicationPackageReferences?.Select(Track2ModelMapper.ToTrack2));
            context.Track2Client.CreatePool(pool);
        }

        private void AssertSameRequests(RecordingHandler handler)
        {
            List<RecordedRequest> creates = handler.Requests.Where(r => r.Method == "POST").ToList();
            Assert.Equal(2, creates.Count);
            JObject track1 = JObject.Parse(creates[0].Body);
            JObject track2 = JObject.Parse(creates[1].Body);
            this.output.WriteLine("Track 1: " + track1.ToString(Newtonsoft.Json.Formatting.None));
            this.output.WriteLine("Track 2: " + track2.ToString(Newtonsoft.Json.Formatting.None));
            Assert.True(JToken.DeepEquals(track1, track2), "Track 1: " + track1.ToString(Newtonsoft.Json.Formatting.None) + " Track 2: " + track2.ToString(Newtonsoft.Json.Formatting.None));
        }

        private static string Pool(string parts)
        {
            return "{\"id\":\"pool1\",\"vmSize\":\"standard_d2s_v3\"," + parts + "}";
        }

        private static Track2TestContext NewContext(RecordingHandler handler)
        {
            return new Track2TestContext(null, "account", AccountUrl, handler, Key);
        }
    }
}
