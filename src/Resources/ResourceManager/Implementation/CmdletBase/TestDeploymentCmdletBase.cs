using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.NewSdkExtensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase
{
    public abstract class TestDeploymentCmdletBase : DeploymentCmdletBase, IDynamicParameters
    {

        [Parameter(Mandatory = false, HelpMessage = "The query string (for example, a SAS token) to be used with the TemplateUri parameter. Would be used in case of linked templates")]
        public string QueryString { get; set; }

        public override object GetDynamicParameters()
        {
            if (!string.IsNullOrEmpty(QueryString))
            {
                protectedTemplateUri = TemplateUri + "?" + QueryString;
            }
            return base.GetDynamicParameters();
        }

        public void WriteOutput(TemplateValidationInfo validationInfo)
        {
            if (validationInfo.Errors.Count == 0)
            {
                var builder = new ColoredStringBuilder();

                var formatter = new WhatIfOperationResultFormatter(builder);

                formatter.FormatDiagnostics(validationInfo.Diagnostics, new List<PSWhatIfChange>());

                WriteObject(builder.ToString());
            }
            else
            {
                WriteObject(validationInfo.Errors.Select(e => e.ToPSResourceManagerError()).ToList());
            }
        }

    }
}
