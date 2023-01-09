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

using Microsoft.Azure.Commands.TestFx;
using Microsoft.Azure.Commands.TestFx.Recorder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Test.HttpRecorder
{
    public class HttpMockServer : DelegatingHandler
    {
        private const string TEST_MODE_HEADER = "azSdkTestPlayBackMode";
        private static AssetNames _assetNames;
        private static Records _records;
        private static List<HttpMockServer> _servers;
        private static bool _initialized;
        private static readonly Random _randomGenerator = new Random();

        public static string CallerIdentity { get; set; }
        public static string TestIdentity { get; set; }
        public static HttpRecorderMode Mode { get; set; }
        public static IRecordMatcher Matcher { get; set; }
        public static string RecordsDirectory { get; set; }
        public static Dictionary<string, string> Variables { get; private set; }
        public static FileSystemUtils FileSystemUtilsObject { get; set; }

        private HttpMockServer()
        {
        }

        public static void Initialize(Type callerIdentity, string testIdentity)
        {
            Initialize(callerIdentity, testIdentity, GetCurrentMode());
        }

        public static void Initialize(string callerIdentity, string testIdentity)
        {
            Initialize(callerIdentity, testIdentity, GetCurrentMode());
        }

        public static void Initialize(Type callerIdentity, string testIdentity, HttpRecorderMode mode)
        {
            Initialize(callerIdentity.Name, testIdentity, mode);
        }

        public static void Initialize(string callerIdentity, string testIdentity, HttpRecorderMode mode)
        {
            _servers = new List<HttpMockServer>();
            _assetNames = new AssetNames();
            _records = new Records(Matcher);

            CallerIdentity = callerIdentity;
            TestIdentity = testIdentity;
            Mode = mode;
            Variables = new Dictionary<string, string>();

            if (Mode == HttpRecorderMode.Playback)
            {
                var recordDir = Path.Combine(RecordsDirectory, CallerIdentity);
                var fileName = Path.GetFullPath(Path.Combine(recordDir, testIdentity.Replace(".json", "") + ".json"));
                if (!FileSystemUtilsObject.DirectoryExists(recordDir) || !FileSystemUtilsObject.FileExists(fileName))
                {
                    throw new ArgumentException($"Unable to find recorded mock file '{fileName}'.", "callerIdentity");
                }
                else
                {
                    RecordEntryPack pack = RecordEntryPack.Deserialize(fileName);
                    lock (_records)
                    {
                        pack.Entries.ForEach(p => _records.Enqueue(p));
                    }
                    foreach (var func in pack.Names.Keys)
                    {
                        pack.Names[func].ForEach(n => _assetNames.Enqueue(func, n));
                    }
                    if (pack.Variables != null)
                    {
                        Variables = pack.Variables;
                    }
                }
            }

            _initialized = true;
        }

        public static HttpMockServer CreateInstance()
        {
            if (!_initialized)
            {
                throw new InvalidOperationException("HttpMockServer has not been initialized yet. Use HttpMockServer.Initialize() method to initialize the HttpMockServer.");
            }
            HttpMockServer server = new HttpMockServer();
            _servers.Add(server);
            return server;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (Mode == HttpRecorderMode.Playback)
            {
                // Will throw KeyNotFoundException if the request is not recorded
                lock (_records)
                {
                    var key = Matcher.GetMatchingKey(request);
                    var queue = _records[key];
                    if (!queue.Any())
                    {
                        throw new InvalidOperationException($"Queue empty for request {RecorderUtilities.DecodeBase64AsUri(key)}");
                    }

                    HttpResponseMessage result = queue.Dequeue().GetResponse();
                    result = AddTestModeHeaders(result);
                    result.RequestMessage = request;
                    return Task.FromResult(result);
                }
            }
            else
            {
                lock (this)
                {
                    return base.SendAsync(request, cancellationToken).ContinueWith(response =>
                    {
                        HttpResponseMessage result = response.Result;
                        if (Mode == HttpRecorderMode.Record)
                        {
                            lock (_records)
                            {
                                _records.Enqueue(new RecordEntry(result));
                            }
                        }

                        return result;
                    });
                }
            }
        }

        private HttpResponseMessage AddTestModeHeaders(HttpResponseMessage response)
        {
            if (response != null)
            {
                response?.Headers?.Add(TEST_MODE_HEADER, "true");
            }

            return response;
        }

        public static string GetAssetName(string testName, string prefix)
        {
            if (Mode == HttpRecorderMode.Playback)
                return _assetNames[testName].Dequeue();

            string generated = prefix + _randomGenerator.Next(9999);

            if (Mode == HttpRecorderMode.Record)
            {
                if (_assetNames.ContainsKey(testName))
                {
                    while (_assetNames[testName].Any(n => n.Equals(generated)))
                    {
                        generated = prefix + _randomGenerator.Next(9999);
                    }
                }
                _assetNames.Enqueue(testName, generated);
            }

            return generated;
        }

        /// <summary>
        /// Gets the asset unique identifier. This is used to store the GUID in the recording so it can be easily retrieved.
        /// This behaves the same as name generation, but if useful if the client is required to generate Guids for the service.
        /// </summary>
        /// <param name="testName">Name of the test.</param>
        /// <returns></returns>
        public static Guid GetAssetGuid(string testName)
        {
            if (Mode == HttpRecorderMode.Playback)
                return new Guid(_assetNames[testName].Dequeue());

            string generated = Guid.NewGuid().ToString();

            if (Mode == HttpRecorderMode.Record)
            {
                if (_assetNames.ContainsKey(testName))
                {
                    // this should never happen, but just in case.
                    while (_assetNames[testName].Any(n => n.Equals(generated)))
                    {
                        generated = Guid.NewGuid().ToString();
                    }
                }
                _assetNames.Enqueue(testName, generated);
            }

            return new Guid(generated);
        }

        /// <summary>
        /// Returns stored variable or variableValue if variableName is not found.
        /// </summary>
        /// <param name="variableName">Variable name</param>
        /// <param name="variableValue">Variable value to be preserved in recording mode.</param>
        /// <returns></returns>
        public static string GetVariable(string variableName, string variableValue)
        {
            if (Mode == HttpRecorderMode.Record)
            {
                Variables[variableName] = variableValue;
                return variableValue;
            }
            else
            {
                if (Variables.ContainsKey(variableName))
                    return Variables[variableName];

                return variableValue;
            }
        }

        public void InjectRecordEntry(RecordEntry record)
        {
            if (Mode == HttpRecorderMode.Playback)
            {
                lock (_records)
                {
                    _records.Enqueue(record);
                }
            }
        }

        public static string Flush(string outputPath = null)
        {
            string fileName = string.Empty;
            if (Mode == HttpRecorderMode.Record && _records.Count > 0)
            {
                RecordEntryPack pack = new RecordEntryPack();
                string perfImpactFileName = string.Empty;
                string fileDirectory = Path.Combine(outputPath ?? RecordsDirectory, CallerIdentity);
                RecorderUtilities.EnsureDirectoryExists(fileDirectory);

                lock (_records)
                {
                    foreach (RecordEntry recordEntry in _records.GetAllEntities())
                    {
                        recordEntry.RequestHeaders.Remove("Authorization");
                        recordEntry.RequestUri = new Uri(recordEntry.RequestUri).PathAndQuery;
                        pack.Entries.Add(recordEntry);
                    }
                }

                fileName = Path.Combine(fileDirectory, (TestIdentity ?? "record") + ".json");
                pack.Variables = Variables;
                pack.Names = _assetNames.Names;

                pack.Serialize(fileName);
            }

            _servers.ForEach(s => s.Dispose());

            return fileName;
        }

        public static HttpRecorderMode GetCurrentMode()
        {
            HttpRecorderMode mode;
            string input = FileSystemUtilsObject?.GetEnvironmentVariable(ConnectionStringKeys.AZURE_TEST_MODE_ENVKEY);

            if (string.IsNullOrEmpty(input))
            {
                mode = HttpRecorderMode.Playback;
            }
            else
            {
                mode = (HttpRecorderMode)Enum.Parse(typeof(HttpRecorderMode), input, true);
            }

            return mode;
        }
    }

    public enum HttpRecorderMode
    {
        /// <summary>
        /// The mock server does not do anything.
        /// </summary>
        None,

        /// <summary>
        /// In this mode the mock server watches the out-going requests and records
        /// their corresponding responses.
        /// </summary>
        Record,

        /// <summary>
        /// The playback mode should always be after a successful record session.
        /// The mock server matches the given requests and return their stored 
        /// corresponding responses.
        /// </summary>
        Playback
    }
}
