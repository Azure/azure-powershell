<!-- DO NOT DELETE THIS TEMPLATE -->

## Description
<!--
Please add an informative description that covers the changes made by the pull request.

If applicable, reference the bug/issue that this pull request fixes here.
-->

---

This checklist is used to make sure that common guidelines for a pull request are followed. You can find a more complete discussion of PowerShell cmdlet best practices [here](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx).

- [ ] **I have read the [contribution guidelines](https://github.com/Azure/azure-powershell/blob/preview/CONTRIBUTING.md).**
- [ ] **If changes were made to any cmdlet, the XML help was regenerated using the [platyPSHelp module](https://github.com/Azure/azure-powershell/blob/preview/documentation/help-generation.md).**
- [ ] **If any large changes are made to a service, they are reflected in the respective [change log](https://github.com/Azure/azure-powershell/blob/preview/CONTRIBUTING.md#updating-the-change-log).**

### [General Guidelines](https://github.com/Azure/azure-powershell/blob/preview/CONTRIBUTING.md#general-guidelines)
- [ ] Title of the pull request is clear and informative.
- [ ] There are a small number of commits, each of which have an informative message. This means that previously merged commits do not appear in the history of the PR. For more information on cleaning up the commits in your PR, [see this page](https://github.com/Azure/azure-powershell/blob/preview/documentation/cleaning-up-commits.md).
- [ ] The pull request does not introduce [breaking changes](https://github.com/Azure/azure-powershell/blob/preview/documentation/breaking-changes/breaking-changes-definition.md) (unless a major version change occurs in the assembly and module).

### [Testing Guidelines](https://github.com/Azure/azure-powershell/blob/preview/CONTRIBUTING.md#testing-guidelines)
- [ ] Pull request includes test coverage for the included changes.
- [ ] PowerShell scripts used in tests should do any necessary setup as part of the test or suite setup, and should not use hard-coded values for locations or existing resources.

### [Cmdlet Signature Guidelines](https://github.com/Azure/azure-powershell/blob/preview/CONTRIBUTING.md#cmdlet-signature-guidelines)
- [ ] New cmdlets that make changes or have side effects should implement `ShouldProcess` and have `SupportShouldProcess=true` specified in the cmdlet attribute. You can find more information on `ShouldProcess` [here](https://github.com/Azure/azure-powershell/wiki/PowerShell-Cmdlet-Design-Guidelines#supportsshouldprocess).
- [ ] Cmdlet specifies `OutputType` attribute if any output is produced - if the cmdlet produces no output, it should implement a `PassThru` parameter.

### [Cmdlet Parameter Guidelines](https://github.com/Azure/azure-powershell/blob/preview/CONTRIBUTING.md#cmdlet-parameter-guidelines)
- [ ] Parameter types should not expose types from the management library - complex parameter types should be defined in the module.
- [ ] Complex parameter types are discouraged - a parameter type should be simple types as often as possible. If complex types are used, they should be shallow and easily creatable from a constructor or another cmdlet.
- [ ] Cmdlet parameter sets should be mutually exclusive - each parameter set must have at least one mandatory parameter not in other parameter sets.
