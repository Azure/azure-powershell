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
using System.ComponentModel;
using System.Reflection;

namespace NetCorePsd1Sync.Model
{
    public class PsDefinition
    {
        public PsDefinitionHeader ManifestHeader { get; set; } = new PsDefinitionHeader();

        [DisplayName("RootModule")]
        [Description("Script module or binary module file associated with this manifest.")]
        public string RootModule { get; set; }

        [DisplayName("ModuleVersion")]
        [Description("Version number of this module.")]
        public Version ModuleVersion { get; set; } = new Version(1, 0);

        [DisplayName("CompatiblePSEditions")]
        [Description("Supported PSEditions")]
        public List<string> CompatiblePsEditions { get; set; }

        [DisplayName("GUID")]
        [Description("ID used to uniquely identify this module")]
        public Guid Guid { get; set; } = Guid.NewGuid();

        [DisplayName("Author")]
        [Description("Author of this module")]
        public string Author { get; set; } = Environment.UserName;

        [DisplayName("CompanyName")]
        [Description("Company or vendor of this module")]
        public string CompanyName { get; set; } = "Unknown";

        [DisplayName("Copyright")]
        [Description("Copyright statement for this module")]
        public string Copyright { get; set; } = $"(c) {DateTime.Now.Year} {Environment.UserName}. All rights reserved.";

        [DisplayName("Description")]
        [Description("Description of the functionality provided by this module")]
        public string Description { get; set; }

        [DisplayName("PowerShellVersion")]
        [Description("Minimum version of the Windows PowerShell engine required by this module")]
        public Version PowerShellVersion { get; set; }

        [DisplayName("PowerShellHostName")]
        [Description("Name of the Windows PowerShell host required by this module")]
        public string PowerShellHostName { get; set; }

        [DisplayName("PowerShellHostVersion")]
        [Description("Minimum version of the Windows PowerShell host required by this module")]
        public Version PowerShellHostVersion { get; set; }

        [DisplayName("DotNetFrameworkVersion")]
        [Description("Minimum version of Microsoft .NET Framework required by this module. This prerequisite is valid for the PowerShell Desktop edition only.")]
        public Version DotNetFrameworkVersion { get; set; }

        [DisplayName("CLRVersion")]
        [Description("Minimum version of the common language runtime (CLR) required by this module. This prerequisite is valid for the PowerShell Desktop edition only.")]
        public Version ClrVersion { get; set; }

        [DisplayName("ProcessorArchitecture")]
        [Description("Processor architecture (None, X86, Amd64) required by this module")]
        public ProcessorArchitecture? ProcessorArchitecture { get; set; }

        [DisplayName("RequiredModules")]
        [Description("Modules that must be imported into the global environment prior to importing this module")]
        public List<ModuleReference> RequiredModules { get; set; }

        [DisplayName("RequiredAssemblies")]
        [Description("Assemblies that must be loaded prior to importing this module")]
        public List<string> RequiredAssemblies { get; set; }

        [DisplayName("ScriptsToProcess")]
        [Description("Script files (.ps1) that are run in the caller's environment prior to importing this module.")]
        public List<string> ScriptsToProcess { get; set; }

        [DisplayName("TypesToProcess")]
        [Description("Type files (.ps1xml) to be loaded when importing this module")]
        public List<string> TypesToProcess { get; set; }

        [DisplayName("FormatsToProcess")]
        [Description("Format files (.ps1xml) to be loaded when importing this module")]
        public List<string> FormatsToProcess { get; set; }

        [DisplayName("NestedModules")]
        [Description("Modules to import as nested modules of the module specified in RootModule/ModuleToProcess")]
        public List<ModuleReference> NestedModules { get; set; }

        [DisplayName("FunctionsToExport")]
        [Description("Functions to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no functions to export.")]
        public List<string> FunctionsToExport { get; set; } = new List<string>();

        [DisplayName("CmdletsToExport")]
        [Description("Cmdlets to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no cmdlets to export.")]
        public List<string> CmdletsToExport { get; set; } = new List<string>();

        [DisplayName("VariablesToExport")]
        [Description("Variables to export from this module")]
        public List<string> VariablesToExport { get; set; } = new List<string> { "*" };

        [DisplayName("AliasesToExport")]
        [Description("Aliases to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no aliases to export.")]
        public List<string> AliasesToExport { get; set; } = new List<string>();

        [DisplayName("DscResourcesToExport")]
        [Description("DSC resources to export from this module")]
        public List<string> DscResourcesToExport { get; set; }

        [DisplayName("ModuleList")]
        [Description("List of all modules packaged with this module")]
        public List<ModuleReference> ModuleList { get; set; }

        [DisplayName("FileList")]
        [Description("List of all files packaged with this module")]
        public List<string> FileList { get; set; }

        [DisplayName("PrivateData")]
        [Description("Private data to pass to the module specified in RootModule/ModuleToProcess. This may also contain a PSData hashtable with additional module metadata used by PowerShell.")]
        public PrivateData PrivateData { get; set; } = new PrivateData();

        [DisplayName("HelpInfoURI")]
        [Description("HelpInfo URI of this module")]
        public string HelpInfoUri { get; set; }

        [DisplayName("DefaultCommandPrefix")]
        [Description("Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.")]
        public string DefaultCommandPrefix { get; set; }
    }
}
