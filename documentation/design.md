# Azure PowerShell Design Guidelines for Azure Resource Manager (ARM) Cmdlets

* [Modules and Versioning](#modules-and-versioning)
* [Module Dependencies](#module-dependencies)
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
    - Changing a cmdlet name without an alias to the original name
    - Removing or changing a cmdlet alias
    - Removing a Cmdlet attribuet option (SupportShouldProcess, SupportsPaging)
    - Breaking change in OutputType or removal of OutputType attribute
  - Parameters
    - Removing a parameter
    - Changing the name of a parameter without an alias to the original parameter name
    - Breaking change in parameter type
    - Adding a required parameter to an existing parameter set (adding new parameter sets, or adding additional optional prameters is not breaking)
    - Changing parameter order for parameter sets with ordered parameters
    - Removing or changing a parameter alias
    - Removing or changing existing parameter attribute values
    - Making parameter validation more exclusive (for example: removing values from a ValidateSet)
  - Output and Parameter Types
    - Changing property names without an accompanying alias to the original name
    - Removing properties
    - Adding additional required properties
    - Adding required parameters, changing parameter names, or parameter types for methods or constructors
    - Changing return types of methods
4. **Breaking Change Notification** Breaking changes **should** provide advance notification by at least one release. This is accomplished through printing messages when the deprecated pattern is used.  The ```Obsolete`` attribute is provided for marking cmdlets and parameters that will be removed or have changed.

# Module Dependencies
Assembly dependencies are split into two categories:
- Shared dependencies, such as common runtime and framework assemblies shared across cmdlets
- Single module dependencies, such as the management library

## Requirements
1. [**Preliminary**] A Cmdlet assembly *may not* take an assembly dependency on another cmdlet assembly.
2. A module *may* take a dependency on another module through the module manifest, provided the dependency is guaranteed to be backward compatible (for example, the dependency on the profile cmdlets).
 - Dependencies on common types between cmdlets must be managed through the common libraries
 - Dependencies on management libraries shared with other modules (Resource Manager, Storage) must be taken through the common libraries.
 - Dependencies on external framework assemblies must be guaranteed to be backward compatible. If shared by multiple modules, they must be taken through the common libraries.
3. [**Preliminary**] All Parameter and output types shared between cmdlets *must* be managed through the common libraries (for example: AzureStorageContext, AzureProfile)

# Cmdlet Signature

## Cmdlet Naming

## Cmdlet attributes

## Types used in parameters and output

## Parameters

### Common Required Parameters and Parameter Sets

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
