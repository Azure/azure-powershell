param(
    [System.String]
    $LabelName,
    [System.String]
    $PrUrl
)
Write-Host "Processing PR $PrUrl with label $LabelName"

$CommentDict = @{
    "DO NOT SQUASH :no_entry_sign:" = @"
‼️ Please merge this PR with commits! You can enable this option in the setting page.
‼️ Remember close that option after merging this PR!
"@
    "Do Not Merge :no_entry_sign:" = @"
‼️ DO NOT MERGE THIS PR ‼️
"@
    "Breaking Change Release" = @"
To PR author,
This PR was labeled "Breaking Change Release" because it contains breaking changes.
According to our [policy](https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/breaking-change/breaking-changes-policy), breaking changes can only take place during major release and must be preannounced.
Please follow our [guide](https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/breaking-change/breaking-changes-process) on the detailed steps.
"@
    "needs-revision" = @"
This PR was labeled "needs-revision" because it has unresolved review comments or CI failures.
Please resolve all open review comments and make sure all CI checks are green. Refer to our guide (link TBD) to troubleshoot common CI failures.
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
        gh pr comment $PrUrl --body $comment
    }
}