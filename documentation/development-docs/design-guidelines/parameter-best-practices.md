# Parameter Best Practices

## Parameter Guidelines

### Parameter Naming Conventions

The following are naming conventions to keep in mind when coming up with a name for your parameters.

In addition, a recommended list of parameter names can be found [here](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/standard-cmdlet-parameter-names-and-types).

#### Standard Parameter Name

From the [_Strongly Encouraged Development Guidelines_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/strongly-encouraged-development-guidelines#use-standard-parameter-names):

> _Your cmdlet should use standard parameter names so that the user can quickly determine what a particular parameter means. If a more specific name is required, use a standard parameter name, and then specify a more specific name as an alias. For example, the `Get-Service` cmdlet has a parameter that has a generic name (**Name**) and a more specific alias (**ServiceName**). Both terms can be used to specify the parameter._

#### Pascal Case

Similar to cmdlets, parameters should follow pascal casing.From the [_Strongly Encouraged Development Guidelines_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/strongly-encouraged-development-guidelines#use-pascal-case-for-parameter-names):

> _Use Pascal case for parameter names. In other words, capitalize the first letter of each word in the parameter name, including the first letter of the name._

#### Singularity

From the [_Strongly Encouraged Development Guidelines_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/strongly-encouraged-development-guidelines#use-singular-parameter-names):

> _Avoid using plural names for parameters whose value is a single element. This includes parameters that take arrays or lists because the user might supply an array or list with only one element._
>
> _Plural parameter names should be used only in those cases where the value of the parameter is always a multiple-element value. In these cases, the cmdlet should verify that multiple elements are supplied, and the cmdlet should display a warning to the user if multiple elements are not supplied._

#### Parameter Alias

If you there is a separate nomenclature for the parameter name, or if you would like to shorten the name of the parameter so it's easier to remember, you can add an alias attribute to your parameter to allow for this functionality.

### Parameter Types

#### Valid Parameter Types

The type of parameters should always be defined; a parameter should never be of type `object`, `PSObject`, `PSCustomObject` or the like. Defining a parameter with any of these types can make it difficult for the user to know what value they should be providing to the parameter, as well as makes it difficult for the breaking change analyzer to detect any breaking changes made to the parameter since it has no knowledge about changes in the types' properties.

#### Consistent Parameter Types

From the [_Strongly Encouraged Development Guidelines_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/strongly-encouraged-development-guidelines#use-consistent-parameter-types):

> _When the same parameter is used by multiple cmdlets, always use the same parameter type. For example, if the **Process** parameter is an **Int16** type for one cmdlet, do not make the **Process** parameter for another cmdlet a **UInt16** type._

#### Array vs. Enumerable Types

For parameters that require a collection of elements to be provided, use an array instead of any other enumerable type to represent this collection.

From the [_Strongly Encouraged Development Guidelines_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/strongly-encouraged-development-guidelines#support-arrays-for-parameters):

> _Frequently, users must perform the same operation against multiple arguments. For these users, a cmdlet should accept an array as parameter input so that a user can pass the arguments into the parameter as a Windows PowerShell variable. For example, the `Get-Process` cmdlet uses an array for the strings that identify the names of the processes to retrieve._

#### Secret Parameters

For parameters that represent a value that should be kept secret in some fashion (such as a password, secret, key, etc.), the type of the parameter should be `SecureString` to avoid any sensitive information about the parameter from leaking during cmdlet execution.

#### Bool vs. SwitchParameter

Parameters of type `bool` are _strongly_ discouraged in PowerShell. The `SwitchParameter` type of a parameter acts a flag that signals whether or not some action should be taken based on if the parameter was provided or not.

The only case where a `bool` parameter should be used is for a `PATCH` operation wrapped by an `Update-*` cmdlet; in this case, the user will have the option to set the value to `true` or `false`, or not provide a value at all, which keeps the value the same on the server. For a `PUT` operation wrapped by a `Set-*` cmdlet, the normal `SwitchParameter` type should be used.

### Argument Completers

PowerShell uses Argument Completers to provide tab completion for users. Azure PowerShell has multiple specific argument completers that should be applied to relevant parameters, as well as a generic argument completer that can be used to tab complete with a given list of values.

#### Resource Group Completer

For any parameter that takes a resource group name, the `ResourceGroupCompleter` should be applied as an attribute.  This will allow the user to tab through all resource groups in the current subscription.

```cs
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
...
[Parameter(Mandatory = false, HelpMessage = "The resource group name")]
[ResourceGroupCompleter]
public string ResourceGroupName { get; set; }
```

#### Resource Name Completer

For any parameter that takes a resource name, the `ResourceNameCompleter` should be applied as an attribute.  This will allow the user to tab through all resource names for the ResourceType in the current subscription.  This completer will filter based upon the current parent resources provided (for instance, if ResourceGroupName is provided, only the resources in that particular resource group will be returned).  For this completer, please provide the ResourceType as the first argument, followed by the parameter name for all parent resources starting at the top level.

```cs
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
...
[Parameter(Mandatory = false, HelpMessage = "The parent server name")]
[ResourceNameCompleter("Microsoft.Sql/servers", nameof(ResourceGroupName))]
public string ServerName { get; set; }

[Parameter(Mandatory = false, HelpMessage = "The database name")]
[ResourceNameCompleter("Microsoft.Sql/servers/databases", nameof(ResourceGroupName), nameof(ServerName))]
public string Name { get; set; }
```

#### Location Completer

For any parameter that takes a location, the `LocationCompleter` should be applied as an attribute.  In order to use the `LocationCompleter`, you must input as an argument all of the Providers/ResourceTypes used by the cmdlet.  The user will then be able to tab through locations that are valid for all of the Providers/ResourceTypes specified.

```cs
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
...
[Parameter(Mandatory = false, HelpMessage = "The location of the resource")]
[LocationCompleter("Microsoft.Batch/operations")]
public string Location { get; set; }
```

#### Generic Argument Completer

For any parameter which you would like the user to tab through a list of suggested values (but you do not want to limit the users to only these values), the generic argument completer should be added.

```cs
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
...
[Parameter(Mandatory = false, HelpMessage = "The tiers of the plan")]
[PSArgumentCompleter("Basic", "Premium", "Elite")]
public string Tier { get; set; }
```

## Parameter Set Guidelines

### Parameter Set Naming Conventions

The following are naming conventions to keep in mind when coming up with a name for your parameter set.

#### Pascal Case

Similar to parameters (mentioned above), parameter set names should follow pascal casing. From the [_Strongly Encouraged Development Guidelines_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/strongly-encouraged-development-guidelines#use-pascal-case-for-cmdlet-names-sd02):

> _Use Pascal case for cmdlet names. In other words, capitalize the first letter of the verb and all terms used in the noun. For example, "Clear-ItemProperty"._

### Attribute Guidelines

The following are guidelines that should be followed when working with the attributes of a parameter set.

#### Mutually Exclusive Parameter Sets

For PowerShell to determine which parameter set a user is intending to use with a set of provided parameters, the parameter sets need to be designed in such a way that they are mutually exclusive. From the remarks section of [_Parameter Attribute Declaration_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/parameter-attribute-declaration#remarks):

> _Each parameter set must have at least one unique parameter. Good cmdlet design indicates this unique parameter should also be mandatory if possible. If your cmdlet is designed to be run without parameters, the unique parameter cannot be mandatory._

#### Positional Parameters Limit

It is possibile to call a PowerShell cmdlet without providing the parameter names, but just the values you would like to pass through. This is done by specifying the position at which the value of each parameter should be provided by using the `Position` property for a parameter.  However, when there are too many positional parameters in a single parameter set, it can be difficult for the user to remember the exact ordering in which the parameter values should be provided. From the remarks section of [_Parameter Attribute Declaration_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/parameter-attribute-declaration#remarks):

> _When you specify positional parameters, limit the number of positional parameters in a parameter set to less than five. And, positional parameters do not have to be contiguous. Positions 5, 100, and 250 work the same as positions 0, 1, and 2._

In addition, there should be no two parameters with the same position in the same parameter set. From the remarks section of [_Parameter Attribute Declaration_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/parameter-attribute-declaration#remarks):

> _No parameter set should contain more than one positional parameter with the same position._

#### ValueFromPipeline Limit

Allowing the user to pipe an object from one cmdlet to another is a major scenario in PowerShell, but allowing multiple parameters in the same parameter set to accept their value from the pipeline can cause issues. From the remarks section of [_Parameter Attribute Declaration_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/parameter-attribute-declaration#remarks):

> _Only one parameter in a parameter set should declare ValueFromPipeline = true. Multiple parameters can define ValueFromPipelineByPropertyName = true._