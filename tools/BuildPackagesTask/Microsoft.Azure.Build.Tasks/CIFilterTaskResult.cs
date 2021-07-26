//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
using Microsoft.Build.Framework;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    public class CIFilterTaskResult : ITaskItem
    {
        readonly string _spec = "CIFilterTaskResult";
        public Dictionary<string, HashSet<string>> PhaseInfo = new Dictionary<string, HashSet<string>>();

        public string ItemSpec
        {
            get { return _spec; }
            set { }
        }

        public ICollection MetadataNames
        {
            get
            {
                return PhaseInfo.Keys;
            }
        }
        public int MetadataCount
        {
            get { return PhaseInfo.Keys.Count; }
        }

        public IDictionary CloneCustomMetadata()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (string key in PhaseInfo.Keys)
            {
                result[key] = string.Join(";", PhaseInfo[key].ToList());
            }

            return result;
        }

        public void CopyMetadataTo(ITaskItem destinationItem)
        {
        }

        public string GetMetadata(string metadataName)
        {
            return string.Format("[{0}]", string.Join(", ", PhaseInfo[metadataName].ToList()));
        }

        public void RemoveMetadata(string metadataName)
        {
        }

        public void SetMetadata(string metadataName, string metadataValue)
        {
        }
    }
}
