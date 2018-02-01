# Breaking Changes Tool

Below are descriptions and remediations for each of the errors that can be seen when using the breaking changes tool.

## Table of Contents

| Problem ID | Breaking Change |
| --- | --- |
| 1000 | [Removed Cmdlet](#1000---removed-cmdlet) |
| 1010 | [Removed Cmdlet Alias](#1010---removed-cmdlet-alias) |
| 1020 | [Changed Output Type](#1020---changed-output-type) |
| 1030 | [Removed SupportsShouldProcess](#1030---removed-supportsshouldprocess) |
| 1040 | [Removed SupportsPaging](#1040---removed-supportspaging) |
| 1050 | [Removed Parameter Set](#1050---removed-parameter-set) |
| 1060 | [Changed Default Parameter Set](#1060---changed-default-parameter-set) |
| 1070 | [Changed Output Element Type](#1070---changed-output-element-type) |
| 1080 | [Changed Output Generic Type](#1080---changed-output-generic-type) |
| 1090 | [Changed Output Generic Type Argument](#1090---changed-output-generic-type-argument) |
| 1100 | [Different Output Generic Type Argument Size](#1100---different-output-generic-type-argument-size) |
| 2000 | [Removed Parameter](#2000---removed-parameter) |
| 2010 | [Removed Parameter Alias](#2010---removed-parameter-alias) |
| 2020 | [Changed Parameter Type](#2020---changed-parameter-type) |
| 2030 | [Mandatory Parameter](#2030---mandatory-parameter) |
| 2040 | [Removed ValidateSet Value](#2040---removed-validateset-value) |
| 2050 | [Added ValidateSet](#2050---added-validateset) |
| 2060 | [Position Changed](#2060---position-changed) |
| 2070 | [Removed ValueFromPipeline](#2070---removed-valuefrompipeline) |
| 2080 | [Removed ValueFromPipelineByPropertyName](#2080---removed-valuefrompipelinebypropertyname) |
| 2090 | [Added ValidateNotNullOrEmpty](#2090---added-validatenotnullorempty) |
| 2100 | [Removed Parameter From Parameter Set](#2100---removed-parameter-from-parameter-set) |
| 2110 | [Changed Parameter Element Type](#2110---changed-parameter-element-type) |
| 2120 | [Changed Parameter Generic Type](#2120---changed-parameter-generic-type) |
| 2130 | [Changed Parameter Generic Type Argument](#2130---changed-parameter-generic-type-argument) |
| 2140 | [Different Parameter Generic Type Argument Size](#2140---different-parameter-generic-type-argument-size) |
| 2150 | [Added ValidateRange](#2150---added-validaterange) |
| 2160 | [Changed ValidateRange Minimum Value](#2160---changed-validaterange-minimum-value) |
| 2170 | [Changed ValidateRange Maximum Value](#2170---changed-validaterange-maximum-value) |
| 3000 | [Changed Property Type](#3000---changed-property-type) |
| 3010 | [Removed Property](#3010---removed-property) |
| 3020 | [Changed Element Type](#3020---changed-element-type) |
| 3030 | [Changed Generic Type](#3030---changed-generic-type) |
| 3040 | [Changed Generic Type Argument](#3040---changed-generic-type-argument) |
| 3050 | [Different Generic Type Argument Size](#3050---different-generic-type-argument-size) |

## 1000 - Removed or Renamed Cmdlet

### Description

_The cmdlet '`<cmdlet>`' has been removed and no alias was found for the original cmdlet name._

When a user can no longer use a cmdlet that was previously available in a module, that is a breaking change. This can occur when the cmdlet is deleted, or when the name of the cmdlet was changed with no alias to the original cmdlet name.

### Remediation

_Add the cmdlet '`<cmdlet>`' back to the module, or add an alias to the original cmdlet name._

To add an alias to the original cmdlet name, use the `Alias` attribute for the cmdlet.

If you need to, you can add multiple aliases for cmdlets that need to be renamed twice.

```cs
[Cmdlet(VerbsCommunications.Connect, "AzureRmAccount")]
[Alias("Login-AzureRmAccount", "Login-AzAccount", "Add-AzureRmAccount")]
public class ConnectAzureRmAccount : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

## 1010 - Removed Cmdlet Alias

### Description

_The cmdlet '`<cmdlet>`' no longer supports the alias '`<alias>`'._

When a user can no longer use a cmdlet by calling one of its aliases, that is a breaking change. 

### Remediation

_Add the alias '`<alias>`' back to the cmdlet '`<cmdlet>`'._

## 1020 - Changed Output Type

### Description

_The cmdlet '`<cmdlet>`' no longer has output type '`<outputType>`'._

When the output of a cmdlet changes types, that is a breaking change. Existing scripts that assign the output of a cmdlet to a variable and call one of its properties or pass it through to another cmdlet will no longer work. If the new output type has all of the same properties as the previous output type, then this is not considered a breaking change.

For example, if we have a cmdlet, `Get-SomeObject` that returns a `Foo` object

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(Foo))]
public class GetSomeObject : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but we change the output type to `Bar`

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(Bar))]
```

the following script will no longer work since we are accessing properties of the `Foo` object that may not be a part of the `Bar` object 

```powershell
$foo = Get-SomeObject
$foo.SomeProperty
$foo.AnotherProperty
```

### Remediation

_Make cmdlet '`<cmdlet>`' return type '`<outputType>`'._

## 1030 - Removed SupportsShouldProcess

### Description

_The cmdlet '`<cmdlet>`' no longer implements ShouldProcess._

When a cmdlet that previously implemented `ShouldProcess` no longer does, that is a breaking change. Users will no longer be able to use the `WhatIf` and `Confirm` parameters with the cmdlet.

For example, if we had a cmdlet `Remove-SomeObject` that implemented `ShouldProcess`, but no longer does, the following script will no longer work since the `WhatIf` and `Confirm` parameters are not defined in the cmdlet.

```powershell
Remove-SomeObject -WhatIf
Remove-SomeObject -Confirm
```

### Remediation

_Make sure the cmdlet '`<cmdlet>`' implements ShouldProcess._

## 1040 - Removed SupportsPaging

### Description

_The cmdlet '`<cmdlet>`' no longer implements Paging._

When a cmdlet that previously implemented `Paging` no longer does, that is a breaking change. Users will no longer be able to use the `First`, `Skip`, and `IncludeTotalCount` parameters with the cmdlet.

### Remediation

_Make sure the cmdlet '`<cmdlet>`' implements Paging._

## 1050 - Removed Parameter Set

### Description

_The parameter set '`<parameterSet>`' for cmdlet '`<cmdlet>`' has been removed._

When a parameter set for a cmdlet has been removed, that is a breaking change. Existing scripts that use the removed parameter set will no longer work.

### Remediation

_Add parameter set '`<parameterSet>`' back to cmdlet '`<cmdlet>`'._

## 1060 - Changed Default Parameter Set

### Description

_The parameter set '`<parameterSet>`' for cmdlet '`<cmdlet>`' is no longer the default parameter set._

When the default parameter set is changed, that is a breaking change. Existing scripts that rely on the default parameter set will no longer function the same since they will now be using a different parameter set.

For example, if we had a cmdlet `Add-SomeObject` whose default parameter set was `Foo`

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject", DefaultParameterSetName = "Foo")]
public class AddSomeObject : Cmdlet
{
    [Parameter(
        ParameterSetName = "Foo",
        Mandatory = false)]
    public string Foo { get; set; }

    [Parameter(
        ParameterSetName = "Bar",
        Mandatory = false)]
    public string Bar { get; set; }

    public override void ExecuteCmdlet()
    {
        ...
    }
}
```

but the default parameter set was changed to `Bar`

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject", DefaultParameterSetName = "Bar")]
```

this will cause a change in functionality of the cmdlet and a call to `Add-SomeObject` with no parameters will not work as expected.

Also, if the default parameter set is removed entirely from this cmdlet, this will cause an exception to be thrown whenever `Add-SomeObject` is called with no parameters since PowerShell will not be able to determine which parameter to use.

### Remediation

_Change the default parameter for cmdlet '`<cmdlet>`' back to '`<parameterSet>`'._

_Note_: if the default parameter set name is changed, this breaking change can also be resolved by ensuring that the same set of parameters in the previous default parameter set are found in the new one. This also means the parameters' attributes (such as `Mandatory` and `Position`) must also remain the same for the set of parameters that were included.

## 1070 - Changed Output Element Type

### Description

_The element type for the output has been changed from `'<oldElementType>'` to `'<newElementType>'`._

When the type of the output is an array, and the element type of that array has been changed, that is a breaking change. If the new output type has all of the properties found in the previous output type, then this is not considered a breaking change.

For example, if we had a cmdlet `Get-SomeObject` that returned an array of `Foo` objects

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(Foo[]))]
public class GetSomeObject : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but it now returns an array of `Bar` objects

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(Bar[]))]
```

the following script will no longer work since we are accessing properties of the `Foo` object that may not be a part of the `Bar` object 

```powershell
$foo = Get-SomeObject
$foo[0].SomeProperty
$foo[0].AnotherProperty
```

### Remediation

_Change the element type for the output back to `'<oldElementType>'`._

## 1080 - Changed Output Generic Type

### Description

_The generic type for the output has been changed from `'<oldGenericType>'` to `'<newGenericType>'`._

When the type of the output is a generic, and that generic has been changed, that is a breaking change.

For example, if we had a cmdlet `Get-SomeObject` that returned a stack of `Foo` objects

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(Stack<Foo>))]
public class GetSomeObject : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but it now returns a queue of `Foo` objects

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(Queue<Foo>))]
```

the following script will no longer work since we are accessing methods of the `Stack` class that are not a part of the `Queue` class

```powershell
$stack = Get-SomeObject
$stack.Pop()
$stack.Push($foo)
```

### Remediation

_Change the generic type for the output back to `'<oldGenericType>'`._

## 1090 - Changed Output Generic Type Argument

### Description

_The generic type argument for the output has been changed from `'<oldArgument>'` to `'<newArgument>'`._

When the type of the output is a generic, and one of the arguments of the generic has changed, that is a breaking change. 

For example, if we had a cmdlet `Get-SomeObject` that returned a list of `Foo` objects

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(List<Foo>))]
public class GetSomeObject : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but it now returns a list of `Bar` objects

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(List<Bar>))]
```

the following script will no longer work since we are accessing properties of the `Foo` object that may not be a part of the `Bar` object 

```powershell
$list = Get-SomeObject
foreach ($foo in $list)
{
    $foo.SomeProperty
    $foo.AnotherProperty
}
```

### Remediation

_Change the generic type argument for the output back to `'<oldArgument>'`._

## 1100 - Different Output Generic Type Argument Size

### Description

_The number of arguments for generic type `'<genericType>'` for the output has been changed from `'<oldSize>'` to `'<newSize>'`._

When the type of the output is a generic, and the number of arguments for the generic has changed, that is a breaking change. 

For example, if we had a cmdlet `Get-SomeObject` that returned a `Tuple<Foo, Bar>` object

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(Tuple<Foo, Bar>))]
public class GetSomeObject : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but it now returns a `Tuple<Foo>` object

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(Tuple<Foo>))]
```

The following script will no longer work since it is expecting a tuple containing two objects rather than an object containing only one

```powershell
$tuple = Get-SomeObject
$tuple.Item1
$tuple.Item2
```

### Remediation

_Change the number of arguments for generic type `'<genericType>'` back to `'<oldSize>'`._

## 2000 - Removed Parameter

### Description

_The cmdlet '`<cmdlet>`' no longer supports the parameter '`<parameter>`' and no alias was found for the original parameter name._

When a user can no longer use a parameter for a cmdlet, that is a breaking change. This can occur when the parameter has been removed, or the parameter name has been changed without adding an alias to the original parameter name.

### Remediation

_Add the parameter '`<parameter>`' back to the cmdlet '`<cmdlet>`', or add an alias to the original parameter name._

To add an alias to the original parameter name, use the `Alias` attribute for the parameter.

```cs
[Cmdlet(VerbsCommunications.Connect, "AzureRmAccount")]
public class ConnectAzureRmAccount : Cmdlet
{
    [Alias("Domain")]
    [Parameter(ParameterSetName = "...", Mandatory = false)
    public string TenantId { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

## 2010 - Removed Parameter Alias

### Description

_The cmdlet '`<cmdlet>`' no longer supports the alias '`<alias>`' for parameter '`<parameter>`'._

When a user can no longer use a parameter by calling one of its aliases, that is a breaking change. 

### Remediation

_Add the alias '`<alias>`' back to parameter '`<parameter>`'._

## 2020 - Changed Parameter Type

### Description

_The cmdlet '`<cmdlet>`' no longer supports the type '`<parameterType>`' for parameter '`<parameter>`'._

When the type of a parameter is changed, that is a breaking change. Existing scripts that use this parameter will no longer work as the type of the object being passed through will no longer match.

For example, if we have a cmdlet, `Add-SomeObject` that has parameter `Foo` of type `string`

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	public string Foo { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but `Foo` is now of type `int`

```cs
[Parameter(Mandatory = false)]
public int Foo { get; set; }
```

The following script will no longer work since it is expecting a `string` to be passed through for `Foo`

```powershell
Add-SomeObject -Foo "string"
```

### Remediation

_Change the type for parameter '`<parameter>`' back to '`<parameterType>`'._

## 2030 - Mandatory Parameter

### Description

_The parameter '`<parameter>`' is no longer optional for the parameter set '`<parameterSet>`' for cmdlet '`<cmdlet>`'._

When a parameter is made mandatory when it was previously optional, that is a breaking change. Existing scripts that do not use this parameter in the given parameter set will no longer work.

For example, if we have a cmdlet, `Add-SomeObject` that has an optional parameter `Foo` 

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	public string Foo { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but `Foo` is now mandatory

```cs
[Parameter(Mandatory = true)]
public string Foo { get; set; }
```

The following script will no longer work since `Foo` was not previously provided because it was optional

```powershell
Add-SomeObject
```

### Remediation

_Make '`<parameter>`' optional for the parameter set '`<parameterSet>`'._

## 2040 - Removed ValidateSet Value

### Description

_The validation set for parameter `'<parameter>'` for cmdlet `'<cmdlet>'` no longer contains the value `'<value>'`._

When a value has been removed from a validation set for a parameter, that is a breaking change. Existing scripts that use this value for the parameter will no longer work.

For example, if we have a cmdlet, `Add-SomeObject` that has parameter `Foo`  with a validation set containing the values "one", "two" and "three"

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	[ValidateSet("one", "two", "three")]
	public string Foo { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but "two" has been removed from the validation set

```cs
[Parameter(Mandatory = false)]
[ValidateSet("one", "three")]
public string Foo { get; set; }
```

The following script will no longer work since the value "two" that previously worked for parameter `Foo` is no longer accepted

```powershell
Add-SomeObject -Foo "one"
Add-SomeObject -Foo "two"
Add-SomeObject -Foo "three"
```

### Remediation

_Add `'<value>'` back to the validation set for `'<parameter>'`._

## 2050 - Added ValidateSet

### Description

_A validate set has been added for parameter `'<parameter>'` for cmdlet `'<cmdlet>'`._

When a validation set is added to an existing parameter to restrict the values that can be used, that is a breaking change. Existing scripts that use values not in the validation set will no longer work.

For example, if we have a cmdlet, `Add-SomeObject` that has parameter `Foo`  with no validation set

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	public string Foo { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but a validation set has now been added

```cs
[Parameter(Mandatory = false)]
[ValidateSet("one", "two", "three")]
public string Foo { get; set; }
```

The following script will no longer work since previously used values that aren't in the newly added validation set will not work

```powershell
Add-SomeObject -Foo "foo"
Add-SomeObject -Foo "bar"
```

### Remediation

_Remove the validate set from parameter `'<parameter>'`._

## 2060 - Position Changed

### Description

_The position of parameter '`<parameter>`' has changed for parameter set '`<parameterSet>`' for cmdlet '`<cmdlet>`'._

When the position of a parameter has changed, that is a breaking change. Existing scripts that use the ordering of the parameters in the cmdlet call will no longer work.

For example, if we have a cmdlet, `Add-SomeObject` that has positional parameters `Foo`  and `Bar`

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Position = 0, Mandatory = false)]
	public string Foo { get; set; }

	[Parameter(Position = 1, Mandatory = false)]
	public int Bar { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but the positions of the parameters have switched

```cs
[Parameter(Position = 1, Mandatory = false)]
public string Foo { get; set; }

[Parameter(Position = 0, Mandatory = false)]
public int Bar { get; set; }
```

The following script will no longer work since it depends on the ordering of the parameters, which have been changed

```powershell
Add-SomeObject "foo" 3
```

### Remediation

_Revert the position change made to parameter '`<parameter>`' for parameter set '`<parameterSet>`'._

## 2070 - Removed ValueFromPipeline

### Description

_The parameter '`<parameter>`' in parameter set '`<parameterSet>`' for cmdlet '`<cmdlet>`' no longer has the attribute 'ValueFromPipeline'._

When a parameter is no longer able to get its value from the pipeline, that is a breaking change. Existing scripts that pipe the output of a command to the cmdlet as the value for the parameter will no longer work.

For example, if we have a cmdlet, `Add-SomeObject` that has parameter `Foo`  that gets its value from the pipeline

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(ValueFromPipeline = true, Mandatory = false)]
	public string Foo { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but `Foo` no longer gets its value from the pipeline

```cs
[Parameter(Mandatory = false)]
public string Foo { get; set; }
```

The following script will no longer work since the value of `Foo` was being passed through the pipeline, which is no longer supported

```powershell
"foo" | Add-SomeObject
```

### Remediation

_Add the attribute 'ValueFromPipeline' back to parameter '`<parameter>`' in parameter set '`<parameterSet>`'._

## 2080 - Removed ValueFromPipelineByPropertyName

### Description

_The parameter '`<parameter>`' in parameter set '`<parameterSet>`' for cmdlet '`<cmdlet>`' no longer has the attribute 'ValueFromPipelineByPropertyName'._

When a parameter is no longer able to get its value from the pipeline by matching the property name, that is a breaking change. Existing scripts that pipe the output of a command to the cmdlet as the value for the parameter will no longer work.

For example, if we have a cmdlet, `Add-SomeObject` that has parameters `Foo` and `Bar` that get their value from the pipeline by property name

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
	public string Foo { get; set; }

	[Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
	public string Bar { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

and there is a type `SomeType` that has properties `Foo` and `Bar` and is returned by another cmdlet `Get-SomeObject`

```cs
public class SomeType
{
	public string Foo { get; set; }

	public string Bar { get; set; }
}
```

but `Foo` and `Bar` no longer get their value from the pipeline by property name

```cs
[Parameter(Mandatory = false)]
public string Foo { get; set; }

[Parameter(Mandatory = false)]
public string Bar { get; set; }
```

The following script will no longer work since the value of `Foo` and `Bar` were being passed through the pipeline by property name, which is no longer supported

```powershell
Get-SomeObject | Add-SomeObject
```

### Remediation

_Add the attribute 'ValueFromPipelineByPropertyName' back to parameter '`<parameter>`' in parameter set '`<parameterSet>`'._

## 2090 - Added ValidateNotNullOrEmpty

### Description

_The ValidateNotNullOrEmpty attribute has been added to parameter `'<parameter>'` for cmdlet `'<cmdlet>'`._

When a parameter no longer accepts null or empty values, that is a breaking change. Existing scripts that pass through null or empty values through to the parameter will no longer work.

For example, if we have a cmdlet, `Add-SomeObject` that has parameter `Foo` 

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	public string Foo { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but `Foo` now has the `ValidateNotNullOrEmpty` attribute

```cs
[Parameter(Mandatory = false)]
[ValidateNotNullOrEmpty]
public string Foo { get; set; }
```

The following script will no longer work since an empty string was being passed through to `Foo`, but this is not longer allowed and will throw an exception

```powershell
Add-SomeObject -Foo ""
```

### Remediation

_Remove the ValidateNotNullOrEmpty attribute from parameter `'<parameter>'`._

## 2100 - Removed Parameter From Parameter Set

### Description

_The parameter '`<parameter>`' in cmdlet '`<cmdlet>`' is no longer in the parameter set '`<parameterSet>`'._

When a parameter is no longer available in a parameter set, that is a breaking change. Existing scripts that use the parameter set with the removed parameter will no longer work.

For example, if we have a cmdlet, `Add-SomeObject` that has parameters `Foo` and `Bar`, both in the same parameter set 

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(ParameterSetName = "ParameterSetOne", Mandatory = false)]
	public string Foo { get; set; }

	[Parameter(ParameterSetName = "ParameterSetOne", Mandatory = false)]
	public string Bar { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but `Foo` is now a part of a different parameter set

```cs
[Parameter(ParameterSetName = "ParameterSetTwo", Mandatory = false)]
public string Foo { get; set; }
```

The following script will no longer work since there is no parameter set that contains both `Foo` and `Bar`

```powershell
Add-SomeObject -Foo "foo" -Bar "bar"
```

### Remediation

_Add parameter '`<parameter>`' back to the parameter set '`<parameterSet>`'._

## 2110 - Changed Parameter Element Type

### Description

_The element type for parameter `'<parameter>'` has been changed from `'<oldElementType>'` to `'<newElementType>'`._

When the type of the parameter is an array, and the element type of that array has been changed, that is a breaking change. 

For example, if we had a cmdlet `Add-SomeObject` with parameter `SomeParameter` that took an array of `Foo` objects

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	public Foo[] SomeParameter { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but `SomeParameter` now accepts an array of `Bar` objects

```cs
[Parameter(Mandatory = false)]
public Bar[] SomeParameter { get; set; }
```

the following script will no longer work since we are passing through an array of `Foo` objects rather than an array of `Bar` objects

```powershell
Add-SomeObject -SomeParameter $fooArray
```

### Remediation

_Change the element type for parameter `'<parameter>'` back to `'<oldElementType>'`._

## 2120 - Changed Parameter Generic Type

### Description

_The generic type for parameter `'<parameter>'` has been changed from `'<oldGenericType>'` to `'<newGenericType>'`._

When the type of the parameter is a generic, and that generic has been changed, that is a breaking change. 

For example, if we had a cmdlet `Add-SomeObject` with parameter `SomeParameter` that took a stack of `Foo` objects

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	public Stack<Foo> SomeParameter { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but `SomeParameter` now accepts a queue of `Bar` objects

```cs
[Parameter(Mandatory = false)]
public Queue<Foo> SomeParameter { get; set; }
```

the following script will no longer work since we are passing through a stack of `Foo` objects rather than a queue of `Foo` objects

```powershell
Add-SomeObject -SomeParameter $fooStack
```

### Remediation

_Change the generic type for parameter `'<parameter>'` back to `'<oldGenericType>'`._

## 2130 - Changed Parameter Generic Type Argument

### Description

_The generic type argument for parameter `'<parameter>'` has been changed from `'<oldArgument>'` to `'<newArgument>'`._

When the type of a parameter is a generic, and one of the arguments of the generic has changed, that is a breaking change. 

For example, if we had a cmdlet `Add-SomeObject` with parameter `SomeParameter` that took a list of `Foo` objects

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	public List<Foo> SomeParameter { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but `SomeParameter` now accepts a list of `Bar` objects

```cs
[Parameter(Mandatory = false)]
public List<Bar> SomeParameter { get; set; }
```

the following script will no longer work since we are passing through a list of `Foo` objects rather than a list of `Bar` objects

```powershell
Add-SomeObject -SomeParameter $fooList
```

### Remediation

_Change the generic type argument for parameter `'<parameter>'` back to `'<oldArgument>'`._

## 2140 - Different Parameter Generic Type Argument Size

### Description

_The number of arguments for generic type `'<genericType>'` for parameter `'<parameter>'` has been changed from `'<oldSize>'` to `'<newSize>'`._

When the type of a parameter is a generic, and the number of arguments for the generic has changed, that is a breaking change. 

For example, if we had a cmdlet `Add-SomeObject` with parameter `SomeParameter` that took a `Tuple<Foo, Bar>`

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	public Tuple<Foo, Bar> SomeParameter { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but `SomeParameter` now accepts a `Tuple<Foo>`

```cs
[Parameter(Mandatory = false)]
public Tuple<Foo> SomeParameter { get; set; }
```

the following script will no longer work since we are passing through a tuple with the incorrect number of arguments

```powershell
Add-SomeObject -SomeParameter $tupleWithFooAndBar
```

### Remediation

_Change the number of arguments for generic type `'<genericType>'` back to `'<oldSize>'`._

## 2150 - Added ValidateRange

### Description

_A validate range has been added for parameter `'<parameter>'` for cmdlet `'<cmdlet>'`._

When a validation range is added to an existing parameter to restrict the values that can be used, that is a breaking change. Existing scripts that use values not in the validation range will no longer work.

For example, if we have a cmdlet, `Add-SomeObject` that has parameter `Foo`  with no validation range

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	public int Foo { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but a validation range has now been added

```cs
[Parameter(Mandatory = false)]
[ValidateRange(1, 100)]
public int Foo { get; set; }
```

The following script will no longer work since previously used values that aren't in the newly added validation range will not work

```powershell
Add-SomeObject -Foo 0
Add-SomeObject -Foo 1000
```

### Remediation

_Remove the validate range from parameter `'<parameter>'`._

## 2160 - Changed ValidateRange Minimum Value

### Description

_The minimum value of the validate range for parameter `'<parameter>'` has been increased from `'<oldMinimum>'` to `'<newMinimum>'`._

When the minimum value of the validation range has been increased, that is a breaking change. Existing scripts that use values that were previously in the accepted range but are no longer due to the increase in the minimum value will no longer work.

For example, if we have a cmdlet, `Add-SomeObject` that has parameter `Foo`  with a validation range containing the values 1 to 100

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	[ValidateRange(1, 100)]
	public int Foo { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but the minimum value of the validation range has been increased to 10

```cs
[Parameter(Mandatory = false)]
[ValidateRange(10, 100)]
public int Foo { get; set; }
```

The following script will no longer work since values less than the new minimum value, but were previously within range, no longer work

```powershell
Add-SomeObject -Foo 1
Add-SomeObject -Foo 5
Add-SomeObject -Foo 10
```

### Remediation

_Change the minimum value of the validate range for parameter `'<parameter>'` back to at most `'<oldMinimum>'`._

## 2170 - Changed ValidateRange Maximum Value

### Description

_The maximum value of the validate range for parameter `'<parameter>'` has been reduced from `'<oldMaximum>'` to `'<newMaximum>'`._

When the maximum value of the validation range has been decreased, that is a breaking change. Existing scripts that use values that were previously in the accepted range but are no longer due to the decrease in the maximum value will no longer work.

For example, if we have a cmdlet, `Add-SomeObject` that has parameter `Foo`  with a validation range containing the values 1 to 100

```cs
[Cmdlet(VerbsCommon.Add, "SomeObject")]
public class AddSomeObject : Cmdlet
{
	[Parameter(Mandatory = false)]
	[ValidateRange(1, 100)]
	public int Foo { get; set; }

    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but the maximum value of the validation range has been decreased to 10

```cs
[Parameter(Mandatory = false)]
[ValidateRange(1, 10)]
public int Foo { get; set; }
```

The following script will no longer work since values greater than the new maximum value, but were previously within range, no longer work

```powershell
Add-SomeObject -Foo 10
Add-SomeObject -Foo 50
Add-SomeObject -Foo 100
```

### Remediation

_Change the maximum value of the validate range for parameter `'<parameter>'` back to at least `'<oldMaximum>'`._

## 3000 - Changed Property Type

### Description

_The type of property `'<property>'` of type `'<type>'` has changed from `'<oldPropertyType>'` to `'<newPropertyType>'`._

When the type of a property has been changed, that is a breaking change.

For example, if there is a class `SomeType` that has property `Foo`

```cs
public class SomeType
{
    public string Foo { get; set; }
}
```

and there is a cmdlet `Get-SomeObject` that returns an object of type `SomeType`

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(SomeType))]
public class GetSomeObject : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but the type of `Foo` is changed

```cs
public int Foo { get; set; }
```

the following script will no longer work since it is trying to access a property whose type has changed, and any use of this property could potentially result in an exception

```powershell
$someType = Get-SomeObject
$someType.Foo
```

### Remediation

_Change the type of property `'<property>'` back to `'<oldPropertyType>'`._

## 3010 - Removed Property

### Description

_The property `'<property>'` of type `'<type>'` has been removed._

When the property of a type has been removed, that is a breaking change.

For example, if there is a class `SomeType` that has property `Foo`

```cs
public class SomeType
{
    public string Foo { get; set; }
}
```

and there is a cmdlet `Get-SomeObject` that returns an object of type `SomeType`

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(SomeType))]
public class GetSomeObject : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but the type of `Foo` is removed, the following script will no longer work since it is trying to access a property that no longer exists for the returned type

```powershell
$someType = Get-SomeObject
$someType.Foo
```

### Remediation

_Add the property `'<property>'` back to type `'<type>'`._

## 3020 - Changed Element Type

### Description

_The element type for property `'<property>'` has been changed from `'<oldElementType>'` to `'<newElementType>'`._

When the type of a property is an array, and the element type has been changed, that is a breaking change.

For example, if there is a class `SomeType` that has property `SomeProperty` whose type is an array of `Foo` objects

```cs
public class SomeType
{
    public Foo[] SomeProperty { get; set; }
}
```

and there is a cmdlet `Get-SomeObject` that returns an object of type `SomeType`

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(SomeType))]
public class GetSomeObject : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but the type of `SomeProperty` is changed to an array of `Bar` objects

```cs
public Bar[] SomeProperty { get; set; }
```

the following script will no longer work since it is trying to access a property whose element type has changed, therefore accessing any of the objects in the array could potentially throw an exception

```powershell
$someType = Get-SomeObject
$someType.SomeProperty[0].Property
$someType.SomeProperty[0].AnotherProperty
```

### Remediation

_Change the element type for property `'<property>'` back to `'<oldElementType>'`._

## 3030 - Changed Generic Type

### Description

_The generic type for property `'<property>'` has been changed from `'<oldGenericType>'` to `'<newGenericType>'`._

When the type of a property is a generic, and the generic has been changed, that is a breaking change.

For example, if there is a class `SomeType` that has property `SomeProperty` whose type is a stack of `Foo` objects

```cs
public class SomeType
{
    public Stack<Foo> SomeProperty { get; set; }
}
```

and there is a cmdlet `Get-SomeObject` that returns an object of type `SomeType`

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(SomeType))]
public class GetSomeObject : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but the type of `SomeProperty` is changed to a queue of `Foo` objects

```cs
public Queue<Foo> SomeProperty { get; set; }
```

the following script will no longer work since it is trying to access methods of the `Stack` class that are not a part of the `Queue` class

```powershell
$someType = Get-SomeObject
$someType.SomeProperty.Pop()
$someType.SomeProperty.Push($foo)
```

### Remediation

_Change the generic type for property `'<property>'` back to `'<oldGenericType>'`._

## 3040 - Changed Generic Type Argument

### Description

_The generic type argument for property `'<property>'` has been changed from `'<oldArgument>'` to `'<newArgument>'`._

When the type of a property is a generic, and one of the arguments of the generic has been changed, that is a breaking change.

For example, if there is a class `SomeType` that has property `SomeProperty` whose type is a list of `Foo` objects

```cs
public class SomeType
{
    public List<Foo> SomeProperty { get; set; }
}
```

and there is a cmdlet `Get-SomeObject` that returns an object of type `SomeType`

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(SomeType))]
public class GetSomeObject : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but the type of `SomeProperty` is changed to a list of `Bar` objects

```cs
public List<Bar> SomeProperty { get; set; }
```

the following script will no longer work since it is trying to access properties of `Foo` objects that may not be a part of the `Bar` object

```powershell
$someType = Get-SomeObject
foreach ($foo in $someType.SomeProperty)
{
    $foo.Property
    $foo.AnotherProperty
}
```

### Remediation

_Change the generic type argument for property `'<property>'` back to `'<oldArgument>'`._

## 3050 - Different Generic Type Argument Size

### Description

_The number of arguments for generic type `'<genericType>'` for property `'<property>'` has been changed from `'<oldSize>'` to `'<newSize>'`._

When the type of a property is a generic, and the number of arguments for the generic has been changed, that is a breaking change.

For example, if there is a class `SomeType` that has property `SomeProperty` whose type is a `Tuple<Foo, Bar>`

```cs
public class SomeType
{
    public Tuple<Foo, Bar> SomeProperty { get; set; }
}
```

and there is a cmdlet `Get-SomeObject` that returns an object of type `SomeType`

```cs
[Cmdlet(VerbsCommon.Get, "SomeObject"), OutputType(typeof(SomeType))]
public class GetSomeObject : Cmdlet
{
    protected override void BeginProcessing()
    {
        // cmdlet logic
    }
}
```

but the type of `SomeProperty` is changed to a `Tuple<Foo>`

```cs
public Tuple<Foo> SomeProperty { get; set; }
```

the following script will no longer work since it is trying to access elements in the tuple that no longer exist

```powershell
$someType = Get-SomeObject
$someType.SomeProperty.Item1
$someType.SomeProperty.Item2
```

### Remediation

_Change the number of arguments for generic type `'<genericType>'` back to `'<oldSize>'`._