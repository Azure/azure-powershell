# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
    Create PR to azure-powershell repo

#>
param(
    [Parameter(Mandatory = $true)]
    [string]$BotAccessToken,

    [Parameter(Mandatory = $true)]
    [string]$Title,

    [Parameter(Mandatory = $true)]
    [string]$HeadBranch,

    [Parameter(Mandatory = $true)]
    [string]$BaseBranch,

    [Parameter(Mandatory = $false)]
    [string]$Description,

    [Parameter(Mandatory = $false)]
    [boolean]$Draft = $false,

    [switch]$FailOnPRExisted = $false
)

$Headers = @{"Accept" = "application/vnd.github+json"; "Authorization" = "Bearer $BotAccessToken" }
$PrBody = @"
<!-- DO NOT DELETE THIS TEMPLATE -->

## Description
$Description

<!-- Please add a brief description of the changes made in this PR. If you have an ongoing or finished cmdlet design, please paste the link below. -->

## Checklist

- [x] Check this box to confirm: **I have read the [_Submitting Changes_](../blob/main/CONTRIBUTING.md#submitting-changes) section of [`CONTRIBUTING.md`](../blob/main/CONTRIBUTING.md) and reviewed the following information:**

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
"@

$RequestBody = @{"title" = $Title; "body" = $PrBody; "head" = $HeadBranch; "base" = $BaseBranch; "draft" = $Draft}
$Uri = "https://api.github.com/repos/Azure/azure-powershell/pulls"

$PrUri = "https://api.github.com/repos/Azure/azure-powershell/pulls?head=Azure:$HeadBranch&base=$BaseBranch"
$PullRequests = Invoke-RestMethod -Uri $PrUri -Method GET -Headers $Headers 
if ($PullRequests.Length -eq 0) {
    Invoke-WebRequest -Uri $Uri -Method POST -Headers $Headers -Body ($RequestBody | ConvertTo-Json)
    exit 0
}

if ($FailOnPRExisted) {
    Write-Error "The PR named $Title already exists."
    exit 1
}
else {
    Write-Host "The PR named $Title already exists. Skipping creation because FailOnPRExisted is set to $FailOnPRExisted."
    exit 0
}

