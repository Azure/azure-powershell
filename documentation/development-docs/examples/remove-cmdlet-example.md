## `Remove-*` cmdlet example

_Note_: for the below examples, the string "TopLevelResource" would be replaced with the name of your top-level resource (_e.g._, "VirtualMachine", "VirtualNetwork", "SqlServer"), and the string "ChildResource" would be replaced with the name of your child resource (_e.g._, "VirtualMachineExtension", "VirtualNetworkPeering", "SqlDatabase")

### Top-level resource

All top-level resources should have a `Remove-*` cmdlet that allows users to delete a specific resource. The user can delete a resource by providing all identity properties, the resource id, or the object representation of the resource. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being deleted. This cmdlet should also implement the [`-PassThru`](../design-guidelines/cmdlet-best-practices.md#returning-no-output) parameter, which allows the user to receive output when no output would normally be provided.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need three parameter sets:

```
Remove-AzTopLevelResource -ResourceGroupName <String> -Name <String> [-PassThru] [-WhatIf] [-Confirm]

Remove-AzTopLevelResource -InputObject <PSTopLevelResource> [-PassThru] [-WhatIf] [-Confirm]

Remove-AzTopLevelResource -ResourceId <String> [-PassThru] [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName` and `-Name` parameters, which allows the user to explicitly provide the identity properties of the resource that they want to delete. The second parameter has a required `-InputObject` parameter, which allows the user to pipe the result of the `Get-*` and `Set/Update-*` cmdlets to this cmdlet and delete the corresponding resource. The third parameter has a required `-ResourceId` parameter, which allows the user to delete a specific resource by resource id.

#### C# example

```cs
namespace Microsoft.Azure.Commands.Service
{
    [Cmdlet(VerbsCommon.Remove, "AzTopLevelResource", DefaultParameterSetName = DeleteByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveTopLevelResourceCommand : ServiceBaseCmdlet
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = DeleteByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSTopLevelResource InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.ShouldProcess(this.Name, string.Format("Deleting TopLevelResource '{0}' in resource group {0}", this.Name, this.ResourceGroupName)))
            {
                this.MySDKClient.TopLevelResource.Delete(this.ResourceGroupName, this.Name);
                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
```

### Child resource

All child resources should have a `Remove-*` cmdlet that allows users to delete a specific child resource. The user can delete a child resource by providing all identity properties, the resource id of the child resource, or the object representation of the child resource. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the child resource actually being deleted. This cmdlet should also implement the [`-PassThru`](../design-guidelines/cmdlet-best-practices.md#returning-no-output) parameter, which allows the user to receive the output when no output would normally be provided.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need four parameter sets:

```
Remove-AzChildResource -ResourceGroupName <String> -TopLevelResourceName <String> -Name <String> [-PassThru] [-WhatIf] [-Confirm]

Remove-AzChildResource -TopLeveResourceObject <PSTopLevelResource> -Name <String> [-PassThru] [-WhatIf] [-Confirm]

Remove-AzChildResource -InputObject <PSChildResource> [-PassThru] [-WhatIf] [-Confirm]

Remove-AzChildResource -ResourceId <String> [-PassThru] [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName`, `-TopLevelResourceName` and `-Name` parameters, which allows the user to explicitly provide the identity properties of the child resource that they want to delete. The second parameter has a required `-TopLeveResourceObject` parameter, which allows the user to pipe the result of the parent resource's `Get-*` and `Set/Update-*` cmdlets to this cmdlet, as well as a required `-Name` parameter. The third parameter has a required `-InputObject` parameter, which allows the user to pipe the result of the `Get-*` and `Set/Update-*` cmdlets to this cmdlet and delete the corresponding child resource. The fourth parameter has a required `-ResourceId` parameter, which allows the user to delete the specific child resource by resource id.

#### C# example

```cs
namespace Microsoft.Azure.Commands.Service
{
    [Cmdlet(VerbsCommon.Remove, "AzChildResource", DefaultParameterSetName = DeleteByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveChildResourceCommand : ServiceBaseCmdlet
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByParentObjectParameterSet = "DeleteByParentObjectParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TopLevelResourceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = DeleteByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSTopLevelResource TopLeveResourceObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = DeleteByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSChildResource InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.TopLeveResourceObject))
            {
                this.ResourceGroupName = this.TopLeveResourceObject.ResourceGroupName;
                this.TopLevelResourceName = this.TopLeveResourceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.TopLevelResourceName = this.InputObject.TopLevelResourceName;
                this.Name = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.TopLevelResourceName = resourceIdentifier.ParentResource;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.ShouldProcess(this.Name, string.Format("Deleting ChildResource '{0}' in resource group '{1}' under parent TopLevelResource '{2}'.", this.Name, this.ResourceGroupName, this.TopLevelResourceName)))
            {
                this.MySDKClient.ChildResource.Delete(this.ResourceGroupName, this.TopLevelResourceName, this.Name);
                if (this.IsPassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
```