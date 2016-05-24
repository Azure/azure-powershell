# Azure PowerShell Design Guidelines for Azure Resource Manager (ARM) Cmdlets

* [Modules and Versioning](#Modules-and-Versioning)
* Cmdlet Dependencies
* Cmdlet Signature
  * Cmdlet Naming
  * Cmdlet attributes
  * Types used in parameters and output
  * Parameters
    * Parameter Attributes
    * Parameter Names and Aliases
    * Parameter Sets
    * Dynamic Parameters
    * Designing Cmdlets for piping
* Cmdlet Execution
  * Overriding AzureRMCmdlet execution methods
  * Handling cmdlet Output
  * Handling cmdlet Errors
  * Displaying Progress
  * Writing Messages
  * Confirmation
* Cmdlet Formatting
* Cmdlet Help
* Cmdlet Testability
* Commits and Pull Requests

# Modules and Versioning
1. Azure PowerShell cmdlets are organized as one module per ARM Resource Provider.  Each module *must* include a module manifest (.psd1) file.  The psd1 file links together the assemblies, help files, formats, scripts, and external dependencies that make up the module.
2. [**Preliminary**] Azure PowerShell modules *must* include additional metadata that indicates the api-version used in management calls to ARM. This metadata is represented as module tags of the format ```RPName: api-version```.  For example ```Microsoft.Compute/VirtualMachine: 2015-06-01```
3. The Azure PowerShell cmdlets use [semantic versioning](http://semver.org) to version each module. Module version changes reflect changes in the signature of cmdlets in the module. Breaking changes result in a major version update.  Non-breaking changes in the public interface result in a minor version update.  Other changes result in a revision update.  Breakinc changes are defined as follows:
  - Cmdlets: 
    - Removing a cmdlet
    - Change in cmdlet name without an alias to the original name
    - Removing or changing a cmdlet alias
    - Removal of Cmdlet attribuet option (SupportShouldProcess, SupportsPaging)
    - Breaking change in OutputType or removal of OutputType attribute
  - Parameters
    - Removing a parameter
    - Changing the name of a parameter without an alias to the original parameter name
    - Breaking change in parameter type
    - Adding a required parameter to an existing parameter set (adding new parameter sets, or adding additional optional prameters is not breaking)
    - Changing parameter order for parameter sets with ordered parameters
    - Removing or changign a parameter alias
    - Removing or changing existing parameter attribute values
    - Making parameter validation more exclusive (for example: removing values from a ValidateSet)
  - Output and Parameter Types
    - Changing property names without an accompanying alias to the original name
    - Removing properties
    - Adding additional required properties

# Cmdlet Dependencies

# Cmdlet Signature

## Cmdlet Naming

## Cmdlet attributes

## Types used in parameters and output

## Parameters

### Parameter Attributes

### Parameter Names and Aliases

### Parameter Sets

### Dynamic Parameters

### Designing Cmdlets for piping

# Cmdlet Execution

## Overriding AzureRMCmdlet execution methods

## Handling cmdlet Output

## Handling cmdlet Errors

## Displaying Progress

## Writing Messages

## Confirmation

# Cmdlet Help

# Cmdlet Testability

# Commits and Pull Requests

# Learn More
* Required Features For Resource Providers (RPs)
* How to Write Cmdlets and Tests
* [How to contribute](../CONTRIBUTING.md)
