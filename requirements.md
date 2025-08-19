# Automatically Trigger ADO Pipelines for PR by Azure Members

## Background

The `Azure/azure-powershell` repository is an open-source repository with lots of community contributions, whose quality is ensured through CI - Azure DevOps pipelines. The pipelines are currently not triggered automatically for pull requests (PRs) made by anyone except for repository owners, which can slow down the development process and make it harder to catch issues early. The purpose of this document is to automatically trigger ADO pipelines for PRs made by Azure members.

## Concepts

- **Azure member**: An Azure member is a GitHub user who is part of the Azure organization.
- **Azure organization**: The Azure organization is the GitHub organization that contains the Azure-related repositories, as well as GitHub users who are members of the Azure team.

## Goal & Scope

Set up a GitHub Action that listens to any change in pull requests and triggers the ADO pipeline for Azure members by commenting "/azp run".

Scope is all pull requests to the `Azure/azure-powershell` repository.

## Requirements

1. **Trigger by push**: The system must trigger the ADO pipelines when a push is made to the PR branch.
   - This includes both the initial creation of the PR and any subsequent updates to the PR.
2. **Azure Member Verification**: The system must verify that the PR is **created** by an Azure member.
   - The system should not trigger the pipeline for PRs created by non-Azure members.
   - Whether it's *updated* by an Azure member doesn't matter because non-members cannot push changes to the PR.
3. **Authenticate with GitHub token**: The system must authenticate using the GitHub token provided by the `GITHUB_TOKEN` secret.

## Resources

- There is an existing PowerShell script in `tools/GitHubOrgMember` that can be used to verify Azure organization membership.
    - The script depends on `GitHub CLI` for querying GitHub API and authentication.
- Commenting "/azp run" on the PR should trigger the ADO pipeline if the account has the right permission.

## Notes

- In case anything unexpected happens, the system should log the error and simply fail the GitHub Action.
- Duplicating "/azp run" comments isn't a problem to the system and can be safely ignored.
- Do not use `pull_request_target` event for this workflow.
