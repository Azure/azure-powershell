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

using Newtonsoft.Json;
using System;
using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    public abstract class DataCollectionController
    {
        public const string RegistryKey = "DataCollectionController";
        public abstract AzurePSDataCollectionProfile GetProfile(Action warningWriter);

        static AzurePSDataCollectionProfile Initialize(IAzureSession session)
        {
            AzurePSDataCollectionProfile result = new AzurePSDataCollectionProfile(true);
            try
            {
                var environmentValue = Environment.GetEnvironmentVariable(AzurePSDataCollectionProfile.EnvironmentVariableName);
                bool enabled = true;
                if (!string.IsNullOrWhiteSpace(environmentValue) && bool.TryParse(environmentValue, out enabled))
                {
                    result.EnableAzureDataCollection = enabled;
                }
                else
                {
                    var store = session.DataStore;
                    string dataPath = Path.Combine(session.ProfileDirectory, AzurePSDataCollectionProfile.DefaultFileName);
                    if (store.FileExists(dataPath))
                    {
                        string contents = store.ReadFileAsText(dataPath);
                        var localResult = JsonConvert.DeserializeObject<AzurePSDataCollectionProfile>(contents);
                        if (localResult != null && localResult.EnableAzureDataCollection.HasValue)
                        {
                            result = localResult;
                        }
                    }
                    else
                    {
                        WritePSDataCollectionProfile(session, new AzurePSDataCollectionProfile(true));
                    }
                }
            }
            catch
            {
                // do not throw for i/o or serialization errors
            }

            return result;
        }

        public static void WritePSDataCollectionProfile(IAzureSession session, AzurePSDataCollectionProfile profile)
        {
            try
            {
                var store = session.DataStore;
                string dataPath = Path.Combine(session.ProfileDirectory, AzurePSDataCollectionProfile.DefaultFileName);
                if (!store.DirectoryExists(session.ProfileDirectory))
                {
                    store.CreateDirectory(session.ProfileDirectory);
                }

                string contents = JsonConvert.SerializeObject(profile);
                store.WriteFile(dataPath, contents);
            }
            catch
            {
                // do not throw for i/o or serialization errors
            }
        }

        public static DataCollectionController Create(IAzureSession session)
        {
            return new MemoryDataCollectionController(Initialize(session));
        }

        public static DataCollectionController Create(AzurePSDataCollectionProfile profile)
        {
            return new MemoryDataCollectionController(profile);
        }

        class MemoryDataCollectionController : DataCollectionController
        {
            object _lock;
            bool? _enabled;

            public MemoryDataCollectionController()
            {
                _lock = new object();
                _enabled = null;
            }

            public MemoryDataCollectionController(AzurePSDataCollectionProfile enabled)
            {
                _lock = new object();
                _enabled = enabled?.EnableAzureDataCollection;
            }

            public override AzurePSDataCollectionProfile GetProfile(Action warningWriter)
            {
                lock (_lock)
                {
                    if (!_enabled.HasValue)
                    {
                        _enabled = true;
                        warningWriter();
                    }

                    return new AzurePSDataCollectionProfile(_enabled.Value);
                }
            }
        }
    }
}
