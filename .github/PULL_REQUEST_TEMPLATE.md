<!-- DO NOT DELETE THIS TEMPLATE -->

## Description

<!-- Please add a brief description of the changes made in this PR. If you have an ongoing or finished cmdlet design, please paste the link below. -->

## Mandatory Checklist

- Please choose the target release of Azure PowerShell
  - [ ] [General release](../blob/main/CONTRIBUTING.md#target-release-types)
  - [ ] [Public preview](../blob/main/CONTRIBUTING.md#target-release-types)
  - [ ] [Private preview](../blob/main/CONTRIBUTING.md#target-release-types)
  - [ ] [Engineering build](../blob/main/CONTRIBUTING.md#target-release-types)
  - [ ] N/A

- [ ] Check this box to confirm: **I have read the [_Submitting Changes_](../blob/main/CONTRIBUTING.md#submitting-changes) section of [`CONTRIBUTING.md`](../blob/main/CONTRIBUTING.md) and reviewed the following information:**

* **SHOULD** update `ChangeLog.md` file(s) appropriately
    * For SDK-based development mode, update `src/{{SERVICE}}/{{SERVICE}}/ChangeLog.md`.
        * A snippet outlining the change(s) made in the PR should be written under the `## Upcoming Release` header in the past tense. 
    * For autorest-based development mode, include the changelog in the PR description.
    * Should **not** change `ChangeLog.md` if no new release is required, such as fixing test case only.
* **SHOULD** regenerate markdown help files if there is cmdlet API change. [Instruction](../blob/main/documentation/development-docs/help-generation.md#updating-all-markdown-files-in-a-module)
* **SHOULD** have proper test coverage for changes in pull request.
* **SHOULD NOT** adjust version of module manually in pull request
