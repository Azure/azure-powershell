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
        private readonly ILogger _logger;
        private readonly IContextProvider _contextProvider;
        private readonly IFileSystem _fs;
        private Codebase _codebase;

        public DefaultCodebaseProvider(IContextProvider contextProvider, IFileSystem fs, ILogger logger)
        {
            _contextProvider = contextProvider;
            _fs = fs;
            _logger = logger;
        }

        public Codebase GetCodebase()
        {
            _logger.Debug("[DefaultCodebaseProvider] Loading codebase information");

            if (_codebase == null)
            {
                var path = _contextProvider.LoadContext().AzurePowerShellRepositoryRoot;
                _logger.Debug($"[DefaultCodebaseProvider] Codebase path: {path}");
                var src = _fs.Path.Combine(path, FileOrDirNames.Src);
                _codebase = Codebase.FromFileSystem(_fs, _logger, src);
            }

            _logger.Debug("[DefaultCodebaseProvider] Codebase loaded successfully");

            return _codebase;
        }
    }
}
