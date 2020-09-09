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
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Xunit;

namespace Microsoft.Azure.PowerShell.AzPredictor.Test
{
    /// <summary>
    /// The class to prepare model for all the tests.
    /// </summary>
    public sealed class ModelFixture : IDisposable
    {
        private const string CommandsModelZip = "CommandsModel.zip";
        private const string CommandsModelJson = "CommandsModel.json";
        private const string PredictionsModelZip = "PredictionsModel.zip";
        private const string PredictionsModelJson = "PredictionsModel.json";
        private const string DataDirectoryName = "Data";

        /// <summary>
        /// Gets a list of string for the commands.
        /// </summary>
        public IList<string> CommandCollection { get; private set; }

        /// <summary>
        /// Gets a dictionary for the predictions.
        /// </summary>
        public IDictionary<string, IList<string>> PredictionCollection { get; private set; }

        /// <summary>
        /// Constructs a new instance of <see cref="ModelFixture" />
        /// </summary>
        public ModelFixture()
        {
            var currentLocation = typeof(ModelFixture).Assembly.Location;
            var fileInfo = new FileInfo(currentLocation);
            var directory = fileInfo.DirectoryName;
            var dataDirectory = Path.Join(directory, ModelFixture.DataDirectoryName);
            var commandsModel = ModelFixture.ReadZipEntry(Path.Join(dataDirectory, ModelFixture.CommandsModelZip), ModelFixture.CommandsModelJson);
            var predictionsModel = ModelFixture.ReadZipEntry(Path.Join(dataDirectory, ModelFixture.PredictionsModelZip), ModelFixture.PredictionsModelJson);

            this.CommandCollection = JsonConvert.DeserializeObject<IList<string>>(commandsModel);
            this.PredictionCollection = JsonConvert.DeserializeObject<IDictionary<string, IList<string>>>(predictionsModel);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
        }

        private static string ReadZipEntry(string zipFilePath, string zipEntryName)
        {
            using ZipArchive zipArchive = ZipFile.Open(zipFilePath, ZipArchiveMode.Read);
            var entry = zipArchive.GetEntry(zipEntryName);

            using StreamReader streamReader = new StreamReader(entry.Open());
            return streamReader.ReadToEnd();
        }
    }

    /// <summary>
    /// This class has no code, and is never created. Its purpose is simply
    /// to be the place to apply [CollectionDefinition] and all the
    /// ICollectionFixture{T} interfaces.
    /// </summary>
    [CollectionDefinition("Model collection")]
    public class ModelCollection : ICollectionFixture<ModelFixture>
    {
    }
}
