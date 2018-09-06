# Breaking Change Definition

This document lists the various types of breaking changes and how to call them out in your code using the [breaking change attributes](./breaking-changes-attribute-help.md).

Breaking changes in cmdlets are defined as follows:

# Cmdlets
- Removing a cmdlet
  - Use the breaking change attribute ["CmdletDeprecationAttribute"](./breaking-changes-attribute-help.md#cmdletdeprecationattribute), more specificallly the ["cmdlet deprecation without replacement"](./breaking-changes-attribute-help.md#when-there-is-no-replacement-cmdlet) option
- Changing a cmdlet name without an alias to the original name
  - Use the breaking change attribute ["CmdletDeprecationAttribute"](./breaking-changes-attribute-help.md#cmdletdeprecationattribute), more specificallly the ["cmdlet deprecation with replacement"](./breaking-changes-attribute-help.md#when-there-is-a-replacement-cmdlet) option
- Removing or changing a cmdlet alias
  - Use the generic breaking change attribute ["GenericBreakingChangeAttribute"](./breaking-changes-attribute-help.md#genericbreakingchangeattribute) with a [simple message](./breaking-changes-attribute-help.md#with-a-simple-message) calling out the alias that is being deprecated
- Removing a cmdlet attribute option (`SupportShouldProcess`, `SupportsPaging`)
  - Use the generic breaking change attribute ["GenericBreakingChangeAttribute"](./breaking-changes-attribute-help.md#genericbreakingchangeattribute) with a [simple message](./breaking-changes-attribute-help.md#with-a-simple-message) calling out the cmdlet attribute that is being removed
- Breaking change in `OutputType` or removal of `OutputType` attribute
  - Use the cmdlet output type breaking change attribute ["CmdletOutputBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletoutputbreakingchangeattribute)
    - To call out the output type being changed use the above attribute [as described here](./breaking-changes-attribute-help.md#the-output-return-type-is-changing).
    - To deprecate an output type use the above attribute [as described here](./breaking-changes-attribute-help.md#the-output-return-type-is-being-dropped).

# Parameters
- Removing a parameter
  - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#a-parameter-is-being-deprecated) to call out a parameter being removed.
- Changing the name of a parameter without an alias to the original parameter name
  - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#a-parameter-is-being-replaced) to call out a parameter name change.
- Breaking change in parameter type
  - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#a-parameter-is-changing-its-type) to call out a parameter name change.
- Adding a required parameter to an existing parametrer set (adding new parameter sets or adding additional optional parameters is not a breaking change)
  - An existing parameter becomes mandatry :
    - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#a-parameter-is-becoming-mandatory) to call out a parameter becoming mandatory.
  - Adding a new mandatory parameter to a parameter set:
      - Use the generic breaking change attribute ["GenericBreakingChangeAttribute"](./breaking-changes-attribute-help.md#genericbreakingchangeattribute) with a [custom message](./breaking-changes-attribute-help.md#with-a-simple-message) calling out the new mandatiry parameter that is going to be added to the parameter set.
- Changing parameter order for parameter sets with ordered parameters
    - Use the generic breaking change attribute ["GenericBreakingChangeAttribute"](./breaking-changes-attribute-help.md#genericbreakingchangeattribute) with a [custom message](./breaking-changes-attribute-help.md#with-a-simple-message) calling out the new order in the parameter set.
- Removing or changing a parameter alias
  - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#generic-change-in-a-parameter) to call out the change by altering the change description.
- Removing or changing existing parameter attribute values
  - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#generic-change-in-a-parameter) to call out the change by altering the change description.
- Making parameter validation more exclusive (_e.g.,_ removing values from a `ValidateSet`)
  - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#generic-change-in-a-parameter) to call out the change by altering the change description.

# Output and Parameter Types
- Changing property names without an accompanying alias to the original name
  - In the output type
    - Use the cmdlet output type breaking change attribute ["CmdletOutputBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletoutputbreakingchangeattribute) [as follows](./breaking-changes-attribute-help.md#a-mixed-example) to call out property name changes (do not specify the attribute property "ReplacementCmdletOutputTypeName" for this purpose).
  - In a parameter
    - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#generic-change-in-a-parameter) to call out the change.
- Removing properties
  - In the output type
      - Use the cmdlet output type breaking change attribute ["CmdletOutputBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletoutputbreakingchangeattribute) [as follows](./breaking-changes-attribute-help.md#a-few-properties-in-the-output-type-are-being-deprecated) to call out derecated properties. 
  - In a parameter
      - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#generic-change-in-a-parameter) to call out the change.
- Adding additional required properties
  - In the output type
      - Use the cmdlet output type breaking change attribute ["CmdletOutputBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletoutputbreakingchangeattribute) [as follows](./breaking-changes-attribute-help.md#a-few-new-properties-are-bing-added-to-the-output-type) to call out derecated properties. 
  - In a parameter
      - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#generic-change-in-a-parameter) to call out the change.
- Adding required parameters, changing parameter names, or parameter types for methods or constructors
    - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#generic-change-in-a-parameter) to call out the change.
- Changing return types of methods
    - Use the parameter breaking change attribute ["CmdletParameterBreakingChangeAttribute"](./breaking-changes-attribute-help.md#cmdletparameterbreakingchangeattribute) as [described here](./breaking-changes-attribute-help.md#generic-change-in-a-parameter) to call out the change.
