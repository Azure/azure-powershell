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
using System.IO.Abstractions;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using NuGet.Common;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace AzDev.Services.Assembly
{
    internal class DefaultNugetService : INugetService
    {

        private readonly SourceRepository _repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        private readonly Lazy<FindPackageByIdResource> _findPackageByIdResource;
        private readonly SourceCacheContext _cache = new();
        private readonly IFileSystem _fs;
        private readonly ILogger _logger;

        public DefaultNugetService(IFileSystem fs, ILogger logger)
        {
            _fs = fs;
            _logger = logger;
            _findPackageByIdResource = new Lazy<FindPackageByIdResource>(_repository.GetResource<FindPackageByIdResource>, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public string DownloadAssembly(string packageName, string packageVersion, string targetFramework, string destinationDir, bool downloadRuntimes)
        {
            _logger.Debug($"[{nameof(DefaultNugetService)}] Downloading {packageName} version {packageVersion} for {targetFramework} to {destinationDir}");
            using var packageStream = new MemoryStream();
            _findPackageByIdResource.Value.CopyNupkgToStreamAsync(
                packageName,
                new NuGetVersion(packageVersion),
                packageStream,
                _cache,
                NullLogger.Instance, // cannot use CmdletLogger because this runs in a different thread and it's not allowed by PS
                default).ConfigureAwait(false).GetAwaiter().GetResult();

            using var packageReader = new PackageArchiveReader(packageStream);
            string assemblyPathRelativeToPackage = $"lib/{targetFramework}/{packageName}.dll";
            if (!packageReader.GetFiles().Contains(assemblyPathRelativeToPackage))
            {
                throw new FileNotFoundException($"[{nameof(DefaultNugetService)}] Assembly {packageName}.dll not found in package {packageName} version {packageVersion} for {targetFramework}.");
            }

            var destAssemblyPath = _fs.Path.Combine(destinationDir, targetFramework, $"{packageName}.dll");
            _logger.Debug($"[{nameof(DefaultNugetService)}] Assembly {packageName}.dll found in package {packageName} version {packageVersion} for {targetFramework}. Start copying to {destAssemblyPath}.");
            ZipArchiveEntry entry = packageReader.GetEntry(assemblyPathRelativeToPackage);
            using var assemblyStream = entry.Open();
            using var destinationStream = _fs.File.Create(destAssemblyPath);
            assemblyStream.CopyTo(destinationStream);
            _logger.Debug($"[{nameof(DefaultNugetService)}] Assembly {packageName}.dll copied to {destAssemblyPath}.");

            if (downloadRuntimes)
            {
                var runtimes = packageReader.GetFiles().Where(f => f.StartsWith("runtimes/") && f.EndsWith(".dll"));
                foreach (var runtime in runtimes)
                {
                    var runtimeFilename = Path.GetFileName(runtime);
                    var destRuntimePath = Path.Combine(destinationDir, targetFramework, runtimeFilename);
                    _logger.Debug($"[{nameof(DefaultNugetService)}] Copying runtime {runtimeFilename} to {destRuntimePath}.");
                    using var runtimeStream = packageReader.GetEntry(runtime).Open();
                    using var destRuntimeStream = _fs.File.OpenWrite(destRuntimePath);
                    runtimeStream.CopyTo(destRuntimeStream);
                    _logger.Debug($"[{nameof(DefaultNugetService)}] Runtime {runtimeFilename} copied to {destRuntimePath}.");
                }
            }

            return destAssemblyPath;
        }
    }
}
