using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase
{
    public abstract class TestDeploymentCmdletBase : ResourceWithParameterCmdletBase, IDynamicParameters
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

    }
}
