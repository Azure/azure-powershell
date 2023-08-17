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

using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.TestFx.Recorder
{
    public class RecordedFiles
    {
        public string OriginalFilePath { get; private set; }

        public string BackupFilePath { get; set; }

        public RecordEntryPack OriginalPack { get; }

        public RecordEntryPack ProcessedPack { get; internal set; }

        public RecordedFiles()
        {

        }

        public RecordedFiles(string recordedFilePath) : this()
        {
            if (File.Exists(recordedFilePath))
            {
                OriginalPack = RecordEntryPack.Deserialize(recordedFilePath);
                OriginalFilePath = recordedFilePath;
                BackupFilePath = string.Concat(Path.Combine(Path.GetDirectoryName(recordedFilePath), Path.GetFileNameWithoutExtension(recordedFilePath)), ".pijson");
            }
        }

        public void CompactLroPolling()
        {
            CompactLroEntries compactLro = new CompactLroEntries();
            compactLro.Process(OriginalPack);
            ProcessedPack = compactLro.ProcessedEntryPack;
            ProcessedPack.Variables = OriginalPack.Variables;
            ProcessedPack.Names = OriginalPack.Names;
        }

        public void SerializeCompactData(string filePath = "")
        {
            if (string.IsNullOrEmpty(filePath))
            {
                ProcessedPack.Serialize(OriginalFilePath);
            }
            else
            {
                ProcessedPack.Serialize(filePath);
            }

            OriginalPack.Serialize(BackupFilePath);
        }
    }
}
