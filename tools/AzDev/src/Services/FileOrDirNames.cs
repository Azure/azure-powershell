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

namespace AzDev.Services
{
    internal static class FileOrDirNames
    {
        public const string Generated = "generated";
        public const string Src = "src";
        public const string Lib = "lib";
        public const string ComponentGovernanceManifest = "cgmanifest.json";
        public const string Accounts = "Accounts";
        public const string AssemblyLoading = "AssemblyLoading";
        public const string ConditionalAssemblyProvider = "ConditionalAssemblyProvider.cs";
        public const string DevContextFileName = "DevContext.json";
        public static string DevContextFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AzPSDev", DevContextFileName);
        public const string AssemblyManifestFileName = "manifest.json";
    }
}
