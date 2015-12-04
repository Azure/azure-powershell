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
using System.Linq;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Net;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.StorSimple.Models;
using System.Text.RegularExpressions;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public class StorSimpleCmdletBase : AzureSMCmdlet
    {
        //this property will determine whether before running the actual commandlet logic, should resource selection be verified
        protected bool verifyResourceBeforeCmdletExecute;

        /// <summary>
        /// default constructor for most commandlets. In this case, Resource check will be verified
        /// </summary>
        public StorSimpleCmdletBase() : this(true) { }

        /// <summary>
        /// constructor variant if you want to suppress the resource check for your commandlet
        /// </summary>
        /// <param name="performResourceCheck"></param>
        public StorSimpleCmdletBase(bool performResourceCheck):base()
        {
            verifyResourceBeforeCmdletExecute = performResourceCheck;
        }

        private StorSimpleClient storSimpleClient;

        internal StorSimpleClient StorSimpleClient
        {
            get
            {
                if (this.storSimpleClient == null)
                {
                    this.storSimpleClient = new StorSimpleClient(Profile, Profile.Context.Subscription);
                }
                storSimpleClient.ClientRequestId = Guid.NewGuid().ToString("D") + "_PS";
                WriteVerbose(string.Format(Resources.ClientRequestIdMessage, storSimpleClient.ClientRequestId, DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")));
                return this.storSimpleClient;
            }
        }

        internal virtual void HandleAsyncTaskResponse(AzureOperationResponse opResponse, string operationName)
        {
            string msg = string.Empty;

            if (opResponse.StatusCode != HttpStatusCode.Accepted && opResponse.StatusCode != HttpStatusCode.OK)
            {
                msg = string.Format(Resources.FailureMessageSubmitTask, operationName);
            }

            else
            {
                if (opResponse.GetType().Equals(typeof(TaskResponse)))
                {
                    var taskResponse = opResponse as TaskResponse;
                    msg = string.Format(Resources.SuccessMessageSubmitTask, operationName, taskResponse.TaskId);
                    WriteObject(taskResponse.TaskId);
                }

                else if (opResponse.GetType().Equals(typeof(GuidTaskResponse)))
                {
                    var guidTaskResponse = opResponse as GuidTaskResponse;
                    msg = string.Format(Resources.SuccessMessageSubmitTask, operationName, guidTaskResponse.TaskId);
                    WriteObject(guidTaskResponse.TaskId);
                }
            }

            WriteVerbose(msg);
        }

        internal virtual void HandleDeviceJobResponse(JobResponse jobResponse, string operationName)
        {
            string msg = string.Format(Resources.SuccessMessageSubmitDeviceJob, operationName, jobResponse.JobId);
            WriteObject(jobResponse.JobId);
            WriteVerbose(msg);
        }

        internal virtual void HandleSyncTaskResponse(TaskStatusInfo taskStatus, string operationName)
        {
            string msg = string.Empty;
            TaskReport taskReport = new TaskReport(taskStatus);

            if (taskStatus.AsyncTaskAggregatedResult != AsyncTaskAggregatedResult.Succeeded)
            {
                msg = string.Format(Resources.FailureMessageCompleteJob, operationName);
                WriteObject(taskReport);
            }

            else
            {
                msg = string.Format(Resources.SuccessMessageCompleteJob, operationName);
                WriteObject(taskReport);
            }

            WriteVerbose(msg);
        }

        private static void StripNamespaces(XDocument doc)
        {
            var elements = doc.Descendants();
            elements.Attributes().Where(attr => attr.IsNamespaceDeclaration).Remove();
            foreach (var element in elements)
            {
                element.Name = element.Name.LocalName;
            }
        }

        internal virtual void HandleException(Exception exception)
        {
            ErrorRecord errorRecord = null;
            var ex = exception;
            do
            {
                Type exType = ex.GetType();
                if(exType == typeof(CloudException))
                {
                    var cloudEx = ex as CloudException;
                    if (cloudEx == null)
                        break;
                    var response = cloudEx.Response;
                    try
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            var notAvailableException = new Exception(Resources.NotFoundWebExceptionMessage);
                            errorRecord = new ErrorRecord(notAvailableException, string.Empty, ErrorCategory.InvalidOperation, null);
                            break;
                        }
                        else
                        {
                            XDocument xDoc = XDocument.Parse(response.Content);
                            StripNamespaces(xDoc);
                            string cloudErrorCode = xDoc.Descendants("ErrorCode").FirstOrDefault().Value;
                            WriteVerbose(string.Format(Resources.CloudExceptionMessage, cloudErrorCode));
                        }
                    }
                    catch (Exception)
                    {
                        
                    } 
                    
                    errorRecord = new ErrorRecord(cloudEx, string.Empty, ErrorCategory.InvalidOperation, null);
                    break;
                }
                else if(exType == typeof(WebException))
                {
                    var webEx = ex as WebException;
                    if (webEx == null)
                        break;
                    try
                    {
                        HttpWebResponse response = webEx.Response as HttpWebResponse;
                        WriteVerbose(string.Format(Resources.WebExceptionMessage, response.StatusCode));
                    }
                    catch (Exception)
                    {
                        
                    }
                    errorRecord = new ErrorRecord(webEx, string.Empty, ErrorCategory.ConnectionError, null);
                    break;
                }
                else if (exType == typeof (FormatException))
                {
                    var formEx = ex as FormatException;
                    if (formEx == null)
                        break;
                    WriteVerbose(string.Format(Resources.InvalidInputMessage, ex.Message));
                    errorRecord = new ErrorRecord(formEx, string.Empty, ErrorCategory.InvalidData, null);
                }
                else if (exType == typeof(NullReferenceException))
                {
                    var nullEx = ex as NullReferenceException;
                    if (nullEx == null)
                        break;
                    WriteVerbose(string.Format(Resources.InvalidInputMessage, ex.Message));
                    errorRecord = new ErrorRecord(nullEx, string.Empty, ErrorCategory.InvalidData, null);
                    break;
                }
                else if (exType == typeof(ArgumentNullException))
                {
                    var argNullEx = ex as ArgumentNullException;
                    if (argNullEx == null)
                        break;
                    WriteVerbose(string.Format(Resources.InvalidInputMessage, ex.Message));
                    errorRecord = new ErrorRecord(argNullEx, string.Empty, ErrorCategory.InvalidData, null);
                    break;
                }
                else if (exType == typeof(ArgumentException))
                {
                    var argEx = ex as ArgumentException;
                    if (argEx == null)
                        break;
                    WriteVerbose(string.Format(Resources.InvalidInputMessage, ex.Message));
                    errorRecord = new ErrorRecord(argEx, string.Empty, ErrorCategory.InvalidData, null);
                    break;
                }
                ex = ex.InnerException;
            } while (ex != null);

            if(errorRecord == null)
            {
                errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.NotSpecified, null);
            }

            WriteError(errorRecord);
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if(verifyResourceBeforeCmdletExecute)
                VerifyResourceContext();
        }
        /// <summary>
        /// this method verifies that a resource has been selected before this commandlet is executed
        /// </summary>
        private void VerifyResourceContext()
        {
            if (!CheckResourceContextPresent())
            {
                throw GetGenericException(Resources.ResourceContextNotSetMessage, null);
            }
        }

        private bool CheckResourceContextPresent()
        {
            var resourceContext = StorSimpleClient.GetResourceContext();
            if (resourceContext == null
                || string.IsNullOrEmpty(resourceContext.ResourceId)
                || string.IsNullOrEmpty(resourceContext.ResourceName))
            {
                return false;
            }
            return true;
        }

        internal bool ValidStorageAccountCred(string storageAccountName, string storageAccountKey, string endpoint)
        {
            using (System.Management.Automation.PowerShell ps = System.Management.Automation.PowerShell.Create())
            {
                bool valid = true;
                Random rnd = new Random();
                string testContainerName = string.Format("storsimplesdkvalidation{0}", rnd.Next());
                //create a storage container and then delete it
                string validateScript = string.Format(
                                  @"$context = New-AzureStorageContext -StorageAccountName {0} -StorageAccountKey {1} -Endpoint {2};"
                                + @"New-AzureStorageContainer -Name {3} -Context $context;"
                                + @"Remove-AzureStorageContainer -Name {3} -Context $context -Force;",
                                storageAccountName, storageAccountKey, endpoint, testContainerName);
                ps.AddScript(validateScript);
                ps.Invoke();
                if (ps.HadErrors)
                {
                    var exception = ps.Streams.Error[0].Exception;
                    string getScript = string.Format(
                                  @"$context = New-AzureStorageContext -StorageAccountName {0} -StorageAccountKey {1};"
                                + @"Get-AzureStorageContainer -Name {2} -Context $context;",
                                storageAccountName, storageAccountKey, testContainerName);
                    ps.AddScript(getScript);
                    var result = ps.Invoke();
                    if (result != null && result.Count > 0)
                    {
                        //storage container successfully created and still exists, retry deleting it
                        int retryCount = 1;
                        string removeScript = string.Format(
                                  @"$context = New-AzureStorageContext -StorageAccountName {0} -StorageAccountKey {1};"
                                + @"Remove-AzureStorageContainer -Name {2} -Context $context -Force;",
                                storageAccountName, storageAccountKey, testContainerName);
                        do
                        {
                            WriteVerbose(string.Format(Resources.StorageAccountCleanupRetryMessage, retryCount));
                            ps.AddScript(removeScript);
                            ps.Invoke();
                            Thread.Sleep(retryCount * 1000);
                            ps.AddScript(getScript);
                            result = ps.Invoke();
                        } while (result != null && result.Count > 0 && ++retryCount <= 5);
                    }
                    else
                    {
                        valid = false;
                        HandleException(exception);
                    }
                }
                return valid;
            }
        }


        internal string GetStorageAccountLocation(string storageAccountName, out bool exist)
        {
            using (System.Management.Automation.PowerShell ps = System.Management.Automation.PowerShell.Create())
            {
                string location = null;
                exist = false;

                string script = string.Format(@"Get-AzureStorageAccount -StorageAccountName {0}", storageAccountName);
                ps.AddScript(script);
                var result = ps.Invoke();
                
                if (ps.HadErrors)
                {
                    HandleException(ps.Streams.Error[0].Exception);
                    WriteVerbose(string.Format(Resources.StorageAccountNotFoundMessage, storageAccountName));
                }
                
                if (result != null && result.Count > 0)
                {
                    exist = true;
                    WriteVerbose(string.Format(Resources.StorageAccountFoundMessage, storageAccountName));
                    script = string.Format(@"Get-AzureStorageAccount -StorageAccountName {0}"
                                           + @"| Select-Object -ExpandProperty Location", storageAccountName);
                    ps.AddScript(script);
                    result = ps.Invoke();
                    if (ps.HadErrors)
                    {
                        HandleException(ps.Streams.Error[0].Exception);
                    }
                    if (result.Count > 0)
                    {
                        location = result[0].ToString();
                    }
                }
                return location;
            }
        }

        internal bool ValidateAndEncryptStorageCred(string name, string key, string endpoint, out string encryptedKey, out string thumbprint)
        {
            StorSimpleCryptoManager storSimpleCryptoManager = new StorSimpleCryptoManager(StorSimpleClient);
            thumbprint = storSimpleCryptoManager.GetSecretsEncryptionThumbprint();
            encryptedKey = null;
            if (!string.IsNullOrEmpty(key))
            {
                //validate storage account credentials
                if (!ValidStorageAccountCred(name, key, endpoint))
                {
                    throw new ArgumentException(Resources.StorageCredentialVerificationFailureMessage);
                }
                WriteVerbose(Resources.StorageCredentialVerificationSuccessMessage);
                WriteVerbose(Resources.EncryptionInProgressMessage);
                storSimpleCryptoManager.EncryptSecretWithRakPub(key, out encryptedKey);
            }
            return true;
        }

        /// <summary>
        /// Helper method to determine if this device has already been configured or not
        /// </summary>
        /// <returns></returns>
        public bool IsDeviceConfigurationCompleteForDevice(DeviceDetails details)
        {
            bool data0Configured = false;

            if (details.NetInterfaceList != null)
            {
                NetInterface data0 = details.NetInterfaceList.Where(x => x.InterfaceId == NetInterfaceId.Data0).ToList<NetInterface>().First<NetInterface>();
                if (data0 != null
                    && data0.IsEnabled
                    && data0.NicIPv4Settings != null
                    && !string.IsNullOrEmpty(data0.NicIPv4Settings.Controller0IPv4Address))
                    data0Configured = true;
            }
            return data0Configured;
        }
    
        /// <summary>
        /// this method verifies that the devicename parameter specified is completely configured
        /// most operations are not allowed on a non-configured device
        /// </summary>
        public void VerifyDeviceConfigurationCompleteForDevice(string deviceId)
        {
            var details = storSimpleClient.GetDeviceDetails(deviceId);
            var data0Configured = IsDeviceConfigurationCompleteForDevice(details);
            if (!data0Configured)
                throw GetGenericException(Resources.DeviceNotConfiguredMessage, null);
        }

        internal string GetHostnameFromEndpoint(string endpoint)
        {
            return string.Format("blob.{0}", endpoint);
        }

        internal string GetEndpointFromHostname(string hostname)
        {
            return hostname.Substring(hostname.IndexOf('.') + 1);
        }

        internal Exception GetGenericException(string exceptionMessage, Exception innerException)
        {
            return new Exception(exceptionMessage, innerException);
        }

        /// <summary>
        /// Validate that all network configs are valid.
        /// 
        /// Its mandatory to provide either (IPv4 Address and netmask) or IPv6 orefix for an interface that
        /// is being enabled. ( Was previously disabled and is now being configured)
        /// </summary>
        internal void ValidateNetworkConfigs(DeviceDetails details, NetworkConfig[] StorSimpleNetworkConfig)
        {
            if (StorSimpleNetworkConfig == null)
            {
                return;
            }
            foreach (var netConfig in StorSimpleNetworkConfig)
            {
                // get corresponding netInterface in device details.
                var netInterface = details.NetInterfaceList.FirstOrDefault(x => x.InterfaceId == netConfig.InterfaceAlias);
                // If its being enabled and its not Data0, it must have IP Address info
                if (netInterface == null || (netInterface.InterfaceId != NetInterfaceId.Data0 && !netInterface.IsEnabled))
                {
                    // If its not an enabled interface either IPv6(prefix) or IPv4(address and mask) must be provided.
                    if ((netConfig.IPv4Address == null || netConfig.IPv4Netmask == null) && netConfig.IPv6Prefix == null)
                    {
                        throw new ArgumentException(string.Format(Resources.IPAddressesNotProvidedForNetInterfaceBeingEnabled, StorSimpleContext.ResourceName, details.DeviceProperties.DeviceId));
                    }
                }
            }
        }

        /// <summary>
        /// Try to parse an IP Address from the provided string
        /// </summary>
        /// <param name="data">IP Address string</param>
        /// <param name="ipAddress"></param>
        /// <param name="paramName">Name of the param which is being processed (to be used for errors)</param>
        internal void TrySetIPAddress(string data, out IPAddress ipAddress, string paramName)
        {
            if (data == null)
            {
                ipAddress = null;
                return;
            }
            try
            {
                ipAddress = IPAddress.Parse(data);
            }
            catch (FormatException)
            {
                ipAddress = null;
                throw new ArgumentException(string.Format(Resources.InvalidIPAddressProvidedMessage, paramName));
            }
        }

        /// <summary>
        /// Validate that all mandatory data for the first Device Configuration has been provided.
        /// </summary>
        /// <returns>bool indicating whether all mandatory data is there or not.</returns>
        internal bool ValidParamsForFirstDeviceConfiguration(NetworkConfig[] netConfigs, TimeZoneInfo timeZone, string secondaryDnsServer)
        {
            if (netConfigs == null)
            {
                return false;
            }
            // Make sure network config for Data0 has been provided with atleast Controller0 IP Address
            var data0 = netConfigs.FirstOrDefault(x => x.InterfaceAlias == NetInterfaceId.Data0);
            if (data0 == null || data0.Controller0IPv4Address == null || data0.Controller1IPv4Address == null)
            {
                return false;
            }
            // Timezone is also mandatory
            if (timeZone == null || secondaryDnsServer == null)
            {
                return false;
            }

            // There must be atleast one iscsi enabled net interface in the first config
            var iscsiEnabledInterfacePresent = netConfigs.Any(x => x.IsIscsiEnabled == true);
            if (!iscsiEnabledInterfacePresent)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate that the target device is eligible for failover
        /// </summary>
        /// <param name="sourceDeviceName">The source device identifier</param>
        /// <param name="targetDeviceName">The target device identifier</param>
        /// <returns></returns>
        internal bool ValidTargetDeviceForFailover(string sourceDeviceId, string targetDeviceId)
        {
            if (sourceDeviceId.Equals(targetDeviceId, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException(Resources.DeviceFailoverSourceAndTargetDeviceSameError);
            }
            
            return true;
        }

        internal bool IsValidAsciiString(string s)
        {
            return Regex.IsMatch(s, "[ -~]+");
        }

        /// <summary>
        /// Validate that the string provided has length within the specified constraints.
        /// 
        /// Throws an ArgumentException with the specified error message if the validation fails.
        /// </summary>
        /// <param name="data">string to be validated</param>
        /// <param name="minLength">minimum allowable length for the string</param>
        /// <param name="maxLength">maximum allowable length for the string</param>
        /// <param name="errorMessage">error message for the exception raised in case of invalid data</param>
        internal void ValidateLength(string data, uint minLength, uint maxLength, string errorMessage)
        {
            if (data.Length < minLength || data.Length > maxLength)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        /// <summary>
        /// Most of the passwords in the device must contain 3 of the following:
        /// - a lowercase character
        /// - an uppercase character
        /// - a number
        /// - a special character
        /// 
        /// Raises an ArgumentException with appropriate error message notifying the above
        /// conditions when the validation fails.
        /// </summary>
        /// <param name="data"></param>
        internal void ValidatePasswordComplexity(string data, string passwordName)
        {
            string errorMessage = string.Format(Resources.PasswordCharacterCriteriaError, passwordName);
            var criteriaFulfilled = 0;
            // Regular expressions for lowercase letter, uppercase letter, digit and special char
            // respectively
            string[] criteriaRegexs = { ".*[a-z]", ".*[A-Z]", ".*\\d", ".*\\W" };

            foreach(var regexStr in criteriaRegexs){
                // The static IsMatch method is supposed to use an Application-wide cache of compiled regexes
                // and hence should save computation time (though not very significant because we are not doing tens of 
                // thousands of such tests)
                if(Regex.IsMatch(data, regexStr)){
                    criteriaFulfilled += 1;
                }
            }

            // If atleast 3 criteria have been fulfilled, then the password is complex enough
            if(criteriaFulfilled < 3){
                throw new ArgumentException(errorMessage);
            }
        }
    }
}