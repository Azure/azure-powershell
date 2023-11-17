# Piping Best Practices

_Note_: for the below examples, the string "TopLevelResource" would be replaced with the name of your top-level resource (_e.g._, "VirtualMachine", "VirtualNetwork", "SqlServer"), and the string "ChildResource" would be replaced with the name of your child resource (_e.g._, "VirtualMachineExtension", "VirtualNetworkPeering", "SqlDatabase")

## Piping in PowerShell

### Understanding Piping

In PowerShell, cmdlets pipe objects between one another; cmdlets should return objects, not text (strings).

For example, in Azure PowerShell, you can remove all of your current environments with the following pipeline scenairo:

```powershell
Get-AzEnvironment | Remove-AzEnviornment
```

The cmdlet `Get-AzEnvironment` will return a set of `Environment` objects, and those objects will be individually piped to the `Remove-AzEnvironment` cmdlet, where they will be removed.

When an object is being piped to a cmdlet, PowerShell will first check to see if it can bind the input object to a parameter with the same type and has the property `ValueFromPipeline = true`. If no parameters are bound at this point, PowerShell will do the same check for parameters with the `ValueFromPipeline = true` parameter, but it will see if it can convert the input object to the type of the parameter. If no parameters are bound at this point, PowerShell will then see if it can bind the properties of the input object with parameters that share the same name and have the property `ValueFromPipelineByPropertyName = true` that are all in the same parameter set.

For more information on piping, see the article [_Understanding pipelines_](https://learn.microsoft.com/en-us/powershell/scripting/learn/understanding-the-powershell-pipeline).

## Piping in Azure PowerShell

There are two main scenarios that we wish to enable in cmdlets for Azure PowerShell:
- piping by value using an `-InputObject` parameter
- piping by property name using a `-ResourceId` parameter

### Using the `-InputObject` Parameter

#### Short explanation
For all resources, `-InputObject` should be implemented for at least the `Remove-*`, `Set-*` and `Update-*` cmdlets (and any other cmdlet where an existing resource is being operated on, such as `Start-*`, `Stop-*`, etc.). The implementation of this will be a new parameter set, like the following:

```
Remove-AzTopLevelResource -InputObject <PSTopLevelResource> [...] [-PassThru] [-WhatIf] [-Confirm]
```

For all child resources, the same functionality should be added for the cmdlets above, but will also include an additional parameter set for the parent resource's object.  The implementation of this will be two new parameter sets, like the following:

```
Remove-AzChildResource -InputObject <PSChildResource> [...] [-PassThru] [-WhatIf] [-Confirm]

Remove-AzChildResource -TopLevelResourceObject <PSTopLevelResource> -Name <String> [...] [-PassThru] [-WhatIf] [-Confirm]
```

#### Long explanation
This scenario should be used when piping objects around within the same module. For example, if you have a set of `Get-AzTopLevelResource`, `Remove-AzTopLevelResource`, and `Set-AzTopLevelResource` cmdlets, the `Remove-AzTopLevelResource` and `Set-AzTopLevelResource` cmdlets should have a parameter set that takes the `-InputObject` parameter of type `PSTopLevelResource` so that a user can do the following:

```powershell
# --- Piping scenario ---
# Setting and removing an individual object
Get-AzTopLevelResource -ResourceGroupName "MyResourceGroup" -Name "MyTopLevelResource" | Set-AzTopLevelResource @additionalParams
Get-AzTopLevelResource -ResourceGroupName "MyResourceGroup" -Name "MyTopLevelResource" | Remove-AzTopLevelResource

# Setting and removing a collection of objects
Get-AzTopLevelResource | Set-AzTopLevelResource @additionalParams
Get-AzTopLevelResource | Remove-AzTopLevelResource


# --- Non-piping scenario ---
# Setting and removing an individual object
$resource = Get-AzTopLevelResource -ResourceGroupName "MyResourceGroup" -Name "MyTopLevelResource"
Set-AzTopLevelResource -InputObject $resource @additionalParams
Remove-AzTopLevelResource -InputObject $resource

# Setting and removing a collection of objects
Get-AzTopLevelResource | ForEach-Object { Set-AzTopLevelResource -InputObject $_ @additionalParams }
Get-AzTopLevelResource | ForEach-Object { Remove-AzTopLevelResource -InputObject $_ }
```

Another time that this scenario applies is when you have cmdlets for child resources that need information about the parent (top-level) resource. For example you can pipe in the whole parent object to the `New-AzChildResource` and `Get-AzChildResource` cmdlets to get the child resources, and then pipe the child resource object to the `Remove-AzChildResource` and `Set-AzChildResource` cmdlets.

```powershell
# --- Piping scenario ---
# Getting all of child resources from all of the parent resources and removing them
Get-AzTopLevelResource | Get-AzChildResource | Remove-AzChildResource

# Getting all of the child resources from all of the parent resources in a resource group and removing them
Get-AzTopLevelResource -ResourceGroupName "MyResourceGroup" | Get-AzChildResource | Remove-AzChildResource

# Getting all of the child resources from a specific parent resource and removing them
Get-AzTopLevelResource -ResourceGroupName "MyResourceGroup" -Name "MyTopLevelResource" | Get-AzChildResource | Remove-AzChildResource


# --- Non-piping scenario ---
# Getting all of the child resources from a specific parent resource and removing them
$resource = Get-AzTopLevelResource -ResourceGroupName "MyResourceGroup" -Name "MyTopLevelResource"
$childResource = Get-AzChildResource -InputObject $resource
Remove-AzChildResource -InputObject $childResource
```

### Using the `-ResourceId` Parameter

#### Short explanation
For all resources, `-ResourceId` should be implemented for the `Get-*`, `Remove-*`, `Set-*` and `Update-*` cmdlets (and any other cmdlet where an existing resource is being operated on, such as `Start-*`, `Stop-*`, etc.). The implementation of this will be a new parameter set, like the following:

```
Remove-AzTopLevelResource -ResourceId <string> [...] [-PassThru] [-WhatIf] [-Confirm]
```

#### Long explanation

In this scenario, we are using the generic cmdlet, `Get-AzResource`, found in the `Az.Resources` module. This cmdlet returns a `PSResource` that has a `ResourceId` property, which is the unique identifier for the given resource. Since this identifier can parsed to get the name and resource group name for a top-level resource (as well as the child resource name), we can create a parameter set that has a `-ResourceId` parameter that accepts its value from the pipeline by property name, allowing us to accept piping from these generic cmdlets.

```powershell
# --- Piping scenario ---
# Remove all TopLevelResource objects in the current subscription
Get-AzResource -ResourceType "Microsoft.SomeProvider/topLevelResource" | Remove-AzTopLevelResource

# Remove all TopLevelResource objects in a given resource group
Get-AzResource -ResourceType "Microsoft.SomeProvider/topLevelResource" -ResourceGroupEquals "MyResourceGroup" | Remove-AzTopLevelResource

# Remove a specific TopLevelResource object
Get-AzResource -ResourceType "Microsoft.SomeProvider/topLevelResource" -ResourceGroupEquals "MyResourceGroup" -Name "MyTopLevelResource" | Remove-AzTopLevelResource


# -- Non-piping scenario ---
# Removing all TopLevelResource objects in the current subscription
Get-AzResource -ResourceType "Microsoft.SomeProvider/topLevelResource" | ForEach-Object { Remove-AzTopLevelResource -ResourceId $_.ResourceId }

# Remove all TopLevelResource objects in a given resource group
Get-AzResource -ResourceType "Microsoft.SomeProvider/topLevelResource" -ResourceGroupEquals "MyResourceGroup" | ForEach-Object { Remove-AzTopLevelResource -ResourceId $_.ResourceId }

# Remove a specific TopLevelResource object
Get-AzResource -ResourceType "Microsoft.SomeProvider/topLevelResource" -ResourceGroupEquals "MyResourceGroup" -ResourceNameEquals "MyTopLevelResource" | ForEach-Object { Remove-AzTopLevelResource -ResourceId $_.ResourceId }
```

To implement this scenario, please see the [`ResourceIdentifier`](https://github.com/Azure/azure-powershell-common/blob/52fc157798d0fdd83f20755106e131aec1689ceb/src/ResourceManager/Version2016_09_01/Utilities/Models/ResourceIdentifier.cs) class in the `ResourceManager` project. This class will allow you to create a `ResourceIdentifier` object that accepts a `ResourceId` string in its constructor and has properties `ResourceName`, `ResourceGroupName`, and others.

### Full examples

The following cmdlet examples containing these piping scenarios can be found in [this folder](../examples):

- [`Get-*` cmdlet](../examples/get-cmdlet-example.md)
- [`New-*` cmdlet](../examples/new-cmdlet-example.md)
- [`Remove-*` cmdlet](../examples/remove-cmdlet-example.md)
- [`Set-*` cmdlet](../examples/set-cmdlet-example.md)
- [`Update-*` cmdlet](../examples/update-cmdlet-example.md)