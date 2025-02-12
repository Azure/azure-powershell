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

using System.IO.Abstractions;
using AzDev.Models.Inventory;

namespace AzDev.Services
{
    internal class DefaultCodebaseProvider : ICodebaseProvider
    {
        private IContextProvider _contextProvider;
        private IFileSystem _fs;
        private Codebase _codebase;

        public DefaultCodebaseProvider(IContextProvider contextProvider)
            : this(contextProvider, new FileSystem()) { }

        public DefaultCodebaseProvider(IContextProvider contextProvider, IFileSystem fs)
        {
            _contextProvider = contextProvider;
            _fs = fs;
        }

        public Codebase GetCodebase()
        {
            if (_codebase == null)
            {
                var path = _contextProvider.LoadContext().AzurePowerShellRepositoryRoot;
                var src = _fs.Path.Combine(path, FileOrDirNames.Src);
                _codebase = _codebase ?? Codebase.FromFileSystem(_fs, src);
            }
            return _codebase;
        }
    }
}
