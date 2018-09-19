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

using System;
using System.IO;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators
{
    internal class AzureHDInsightStorageHandlerSimulator : IAzureHDInsightStorageHandler
    {
        internal Uri Path { get; private set; }
        internal Stream UploadedStream { get; private set; }

        public Uri GetStoragePath(Uri httpPath)
        {
            return AzureHDInsightStorageHandler.GetWasbStoragePath(httpPath);
        }

        public void UploadFile(Uri path, Stream contents)
        {
            this.Path = path;
            this.UploadedStream = new MemoryStream();
            contents.CopyTo(this.UploadedStream);
        }
    }
}
