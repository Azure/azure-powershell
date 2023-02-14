<!-- DO NOT DELETE THIS TEMPLATE -->

## Description

<<<<<<< HEAD
<!-- Please add a brief description of the changes made in this PR -->

## Checklist

- [ ] I have read the [_Submitting Changes_](https://github.com/Azure/azure-powershell/blob/master/CONTRIBUTING.md#submitting-changes) section of [`CONTRIBUTING.md`](https://github.com/Azure/azure-powershell/blob/master/CONTRIBUTING.md)
- [ ] The title of the PR is clear and informative
- [ ] The appropriate [change log has been updated](https://github.com/Azure/azure-powershell/blob/master/CONTRIBUTING.md#updating-the-change-log)
- [ ] The PR does not introduce [breaking changes](https://github.com/Azure/azure-powershell/blob/master/documentation/breaking-changes/breaking-changes-definition.md)
- [ ] If applicable, the changes made in the PR have proper test coverage
- [ ] For public API changes to cmdlets:
    - [ ] the changes have gone through a [cmdlet design review](https://github.com/Azure/azure-powershell-cmdlet-review-pr) (Microsoft internal partners only)
    - [ ] the cmdlet markdown files were [generated using the `platyPS` module](https://github.com/Azure/azure-powershell/blob/master/documentation/development-docs/help-generation.md)
=======
<!-- Please add a brief description of the changes made in this PR. If you have an ongoing or finished cmdlet design, please paste the link below. -->

## Checklist

- [ ] Check this box to confirm: **I have read the [_Submitting Changes_](../blob/main/CONTRIBUTING.md#submitting-changes) section of [`CONTRIBUTING.md`](../blob/main/CONTRIBUTING.md) and reviewed the following information:**

* **SHOULD** select appropriate branch. Cmdlets from Autorest.PowerShell should go to [`generation`](https://github.com/Azure/azure-powershell/tree/generation) branch. 
* **SHOULD** make the title of PR clear and informative, and in the present imperative tense. 
* **SHOULD** update `ChangeLog.md` file(s) appropriately
    * For any service, the `ChangeLog.md` file can be found at `src/{{SERVICE}}/{{SERVICE}}/ChangeLog.md`
    * A snippet outlining the change(s) made in the PR should be written under the `## Upcoming Release` header in the past tense. Add changelog in description section if PR goes into [`generation`](https://github.com/Azure/azure-powershell/tree/generation) branch.
    * Should **not** change `ChangeLog.md` if no new release is required, such as fixing test case only.
* **SHOULD** have approved design review for the changes in [this repository](https://github.com/Azure/azure-powershell-cmdlet-review-pr) ([_Microsoft internal only_](../blob/main/CONTRIBUTING.md#onboarding)) with following situations
    * Create new module from scratch
    * Create new resource types which are not easy to conform to [Azure PowerShell Design Guidelines](../blob/main/documentation/development-docs/design-guidelines)
    * Create new resource type which name doesn't use module name as prefix
    * Have design question before implementation
* **SHOULD** regenerate markdown help files if there is cmdlet API change. [Instruction](../blob/main/documentation/development-docs/help-generation.md#updating-all-markdown-files-in-a-module)
* **SHOULD** have proper test coverage for changes in pull request.
* **SHOULD NOT** introduce [breaking changes](../blob/main/documentation/breaking-changes/breaking-changes-definition.md) in Az minor release except preview version.
* **SHOULD NOT** adjust version of module manually in pull request
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
