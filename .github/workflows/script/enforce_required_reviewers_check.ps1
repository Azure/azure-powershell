# set the repository to $env:repository, e.g., $env:repository="Azure/azure-powershell"
# set the PR number to $env:prNo, e.g., $env:prNo=22145
# set the GITHUB_TOKEN to $env:GITHUB_TOKEN if necessay, e.g., $env:GITHUB_TOKEN="******"

$prNo = $env:PR_NO
$repository = $env:REPOSITORY
Invoke-WebRequest -Uri "https://raw.githubusercontent.com/$repository/main/.github/enforce_review_paths.txt" -OutFile "./enforce_review_paths.txt"
$enforceReivewPaths = Get-Content ./enforce_review_paths.txt
if ($enforceReivewPaths.Length -eq 0) {
    Write-Host "No enforce review paths are configured. Skip it."
    return
}

$updatedFiles = (gh api -H "Accept: application/vnd.github+json" -H "X-GitHub-Api-Version: 2022-11-28" /repos/$repository/pulls/$prNo/files | ConvertFrom-Json).filename
Write-Host "All updated files in this PR $prNo : "
$updatedFiles

$updatedEnforcePaths = @()
foreach ($enforceReivewPath in $enforceReivewPaths) {
    $updatedEnforcePaths += $updatedFiles | Where-Object {$_.StartsWith($enforceReivewPath)}
}
$updatedEnforcePaths = $updatedEnforcePaths | Sort-Object -Unique
if ($updatedEnforcePaths.Length -eq 0) {
    Write-Host "No enforce review paths are updated in this PR. Skip it."
    return
}
Invoke-WebRequest -Uri "https://raw.githubusercontent.com/$repository/main/.github/CODEOWNERS" -OutFile "./CODEOWNERS"
$codeOwnerLines = Get-Content ./CODEOWNERS | Where-Object { ($_.trim().Length -gt 1) -and ($_.trim() -notlike "#*") }
$actualReviewers = (gh api -H "Accept: application/vnd.github+json" -H "X-GitHub-Api-Version: 2022-11-28" /repos/$repository/pulls/$prNo/reviews | ConvertFrom-Json).user.login
$actualReviewers = $actualReviewers ? $actualReviewers : @() # if no reviewers
Write-Host "All reviewers for this PR $prNo : "
$actualReviewers

foreach ($updatedEnforcePath in $updatedEnforcePaths) {
    foreach ($codeOwnerLine in $codeOwnerLines) {
        $codeOwnerLineArray = ($codeOwnerLine.trim() -split "[ ]+")
        if ($codeOwnerLineArray.Length -le 1) {
            continue
        }
        $codeReivewPath = $codeOwnerLineArray[0]
        if ($codeReivewPath.StartsWith('/')) {
            $codeReivewPath = $codeReivewPath.Substring(1)
        }
        if ($updatedEnforcePath.StartsWith($codeReivewPath)) {
            $codeReivewOwners = $codeOwnerLineArray[1..$codeOwnerLineArray.Length] | ForEach-Object { $_.Substring(1) } # remove '@'
            $reviewerOwners = Compare-Object $codeReivewOwners $actualReviewers -PassThru -IncludeEqual -ExcludeDifferent
            if ($reviewerOwners.Length -eq 0) {
                throw "error: At least one of the required reviewers '$($codeReivewOwners -join "', '")' must approve the PR"
            }
        }
    }
}