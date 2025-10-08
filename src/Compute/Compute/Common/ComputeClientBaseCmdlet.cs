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

namespace Microsoft.Azure.Commands.Compute
{
    public abstract class ComputeClientBaseCmdlet : AzureRMCmdlet
    {
        protected const string VirtualMachineExtensionType = "Microsoft.Compute/virtualMachines/extensions";

        protected override bool IsUsageMetricEnabled => true;
        protected DateTime StartTime;

        private ComputeClient computeClient;

        // Reusable static HttpClient for DryRun posts
        private static readonly HttpClient _dryRunHttpClient = new HttpClient();

        [Parameter(Mandatory = false, HelpMessage = "Send the invoked PowerShell command (ps_script) and subscription id to a remote endpoint without executing the real operation.")]
        public SwitchParameter DryRun { get; set; }

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

            // Intercept early if DryRun requested
            if (DryRun.IsPresent && TryHandleDryRun())
            {
                return;
            }
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Handles DryRun processing: capture command text and subscription id and POST to endpoint.
        /// Returns true if DryRun was processed (and normal execution should stop).
        /// </summary>
        protected virtual bool TryHandleDryRun()
        {
            try
            {
                string psScript = this.MyInvocation?.Line ?? this.MyInvocation?.InvocationName ?? string.Empty;
                string subscriptionId = this.DefaultContext?.Subscription?.Id ?? DefaultProfile.DefaultContext?.Subscription?.Id ?? string.Empty;

                var payload = new
                {
                    ps_script = psScript,
                    subscription_id = subscriptionId,
                    timestamp_utc = DateTime.UtcNow.ToString("o"),
                    source = "Az.Compute.DryRun"
                };

                // Endpoint + token provided via environment variables to avoid changing all cmdlet signatures
                string endpoint = Environment.GetEnvironmentVariable("AZURE_POWERSHELL_DRYRUN_ENDPOINT");
                if (string.IsNullOrWhiteSpace(endpoint))
                {
                    // Default local endpoint (e.g., local Azure Function) if not provided via environment variable
                    endpoint = "http://localhost:7071/api/what_if_ps_preview";
                }
                // Acquire token via Azure Identity (DefaultAzureCredential). Optional scope override via AZURE_POWERSHELL_DRYRUN_SCOPE
                string token = GetDryRunAuthToken();

                // endpoint is always non-empty now (falls back to local default)

                var dryRunResult = PostDryRun(endpoint, token, payload);
                if (dryRunResult != null)
                {
                    // Display the response in a user-friendly format
                    WriteVerbose("========== DryRun Response ==========");
                    
                    // Try to pretty-print the JSON response
                    try
                    {
                        string formattedJson = JsonConvert.SerializeObject(dryRunResult, Formatting.Indented);
                        // Only output to pipeline once, not both WriteObject and WriteInformation
                        WriteObject(formattedJson);
                    }
                    catch
                    {
                        // Fallback: just write the object
                        WriteObject(dryRunResult);
                    }
                    
                    WriteVerbose("=====================================");
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
    }
}

