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
using System.Runtime.CompilerServices;
using AzDev.Services.Assembly;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace AzDev.Services
{
    internal static class AzDevModule
    {
        private static IServiceProvider _serviceProvider;

        public static void Initialize()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IFileSystem, FileSystem>();
            services.AddSingleton<IContextProvider, DefaultContextProvider>(sp => new DefaultContextProvider(FileOrDirNames.DevContextFilePath, sp.GetRequiredService<IFileSystem>(), sp.GetRequiredService<ILogger>()));
            services.AddSingleton<ICodebaseProvider, DefaultCodebaseProvider>();
            services.AddSingleton<IAssemblyService, DefaultAssemblyService>();
            services.AddSingleton<INugetService, DefaultNugetService>();
            services.AddSingleton<ILogger, PSCmdletLogger>();
            services.AddSingleton<IAssemblyMetadataService, AssemblyMetadataService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() where T : class
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
