<!-- DO NOT DELETE THIS TEMPLATE -->

## Description

<!-- Please add a brief description of the changes made in this PR -->

## Checklist

- [ ] I have read the [_Submitting Changes_](../blob/master/CONTRIBUTING.md#submitting-changes) section of [`CONTRIBUTING.md`](../blob/master/CONTRIBUTING.md)
- [ ] The title of the PR is clear and informative
- [ ] The appropriate `ChangeLog.md` file(s) has been updated:
    - For any service, the `ChangeLog.md` file can be found at `src/{{SERVICE}}/{{SERVICE}}/ChangeLog.md`
    - A snippet outlining the change(s) made in the PR should be written under the `## Upcoming Release` header -- no new version header should be added
- [ ] The PR does not introduce [breaking changes](../blob/master/documentation/breaking-changes/breaking-changes-definition.md)
- [ ] If applicable, the changes made in the PR have proper test coverage
- [ ] For public API changes to cmdlets:
    - [ ] a cmdlet design review was approved for the changes in [this repository](https://github.com/Azure/azure-powershell-cmdlet-review-pr) (_Microsoft internal only_)
    - [ ] the markdown help files have been regenerated using the commands listed [here](../blob/master/documentation/development-docs/help-generation.md#updating-all-markdown-files-in-a-module)
