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
using System.IO.Abstractions;
using AzDev.Models.Inventory;

namespace AzDev.Services
{
    internal class DefaultCodebaseProvider : ICodebaseProvider
    {
        private ILogger _logger;
        private readonly IContextProvider _contextProvider;
        private readonly IFileSystem _fs;
        private Codebase _codebase;

        public DefaultCodebaseProvider(IContextProvider contextProvider)
            : this(contextProvider, new FileSystem()) { }

        public DefaultCodebaseProvider(IContextProvider contextProvider, IFileSystem fs)
        {
            _contextProvider = contextProvider ?? throw new ArgumentNullException(nameof(contextProvider));
            _fs = fs;
        }

        public void SetLogger(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Codebase GetCodebase()
        {
            _logger.Verbose("Loading codebase information");

            if (_codebase == null)
            {
                var path = _contextProvider.LoadContext().AzurePowerShellRepositoryRoot;
                _logger.Verbose($"Codebase path: {path}");
                var src = _fs.Path.Combine(path, FileOrDirNames.Src);
                _codebase = _codebase ?? Codebase.FromFileSystem(_fs, src);
            }

            _logger.Verbose("Codebase loaded successfully");

            return _codebase;
        }
    }
}
