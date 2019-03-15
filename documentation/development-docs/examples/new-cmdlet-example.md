## `New-*` cmdlet example

_Note_: for the below examples, the string "TopLevelResource" would be replaced with the name of your top-level resource (_e.g._, "VirtualMachine", "VirtualNetwork", "SqlServer"), and the string "ChildResource" would be replaced with the name of your child resource (_e.g._, "VirtualMachineExtension", "VirtualNetworkPeering", "SqlDatabase")

### Top-level resource

All top-level resources should have a `New-*` cmdlet that allows users to create a resource with given properties. Properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being created.

_Note_: for long-running operations (~15s or longer), it is advised to add the [`-AsJob`](../design-guidelines/cmdlet-best-practices.md#asjob) to your cmdlet.


#### Parameter sets

To enable the above scenario, only one parameter set is needed:

```
New-AzTopLevelResource -ResourceGroupName <String> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]
```

This parameter set has required `-ResourceGroupName` and `-Name` parameters to satisfy the identity properties of the resource, as well as a few optional `-PropertyX` parameters that allows the user to set values for properties. The parameter set also has optional `-WhatIf` and `-Confirm` parameters that are automatically included from the implementation of `SupportsShouldProcess`.

#### C# example

```cs
namespace Microsoft.Azure.Commands.Service
{
    [Cmdlet(VerbsCommon.New, "AzTopLevelResource", DefaultParameterSetName = CreateParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSTopLevelResource))]
    public class NewTopLevelResourceCommand : ServiceBaseCmdlet
    {
        private const string CreateParameterSet = "CreateParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = CreateParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = CreateParameterSet)]
        public Type1 Property1 { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = CreateParameterSet)]
        public Type2 Property2 { get; set; }

        // Excluding other property parameters

        public override void ExecuteCmdlet()
        {
            TopLevelResource existingResource = null;
            try
            {
                existingResource = this.MySDKClient.TopLevelResource.Get(this.ResourceGroupName, this.Name);
            }
            catch
            {
                existingResource = null;
            }

            if (existingResource != null)
            {
                throw new Exception(string.Format("A TopLevelResource with name '{0}' in resource group '{1}' already exists. Please use Set/Update-AzTopLevelResource to update an existing TopLevelResource.", this.Name, this.ResourceGroupName));
            }

            existingResource = new TopLevelResource()
            {
                Name = this.Name,
                ResourceGroupName = this.ResourceGroupName,
                Property1 = this.Property1,
                Property2 = this.Property2,
                ...
            }

            if (this.ShouldProcess(this.Name, string.Format("Creating a new TopLevelResource in resource group '{0}' with name '{1}'.", this.ResourceGroupName, this.Name))
            {
                var result = new PSTopLevelResource(this.MySDKClient.TopLevelResource.CreateOrUpdate(existingResource));
                WriteObject(result);
            }
        }
    }
}
```

### Child resource

All child resources should have a `New-*` cmdlet that allows users to create a child resource with given properties. Properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being created.

_Note_: for long-running operations (~15s or longer), it is advised to add the [`-AsJob`](../design-guidelines/cmdlet-best-practices.md#asjob) to your cmdlet.

#### Parameter sets

To enable the above scenario, the cmdlet will need two parameter sets:

```
New-AzChildResource -ResourceGroupName <String> -TopLevelResourceName <String> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

New-AzChildResource -TopLevelResourceObject <PSTopLevelResource> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName`, `-TopLevelResource` and `-Name` parameters to satisfy the identity properties of the child resource, as well as a few optional `-PropertyX` parameters that allows the user to set values for the properties. The second parameter set has a required `-TopLevelResourceObject` parameter that can be piped from the parent resource's `Get-*` and `Set/Update-*` cmdlets.

#### C# example

```cs
namespace Microsoft.Azure.Commands.Service
{
    [Cmdlet(VerbsCommon.New, "AzChildResource", DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSChildResource))]
    public class NewChildResourceCommand : ServiceBaseCmdlet
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TopLevelResourceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSTopLevelResource TopLevelResourceObject { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

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

            ChildResource existingChildResource = null;
            try
            {
                existingChildResource = this.MySDKClient.ChildResource.Get(this.ResourceGroupName, this.TopLevelResourceName, this.Name);
            }
            catch
            {
                existingChildResource = null;
            }

            if (existingChildResource != null)
            {
                throw new Exception(string.Format("A ChildResource with name '{0}' in resource group '{1}' under parent TopLevelResource '{2}' already exists. Please use Set/Update-AzChildResource to update an existing ChildResource.", this.Name, this.ResourceGroupName, this.TopLevelResourceName));
            }

            existingChildResource = new ChildResource()
            {
                Name = this.Name,
                TopLevelResourceName = this.TopLevelResourceName,
                ResourceGroupName = this.ResourceGroupName,
                Property1 = this.Property1,
                Property2 = this.Property2,
                ...
            }

            if (this.ShouldProcess(this.Name, string.Format("Creating a new ChildResource in resource group '{0}' under parent TopLevelResource '{1}' with name '{2}'.", this.ResourceGroupName, this.TopLevelResourceName, this.Name))
            {
                var result = new PSChildResource(this.MySDKClient.ChildResource.CreateOrUpdate(existingChildResource));
                WriteObject(result);
            }
        }
    }
}
```