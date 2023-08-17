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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using Xunit;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// The class to prepare model for all the tests.
    /// </summary>
    public sealed class ModelFixture : IDisposable
    {
        private const string CommandsModelJson = "CommandsModel.json";
        private const string PredictionsModelJson = "PredictionsModel.json";
        private const string DataDirectoryName = "Data";
        private static readonly Version CommandsVersionToUse = new Version("0.0.0");
        private static readonly Version PredictionsVersionToUse = new Version("0.0.0");

        /// <summary>
        /// Gets a list of string for the commands.
        /// </summary>
        public IList<PredictiveCommand> CommandCollection { get; private set; }

        /// <summary>
        /// Gets a dictionary for the predictions.
        /// </summary>
        public IDictionary<string, IList<PredictiveCommand>> PredictionCollection { get; private set; }

        /// <summary>
        /// Constructs a new instance of <see cref="ModelFixture" />
        /// </summary>
        public ModelFixture()
        {
            var currentLocation = typeof(ModelFixture).Assembly.Location;
            var fileInfo = new FileInfo(currentLocation);
            var directory = fileInfo.DirectoryName;
            var dataDirectory = Path.Join(directory, ModelFixture.DataDirectoryName);
            var commandsModelVersions = JsonSerializer.Deserialize<IDictionary<Version, IList<ModelEntry>>>(File.ReadAllText(Path.Join(dataDirectory, ModelFixture.CommandsModelJson), Encoding.UTF8), JsonUtilities.DefaultSerializerOptions);
            var predictionsModelVersions = JsonSerializer.Deserialize<IDictionary<Version, Dictionary<string, IList<ModelEntry>>>>(File.ReadAllText(Path.Join(dataDirectory, ModelFixture.PredictionsModelJson), Encoding.UTF8), JsonUtilities.DefaultSerializerOptions);

            var commandsModel = commandsModelVersions[CommandsVersionToUse];
            var predictionsModel = predictionsModelVersions[PredictionsVersionToUse];

            this.CommandCollection = commandsModel.Select(x => x.TransformEntry()).ToList();
            var predictiveCollection = new Dictionary<string, IList<PredictiveCommand>>();
            foreach (var command in predictionsModel)
            {
                var predictiveCommandEntries = new List<PredictiveCommand>();
                foreach (var modelEntry in command.Value)
                {
                    predictiveCommandEntries.Add(modelEntry.TransformEntry());
                }
                predictiveCollection.Add(command.Key, predictiveCommandEntries);
            }
            this.PredictionCollection = predictiveCollection;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
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
