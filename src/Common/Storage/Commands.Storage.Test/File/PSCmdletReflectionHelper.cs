﻿// ----------------------------------------------------------------------------------
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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Internal;
using System.Management.Automation.Runspaces;
using System.Reflection;

namespace Microsoft.WindowsAzure.Management.Storage.Test.File
{
    internal static class PSCmdletReflectionHelper
    {
        private static readonly Type psCmdletType = typeof(PSCmdlet);

        private static readonly Type azurePsCmdletType = typeof(AzurePSCmdlet);

        private static readonly FieldInfo parameterSetFieldInfo = typeof(System.Management.Automation.Cmdlet).GetField("_parameterSetName", BindingFlags.Instance | BindingFlags.NonPublic);

        private static readonly FieldInfo sessionStateFieldInfo = typeof(InternalCommand).GetField("state", BindingFlags.Instance | BindingFlags.NonPublic);

        private static readonly FieldInfo engineFieldInfo = psCmdletType.Assembly.GetType("System.Management.Automation.Runspaces.LocalRunspace").GetField("_engine", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly FieldInfo executionContextFieldInfo = psCmdletType.Assembly.GetType("System.Management.Automation.AutomationEngine").GetField("_context", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly PropertyInfo contextPropertyInfo = typeof(InternalCommand).GetProperty("Context", BindingFlags.Instance | BindingFlags.NonPublic);

        private static readonly MethodInfo beginProcessingMethodInfo = psCmdletType.GetMethod("BeginProcessing", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly MethodInfo endProcessingMethodInfo = psCmdletType.GetMethod("EndProcessing", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly MethodInfo processRecordMethodInfo = azurePsCmdletType.GetMethod("ExecuteCmdlet", BindingFlags.Public | BindingFlags.Instance);

        private static readonly object[] emptyParameters = new object[0];

        public static IDisposable InitializeSessionState(this PSCmdlet cmdlet)
        {
            var ps = System.Management.Automation.PowerShell.Create(InitialSessionState.CreateDefault());
            try
            {
                var engine = engineFieldInfo.GetValue(ps.Runspace);
                var context = executionContextFieldInfo.GetValue(engine);
                contextPropertyInfo.SetValue(cmdlet, context, emptyParameters);
                return ps;
            }
            catch
            {
                if (ps != null)
                {
                    ps.Dispose();
                }

                throw;
            }
        }

        public static void RunCmdlet(this PSCmdlet cmdlet, string parameterSet, params KeyValuePair<string, object>[] parameters)
        {
            RunCmdlet(cmdlet, parameterSet,
                parameters.Select(x => new KeyValuePair<string, object[]>(
                    x.Key, new object[] { x.Value })).ToArray()
            );
        }

        public static void RunCmdlet(this PSCmdlet cmdlet, string parameterSet, KeyValuePair<string, object[]>[] incomingValues)
        {
            var cmdletType = cmdlet.GetType();
            parameterSetFieldInfo.SetValue(cmdlet, parameterSet);
            beginProcessingMethodInfo.Invoke(cmdlet, emptyParameters);
            var parameterProperties = incomingValues.Select(x =>
                new Tuple<PropertyInfo, object[]>(
                    cmdletType.GetProperty(x.Key),
                    x.Value)).ToArray();

            for (int i = 0; i < incomingValues[0].Value.Length; i++)
            {
                foreach (var parameter in parameterProperties)
                {
                    parameter.Item1.SetValue(cmdlet, parameter.Item2[i], null);
                }

                processRecordMethodInfo.Invoke(cmdlet, emptyParameters);
            }

            endProcessingMethodInfo.Invoke(cmdlet, emptyParameters);
        }
    }
}
