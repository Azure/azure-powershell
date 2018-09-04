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
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class PowerShellUtilities
    {
        public const string PSModulePathName = "PSModulePath";

        private static void EditPSModulePath(Func<IEnumerable<string>, IEnumerable<string>> job, EnvironmentVariableTarget target)
        {
            ChangeForTargetEnvironment(job, target);
        }

        private static void ChangeForTargetEnvironment(Func<IEnumerable<string>, IEnumerable<string>> job, EnvironmentVariableTarget target)
        {
            string psModulePath = Environment.GetEnvironmentVariable(PSModulePathName, target) ?? string.Empty;
            IEnumerable<string> paths = psModulePath.Split(';');
            paths = job(paths);

            if (!paths.Any())
            {
                Environment.SetEnvironmentVariable(PSModulePathName, null, target);
            }
            else if (paths.Count() == 1)
            {
                Environment.SetEnvironmentVariable(PSModulePathName, paths.First(), target);
            }
            else
            {
                psModulePath = string.Join(";", paths.Distinct(StringComparer.CurrentCultureIgnoreCase));
                Environment.SetEnvironmentVariable(PSModulePathName, psModulePath, target);
            }
        }

        public static PSObject ConstructPSObject(string typeName, params object[] args)
        {
            Debug.Assert(args.Length % 2 == 0, "The parameter args length must be even number");

            PSObject outputObject = new PSObject();

            if (!string.IsNullOrEmpty(typeName))
            {
                outputObject.TypeNames.Add(typeName);
            }

            for (int i = 0, j = 0; i < args.Length / 2; i++, j += 2)
            {
                outputObject.Properties.Add(new PSNoteProperty(args[j].ToString(), args[j + 1]));
            }

            return outputObject;
        }

        public static void RemoveModuleFromPSModulePath(string modulePath)
        {
            EditPSModulePath(list => list.Where(p => !p.Equals(modulePath, StringComparison.OrdinalIgnoreCase)), EnvironmentVariableTarget.Process);
        }

        public static void RemoveModuleFromPSModulePath(string modulePath, EnvironmentVariableTarget target)
        {
            EditPSModulePath(list => list.Where(p => !p.Equals(modulePath, StringComparison.OrdinalIgnoreCase)), target);
        }

        public static void AddModuleToPSModulePath(string modulePath)
        {
            EditPSModulePath(list => new List<string>(list) { modulePath }, EnvironmentVariableTarget.Process);
        }

        public static void AddModuleToPSModulePath(string modulePath, EnvironmentVariableTarget target)
        {
            EditPSModulePath(list => new List<string>(list) { modulePath }, target);
        }

        public static IEnumerable<RuntimeDefinedParameter> GetUsedDynamicParameters(RuntimeDefinedParameterDictionary dynamicParameters, InvocationInfo MyInvocation)
        {
            return dynamicParameters.Values.Where(dp => MyInvocation.BoundParameters.Keys.Any(bp => bp.Equals(dp.Name)));
        }
    }
}
