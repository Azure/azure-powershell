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

using Hyak.Common;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch
{
    public abstract class BatchCmdletBase : AzureRMCmdlet
    {
        private BatchClient batchClient;

        public BatchClient BatchClient
        {
            get
            {
                if (batchClient == null)
                {
                    batchClient = new BatchClient(DefaultContext);
                }

                this.batchClient.VerboseLogger = WriteVerboseWithTimestamp;
                return batchClient;
            }

            set { batchClient = value; }
        }

        protected abstract void ExecuteCmdletImpl();

        public override void ExecuteCmdlet()
        {
            try
            {
                Validate.ValidateInternetConnection();
                ExecuteCmdletImpl();
            }
            catch (BatchException ex)
            {
                if (ex?.RequestInformation != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"HttpStatusCode: " + ex.RequestInformation.HttpStatusCode);
                    sb.AppendLine($"StatusMessage: " + ex.RequestInformation.HttpStatusMessage);
                    sb.AppendLine($"ClientRequestId: {ex.RequestInformation.ClientRequestId}");
                    sb.AppendLine($"RequestId: {ex.RequestInformation.ServiceRequestId}");

                    if (ex.RequestInformation.BatchError != null)
                    {
                        sb.AppendLine();
                        sb.AppendLine($"Error code: {ex.RequestInformation.BatchError.Code}");
                        if (ex.RequestInformation.BatchError.Message != null)
                        {
                            sb.AppendLine($"Message: {ex.RequestInformation.BatchError.Message.Value}");
                        }

                        if (ex.RequestInformation.BatchError.Values != null && ex.RequestInformation.BatchError.Values.Any())
                        {
                            sb.AppendLine("Error details:");
                            foreach (var item in ex.RequestInformation.BatchError.Values)
                            {
                                sb.AppendLine($"{item.Key}: {item.Value}");
                            }
                        }
                    }

                    throw new BatchException(ex.RequestInformation, sb.ToString(), ex.InnerException);
                }

                throw;
            }
            catch (CloudException ex)
            {
                if (ex.Response?.Content != null)
                {
                    var message = FindDetailedMessage(ex.Response.Content);

                    if (message != null)
                    {
                        var updatedEx = new CloudException(message, ex);
                        throw updatedEx;
                    }
                }

                throw;
            }
        }

        /// <summary>
        /// For now, the 2nd message KVP inside "details" contains useful info about the failure. Eventually, a code KVP
        /// will be added such that we can search on that directly.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        internal static string FindDetailedMessage(string content)
        {
            string message = null;

            if (CloudException.IsJson(content))
            {
                var response = JObject.Parse(content);

                // check that we have a details section
                var detailsToken = response["details"];

                if (detailsToken != null)
                {
                    var details = detailsToken as JArray;
                    if (details != null && details.Count > 1)
                    {
                        // for now, 2nd entry in array is the one we're interested in. Need a better way of identifying the
                        // detailed error message
                        var dObj = detailsToken[1] as JObject;
                        var code = dObj.GetValue("code", StringComparison.CurrentCultureIgnoreCase);
                        if (code != null)
                        {
                            message = code.ToString() + ": ";
                        }

                        var detailedMsg = dObj.GetValue("message", StringComparison.CurrentCultureIgnoreCase);
                        if (detailedMsg != null)
                        {
                            message += detailedMsg.ToString();

                        }
                    }
                }
            }

            return message;
        }
    }
}
