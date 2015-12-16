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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class CmdletExtensions
    {
        public static string TryResolvePath(this PSCmdlet psCmdlet, string path)
        {
            try
            {
                return psCmdlet.ResolvePath(path);
            }
            catch
            {
                return path;
            }
        }

        public static string ResolvePath(this PSCmdlet psCmdlet, string path)
        {
            if (path == null)
            {
                return null;
            }

            if (psCmdlet.SessionState == null)
            {
                return path;
            }

            path = path.Trim('"', '\'', ' ');
            var result = psCmdlet.SessionState.Path.GetResolvedPSPathFromPSPath(path);
            string fullPath = string.Empty;

            if (result != null && result.Count > 0)
            {
                fullPath = result[0].Path;
            }

            return fullPath;
        }

        #region PowerShell Commands

        public static void InvokeBeginProcessing(this PSCmdlet cmdlt)
        {
            MethodInfo dynMethod = (typeof(PSCmdlet)).GetMethod("BeginProcessing", BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod.Invoke(cmdlt, null);
        }

        public static void SetParameterSet(this PSCmdlet cmdlt, string value)
        {
            FieldInfo dynField = (typeof(Cmdlet)).GetField("_parameterSetName", BindingFlags.NonPublic | BindingFlags.Instance);
            dynField.SetValue(cmdlt, value);
        }

        public static void InvokeEndProcessing(this PSCmdlet cmdlt)
        {
            MethodInfo dynMethod = (typeof(PSCmdlet)).GetMethod("EndProcessing", BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod.Invoke(cmdlt, null);
        }

        #endregion
    }
}
