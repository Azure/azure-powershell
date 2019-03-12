# Piping Best Practices

## Piping in PowerShell

### Understanding Piping

In PowerShell, cmdlets pipe objects between one another; cmdlets should return objects, not text (strings).

For example, in Azure PowerShell, you can remove all of your current environments with the following pipeline scenairo:

```powershell
Get-AzEnvironment | Remove-AzEnviornment
```

The cmdlet `Get-AzEnvironment` will return a set of `Environment` objects, and those objects will be individually piped to the `Remove-AzEnvironment` cmdlet, where they will be removed.

When an object is being piped to a cmdlet, PowerShell will first check to see if it can bind that object to a parameter with the same type and has the property `ValueFromPipeline = true`. If this cannot be done, PowerShell will then see if it can bind the properties of the object with parameters that share the same name and have the property `ValueFromPipelineByPropertyName = true`.

#### `ValueFromPipeline` property

In this scenario, the object piped to the cmdlet will be bound to a parameter with the same type that has the property `ValueFromPipeline = true`.

For example, you have a `Remove-AzFoo` cmdlet with the following parameter:

```cs
[Parameter(ParameterSetName = "ByInputObject", ValueFromPipeline = true)]
public PSFoo InputObject { get; set; }
```

If there is a corresponding `Get-AzFoo` cmdlet that returns a `PSFoo` object, the following scenario is enabled:

```powershell
# --- Piping scenario ---
# Remove an individual PSFoo object
Get-AzFoo -Name "FooName" -ResourceGroupName "RG" | Remove-AzFoo

# Remove all PSFoo objects
Get-AzFoo | Remove-AzFoo


# --- Non-piping scenarios ---
# Remove an individual PSFoo object
$foo = Get-AzFoo -Name "FooName" -ResourceGroupName "RG"
Remove-AzFoo -InputObject $foo

# Remove all PSFoo objects
Get-AzFoo | ForEach-Object { Remove-AzFoo -InputObject $_ }
```

The `PSFoo` object(s) that is returned by the `Get-AzFoo` call will be piped to the `Remove-AzFoo` cmdlet, and becuase that cmdlet has a parameter that accepts a `PSFoo` object by value, PowerShell will bind the object being sent through the pipeline to this `-InputObject` parameter.

#### `ValueFromPipelineByPropertyName` property

In this scenario, the properties of the object being piped to the cmdlet will be bound to parameters with the same name that have the property `ValueFromPipelineByPropertyName = true`.

For example, you have a `Remove-AzFoo` cmdlet with the following parameters:

```cs
[Parameter(ParameterSetName = "ByPropertyName", ValueFromPipelineByPropertyName = true)]
public string ResourceId { get; set; }
```

If there is a corresponding `Get-AzFoo` cmdlet that returns a `PSFoo` object (that has properties `Name` and `ResourceGroupName`), the following scenario is enabled:

```powershell
# --- Piping scenario ---
# Remove an individual PSFoo object
Get-AzResource -ResourceId <resourceId> | Remove-AzFoo

# Remove all PSFoo objects
Get-AzResource -ResourceType Foo | Remove-AzFoo


# --- Non-piping scenario ---
# Remove an individual PSFoo object
$foo = Get-AzResource -ResourceId <resourceId>
Remove-AzFoo -ResourceId <resourceId>

# Remove all PSFoo objects
Get-AzFoo | ForEach-Object { Remove-AzFoo -ResourceId <resourceId> }
```

The `PSFoo` object(s) that is returned by the `Get-AzFoo` call will be piped to the `Remove-AzFoo` cmdlet, and because that cmdlet has parameters that accept their value from the pipeline by property name, PowerShell will check each of these parameters and see if it can find a corresponding property in the `PSFoo` object that it shares a name with, and bind the value.

#### Writing to the Pipeline

To write to the pipeline, use the `WriteObject` method from the `AzurePSCmdlet` class in the `Commands.Common` project. If you are writing **only one** object to the pipeline, then you should use the overload `WriteObject(object sendToPipeline)`, but if you are writing **more than one** objects to the pipeline, you should use the overload `WriteObject(object sendToPipeline, bool enumerateCollection)`.

If you use the `WriteObject(object sendToPipeline)` overload when writing a collection of objects to the pipeline, this will cause errors in the piping scenario, specifically, it will pipe a collection to the next cmdlet, rather than the individual objects.

```cs
public override void ExecuteCmdlet()
{
    if (!string.IsNullOrEmpty(this.Name))
    {
        // If the Name is not empty, write a single object to the pipeline
        var result = client.Foo.List(this.Name);
        WriteObject(result);
    }
    else
    {
        // If the Name is empty, write a collection of objects to the pipeline
        var result = client.Foo.List();
        WriteObject(result, true);
    }
}
```

### More Information

For more information on piping, see the article [_Understanding pipelines_](https://docs.microsoft.com/en-us/powershell/scripting/learn/understanding-the-powershell-pipeline).

## Piping in Azure PowerShell

There are two main scenarios that we wish to enable in cmdlets for Azure PowerShell:
- piping by value using an `-InputObject` parameter
- piping by property name using a `-ResourceId` parameter

### Using the `-InputObject` Parameter

#### Short explanation
For all resources, `-InputObject` should be implemented for at least the `Remove-*`, `Set-*` and `Update-*` cmdlets (and any other cmdlet where an existing resource is being operated on, such as `Start-*`, `Stop-*`, etc.). The implementation of this will be a new parameter set, like the following:

```
Remove-AzSampleResource -InputObject <PSSampleResource> [...] [-PassThru] [-WhatIf] [-Confirm]
```

For all child resources, the same functionality should be added for the cmdlets above, but for `Get-*` and `New-*` cmdlets, rather than using the `-InputObject` parameter, a separate object parameter should be added to allow piping the object representation of the parent resource.  The implementation of this will be a new parameter set, like the following:

```
Get-AzChildResource -TopLevelResourceObject <PSTopLevelResource> [...]
```

#### Long explanation
This scenario should be used when piping objects around within the same module. For example, if you have a set of `Get-AzFoo`, `Remove-AzFoo`, and `Set-AzFoo` cmdlets, the `Remove-AzFoo` and `Set-AzFoo` cmdlets should have a parameter set that takes the `-InputObject` parameter of type `PSFoo` so that a user can do the following:

```powershell
# --- Piping scenario ---
# Setting and removing an individual object
Get-AzFoo -Name "FooName" -ResourceGroupName "RG" | Set-AzFoo @additionalParams
Get-AzFoo -Name "FooName" -ResourceGroupName "RG" | Remove-AzFoo

# Setting and removing a collection of objects
Get-AzFoo | Set-AzFoo @additionalParams
Get-AzFoo | Remove-AzFoo


# --- Non-piping scenario ---
# Setting and removing an individual object
$foo = Get-AzFoo -Name "FooName" -ResourceGroupName "RG"
Set-AzFoo -InputObject $foo @additionalParams
Remove-AzFoo -InputObject $foo

# Setting and removing a collection of objects
Get-AzFoo | ForEach-Object { Set-AzFoo -InputObject $_ @additionalParams }
Get-AzFoo | ForEach-Object { Remove-AzFoo -InputObject $_ }
```

Another time that this scenario applies is when you have cmdlets for child resources that need information about the parent (top-level) resource. For example you can pipe in the whole parent object to the `New-AzFooBar` and `Get-AzFooBar` cmdlets to get the child resources, and then pipe the child resource object to the `Remove-AzFooBar` and `Set-AzFooBar` cmdlets.

```powershell
# --- Piping scenario ---
# Getting all of child resources from all of the parent resources and removing them
Get-AzFoo | Get-AzFooBar | Remove-AzFooBar

# Getting all of the child resources from all of the parent resources in a resource group and removing them
Get-AzFoo -ResourceGroupName "RG" | Get-AzFooBar | Remove-AzFooBar

# Getting all of the child resources from a specific parent resource and removing them
Get-AzFoo -ResourceGroupName "RG" -Name "FooName" | Get-AzFooBar | Remove-AzFooBar


# --- Non-piping scenario ---
# Getting all of the child resources from a specific parent resource and removing them
$foo = Get-AzFoo -ResourceGroupName "RG" -Name "FooName"
$fooBar = Get-AzFooBar -InputObject $foo
Remove-AzFooBar -InputObject $fooBar
```

### Using the `-ResourceId` Parameter

#### Short explanation
For all resources, `-ResourceId` should be implemented for the `Remove-*`, `Set-*` and `Update-*` cmdlets (and any other cmdlet where an existing resource is being operated on, such as `Start-*`, `Stop-*`, etc.). The implementation of this will be a new parameter set, like the following:

```
RemoveAzSampleResource -ResourceId <string> [...] [-PassThru] [-WhatIf] [-Confirm]
```

#### Long explanation

In this scenario, we are using the generic cmdlets found in the `Az.Resources` module. These cmdlets, `Find-AzResource` and `Get-AzResource`, return a `PSCustomObject` that has a `ResourceId` property, which is the unique identifier for the given resource. Since this identifier can parsed to get the name and resource group name for a top-level resource, we can create a parameter set that has a `ResourceId` parameter that accepts its value from the pipeline by property name, allowing us to accept piping from these generic cmdlets.

```powershell
# --- Piping scenario ---
# Remove all Foo objects in the current subscription
Get-AzResource -ResourceType Microsoft.Foo/foo | Remove-AzFoo

# Remove all Foo objects in a given resource group
Get-AzResource -ResourceType Microsoft.Foo/foo -ResourceGroupEquals "RG" | Remove-AzFoo

# Remove a specific Foo object
Get-AzResource -ResourceGroupEquals "RG" -ResourceNameEquals "FooName" | Remove-AzFoo


# -- Non-piping scenario ---
# Removing all Foo objects in the current subscription
Get-AzResource -ResourceType Microsoft.Foo/foo | ForEach-Object { Remove-AzFoo -ResourceId $_.ResourceId }

# Remove all Foo objects in a given resource group
Get-AzResource -ResourceType Microsoft.Foo/foo -ResourceGroupEquals "RG" | ForEach-Object { Remove-AzFoo -ResourceId $_.ResourceId }

# Remove a specific Foo object
Get-AzResource -ResourceGroupEquals "RG" -ResourceNameEquals "FooName" | ForEach-Object { Remove-AzFoo -ResourceId $_.ResourceId }
```

To implement this scenario, please see the [`ResourceIdentifier`](https://github.com/Azure/azure-powershell-common/blob/52fc157798d0fdd83f20755106e131aec1689ceb/src/ResourceManager/Version2016_09_01/Utilities/Models/ResourceIdentifier.cs) class in the `ResourceManager` project. This class will allow you to create a `ResourceIdentifier` object that accepts a `ResourceId` string in its constructor and has properties `ResourceName`, `ResourceGroupName`, and others.

### Summary
For all `Remove-*`, `Set-*` and `Update-*` cmdlets (and any other cmdlet where an existing resource is being operated on, such as `Start-*`, `Stop-*`, etc.), you will have three parameter sets (and potentially a multiple of three if you have initially have multiple parameter sets):

```
Remove-AzSampleResource -ResourceGroupName <string> -Name <string> [...] [-PassThru] [-WhatIf] [-Confirm]

Remove-AzSampleResource -InputObject <PSSampleResource> [...] [-PassThru] [-WhatIf] [-Confirm]

Remove-AzSampleResource -ResourceId <string> [...] [-PassThru] [-WhatIf] [-Confirm]
```

For child resources, there will be the following three parameter sets for `Remove-*`:

```
Remove-AzChildResource -ResourceGroupName <string> -TopLevelResourceName <string> -Name <string> [...] [-PassThru] [-WhatIf] [-Confirm]

Remove-AzChildResource -InputObject <PSTopLevelResource> [...] [-PassThru] [-WhatIf] [-Confirm]

Remove-AzChildResource -ResourceId <string> [...] [-PassThru] [-WhatIf] [-Confirm]
```

For all child resources, `Get-*` cmdlets will also the following three parameter sets:

```
Get-AzChildResource -ResourceGroupName <string> -TopLevelResourceName <string> [-Name <string>] [...]

Get-AzChildResource -TopLevelResourceObject <PSTopLevelResource> [...]

Get-AzChildResource -ResourceId <string> [...]
```