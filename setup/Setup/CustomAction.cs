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

namespace Microsoft.WindowsAzure.Setup
{
    using System;
    using System.IO;
    using Deployment.WindowsInstaller;
    using System.Threading;

    public class CustomAction
    {
        // The exception object which will store (if) exception which is occurred in our sta thread
        private static Exception _STAThreadException; 

        private static uint[] powerShellDefaultColorTable = new uint[] 
            { 
                0x0, 0x800000, 0x8000, 0x808000, 0x80, 0x562401, 0xF0EDEE, 0xC0C0C0,
                0x808080, 0xFF0000, 0xFF00, 0xFFFF00, 0xFF, 0xFF00FF, 0xFFFF, 0xFFFFFF 
            };

        // Method which contains our custom action behavior
        private static void RunSTAThread(object sessionObject)
        {
            try
            {
                Session session = sessionObject as Session;

                string powerShellShortcutPath = session.CustomActionData["ShortcutPath"];
                string powerShellDefaultShortcutPath = session.CustomActionData["DefaultShortcutPath"];

                if (!File.Exists(powerShellShortcutPath))
                {
                    _STAThreadException = new Exception(string.Format("UpdatePSShortcut: file {0} does not exist", powerShellShortcutPath));
                    return;
                }

                ShellLink powerShellShellLink = new ShellLink(powerShellShortcutPath);
                if (File.Exists(powerShellDefaultShortcutPath))
                {
                    session.Log("UpdatePSShortcut: found default Windows PowerShell shortcut at {0}", powerShellDefaultShortcutPath);
                    ShellLink powerShellDefaultShellLink = new ShellLink(powerShellDefaultShortcutPath);
                    powerShellShellLink.ConsoleProperties = powerShellDefaultShellLink.ConsoleProperties;
                }
                else
                {
                    session.Log("UpdatePSShortcut: default Windows PowerShell shortcut does not exist at {0}", powerShellDefaultShortcutPath);

                    for (int i = 0; i < powerShellShellLink.ConsoleProperties.ColorTable.Length; i++)
                    {
                        powerShellShellLink.ConsoleProperties.ColorTable[i] = powerShellDefaultColorTable[i];
                    }
                    powerShellShellLink.AutoPosition = true;
                    powerShellShellLink.CommandHistoryBufferSize = 50;
                    powerShellShellLink.CommandHistoryBufferCount = 4;

                    powerShellShellLink.InsertMode = true;

                    powerShellShellLink.PopUpBackgroundColor = 15;
                    powerShellShellLink.PopUpTextColor = 3;

                    powerShellShellLink.QuickEditMode = true;

                    powerShellShellLink.ScreenBackgroundColor = 5;
                    powerShellShellLink.ScreenTextColor = 6;

                    powerShellShellLink.SetScreenBufferSize(120, 3000);
                    powerShellShellLink.SetWindowSize(120, 50);
                }
                powerShellShellLink.SetFont();
                powerShellShellLink.Save();
                session.Log("UpdatePSShortcut: success");
            }
            catch (Exception ex)
            {
                _STAThreadException = new Exception(string.Format("UpdatePSShortcut: failed with exception {0}", ex.Message));
            }
        }

        [CustomAction]
        public static ActionResult UpdatePSShortcut(Session session)
        {
            Thread staThread = new Thread(RunSTAThread);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start(session);
            // Wait for the new thread to finish its operations
            staThread.Join();

            // If there is any exception in the new thread pass it to the installer
            if (_STAThreadException != null)
            {
                session.Log(_STAThreadException.Message);
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }
    }
}