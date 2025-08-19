#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Check if a GitHub user is a member of the Azure organization.

.DESCRIPTION
    This script uses the GitHub CLI to check if a specified user is a member of the Azure GitHub organization.
    Returns a structured PowerShell object with membership details.

.PARAMETER Username
    The GitHub username to check.

.PARAMETER Organization
    The GitHub organization to check membership for. Defaults to "Azure".

.PARAMETER Quiet
    Suppress console output and only return the object.

.OUTPUTS
    PSCustomObject with the following properties:
    - Username: The checked username
    - Organization: The organization that was checked
    - IsMember: Boolean indicating if user is a public member
    - Status: Detailed status (PublicMember, NotMember, PrivateMember, UserNotFound, Error)
    - ErrorMessage: Error details if Status is Error
    - CheckedAt: Timestamp of when the check was performed

.EXAMPLE
    $result = .\Check-AzureOrgMembership.ps1 "octocat"
    if ($result.IsMember) { Write-Host "User is a member!" }

.EXAMPLE
    .\Check-AzureOrgMembership.ps1 "octocat" -Quiet | ConvertTo-Json
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true, Position = 0)]
    [ValidateNotNullOrEmpty()]
    [string]$Username,

    [Parameter()]
    [string]$Organization = "Azure",

    [Parameter()]
    [switch]$Quiet
)

function Write-ConditionalOutput {
    param([string]$Message, [string]$ForegroundColor = "White")
    if (-not $Quiet) {
        Write-Host $Message -ForegroundColor $ForegroundColor
    }
}

# Initialize result object
$result = [PSCustomObject]@{
    Username = $Username
    Organization = $Organization
    IsMember = $false
    Status = "Unknown"
    ErrorMessage = $null
    CheckedAt = Get-Date
}

try {
    # Check if GitHub CLI is available
    if (-not (Get-Command gh -ErrorAction SilentlyContinue)) {
        $result.Status = "Error"
        $result.ErrorMessage = "GitHub CLI (gh) is not installed. Install from: https://cli.github.com/"
        Write-ConditionalOutput "❌ GitHub CLI not found" "Red"
        return $result
    }

    # Check if authenticated
    $null = gh auth status 2>&1
    if ($LASTEXITCODE -ne 0) {
        $result.Status = "Error"
        $result.ErrorMessage = "GitHub CLI is not authenticated. Run 'gh auth login' first."
        Write-ConditionalOutput "❌ GitHub CLI not authenticated" "Red"
        return $result
    }

    Write-ConditionalOutput "🔍 Checking if '$Username' is a member of '$Organization' organization..." "Yellow"

    # Check organization membership using GitHub API
    gh api "orgs/$Organization/members/$Username" --silent 2>$null
    $apiExitCode = $LASTEXITCODE

    if ($apiExitCode -eq 0) {
        # User is a public member
        $result.IsMember = $true
        $result.Status = "PublicMember"
        Write-ConditionalOutput "✅ $Username is a PUBLIC member of the $Organization organization!" "Green"
    }
    elseif ($apiExitCode -eq 1) {
        # Exit code 1 typically means 404 - could be not a member or private membership
        # Check if user exists
        gh api "users/$Username" --silent 2>$null
        if ($LASTEXITCODE -eq 0) {
            $result.IsMember = $false
            $result.Status = "NotMemberOrPrivate"
            Write-ConditionalOutput "❌ $Username is either not a member of $Organization organization or has private membership." "Red"
        }
        else {
            $result.Status = "UserNotFound"
            $result.ErrorMessage = "User '$Username' was not found on GitHub."
            Write-ConditionalOutput "❌ User '$Username' was not found on GitHub." "Red"
        }
    }
    else {
        # Unexpected error
        $result.Status = "Error"
        $result.ErrorMessage = "Unexpected error occurred (GitHub API exit code: $apiExitCode)"
        Write-ConditionalOutput "❌ Unexpected error checking membership (exit code: $apiExitCode)" "Red"
    }
}
catch {
    $result.Status = "Error"
    $result.ErrorMessage = "Exception occurred: $($_.Exception.Message)"
    Write-ConditionalOutput "❌ Error: $($_.Exception.Message)" "Red"
}

# Return the result object
return $result