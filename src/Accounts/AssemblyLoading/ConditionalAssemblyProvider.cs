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
using System.IO;
using System.Linq;

namespace Microsoft.Azure.PowerShell.AssemblyLoading
{
    /// <summary>
    /// Provides a set of assemblies to load for different environments.
    /// </summary>
    public static class ConditionalAssemblyProvider
    {
        private static IConditionalAssemblyContext _context = null;
        private static IEnumerable<IConditionalAssembly> _assemblies = null;
        private static string _rootPath = null;

        /// <summary>
        /// Initializes the conditional assembly provider.
        /// </summary>
        /// <param name="rootPath">Root path of the assemblies.</param>
        /// <param name="context">Context according to which an assembly is loaded or not.</param>
        public static void Initialize(string rootPath, IConditionalAssemblyContext context)
        {
            _rootPath = rootPath ?? throw new ArgumentNullException(nameof(rootPath));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _assemblies = new List<IConditionalAssembly>()
            {
                // todo: consider moving the list to a standalone config file
                // do not update this list manually, see src/lib/README.md for details
                #region Generated
                CreateAssembly("net45", "Newtonsoft.Json", "13.0.0.0").WithWindowsPowerShell(),
                CreateAssembly("net46", "System.Xml.ReaderWriter", "4.1.0.0").WithWindowsPowerShell(),
                CreateAssembly("net461", "System.Reflection.DispatchProxy", "4.0.4.0").WithWindowsPowerShell(),
                CreateAssembly("net461", "System.Security.Cryptography.ProtectedData", "4.0.3.0").WithWindowsPowerShell(),
                CreateAssembly("net462", "System.Diagnostics.DiagnosticSource", "10.0.0.3").WithWindowsPowerShell(),
                CreateAssembly("net462", "System.Numerics.Vectors", "4.1.6.0").WithWindowsPowerShell(),
                CreateAssembly("net462", "System.Runtime.CompilerServices.Unsafe", "6.0.3.0").WithWindowsPowerShell(),
                CreateAssembly("net462", "System.Text.Encodings.Web", "10.0.0.3").WithWindowsPowerShell(),
                CreateAssembly("net47", "System.Security.Cryptography.Cng", "5.0.0.0").WithWindowsPowerShell(),
                CreateAssembly("net47", "System.ValueTuple", "4.0.3.0").WithWindowsPowerShell(),
                CreateAssembly("netstandard2.0", "Azure.Core", "1.56.0.0"),
                CreateAssembly("netstandard2.0", "Azure.Identity.Broker", "1.6.0.0"),
                CreateAssembly("netstandard2.0", "Azure.Identity", "1.21.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Bcl.AsyncInterfaces", "10.0.0.3"),
                CreateAssembly("netstandard2.0", "Microsoft.Extensions.Configuration.Abstractions", "10.0.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Extensions.DependencyInjection.Abstractions", "10.0.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Extensions.Diagnostics.Abstractions", "10.0.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Extensions.FileProviders.Abstractions", "10.0.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Extensions.Hosting.Abstractions", "10.0.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Extensions.Logging.Abstractions", "10.0.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Extensions.Options", "10.0.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Extensions.Primitives", "10.0.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Identity.Client.Broker", "4.84.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Identity.Client", "4.84.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Identity.Client.Extensions.Msal", "4.84.0.0"),
                CreateAssembly("netstandard2.0", "Microsoft.Identity.Client.NativeInterop", "0.20.4.0"),
                CreateAssembly("netstandard2.0", "Microsoft.IdentityModel.Abstractions", "8.14.0.0"),
                CreateAssembly("netstandard2.0", "System.Buffers", "4.0.2.0").WithWindowsPowerShell(),
                CreateAssembly("netstandard2.0", "System.ClientModel", "1.12.0.0"),
                CreateAssembly("netstandard2.0", "System.Formats.Asn1", "8.0.0.0").WithWindowsPowerShell(),
                CreateAssembly("netstandard2.0", "System.IO.Pipelines", "10.0.0.0").WithWindowsPowerShell(),
                CreateAssembly("netstandard2.0", "System.Memory.Data", "10.0.0.3"),
                CreateAssembly("netstandard2.0", "System.Memory", "4.0.2.0").WithWindowsPowerShell(),
                CreateAssembly("netstandard2.0", "System.Net.Http.WinHttpHandler", "4.0.4.0").WithWindowsPowerShell(),
                CreateAssembly("netstandard2.0", "System.Private.ServiceModel", "4.7.0.0").WithWindowsPowerShell(),
                CreateAssembly("netstandard2.0", "System.Security.AccessControl", "4.1.3.0").WithWindowsPowerShell(),
                CreateAssembly("netstandard2.0", "System.Security.Permissions", "4.0.3.0").WithWindowsPowerShell(),
                CreateAssembly("netstandard2.0", "System.Security.Principal.Windows", "4.1.3.0").WithWindowsPowerShell(),
                CreateAssembly("netstandard2.0", "System.ServiceModel.Primitives", "4.7.0.0").WithWindowsPowerShell(),
                CreateAssembly("netstandard2.0", "System.Text.Json", "10.0.0.0"),
                CreateAssembly("netstandard2.0", "System.Threading.Tasks.Extensions", "4.2.1.0").WithWindowsPowerShell(),
                #endregion
            };
        }

        /// <summary>
        /// Shorthand syntax to define a conditional assembly.
        /// </summary>
        private static ConditionalAssembly CreateAssembly(string framework, string name, string version)
        {
            string path = Path.Combine(_rootPath, framework, $"{name}.dll");
            return new ConditionalAssembly(_context, name, path, new Version(version));
        }

        /// <summary>
        /// Returns a set of assemblies that should be loaded into the current environment.
        /// </summary>
        public static IDictionary<string, (string Path, Version Version)> GetAssemblies()
        {
            if (_context == null || _assemblies == null) throw new InvalidOperationException($"Call {nameof(Initialize)}() first.");
            return _assemblies.Where(x => x.ShouldLoad).ToDictionary(x => x.Name, x => (x.Path, x.Version));
        }
    }
}
