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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using StorageModels = Microsoft.Azure.Management.Storage.Models;
using System.Management.Automation;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
// Attempt to use shared WhatIf formatter & models (may not be available if project not referenced)
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    public abstract class StorageAccountBaseCmdlet : AzureRMCmdlet
    {
        private StorageManagementClientWrapper storageClientWrapper;

        protected const string StorageAccountNounStr = "StorageAccount";
        protected const string StorageAccountKeyNounStr = StorageAccountNounStr + "Key";
        protected const string StorageAccountRuleNounStr = StorageAccountNounStr + "NetworkRule";
        protected const string StorageAccountRuleSetNounStr = StorageAccountRuleNounStr + "Set";
        protected const string StorageAccountFailoverNounStr = StorageAccountNounStr + "Failover";
        protected const string StorageAccountHierarchicalNamespaceUpgradeNounStr = StorageAccountNounStr + "HierarchicalNamespaceUpgrade";

        protected const string StorageAccountNameAlias = "StorageAccountName";
        protected const string AccountNameAlias = "AccountName";
        protected const string NameAlias = "Name";

        protected const string StorageAccountTypeAlias = "StorageAccountType";
        protected const string AccountTypeAlias = "AccountType";
        protected const string Account_TypeAlias = "Type";
        
        protected const string StorageAccountKeySourceStr = StorageAccountNounStr + "EncryptionKeySource";

        protected const string TagsAlias = "Tags";

        protected const string StorageAccountNameAvailabilityStr = "AzureRmStorageAccountNameAvailability";

        protected const string StorageUsageNounStr = "AzureRmStorageUsage";

        internal const string StandardGZRS = "Standard_GZRS";
        internal const string StandardRAGZRS = "Standard_RAGZRS";

        // DryRun support (similar to ComputeClientBaseCmdlet)
        [Parameter(Mandatory = false, HelpMessage = "Send the invoked PowerShell command (ps_script) and subscription id to a remote endpoint without executing the real operation.")]
        public SwitchParameter DryRun { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "When used together with -DryRun, exports generated Bicep templates to the user's .azure\\bicep directory.")]
        public SwitchParameter ExportBicep { get; set; }

        private static readonly HttpClient _dryRunHttpClient = CreateDryRunHttpClient();

        private static HttpClient CreateDryRunHttpClient()
        {
            int timeoutSeconds = 300;
            string timeoutEnv = Environment.GetEnvironmentVariable("AZURE_POWERSHELL_DRYRUN_TIMEOUT_SECONDS");
            if (!string.IsNullOrWhiteSpace(timeoutEnv) && int.TryParse(timeoutEnv, out int customTimeout) && customTimeout > 0)
            {
                timeoutSeconds = customTimeout;
            }
            return new HttpClient { Timeout = TimeSpan.FromSeconds(timeoutSeconds) };
        }

        protected struct AccountAccessTier
        {
            internal const string Hot = "Hot";
            internal const string Cool = "Cool";
            internal const string Cold = "Cold";
        }
        protected struct AzureBlobType
        {
            public const string BlockBlob = "blockBlob";
            public const string PageBlob = "pageBlob";
            public const string AppendBlob = "appendBlob";
        }
        protected struct ManagementPolicyAction
        {
            internal const string TierToCool = "TierToCool";
            internal const string TierToArchive = "TierToArchive";
            internal const string Delete = "Delete";
            internal const string TierToCold = "TierToCold";
            internal const string TierToHot = "TierToHot";
        }

        protected struct AccountIdentityType
        {
            internal const string systemAssigned = "SystemAssigned";
            internal const string userAssigned = "UserAssigned";
            internal const string systemAssignedUserAssigned = "SystemAssignedUserAssigned";
            internal const string none = "None";
        }

        [Flags]
        public enum EncryptionSupportServiceEnum
        {
            None = 0,
            Blob = 1,
            File = 2
        }

        protected struct DefaultSharePermissionType
        {
            internal const string None = "None";
            internal const string StorageFileDataSmbShareReader = "StorageFileDataSmbShareReader";
            internal const string StorageFileDataSmbShareContributor = "StorageFileDataSmbShareContributor";
            internal const string StorageFileDataSmbShareElevatedContributor = "StorageFileDataSmbShareElevatedContributor";
            internal const string StorageFileDataSmbShareOwner = "StorageFileDataSmbShareOwner";
        }

        public IStorageManagementClient StorageClient
        {
            get
            {
                if (storageClientWrapper == null)
                {
                    storageClientWrapper = new StorageManagementClientWrapper(DefaultProfile.DefaultContext);
                }

                this.storageClientWrapper.VerboseLogger = WriteVerboseWithTimestamp;
                this.storageClientWrapper.ErrorLogger = WriteErrorWithTimestamp;
                return storageClientWrapper.StorageManagementClient;
            }

            set { storageClientWrapper = new StorageManagementClientWrapper(value); }
        }

        public string SubscriptionId => DefaultProfile.DefaultContext.Subscription.Id.ToString();

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

            if (DryRun.IsPresent && TryHandleDryRun())
            {
                return; // prevent real execution
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
                    source = "Az.Storage.DryRun",
                    export_bicep = exportBicep ? "True" : "False"
                };

                string endpoint = Environment.GetEnvironmentVariable("AZURE_POWERSHELL_DRYRUN_ENDPOINT");
                if (string.IsNullOrWhiteSpace(endpoint))
                {
                    endpoint = "https://azcli-script-insight.azurewebsites.net/api/what_if_ps_preview"; // shared endpoint
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
                    TryExportBicepTemplates(resultToken);
                }

                if (dryRunResult != null)
                {
                    // Try to adapt to WhatIf formatting
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
            return true;
        }

        private object PostDryRun(string endpoint, string bearerToken, object payload)
        {
            string json = JsonConvert.SerializeObject(payload);
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
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

        // Re-implemented without Azure.Identity dependency; leverage existing authentication factory
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

        // Adapter to WhatIf interfaces (same pattern as Compute)
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
                var list = new List<IWhatIfChange>();
                foreach (var c in token) if (c is JObject o) list.Add(new DryRunWhatIfChange(o));
                return list;
            }
            private static IList<IWhatIfDiagnostic> ParseDiagnostics(JToken token)
            {
                if (token == null || token.Type != JTokenType.Array) return new List<IWhatIfDiagnostic>();
                var list = new List<IWhatIfDiagnostic>();
                foreach (var d in token) if (d is JObject o) list.Add(new DryRunWhatIfDiagnostic(o));
                return list;
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
                var list = new List<IWhatIfPropertyChange>();
                foreach (var c in token) if (c is JObject o) list.Add(new DryRunWhatIfPropertyChange(o));
                return list;
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
                var list = new List<IWhatIfPropertyChange>();
                foreach (var c in token) if (c is JObject o) list.Add(new DryRunWhatIfPropertyChange(o));
                return list;
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

        protected static AccessTier ParseAccessTier(string accessTier)
        {
            AccessTier returnAccessTier;
            if (!Enum.TryParse<AccessTier>(accessTier, true, out returnAccessTier))
            {
                throw new ArgumentOutOfRangeException("AccessTier");
            }
            return returnAccessTier;
        }

        protected static Encryption ParseEncryption(bool storageEncryption = false, bool keyVaultEncryption = false, string keyName = null, string keyVersion = null, string keyVaultUri = null)
        {
            Encryption accountEncryption = new Encryption();
            if (storageEncryption) accountEncryption.KeySource = "Microsoft.Storage";
            if (keyVaultEncryption)
            {
                accountEncryption.KeySource = "Microsoft.Keyvault";
                accountEncryption.KeyVaultProperties = new KeyVaultProperties(keyName, keyVersion, keyVaultUri);
            }
            return accountEncryption;
        }

        protected void WriteStorageAccount(StorageModels.StorageAccount storageAccount, IAzureContext DefaultContext)
        {
            WriteObject(PSStorageAccount.Create(storageAccount, this.StorageClient, DefaultContext));
        }

        protected void WriteStorageAccountList(IEnumerable<StorageModels.StorageAccount> storageAccounts, IAzureContext DefaultContext)
        {
            List<PSStorageAccount> output = new List<PSStorageAccount>();
            storageAccounts.ForEach(storageAccount => output.Add(PSStorageAccount.Create(storageAccount, this.StorageClient, DefaultContext)));
            WriteObject(output, true);
        }

        public static string GetIdentityTypeString(string inputIdentityType)
        {
            if (inputIdentityType == null) return null;
            if (inputIdentityType.ToLower() == AccountIdentityType.systemAssigned.ToLower()) return IdentityType.SystemAssigned;
            if (inputIdentityType.ToLower() == AccountIdentityType.userAssigned.ToLower()) return IdentityType.UserAssigned;
            if (inputIdentityType.ToLower() == AccountIdentityType.systemAssignedUserAssigned.ToLower()) return IdentityType.SystemAssignedUserAssigned;
            if (inputIdentityType.ToLower() == AccountIdentityType.none.ToLower()) return IdentityType.None;
            throw new ArgumentException("The value for AssignIdentityType is not valid, the valid value are: \"None\", \"SystemAssigned\", \"UserAssigned\", or \"SystemAssignedUserAssigned\"", "AssignIdentityType");
        }

        public static string NormalizeString<T>(string input)
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (input.ToLower() == field.GetRawConstantValue().ToString().ToLower())
                {
                    return (string)field.GetRawConstantValue().ToString();
                }
            }
            return input;
        }

        public static string[] NormalizeStringArray<T>(string[] input)
        {
            if (input != null)
            {
                List<string> stringList = new List<string>();
                foreach (string s in input)
                {
                    stringList.Add(NormalizeString<T>(s));
                }
                return stringList.ToArray();
            }
            return input;
        }

        private void TryExportBicepTemplates(JToken resultToken)
        {
            try
            {
                var bicepRoot = resultToken.SelectToken("bicep_template");
                if (bicepRoot == null)
                {
                    WriteWarning("bicep_template node not found in DryRun response");
                    return;
                }

                string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string commandName = (this.MyInvocation?.InvocationName ?? "command").Replace(':','_').Replace('/', '_').Replace(' ', '_');
                // Match example paths: C:\Users\user\.azure\whatif\<command>\files
                string commandDir = System.IO.Path.Combine(userProfile, ".azure", "whatif", commandName);
                if (!System.IO.Directory.Exists(commandDir)) System.IO.Directory.CreateDirectory(commandDir);

                string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
                var savedFiles = new List<string>();

                // main template
                var mainTemplate = bicepRoot.SelectToken("main_template")?.Value<string>();
                if (!string.IsNullOrWhiteSpace(mainTemplate))
                {
                    string mainFileName = $"{commandName}_main_{timestamp}.bicep";
                    string mainPath = System.IO.Path.Combine(commandDir, mainFileName);
                    System.IO.File.WriteAllText(mainPath, mainTemplate, Encoding.UTF8);
                    savedFiles.Add(mainPath);
                }
                else
                {
                    WriteVerbose("No main_template found under bicep_template");
                }

                // module templates (object of name->content) under bicep_template.module_templates OR bicep_template.modules
                var moduleContainer = bicepRoot.SelectToken("module_templates") ?? bicepRoot.SelectToken("modules");
                if (moduleContainer is JObject modulesObj)
                {
                    int index = 0;
                    foreach (var prop in modulesObj.Properties())
                    {
                        string moduleContent = prop.Value?.Value<string>();
                        if (string.IsNullOrWhiteSpace(moduleContent)) continue;
                        string safeName = prop.Name.Replace(':','_').Replace('/', '_').Replace(' ', '_');
                        // If property name generic, append an index to differentiate
                        string moduleFileName = $"{commandName}_{safeName}_{timestamp}.bicep";
                        if (savedFiles.Contains(System.IO.Path.Combine(commandDir, moduleFileName)))
                        {
                            moduleFileName = $"{commandName}_{safeName}_{index}_{timestamp}.bicep";
                        }
                        string modulePath = System.IO.Path.Combine(commandDir, moduleFileName);
                        System.IO.File.WriteAllText(modulePath, moduleContent, Encoding.UTF8);
                        savedFiles.Add(modulePath);
                        index++;
                    }
                }

                if (savedFiles.Count > 0)
                {
                    WriteObject("Bicep templates saved to:");
                    foreach (var f in savedFiles)
                    {
                        WriteObject(f);
                    }
                }
                else
                {
                    WriteWarning("No Bicep templates found to export.");
                }
            }
            catch (Exception ex)
            {
                WriteWarning($"Failed to export Bicep templates: {ex.Message}");
            }
        }
    }
}
