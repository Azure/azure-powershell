## `Set-*` cmdlet example

_Note_: for the below examples, the string "TopLevelResource" would be replaced with the name of your top-level resource (_e.g._, "VirtualMachine", "VirtualNetwork", "SqlServer"), and the string "ChildResource" would be replaced with the name of your child resource (_e.g._, "VirtualMachineExtension", "VirtualNetworkPeering", "SqlDatabase")

### Top-level resource

All top-level resources should have a `Set-*` cmdlet that allows users to update an existing resource _if the API follows `PUT` semantics_. If the API supports `PATCH` semantics, then the cmdlet should be `Update-*` (see below). The user can update an existing resource by providing all identity properties, the resource id, or the object representation of the resource. Similar to the `New-*` cmdlet, properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being updated.

#### Parameter Sets

To enable the scenarios mentioned previously, the cmdlet will need three parameter sets:

```
Set-AzTopLevelResource -ResourceGroupName <String> -Name <String> -Property1 <Type1> -Property2 <Type2> ... [-WhatIf] [-Confirm]

Set-AzTopLevelResource -InputObject <PSTopLevelResource> [-Property1 <Type1>] -[Property2 <Type2>] ... [-WhatIf] [-Confirm]

Set-AzTopLevelResource -ResourceId <String> -Property1 <Type1> -Property2 <Type2> ... [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName` and `-Name` parameters, as well as required property parameters to set their values on the resource. The second parameter has a required `-InputObject` parameter, as well as optional property parameters that override the value of the property on the given object if provided. The third parameter has a required `-ResourceId` parameter, as well as required property parameters to set their values on the resource.

#### C# example

```cs
namespace Microsoft.Azure.Commands.Service
{
    [Cmdlet(VerbsCommon.Set, "AzTopLevelResource", DefaultParameterSet = SetByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSTopLevelResource))]
    public class SetTopLevelResourceCommand : ServiceBaseCmdlet
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = SetByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSTopLevelResource InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = SetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByResourceIdParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet)]
        public Type1 Property1 { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByResourceIdParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet)]
        public Type2 Property2 { get; set; }

        // Excluding other property parameters

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
                this.Property1 = this.IsParameterBound(c => c.Property1) ? this.Property1 : this.InputObject.Property1;
                this.Property2 = this.IsParameterBound(c => c.Property2) ? this.Property2 : this.InputObject.Property2;
                ...
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            TopLevelResource existingResource = null;
            try
            {
                existingResource = this.MySDKClient.TopLevelResource.Get(this.ResourceGroupName, this.Name);
            }
            catch
            {
                existingResource = null;
            }

            if (existingResource == null)
            {
                throw new Exception(string.Format("A TopLevelResource with name '{0}' in resource group '{1}' does not exist. Please use New-AzTopLevelResource to create a TopLevelResource with these properties.", this.Name, this.ResourceGroupName));
            }

            existingResource.Property1 = this.Property1;
            existingResource.Property2 = this.Property2;
            ...

            if (this.ShouldProcess(this.Name, string.Format("Updating TopLevelResource '{0}' in resource group '{1}'.", this.Name, this.ResourceGroupName)))
            {
                var result = new PSTopLevelResource(this.MySDKClient.TopLevelResource.CreateOrUpdate(this.ResourceGroupName, this.Name, existingResource));
                WriteObject(result);
            }
        }
    }
}
```

### Child resource

All child resources should have a `Set-*` cmdlet that allows users to update an existing child resource _if the API follows `PUT` semantics_. If the API supports `PATCH` semantics, then the cmdlet should be `Update-*` (see below). The user can update an existing child resource by providing all identity properties, the resource id, or the object representation of the child resource. Similar to the `New-*` cmdlet, properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being updated.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need four parameter sets:

```
Set-AzChildResource -ResourceGroupName <String> -TopLevelResourceName <String> -Name <String> -Property1 <Type1> -Property2 <Type2> ... [-WhatIf] [-Confirm]

Set-AzChildResource -TopLevelResourceObject <PSTopLevelResource> -Name <String> -Property1 <Type1> -Property2 <Type2> ... [-WhatIf] [-Confirm]

Set-AzChildResource -InputObject <PSChildResource> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Set-AzChildResource -ResourceId <String> -Property1 <Type1> -Property2 <Type2> ... [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName`, `-TopLevelResourceName` and `-Name` parameters, as well as required property parameters to set their values on the child resource. The second parameter set has a required `-TopLevelResourceObject` parameter, which allows the user to pipe the result of the parent resource's `Get-*` and `Set/Update-*` cmdlets to this cmdlet, as well as required property parameters. The third parameter set has a required `-InputObject` parameter, as well as optional property parameters that override the value of the property on the given object if provided. The fourth parameter set has a required `-ResourceId` parameter, as well as required property parameters to set their values on the child resource.

#### C# example

```cs
namespace Microsoft.Azure.Commands.Service
{
    [Cmdlet(VerbsCommon.Set, "AzChildResource", DefaultParameterSet = SetByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSChildResource))]
    public class SetChildResourceCommand : ServiceBaseCmdlet
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByParentObjectParameterSet = "SetByParentObjectParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)
        [ValidateNotNullOrEmpty]
        public string TopLevelResourceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = SetByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSTopLevelResource TopLevelResourceObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = SetByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSChildResource InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = SetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByResourceIdParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet)]
        public Type1 Property1 { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByResourceIdParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet)]
        public Type2 Property2 { get; set; }

        // Excluding other property parameters

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.TopLevelResourceObject))
            {
                this.ResourceGroupName = this.TopLevelResourceObject.ResourceGroupName;
                this.TopLevelResourceName = this.TopLevelResourceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.TopLevelResourceName = this.InputObject.TopLevelResourceName;
                this.Name = this.InputObject.Name;
                this.Property1 = this.IsParameterBound(c => c.Property1) ? this.Property1 : this.InputObject.Property1;
                this.Property2 = this.IsParameterBound(c => c.Property2) ? this.Property2 : this.InputObject.Property2;
                ...
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.TopLevelResourceName = resourceIdentifier.ParentResource;
                this.Name = resourceIdentifier.ResourceName;
            }

            ChildResource childResource = null;
            try
            {
                childResource = this.MySDKClient.ChildResource.Get(this.ResourceGroupName, this.TopLevelResourceName, this.Name);
            }
            catch
            {
                childResource = null;
            }

            if (childResource == null)
            {
                throw new Exception(string.Format("A ChildResource with name '{0}' in resource group '{1}' under parent TopLevelResource '{2}' does not exist. Please use New-AzChildResource to create a ChildResource with these properties.", this.Name, this.ResourceGroupName, this.TopLevelResourceName));
            }

            childResource.Property1 = this.Property1;
            childResource.Property2 = this.Property2;
            ...

            if (this.ShouldProcess(this.Name, string.Format("Updating ChildResource '{0}' in resource group '{1}' under parent TopLevelResource '{2}'.", this.Name, this.ResourceGroupName, this.TopLevelResourceName)))
            {
                var result = new PSChildResource(this.MySDKClient.ChildResource.CreateOrUpdate(this.ResourceGroupName, this.TopLevelResourceName, this.Name, childResource));
                WriteObject(result);
            }
        }
    }
}
```