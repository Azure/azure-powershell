/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime
{
    internal static class AttachDebugger
    {
        internal static void Break()
        {
            while (!System.Diagnostics.Debugger.IsAttached)
            {
                System.Console.Error.WriteLine($"Waiting for debugger to attach to process {System.Diagnostics.Process.GetCurrentProcess().Id}");
                for (int i = 0; i < 50; i++)
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(100);
                    System.Console.Error.Write(".");
                }
                System.Console.Error.WriteLine();
            }
            System.Diagnostics.Debugger.Break();
        }
    }
}
