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

function Merge-DevPullRequest {
    <#
    .SYNOPSIS
    Merges pull requests in the azure-powershell repository.

    .DESCRIPTION
    Helps merge pull requests in the azure-powershell repo. When using -AllArchivePR, for safety,
    it only supports merging PRs with the "[skip ci]" prefix in the title and created by the
    "azure-powershell-bot" user, which are the archive PRs for generated modules.
    When using -Number, any PR can be merged.

    .PARAMETER Number
    The pull request number(s) to merge. Can be a single number or an array of numbers.

    .PARAMETER AllArchivePR
    Lists all matching PRs (ordered by CreatedAt ascending) and prompts for confirmation before merging.

    .PARAMETER Approve
    Approve the pull request before merging.

    .PARAMETER Force
    Skip confirmation prompts.

    .EXAMPLE
    Merge-DevPullRequest -Approve -Number 28690

    .EXAMPLE
    Merge-DevPullRequest -Approve -Number 28690, 28691, 28692

    .EXAMPLE
    Merge-DevPullRequest -Approve -AllArchivePR -Force

    .NOTES
    Requires GitHub CLI to be installed and authenticated (gh auth login).
    #>
    [CmdletBinding(DefaultParameterSetName = 'Single')]
    [Alias('Merge-DevPR')]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Single')]
        [int[]]$Number,

        [Parameter(Mandatory = $true, ParameterSetName = 'All')]
        [switch]$AllArchivePR,

        [switch]$Approve,

        [switch]$Force
    )

    # Check if GitHub CLI is available
    try {
        gh --version | Out-Null
    }
    catch {
        throw "GitHub CLI is not installed or not in PATH. Please install GitHub CLI and authenticate with 'gh auth login'."
    }

    # Check if authenticated
    try {
        gh auth status | Out-Null
    }
    catch {
        throw "GitHub CLI is not authenticated. Please run 'gh auth login' first."
    }

    $mergedPRs = @()
    $failedPRs = @()

    if ($PSCmdlet.ParameterSetName -eq 'Single') {
        # Get PR details for each number
        $prsToMerge = @()
        foreach ($prNumber in $Number) {
            try {
                $prJson = gh pr view $prNumber --json number,title,author,createdAt,url 2>$null
                if ($LASTEXITCODE -ne 0) {
                    throw "Pull request #$prNumber not found."
                }
                $pr = $prJson | ConvertFrom-Json
                $prsToMerge += $pr
            }
            catch {
                throw "Failed to get pull request #$($prNumber): $_"
            }
        }
    }
    else {
        # Get all archive PRs
        try {
            $allPRsJson = gh pr list --state open --author azure-powershell-bot --json number,title,author,createdAt,url 2>$null
            if ($LASTEXITCODE -ne 0) {
                throw "Failed to list pull requests."
            }
            $allPRs = $allPRsJson | ConvertFrom-Json
        }
        catch {
            throw "Failed to list pull requests: $_"
        }

        # Filter for archive PRs (with [skip ci] prefix)
        $archivePRs = $allPRs | Where-Object { $_.title.StartsWith('[skip ci]') } | Sort-Object createdAt

        if ($archivePRs.Count -eq 0) {
            Write-Host "No archive PRs found matching criteria."
            return @()
        }

        $prsToMerge = $archivePRs
    }

    # Display PRs to be merged
    if ($prsToMerge.Count -gt 0) {
        if (-not $Force) {
            $confirmMessage = "Do you want to"
            if ($Approve) { $confirmMessage += " approve and" }
            $confirmMessage += " merge the following pull request$(if($prsToMerge.Count -gt 1){'s'})?"
            Write-Host $confirmMessage
        }

        # Format and display PRs
        $prTable = $prsToMerge | ForEach-Object {
            [PSCustomObject]@{
                'No.' = $_.number
                'Title' = $_.title
                'CreatedBy' = $_.author.login
                'CreatedAt' = [DateTime]::Parse($_.createdAt).ToString('M/d/yyyy h:mm:ss tt')
                'Url' = $_.url
            }
        }

        $prTable | Format-Table -AutoSize | Out-String | Write-Host

        # Confirmation prompt (for both parameter sets unless Force is used)
        if (-not $Force) {
            do {
                $response = Read-Host "Type Y to$(if($Approve){' approve and'}) merge, N to cancel"
            } while ($response -notin @('Y', 'y', 'N', 'n'))

            if ($response -in @('N', 'n')) {
                Write-Host "Operation cancelled."
                return @()
            }
        }
    }

    # Merge PRs
    foreach ($pr in $prsToMerge) {
        try {
            Write-Host "Processing PR #$($pr.number)..." -ForegroundColor Yellow

            # Approve if requested
            if ($Approve) {
                Write-Host "  Approving PR #$($pr.number)..." -ForegroundColor Cyan
                gh pr review $pr.number --approve 2>$null
                if ($LASTEXITCODE -ne 0) {
                    throw "Failed to approve PR #$($pr.number)"
                }
            }

            # Merge PR
            Write-Host "  Merging PR #$($pr.number)..." -ForegroundColor Cyan
            gh pr merge $pr.number --squash 2>$null
            if ($LASTEXITCODE -ne 0) {
                throw "Failed to merge PR #$($pr.number)"
            }

            Write-Host "  Successfully merged PR #$($pr.number)" -ForegroundColor Green
            $mergedPRs += $pr
        }
        catch {
            Write-Error "Failed to merge PR #$($pr.number): $_"
            $failedPRs += $pr
        }
    }

    # Report results
    if ($mergedPRs.Count -gt 0) {
        Write-Host "`nSuccessfully merged $($mergedPRs.Count) pull request(s)." -ForegroundColor Green
    }

    if ($failedPRs.Count -gt 0) {
        $errorMessage = "Failed to merge $($failedPRs.Count) pull request(s): $($failedPRs.number -join ', ')"
        Write-Error $errorMessage
        throw $errorMessage
    }

    # Return merged PRs in the format shown in README
    return $mergedPRs | ForEach-Object {
        [PSCustomObject]@{
            'No.' = $_.number
            'Title' = $_.title
            'CreatedBy' = $_.author.login
            'CreatedAt' = ([DateTime]::Parse($_.createdAt).ToString('M/d/yyyy h:mm:ss tt'))
            'Url' = $_.url
        }
    }
}

Export-ModuleMember -Function Merge-DevPullRequest -Alias Merge-DevPR
