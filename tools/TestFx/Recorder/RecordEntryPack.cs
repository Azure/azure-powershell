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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.TestFx.Recorder
{
    public class RecordEntryPack
    {
        [JsonIgnore]
        public List<RequestResponseInfo> RRInfoRecordEntry { get; set; }

        public List<RecordEntry> Entries { get; set; }

        public Dictionary<string, Queue<string>> Names { get; set; }

        public Dictionary<string, string> Variables { get; set; }

        public RecordEntryPack()
        {
            Entries = new List<RecordEntry>();
            RRInfoRecordEntry = new List<RequestResponseInfo>();
        }

        public void Serialize(string path)
        {
            RecorderUtilities.SerializeJson(this, path);
        }

        public static RecordEntryPack Deserialize(string path)
        {
            return RecorderUtilities.DeserializeJson<RecordEntryPack>(path);
        }

        public RecordEntryPack Deserialize(string path, bool extractMetaData)
        {
            RecordEntryPack recordPack = Deserialize(path);

            if (recordPack != null && extractMetaData)
            {
                RRInfoRecordEntry.AddRange(recordPack.Entries.Select(re => new RequestResponseInfo(re)));
            }

            return recordPack;
        }
    }
}
