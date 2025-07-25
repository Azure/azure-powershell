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
using System.IO;
using System.Text.Json;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Profile
{
    // See https://github.com/Azure/azure-powershell-common/blob/master/src/Authentication.Abstractions/AzurePSDataCollectionProfile.cs

    /// <summary>
    /// The profile about data collection in Azure PowerShell
    /// </summary>
    internal sealed class AzurePSDataCollectionProfile
    {
        private const string EnvironmentVariableName = "Azure_PS_Data_Collection";
        private const string DefaultFileName = "AzurePSDataCollectionProfile.json";

        private static AzurePSDataCollectionProfile _instance;

        /// <summary>
        /// Gets the singleton for <see cref="AzurePSDataCollectionProfile"/>
        /// </summary>
        public static AzurePSDataCollectionProfile Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = AzurePSDataCollectionProfile.CreateInstance();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Gets an instance of <see cref="AzurePSDataCollectionProfile"/>
        /// </summary>
        public AzurePSDataCollectionProfile() : this(false)
        { }

        private AzurePSDataCollectionProfile(bool enable)
        {
            EnableAzureDataCollection = enable;
        }

        /// <summary>
        /// Gets or sets if the data collection is enabled.
        /// </summary>
        public bool? EnableAzureDataCollection { get; set; }

        private static AzurePSDataCollectionProfile CreateInstance()
        {
            // Gets the profile about data collection as in Azure PowerShell.
            // See AzurePSDataCollectionProfile Initialize(IAzureSession session) in
            // https://github.com/Azure/azure-powershell-common/blob/master/src/Authentication.Abstractions/DataCollectionController.cs

            AzurePSDataCollectionProfile result = new AzurePSDataCollectionProfile(true);

            try
            {
                var environmentValue = Environment.GetEnvironmentVariable(AzurePSDataCollectionProfile.EnvironmentVariableName);

                if (!string.IsNullOrWhiteSpace(environmentValue) && bool.TryParse(environmentValue, out bool enabled))
                {
                    result.EnableAzureDataCollection = enabled;
                }
                else
                {
                    var profileDirectory = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                        AzPredictorConstants.AzureProfileDirectoryName);
                    string dataPath = Path.Combine(profileDirectory, AzurePSDataCollectionProfile.DefaultFileName);

                    if (File.Exists(dataPath))
                    {
                        string contents = File.ReadAllText(dataPath);
                        var localResult = JsonSerializer.Deserialize<AzurePSDataCollectionProfile>(contents, JsonUtilities.DefaultSerializerOptions);
                        if (localResult != null && localResult.EnableAzureDataCollection.HasValue)
                        {
                            result = localResult;
                        }
                    }
                }
            }
            catch
            {
                // do not throw for i/o or serialization errors
            }

            return result;
        }
    }
}
