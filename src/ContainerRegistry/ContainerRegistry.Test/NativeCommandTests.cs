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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.ContainerRegistry.Test
{
    [Trait(Category.AcceptanceType, Category.CheckIn)]
    public class NativeCommandTests
    {
        public static IEnumerable<object[]> CredentialCases()
        {
            var credentials = new[]
            {
                new[] { "user", "password" },
                new[] { "user name", "password with spaces" },
                new[] { "user'name", "pass'word" },
                new[] { "user\"name", "pass\"word" },
                new[] { "user;$(throw 'evaluated')", "'; throw 'Password evaluated'; #" },
                new[] { "user", "line1\r\nline2" },
                new[] { "user\\\"name", "pass`word;&|<>$()" },
                new[] { "user\" name", "password" },
                new[] { "user name\\", "password" },
                new[] { "\"quoted user\"", "password" },
                new[] { "user\\\\\" name\\", "password" },
                new[] { "us\u00e9r", "p\u00e4ss\u6587" }
            };
            foreach (string[] credential in credentials)
            {
                yield return new object[] { credential[0], credential[1] };
            }
        }

        [Theory]
        [MemberData(nameof(CredentialCases))]
        public async Task DockerLoginPassesLiteralArgumentsAndStdin(
            string username,
            string password)
        {
            string directory = Path.Combine(Path.GetTempPath(), "AcrNativeLogin-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);
            try
            {
                string inputPath = Path.Combine(directory, "input.json");
                string outputPath = Path.Combine(directory, "output.json");
                File.WriteAllText(inputPath, JsonConvert.SerializeObject(new
                {
                    UserName = username,
                    Password = password
                }));
                string moduleArtifacts = typeof(NativeCommandTests).Assembly
                    .GetCustomAttributes<AssemblyMetadataAttribute>()
                    .Single(attribute => attribute.Key == "ModuleArtifactsPath").Value;
                var start = new ProcessStartInfo("pwsh")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };
                start.ArgumentList.Add("-NoLogo");
                start.ArgumentList.Add("-NoProfile");
                start.ArgumentList.Add("-NonInteractive");
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // Allow only this child process to run the repository-owned test script.
                    start.ArgumentList.Add("-ExecutionPolicy");
                    start.ArgumentList.Add("Bypass");
                }
                start.ArgumentList.Add("-File");
                start.ArgumentList.Add(Path.Combine(AppContext.BaseDirectory, "NativeCommand", "Invoke-DockerLogin.ps1"));
                start.ArgumentList.Add("-ModuleArtifactsPath");
                start.ArgumentList.Add(moduleArtifacts);
                start.ArgumentList.Add("-InputPath");
                start.ArgumentList.Add(inputPath);
                start.ArgumentList.Add("-OutputPath");
                start.ArgumentList.Add(outputPath);

                using (var process = Process.Start(start))
                {
                    Task<string> stdout = process.StandardOutput.ReadToEndAsync();
                    Task<string> stderr = process.StandardError.ReadToEndAsync();
                    using (var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(60)))
                    {
                        try
                        {
                            await process.WaitForExitAsync(timeout.Token);
                        }
                        finally
                        {
                            if (!process.HasExited)
                            {
                                process.Kill(entireProcessTree: true);
                                await process.WaitForExitAsync();
                            }
                        }
                    }
                    Assert.True(process.ExitCode == 0, (await stderr) + (await stdout));
                }

                var capture = JObject.Parse(File.ReadAllText(outputPath));
                Assert.Equal(new[]
                {
                    "login", "myregistry-0123456789abcdef.azurecr.io", "-u", username, "--password-stdin"
                }, capture["Arguments"].ToObject<string[]>());
                Assert.Equal(Encoding.UTF8.GetBytes(password + Environment.NewLine),
                    Convert.FromBase64String(capture["StandardInput"].Value<string>()));
            }
            finally
            {
                Directory.Delete(directory, recursive: true);
            }
        }
    }
}
