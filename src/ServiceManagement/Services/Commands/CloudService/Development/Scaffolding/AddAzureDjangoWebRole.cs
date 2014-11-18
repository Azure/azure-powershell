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

using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using Microsoft.Win32;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding
{
    /// <summary>
    /// Create scaffolding for a new Python Django web role, change cscfg file and csdef to include the added web role
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureDjangoWebRole"), OutputType(typeof(RoleSettings))]
    public class AddAzureDjangoWebRoleCommand : AddRole
    {
        const string PythonCorePath = "SOFTWARE\\Python\\PythonCore";
        const string SupportedPythonVersion = "2.7";
        const string InstallPathSubKey = "InstallPath";
        const string PythonInterpreterExe = "python.exe";
        const string DjangoStartProjectCommand = "-m django.bin.django-admin startproject {0}";

        public AddAzureDjangoWebRoleCommand() :
            base(Path.Combine(Resources.PythonScaffolding, RoleType.WebRole.ToString()), Resources.AddRoleMessageCreatePython, true)
        {

        }

        protected override void OnProcessing(RoleInfo roleInfo)
        {
            var interpPath = FindPythonInterpreterPath();
            if (interpPath != null)
            {
                string stdOut, stdErr;

                string originalDir = Directory.GetCurrentDirectory();
                Directory.SetCurrentDirectory(Path.Combine(RootPath, roleInfo.Name));

                try
                {
                    ProcessHelper.StartAndWaitForProcess(
                    new ProcessStartInfo(
                        Path.Combine(interpPath, PythonInterpreterExe),
                        string.Format(DjangoStartProjectCommand, roleInfo.Name)
                    ),
                    out stdOut,
                    out stdErr);
                }
                finally
                {
                    Directory.SetCurrentDirectory(originalDir);
                }

                if (!string.IsNullOrEmpty(stdErr))
                {
                    WriteWarning(string.Format(Resources.UnableToCreateDjangoApp, stdErr));
                    WriteWarning(Resources.UnableToCreateDjangoAppFix);
                }
            }
            else
            {
                WriteWarning(Resources.MissingPythonPreReq);
            }
        }

        internal static string FindPythonInterpreterPath()
        {
            foreach (var baseKey in new[] { RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                RegistryView.Registry32), Registry.CurrentUser })
            {
                using (var python = baseKey.OpenSubKey(PythonCorePath))
                {
                    if (python != null)
                    {
                        foreach (var key in python.GetSubKeyNames())
                        {
                            if (key == SupportedPythonVersion)
                            {
                                var value = python.OpenSubKey(key + "\\" + InstallPathSubKey);
                                if (value != null)
                                {
                                    return value.GetValue("") as string;
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}