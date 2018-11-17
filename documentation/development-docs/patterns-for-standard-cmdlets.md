# Expected Patterns for Standard Cmdlets

## Table of Contents

- [Top-level Resources](#top---level-resources)
    - [`Get-*` cmdlet](#get--cmdlet)
    - [`New-*` cmdlet](#new--cmdlet)
    - [`Remove-*` cmdlet](#remove--cmdlet)
    - [`Set-*` cmdlet](#set--cmdlet)
    - [`Update-*` cmdlet](#update--cmdlet)
- [Child Resources](#child-resources)
    - [`Get-*` cmdlet](#get--cmdlet-1)
    - [`New-*` cmdlet](#new--cmdlet-1)
    - [`Remove-*` cmdlet](#remove--cmdlet-1)
    - [`Set-*` cmdlet](#set--cmdlet-1)
    - [`Update-*` cmdlet](#update--cmdlet-1)

## Top-level Resources

### `Get-*` cmdlet

All top-level resources should have a `Get-*` cmdlet that allows users to list the resources in their subscription or a resource group, as well as get a specific resource. In addition, users should be able to provide the resource id of the resource they want to get, and the cmdlet will parse the string to get the necessary identity information.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need three parameter sets:

```
Get-AzureRmFoo [-ResourceGroupName <String>]

Get-AzureRmFoo -ResourceGroupName <String> -Name <String>

Get-AzureRmFoo -ResourceId <String>
```

The first parameter set has an optional `-ResourceGroupName` parameter, which allows the user to list all resources in a subscription or in a resource group. The second parameter set has required `-ResourceGroupName` and `-Name` parameters, which allows the user to get a specific resource. The third parameter set has a required `-ResourceId` parameter, which allows the user to get a specific resource by resource id.

#### C# example

<details><summary>Click to expand example</summary>
<p>

```cs
namespace Microsoft.Azure.Commands.Foo
{
    [Cmdlet(VerbsCommon.Get, "AzureRmFoo", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSFoo))]
    public class GetFooCommand : FooBaseCmdlet
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";"
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSet )]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                var result = new PSFoo(this.MySDKClient.Foo.Get(this.ResourceGroupName, this.Name));
                WriteObject(result);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                var result = this.MySDKClient.Foo.ListByResourceGroup(this.ResourceGroupName).Select(f => new PSFoo(f));
                WriteObject(result, true);
            }
            else
            {
                var result = this.MySDKClient.Foo.List().Select(f => new PSFoo(f));
                WriteObject(result, true);
            }
        }
    }
}
```

</p>
</details>

### `New-*` cmdlet

All top-level resources should have a `New-*` cmdlet that allows users to create a resource with given properties. Properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being created.

_Note_: for long-running operations (~15s or longer), it is advised to add the [`-AsJob`](.\azure-powershell-design-guidelines#asjob-parameter) to your cmdlet.

#### Parameter sets

To enable the above scenario, only one parameter set is needed:

```
New-AzureRmFoo -ResourceGroupName <String> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]
```

This parameter set has required `-ResourceGroupName` and `-Name` parameters to satisfy the identity properties of the resource, as well as a few optional `-PropertyX` parameters that allows the user to set values for properties. The parameter set also has optional `-WhatIf` and `-Confirm` parameters that are automatically included from the implementation of `SupportsShouldProcess`.

#### C# example

<details><summary>Click to expand example</summary>
<p>

```cs
namespace Microsoft.Azure.Commands.Foo
{
    [Cmdlet(VerbsCommon.New, "AzureRmFoo", DefaultParameterSetName = CreateParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSFoo))]
    public class NewFooCommand : FooBaseCmdlet
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
            Foo existingFoo = null;
            try
            {
                existingFoo = this.MySDKClient.Foo.Get(this.ResourceGroupName, this.Name);
            }
            catch
            {
                existingFoo = null;
            }

            if (existingFoo != null)
            {
                throw new Exception(string.Format("A Foo with name '{0}' in resource group '{1}' already exists. Please use Set/Update-AzureRmFoo to update an existing Foo.", this.Name, this.ResourceGroupName));
            }

            existingFoo = new Foo()
            {
                Name = this.Name,
                ResourceGroupName = this.ResourceGroupName,
                Property1 = this.Property1,
                Property2 = this.Property2,
                ...
            }

            if (this.ShouldProcess(this.Name, string.Format("Creating a new Foo in resource group '{0}' with name '{1}'.", this.ResourceGroupName, this.Name))
            {
                var result = new PSFoo(this.MySDKClient.Foo.CreateOrUpdate(existingFoo));
                WriteObject(result);
            }
        }
    }
}
```

</p>
</details>

### `Remove-*` cmdlet

All top-level resources should have a `Remove-*` cmdlet that allows users to delete a specific resource. The user can delete a resource by providing all identity properties, the resource id, or the object representation of the resource. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being deleted. This cmdlet should also implement the [`-PassThru`](.\azure-powershell-design-guidelines.md#returning-no-output) parameter, which allows the user to receive output when no output would normally be provided.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need three parameter sets:

```
Remove-AzureRmFoo -ResourceGroupName <String> -Name <String> [-PassThru] [-WhatIf] [-Confirm]

Remove-AzureRmFoo -InputObject <PSFoo> [-PassThru] [-WhatIf] [-Confirm]

Remove-AzureRmFoo -ResourceId <String> [-PassThru] [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName` and `-Name` parameters, which allows the user to explicitly provide the identity properties of the resource that they want to delete. The second parameter has a required `-InputObject` parameter, which allows the user to pipe the result of the `Get-*` and `Set/Update-*` cmdlets to this cmdlet and delete the corresponding resource. The third parameter has a required `-ResourceId` parameter, which allows the user to delete a specific resource by resource id.

#### C# example

<details><summary>Click to expand example</summary>
<p>

```cs
namespace Microsoft.Azure.Commands.Foo
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmFoo", DefaultParameterSetName = DeleteByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveFooCommand : FooBaseCmdlet
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
        public PSFoo InputObject { get; set; }

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

            if (this.ShouldProcess(this.Name, string.Format("Deleting Foo '{0}' in resource group {0}", this.Name, this.ResourceGroupName)))
            {
                this.MySDKClient.Foo.Delete(this.ResourceGroupName, this.Name);
                if (this.IsPassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
```

</p>
</details>

### `Set-*` cmdlet

All top-level resources should have a `Set-*` cmdlet that allows users to update an existing resource _if the API follows `PUT` semantics_. If the API supports `PATCH` semantics, then the cmdlet should be `Update-*` (see below). The user can update an existing resource by providing all identity properties, the resource id, or the object representation of the resource. Similar to the `New-*` cmdlet, properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being updated.

#### Parameter Sets

To enable the scenarios mentioned previously, the cmdlet will need three parameter sets:

```
Set-AzureRmFoo -ResourceGroupName <String> -Name <String> -Property1 <Type1> -Property2 <Type2> ... [-WhatIf] [-Confirm]

Set-AzureRmFoo -InputObject <PSFoo> [-Property1 <Type1>] -[Property2 <Type2>] ... [-WhatIf] [-Confirm]

Set-AzureRmFoo -ResourceId <String> -Property1 <Type1> -Property2 <Type2> ... [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName` and `-Name` parameters, as well as required property parameters to set their values on the resource. The second parameter has a required `-InputObject` parameter, as well as optional property parameters that override the value of the property on the given object if provided. The third parameter has a required `-ResourceId` parameter, as well as required property parameters to set their values on the resource.

#### C# example

<details><summary>Click to expand example</summary>
<p>

```cs
namespace Microsoft.Azure.Commands.Foo
{
    [Cmdlet(VerbsCommon.Set, "AzureRmFoo", DefaultParameterSet = SetByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSFoo))]
    public class SetFooCommand : FooBaseCmdlet
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
        public PSFoo InputObject { get; set; }

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

            Foo foo = null;
            try
            {
                foo = this.MySDKClient.Foo.Get(this.ResourceGroupName, this.Name);
            }
            catch
            {
                foo = null;
            }

            if (foo == null)
            {
                throw new Exception(string.Format("A Foo with name '{0}' in resource group '{1}' does not exist. Please use New-AzureRmFoo to create a Foo with these properties.", this.Name, this.ResourceGroupName));
            }

            foo.Property1 = this.Property1;
            foo.Property2 = this.Property2;
            ...

            if (this.ShouldProcess(this.Name, string.Format("Updating Foo '{0}' in resource group '{1}'.", this.Name, this.ResourceGroupName)))
            {
                var result = new PSFoo(this.MySDKClient.Foo.Update(this.ResourceGroupName, this.Name, foo)
                WriteObject(result);
            }
        }
    }
}
```

</p>
</details>

### `Update-*` cmdlet

All top-level resources should have an `Update-*` cmdlet that allows users to update an existing resource _if the API follows `PATCH` semantics_. If the API supports `PUT` semantics, then the cmdlet should be `Set-*` (see above). The user can update an existing resource by providing all identity properties, the resource id, or the object representation of the resource. Similar to the `New-*` cmdlet, properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being updated.

_Note_: if the only property that a user is able to update through the `PATCH` API is tags, then this cmdlet should not be implemented.

#### Parameter Sets

To enable the scenarios mentioned previously, the cmdlet will need three parameter sets:

```
Update-AzureRmFoo -ResourceGroupName <String> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Update-AzureRmFoo -InputObject <PSFoo> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Update-AzureRmFoo -ResourceId <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName` and `-Name` parameters, the second parameter set has a required `-InputObject` parameter, and the third parameter set has a required `-ResourceId` parameter. All three parameter sets have optional property parameters that can be used to override the value of the property set on the retrieved/provided resource.

#### C# example

<details><summary>Click to expand example</summary>
<p>

```cs
namespace Microsoft.Azure.Commands.Foo
{
    [Cmdlet(VerbsData.Update, "AzureRmFoo", DefaultParameterSet = UpdateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSFoo))]
    public class UpdateFooCommand : FooBaseCmdlet
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
        public PSFoo InputObject { get; set; }

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

            Foo foo = null;
            try
            {
                foo = this.MySDKClient.Foo.Get(this.ResourceGroupName, this.Name);
            }
            catch
            {
                foo = null;
            }

            if (foo == null)
            {
                throw new Exception(string.Format("A Foo with name '{0}' in resource group '{1}' does not exist. Please use New-AzureRmFoo to create a Foo with these properties.", this.Name, this.ResourceGroupName));
            }

            foo.Property1 = this.IsParameterBound(c => c.Property1) ? this.Property1 : foo.Property1;
            foo.Property2 = this.IsParameterBound(c => c.Property2) ? this.Property2 : foo.Property2;
            ...

            if (this.ShouldProcess(this.Name, string.Format("Updating Foo '{0}' in resource group '{1}'.", this.Name, this.ResourceGroupName)))
            {
                var result = new PSFoo(this.MySDKClient.Foo.Update(this.ResourceGroupName, this.Name, foo)
                WriteObject(result);
            }
        }
    }
}
```

</p>
</details>

## Child Resources

### `Get-*` cmdlet

All child resources should have a `Get-*` cmdlet that allows users to list the child resources under a parent resource, as well as get a specific resource. In addition, users should be able to provide the resource id of the resource they want to get, and the cmdlet will parse the string to get the necessary identity information.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need three parameter sets:

```
Get-AzureRmChildFoo -ResourceGroupName <String> -FooName <String> [-Name <String>]

Get-AzureRmChildFoo -FooObject <PSFoo> [-Name <String>]

Get-AzureRmChildFoo -ResourceId <String>
```

The first parameter set has mandatory `-ResourceGroupName` and `-FooName` parameters to get the identity information about the parent resource, and then an optional `-Name` parameter to allow the user to either list all child resources contained in the given parent or get the specific child resource. The second parameter set has required `-FooObject` parameter, which can be piped from the parent `Get-*` or `Set/Update-*` cmdlet, and an optional `-Name` parameter. The third parameter set has a required `-ResourceId` parameter, which allows the user to get a specific child resource by resource id.

#### C# example

<details><summary>Click to expand example</summary>
<p>

```cs
namespace Microsoft.Azure.Commands.Foo
{
    [Cmdlet(VerbsCommon.Get, "AzureRmChildFoo", DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(PSChildFoo))]
    public class GetChildFooCommand : FooBaseCmdlet
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FooName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = GetByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = GetByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSFoo FooObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.FooName = resourceIdentifier.ParentResource
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.FooObject))
            {
                this.ResourceGroupName = this.FooObject.ResourceGroupName;
                this.FooName = this.FooObject.Name;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                var result = new PSChildFoo(this.MySDKClient.ChildFoo.Get(this.ResourceGroupName, this.FooName, this.Name));
                WriteObject(result);
            }
            else
            {
                var result = this.MySDKClient.ChildFoo.ListByFoo(this.ResourceGroupName, this.FooName).Select(f => new PSChildFoo(f));
                WriteObject(result, true);
            }
        }
    }
}
```

</p>
</details>

### `New-*` cmdlet

All child resources should have a `New-*` cmdlet that allows users to create a child resource with given properties. Properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being created.

_Note_: for long-running operations (~15s or longer), it is advised to add the [`-AsJob`](.\azure-powershell-design-guidelines#asjob-parameter) to your cmdlet.

#### Parameter sets

To enable the above scenario, the cmdlet will need two parameter sets:

```
New-AzureRmChildFoo -ResourceGroupName <String> -FooName <String> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

New-AzureRmChildFoo -FooObject <PSFoo> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName`, `-FooName` and `-Name` parameters to satisfy the identity properties of the child resource, as well as a few optional `-PropertyX` parameters that allows the user to set values for the properties. The second parameter set has a required `-FooObject` parameter that can be piped from the parent resource's `Get-*` and `Set/Update-*` cmdlets.

#### C# example

<details><summary>Click to expand example</summary>
<p>

```cs
namespace Microsoft.Azure.Commands.Foo
{
    [Cmdlet(VerbsCommon.New, "AzureRmChildFoo", DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSChildFoo))]
    public class NewChildFooCommand : FooBaseCmdlet
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FooName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSFoo FooObject { get; set; }

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
            if (this.IsParameterBound(c => c.FooObject))
            {
                this.ResourceGroupName = this.FooObject.ResourceGroupName;
                this.FooName = this.FooObject.FooName;
            }

            ChildFoo existingFoo = null;
            try
            {
                existingChildFoo = this.MySDKClient.ChildFoo.Get(this.ResourceGroupName, this.FooName, this.Name);
            }
            catch
            {
                existingChildFoo = null;
            }

            if (existingChildFoo != null)
            {
                throw new Exception(string.Format("A ChildFoo with name '{0}' in resource group '{1}' under parent Foo '{2}' already exists. Please use Set/Update-AzureRmChildFoo to update an existing ChildFoo.", this.Name, this.ResourceGroupName, this.FooName));
            }

            existingChildFoo = new ChildFoo()
            {
                Name = this.Name,
                FooName = this.FooName,
                ResourceGroupName = this.ResourceGroupName,
                Property1 = this.Property1,
                Property2 = this.Property2,
                ...
            }

            if (this.ShouldProcess(this.Name, string.Format("Creating a new ChildFoo in resource group '{0}' under parent Foo '{1}' with name '{2}'.", this.ResourceGroupName, this.FooName, this.Name))
            {
                var result = new PSChildFoo(this.MySDKClient.ChildFoo.CreateOrUpdate(existingChildFoo));
                WriteObject(result);
            }
        }
    }
}
```

</p>
</details>

### `Remove-*` cmdlet

All child resources should have a `Remove-*` cmdlet that allows users to delete a specific child resource. The user can delete a child resource by providing all identity properties, the resource id of the child resource, or the object representation of the child resource. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the child resource actually being deleted. This cmdlet should also implement the [`-PassThru`](.\azure-powershell-design-guidelines.md#returning-no-output) parameter, which allows the user to receive the output when no output would normally be provided.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need four parameter sets:

```
Remove-AzureRmChildFoo -ResourceGroupName <String> -FooName <String> -Name <String> [-PassThru] [-WhatIf] [-Confirm]

Remove-AzureRmChildFoo -FooObject <PSFoo> -Name <String> [-PassThru] [-WhatIf] [-Confirm]

Remove-AzureRmChildFoo -InputObject <PSChildFoo> [-PassThru] [-WhatIf] [-Confirm]

Remove-AzureRmChildFoo -ResourceId <String> [-PassThru] [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName`, `-FooName` and `-Name` parameters, which allows the user to explicitly provide the identity properties of the child resource that they want to delete. The second parameter has a required `-FooObject` parameter, which allows the user to pipe the result of the parent resource's `Get-*` and `Set/Update-*` cmdlets to this cmdlet, as well as a required `-Name` parameter. The third parameter has a required `-InputObject` parameter, which allows the user to pipe the result of the `Get-*` and `Set/Update-*` cmdlets to this cmdlet and delete the corresponding child resource. The fourth parameter has a required `-ResourceId` parameter, which allows the user to delete the specific child resource by resource id.

#### C# example

<details><summary>Click to expand example</summary>
<p>

```cs
namespace Microsoft.Azure.Commands.Foo
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmChildFoo", DefaultParameterSetName = DeleteByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveChildFooCommand : FooBaseCmdlet
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
        public string FooName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = DeleteByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSFoo FooObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = DeleteByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSChildFoo InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.FooObject))
            {
                this.ResourceGroupName = this.FooObject.ResourceGroupName;
                this.FooName = this.FooObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.FooName = this.InputObject.FooName;
                this.Name = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.FooName = resourceIdentifier.ParentResource;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.ShouldProcess(this.Name, string.Format("Deleting ChildFoo '{0}' in resource group '{1}' under parent Foo '{2}'.", this.Name, this.ResourceGroupName, this.FooName)))
            {
                this.MySDKClient.ChildFoo.Delete(this.ResourceGroupName, this.FooName, this.Name);
                if (this.IsPassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
```

</p>
</details>

### `Set-*` cmdlet

All child resources should have a `Set-*` cmdlet that allows users to update an existing child resource _if the API follows `PUT` semantics_. If the API supports `PATCH` semantics, then the cmdlet should be `Update-*` (see below). The user can update an existing child resource by providing all identity properties, the resource id, or the object representation of the child resource. Similar to the `New-*` cmdlet, properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being updated.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need four parameter sets:

```
Set-AzureRmChildFoo -ResourceGroupName <String> -FooName <String> -Name <String> -Property1 <Type1> -Property2 <Type2> ... [-WhatIf] [-Confirm]

Set-AzureRmChildFoo -FooObject <PSFoo> -Name <String> -Property1 <Type1> -Property2 <Type2> ... [-WhatIf] [-Confirm]

Set-AzureRmChildFoo -InputObject <PSChildFoo> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Set-AzureRmChildFoo -ResourceId <String> -Property1 <Type1> -Property2 <Type2> ... [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName`, `-FooName` and `-Name` parameters, as well as required property parameters to set their values on the child resource. The second parameter set has a required `-FooObject` parameter, which allows the user to pipe the result of the parent resource's `Get-*` and `Set/Update-*` cmdlets to this cmdlet, as well as required property parameters. The third parameter set has a required `-InputObject` parameter, as well as optional property parameters that override the value of the property on the given object if provided. The fourth parameter set has a required `-ResourceIid` parameter, as well as required property parameters to set their values on the child resource.

#### C# example

<details><summary>Click to expand example</summary>
<p>

```cs
namespace Microsoft.Azure.Commands.Foo
{
    [Cmdlet(VerbsCommon.Set, "AzureRmChildFoo", DefaultParameterSet = SetByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSChildFoo))]
    public class SetChildFooCommand : FooBaseCmdlet
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
        public string FooName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = SetByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSFoo FooObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = SetByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSChildFoo InputObject { get; set; }

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
            if (this.IsParameterBound(c => c.FooObject))
            {
                this.ResourceGroupName = this.FooObject.ResourceGroupName;
                this.FooName = this.FooObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.FooName = this.InputObject.FooName;
                this.Name = this.InputObject.Name;
                this.Property1 = this.IsParameterBound(c => c.Property1) ? this.Property1 : this.InputObject.Property1;
                this.Property2 = this.IsParameterBound(c => c.Property2) ? this.Property2 : this.InputObject.Property2;
                ...
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.FooName = resourceIdentifier.ParentResource;
                this.Name = resourceIdentifier.ResourceName;
            }

            ChildFoo childFoo = null;
            try
            {
                childFoo = this.MySDKClient.ChildFoo.Get(this.ResourceGroupName, this.FooName, this.Name);
            }
            catch
            {
                childFoo = null;
            }

            if (childFoo == null)
            {
                throw new Exception(string.Format("A ChildFoo with name '{0}' in resource group '{1}' under parent Foo '{2}' does not exist. Please use New-AzureRmChildFoo to create a ChildFoo with these properties.", this.Name, this.ResourceGroupName, this.FooName));
            }

            childFoo.Property1 = this.Property1;
            childFoo.Property2 = this.Property2;
            ...

            if (this.ShouldProcess(this.Name, string.Format("Updating Foo '{0}' in resource group '{1}' under parent Foo '{2}'.", this.Name, this.ResourceGroupName, this.FooName)))
            {
                var result = new PSChildFoo(this.MySDKClient.ChildFoo.Update(this.ResourceGroupName, this.FooName, this.Name, childFoo)
                WriteObject(result);
            }
        }
    }
}
```

</p>
</details>

### `Update-*` cmdlet

All child resources should have an `Update-*` cmdlet that allows users to update an existing child resource _if the API follows `PATCH` semantics_. If the API supports `PUT` semantics, then the cmdlet should be `Set-*` (See above). The user can update an existing child resource by providing all identity properties, the resource id, or the object representation of the child resource. Similar to the `New-*` cmdlet, properties that are required by the API should be mandatory parameters, and in the case where different combinations of properties are needed depending on a provided value (_e.g._, Windows and Linux VMs have different properties), multiple parameter sets should be used. This cmdlet should implement `SupportsShouldProcess` to allow users to provide the `-WhatIf` parameter and see what the result of executing the cmdlet is without the resource actually being updated.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need four parameter sets:

```
Update-AzureRmChildFoo -ResourceGroupName <String> -FooName <String> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Update-AzureRmChildFoo -FooObject <PSFoo> -Name <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Update-AzureRmChildFoo -InputObject <PSChildFoo> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]

Update-AzureRmChildFoo -ResourceId <String> [-Property1 <Type1>] [-Property2 <Type2>] ... [-WhatIf] [-Confirm]
```

The first parameter set has required `-ResourceGroupName`, `-FooName` and `-Name` parameters, the second parameter set has required `-FooObject` and `-Name` parameters, the third parameter set has a required `-InputObject` parameter, and the fourth parameter set has a required `-ResourceId` parameter. All four parameter sets have optional property parameters that can be used to override the value of the property set on the retrieved/provided resource.

#### C# example

<details><summary>Click to expand example</summary>
<p>

```cs
namespace Microsoft.Azure.Commands.Foo
{
    [Cmdlet(VerbsData.Update, "AzureRmChildFoo", DefaultParameterSet = UpdateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSChildFoo))]
    public class UpdateChildFooCommand : FooBaseCmdlet
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
        public string FooName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSFoo FooObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSFoo InputObject { get; set; }

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
            if (this.IsParameterBound(c => c.FooObject))
            {
                this.ResourceGroupName = this.FooObject.ResourceGroupName;
                this.FooName = this.FooObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.FooName = this.InputObject.FooName;
                this.Name = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.FooName = resourceIdentifer.ParentResource;
                this.Name = resourceIdentifier.ResourceName;
            }

            ChildFoo childFoo = null;
            try
            {
                childFoo = this.MySDKClient.ChildFoo.Get(this.ResourceGroupName, this.FooName, this.Name);
            }
            catch
            {
                childFoo = null;
            }

            if (childFoo == null)
            {
                throw new Exception(string.Format("A ChildFoo with name '{0}' in resource group '{1}' under parent Foo '{2}' does not exist. Please use New-AzureRmChildFoo to create a ChildFoo with these properties.", this.Name, this.ResourceGroupName, this.FooName));
            }

            childFoo.Property1 = this.IsParameterBound(c => c.Property1) ? this.Property1 : childFoo.Property1;
            childFoo.Property2 = this.IsParameterBound(c => c.Property2) ? this.Property2 : childFoo.Property2;
            ...

            if (this.ShouldProcess(this.Name, string.Format("Updating Foo '{0}' in resource group '{1}' under parent Foo '{2}'.", this.Name, this.ResourceGroupName, this.FooName)))
            {
                var result = new PSChildFoo(this.MySDKClient.ChildFoo.Update(this.ResourceGroupName, this.FooName, this.Name, childFoo)
                WriteObject(result);
            }
        }
    }
}
```

</p>
</details>