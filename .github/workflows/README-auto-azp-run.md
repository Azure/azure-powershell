# Auto ADO Pipeline Trigger for Azure Members

This GitHub Action automatically triggers Azure DevOps (ADO) pipelines for pull requests created by Azure organization members.

## How it works

1. **Trigger**: The workflow runs when a PR is opened or updated (push to PR branch)
2. **Membership Check**: Uses the existing script in `tools/GitHubOrgMember/Check-AzureOrgMembership.ps1` to verify if the PR author is an Azure organization member
3. **Authentication**: Uses the built-in `GITHUB_TOKEN` secret for authentication
4. **Pipeline Trigger**: Comments "/azp run" on the PR to trigger the ADO pipeline

## Required Permissions

The workflow uses the built-in `GITHUB_TOKEN` with the following permissions:
- `pull-requests: write` - To comment on PRs
- `contents: read` - To checkout the repository

No additional secrets need to be configured.

## Workflow Behavior

- ✅ **Azure Members**: ADO pipeline is triggered automatically with "/azp run" comment
- ❌ **Non-Azure Members**: Workflow silently completes without action
- 🔴 **Errors**: Workflow fails with error details in logs

## Troubleshooting

### Common Issues

1. **GitHub CLI Authentication Failed**
   - This should not happen as we use the built-in `GITHUB_TOKEN`
   - Check if the token permissions are sufficient

2. **Membership Check Failed**
   - GitHub API rate limits may cause temporary failures
   - User might have private membership in Azure organization
   - Check the GitHub CLI authentication

3. **Comment Creation Failed**
   - Verify the workflow has `pull-requests: write` permission
   - Check if the PR number is correct

### Logs

Check the GitHub Actions logs for detailed error messages and troubleshooting information.

## Security Notes

- Uses `pull_request` trigger (safe for public repositories)
- Only uses built-in `GITHUB_TOKEN` - no external secrets required
- Membership verification happens before any ADO pipeline trigger
