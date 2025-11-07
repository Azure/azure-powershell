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
using System.Globalization;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Azure.Identity;
using Azure.Core;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Compute
{
    public abstract class ComputeClientBaseCmdlet : AzureRMCmdlet
    {
        protected const string VirtualMachineExtensionType = "Microsoft.Compute/virtualMachines/extensions";

        protected override bool IsUsageMetricEnabled => true;
        protected DateTime StartTime;

        private ComputeClient computeClient;

        // Reusable static HttpClient for DryRun posts
        private static readonly HttpClient _dryRunHttpClient = CreateDryRunHttpClient();

        private static HttpClient CreateDryRunHttpClient()
        {
            int timeoutSeconds = 300; // Default 5 minutes
            
            // Allow override via environment variable
            string timeoutEnv = Environment.GetEnvironmentVariable("AZURE_POWERSHELL_DRYRUN_TIMEOUT_SECONDS");
            if (!string.IsNullOrWhiteSpace(timeoutEnv) && int.TryParse(timeoutEnv, out int customTimeout) && customTimeout > 0)
            {
                timeoutSeconds = customTimeout;
            }
            
            return new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(timeoutSeconds)
            };
        }

        [Parameter(Mandatory = false, HelpMessage = "Send the invoked PowerShell command (ps_script) and subscription id to a remote endpoint without executing the real operation.")]
        public SwitchParameter DryRun { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "When used together with -DryRun, export generated Bicep templates to the user's .azure directory.")]
        public SwitchParameter ExportBicep { get; set; }

        public ComputeClient ComputeClient
        {
            get
            {
                if (computeClient == null)
                {
                    computeClient = new ComputeClient(DefaultProfile.DefaultContext);
                }

                this.computeClient.VerboseLogger = WriteVerboseWithTimestamp;
                this.computeClient.ErrorLogger = WriteErrorWithTimestamp;
                return computeClient;
            }

            set { computeClient = value; }
        }

        public override void ExecuteCmdlet()
        {
            StartTime = DateTime.Now;

            // Validate ExportBicep usage
            if (ExportBicep.IsPresent && !DryRun.IsPresent)
            {
                ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException("-ExportBicep must be used together with -DryRun"),
                    "ExportBicepRequiresDryRun",
                    ErrorCategory.InvalidArgument,
                    null));
            }

            // Intercept early if DryRun requested
            if (DryRun.IsPresent && TryHandleDryRun())
            {
                return;
            }
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Handles DryRun processing: optionally prepend a custom PowerShell script segment (e.g. flattened object definition)
        /// before the original invocation line. Captures subscription id and posts to remote endpoint.
        /// If -ExportTemplateToPath is provided, sets export_bicep=True in payload and writes the returned bicep template
        /// (bicep_template.main_template) to the target path (file or directory).
        /// Returns true if DryRun was processed (and normal execution should stop).
        /// </summary>
        /// <param name="prePsInvocationScript">Optional PowerShell script lines to prepend before the actual invocation.</param>
        protected virtual bool TryHandleDryRun(string prePsInvocationScript = null)
        {
            try
            {
                string invocationLine = this.MyInvocation?.Line ?? this.MyInvocation?.InvocationName ?? string.Empty;
                string psScript = string.IsNullOrWhiteSpace(prePsInvocationScript)
                    ? invocationLine
                    : prePsInvocationScript + "\n" + invocationLine;
                string subscriptionId = this.DefaultContext?.Subscription?.Id ?? DefaultProfile.DefaultContext?.Subscription?.Id ?? string.Empty;

                bool exportBicep = ExportBicep.IsPresent;

                var payload = new
                {
                    ps_script = psScript,
                    subscription_id = subscriptionId,
                    timestamp_utc = DateTime.UtcNow.ToString("o"),
                    source = "Az.Compute.DryRun",
                    export_bicep = exportBicep ? "True" : "False"
                };

                string endpoint = Environment.GetEnvironmentVariable("AZURE_POWERSHELL_DRYRUN_ENDPOINT");
                if (string.IsNullOrWhiteSpace(endpoint))
                {
                    endpoint = "https://azcli-script-insight.azurewebsites.net/api/what_if_ps_preview";
                }
                string token = GetDryRunAuthToken();

                var dryRunResult = PostDryRun(endpoint, token, payload);
                JToken resultToken = null;
                try
                {
                    if (dryRunResult is JToken jt)
                    {
                        resultToken = jt;
                    }
                    else if (dryRunResult is string s && !string.IsNullOrWhiteSpace(s))
                    {
                        resultToken = JToken.Parse(s);
                    }
                    else
                    {
                        resultToken = dryRunResult != null ? JToken.FromObject(dryRunResult) : null;
                    }
                }
                catch { /* ignore parse errors */ }

                // If export requested, attempt to extract and persist bicep templates
                if (exportBicep && resultToken != null)
                {
                    var bicepRoot = resultToken.SelectToken("bicep_template");
                    var mainTemplateContent = bicepRoot?.SelectToken("main_template")?.Value<string>();
                    var moduleTemplatesToken = bicepRoot?.SelectToken("module_templates");

                    if (!string.IsNullOrWhiteSpace(mainTemplateContent) || moduleTemplatesToken != null)
                    {
                        try
                        {
                            // Base directory: ~/.azure/bicep
                            string baseDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".azure", "bicep");
                            if (!System.IO.Directory.Exists(baseDir))
                            {
                                System.IO.Directory.CreateDirectory(baseDir);
                            }

                            // Create a subfolder per command for organization (optional)
                            string commandName = (this.MyInvocation?.InvocationName ?? "az_compute").ToLower().Replace('-', '_');
                            string commandDir = System.IO.Path.Combine(baseDir, commandName);
                            if (!System.IO.Directory.Exists(commandDir))
                            {
                                System.IO.Directory.CreateDirectory(commandDir);
                            }

                            string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
                            var savedPaths = new List<string>();

                            if (!string.IsNullOrWhiteSpace(mainTemplateContent))
                            {
                                string mainFileName = $"{commandName}_main_{timestamp}.bicep";
                                string mainPath = System.IO.Path.Combine(commandDir, mainFileName);
                                System.IO.File.WriteAllText(mainPath, mainTemplateContent, Encoding.UTF8);
                                savedPaths.Add(mainPath);
                            }

                            if (moduleTemplatesToken != null)
                            {
                                // Handle object or array forms
                                if (moduleTemplatesToken.Type == JTokenType.Object)
                                {
                                    int index = 1;
                                    foreach (var prop in ((JObject)moduleTemplatesToken).Properties())
                                    {
                                        string content = prop.Value.Value<string>();
                                        if (string.IsNullOrWhiteSpace(content)) continue;
                                        string moduleFileName = $"{commandName}_module{(index == 1 ? string.Empty : index.ToString())}_{timestamp}.bicep";
                                        string modulePath = System.IO.Path.Combine(commandDir, moduleFileName);
                                        System.IO.File.WriteAllText(modulePath, content, Encoding.UTF8);
                                        savedPaths.Add(modulePath);
                                        index++;
                                    }
                                }
                                else if (moduleTemplatesToken.Type == JTokenType.Array)
                                {
                                    int index = 1;
                                    foreach (var item in (JArray)moduleTemplatesToken)
                                    {
                                        string content = item?.Value<string>();
                                        if (string.IsNullOrWhiteSpace(content)) continue;
                                        string moduleFileName = $"{commandName}_module{(index == 1 ? string.Empty : index.ToString())}_{timestamp}.bicep";
                                        string modulePath = System.IO.Path.Combine(commandDir, moduleFileName);
                                        System.IO.File.WriteAllText(modulePath, content, Encoding.UTF8);
                                        savedPaths.Add(modulePath);
                                        index++;
                                    }
                                }
                            }

                            if (savedPaths.Count > 0)
                            {
                                WriteInformation("Bicep templates saved to:", new[] { "PSHOST" });
                                foreach (var p in savedPaths)
                                {
                                    WriteInformation(p, new[] { "PSHOST" });
                                }
                            }
                            else
                            {
                                WriteWarning("No Bicep templates were exported (empty content).");
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteWarning($"Failed to export Bicep templates: {ex.Message}");
                        }
                    }
                    else
                    {
                        WriteWarning("No bicep_template content found in DryRun response");
                    }
                }

                if (dryRunResult != null)
                {
                    try
                    {
                        var whatIfResult = TryAdaptDryRunToWhatIf(dryRunResult);
                        if (whatIfResult != null)
                        {
                            WriteVerbose("========== DryRun Response (Formatted) ==========");
                            string formattedOutput = WhatIfOperationResultFormatter.Format(
                                whatIfResult,
                                noiseNotice: "Note: DryRun preview - actual deployment behavior may differ.");
                            WriteObject(formattedOutput);
                            WriteVerbose("=================================================");
                        }
                        else
                        {
                            WriteVerbose("========== DryRun Response ==========");
                            string formattedJson = JsonConvert.SerializeObject(dryRunResult, Formatting.Indented);
                            WriteObject(formattedJson);
                            WriteVerbose("=====================================");
                        }
                    }
                    catch (Exception formatEx)
                    {
                        WriteVerbose($"DryRun formatting failed: {formatEx.Message}");
                        WriteVerbose("========== DryRun Response ==========");
                        try
                        {
                            string formattedJson = JsonConvert.SerializeObject(dryRunResult, Formatting.Indented);
                            WriteObject(formattedJson);
                        }
                        catch
                        {
                            WriteObject(dryRunResult);
                        }
                        WriteVerbose("=====================================");
                    }
                }
                else
                {
                    WriteWarning("DryRun request completed but no response data was returned.");
                }
            }
            catch (Exception ex)
            {
                WriteWarning($"DryRun error: {ex.Message}");
            }
            return true; // Always prevent normal execution when -DryRun is used
        }

        /// <summary>
        /// Attempts to adapt the DryRun JSON response to IWhatIfOperationResult for formatting.
        /// Returns null if the response doesn't match expected structure.
        /// </summary>
        private IWhatIfOperationResult TryAdaptDryRunToWhatIf(object dryRunResult)
        {
            try
            {
                // Try to parse as JObject
                JObject jObj = null;
                if (dryRunResult is JToken jToken)
                {
                    jObj = jToken as JObject;
                }
                else if (dryRunResult is string strResult)
                {
                    jObj = JObject.Parse(strResult);
                }

                if (jObj == null)
                {
                    return null;
                }

                // Check if the response has a 'what_if_result' wrapper
                JObject whatIfData = jObj;
                if (jObj["what_if_result"] != null)
                {
                    // Extract the nested what_if_result object
                    whatIfData = jObj["what_if_result"] as JObject;
                    if (whatIfData == null)
                    {
                        return null;
                    }
                }

                // Check if it has a 'changes' or 'resourceChanges' field
                var changesToken = whatIfData["changes"] ?? whatIfData["resourceChanges"];
                if (changesToken == null)
                {
                    return null;
                }

                return new DryRunWhatIfResult(whatIfData);
            }
            catch (Exception ex)
            {
                WriteVerbose($"Failed to adapt DryRun result to WhatIf format: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Posts DryRun payload and returns parsed JSON response or raw string.
        /// Mirrors Python test_what_if_ps_preview() behavior.
        /// </summary>
        private object PostDryRun(string endpoint, string bearerToken, object payload)
        {
            string json = JsonConvert.SerializeObject(payload);
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                
                // Add Accept header and correlation id like Python script
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string correlationId = Guid.NewGuid().ToString();
                request.Headers.Add("x-ms-client-request-id", correlationId);
                
                if (!string.IsNullOrWhiteSpace(bearerToken))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                }
                
                WriteVerbose($"DryRun POST -> {endpoint}");
                WriteVerbose($"DryRun correlation-id: {correlationId}");
                WriteVerbose($"DryRun Payload: {Truncate(json, 1024)}");
                
                try
                {
                    var response = _dryRunHttpClient.SendAsync(request).GetAwaiter().GetResult();
                    string respBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    
                    WriteVerbose($"DryRun HTTP Status: {(int)response.StatusCode} {response.ReasonPhrase}");
                    
                    if (response.IsSuccessStatusCode)
                    {
                        WriteVerbose("DryRun post succeeded.");
                        WriteVerbose($"DryRun response body: {Truncate(respBody, 2048)}");
                        
                        // Parse JSON and return as object (similar to Python result = response.json())
                        try
                        {
                            var jToken = !string.IsNullOrWhiteSpace(respBody) ? JToken.Parse(respBody) : null;
                            if (jToken != null)
                            {
                                // Enrich with correlation and status
                                if (jToken.Type == JTokenType.Object)
                                {
                                    ((JObject)jToken)["_correlation_id"] = correlationId;
                                    ((JObject)jToken)["_http_status"] = (int)response.StatusCode;
                                    ((JObject)jToken)["_success"] = true;
                                }
                                return jToken.ToObject<object>();
                            }
                        }
                        catch (Exception parseEx)
                        {
                            WriteVerbose($"DryRun response parse failed: {parseEx.Message}");
                        }
                        return respBody;
                    }
                    else
                    {
                        // HTTP error response - display detailed error information
                        WriteWarning($"DryRun API returned error: {(int)response.StatusCode} {response.ReasonPhrase}");
                        
                        // Create error response object with all details
                        var errorResponse = new
                        {
                            _success = false,
                            _http_status = (int)response.StatusCode,
                            _status_description = response.ReasonPhrase,
                            _correlation_id = correlationId,
                            _endpoint = endpoint,
                            error_message = respBody,
                            timestamp = DateTime.UtcNow.ToString("o")
                        };
                        
                        // Try to parse error as JSON if possible
                        try
                        {
                            var errorJson = JToken.Parse(respBody);
                            WriteError(new ErrorRecord(
                                new Exception($"DryRun API Error: {response.StatusCode} - {respBody}"),
                                "DryRunApiError",
                                ErrorCategory.InvalidOperation,
                                endpoint));
                            
                            // Return enriched error object
                            if (errorJson.Type == JTokenType.Object)
                            {
                                ((JObject)errorJson)["_correlation_id"] = correlationId;
                                ((JObject)errorJson)["_http_status"] = (int)response.StatusCode;
                                ((JObject)errorJson)["_success"] = false;
                                return errorJson.ToObject<object>();
                            }
                        }
                        catch
                        {
                            // Error body is not JSON, return as plain error object
                            WriteError(new ErrorRecord(
                                new Exception($"DryRun API Error: {response.StatusCode} - {respBody}"),
                                "DryRunApiError",
                                ErrorCategory.InvalidOperation,
                                endpoint));
                        }
                        
                        WriteVerbose($"DryRun error response body: {Truncate(respBody, 2048)}");
                        return errorResponse;
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    // Network or connection error
                    WriteError(new ErrorRecord(
                        new Exception($"DryRun network error: {httpEx.Message}", httpEx),
                        "DryRunNetworkError",
                        ErrorCategory.ConnectionError,
                        endpoint));
                    
                    return new
                    {
                        _success = false,
                        _correlation_id = correlationId,
                        _endpoint = endpoint,
                        error_type = "NetworkError",
                        error_message = httpEx.Message,
                        stack_trace = httpEx.StackTrace,
                        timestamp = DateTime.UtcNow.ToString("o")
                    };
                }
                catch (TaskCanceledException timeoutEx)
                {
                    // Timeout error
                    WriteError(new ErrorRecord(
                        new Exception($"DryRun request timeout: {timeoutEx.Message}", timeoutEx),
                        "DryRunTimeout",
                        ErrorCategory.OperationTimeout,
                        endpoint));
                    
                    return new
                    {
                        _success = false,
                        _correlation_id = correlationId,
                        _endpoint = endpoint,
                        error_type = "Timeout",
                        error_message = "Request timed out",
                        timestamp = DateTime.UtcNow.ToString("o")
                    };
                }
                catch (Exception sendEx)
                {
                    // Generic error
                    WriteError(new ErrorRecord(
                        new Exception($"DryRun request failed: {sendEx.Message}", sendEx),
                        "DryRunRequestError",
                        ErrorCategory.NotSpecified,
                        endpoint));
                    
                    return new
                    {
                        _success = false,
                        _correlation_id = correlationId,
                        _endpoint = endpoint,
                        error_type = sendEx.GetType().Name,
                        error_message = sendEx.Message,
                        stack_trace = sendEx.StackTrace,
                        timestamp = DateTime.UtcNow.ToString("o")
                    };
                }
            }
        }

        private static string Truncate(string value, int max)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= max)
            {
                return value;
            }
            return value.Substring(0, max) + "...(truncated)";
        }

        /// <summary>
        /// Uses Azure Identity's DefaultAzureCredential to acquire a bearer token. Scope can be overridden using
        /// AZURE_POWERSHELL_DRYRUN_SCOPE; otherwise defaults to the Resource Manager endpoint + "/.default".
        /// Returns null if acquisition fails (request will be sent without Authorization header).
        /// </summary>
        private string GetDryRunAuthToken()
        {
            try
            {
                string overrideScope = Environment.GetEnvironmentVariable("AZURE_POWERSHELL_DRYRUN_SCOPE");
                string scope;
                if (!string.IsNullOrWhiteSpace(overrideScope))
                {
                    scope = overrideScope.Trim();
                }
                else
                {
                    // Default to management endpoint (e.g., https://management.azure.com/.default)
                    var rmEndpoint = this.DefaultContext?.Environment?.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager) ?? AzureEnvironment.PublicEnvironments["AzureCloud"].GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);
                    scope = rmEndpoint.TrimEnd('/') + "/.default";
                }

                var credential = new DefaultAzureCredential();
                var token = credential.GetToken(new TokenRequestContext(new[] { scope }));
                return token.Token;
            }
            catch (Exception ex)
            {
                WriteVerbose($"DryRun token acquisition failed: {ex.Message}");
                return null;
            }
        }

        protected void ExecuteClientAction(Action action)
        {
            try
            {
                action();
            }
            catch (Rest.Azure.CloudException ex)
            {
                try
                {
                    base.EndProcessing();
                }
                catch
                {
                    // Ignore exceptions during end processing
                }

                throw new ComputeCloudException(ex);
            }
        }

        protected void ThrowInvalidArgumentError(string errorMessage, string arg)
        {
            ThrowTerminatingError
                (new ErrorRecord(
                    new ArgumentException(string.Format(CultureInfo.InvariantCulture,
                        errorMessage, arg)),
                    "InvalidArgument",
                    ErrorCategory.InvalidArgument,
                    null));
        }

        protected string GetDiskNameFromId(string Id)
        {
            return Id.Substring(Id.LastIndexOf('/') + 1);
        }

        public static string GetOperationIdFromUrlString(string Url)
        {
            Regex r = new Regex(@"(.*?)operations/(?<id>[a-f0-9]{8}[-]([a-f0-9]{4}[-]){3}[a-f0-9]{12})", RegexOptions.IgnoreCase);
            Match m = r.Match(Url);
            return m.Success ? m.Groups["id"].Value : null;
        }

        public static ManagedDiskParameters SetManagedDisk(string managedDiskId, string diskEncryptionSetId, string storageAccountType, ManagedDiskParameters managedDisk = null)
        {
            if (string.IsNullOrWhiteSpace(managedDiskId) && string.IsNullOrWhiteSpace(diskEncryptionSetId) && string.IsNullOrWhiteSpace(storageAccountType))
            {
                return managedDisk;
            }

            managedDisk = new ManagedDiskParameters();

            if (!string.IsNullOrWhiteSpace(managedDiskId))
            {
                managedDisk.Id = managedDiskId;
            }

            if (!string.IsNullOrWhiteSpace(diskEncryptionSetId))
            {
                managedDisk.DiskEncryptionSet = new DiskEncryptionSetParameters(diskEncryptionSetId);
            }

            if (!string.IsNullOrWhiteSpace(storageAccountType))
            {
                managedDisk.StorageAccountType = storageAccountType;
            }

            return managedDisk;
        }

        private ResourceManagementClient _armClient;

        public ResourceManagementClient ArmClient
        {
            get
            {
                return this._armClient ??
                       (this._armClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                           context: this.DefaultContext,
                           endpoint: AzureEnvironment.Endpoint.ResourceManager));
            }
            set
            {
                this._armClient = value;
            }
        }

        #region DryRun WhatIf Adapter Classes

        /// <summary>
        /// Adapter class to convert DryRun JSON response to IWhatIfOperationResult interface
        /// </summary>
        private class DryRunWhatIfResult : IWhatIfOperationResult
        {
            private readonly JObject _response;
            private readonly Lazy<IList<IWhatIfChange>> _changes;
            private readonly Lazy<IList<IWhatIfChange>> _potentialChanges;
            private readonly Lazy<IList<IWhatIfDiagnostic>> _diagnostics;
            private readonly Lazy<IWhatIfError> _error;

            public DryRunWhatIfResult(JObject response)
            {
                _response = response;
                _changes = new Lazy<IList<IWhatIfChange>>(() => ParseChanges(_response["changes"] ?? _response["resourceChanges"]));
                _potentialChanges = new Lazy<IList<IWhatIfChange>>(() => ParseChanges(_response["potentialChanges"]));
                _diagnostics = new Lazy<IList<IWhatIfDiagnostic>>(() => ParseDiagnostics(_response["diagnostics"]));
                _error = new Lazy<IWhatIfError>(() => ParseError(_response["error"]));
            }

            public string Status => _response["status"]?.Value<string>() ?? "Succeeded";
            public IList<IWhatIfChange> Changes => _changes.Value;
            public IList<IWhatIfChange> PotentialChanges => _potentialChanges.Value;
            public IList<IWhatIfDiagnostic> Diagnostics => _diagnostics.Value;
            public IWhatIfError Error => _error.Value;

            private static IList<IWhatIfChange> ParseChanges(JToken changesToken)
            {
                if (changesToken == null || changesToken.Type != JTokenType.Array)
                {
                    return new List<IWhatIfChange>();
                }

                return changesToken
                    .Select(c => (IWhatIfChange)new DryRunWhatIfChange(c as JObject))
                    .ToList();
            }

            private static IList<IWhatIfDiagnostic> ParseDiagnostics(JToken diagnosticsToken)
            {
                if (diagnosticsToken == null || diagnosticsToken.Type != JTokenType.Array)
                {
                    return new List<IWhatIfDiagnostic>();
                }

                return diagnosticsToken
                    .Select(d => (IWhatIfDiagnostic)new DryRunWhatIfDiagnostic(d as JObject))
                    .ToList();
            }

            private static IWhatIfError ParseError(JToken errorToken)
            {
                if (errorToken == null)
                {
                    return null;
                }

                return new DryRunWhatIfError(errorToken as JObject);
            }
        }

        /// <summary>
        /// Adapter for individual resource change
        /// </summary>
        private class DryRunWhatIfChange : IWhatIfChange
        {
            private readonly JObject _change;
            private readonly Lazy<IList<IWhatIfPropertyChange>> _delta;

            public DryRunWhatIfChange(JObject change)
            {
                _change = change;
                
                // Parse resourceId into scope and relative path
                string resourceId = _change["resourceId"]?.Value<string>() ?? string.Empty;
                var parts = SplitResourceId(resourceId);
                Scope = parts.scope;
                RelativeResourceId = parts.relativeId;
                
                _delta = new Lazy<IList<IWhatIfPropertyChange>>(() => ParsePropertyChanges(_change["delta"] ?? _change["propertyChanges"]));
            }

            public string Scope { get; }
            public string RelativeResourceId { get; }
            public string UnsupportedReason => _change["unsupportedReason"]?.Value<string>();
            public string FullyQualifiedResourceId => _change["resourceId"]?.Value<string>() ?? $"{Scope}/{RelativeResourceId}";
            
            public ChangeType ChangeType
            {
                get
                {
                    string changeTypeStr = _change["changeType"]?.Value<string>() ?? "NoChange";
                    return ParseChangeType(changeTypeStr);
                }
            }

            public string ApiVersion => _change["apiVersion"]?.Value<string>() ?? 
                                       Before?["apiVersion"]?.Value<string>() ?? 
                                       After?["apiVersion"]?.Value<string>();
            
            public JToken Before => _change["before"];
            public JToken After => _change["after"];
            public IList<IWhatIfPropertyChange> Delta => _delta.Value;

            private static (string scope, string relativeId) SplitResourceId(string resourceId)
            {
                if (string.IsNullOrEmpty(resourceId))
                {
                    return (string.Empty, string.Empty);
                }

                // Find last occurrence of /providers/
                int providersIndex = resourceId.LastIndexOf("/providers/", StringComparison.OrdinalIgnoreCase);
                if (providersIndex > 0)
                {
                    string scope = resourceId.Substring(0, providersIndex);
                    string relativeId = resourceId.Substring(providersIndex + 1); // Skip the leading '/'
                    return (scope, relativeId);
                }

                // If no providers found, treat entire path as relative
                return (string.Empty, resourceId);
            }

            private static ChangeType ParseChangeType(string changeTypeStr)
            {
                if (Enum.TryParse<ChangeType>(changeTypeStr, true, out var changeType))
                {
                    return changeType;
                }
                return ChangeType.NoChange;
            }

            private static IList<IWhatIfPropertyChange> ParsePropertyChanges(JToken deltaToken)
            {
                if (deltaToken == null || deltaToken.Type != JTokenType.Array)
                {
                    return new List<IWhatIfPropertyChange>();
                }

                return deltaToken
                    .Select(pc => (IWhatIfPropertyChange)new DryRunWhatIfPropertyChange(pc as JObject))
                    .ToList();
            }
        }

        /// <summary>
        /// Adapter for property changes
        /// </summary>
        private class DryRunWhatIfPropertyChange : IWhatIfPropertyChange
        {
            private readonly JObject _propertyChange;
            private readonly Lazy<IList<IWhatIfPropertyChange>> _children;

            public DryRunWhatIfPropertyChange(JObject propertyChange)
            {
                _propertyChange = propertyChange;
                _children = new Lazy<IList<IWhatIfPropertyChange>>(() => ParseChildren(_propertyChange["children"]));
            }

            public string Path => _propertyChange["path"]?.Value<string>() ?? string.Empty;
            
            public PropertyChangeType PropertyChangeType
            {
                get
                {
                    string typeStr = _propertyChange["propertyChangeType"]?.Value<string>() ?? 
                                    _propertyChange["changeType"]?.Value<string>() ?? 
                                    "NoEffect";
                    if (Enum.TryParse<PropertyChangeType>(typeStr, true, out var propChangeType))
                    {
                        return propChangeType;
                    }
                    return PropertyChangeType.NoEffect;
                }
            }

            public JToken Before => _propertyChange["before"];
            public JToken After => _propertyChange["after"];
            public IList<IWhatIfPropertyChange> Children => _children.Value;

            private static IList<IWhatIfPropertyChange> ParseChildren(JToken childrenToken)
            {
                if (childrenToken == null || childrenToken.Type != JTokenType.Array)
                {
                    return new List<IWhatIfPropertyChange>();
                }

                return childrenToken
                    .Select(c => (IWhatIfPropertyChange)new DryRunWhatIfPropertyChange(c as JObject))
                    .ToList();
            }
        }

        /// <summary>
        /// Adapter for diagnostics
        /// </summary>
        private class DryRunWhatIfDiagnostic : IWhatIfDiagnostic
        {
            private readonly JObject _diagnostic;

            public DryRunWhatIfDiagnostic(JObject diagnostic)
            {
                _diagnostic = diagnostic;
            }

            public string Code => _diagnostic["code"]?.Value<string>() ?? string.Empty;
            public string Message => _diagnostic["message"]?.Value<string>() ?? string.Empty;
            public string Level => _diagnostic["level"]?.Value<string>() ?? "Info";
            public string Target => _diagnostic["target"]?.Value<string>() ?? string.Empty;
            public string Details => _diagnostic["details"]?.Value<string>() ?? string.Empty;
        }

        /// <summary>
        /// Adapter for errors
        /// </summary>
        private class DryRunWhatIfError : IWhatIfError
        {
            private readonly JObject _error;

            public DryRunWhatIfError(JObject error)
            {
                _error = error;
            }

            public string Code => _error["code"]?.Value<string>() ?? string.Empty;
            public string Message => _error["message"]?.Value<string>() ?? string.Empty;
            public string Target => _error["target"]?.Value<string>() ?? string.Empty;
        }

        #endregion
    }
}

