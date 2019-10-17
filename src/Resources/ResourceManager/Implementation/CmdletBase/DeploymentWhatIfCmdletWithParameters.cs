namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System.Collections;
    using System.Management.Automation;

    public abstract class DeploymentWhatIfCmdletWithParameters : DeploymentCmdletBase
    {
        protected const string SubscriptionParameterSetWithTemplateObjectParameterObject = "SubscriptionWithTemplateObjectAndParameterObject";
        protected const string SubscriptionParameterSetWithTemplateObjectParameterFile = "SubscriptionWithTemplateObjectAndParameterFile";
        protected const string SubscriptionParameterSetWithTemplateFileParameterObject = "SubscriptionWithTemplateFileAndParameterObject";
        protected const string SubscriptionParameterSetWithTemplateFileParameterFile = "SubscriptionWithTemplateFileAndParameterFile";
        protected const string SubscriptionParameterSetWithParameterlessTemplateObject = "SubscriptionWithTemplateObjectAndNoParameters";
        protected const string SubscriptionParameterSetWithParameterlessTemplateFile = "SubscriptionWithTemplateFileWithAndNoParameters";

        protected const string ResourceGroupParameterSetWithTemplateObjectParameterObject = "ResourceGroupWithTemplateObjectAndParameterObject";
        protected const string ResourceGroupParameterSetWithTemplateObjectParameterFile = "ResourceGroupWithTemplateObjectAndParameterFile";
        protected const string ResourceGroupParameterSetWithTemplateFileParameterObject = "ResourceGroupWithTemplateFileAndParameterObject";
        protected const string ResourceGroupParameterSetWithTemplateFileParameterFile = "ResourceGroupWithTemplateFileAndParameterFile";
        protected const string ResourceGroupParameterSetWithParameterlessTemplateObject = "ResourceGroupWithTemplateObjectAndNoParameters";
        protected const string ResourceGroupParameterSetWithParameterlessTemplateFile = "ResourceGroupWithTemplateFileWithAndNoParameters";

        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateObjectParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateFileParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = SubscriptionParameterSetWithTemplateObjectParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = SubscriptionParameterSetWithTemplateFileParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        public override Hashtable TemplateParameterObject { get; set; }

        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateObjectParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A Uri or local path to the file that has the template parameters.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateFileParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A Uri or local path to the file that has the template parameters.")]
        [Parameter(ParameterSetName = SubscriptionParameterSetWithTemplateObjectParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A Uri or local path to the file that has the template parameters.")]
        [Parameter(ParameterSetName = SubscriptionParameterSetWithTemplateFileParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A Uri or local path to the file that has the template parameters.")]
        [ValidateNotNullOrEmpty]
        [Alias("TemplateParameterUri")]
        public override string TemplateParameterFile { get; set; }

        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateObjectParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateObjectParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithParameterlessTemplateObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [Parameter(ParameterSetName = SubscriptionParameterSetWithTemplateObjectParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [Parameter(ParameterSetName = SubscriptionParameterSetWithTemplateObjectParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [Parameter(ParameterSetName = SubscriptionParameterSetWithParameterlessTemplateObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [ValidateNotNull]
        public override Hashtable TemplateObject { get; set; }

        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateFileParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri or local path to the template file.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateFileParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri or local path to the template file.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithParameterlessTemplateFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri or local path to the template file.")]
        [Parameter(ParameterSetName = SubscriptionParameterSetWithTemplateFileParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri or local path to the template file.")]
        [Parameter(ParameterSetName = SubscriptionParameterSetWithTemplateFileParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri or local path to the template file.")]
        [Parameter(ParameterSetName = SubscriptionParameterSetWithParameterlessTemplateFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri or local path to the template file.")]
        [ValidateNotNullOrEmpty]
        [Alias("TemplateUri")]
        public override string TemplateFile { get; set; }
    }
}
