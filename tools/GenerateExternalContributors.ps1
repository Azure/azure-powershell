<#
.Synopsis
Get all extenal contibuting authors.
.Description
Get all extenal contibuting authors.
.Outputs
The name, login, commits message of the authors.
.Link
Invoke-WebRequest: https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.utility/invoke-webrequest?view=powershell-7
Invoke-RestMethod: https://learn.microsoft.com/en-us/powershell/module/Microsoft.PowerShell.Utility/Invoke-RestMethod?view=powershell-7
#>
param(
    [Parameter(Mandatory)]
    [string]
    $AccessToken,
    [Parameter(HelpMessage='Days back default 28')]
    [int]
    $DaysBack = 28
)
$SinceDate = (Get-Date).AddDays((0-$DaysBack))
$SinceDateStr =  $SinceDate.ToString('yyyy-MM-ddTHH:mm:ssZ')
$Branch = git branch --show-current # The Git 2.22 and above support.
$rootPath = "$PSScriptRoot\.."
$changeLogFile = Get-Item -Path "..\ChangeLog.md"
$changeLogContent = Get-Content -Path $changeLogFile.FullName | Out-String

Write-Debug 'Create ExternalContributors.md'
# Create md file to store contributors information.
$contributorsMDFile = Join-Path $PSScriptRoot 'ExternalContributors.md'
if ((Test-Path -Path $contributorsMDFile)) {
    Remove-Item -Path $contributorsMDFile -Force
}
New-Item -ItemType "file" -Path $contributorsMDFile

$commitsUrl = "https://api.github.com/repos/Azure/azure-powershell/commits?since=$SinceDateStr&sha=$Branch"
$token = ConvertTo-SecureString $AccessToken -AsPlainText -Force
# Get last page number of commints.
$commintsPagesLink = (Invoke-WebRequest -Uri $commitsUrl -Authentication Bearer -Token $token).Headers.Link
$commintsLastPageNumber = 1 # Default value
if (![string]::IsNullOrEmpty($commintsPagesLink)) {
    if ($commintsPagesLink.LastIndexOf('&page=') -gt 0) {
        [int]$commintsLastPageNumber = $commintsPagesLink.Substring($commintsPagesLink.LastIndexOf('&page=') + '&page='.Length, 1) 
    }
}

$PRs = @()
for ($pageNumber=1; $pageNumber -le $commintsLastPageNumber; $pageNumber++) {
    $commitsPageUrl = $commitsUrl + "&page=$pageNumber"
    $PRs += Invoke-RestMethod -Uri $commitsPageUrl -Authentication Bearer -Token $token -ResponseHeadersVariable 'ResponseHeaders'
}
Write-Debug "The PR count: $($PRs.Count)"

# Remove already existed commits
$validPRs = @()
foreach ($PR in $PRs)
{
  $index = $PR.commit.message.IndexOf("`n`n")
  if ($index -lt 0) {
      $commitMessage = $PR.commit.message
  } else {
      $commitMessage = $PR.commit.message.Substring(0, $index)
  }

  if (!($changeLogContent.Contains($commitMessage)))
  {
    $validPRs += $PR
  }
}

Write-Debug "The valid PR count: $($validPRs.Count)"

$sortPRs = $validPRs | Sort-Object -Property @{Expression = {$_.author.login}; Descending = $False}

$skipContributors = @('aladdindoc','azure-powershell-bot')

# Get team members of the azure-powershell-team.
$teamMembers = (Invoke-WebRequest -Uri "https://api.github.com/orgs/Azure/teams/azure-powershell-team/members" -Authentication Bearer -Token $token).Content | ConvertFrom-Json

foreach ($members in $teamMembers) {
  $skipContributors += $members.login
}

# Output external contributors information.
Write-Debug 'Output external contributors information.'
'### Thanks to our community contributors' | Out-File -FilePath $contributorsMDFile -Force
Write-Host '### Thanks to our community contributors'

for ($PR = 0; $PR -lt $sortPRs.Length; $PR++) {

    $account = $sortPRs[$PR].author.login
    $name = $sortPRs[$PR].commit.author.name
    $index = $sortPRs[$PR].commit.message.IndexOf("`n`n")

    if ($skipContributors.Contains($account))
    {
        continue
    }

    # Skip if commit author exists in skipContributors list.
    if ([System.String]::IsNullOrEmpty($account) -and $skipContributors.Contains($name))
    {
        continue
    }
    
    # Check whether the contributor belongs to the Azure organization.
    Invoke-RestMethod -Uri "https://api.github.com/orgs/Azure/members/$($sortPRs[$PR].author.login)" -Authentication Bearer -Token $token -ResponseHeadersVariable 'ResponseHeaders' -StatusCodeVariable 'StatusCode' -SkipHttpErrorCheck > $null
    if ($StatusCode -eq '204') {
        # Add internal contributors to skipContributors to reduce the number of https requests sent.
        $skipContributors += $sortPRs[$PR].author.login
        continue
    }

    if ($index -lt 0) {
        $commitMessage = $sortPRs[$PR].commit.message
    } else {
        $commitMessage = $sortPRs[$PR].commit.message.Substring(0, $index)
    }

    # Contributors have many commits.
    if ( ($account -eq $sortPRs[$PR - 1].author.login) -or ($account -eq $sortPRs[$PR + 1].author.login)) {
        # Firt commit.
        if (!($sortPRs[$PR].author.login -eq $sortPRs[$PR - 1].author.login)) {
            if (($account -eq $name)) {
                "* @$account" | Out-File -FilePath $contributorsMDFile -Append -Force
                "  * $commitMessage" | Out-File -FilePath $contributorsMDFile -Append -Force

                Write-Host "* @$account"
                Write-Host "  * $commitMessage"
            } else {
                "* $($name) (@$account)" | Out-File -FilePath $contributorsMDFile -Append -Force
                "  * $commitMessage" | Out-File -FilePath $contributorsMDFile -Append -Force
                
                Write-Host "* $($name) (@$account)"
                Write-Host "  * $commitMessage"
            }
        } else
        {
            "  * $commitMessage" | Out-File -FilePath $contributorsMDFile -Append -Force

            Write-Host "  * $commitMessage"
        }
    } else {
        if (($account -eq $name)) {
            "* @$account, $commitMessage" | Out-File -FilePath $contributorsMDFile -Append -Force

            Write-Host "* @$account, $commitMessage"
        } else {
            "* $name (@$account), $commitMessage" | Out-File -FilePath $contributorsMDFile -Append -Force

            Write-Host "* $name (@$account), $commitMessage"
        }
    }
}


