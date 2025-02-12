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
using System.Text.Json;
using AzDev.Models;

namespace AzDev.Services
{
    internal class DefaultContextProvider : IContextProvider
    {
        private readonly string _contextFilePath;
        private IFileSystem _fileSystem;
        private DevContext _cachedContext;

        public DefaultContextProvider(string contextFilePath) : this(contextFilePath, new FileSystem())
        {
        }

        public DefaultContextProvider(string contextFilePath, IFileSystem fileSystem)
        {
            _contextFilePath = contextFilePath;
            _fileSystem = fileSystem;
            _cachedContext = null;
        }

        public string ContextPath => _contextFilePath;

        public DevContext LoadContext()
        {
            if (_cachedContext != null)
            {
                return _cachedContext;
            }

            if (!_fileSystem.File.Exists(_contextFilePath))
            {
                // Handle the case when the context file doesn't exist
                throw new System.IO.FileNotFoundException("Context file not found.");
            }

            string json = _fileSystem.File.ReadAllText(_contextFilePath);
            _cachedContext = JsonSerializer.Deserialize<DevContext>(json);
            return _cachedContext;
        }

        public void SaveContext(DevContext context)
        {
            string json = JsonSerializer.Serialize(context);
            string directoryPath = _fileSystem.Path.GetDirectoryName(_contextFilePath);
            if (!string.IsNullOrEmpty(directoryPath))
            {
                _fileSystem.Directory.CreateDirectory(directoryPath);
            }
            _fileSystem.File.WriteAllText(_contextFilePath, json);
            _cachedContext = context;
        }
    }
}
