using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Net;
using System.Management.Automation;
using Microsoft.WindowsAzure;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    using Properties;

    public class StorSimpleCmdletBase : AzurePSCmdlet
    {
        private PSStorSimpleClient storSimpleClient;

        internal PSStorSimpleClient StorSimpleClient
        {
            get
            {
                if (this.storSimpleClient == null)
                {
                    this.storSimpleClient = new PSStorSimpleClient(CurrentContext.Subscription);
                }
                storSimpleClient.ClientRequestId = Guid.NewGuid().ToString("D") + "_PS";
                WriteVerbose(String.Format(Resources.ClientRequestIdMessage, storSimpleClient.ClientRequestId));
                return this.storSimpleClient;
            }
        }

        internal virtual void HandleAsyncJobResponse(OperationResponse opResponse, string operationName)
        {
            string msg = string.Empty;

            if (opResponse.StatusCode != HttpStatusCode.Accepted && opResponse.StatusCode != HttpStatusCode.OK)
            {
                msg = string.Format(Resources.FailureMessageSubmitJob, operationName);
            }

            else
            {
                if (opResponse.GetType().Equals(typeof(JobResponse)))
                {
                    var jobResponse = opResponse as JobResponse;
                    msg = string.Format(Resources.SuccessMessageSubmitJob, operationName, jobResponse.JobId);
                    WriteObject(jobResponse.JobId);
                }

                else if (opResponse.GetType().Equals(typeof(GuidJobResponse)))
                {
                    var guidJobResponse = opResponse as GuidJobResponse;
                    msg = string.Format(Resources.SuccessMessageSubmitJob, operationName, guidJobResponse.JobId);
                    WriteObject(guidJobResponse.JobId);
                }
            }

            WriteVerbose(msg);
        }

        internal virtual void HandleSyncJobResponse(JobStatusInfo jobStatus, string operationName)
        {
            string msg = string.Empty;

            if (jobStatus.TaskResult != TaskResult.Succeeded)
            {
                msg = string.Format(Resources.FailureMessageCompleteJob, operationName);
                WriteObject(jobStatus);
            }

            else
            {
                msg = string.Format(Resources.SuccessMessageCompleteJob, operationName);
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
                        XDocument xDoc = XDocument.Parse(response.Content);
                        StripNamespaces(xDoc);
                        string cloudErrorCode = xDoc.Descendants("ErrorCode").FirstOrDefault().Value;
                        WriteVerbose(String.Format(Resources.CloudExceptionMessage, cloudErrorCode));
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
                        WriteVerbose(String.Format(Resources.WebExceptionMessage, response.StatusCode));
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
                    var argEx = ex as ArgumentNullException;
                    if (argEx == null)
                        break;
                    WriteVerbose(string.Format(Resources.InvalidInputMessage, ex.Message));
                    errorRecord = new ErrorRecord(argEx, string.Empty, ErrorCategory.InvalidData, null);
                    break;
                }
                else if (exType == typeof(StorSimpleSecretManagementException))
                {
                    var keyManagerEx = ex as StorSimpleSecretManagementException;
                    if (keyManagerEx == null)
                        break;
                    errorRecord = new ErrorRecord(keyManagerEx, string.Empty, ErrorCategory.SecurityError, null);
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
            VerifyResourceContext();
        }
        private void VerifyResourceContext()
        {
            if (!CheckResourceContextPresent())
            {
                Exception ex = new Exception("Resource Context not set. Please set the resourcename using Select-AzureStorSimpleResource commandlet");
                ErrorRecord resourceNotSetRecord = new ErrorRecord(ex, "RESOURCE_NOT_SET", ErrorCategory.InvalidOperation, null);
                this.ThrowTerminatingError(resourceNotSetRecord);
            }
        }

        private bool CheckResourceContextPresent()
        {
            var resourceContext = StorSimpleClient.GetResourceContext();
            if (resourceContext == null
                || String.IsNullOrEmpty(resourceContext.ResourceId)
                || String.IsNullOrEmpty(resourceContext.ResourceName))
            {
                return false;
            }
            return true;
        }

        internal bool ValidStorageAccountCred(string storageAccountName, string storageAccountKey)
        {
            using (System.Management.Automation.PowerShell ps = System.Management.Automation.PowerShell.Create())
            {
                Random rnd = new Random();
                string testContainerName = String.Format("storsimplevalidationcontainer{0}", rnd.Next());
                string script = String.Format(
                                  @"$context = New-AzureStorageContext -StorageAccountName {0} -StorageAccountKey {1};"
                                + @"New-AzureStorageContainer -Name {2} -Context $context;"
                                + @"Remove-AzureStorageContainer -Name {2} -Context $context -Force;",
                                storageAccountName, storageAccountKey, testContainerName);
                ps.AddScript(script);
                ps.Invoke();
                if (ps.HadErrors)
                {
                    HandleException(ps.Streams.Error[0].Exception);
                    return false;
                }
                return true;
            }
        }

        internal String GetStorageAccountLocation(string storageAccountName, out bool exist)
        {
            using (System.Management.Automation.PowerShell ps = System.Management.Automation.PowerShell.Create())
            {
                String location = null;
                exist = false;

                string script = String.Format(@"Get-AzureStorageAccount -StorageAccountName {0}", storageAccountName);
                ps.AddScript(script);
                var result = ps.Invoke();
                
                if (ps.HadErrors)
                {
                    HandleException(ps.Streams.Error[0].Exception);
                    WriteVerbose(String.Format(Resources.StorageAccountNotFoundMessage, storageAccountName));
                }
                
                if (result != null && result.Count > 0)
                {
                    exist = true;
                    WriteVerbose(string.Format(Resources.StorageAccountFoundMessage, storageAccountName));
                    script = String.Format(@"Get-AzureStorageAccount -StorageAccountName {0}"
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
    }
}