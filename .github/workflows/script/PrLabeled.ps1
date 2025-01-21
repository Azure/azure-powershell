param(
    [System.String]
    $LabelName,
    [System.String]
    $PrUrl
)
Write-Host "Processing PR $PrUrl with label $LabelName"

$CommentDict = @{
    "DO NOT SQUASH :no_entry_sign:" = @"
‼️ Do NOT use squash to merge this pull request. All the commits must be merged to the target branch.
‼️ Enable "Allow merge commits" in the pull request settings. Select "Merge Commits" to merge the PR. Then go back to settings and disable the option.
"@
    "Do Not Merge :no_entry_sign:" = @"
‼️ DO NOT MERGE THIS PR ‼️
This PR was labeled "Do Not Merge" because it contains code change that cannot be merged. Please contact the reviewer for more information.
"@
    "Breaking Change Release" = @"
To the author of the pull request,
This PR was labeled "Breaking Change Release" because it contains breaking changes.
- According to our [policy](https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/breaking-change/breaking-changes-policy), breaking changes can only take place during major release and they must be preannounced.
- Please follow our [guide](https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/breaking-change/breaking-changes-process) on the detailed steps.
- [ ] **Required**: Please fill in the [task](https://msazure.visualstudio.com/One/_workitems/create/Task?templateId=030c9f4f-a13e-4393-9b87-ae6fd458692b&ownerId=5439f061-9499-4da9-8c5a-659bd6db3188) below to facilitate our contact,you will receive notifications related to breaking changes.
"@
    "needs-revision" = @"
This PR was labeled "needs-revision" because it has unresolved review comments or CI failures.
Please resolve all open review comments and make sure all CI checks are green. Refer to our [guide](https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/ci_tsg) to troubleshoot common CI failures.
"@
    "codegen-survey" = @"
Thanks for using autorest.powershell to develop your PowerShell module! Would you like to take [a 5-minute survey](https://forms.office.com/r/j6rQuFUqUf?origin=lprLink) to help us improve the tool? Much appreciated :)
"@
}


function Test-LabelCommentIsAlreadyAdded {
    param(
        [System.String]
        $Comment,
        [System.String]
        $PrUrl
    )
    $existingComments = (gh pr view $PrUrl --json comments | ConvertFrom-Json).comments | Where-Object { $_.body -eq $comment }
    if ($existingComments.Count -gt 0) {
        return $true
    }
    return $false
}

function Get-Comment {
    param(
        [System.String]
        $LabelName
    )
    if ($CommentDict.ContainsKey($LabelName)) {
        return $CommentDict[$LabelName]
    }
    return $null
}

if ($CommentDict.ContainsKey($LabelName)) {
    $comment = Get-Comment -LabelName $LabelName
    Write-Host "Try to add comment: $comment"
    $isCommentAlreadyAdded = Test-LabelCommentIsAlreadyAdded -Comment $comment -PrUrl $PrUrl
    if ($isCommentAlreadyAdded) {
        Write-Host "Comment is already added"
    }
    else {
        try {
            Out-File -FilePath comment.txt -InputObject $comment
            gh pr comment "${PrUrl}" --body-file comment.txt
        }
        catch {
            Write-Host "Failed to add comment: $_"
        }
    }
}
