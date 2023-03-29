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

using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Management.Automation;
using System.Net.Sockets;
using Microsoft.Azure.Commands.Common.Exceptions;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Ssh.Properties;

namespace Microsoft.Azure.Commands.Ssh
{
    [Cmdlet(
        VerbsCommon.Enter,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM",
        DefaultParameterSetName = InteractiveParameterSet)]
    [OutputType(typeof(bool))]
    [Alias("Enter-AzArcServer")]
    public sealed class EnterAzVMCommand : SshBaseCmdlet
    {
        #region Supress Export-AzSshConfig Parameters

        public override string ConfigFilePath
        { 
            get { return null; } 
        }
        public override SwitchParameter Overwrite
        {
            get { return false; }
        }

        public override string KeysDestinationFolder
        {
            get { return null; }
        }

        #endregion

        #region fields
        private int rdpLocalPort;
        #endregion

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ValidateParameters();
            SetResourceType();
 
            ProgressRecord record = new ProgressRecord(0, "Prepare for starting SSH connection", "Start Preparing");
            UpdateProgressBar(record, "Start preparing", 0);

            if (!IsArc() && !ParameterSetName.Equals(IpAddressParameterSet))
            {
                GetVmIpAddress();
                UpdateProgressBar(record, "Retrieved the IP address of the target VM", 50);
            }
            if (IsArc())
            {
                proxyPath = GetClientSideProxy();
                UpdateProgressBar(record, $"Dowloaded SSH Proxy, saved to {proxyPath}", 25);
                GetRelayInformation();
                UpdateProgressBar(record, $"Retrieved Relay Information", 50);
            }
            try
            {
                if (LocalUser == null)
                {
                    PrepareAadCredentials();
                }
                
                record.RecordType = ProgressRecordType.Completed;
                UpdateProgressBar(record, "Ready to start SSH connection.", 100);


                int sshStatus = 0;
                if (Rdp.IsPresent)
                {
                    sshStatus = StartRDPConnection();
                }
                else
                {
                    sshStatus = StartSSHConnection();
                }
                
                if (this.PassThru.IsPresent)
                {
                    WriteObject(sshStatus == 0);
                }
            }
            finally
            {
                DoCleanup();
            }
        }

        #region Private Methods

        private int StartSSHConnection()
        {
            Process sshProcess = CreateSSHProcess();

            // Redirect OpenSSH Logs and use it to determine when authentication succeeds, so that cleanup can be performed.
            // Redirect SSH Proxy logs to provide helpful error messaged when well known errors happen.
            if (!SshLogsPrinted() && !IsDebugMode() &&
                (deleteCert || (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && IsArc())))
            {
                sshProcess.StartInfo.RedirectStandardError = true;
            }
                    
            sshProcess.Start();

            if (deleteCert && !sshProcess.StartInfo.RedirectStandardError)
                WaitToDeleteCred(sshProcess);
            if (sshProcess.StartInfo.RedirectStandardError)
                ReadSshLogs(sshProcess);

            sshProcess.WaitForExit();

            return sshProcess.ExitCode;
        }

        private int StartRDPConnection()
        {
            Process sshProcess = null;
            int success = 1;

            try
            {
                // Get an open local port to act an a listener
                TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
                listener.Start();
                rdpLocalPort = ((IPEndPoint)listener.LocalEndpoint).Port;
                listener.Stop();

                // Start SSH Process
                sshProcess = CreateSSHProcess();
                sshProcess.StartInfo.RedirectStandardError = true;
                sshProcess.Start();

                bool sshSuccess = WaitSSHTunnelConnection(sshProcess);
                DoCleanup();

                if (sshSuccess && !sshProcess.HasExited)
                {
                    string rdpCommand = GetClientApplicationPath("mstsc");

                    Process rdpProcess = new Process();
                    rdpProcess.StartInfo.FileName = rdpCommand;
                    rdpProcess.StartInfo.Arguments = $"/v:localhost:{rdpLocalPort}";
                    rdpProcess.Start();
                    rdpProcess.WaitForExit();
                    success = rdpProcess.ExitCode;
                }
            }
            finally
            {
                if (sshProcess != null && !sshProcess.HasExited)
                {
                    sshProcess.Kill();
                    sshProcess.WaitForExit();

                    if (SshLogsPrinted() || IsDebugMode())
                    {
                        var stderr = sshProcess.StandardError;
                        string line;
                        while ((line = stderr.ReadLine()) != null)
                        {
                            Host.UI.WriteLine(line);
                            CheckForCommonErrors(line);
                        }
                    }
                }
            }

            return success;
        }

        private Process CreateSSHProcess()
        {
            string sshClient = GetClientApplicationPath("ssh");
            string command = $"{GetHost()} {BuildArgs()}";
            Process sshProcess = new Process();
            WriteDebug($"Running SSH command: {sshClient} {command}");

            if (IsArc())
                sshProcess.StartInfo.EnvironmentVariables["SSHPROXY_RELAY_INFO"] = relayInfo;
            sshProcess.StartInfo.FileName = sshClient;
            sshProcess.StartInfo.Arguments = command;
            sshProcess.StartInfo.UseShellExecute = false;
            return sshProcess;
        }

        private void ReadSshLogs(Process sshProcess)
        {
            var stderr = sshProcess.StandardError;
            string line;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while ((line = stderr.ReadLine()) != null)
            {
                if (!line.Contains("debug1: ") &&
                    !line.Contains("debug2: ") &&
                    !line.Contains("debug3: ") &&
                    !line.StartsWith("Authenticated "))
                {
                    Host.UI.WriteLine(line);
                    CheckForCommonErrors(line);
                }

                if (line.Contains("debug1: Entering interactive session.") || timer.ElapsedMilliseconds >= 120000)
                {
                    DoCleanup();
                }
            }

            return;
        }

        private void WaitToDeleteCred(Process sshProcess)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            while (timer.ElapsedMilliseconds < 120000)
            {
                if (sshProcess.HasExited) { return; }
                Thread.Sleep(1000);
            }
            if (!sshProcess.HasExited) { DoCleanup(); }
            return;
        }

        private bool WaitSSHTunnelConnection(Process sshProcess)
        {
            var stderr = sshProcess.StandardError;
            bool sshSuccess = false;
            string line;
            while ((line = stderr.ReadLine()) != null)
            {
                // Print logs if user expects it to be printed (if verbose or debug mode)
                // or if the message is not debug level (best effort to print fatal error messages and banner)
                if (SshLogsPrinted() || IsDebugMode()
                    || (!line.Contains("debug1: ") &&
                    !line.Contains("debug2: ") &&
                    !line.Contains("debug3: ") &&
                    !line.StartsWith("Authenticated ")))
                    Host.UI.WriteLine(line);
               
                CheckForCommonErrors(line);

                if (line.Contains("debug1: Entering interactive session."))
                {
                    WriteDebug("SSH Connection established successfully.");
                    sshSuccess = true;
                    break;
                }

                if (sshProcess.HasExited)
                {
                    WriteDebug("SSH Connection Failed.");
                    sshSuccess = false;
                    break;
                }
            }
            return sshSuccess;
        }


        private string GetHost()
        {
            if (IsArc() && LocalUser != null && Name != null) 
            {
                return LocalUser + "@" + Name;
            } else if (LocalUser != null && Ip != null)
            {
                return LocalUser + "@" + Ip;
            }
            throw new AzPSInvalidOperationException("Unable to determine target host.");
        }


        private string BuildArgs()
        {
            List<string> argList = new List<string>();

            if (PrivateKeyFile != null) { argList.Add("-i \"" + PrivateKeyFile + "\""); }

            if (CertificateFile != null) { argList.Add("-o CertificateFile=\"" + CertificateFile + "\""); }

            if (IsArc())
            {
                string pcommand = "ProxyCommand=\"" + proxyPath + "\"";
                if (Port != null)
                {
                    pcommand = "ProxyCommand=\"" + proxyPath + " -p " + Port + "\"";
                }
                argList.Add("-o " + pcommand);
            } else if (Port != null) 
            { 
                argList.Add("-p " + Port);
            }
            
            if (!SshLogsPrinted())
            { 
                if (IsDebugMode())
                {
                    // Print SSH verbose logs if cmdlet run on debug mode
                    argList.Add("-vvv");
                }
                else if (Rdp || deleteCert || (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && IsArc()))
                {
                    argList.Add("-v");
                }
            }

            if (Rdp)
            {
                argList.Add("-L");
                argList.Add($"{rdpLocalPort}:localhost:3389");
                argList.Add("-N");
            }

            if (SshArgument != null)
            {
                Array.ForEach(SshArgument, item => argList.Add(item));
            }

            return string.Join(" ", argList.ToArray());
        }

        private bool SshLogsPrinted()
        {
            if (SshArgument != null)
            {
                if (Array.Exists(SshArgument, x => x == "-v") &&
                    Array.Exists(SshArgument, x => x == "-vv") &&
                    Array.Exists(SshArgument, x => x == "-vvv")) { return true; }
            }
            return false;
        }

        private void DoCleanup()
        {
            if (deleteKeys && PrivateKeyFile != null)
            {
                DeleteFile(PrivateKeyFile, $"Couldn't delete Private Key file {PrivateKeyFile}.");
            }
            
            if (deleteKeys && PublicKeyFile != null)
            {
                DeleteFile(PublicKeyFile, $"Couldn't delete Public Key file {PublicKeyFile}.");
            }
            
            if (deleteCert && CertificateFile != null)
            {
                DeleteFile(CertificateFile, $"Couldn't delete Certificate File {CertificateFile}.");
            }
            
            if (deleteKeys && !String.IsNullOrEmpty(CertificateFile))
            {
                DeleteDirectory(Directory.GetParent(CertificateFile).ToString());
            }
            else if (deleteKeys && !String.IsNullOrEmpty(PrivateKeyFile))
            {
                DeleteDirectory(Directory.GetParent(PrivateKeyFile).ToString());
            }
        }

        private void CheckForCommonErrors(string line)
        {
            // For now we are only checking for one error. Will add more common errors on later releases.
            string pattern = "{\"level\":\"fatal\",\"msg\":\"sshproxy: error copying information from the connection: .*\",\"time\":\".*\"}.*";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(line))
            {
                throw new AzPSApplicationException(Resources.MakeSurePortIsEnabled);
            }
        }

        private bool IsDebugMode()
        {
            bool debug;
            bool containsDebug = MyInvocation.BoundParameters.ContainsKey("Debug");
            if (containsDebug)
                debug = ((SwitchParameter)MyInvocation.BoundParameters["Debug"]).ToBool();
            else
                debug = (ActionPreference)GetVariableValue("DebugPreference") != ActionPreference.SilentlyContinue;
            return debug;
        }

        #endregion
    }
}
