# PowerShell Design Guidelines Summary

Condensed validation rules extracted from the [Azure PowerShell Design Guidelines](https://github.com/Azure/azure-powershell/tree/master/documentation/development-docs/design-guidelines). The agent checks these at each step. For full details or edge-case rationale, fetch the source docs via GitHub MCP Server.

---

## Naming Conventions {#naming}

| Rule                  | Description                                                                                                                                                                |
| --------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Verb-Noun format**  | Use an [approved PowerShell verb](https://learn.microsoft.com/en-us/powershell/scripting/developer/cmdlet/approved-verbs-for-windows-powershell-commands) + specific noun. |
| **Az prefix**         | ARM cmdlet nouns must start with `Az` (e.g., `Get-AzVM`).                                                                                                                  |
| **Pascal case**       | Capitalize the first letter of the verb and every term in the noun.                                                                                                        |
| **Two-char acronyms** | Fully capitalize (e.g., `VM`, `DB`).                                                                                                                                       |
| **3+ char acronyms**  | Only capitalize the first letter (e.g., `Sql`, `Vmss`).                                                                                                                    |
| **Singular nouns**    | Use singular form (e.g., `Get-AzVM` not `Get-AzVMs`).                                                                                                                      |
| **Set vs. Update**    | `Set-` for PUT (full replace); `Update-` for PATCH (partial update).                                                                                                       |

---

## Parameter Best Practices {#parameters}

| Rule                              | Description                                                                                                                           |
| --------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------- |
| **Three required parameter sets** | Interactive (`-Name` + `-ResourceGroupName`), ResourceId (`-ResourceId`), InputObject (`-InputObject`).                               |
| **Pascal case**                   | Parameter names use Pascal case.                                                                                                      |
| **Specific types**                | Never use `object`, `PSObject`, `PSCustomObject`, or `string` as output type.                                                         |
| **-PassThru**                     | Cmdlets that return no output must implement `-PassThru` (returns `bool`).                                                            |
| **-AsJob**                        | All long-running operations must support `-AsJob`.                                                                                    |
| **ShouldProcess**                 | Cmdlets that create, delete, update, start, or stop resources must implement `SupportsShouldProcess` (adds `-WhatIf` and `-Confirm`). |
| **-Force**                        | Only for scenarios requiring extra confirmation (e.g., overwriting existing resources, deleting containers with children).            |
| **Mandatory parameters**          | Mark as `Mandatory = true` only when the cmdlet cannot function without the value.                                                    |

---

## Output Type Rules

| Rule                      | Description                                                                          |
| ------------------------- | ------------------------------------------------------------------------------------ |
| **Specific OutputType**   | Always declare `[OutputType(typeof(...))]` with a concrete type.                     |
| **Wrap SDK types**        | Return `PS*` wrapper types (e.g., `PSVirtualMachine`) instead of raw .NET SDK types. |
| **Enumerate collections** | Use `WriteObject(collection, true)` to enumerate — never return a raw `List<T>`.     |
| **No string returns**     | If you need to return string data, wrap it in a typed object.                        |

---

## Piping Best Practices {#piping}

| Rule                                | Description                                                       |
| ----------------------------------- | ----------------------------------------------------------------- | --------------------------------------------------------------- |
| **InputObject piping**              | Support `Get-Az\*                                                 | Update-Az\*` by accepting the output type of the source cmdlet. |
| **ResourceId piping**               | Support `Get-AzResource                                           | Remove-Az\*`via the`-ResourceId` parameter set.                 |
| **ValueFromPipeline**               | Mark `-InputObject` with `ValueFromPipeline = true`.              |
| **ValueFromPipelineByPropertyName** | Mark `-ResourceId` with `ValueFromPipelineByPropertyName = true`. |

---

## ShouldProcess & Confirm Impact

| Scenario                             | ConfirmImpact | Behavior                               |
| ------------------------------------ | ------------- | -------------------------------------- |
| Read-only (Get)                      | None          | No confirmation                        |
| Low-risk change                      | Low           | Confirms only with `-Confirm`          |
| Standard mutation (New, Set, Update) | Medium        | Confirms only with `-Confirm`          |
| Destructive action (Remove, Stop)    | High          | Always prompts unless `-Force` is used |

---

## Module Best Practices

- One module per Azure service (e.g., `Az.Compute`).
- Module manifest must declare all exported cmdlets.
- Help content must be generated via platyPS.
- Breaking changes require a breaking change attribute annotation and a deprecation period.

---

## Managed Identity Best Practices

- Support system-assigned and user-assigned managed identities.
- Use `-IdentityType` parameter with values: `SystemAssigned`, `UserAssigned`, `SystemAssignedUserAssigned`, `None`.
- `-IdentityId` accepts an array of user-assigned identity resource IDs.

---

## Source Documents

For the full, authoritative guidelines, see:

- [Cmdlet Best Practices](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/cmdlet-best-practices.md)
- [Parameter Best Practices](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/parameter-best-practices.md)
- [Piping Best Practices](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/piping-best-practices.md)
- [ShouldProcess and Confirm Impact](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/should-process-confirm-impact.md)
- [Module Best Practices](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/module-best-practices.md)
- [Managed Identity Best Practices](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/managed-identity-best-practices.md)
- [Azure PowerShell Exceptions](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/azure-powershell-exceptions.md)
