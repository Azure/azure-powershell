# Azure PowerShell Design Guidelines

## Table of Contents

- [Cmdlet Guidelines](#cmdlet-guidelines)
    - [Cmdlet Naming Conventions](#cmdlet-naming-conventions)
        - [Verb-Noun Format](#verb-noun-format)
        - [Pascal Case](#pascal-case)
        - [Noun Prefix](#noun-prefix)
        - [Specific Noun](#specific-noun)
        - [Noun Singularity](#noun-singularity)
        - [Set vs. Update](#set-vs-update)
        - [Cmdlet Alias](#cmdlet-alias)
    - [Output Type](#output-type)
        - [Returning Wrapped SDK Types](#returning-wrapped-sdk-types)
        - [Returning No Output](#returning-no-output)
    - [ShouldProcess](#should-process)
        - [When to Add the Force Parameter](#when-to-add-the-force-parameter)
- [Parameter Guidelines](#parameter-guidelines)
    - [Parameter Naming Conventions](#parameter-naming-conventions)
        - [Standard Parameter Name](#standard-parameter-name)
        - [Pascal Case](#pascal-case)
        - [Singularity](#singularity)
        - [Parameter Alias](#parameter-alias)
    - [Bool vs. SwitchParameter](#bool-vs-switchparameter)
    - [Closed Set of Values](#closed-set-of-values)
    - [Consistent Parameter Types](#consistent-parameter-types)
- [Parameter Set Guidelines](#parameter-set-guidelines)
    - [Parameter Set Naming Conventions](#parameter-set-naming-conventions)
        - [Pascal Case](#pascal-case)
    - [Attribute Guidelines](#attribute-guidelines)
        - [Mutually Exclusive Parameter Sets](#mutually-exclusive-parameter-sets)
        - [Positional Parameters Limit](#positional-parameters-limit)
        - [ValueFromPipeline Limit](#valuefrompipeline-limit)
    - [Required Parameter Sets](#required-parameter-sets)
        - [Interactive Parameter Set](#interactive-parameter-set)
        - [ResourceId Parameter Set](#resourceid-parameter-set)
        - [InputObject Parameter Set](#inputobject-parameter-set)
- [Piping Guidelines](#piping-guidelines)
    - [ResourceId](#resourceid)
    - [InputObject](#inputobject)
- [AsJob Parameter](#asjob-parameter)

## Cmdlet Guidelines

### Cmdlet Naming Conventions

The following are naming conventions to keep in mind when coming up with a name for your cmdlet.

#### Verb-Noun Format

Cmdlet names should follow the _Verb-Noun_ format, where the verb is from the [list of approved PowerShell verbs](https://msdn.microsoft.com/en-us/library/ms714428(v=vs.85).aspx), and the noun is a specific noun describing a resource within your service.

#### Pascal Case

From the [Strongly Encouraged Development Guidelines](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx):

> _Use Pascal case for cmdlet names. In other words, capitalize the first letter of the verb and all terms used in the noun. For example, "Clear-ItemProperty"._

#### Noun Prefix

For ARM cmdlets, the noun must be prefixed with `AzureRm`. For RDFE and data plane cmdlets, the noun must be prefixed with `Azure`.

#### Specific Noun

From the [Strongly Encouraged Development Guidelines](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx):

> _Nouns used in cmdlet naming need to be very specific so that the user can discover your cmdlets. Prefix generic nouns such as "server" with a shortened version of the product name. For example, if a noun refers to a server that is running an instance of Microsoft SQL Server, use a noun such as "SQLServer". The combination of specific nouns and the short list of approved verbs enable the user to quickly discover and anticipate functionality while avoiding duplication among cmdlet names._

#### Noun Singularity

Similar to parameters (mentioned below), avoid using plural nouns when naming cmdlets. From the [Strongly Encouraged Development Guidelines](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx):

> _Avoid using plural names for parameters whose value is a single element. This includes parameters that take arrays or lists because the user might supply an array or list with only one element._
>
>_Plural parameter names should be used only in those cases where the value of the parameter is always a multiple-element value. In these cases, the cmdlet should verify that multiple elements are supplied, and the cmdlet should display a warning to the user if multiple elements are not supplied._

#### Set vs. Update

If your cmdlet is performing a **PATCH** operation (_i.e._, a partial replacement on the server), then the cmdlet should use the verb `Update`.

If your cmdlet is performing a **PUT** operation (_i.e._, a full replacement on the server), the the cmdlet should use the verb `Set`.

#### Cmdlet Alias

If you there is a separate nomenclature for your service and/or resource, or if you would like to shorten the name of the cmdlet so it's easier to remember, you can add an alias attribute to your cmdlet to allow for this functionality.

### Output Type

Specified by the `OutputType` attribute, this piece of metadata lets the user know what the type of the object returned by the cmdlet is (found in the **Outputs** section of a cmdlet's help content).

#### Returning Wrapped SDK Types

In most cases, cmdlets will be returning an object corresponding to a resource(s) that a user is performing an action on. Rather than returning the .NET SDK type for that resource (exposing .NET SDK types in PowerShell cmdlets is _strongly_ discouraged), we suggest creating a new class that wraps this .NET SDK type, allowing for breaking changes in the underlying type while avoiding breaking changes in the PowerShell type.

For example, the `Get-AzureRmVM` cmdlet uses the .NET SDK to retrieve objects of the `VirtualMachine` type, but a new class, `PSVirtualMachine`, was created to wrap the type from the .NET SDK, and is returned by the cmdlet. If, in the future, the `VirtualMachine` type in the .NET SDK has a property removed, that property can still be maintained in PowerShell by adding it to the `PSVirtualMachine` and recreating the value, thus avoiding a breaking change in the cmdlet(s).

#### Returning No Output

In the case where your cmdlet doesn't return any output (_e.g._, removing, starting, stopping a resource), the cmdlet should implement the `PassThru` parameter and the `OutputType` should be set to `bool`. The `PassThru` parameter is a `SwitchParameter` set by the user to signal that they would like to receive output from a cmdlet which does not return anything. If the `PassThru` parameter is provided, you should return the value `true` so the user is made aware that the operation was successful. If the operation was unsuccessful, then the cmdlet should throw an exception.

### ShouldProcess

If a cmdlet makes any changes to an object on the server (_e.g._, create, delete, update, start, stop a resource), the cmdlet should implement `ShouldProcess`. This property adds the `WhatIf` and `Confirm` parameters to the cmdlet: `WhatIf` is a `SwitchParameter` that, when provided by the user, doesn't execute the part of the cmdlet responsible for making the changes to the object, but rather displays a message alerting the user of the action that is to be performed on the object; `Confirm` is a `SwitchParameter` that, when provided by the user, prompts the user for confirmation that they want to continue with the execution of the cmdlet.

More information about `ShouldProcess` can be found in the [Should Process and Confirm Impact](./should-process-confirm-impact.md) document.

#### When to Add the Force Parameter

The `Force` parameter is reserved for special scenarios where additional confirmation from the user is required. From the above document on [Should Process and Confirm Impact](./should-process-confirm-impact.md) document:

> _Some cmdlets required additional confirmation. For example, if a cmdlet would destroy existing resources in some circumstances, the cmdlet might detect that condition and prompt the user to verify before continuing. Overwriting an existing resource during resource creation, overwriting a file when downloading data, deleting a resource that is currently in use, or deleting a container that contains additional resources are all example of this pattern. To implement additional confirmation, and allow scripts to opt out of additional prompts, the above pattern is enhanced with calles to `ShouldContinue()` and the `Force` parameter._

## Parameter Guidelines

### Parameter Naming Conventions

The following are naming conventions to keep in mind when coming up with a name for your parameters.

In addition, a recommended list of parameter names can be found [here](https://msdn.microsoft.com/en-us/library/ms714468(v=vs.85).aspx).

#### Standard Parameter Name

From the [Strongly Encouraged Development Guidelines](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx):

> _Your cmdlet should use standard parameter names so that the user can quickly determine what a particular parameter means. If a more specific name is required, use a standard parameter name, and then specify a more specific name as an alias. For example, the `Get-Service` cmdlet has a parameter that has a generic name (**Name**) and a more specific alias (**ServiceName**). Both terms can be used to specify the parameter._

#### Pascal Case

Similar to cmdlets (mentioned above), parameters should follow pascal casing.From the [Strongly Encouraged Development Guidelines](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx):

> _Use Pascal case for cmdlet names. In other words, capitalize the first letter of the verb and all terms used in the noun. For example, "Clear-ItemProperty"._

#### Singularity

From the [Strongly Encouraged Development Guidelines](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx):

> _Avoid using plural names for parameters whose value is a single element. This includes parameters that take arrays or lists because the user might supply an array or list with only one element._
>
>_Plural parameter names should be used only in those cases where the value of the parameter is always a multiple-element value. In these cases, the cmdlet should verify that multiple elements are supplied, and the cmdlet should display a warning to the user if multiple elements are not supplied._

#### Parameter Alias

If you there is a separate nomenclature for the parameter name, or if you would like to shorten the name of the parameter so it's easier to remember, you can add an alias attribute to your parameter to allow for this functionality.

### Bool vs. SwitchParameter

Parameters of type `bool` are _strongly_ discouraged in PowerShell. The `SwitchParameter` type of a parameter acts a flag that signals whether or not some action should be taken based on if the parameter was provided or not. From the [Strongly Encouraged Development Guidelines](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx):

> _If your parameter takes only true and false, define the parameter as type SwitchParameter. A switch parameter is treated as true when it is specified in a command. If the parameter is not included in a command, Windows PowerShell considers the value of the parameter to be false. Do not define Boolean parameters._

### Closed Set of Values

If there is a closed set of values applicable for a given parameter, use either a `ValidateSet`, enumeration type, or an `ArgumentCompleter`. This functionality allows users to tab through the different values they can provide. From the [Strongly Encouraged Development Guidelines](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx):

> _There are two ways to create a parameter whose value can be selected from a set of options._
> 
> - _Define an enumeration type (or use an existing type) that specifies the valid values. Then, use the enumeration type to create a parameter of that type._
> - _Add the **ValidateSet** attribute to the parameter declaration._

In addition, you can choose to add an `ArgumentCompleter` to a parameter to allow users to tab through a closed set of values, _but this does not restrict users on the values they can provide._ For more information on `ArgumentCompleters`, please see the [below section](#argument-completers)

### Consistent Parameter Types

From the [Strongly Encouraged Development Guidelines](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx):

> _When the same parameter is used by multiple cmdlets, always use the same parameter type. For example, if the **Process** parameter is an **Int16** type for one cmdlet, do not make the **Process** parameter for another cmdlet a **UInt16** type._

## Parameter Set Guidelines

### Parameter Set Naming Conventions

The following are naming conventions to keep in mind when coming up with a name for your parameter set.

#### Pascal Case

Similar to cmdlets (mentioned above), parameter set names should follow pascal casing. From the [Strongly Encouraged Development Guidelines](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx):

> _Use Pascal case for cmdlet names. In other words, capitalize the first letter of the verb and all terms used in the noun. For example, "Clear-ItemProperty"._

### Attribute Guidelines

The following are guidelines that should be followed when working with the attributes of a parameter set.

#### Mutually Exclusive Parameter Sets

For PowerShell to determine which parameter set a user is intending to use with a set of provided parameters, the parameter sets need to be designed in such a way that they are mutually exclusive. From the remarks section of [Parameter Attribute Declaration](https://msdn.microsoft.com/en-us/library/ms714348(v=vs.85).aspx):

> _Each parameter set must have at least one unique parameter. Good cmdlet design indicates this unique parameter should also be mandatory if possible. If your cmdlet is designed to be run without parameters, the unique parameter cannot be mandatory._

#### Positional Parameters Limit

It is possibile to call a PowerShell cmdlet without providing the parameter names, but just the values you would like to pass through. This is done by specifying the position at which the value of each parameter should be provided by using the `Position` property for a parameter.  However, when there are too many positional parameters in a single parameter set, it can be difficult for the user to remember the exact ordering in which the parameter values should be provided. From the remarks section of [Parameter Attribute Declaration](https://msdn.microsoft.com/en-us/library/ms714348(v=vs.85).aspx):

> _When you specify positional parameters, limit the number of positional parameters in a parameter set to less than five. And, positional parameters do not have to be contiguous. Positions 5, 100, and 250 work the same as positions 0, 1, and 2._ 

In addition, there should be no two parameters with the same position in the same parameter set. From the remarks section of [Parameter Attribute Declaration](https://msdn.microsoft.com/en-us/library/ms714348(v=vs.85).aspx):

> _No parameter set should contain more than one positional parameter with the same position._

#### ValueFromPipeline Limit

Allowing the user to pipe an object from one cmdlet to another is a major scenario in PowerShell, but allowing multiple parameters in the same parameter set to accept their value from the pipeline can cause issues. From the remarks section of [Parameter Attribute Declaration](https://msdn.microsoft.com/en-us/library/ms714348(v=vs.85).aspx):

> _Only one parameter in a parameter set should declare ValueFromPipeline = true. Multiple parameters can define ValueFromPipelineByPropertyName = true._

### Required Parameter Sets

In most Azure PowerShell cmdlets, there is a bare minimum of three parameter sets that need to be implemented.

#### Interactive Parameter Set

This parameter set should be implemented by _every_ cmdlet - in most cases, the user provides the name of the resource that they are acting upon (`Name`) and the resource group in which they are acting in (`ResourceGroupName`).

The interactive parameter set **will always be the default parameter set** for a cmdlet (specified by the `DefaultParameterSetName` property in the `Cmdlet` attribute). This means that when PowerShell is unable to determine which parameter set a user is in, it will default to the interactive parameter set and prompt the user to provide values for the missing mandatory parameters.

#### ResourceId Parameter Set

This parameter set should be implemented by _every_ cmdlet - the user is able to provide a `ResourceId` string or GUID from the Azure Portal, or from one of the generic resources cmdlets (more information about that below in the piping section), and act upon the given resource associated with the id. The typical `Name` and `ResourceGroupName` parameters are replaced by a single `ResourceId` parameter of type string.

#### InputObject Parameter Set 

This parameter should be implemented by _most_ cmdlets - the user is able to take the object returned from the `Get`, `New`, or `Set` cmdlets (or other cmdlets that return the common resource) and provide it to the `InputObject` parameter for a cmdlet that acts upon the same resource. The typical `Name` and `ResourceGroupName` parameters are retrieved from the `InputObject` that the user is passing through.

## Piping Guidelines

Piping is an important scenario for cmdlets to have enabled in PowerShell. For more information on how piping works and for examples of its usage, please see the [Piping in PowerShell](./piping-in-powershell.md) document.

Below are the two main piping scenarios that should be applied in the cmdlets with the corresponding parameter sets.

### ResourceId

In this scenario, the user is able to pipe the result of a generic resources cmdlet into a cmdlet that accepts `ResourceId`. The below example shows how a user can use the generic resources cmdlet `Find-AzureRmResource` to get all resources of type `Foo` and remove them:

```powershell
Find-AzureRmResource -ResourceType Microsoft.Foo/foo | Remove-AzureRmFoo
```

For more information on enabling the `ResourceId` piping scenario and more examples, please see the ["Using the `ResourceId` parameter"](./piping-in-powershell.md#using-the-resourceid-parameter) section of the _Piping in PowerShell_ document. 

### InputObject

In this scenario, the user is able to pipe the result of a cmdlet that returns a resource into a cmdlet that accepts that resource as an `InputObject`. The below example shows how a user can get a `Foo` object from one cmdlet and pipe it to a cmdlet that removes it:

```powershell
Get-AzureRmFoo -Name "FooName" -ResourceGroupName "RG" | Remove-AzureRmFoo
```

For more information on enabling the `InputObject` piping scenario and more examples, please see the ["Using the `InputObject` parameter"](./piping-in-powershell.md#using-the-inputobject-parameter) section of the _Piping in PowerShell_ document.

## AsJob Parameter

All long running operations must implement the `-AsJob` parameter, which will allow the user to create jobs in the background. For more information about PowerShell jobs and the -AsJob parameter, read [this doc](https://docs.microsoft.com/en-us/powershell/azure/using-psjobs).

To implement the `-AsJob` parameter, simply add the parameter to the end of the parameter list:

````cs
[Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
public SwitchParameter AsJob { get; set; }
````

Once you add the parameter, please manually test that the job is created and successfully completes when the parameter is specified.  Additionally, please ensure that the help files are updated with this parameter.

To ensure that `-AsJob` is not broken in future changes, please add a test for this parameter. To update tests to include this parameter, use the following pattern:

````powershell
$job = Get-AzureRmSubscription
$job | Wait-Job
$subcriptions = $job | Receive-Job
````

To set a custom job name, please use [SetBackgroupJobDescription(string name)](https://github.com/Azure/azure-powershell/blob/preview/src/Common/Commands.Common/AzurePSCmdlet.cs#L761).  The default job description is: "Long Running Operation for '{cmdlet name}' on resource '{resource name}'"

## Argument Completers

PowerShell uses Argument Completers to provide tab completion for users.  At the moment, Azure PowerShell has two specific argument completers that should be applied to relevant parameters, and one generic argument completer that can be used to tab complete with a given list of values.

### Resource Group Completer

For any parameter that takes a resource group name, the `ResourceGroupCompleter` should be applied as an attribute.  This will allow the user to tab through all resource groups in the current subscription.

```cs
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
...
[Parameter(Mandatory = false, HelpMessage = "The resource group name")]
[ResourceGroupCompleter]
public string ResourceGroupName { get; set; }
```

### Location Completer

For any parameter that takes a location, the `LocationCompleter` should be applied as an attribute.  In order to use the `LocationCompleter`, you must input as an argument all of the Providers/ResourceTypes used by the cmdlet.  The user will then be able to tab through locations that are valid for all of the Providers/ResourceTypes specified.

```cs
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
...
[Parameter(Mandatory = false, HelpMessage = "The location of the resource")]
[LocationCompleter("Microsoft.Batch/operations")]
public string Location { get; set; }
```

### Generic Argument Completer

For any parameter which you would like the user to tab through a list of suggested values (but you do not want to limit the users to only these values), the generic argument completer should be added.

```cs
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
...
[Parameter(Mandatory = false, HelpMessage = "The tiers of the plan")]
[PSArgumentCompleter("Basic", "Premium", "Elite")]
public string Tier { get; set; }
```
