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
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;

namespace AzDev.Models.Inventory
{
    internal class AutoRestYamlConfig
    {
        [YamlMember(Alias = "title")]
        public string Title { get => _title; set => _title = value?.Trim(); }
        private string _title;

        [YamlMember(Alias = "input-file")]
        public IEnumerable<string> InputFile { get => _inputFile; set => _inputFile = value?.Select(x => x.Trim())?.Where(x => !string.IsNullOrWhiteSpace(x)) ?? Enumerable.Empty<string>(); }
        private IEnumerable<string> _inputFile = Enumerable.Empty<string>();

        [YamlMember(Alias = "commit")]
        public string Commit { get => _commit; set => _commit = value?.Trim(); }
        private string _commit;

        [YamlMember(Alias = "require")]
        public IEnumerable<string> Require { get => _require; set => _require = value?.Select(x => x.Trim())?.Where(x => !string.IsNullOrWhiteSpace(x)) ?? Enumerable.Empty<string>(); }
        private IEnumerable<string> _require = Enumerable.Empty<string>();

        [YamlMember(Alias = "try-require")]
        public IEnumerable<string> TryRequire { get => _tryRequire; set => _tryRequire = value?.Select(x => x.Trim())?.Where(x => !string.IsNullOrWhiteSpace(x)) ?? Enumerable.Empty<string>(); }
        private IEnumerable<string> _tryRequire = Enumerable.Empty<string>();

        [YamlMember(Alias = "directive")]
        public object Directive { get; internal set; } = Array.Empty<object>();

        // Recognize use-extension block for AutoRest.PowerShell version detection
        // Example:
        // use-extension:
        //   "@autorest/powershell": "3.x"
        [YamlMember(Alias = "use-extension")]
        public IDictionary<string, string> UseExtension { get; internal set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
}
