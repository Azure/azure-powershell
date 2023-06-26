# Cmdlet Best Practices

### Cmdlet Naming Conventions

The following are naming conventions to keep in mind when coming up with a name for your cmdlet.

#### Verb-Noun Format

Cmdlet names should follow the _Verb-Noun_ format, where the verb is from the [list of approved PowerShell verbs](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/approved-verbs-for-windows-powershell-commands), and the noun is a specific noun describing a resource within your service.

#### Noun Prefix

For ARM cmdlets, the noun must be prefixed with `Az`.

#### Pascal Case

From the [_Strongly Encouraged Development Guidelines_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/strongly-encouraged-development-guidelines#use-pascal-case-for-cmdlet-names-sd02):

> _Use Pascal case for cmdlet names. In other words, capitalize the first letter of the verb and all terms used in the noun. For example, "Clear-ItemProperty"._

#### Specific Noun and Noun Singularity

From the [_Strongly Encouraged Development Guidelines_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/strongly-encouraged-development-guidelines#use-a-specific-noun-for-a-cmdlet-name-sd01):

> _Nouns used in cmdlet naming need to be very specific so that the user can discover your cmdlets. Prefix generic nouns such as "server" with a shortened version of the product name. For example, if a noun refers to a server that is running an instance of Microsoft SQL Server, use a noun such as "SQLServer". The combination of specific nouns and the short list of approved verbs enable the user to quickly discover and anticipate functionality while avoiding duplication among cmdlet names._
>
> _To enhance the user experience, the noun that you choose for a cmdlet name should be singular. For example, use the name `Get-Process` instead of `Get-Processes`. It is best to follow this rule for all cmdlet names, even when a cmdlet is likely to act upon more than one item._

#### Set vs. Update

If your cmdlet is performing a **PATCH** operation (_i.e._, a partial replacement on the server), then the cmdlet should use the verb `Update`.

If your cmdlet is performing a **PUT** operation (_i.e._, a full replacement on the server), the the cmdlet should use the verb `Set`.

#### Cmdlet Alias

If you there is a separate nomenclature for your service and/or resource, or if you would like to shorten the name of the cmdlet so it's easier to remember, you can add an alias attribute to your cmdlet to allow for this functionality.

### Output Type

Specified by the `OutputType` attribute, this piece of metadata lets the user know what the type of the object returned by the cmdlet is (found in the **Outputs** section of a cmdlet's help content). The type specified here should always be a single element and not an enumeration of elements (_e.g._, `PSVirtualMachine` instead of `List<PSVirtualMachine>`).

#### Valid Output Types

If the cmdlet returns an object, the type of the object returned must be defined; the output type for a cmdlet should _never_ be `object`, `PSObject`, `PSCustomObject` or the like. Returning these types of objects makes it difficult for the user to anticipate what properties will be found on the object returned from the cmdlet, as well as makes it impossible for the breaking change analyzer to detect if a breaking change was introduced to the cmdlet as the type is not defined.

In order to preserve proper piping scenarios, the output type for a cmdlet should _never_ be a `string`. If a cmdlet is expected to return a `string`, the suggestion is to introduce a new type that encapsulates the `string` information as a property and return that object. The PowerShell language revolves around objects and passing them around cmdlets; returning `string` objects can introduce inconsistencies in the piping experience for users.

#### Returning Wrapped SDK Types

In most cases, cmdlets will be returning an object corresponding to a resource that a user is performing an action on. Rather than returning the .NET SDK type for that resource (exposing .NET SDK types in PowerShell cmdlets is _strongly_ discouraged), we suggest creating a new class that wraps this .NET SDK type, allowing for breaking changes in the underlying type while avoiding breaking changes in the PowerShell type.

For example, the `Get-AzVM` cmdlet uses the .NET SDK to retrieve objects of the `VirtualMachine` type, but a new class, `PSVirtualMachine`, was created to wrap the type from the .NET SDK, and is returned by the cmdlet. If, in the future, the `VirtualMachine` type in the .NET SDK has a property removed, that property can still be maintained in PowerShell by adding it to the `PSVirtualMachine` type and recreating the value, thus avoiding a breaking change in the corresponding cmdlet(s).

#### Returning No Output

In the case where your cmdlet doesn't return any output (_e.g._, deleting, starting, stopping a resource), the cmdlet should implement the `-PassThru` parameter and the `OutputType` should be set to `bool`. The `-PassThru` parameter is a `SwitchParameter` set by the user to signal that they would like to receive output from a cmdlet which does not return anything. If the `-PassThru` parameter is provided, you should return the value `true` so the user is made aware that the operation was successful. If the operation was unsuccessful, then the cmdlet should throw an exception.

From the [_Strongly Encouraged Development Guidelines_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/strongly-encouraged-development-guidelines#support-the-passthru-parameter):

> _By default, many cmdlets that modify the system, such as the `Stop-Process` cmdlet, act as "sinks" for objects and do not return a result. These cmdlet should implement the `-PassThru` parameter to force the cmdlet to return an object._

The code below shows how this should look in a cmdlet:

```cs
[Cmdlet(...), OutputType(typeof(bool))]
public class MySampleCmdlet : MyBaseCmdlet
{
    // other parameters omitted

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; set; }

    public override void ExecuteCmdlet()
    {
        // other code omitted

        if (this.PassThru.IsPresent)
        {
            WriteObject(true);
        }
    }
}
```

### `ShouldProcess`

If a cmdlet makes any changes to an object on the server (_e.g._, create, delete, update, start, stop a resource), the cmdlet should implement `ShouldProcess`. This property adds the `-WhatIf` and `-Confirm` parameters to the cmdlet:

- `-WhatIf` is a `SwitchParameter` that, when provided by the user, doesn't execute the part of the cmdlet responsible for making the changes to the object, but rather displays a message alerting the user of the action that is to be performed on the object
- `-Confirm` is a `SwitchParameter` that, when provided by the user, prompts the user for confirmation that they want to continue with the execution of the cmdlet.

The code below shows how this should look in a cmdlet:

```cs
[Cmdlet(..., SupportsShouldProcess = true), OutputType(typeof(...))]
public class MySampleCmdlet : MyBaseCmdlet
{
    // parameters omitted

    public override void ExecuteCmdlet()
    {
        // other code omitted

        if (ShouldProcess(targetResource, actionMessage))
        {
            // make the change
        }
    }
}
```

More information about `ShouldProcess` can be found in the [_Should Process and Confirm Impact_](./should-process-confirm-impact.md) document.

#### When to Add the Force Parameter

The `-Force` parameter is reserved for special scenarios where additional confirmation from the user is required. From the above document on [_Should Process and Confirm Impact_](./should-process-confirm-impact.md) document:

> _Some cmdlets require additional confirmation. For example, if a cmdlet would destroy existing resources in some circumstances, the cmdlet might detect that condition and prompt the user to verify before continuing. Overwriting an existing resource during resource creation, overwriting a file when downloading data, deleting a resource that is currently in use, or deleting a container that contains additional resources are all example of this pattern. To implement additional confirmation, and allow scripts to opt out of additional prompts, the above pattern is enhanced with calls to `ShouldContinue()` and the `-Force` parameter._

### `AsJob`

All long running operations must implement the `-AsJob` parameter, which will allow the user to create jobs in the background. For more information about PowerShell jobs and the `-AsJob` parameter, read [this doc](https://learn.microsoft.com/en-us/powershell/azure/using-psjobs).

To implement the `-AsJob` parameter, simply add the parameter to the end of the parameter list:

````cs
[Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
public SwitchParameter AsJob { get; set; }
````

Once you add the parameter, please manually test that the job is created and successfully completes when the parameter is specified.  Additionally, please ensure that the help files are updated with this parameter.

To ensure that `-AsJob` is not broken in future changes, please add a test for this parameter. To update tests to include this parameter, use the following pattern:

````powershell
$job = Get-AzSubscription -AsJob
$job | Wait-Job
$subcriptions = $job | Receive-Job
````

To set a custom job name, please use [`SetBackgroupJobDescription`](https://github.com/Azure/azure-powershell-common/blob/master/src/Common/AzurePSCmdlet.cs#L810). The default job description is: "Long Running Operation for '{cmdlet name}' on resource '{resource name}'"

### Required Parameter Sets

In most Azure PowerShell cmdlets, there is a bare minimum of three parameter sets that need to be implemented.

#### Interactive Parameter Set

This parameter set should be implemented by _every_ cmdlet - in most cases, the user provides the name of the resource that they are acting upon (`-Name`) and the resource group in which they are acting in (`-ResourceGroupName`).

The interactive parameter set **will always be the default parameter set** for a cmdlet (specified by the `DefaultParameterSetName` property in the `Cmdlet` attribute). This means that when PowerShell is unable to determine which parameter set a user is in, it will default to the interactive parameter set and prompt the user to provide values for the missing mandatory parameters.

#### ResourceId Parameter Set

This parameter set should be implemented by _every_ cmdlet - the user is able to provide a `-ResourceId` string or GUID from the Azure Portal, or from one of the generic resources cmdlets (more information about this scenario can be found in the [`piping-best-practices.md`](./piping-best-practices.md#using-the--resourceid-parameter) document), and act upon the given resource associated with the id. The typical `-Name` and `-ResourceGroupName` parameters are replaced by a single `-ResourceId` parameter of type string.

#### InputObject Parameter Set

This parameter should be implemented by _most_ cmdlets - the user is able to take the object returned from the `Get`, `New`, or `Set` cmdlets (or other cmdlets that return the common resource) and provide it to the `-InputObject` parameter for a cmdlet that acts upon the same resource (more information about this scenario can be found in the [`piping-best-practices.md`](./piping-best-practices.md#using-the--inputobject-parameter) document). The typical `-Name` and `-ResourceGroupName` parameters are retrieved from the `-InputObject` that the user is passing through.