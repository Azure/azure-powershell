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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Net;
using System;
using System.Management.Automation;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class VirtualNetworkBaseCmdlet : NetworkBaseCmdlet
    {
        // DryRun parameters (modeled after ComputeClientBaseCmdlet)
        [Parameter(Mandatory = false, HelpMessage = "Send the invoked PowerShell command (ps_script) and subscription id to a remote endpoint without executing the real operation.")] 
        public SwitchParameter DryRun { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "When used together with -DryRun, export generated Bicep templates to the user's .azure\\whatif directory.")] 
        public SwitchParameter ExportBicep { get; set; }

        private static readonly HttpClient _dryRunHttpClient = CreateDryRunHttpClient();

        private static HttpClient CreateDryRunHttpClient()
        {
            int timeoutSeconds = 300; // default 5 minutes
            string timeoutEnv = Environment.GetEnvironmentVariable("AZURE_POWERSHELL_DRYRUN_TIMEOUT_SECONDS");
            if (!string.IsNullOrWhiteSpace(timeoutEnv) && int.TryParse(timeoutEnv, out int customTimeout) && customTimeout > 0)
            {
                timeoutSeconds = customTimeout;
            }
            return new HttpClient { Timeout = TimeSpan.FromSeconds(timeoutSeconds) };
        }

        public IVirtualNetworksOperations VirtualNetworkClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualNetworks;
            }
        }

        public override void ExecuteCmdlet()
        {
            // Validate ExportBicep usage
            if (ExportBicep.IsPresent && !DryRun.IsPresent)
            {
                ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException("-ExportBicep must be used together with -DryRun"),
                    "ExportBicepRequiresDryRun",
                    ErrorCategory.InvalidArgument,
                    null));
            }

            base.ExecuteCmdlet();
        }

        protected virtual bool TryHandleDryRun(string prePsInvocationScript = null)
        {
            try
            {
                string invocationLine = this.MyInvocation?.Line ?? this.MyInvocation?.InvocationName ?? string.Empty;
                string psScript = string.IsNullOrWhiteSpace(prePsInvocationScript) ? invocationLine : prePsInvocationScript + "\n" + invocationLine;
                string subscriptionId = this.DefaultContext?.Subscription?.Id ?? DefaultProfile.DefaultContext?.Subscription?.Id ?? string.Empty;
                bool exportBicep = ExportBicep.IsPresent;

                var payload = new
                {
                    ps_script = psScript,
                    subscription_id = subscriptionId,
                    timestamp_utc = DateTime.UtcNow.ToString("o"),
                    source = "Az.Network.DryRun",
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
                    if (dryRunResult is JToken jt) resultToken = jt;
                    else if (dryRunResult is string s && !string.IsNullOrWhiteSpace(s)) resultToken = JToken.Parse(s);
                    else if (dryRunResult != null) resultToken = JToken.FromObject(dryRunResult);
                }
                catch { }

                if (exportBicep && resultToken != null)
                {
                    ExportBicepTemplates(resultToken);
                }

                if (dryRunResult != null)
                {
                    var whatIfResult = TryAdaptDryRunToWhatIf(dryRunResult);
                    if (whatIfResult != null)
                    {
                        try
                        {
                            WriteVerbose("========== DryRun WhatIf (Formatted) ==========");
                            string formatted = WhatIfOperationResultFormatter.Format(whatIfResult, noiseNotice: "Note: DryRun preview - actual execution skipped.");
                            WriteObject(formatted);
                            WriteVerbose("===============================================");
                        }
                        catch (Exception formatEx)
                        {
                            WriteVerbose($"WhatIf formatting failed: {formatEx.Message}");
                            string formattedJson = JsonConvert.SerializeObject(dryRunResult, Formatting.Indented);
                            WriteObject(formattedJson);
                        }
                    }
                    else
                    {
                        WriteVerbose("========== DryRun Response (Raw JSON) ==========");
                        string formattedJson = JsonConvert.SerializeObject(dryRunResult, Formatting.Indented);
                        WriteObject(formattedJson);
                        WriteVerbose("===============================================");
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

        private void ExportBicepTemplates(JToken resultToken)
        {
            var bicepRoot = resultToken.SelectToken("bicep_template");
            var mainTemplateContent = bicepRoot?.SelectToken("main_template")?.Value<string>();
            var moduleTemplatesToken = bicepRoot?.SelectToken("module_templates");

            if (string.IsNullOrWhiteSpace(mainTemplateContent) && moduleTemplatesToken == null)
            {
                WriteWarning("No bicep_template content found in DryRun response");
                return;
            }

            try
            {
                string baseDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".azure", "whatif");
                if (!System.IO.Directory.Exists(baseDir)) System.IO.Directory.CreateDirectory(baseDir);

                string commandName = (this.MyInvocation?.InvocationName ?? "az_network").ToLower().Replace('-', '_');
                string commandDir = System.IO.Path.Combine(baseDir, commandName);
                if (!System.IO.Directory.Exists(commandDir)) System.IO.Directory.CreateDirectory(commandDir);
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
                    foreach (var p in savedPaths) WriteInformation(p, new[] { "PSHOST" });
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

        private object PostDryRun(string endpoint, string bearerToken, object payload)
        {
            string json = JsonConvert.SerializeObject(payload);
            using (var request = new HttpRequestMessage(System.Net.Http.HttpMethod.Post, endpoint))
            {
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string correlationId = Guid.NewGuid().ToString();
                request.Headers.Add("x-ms-client-request-id", correlationId);
                if (!string.IsNullOrWhiteSpace(bearerToken)) request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

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
                        try
                        {
                            var jToken = !string.IsNullOrWhiteSpace(respBody) ? JToken.Parse(respBody) : null;
                            if (jToken != null && jToken.Type == JTokenType.Object)
                            {
                                ((JObject)jToken)["_correlation_id"] = correlationId;
                                ((JObject)jToken)["_http_status"] = (int)response.StatusCode;
                                ((JObject)jToken)["_success"] = true;
                                return jToken.ToObject<object>();
                            }
                            return jToken ?? (object)respBody;
                        }
                        catch (Exception parseEx)
                        {
                            WriteVerbose($"DryRun response parse failed: {parseEx.Message}");
                            return respBody;
                        }
                    }
                    else
                    {
                        WriteWarning($"DryRun API returned error: {(int)response.StatusCode} {response.ReasonPhrase}");
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
                        try
                        {
                            var errorJson = JToken.Parse(respBody);
                            WriteError(new ErrorRecord(new Exception($"DryRun API Error: {response.StatusCode} - {respBody}"), "DryRunApiError", ErrorCategory.InvalidOperation, endpoint));
                            if (errorJson.Type == JTokenType.Object)
                            {
                                ((JObject)errorJson)["_correlation_id"] = correlationId;
                                ((JObject)errorJson)["_http_status"] = (int)response.StatusCode;
                                ((JObject)errorJson)["_success"] = false;
                                return errorJson.ToObject<object>();
                            }
                        }
                        catch { }
                        WriteVerbose($"DryRun error response body: {Truncate(respBody, 2048)}");
                        return errorResponse;
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    WriteError(new ErrorRecord(new Exception($"DryRun network error: {httpEx.Message}", httpEx), "DryRunNetworkError", ErrorCategory.ConnectionError, endpoint));
                    return new { _success = false, _endpoint = endpoint, error_type = "NetworkError", error_message = httpEx.Message, timestamp = DateTime.UtcNow.ToString("o") };
                }
                catch (TimeoutException timeoutEx)
                {
                    WriteError(new ErrorRecord(new Exception($"DryRun request timeout: {timeoutEx.Message}", timeoutEx), "DryRunTimeout", ErrorCategory.OperationTimeout, endpoint));
                    return new { _success = false, _endpoint = endpoint, error_type = "Timeout", error_message = "Request timed out", timestamp = DateTime.UtcNow.ToString("o") };
                }
                catch (Exception sendEx)
                {
                    WriteError(new ErrorRecord(new Exception($"DryRun request failed: {sendEx.Message}", sendEx), "DryRunRequestError", ErrorCategory.NotSpecified, endpoint));
                    return new { _success = false, _endpoint = endpoint, error_type = sendEx.GetType().Name, error_message = sendEx.Message, timestamp = DateTime.UtcNow.ToString("o") };
                }
            }
        }

        private static string Truncate(string value, int max)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= max) return value;
            return value.Substring(0, max) + "...(truncated)";
        }

        // Token acquisition using existing authentication factory (no Azure.Identity dependency)
        private string GetDryRunAuthToken()
        {
            try
            {
                var context = this.DefaultContext ?? DefaultProfile.DefaultContext;
                if (context?.Account == null || context.Environment == null) return null;
                string scope = context.Environment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);
                var accessToken = AzureSession.Instance.AuthenticationFactory.Authenticate(
                    context.Account,
                    context.Environment,
                    context.Tenant?.Id,
                    null,
                    ShowDialog.Never,
                    null,
                    scope);
                return accessToken?.AccessToken;
            }
            catch (Exception ex)
            {
                WriteVerbose($"DryRun token acquisition failed: {ex.Message}");
                return null;
            }
        }

        private IWhatIfOperationResult TryAdaptDryRunToWhatIf(object dryRunResult)
        {
            try
            {
                JObject root = null;
                if (dryRunResult is JToken jt) root = jt as JObject; else if (dryRunResult is string s) root = JObject.Parse(s); else root = JObject.FromObject(dryRunResult);
                if (root == null) return null;
                var whatIfObj = root["what_if_result"] as JObject ?? root;
                if (whatIfObj["changes"] == null && whatIfObj["resourceChanges"] == null) return null;
                return new DryRunWhatIfResult(whatIfObj);
            }
            catch (Exception ex)
            {
                WriteVerbose($"Adapt WhatIf failed: {ex.Message}");
                return null;
            }
        }

        // WhatIf adapter classes
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
            private static IList<IWhatIfChange> ParseChanges(JToken token)
            {
                if (token == null || token.Type != JTokenType.Array) return new List<IWhatIfChange>();
                return token.Select(c => c is JObject o ? (IWhatIfChange)new DryRunWhatIfChange(o) : null).Where(x => x != null).ToList();
            }
            private static IList<IWhatIfDiagnostic> ParseDiagnostics(JToken token)
            {
                if (token == null || token.Type != JTokenType.Array) return new List<IWhatIfDiagnostic>();
                return token.Select(d => d is JObject o ? (IWhatIfDiagnostic)new DryRunWhatIfDiagnostic(o) : null).Where(x => x != null).ToList();
            }
            private static IWhatIfError ParseError(JToken token)
            {
                if (token == null || token.Type != JTokenType.Object) return null;
                return new DryRunWhatIfError((JObject)token);
            }
        }
        private class DryRunWhatIfChange : IWhatIfChange
        {
            private readonly JObject _change;
            private readonly Lazy<IList<IWhatIfPropertyChange>> _delta;
            public DryRunWhatIfChange(JObject change)
            {
                _change = change;
                _delta = new Lazy<IList<IWhatIfPropertyChange>>(() => ParsePropertyChanges(_change["delta"] ?? _change["propertyChanges"]));
            }
            public string Scope { get { var id = _change["resourceId"]?.Value<string>() ?? string.Empty; int idx = id.LastIndexOf("/providers/"); return idx > 0 ? id.Substring(0, idx) : string.Empty; } }
            public string RelativeResourceId { get { var id = _change["resourceId"]?.Value<string>() ?? string.Empty; int idx = id.LastIndexOf("/providers/"); return idx > 0 ? id.Substring(idx + 1) : id; } }
            public string UnsupportedReason => _change["unsupportedReason"]?.Value<string>();
            public string FullyQualifiedResourceId => _change["resourceId"]?.Value<string>() ?? string.Empty;
            public ChangeType ChangeType { get { var s = _change["changeType"]?.Value<string>() ?? "NoChange"; if (Enum.TryParse<ChangeType>(s, true, out var ct)) return ct; return ChangeType.NoChange; } }
            public string ApiVersion => _change["apiVersion"]?.Value<string>() ?? _change["after"]?["apiVersion"]?.Value<string>() ?? _change["before"]?["apiVersion"]?.Value<string>();
            public JToken Before => _change["before"];
            public JToken After => _change["after"];
            public IList<IWhatIfPropertyChange> Delta => _delta.Value;
            private static IList<IWhatIfPropertyChange> ParsePropertyChanges(JToken token)
            {
                if (token == null || token.Type != JTokenType.Array) return new List<IWhatIfPropertyChange>();
                return token.Select(c => c is JObject o ? (IWhatIfPropertyChange)new DryRunWhatIfPropertyChange(o) : null).Where(x => x != null).ToList();
            }
        }
        private class DryRunWhatIfPropertyChange : IWhatIfPropertyChange
        {
            private readonly JObject _prop;
            private readonly Lazy<IList<IWhatIfPropertyChange>> _children;
            public DryRunWhatIfPropertyChange(JObject prop)
            {
                _prop = prop;
                _children = new Lazy<IList<IWhatIfPropertyChange>>(() => ParseChildren(_prop["children"]));
            }
            public string Path => _prop["path"]?.Value<string>() ?? string.Empty;
            public PropertyChangeType PropertyChangeType { get { var s = _prop["propertyChangeType"]?.Value<string>() ?? _prop["changeType"]?.Value<string>() ?? "NoEffect"; if (Enum.TryParse<PropertyChangeType>(s, true, out var pct)) return pct; return PropertyChangeType.NoEffect; } }
            public JToken Before => _prop["before"];
            public JToken After => _prop["after"];
            public IList<IWhatIfPropertyChange> Children => _children.Value;
            private static IList<IWhatIfPropertyChange> ParseChildren(JToken token)
            {
                if (token == null || token.Type != JTokenType.Array) return new List<IWhatIfPropertyChange>();
                return token.Select(c => c is JObject o ? (IWhatIfPropertyChange)new DryRunWhatIfPropertyChange(o) : null).Where(x => x != null).ToList();
            }
        }
        private class DryRunWhatIfDiagnostic : IWhatIfDiagnostic
        {
            private readonly JObject _diag;
            public DryRunWhatIfDiagnostic(JObject d) { _diag = d; }
            public string Code => _diag["code"]?.Value<string>() ?? string.Empty;
            public string Message => _diag["message"]?.Value<string>() ?? string.Empty;
            public string Level => _diag["level"]?.Value<string>() ?? "Info";
            public string Target => _diag["target"]?.Value<string>() ?? string.Empty;
            public string Details => _diag["details"]?.Value<string>() ?? string.Empty;
        }
        private class DryRunWhatIfError : IWhatIfError
        {
            private readonly JObject _err;
            public DryRunWhatIfError(JObject e) { _err = e; }
            public string Code => _err["code"]?.Value<string>() ?? string.Empty;
            public string Message => _err["message"]?.Value<string>() ?? string.Empty;
            public string Target => _err["target"]?.Value<string>() ?? string.Empty;
        }

        // Existing functionality retained below
        public bool IsVirtualNetworkPresent(string resourceGroupName, string name)
        {
            try
            {
                GetVirtualNetwork(resourceGroupName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                throw;
            }
            return true;
        }

        public PSVirtualNetwork GetVirtualNetwork(string resourceGroupName, string name, string expandResource = null)
        {
            var vnet = this.VirtualNetworkClient.Get(resourceGroupName, name, expandResource);
            var psVirtualNetwork = NetworkResourceManagerProfile.Mapper.Map<PSVirtualNetwork>(vnet);
            psVirtualNetwork.ResourceGroupName = resourceGroupName;
            psVirtualNetwork.Tag = TagsConversionHelper.CreateTagHashtable(vnet.Tags);
            if (psVirtualNetwork.DhcpOptions == null)
            {
                psVirtualNetwork.DhcpOptions = new PSDhcpOptions();
            }
            return psVirtualNetwork;
        }

        public PSVirtualNetwork ToPsVirtualNetwork(Microsoft.Azure.Management.Network.Models.VirtualNetwork vnet)
        {
            var psVnet = NetworkResourceManagerProfile.Mapper.Map<PSVirtualNetwork>(vnet);
            psVnet.Tag = TagsConversionHelper.CreateTagHashtable(vnet.Tags);
            return psVnet;
        }
    }
}