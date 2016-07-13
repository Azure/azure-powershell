//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Management.Automation;
    using System.Text;

    [Cmdlet(VerbsData.Export, Constants.ApiManagementApi, DefaultParameterSetName = ExportContentToPipeline, 
        SupportsShouldProcess = true)]
    [OutputType(typeof(string))]
    public class ExportAzureApiManagementApi : AzureApiManagementCmdletBase
    {
        private const string ExportContentToPipeline = "Export to pipeline";
        private const string ExportToFile = "Export to File";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of exporting API. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Specification format (Wadl or Swagger). This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementApiFormat SpecificationFormat { get; set; }

        [Parameter(
            ParameterSetName = ExportToFile,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "File path where to save the exporting specification to. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String SaveAs { get; set; }

        [Parameter(
            ParameterSetName = ExportToFile,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified will override the file if it exists. This parameter is optional.")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            ParameterSetName = ExportToFile,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified will write true/false if api exported successfully/failed. This parameter is optional.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var result = Client.ApiExportToFile(Context, ApiId, SpecificationFormat, SaveAs);

            if (ParameterSetName.Equals(ExportContentToPipeline))
            {
                string resultStr;
                using (var memoryStream = new MemoryStream(result))
                using (var streamReader = new StreamReader(memoryStream, Encoding.UTF8))
                {
                    resultStr = streamReader.ReadToEnd();
                }

                WriteObject(resultStr);
            }
            else if (ParameterSetName.Equals(ExportToFile))
            {
                var actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.ApiExportDescription, ApiId, SaveAs);
                var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.ApiExportWarning, SaveAs);

                // Do nothing if force is not specified and user cancelled the operation
                if (!ShouldProcess(ApiId,
                        actionDescription) || (File.Exists(SaveAs) &&
                    !Force.IsPresent && !ShouldContinue(actionWarning, Resources.ShouldProcessCaption)))
                {
                    if (PassThru)
                    {
                        WriteObject(false.ToString().ToLower());
                    }

                    return;
                }

                using (var file = File.OpenWrite(SaveAs))
                {
                    file.Write(result, 0, result.Length);
                    file.Flush();
                }

                if (PassThru)
                {
                    WriteObject(true.ToString().ToLower());
                }
            }
        }
    }
}
