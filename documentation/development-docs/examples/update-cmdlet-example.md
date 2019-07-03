## `Update-*` cmdlet example

_Note_: for the below examples, the string "TopLevelResource" would be replaced with the name of your top-level resource (_e.g._, "VirtualMachine", "VirtualNetwork", "SqlServer"), and the string "ChildResource" would be replaced with the name of your child resource (_e.g._, "VirtualMachineExtension", "VirtualNetworkPeering", "SqlDatabase")

### Top-level resource

All top-level resources should have an `Update-*` cmdlet that allows users to update an existing resource _if the API follows `PATCH` semantics_. If the API supports `PUT` semantics, then the cmdlet should be `Set-*` (see above). The user can update an existing resource by providing all identity properties, the resource id, or the object representation of the resource. Similar to the `New-*` cmdlet, properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being updated.

_Note_: if the only property that a user is able to update through the `PATCH` API is tags, then this cmdlet should not be implemented.

#### Parameter Sets

To enable the scenarios mentioned previously, the cmdlet will need three parameter sets:

```
Update-AzTopLevelResource -ResourceGroupName <String> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Update-AzTopLevelResource -InputObject <PSTopLevelResource> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Update-AzTopLevelResource -ResourceId <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName` and `-Name` parameters, the second parameter set has a required `-InputObject` parameter, and the third parameter set has a required `-ResourceId` parameter. All three parameter sets have optional property parameters that can be used to override the value of the property set on the retrieved/provided resource.

#### C# example

```cs
namespace Microsoft.Azure.Commands.Service
{
    [Cmdlet(VerbsData.Update, "AzTopLevelResource", DefaultParameterSet = UpdateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSTopLevelResource))]
    public class UpdateTopLevelResourceCommand : ServiceBaseCmdlet
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSTopLevelResource InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = UpdateByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public Type1 Property1 { get; set; }

        [Parameter(Mandatory = false)]
        public Type2 Property2 { get; set; }

        // Excluding other property parameters

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

            existingResource.Property1 = this.IsParameterBound(c => c.Property1) ? this.Property1 : existingResource.Property1;
            existingResource.Property2 = this.IsParameterBound(c => c.Property2) ? this.Property2 : existingResource.Property2;
            ...

            if (this.ShouldProcess(this.Name, string.Format("Updating TopLevelResource '{0}' in resource group '{1}'.", this.Name, this.ResourceGroupName)))
            {
                var result = new PSTopLevelResource(this.MySDKClient.TopLevelResource.Update(this.ResourceGroupName, this.Name, existingResource));
                WriteObject(result);
            }
        }
    }
}
```

### Child resource

All child resources should have an `Update-*` cmdlet that allows users to update an existing child resource _if the API follows `PATCH` semantics_. If the API supports `PUT` semantics, then the cmdlet should be `Set-*` (See above). The user can update an existing child resource by providing all identity properties, the resource id, or the object representation of the child resource. Similar to the `New-*` cmdlet, properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being updated.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need four parameter sets:

```
Update-AzChildResource -ResourceGroupName <String> -TopLevelResourceName <String> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Update-AzChildResource -TopLevelResourceObject <PSTopLevelResource> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Update-AzChildResource -InputObject <PSChildResource> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Update-AzChildResource -ResourceId <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName`, `-TopLevelResourceName` and `-Name` parameters, the second parameter set has required `-TopLevelResourceObject` and `-Name` parameters, the third parameter set has a required `-InputObject` parameter, and the fourth parameter set has a required `-ResourceId` parameter. All four parameter sets have optional property parameters that can be used to override the value of the property set on the retrieved/provided resource.

#### C# example

```cs
namespace Microsoft.Azure.Commands.Service
{
    [Cmdlet(VerbsData.Update, "AzChildResource", DefaultParameterSet = UpdateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSChildResource))]
    public class UpdateChildResourceCommand : ServiceBaseCmdlet
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByParentObjectParameterSet = "UpdateByParentObjectParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TopLevelResourceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSTopLevelResource TopLevelResourceObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSTopLevelResource InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = UpdateByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public Type1 Property1 { get; set; }

        [Parameter(Mandatory = false)]
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
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.TopLevelResourceName = resourceIdentifer.ParentResource;
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

            childResource.Property1 = this.IsParameterBound(c => c.Property1) ? this.Property1 : childResource.Property1;
            childResource.Property2 = this.IsParameterBound(c => c.Property2) ? this.Property2 : childResource.Property2;
            ...

            if (this.ShouldProcess(this.Name, string.Format("Updating ChildResource '{0}' in resource group '{1}' under parent TopLevelResource '{2}'.", this.Name, this.ResourceGroupName, this.TopLevelResourceName)))
            {
                var result = new PSChildResource(this.MySDKClient.ChildResource.Update(this.ResourceGroupName, this.TopLevelResourceName, this.Name, childResource));
                WriteObject(result);
            }
        }
    }
}
```