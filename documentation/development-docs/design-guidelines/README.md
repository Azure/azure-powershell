## Azure PowerShell Design Guidelines

In this folder, you will find best practices and design guidelines for different components of Azure PowerShell.

### Table of contents

- [Cmdlet Best Practices](./cmdlet-best-practices.md)
    - [Cmdlet Naming Conventions](./cmdlet-best-practices.md#cmdlet-naming-conventions)
    - [Output Type](./cmdlet-best-practices.md#output-type)
    - [`ShouldProcess`](./cmdlet-best-practices.md#shouldprocess)
    - [`AsJob`](./cmdlet-best-practices.md#asjob)
    - [Required Parameter Sets](./cmdlet-best-practices.md#required-parameter-sets)
- [Module Best Practices](./module-best-practices.md)
    - [Module Metadata](./module-best-practices.md#module-metadata)
    - [Module Dependencies](./module-best-practices.md#module-dependencies)
- [Parameter Best Practices](./parameter-best-practices.md)
    - [Parameter Guidelines](./parameter-best-practices.md#parameter-guidelines)
        - [Parameter Naming Conventions](./parameter-best-practices.md#parameter-naming-conventions)
        - [Parameter Types](./parameter-best-practices.md#parameter-types)
        - [Argument Completers](./parameter-best-practices.md#argument-completers)
    - [Parameter Set Guidelines](./parameter-best-practices.md#parameter-set-guidelines)
        - [Parameter Set Naming Conventions](./parameter-best-practices.md#parameter-set-naming-conventions)
        - [Attribute Guidelines](./parameter-best-practices.md#attribute-guidelines)
- [Piping Best Practices](./piping-best-practices.md)
    - [Piping in PowerShell](./piping-best-practices.md#piping-in-powershell)
        - [Understanding Piping](./piping-best-practices.md#understanding-piping)
    - [Piping in Azure PowerShell](./piping-best-practices.md#piping-in-azure-powershell)
        - [Using the `-InputObject` Parameter](./piping-best-practices.md#using-the-inputobject-parameter)
        - [Using the `-ResourceId` Parameter](./piping-best-practices.md#using-the-resourceid-parameter)
        - [Full examples](./piping-best-practices.md#full-examples)
- [`ShouldProcess` and `ConfirmImpact`](./should-process-confirm-impact.md)
    - [`ShouldProcess`](./should-process-confirm-impact.md#shouldprocess)
    - [`ConfirmImpact`](./should-process-confirm-impact.md#confirmimpact)
