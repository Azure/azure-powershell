param(
    [System.String]
    $LabelName,
    [System.String]
    $PrUrl
)
Write-Host "Processing PR $PrUrl with label $LabelName"

$CommentDict = @{
    "Breaking Change Release" = "Azure PowerShell breaking change policy, please refer to [Breaking Change Definition](https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/breaking-change/breaking-changes-definition)"
    "Breaking Change - attribute" = "Please check, the attribute is missing in the breaking change or the attribute setting is incorrect, please refer to [Breaking Changes Attribute Help](https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/breaking-change/breaking-changes-attribute-help)"
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