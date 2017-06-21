CHANGE IN FILE

# Breaking Change Definition

Breaking changes in cmdlets are defined as follows:

## Cmdlets
- Removing a cmdlet
- Changing a cmdlet name without an alias to the original name
- Removing or changing a cmdlet alias
- Removing a cmdlet attribute option (`SupportShouldProcess`, `SupportsPaging`)
- Breaking change in `OutputType` or removal of `OutputType` attribute

## Parameters
- Removing a parameter
- Changing the name of a parameter without an alias to the original parameter name
- Breaking change in parameter type
- Adding a required parameter to an existing parametrer set (adding new parameter sets or adding additional optional parameters is not a breaking change)
- Changing parameter order for parameter sets with ordered parameters
- Removing or changing a parameter alias
- Removing or changing existing parameter attribute values
- Making parameter validation more exclusive (_e.g.,_ removing values from a `ValidateSet`)

## Output and Parameter Types
- Changing property names without an accompanying alias to the original name
- Removing properties
- Adding additional required properties
- Adding required parameters, changing parameter names, or parameter types for methods or constructors
- Changing return types of methods
