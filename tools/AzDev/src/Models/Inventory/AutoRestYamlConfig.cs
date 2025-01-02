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
        public IEnumerable<object> Directive { get; internal set; } = Enumerable.Empty<object>();
    }
}
