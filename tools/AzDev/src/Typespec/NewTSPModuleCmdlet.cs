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

using AzDev.Models;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AzDev.Cmdlets.Typespec
{
    /*
        TODO: 
            0. preinstall tsc/tsp?
            1. handle additional directories
            2. add more try catch on file operations
            3. add more logging
            4. support debug
            5. polish the try-finally block
                5.1 cmdlet could fail before reaching try block which causes temp files not cleaned up
                5.2 too many lines in the try block make it hard to catch exceptions
                5.3 maybe use "using + filestream" for IO operations
    */
    /*
        1. -tsplocation provided but no tsp-location.json, update tsp-location with -tsplocation
        2. -tsplocation provided and tsp-location.yaml exists, use -tsplocation and update tsp-location.yaml
        3. no -tsplocation and there is a tsp-location.yaml, use tsp-location.yaml as -tsplocation
        4. if -tspconfig provided, merge it with -tsplocation
    */
    [Cmdlet("New", "DevTSPModule")]
    public class NewTSPModuleCmdlet : DevCmdletBase
    {
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Regex pattern to match GitHub URLs pointing to tspconfig.yaml files with 40-character commit hashes (SHA-1).
        /// 
        /// Examples:
        /// - https://github.com/Azure/azure-rest-api-specs/blob/abc123.../path/tspconfig.yaml
        /// - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/abc123.../path/tspconfig.yaml
        /// 
        /// Note: The pattern expects exactly 40-character commit hashes (SHA-1). If GitHub moves to SHA-256 hashes (64 characters),
        /// this pattern will need to be updated.
        /// </summary>
        private const string UriRegex = "^https://(?<urlRoot>github|raw.githubusercontent).com/(?<repo>[^/]*/azure-rest-api-specs(-pr)?)/(tree/|blob/)?(?<commit>[0-9a-f]{40})/(?<path>.*)/tspconfig.yaml$";

        private const string emitterName = "@azure-tools/typespec-powershell";

        /// <summary>
        /// Name of the temporary directory used to store intermediate TypeSpec files during module update operations.
        /// This directory is created in a controlled location and is intended to be cleaned up after use.
        /// The name "TempTypeSpecFiles" was chosen for clarity, but developers should be aware of potential
        /// conflicts if a directory with the same name exists in the target location, especially on case-sensitive file systems.
        /// Consider updating the logic to use a more unique name if this becomes an issue.
        /// </summary>
        private const string tempDirName = "TempTypeSpecFiles";

        private string _npmPath = "";
        
        [Parameter(HelpMessage = "The location of the TSP config file (can be a URL or local path). Will look for `tsp-location.yaml` in current directory if not provided.")]
        public string TSPLocation { get; set; }

        [Parameter(HelpMessage = "The root directory of the Azure PowerShell repository. You can either set it through this parameter or through `Set-DevContext -RepoRoot`. Will look for the root from current directory if not provided.")]
        public string RepoRoot { get; set; }

        [Parameter(HelpMessage = "The directory in the remote repository where the TSP config is located. Do not use this parameter along with `-TSPLocation`.")]
        public string RemoteDirectory { get; set; }

        [Parameter(HelpMessage = "The commit hash in the remote repository where the TSP config is located. Do not use this parameter along with `-TSPLocation`.")]
        public string RemoteCommit { get; set; }

        [Parameter(HelpMessage = "The repository in the remote repository where the TSP config is located. Do not use this parameter along with `-TSPLocation`.")]
        public string RemoteRepositoryName { get; set; }

        [Parameter(HelpMessage = "The fork name of the remote repository where the TSP config is located. Do not use this parameter along with `-TSPLocation` and `-RemoteRepository`.")]
        public string RemoteForkName { get; set; }

        [Parameter(HelpMessage = "The path to an additional TSP config file to merge with the main TSP config. Will look for `tspconfig.yaml` in current directory if not provided.")]
        public string AzPSConfig { get; set; }

        [Parameter(HelpMessage = "Skip cleanup of temporary files.")]
        public SwitchParameter SkipCleanTemp { get; set; }

        [Parameter(HelpMessage = "The path of local emitter")]
        public string EmitterPath { get; set; }

        protected override void ProcessRecord()
        {
            string currentPath = this.SessionState.Path.CurrentFileSystemLocation.Path;

            /*
                Calculate location of TSP, it could be from:
                    1. remote `-TSPlocation`
                    2. local `-TSPlocation`
                    3. Combination of `-Remote*` parameters
                    4. `tsp-location.yaml` in current directory
            */
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(TSPLocation)))
            {
                if (this.MyInvocation.BoundParameters.ContainsKey(nameof(RemoteDirectory)) ||
                    this.MyInvocation.BoundParameters.ContainsKey(nameof(RemoteCommit)) ||
                    this.MyInvocation.BoundParameters.ContainsKey(nameof(RemoteRepositoryName)) ||
                    this.MyInvocation.BoundParameters.ContainsKey(nameof(RemoteForkName)))
                {
                    throw new ArgumentException("Please do not provide `-RemoteDirectory`, `-RemoteCommit`, `-RemoteRepositoryName` or `-RemoteForkName` along with `-TSPLocation`.");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(RemoteRepositoryName) && !string.IsNullOrEmpty(RemoteForkName))
                {
                    RemoteRepositoryName = $"{RemoteForkName}/azure-rest-api-specs";
                }
                if (!string.IsNullOrEmpty(RemoteRepositoryName) && !string.IsNullOrEmpty(RemoteCommit) && !string.IsNullOrEmpty(RemoteDirectory))
                {
                    TSPLocation = new UriBuilder
                    {
                        Scheme = "https",
                        Host = "raw.githubusercontent.com",
                        Path = $"{RemoteRepositoryName ?? "Azure/azure-rest-api-specs"}/{RemoteCommit ?? "main"}/{RemoteDirectory ?? ""}/tspconfig.yaml"
                    }.ToString();
                }
            }
            //use tsp-location.yaml in current directory if no -tsplocation provided
            if (string.IsNullOrEmpty(TSPLocation))
            {
                string tspLocationPathPWD = Path.Combine(currentPath, "tsp-location.yaml");
                if (!File.Exists(tspLocationPathPWD))
                {
                    throw new ArgumentException("Please provide `-TSPLocation`");
                }
                TSPLocation = ConstructTSPConfigUriFromTSPLocation(tspLocationPathPWD, (RemoteDirectory, RemoteCommit, RemoteRepositoryName, RemoteForkName));
            }
            // resolve local path of TSP as absolute if it's relative
            bool isRemote = IsRemoteUri(TSPLocation);
            if (!isRemote && !Path.IsPathRooted(TSPLocation))
            {
                TSPLocation = Path.GetFullPath(TSPLocation, currentPath);
            }
            else if (isRemote)
            {
                (TSPLocation, RemoteCommit, RemoteRepositoryName, RemoteDirectory) = ResolveTSPConfigUri(TSPLocation);
                RemoteDirectory = NormalizePath(RemoteDirectory);
            }

            /*
                Calculate location of AzPSConfig, it could be from:
                    1. `-AzPSConfig`
                    2. `tspconfig.yaml` in current directory
            */
            if (!this.MyInvocation.BoundParameters.ContainsKey(nameof(AzPSConfig)))
            {
                string azpsConfigPathPWD = Path.Combine(currentPath, "tspconfig.yaml");
                if (!File.Exists(azpsConfigPathPWD))
                {
                    WriteWarning($"No `-AzPSConfig` provided or `tspconfig.yaml` detected in `{azpsConfigPathPWD}`.");
                    AzPSConfig = null;
                } 
                else
                {
                    AzPSConfig = azpsConfigPathPWD;
                }  
            }
            // resolve local path of AzPSConfig as absolute if it's relative
            if (!string.IsNullOrEmpty(AzPSConfig) && !IsRemoteUri(AzPSConfig) && !Path.IsPathRooted(AzPSConfig))
            {
                AzPSConfig = Path.GetFullPath(AzPSConfig, currentPath);
            }
            else if (!string.IsNullOrEmpty(AzPSConfig) && IsRemoteUri(AzPSConfig))
            {
                (AzPSConfig, _, _, _) = ResolveTSPConfigUri(AzPSConfig);
            }


            /*
                Calculate RepoRoot
            */
            DevContext context;
            try
            {
                context = ContextProvider.LoadContext();
            }
            catch
            {
                context = null;
            }
            RepoRoot = GetRepoRoot((context, RepoRoot, currentPath));

            /*
                merge AzPSConfig to tspconfig if provided
            */
            Dictionary<object, object> mergedTspConfig = (Dictionary<object, object>)MergeTSPConfig(TSPLocation, AzPSConfig);
            Dictionary<object, object> options = (Dictionary<object, object>)mergedTspConfig["options"];
            Dictionary<object, object> option = (Dictionary<object, object>)options[emitterName];
            string emitterOutputDir;
            if (option.ContainsKey("emitter-output-dir"))
            {
                emitterOutputDir = (string)option["emitter-output-dir"];
                emitterOutputDir = TryResolveDirFromTSPConfig(option, emitterOutputDir);
            }
            else if (AzPSConfig != null && !IsRemoteUri(AzPSConfig))
            {
                //If there is a child tspconfig, use its directory to emit
                emitterOutputDir = Path.GetDirectoryName(AzPSConfig);
            }
            else 
            {
                throw new ArgumentException($"No emitter-output-dir configured in {TSPLocation}");
            }
            // if emitter-output-dir is not absolute, assume it's relative to RepoRoot
            if (!Path.IsPathRooted(emitterOutputDir))
            {
                emitterOutputDir = Path.GetFullPath(emitterOutputDir, RepoRoot);
            }

            /*
                1. Prepare TSP from TSP location, copy TSP to temp directory under emitter output directory
                    1.1 remote
                        `--no-checkout` clone azure-rest-api-specs repo
                        Sparse checkout directory in tsp location
                    1.2 local
                        copy service directory to current directory
                2. replace tspconfig.yaml in the temp directory with mergedTspConfig
                3. replace package.json with project emitter package.json

                        
            */
            string tempTSPLocation = isRemote ?
                PrepareTSPFromRemote(RemoteRepositoryName, RemoteCommit, RemoteDirectory, emitterOutputDir).GetAwaiter().GetResult() :
                PrepareTSPFromLocal(TSPLocation, emitterOutputDir);
            if (!File.Exists(tempTSPLocation))
            {
                throw new InvalidOperationException($"The specified TSP config file [{tempTSPLocation}] does not exist.");
            }
            File.WriteAllText(tempTSPLocation, YamlHelper.Serialize(mergedTspConfig));

            /*
                persist tsp-location.yaml to Emitter output directory
            */
            if (!isRemote)
            {
                RemoteDirectory = TSPLocation;
            }
            object tspLocationData = new
            {
                directory = RemoteDirectory,
                commit = RemoteCommit,
                repo = RemoteRepositoryName
            };
            File.WriteAllText(Path.Combine(emitterOutputDir, "tsp-location.yaml"), YamlHelper.Serialize(tspLocationData));

            string emitterPackageJsonPath = Path.Combine(RepoRoot, "eng", "emitter-package.json");
            File.Copy(emitterPackageJsonPath, Path.Combine(Path.GetDirectoryName(tempTSPLocation), "package.json"), true);

            /*
                emit from tempTSPLocation
            */
            try
            {
                if (!File.Exists(Path.Combine(workingDirectory, "package.json")))
                {
                    throw new FileNotFoundException($"package.json not found in {workingDirectory}");
                }
                RunCommand(FindNPMCommandFromPath("npm"), File.Exists(Path.Combine(workingDirectory, "package-lock.json")) ? "ci" : "install", workingDirectory).Wait();
                RunCommand(FindNPMCommandFromPath("tsp"), $"compile ./ --emit {EmitterPath ?? emitterName} --output-dir {emitterOutputDir}", Path.GetDirectoryName(tempTSPLocation)).Wait();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to emit from TSP config [{tempTSPLocation}]: {ex.Message}", ex);
            }
            finally
            {
                if (!SkipCleanTemp)
                {
                    try
                    {
                        string tempDirPath = Path.Combine(emitterOutputDir, tempDirName);
                        ForceDeleteDir(tempDirPath);
                    }
                    catch (Exception ex)
                    {
                        WriteWarning($"Failed to clean up temporary files: {ex.Message}");
                    }
                }
            }
        }

        private string FindNPMCommandFromPath(string command)
        {
            Console.WriteLine($"##########DEBUG: looking for command: {command} ##########");
            string commandSuffix = Environment.OSVersion.Platform == PlatformID.Win32NT ? ".cmd":"";
            Console.WriteLine($"##########DEBUG: looking for suffix: {commandSuffix} ##########");
            if ( string.IsNullOrEmpty(_npmPath) || !File.Exists(_npmPath))
            {
                string pathEnv = Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
                Console.WriteLine($"##########DEBUG: looking for path: {pathEnv} ##########");
                string npmPath = pathEnv.Split(Path.PathSeparator).FirstOrDefault(path => path.EndsWith("npm"));
                _npmPath = npmPath;
            }
            Console.WriteLine($"##########DEBUG: looking for npm path: {_npmPath} ##########");
            string commandPath = Path.Combine(_npmPath, command+commandSuffix);
            Console.WriteLine($"##########DEBUG: Found npm command path: {commandPath} ##########");
            if (!File.Exists(commandPath))
            {
                
                throw new FileNotFoundException($"Command '{command}' not found in system PATH.");
            }
            return commandPath;
        }

        private string NormalizePath(string path) => path.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);

        private void ForceDeleteDir(string path)
        {
            if (!Directory.Exists(path))
            {
                return;
            }
            foreach (var file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
            {
                File.SetAttributes(file, FileAttributes.Normal);
            }

            Directory.Delete(path, true);
        }

        private (string, string, string, string) ResolveTSPConfigUri(string uri)
        {
            Match match = Regex.Match(uri, UriRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                throw new ArgumentException($"The provided TSP config URI [{uri}] is not valid.");
            }
            if (match.Groups["urlRoot"]?.Value == "github")
            {
                uri = uri.Replace("github.com", "raw.githubusercontent.com").Replace("/blob/", "/").Replace("/tree/", "/");
            }
            string repo = match.Groups["repo"].Value;
            string commit = match.Groups["commit"].Value;
            string path = match.Groups["path"].Value;
            return (uri, commit, repo, path);
        }

        private async Task<string> PrepareTSPFromRemote(string repo, string commit, string path, string outDir)
        {
            string tempDirPath = Path.Combine(outDir, tempDirName);
            try
            {
                if (Directory.Exists(tempDirPath))
                {
                    ForceDeleteDir(tempDirPath);
                }
                Directory.CreateDirectory(tempDirPath);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to prepare temporary directory [{tempDirPath}]: {ex.Message}", ex);
            }
            string cloneRepo = $"https://github.com/{repo}.git";
            await RunCommand("git", $"clone {cloneRepo} {tempDirPath} --no-checkout --filter=tree:0", outDir);
            await RunCommand("git", $"sparse-checkout set {path}", tempDirPath);
            await RunCommand("git", $"sparse-checkout add {path}", tempDirPath);
            await RunCommand("git", $"checkout {commit}", tempDirPath);
            return Path.Combine(tempDirPath, path, "tspconfig.yaml");
        }

        private string PrepareTSPFromLocal(string tspLocation, string outDir)
        {
            tspLocation = Path.GetDirectoryName(tspLocation);
            string tempDirPath = Path.Combine(outDir, tempDirName);
            try
            {
                if (Directory.Exists(tempDirPath))
                {
                    ForceDeleteDir(tempDirPath);
                }
                Directory.CreateDirectory(tempDirPath);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to prepare temporary directory [{tempDirPath}]: {ex.Message}", ex);
            }
            CopyDirectory(tspLocation, tempDirPath, ["tsp-output", "node_modules"]);
            return Path.Combine(tempDirPath, Path.GetFileName(tspLocation), "tspconfig.yaml");
        }

        // Copies the contents of sourceDir into a subdirectory (named after sourceDir) within destinationDir,
        // excluding any files or directories specified in the 'exclude' array.
        private void CopyDirectory(string sourceDir, string destinationDir, string[] exclude)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {sourceDir}");
            }
            string currentDir = Path.Combine(destinationDir, dir.Name);
            Directory.CreateDirectory(currentDir);
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (exclude != null && Array.Exists(exclude, e => e.Equals(file.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }
                string tempPath = Path.Combine(currentDir, file.Name);
                file.CopyTo(tempPath, false);
            }
            foreach (DirectoryInfo subdir in dirs)
            {
                if (exclude != null && Array.Exists(exclude, e => e.Equals(subdir.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }
                CopyDirectory(subdir.FullName, currentDir, exclude);
            }
        }

        private async Task RunCommand(string command, string arguments, string workingDirectory)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                WorkingDirectory = workingDirectory,
                RedirectStandardOutput = true,     // Capture output
                RedirectStandardError = true,      // Capture errors
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;

                // Attach real-time output event handlers
                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        Console.WriteLine(e.Data);
                };
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        Console.Error.WriteLine(e.Data);
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                await process.WaitForExitAsync();
                if (process.ExitCode != 0)
                {
                    throw new InvalidOperationException($"Command '{command} {arguments}' failed with exit code {process.ExitCode}");
                }
            }
        }

        private string TryResolveDirFromTSPConfig(Dictionary<object, object> option, string dir)
        {
            if (string.IsNullOrEmpty(dir))
            {
                return null;
            }
            StringBuilder resolvedDir = new StringBuilder();
            string[] segments = dir.Split('/', '\\', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < segments.Length; i++)
            {
                string segment = segments[i];
                if (segment[0] == '{' && segment[^1] == '}')
                {
                    string key = segment.Substring(1, segment.Length - 2);
                    segment = option.ContainsKey(key) ? (string)option[key] : string.Empty;
                }
                if (string.IsNullOrEmpty(segment))
                {
                    continue;
                }
                resolvedDir.Append(segment);
                if (i < segments.Length - 1)
                {
                    resolvedDir.Append(Path.DirectorySeparatorChar);
                }

            }
            return resolvedDir.ToString();
        }

        private bool IsRoot(string path) => Directory.Exists(Path.Combine(path, ".azure-pipelines")) &&
                                            Directory.Exists(Path.Combine(path, "src")) &&
                                            Directory.Exists(Path.Combine(path, "generated")) &&
                                            Directory.Exists(Path.Combine(path, ".github"));

        private string GetRepoRoot((DevContext, string, string) repoInfo)
        {
            (DevContext context, string repoRoot, string currentPath) = repoInfo;
            if (!string.IsNullOrEmpty(repoRoot))
            {
                if (!Directory.Exists(repoRoot) || !IsRoot(repoRoot))
                {
                    throw new ArgumentException($"The provided RepoRoot [{repoRoot}] is not a valid Azure PowerShell repository root.");
                }
                return repoRoot;
            }
            if (context != null && !string.IsNullOrEmpty(context.AzurePowerShellRepositoryRoot) && Directory.Exists(context.AzurePowerShellRepositoryRoot))
            {
                return context.AzurePowerShellRepositoryRoot;
            }
            string potentialRoot = currentPath;
            while (!string.IsNullOrEmpty(potentialRoot) && !IsRoot(potentialRoot))
            {
                potentialRoot = Path.GetDirectoryName(potentialRoot);
            }
            if (string.IsNullOrEmpty(potentialRoot))
            {
                throw new ArgumentException("Unable to determine Azure PowerShell repository root. Please execute this cmdlet in Azure-PowerShell repository, or please provide `-RepoRoot` or set it through `Set-DevContext -RepoRoot`.");
            }
            return potentialRoot;
        }

        private string ConstructTSPConfigUriFromTSPLocation(string tspLocationPath, (string, string, string, string) remoteInfo)
        {
            Dictionary<string, object> tspLocationPWDContent = YamlHelper.Deserialize<Dictionary<string, object>>(File.ReadAllText(tspLocationPath));
            //if tspconfig emitted previously was from local, only record the absolute directory name
            if (File.Exists((string)tspLocationPWDContent["directory"]) && string.IsNullOrEmpty((string)tspLocationPWDContent["repo"]) && string.IsNullOrEmpty((string)tspLocationPWDContent["commit"]))
            {
                if (remoteInfo != (null, null, null, null))
                {
                    throw new ArgumentException("Emitted by local TSP last time, cannot update by remote info. Please provide remote `-TSPLocation`.");
                }
                return (string)tspLocationPWDContent["directory"];
            }
            (string RemoteDirectory, string RemoteCommit, string RemoteRepositoryName, string RemoteForkName) = remoteInfo;
            //otherwise it was from remote, construct its url
            string repo = !string.IsNullOrEmpty(RemoteForkName) ? $"{RemoteForkName}/azure-rest-api-specs" : (!string.IsNullOrEmpty(RemoteRepositoryName) ? RemoteRepositoryName : (string)tspLocationPWDContent["repo"]);
            string commit = !string.IsNullOrEmpty(RemoteCommit) ? RemoteCommit : (string)tspLocationPWDContent["commit"];
            string directory = !string.IsNullOrEmpty(RemoteDirectory) ? RemoteDirectory : (string)tspLocationPWDContent["directory"];
            UriBuilder uriBuilder = new UriBuilder
            {
                Scheme = "https",
                Host = "raw.githubusercontent.com",
                Path = $"{repo}/{commit}/{directory}/tspconfig.yaml"
            };
            return uriBuilder.ToString();
        }

        private bool IsRemoteUri(string uri) => Uri.TryCreate(uri, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        private string GetTSPConfig(string uri) => IsRemoteUri(uri) ? GetTSPConfigRemote(uri).GetAwaiter().GetResult() : GetTSPConfigLocal(uri).GetAwaiter().GetResult();

        private async Task<string> GetTSPConfigRemote(string uri)
        {
            // Validate URI
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentException("URI cannot be null or empty", nameof(uri));
            }

            if (!Uri.TryCreate(uri, UriKind.Absolute, out Uri validatedUri))
            {
                throw new ArgumentException($"Invalid URI format: {uri}", nameof(uri));
            }

            // Ensure HTTPS for security
            if (validatedUri.Scheme != Uri.UriSchemeHttps && validatedUri.Scheme != Uri.UriSchemeHttp)
            {
                throw new ArgumentException($"Only HTTP and HTTPS URIs are supported: {uri}", nameof(uri));
            }

            Console.WriteLine($"Downloading TSP config from: {uri}");

            // Prepare request and timeout
            using var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("User-Agent", "AzDev-TSPConfig/1.0");

            using var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromMinutes(2));

            try
            {
                // Send request and get response
                using var response = await httpClient.SendAsync(request, cts.Token);

                // Check response status
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Failed to download TSP config. Status: {response.StatusCode}, Reason: {response.ReasonPhrase}");
                }

                // Read and validate content
                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new InvalidOperationException("Downloaded TSP config content is empty");
                }

                Console.WriteLine($"Successfully downloaded TSP config ({content.Length} characters)");
                return content;
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException || ex.CancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException($"Timeout occurred while downloading TSP config from {uri}", ex);
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException($"Network error occurred while downloading TSP config: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to download tspconfig from {uri}, {ex.Message}", ex);
            }
        }

        private async Task<string> GetTSPConfigLocal(string uri)
        {
            // Validate uri
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentException("URI cannot be null or empty", nameof(uri));
            }

            // Normalize and validate the path
            string normalizedPath;
            try
            {
                normalizedPath = Path.GetFullPath(uri);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Invalid file path: {uri}", nameof(uri), ex);
            }

            // Check if file exists
            if (!File.Exists(normalizedPath))
            {
                throw new FileNotFoundException($"TSP config file not found: {normalizedPath}", normalizedPath);
            }

            Console.WriteLine($"Reading TSP config from local file: {normalizedPath}");

            try
            {
                // Read file content asynchronously
                var content = await File.ReadAllTextAsync(normalizedPath);

                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new InvalidOperationException($"TSP config file is empty: {normalizedPath}");
                }

                Console.WriteLine($"Successfully read TSP config from local file ({content.Length} characters)");
                return content;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException($"Access denied reading TSP config file: {normalizedPath}", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"IO error reading TSP config file: {normalizedPath} - {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to read tspconfig from {normalizedPath}, {ex.Message}", ex);
            }
        }
        
        private object MergeTSPConfig(string parentConfigPath, string childConfigPath)
        {
            string parentConfig = GetTSPConfig(parentConfigPath);

            // Validate and deserialize parent config
            if (string.IsNullOrWhiteSpace(parentConfig) || !YamlHelper.TryDeserialize<IDictionary<object, object>>(parentConfig, out IDictionary<object, object> parent))
            {
                throw new ArgumentException("Invalid parent TSP config: " + parentConfig, nameof(parentConfig));
            }

            // return parent if no child config provided
            if (string.IsNullOrEmpty(childConfigPath))
            {
                Console.WriteLine($"No ChildConfig provided, use {parentConfigPath}");
                return parent;
            }
            string childConfig = GetTSPConfig(childConfigPath);
            // Validate and deserialize child config
            if (string.IsNullOrWhiteSpace(childConfig) || !YamlHelper.TryDeserialize<IDictionary<object, object>>(childConfig, out IDictionary<object, object> child))
            {
                throw new ArgumentException("Invalid child TSP config: " + childConfig, nameof(childConfig));
            }

            Console.WriteLine("Performing deep merge for parent: " + parentConfigPath + " and child: " + childConfigPath);
            var mergedConfig = MergeNestedObjectIteratively(parent, child);
            Console.WriteLine("TSP config merge completed successfully");
            return mergedConfig;
        }

        private IDictionary<object, object> MergeNestedObjectIteratively(IDictionary<object, object> parent, IDictionary<object, object> child)
        {
            // Create result starting with parent
            var result = new Dictionary<object, object>(parent);

            // Stack to track merge operations: (targetDict, sourceDict, keyPath)
            var mergeStack = new Stack<(IDictionary<object, object> target, IDictionary<object, object> source, string path)>();

            // Start with root level merge
            mergeStack.Push((result, child, "root"));

            while (mergeStack.Count > 0)
            {
                var (targetDict, sourceDict, currentPath) = mergeStack.Pop();

                foreach (var kvp in sourceDict)
                {
                    var key = kvp.Key;
                    var childValue = kvp.Value;
                    var keyPath = $"{currentPath}.{key}";

                    if (targetDict.ContainsKey(key))
                    {
                        var parentValue = targetDict[key];

                        // Apply merge rules iteratively
                        if (childValue == null)
                        {
                            // Child is null, keep parent value (no change needed)
                            continue;
                        }
                        else if (parentValue == null)
                        {
                            // Parent is null, replace with child
                            targetDict[key] = childValue;
                        }
                        else if (!(childValue is IDictionary<object, object>))
                        {
                            // Rule: Arrays and primitives replace parent
                            targetDict[key] = childValue;
                        }
                        else if (parentValue is IDictionary<object, object> parentNestedDict &&
                                childValue is IDictionary<object, object> childNestedDict)
                        {
                            // Both are dictionaries - need to merge them
                            // Create a new dictionary for this nested level
                            var nestedResult = new Dictionary<object, object>(parentNestedDict);
                            targetDict[key] = nestedResult;

                            // Push this nested merge operation onto the stack
                            mergeStack.Push((nestedResult, childNestedDict, keyPath));
                        }
                        else
                        {
                            // Parent is not a dictionary but child is, child replaces parent
                            targetDict[key] = childValue;
                        }
                    }
                    else
                    {
                        // Key doesn't exist in parent, add it from child
                        targetDict[key] = childValue;
                    }
                }
            }
            return result;
        }
    }
}