# Piping in PowerShell

## Understanding Piping

In PowerShell, cmdlets pipe objects between one another; cmdlets should return objects, not text (strings).

For example, in Azure PowerShell, you can remove all of your current environments with the following pipeline scenairo:

```powershell
Get-AzureRmEnvironment | Remove-AzureRmEnviornment
```

The cmdlet `Get-AzureRmEnvironment` will return a set of `Environment` objects, and those objects will be individually piped to the `Remove-AzureRmEnvironment` cmdlet, where they will be removed.

When an object is being piped to a cmdlet, PowerShell will first check to see if it can bind that object to a parameter with the same type and has the property `ValueFromPipeline = true`. If this cannot be done, PowerShell will then see if it can bind the properties of the object with parameters that share the same name and have the property `ValueFromPipelineByPropertyName = true`.

### ValueFromPipeline

In this scenario, the object piped to the cmdlet will be bound to a parameter with the same type that has the property `ValueFromPipeline = true`.

For example, you have a `Remove-AzureRmFoo` cmdlet with the following parameter:

```cs
[Parameter(ParameterSetName = "ByInputObject", ValueFromPipeline = true)]
public PSFoo InputObject { get; set; }
```

If there is a corresponding `Get-AzureRmFoo` cmdlet that returns a `PSFoo` object, the following scenario is enabled:

```powershell
# --- Piping scenario ---
# Remove an individual PSFoo object
Get-AzureRmFoo -Name "FooName" -ResourceGroupName "RG" | Remove-AzureRmFoo

# Remove all PSFoo objects
Get-AzureRmFoo | Remove-AzureRmFoo


# --- Non-piping scenarios ---
# Remove an individual PSFoo object
$foo = Get-AzureRmFoo -Name "FooName" -ResourceGroupName "RG"
Remove-AzureRmFoo -InputObject $foo

# Remove all PSFoo objects
Get-AzureRmFoo | ForEach-Object { Remove-AzureRmFoo -InputObject $_ }
```

The `PSFoo` object(s) that is returned by the `Get-AzureRmFoo` call will be piped to the `Remove-AzureRmFoo` cmdlet, and becuase that cmdlet has a parameter that accepts a `PSFoo` object by value, PowerShell will bind the object being sent through the pipeline to this `InputObject` parameter.

### ValueFromPipelineByPropertyName

In this scenario, the properties of the object being piped to the cmdlet will be bound to parameters with the same name that have the property `ValueFromPipelineByPropertyName = true`.

For example, you have a `Remove-AzureRmFoo` cmdlet with the following parameters:

```cs
[Parameter(ParameterSetName = "ByPropertyName", ValueFromPipelineByPropertyName = true)]
public string Name { get; set; }

[Parameter(ParameterSetName = "ByPropertyName", ValueFromPipelineByPropertyName = true)]
public string ResourceGroupName { get; set; }
```

If there is a corresponding `Get-AzureRmFoo` cmdlet that returns a `PSFoo` object (that has properties `Name` and `ResourceGroupName`), the following scenario is enabled:

```powershell
# --- Piping scenario ---
# Remove an individual PSFoo object
Get-AzureRmFoo -Name "FooName" -ResourceGroupName "RG" | Remove-AzureRmFoo

# Remove all PSFoo objects
Get-AzureRmFoo | Remove-AzureRmFoo


# --- Non-piping scenario ---
# Remove an individual PSFoo object
$foo = Get-AzureRmFoo -Name "FooName" -ResourceGroupName "RG"
Remove-AzureRmFoo -Name $foo.Name -ResourceGroupName $foo.ResourceGroupName

# Remove all PSFoo objects
Get-AzureRmFoo | ForEach-Object { Remove-AzureRmFoo -Name $_.Name -ResourceGroupName $_.ResourceGroupName }
```

The `PSFoo` object(s) that is returned by the `Get-AzureRmFoo` call will be piped to the `Remove-AzureRmFoo` cmdlet, and because that cmdlet has parameters that accept their value from the pipeline by property name, PowerShell will check each of these parameters and see if it can find a corresponding property in the `PSFoo` object that it shares a name with, and bind the value.

### Writing to the Pipeline

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

## Azure PowerShell Piping Scenarios

There are two main scenarios that we wish to enable in cmdlets for Azure PowerShell:
- piping by value using an `InputObject` parameter
- piping by property name using a `ResourceId` parameter

### Using the `InputObject` parameter

This scenario should be used when piping objects around within the same module. For example, if you have a set of `Get-AzureRmFoo`, `Remove-AzureRmFoo`, and `Set-AzureRmFoo` cmdlets, the `Remove-AzureRmFoo` and `Set-AzureRmFoo` cmdlets should have a parameter set that takes the `InputObject` parameter of type `PSFoo` so that a user can do the following:

```powershell
# --- Piping scenario ---
# Setting and removing an individual object
Get-AzureRmFoo -Name "FooName" -ResourceGroupName "RG" | Set-AzureRmFoo <additional parameters>
Get-AzureRmFoo -Name "FooName" -ResourceGroupName "RG" | Remove-AzureRmFoo

# Setting and removing a collection of objects
Get-AzureRmFoo | Set-AzureRmFoo <additional parameters>
Get-AzureRmFoo | Remove-AzureRmFoo


# --- Non-piping scenario ---
# Setting and removing an individual object
$foo = Get-AzureRmFoo -Name "FooName" -ResourceGroupName "RG"
Set-AzureRmFoo -InputObject $foo <additional parameters>
Remove-AzureRmFoo -InputObject $foo

# Setting and removing a collection of objects
Get-AzureRmFoo | ForEach-Object { Set-AzureRmFoo -InputObject $_ <additional parameters> }
Get-AzureRmFoo | ForEach-Object { Remove-AzureRmFoo -InputObject $_ }
```

Another time that this scenario applies is when you have cmdlets for child resources that need information about the parent (top-level) resource. For example you can pipe in the whole parent object to the `New-AzureRmFooBar` and `Get-AzureRmFooBar` cmdlets to get the child resources, and then pipe the child resource object to the `Remove-AzureRmFooBar` and `Set-AzureRmFooBar` cmdlets.

```powershell
# --- Piping scenario ---
# Getting all of child resources from all of the parent resources and removing them
Get-AzureRmFoo | Get-AzureRmFooBar | Remove-AzureRmFooBar

# Getting all of the child resources from all of the parent resources in a resource group and removing them
Get-AzureRmFoo -ResourceGroupName "RG" | Get-AzureRmFooBar | Remove-AzureRmFooBar

# Getting all of the child resources from a specific parent resource and removing them
Get-AzureRmFoo -ResourceGroupName "RG" -Name "FooName" | Get-AzureRmFooBar | Remove-AzureRmFooBar


# --- Non-piping scenario ---
# Getting all of the child resources from a specific parent resource and removing them
$foo = Get-AzureRmFoo -ResourceGroupName "RG" -Name "FooName"
$fooBar = Get-AzureRmFooBar -InputObject $foo
Remove-AzureRmFooBar -InputObject $fooBar
```

### Using the `ResourceId` parameter

In this scenario, we are using the generic cmdlets found in the `AzureRM.Resources` module. These cmdlets, `Find-AzureRmResource` and `Get-AzureRmResource`, return a `PSCustomObject` that has a `ResourceId` property, which is the unique identifier for the given resource. Since this identifier can parsed to get the name and resource group name for a top-level resource, we can create a parameter set that has a `ResourceId` parameter that accepts its value from the pipeline by property name, allowing us to accept piping from these generic cmdlets.

```powershell
# --- Piping scenario ---
# Remove all Foo objects in the current subscription
Find-AzureRmResource -ResourceType Microsoft.Foo/foo | Remove-AzureRmFoo

# Remove all Foo objects in a given resource group
Find-AzureRmResource -ResourceType Microsoft.Foo/foo -ResourceGroupEquals "RG" | Remove-AzureRmFoo

# Remove a specific Foo object
Find-AzureRmResource -ResourceGroupEquals "RG" -ResourceNameEquals "FooName" | Remove-AzureRmFoo


# -- Non-piping scenario ---
# Removing all Foo objects in the current subscription
Find-AzureRmResource -ResourceType Microsoft.Foo/foo | ForEach-Object { Remove-AzureRmFoo -ResourceId $_.ResourceId }

# Remove all Foo objects in a given resource group
Find-AzureRmResource -ResourceType Microsoft.Foo/foo -ResourceGroupEquals "RG" | ForEach-Object { Remove-AzureRmFoo -ResourceId $_.ResourceId }

# Remove a specific Foo object
Find-AzureRmResource -ResourceGroupEquals "RG" -ResourceNameEquals "FooName" | ForEach-Object { Remove-AzureRmFoo -ResourceId $_.ResourceId }
```

To implement this scenario, please see the [`ResourceIdentifier`](https://github.com/Azure/azure-powershell/blob/preview/src/ResourceManager/Common/Commands.ResourceManager.Common/Utilities/Models/ResourceIdentifier.cs) class in the `Commands.ResourceManager.Common` project. This class will allow you to create a `ResourceIdentifier` object that accepts a `ResourceId` string in its constructor and has properties `ResourceName`, `ResourceGroupName`, and others.

## More Information

For more information on piping, see the article ["Understanding the Windows PowerShell Pipeline"](https://msdn.microsoft.com/en-us/powershell/scripting/getting-started/fundamental/understanding-the-windows-powershell-pipeline).