// ----------------------------------------------------------------------------------
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

namespace RepoTasks.Cmdlets
{
    using RemoteWorker;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, "FormatPs1Xml", SupportsShouldProcess = true)]
    public class NewFormatPs1XmlCommand : PSCmdlet
    {
        [Parameter(Position = 1, ValueFromPipeline = true, Mandatory = true)]
        public string ModulePath { get; set; }

        [Parameter(Position = 2, ValueFromPipeline = true, Mandatory = false)]
        public string[] Cmdlet { get; set; }

        [Parameter(Position = 3, ValueFromPipeline = false, Mandatory = false)]
        public string OutputPath { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        [Parameter]
        public SwitchParameter OnlyMarkedProperties { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                ModulePath = GetUnresolvedProviderPathFromPSPath(ModulePath);

                if (!File.Exists(ModulePath))
                {
                    throw new ArgumentException(@"ModulePath doesn't exist", ModulePath);
                }

                if (string.IsNullOrEmpty(OutputPath))
                {
                    OutputPath = SessionState.Path.CurrentFileSystemLocation.Path;
                }
                else
                {
                    OutputPath = GetUnresolvedProviderPathFromPSPath(OutputPath);

                    if (!Directory.Exists(OutputPath))
                    {
                        throw new ArgumentException(@"OutputPath doesn't exist", OutputPath);
                    }
                }

                foreach (var assemblyPath in GetAssemblyPath(ModulePath))
                {
                    ReflectInIsolateAppDomain<AppDomainWorker>(assemblyPath);
                }
            }
            catch (Exception e)
            {
                WriteError(new ErrorRecord(e, null, ErrorCategory.InvalidOperation, null));
            }
        }

        internal static IEnumerable<string> GetAssemblyPath(string manifestPath)
        {
            // parse module (psd1 file) - get assemblies list
            var list = new List<string>();
            using (var ps = PowerShell.Create())
            {
                ps.AddCommand("Test-ModuleManifest").AddParameter("Path", manifestPath);
                var result = ps.Invoke();
                var moduleInfo = (PSModuleInfo)result[0].BaseObject;
                if (moduleInfo == null) return list;
                list.AddRange(moduleInfo.NestedModules.Select(nestedModule => Path.Combine(nestedModule.ModuleBase, nestedModule.Name + ".dll")));
            }

            return list;
        }

        internal void ReflectInIsolateAppDomain<T>(string assemblyPath) where T : MarshalByRefObject, IReflectionWorker
        {
            AppDomain domain = null;
            try
            {
                var setup = new AppDomainSetup
                {
                    ApplicationBase = Path.GetDirectoryName(assemblyPath),
                };

                domain = AppDomain.CreateDomain("AppDomainIsolation: " + Guid.NewGuid(), null, setup);
                var type = typeof(T);
                if (type.FullName == null) throw new Exception("type fullname is null");
                var worker = (T)domain.CreateInstanceFromAndUnwrap(type.Assembly.Location, type.FullName);
                var outFilename = worker.BuildFormatPs1Xml(assemblyPath, Cmdlet, OnlyMarkedProperties);
                if (string.IsNullOrEmpty(outFilename))
                {
                    WriteWarning(@"No output types found.");
                    return;
                }

                var outFilepath = Path.Combine(OutputPath, outFilename);
                if (!File.Exists(outFilepath)
                    || Force
                    || ShouldProcess($"File path: {outFilepath}", "Override existing file"))
                {
                    worker.Serialize(outFilepath);
                    WriteObject(outFilepath);
                }
            }
            finally
            {
                if (domain != null) AppDomain.Unload(domain);
            }
        }
    }
}
