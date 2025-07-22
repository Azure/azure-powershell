[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [string]$Owner,
    [string]$Repo,
    [string]$BaseBranch,
    [string]$NewBranch,
    [string]$Token
)

$headers = @{ Authorization = "Bearer $Token"; "User-Agent" = "ADO-Pipeline" }
$branchInfo = Invoke-RestMethod -Uri "https://api.github.com/repos/$Owner/$Repo/git/ref/heads/$BaseBranch" -Headers $headers
$sha = $branchInfo.object.sha

$body = @{
    ref = "refs/heads/$NewBranch"
    sha = $sha
} | ConvertTo-Json

Invoke-RestMethod -Uri "https://api.github.com/repos/$Owner/$Repo/git/refs" `
                -Method Post -Headers $headers -Body $body -ContentType "application/json"

Write-Host "Created branch '$NewBranch' from '$BaseBranch'"
