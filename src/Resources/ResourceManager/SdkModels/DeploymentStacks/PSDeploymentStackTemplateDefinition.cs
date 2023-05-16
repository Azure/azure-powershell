using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentStackTemplateDefinition
    {
        public string Template { get; set; }

        public PSDeploymentStackTemplateLink TemplateLink { get; set; }

        internal PSDeploymentStackTemplateDefinition(object template, DeploymentStacksTemplateLink link)
        {
            if (template != null)
            {
                Template = template.ToString();
            }
            if (link != null)
            {
                TemplateLink = new PSDeploymentStackTemplateLink(link);
            }
        }
    }
}
