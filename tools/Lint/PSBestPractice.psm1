#Requires -Modules Az.Accounts, PSScriptAnalyzer

<#
.SYNOPSIS
    A PowerShell module for analyzing and repairing PowerShell scripts according to best practices.

.DESCRIPTION
    This module provides functions to analyze PowerShell scripts against defined best practices using Azure OpenAI.
    It can analyze scripts, suggest improvements, and optionally apply the suggested changes.
    
    The module uses Azure OpenAI service to analyze scripts and provide intelligent suggestions for improvements
    based on PowerShell best practices defined in a markdown file.

.EXAMPLE
    # Example 1: Import the module and analyze a single script
    Import-Module .\PSBestPractice.psm1
    Repair-PSBestPractice -Path ".\MyScript.ps1" -ApplyChanges
    
.EXAMPLE
    # Example 2: Analyze all scripts in a directory
    Import-Module .\PSBestPractice.psm1
    Repair-PSBestPractice -Path "C:\Scripts" -Recurse -ApplyChanges

.NOTES
    Requirements:
    - Az.Accounts module
    - PSScriptAnalyzer module
    - Access to Azure OpenAI service
#>


function Get-BestPractices {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]$Path
    )
    
    if (Test-Path -Path $Path) {
        return Get-Content -Path $Path -Raw
    }
    else {
        Write-Error "Best practices file not found at: $Path"
        exit 1
    }
}

function Get-AzureOpenAIToken {
    [CmdletBinding()]
    param()
    
    try {
        $token = Get-AzAccessToken -ResourceUrl "https://cognitiveservices.azure.com/" -WarningAction SilentlyContinue
        return $token.Token
    }
    catch {
        Write-Error "Failed to get Azure OpenAI token: $_"
        exit 1
    }
}

function Invoke-AzureOpenAI {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]$Endpoint,
        
        [Parameter(Mandatory = $true)]
        [string]$DeploymentName,
        
        [Parameter(Mandatory = $true)]
        [string]$Token,
        
        [Parameter(Mandatory = $true)]
        [string]$Prompt
    )
    
    $headers = @{
        "Authorization" = "Bearer $Token"
        "Content-Type" = "application/json"
    }
    
    $body = @{
        messages = @(
            @{
                role = "system"
                content = "You are a PowerShell best practices assistant. Analyze PowerShell scripts and suggest improvements to meet best practices."
            },
            @{
                role = "user"
                content = $Prompt
            }
        )
    } | ConvertTo-Json
    
    $url = "$Endpoint/openai/deployments/$DeploymentName/chat/completions?api-version=2024-12-01-preview"
    
    try {
        $response = Invoke-RestMethod -Uri $url -Method Post -Headers $headers -Body $body
        return $response.choices[0].message.content
    }
    catch {
        Write-Error "Error calling Azure OpenAI API: $_"
        return $null
    }
}

function Test-PowerShellFile {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]$FilePath,
        
        [Parameter(Mandatory = $true)]
        [string]$BestPractices,
        
        [Parameter(Mandatory = $true)]
        [string]$Endpoint,
        
        [Parameter(Mandatory = $true)]
        [string]$DeploymentName,
        
        [Parameter(Mandatory = $true)]
        [string]$Token
    )
    
    Write-Verbose "Analyzing file: $FilePath"
    
    $fileContent = Get-Content -Path $FilePath -Raw
    
    $prompt = @"
I have a PowerShell script that I need to check against best practices.

Best Practices:
$BestPractices

PowerShell Script ($FilePath):
$fileContent

Please analyze this script and provide your response in a JSON format with the following structure:
{
    "hasIssues": true/false,
    "issues": [
        {
            "description": "Issue description",
            "suggestion": "Suggested fix"
        }
    ],
    "improvedScript": "The complete improved script content without markdown code blocks"
}

Do not include any markdown formatting like triple backticks in the improvedScript value. The JSON should be valid and parseable.
"@
    
    $analysis = Invoke-AzureOpenAI -Endpoint $Endpoint -DeploymentName $DeploymentName -Token $Token -Prompt $prompt
    
    if ($analysis) {
        return @{
            FilePath = $FilePath
            Analysis = $analysis
        }
    }
    
    return $null
}

function Get-FileHeaderComments {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]$FilePath
    )
    
    $content = Get-Content -Path $FilePath -Raw
    $lines = $content -split "`n"
    $headerComments = @()
    $inCommentBlock = $false
    $foundFirstNonComment = $false
    
    foreach ($line in $lines) {
        $trimmedLine = $line.TrimStart()
        
        # Skip empty lines at the start
        if ($headerComments.Count -eq 0 -and [string]::IsNullOrWhiteSpace($line)) {
            continue
        }
        
        # Handle different types of comments
        if ($trimmedLine.StartsWith("<#")) {
            $inCommentBlock = $true
            $headerComments += $line
        }
        elseif ($trimmedLine.StartsWith("#>")) {
            $inCommentBlock = $false
            $headerComments += $line
        }
        elseif ($trimmedLine.StartsWith("#")) {
            $headerComments += $line
        }
        elseif ($inCommentBlock) {
            $headerComments += $line
        }
        else {
            # If we find a non-comment line
            if ($headerComments.Count -gt 0) {
                if ([string]::IsNullOrWhiteSpace($line)) {
                    # Include one blank line after comments if present
                    $headerComments += $line
                } else {
                    break
                }
            } else {
                break
            }
        }
    }
    
    # Trim any trailing empty lines
    while ($headerComments.Count -gt 0 -and [string]::IsNullOrWhiteSpace($headerComments[-1])) {
        $headerComments = $headerComments[0..($headerComments.Count - 2)]
    }
    
    return $headerComments -join "`n"
}

function Format-PowerShellScript {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]$ScriptContent
    )
    
    $NormalizedText = $ScriptContent -replace "`r`n|`r|`n", "`n"
    
    try {
        # Format the script using Invoke-Formatter
        $formattedContent = Invoke-Formatter -ScriptDefinition $NormalizedText
        
        if ($formattedContent) {
            return $formattedContent
        }
        
        # If formatting failed, return original content
        return $NormalizedText
    }
    catch {
        Write-Warning "Failed to format script: $_"
        return $NormalizedText
    }
}

function Update-PowerShellFile {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]$FilePath,
        
        [Parameter(Mandatory = $true)]
        [string]$Analysis
    )
    
    try {
        # Extract header comments
        $headerComments = Get-FileHeaderComments -FilePath $FilePath
        
        # Try to parse the JSON response
        $jsonResponse = $Analysis | ConvertFrom-Json -ErrorAction Stop
        
        # Check if there are issues to fix and an improved script is available
        if ($jsonResponse.hasIssues -eq $true -and $jsonResponse.improvedScript) {
            # Remove any existing header comments from the improved script
            $improvedScript = $jsonResponse.improvedScript -replace '(?ms)^(\s*#[^\n]*\n)*\s*', ''
            
            # Combine header comments with improved script, ensuring no duplication
            $finalContent = if ($headerComments) {
                "$headerComments`n`n$improvedScript"
            } else {
                $improvedScript
            }

            # Format the final content
            $formattedContent = Format-PowerShellScript -ScriptContent $finalContent

            # Write the improved and formatted script to the file
            Set-Content -Path $FilePath -Value $formattedContent
            
            # Return information about the issues that were fixed
            return @{
                Success = $true
                Issues = $jsonResponse.issues
            }
        }
        elseif ($jsonResponse.hasIssues -eq $false) {
            Write-Host "No issues found in file: $FilePath" -ForegroundColor Green
            return @{
                Success = $true
                Issues = @()
            }
        }
        else {
            Write-Warning "No improved script found in the analysis for file: $FilePath"
            return @{
                Success = $false
                Error = "No improved script provided in the analysis"
            }
        }
    }
    catch {
        Write-Warning "Failed to parse analysis as JSON for file: $FilePath. Error: $_"
        
        # Fallback to regex parsing if JSON parsing fails
        if ($Analysis -match '(?s)Improved Script[:\r\n]+(```powershell\s*\r?\n(.*?)\r?\n```|```\s*\r?\n(.*?)\r?\n```)') {
            $improvedScript = if ($matches[2]) { $matches[2] } else { $matches[3] }
            
            # Remove any existing header comments from the improved script
            $improvedScript = $improvedScript -replace '(?ms)^(\s*#[^\n]*\n)*\s*', ''
            
            # Combine header comments with improved script
            $finalContent = if ($headerComments) {
                "$headerComments`n`n$improvedScript"
            } else {
                $improvedScript
            }
            
            # Format the final content
            $formattedContent = Format-PowerShellScript -ScriptContent $finalContent
            
            # Write the improved and formatted script to the file
            Set-Content -Path $FilePath -Value $formattedContent
            return @{
                Success = $true
                Issues = @("Used regex fallback to extract improved script")
            }
        }
        
        return @{
            Success = $false
            Error = "Failed to parse analysis and extract improved script: $_"
        }
    }
}

# Main exported functions
function Repair-PowerShellFile {
    <#
    .SYNOPSIS
        Analyzes and repairs a single PowerShell script according to best practices.
    
    .DESCRIPTION
        Analyzes a PowerShell script file against best practices using Azure OpenAI,
        suggests improvements, and optionally applies the changes.
    
    .PARAMETER FilePath
        The path to the PowerShell script file to analyze and repair.
    
    .PARAMETER BestPracticePath
        Path to the markdown file containing best practices rules.
        Defaults to 'best-practice.md' in the module directory.
    
    .PARAMETER AzureOpenAIEndpoint
        The Azure OpenAI service endpoint URL.
        Defaults to the AZURE_OPENAI_ENDPOINT environment variable.
    
    .PARAMETER DeploymentName
        The deployment name for the Azure OpenAI model.
        Defaults to 'o3-mini'.
    
    .PARAMETER ApplyChanges
        If specified, applies the suggested changes to the script.
        Otherwise, only shows suggestions.
    
    .EXAMPLE
        # Analyze and show suggestions for a script
        Repair-PowerShellFile -FilePath ".\MyScript.ps1" -ApplyChanges:$false
    
    .EXAMPLE
        # Analyze and automatically apply fixes to a script
        Repair-PowerShellFile -FilePath ".\MyScript.ps1" -ApplyChanges
    #>
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$FilePath,
        
        [Parameter()]
        [string]$BestPracticePath = (Join-Path -Path $PSScriptRoot -ChildPath "best-practice.md"),
        
        [Parameter()]
        [string]$AzureOpenAIEndpoint = $env:AZURE_OPENAI_ENDPOINT,
        
        [Parameter()]
        [string]$DeploymentName = "o3-mini",
        
        [Parameter()]
        [switch]$ApplyChanges
    )
    
    try {
        # Validate file exists
        if (-not (Test-Path -Path $FilePath)) {
            Write-Error "File not found: $FilePath"
            return
        }
        
        # Get best practices content
        $practices = Get-BestPractices -Path $BestPracticePath
        
        # Get Azure OpenAI token
        $token = Get-AzureOpenAIToken
        
        # Analyze the file
        Write-Host "Analyzing: $FilePath" -ForegroundColor Yellow
        $result = Test-PowerShellFile -FilePath $FilePath -BestPractices $practices -Endpoint $AzureOpenAIEndpoint -DeploymentName $DeploymentName -Token $token
        
        if ($result) {
            # Display analysis
            Write-Host "`nAnalysis Results:" -ForegroundColor Cyan
            $analysisObj = $result.Analysis | ConvertFrom-Json
            
            if ($analysisObj.hasIssues) {
                foreach ($issue in $analysisObj.issues) {
                    Write-Host "`nIssue:" -ForegroundColor Yellow
                    Write-Host $issue.description
                    Write-Host "Suggestion:" -ForegroundColor Cyan
                    Write-Host $issue.suggestion
                }
                
                if ($ApplyChanges) {
                    Write-Host "`nApplying fixes..." -ForegroundColor Yellow
                    $updateResult = Update-PowerShellFile -FilePath $FilePath -Analysis $result.Analysis
                    
                    if ($updateResult.Success) {
                        Write-Host "Successfully updated file: $FilePath" -ForegroundColor Green
                    } else {
                        Write-Warning "Failed to update file: $FilePath - $($updateResult.Error)"
                    }
                }
            } else {
                Write-Host "No issues found in file: $FilePath" -ForegroundColor Green
            }
        } else {
            Write-Warning "Analysis failed for file: $FilePath"
        }
    }
    catch {
        Write-Error "An error occurred while processing $FilePath : $_"
    }
}

function Repair-PowerShellDirectory {
    <#
    .SYNOPSIS
        Analyzes and repairs all PowerShell scripts in a directory according to best practices.
    
    .DESCRIPTION
        Recursively finds all PowerShell scripts (*.ps1, *.psm1) in the specified directory,
        analyzes them against best practices using Azure OpenAI, and optionally applies the suggested changes.
    
    .PARAMETER Directory
        The directory containing PowerShell scripts to analyze and repair.
    
    .PARAMETER BestPracticePath
        Path to the markdown file containing best practices rules.
        Defaults to 'best-practice.md' in the module directory.
    
    .PARAMETER AzureOpenAIEndpoint
        The Azure OpenAI service endpoint URL.
        Defaults to the AZURE_OPENAI_ENDPOINT environment variable.
    
    .PARAMETER DeploymentName
        The deployment name for the Azure OpenAI model.
        Defaults to 'o3-mini'.
    
    .PARAMETER ApplyChanges
        If specified, applies the suggested changes to the scripts.
        Otherwise, only shows suggestions.
    
    .PARAMETER Recurse
        If specified, searches for PowerShell scripts in subdirectories.
    
    .EXAMPLE
        # Analyze all scripts in current directory
        Repair-PowerShellDirectory -Directory "." -ApplyChanges:$false
    
    .EXAMPLE
        # Analyze and fix all scripts in a directory and its subdirectories
        Repair-PowerShellDirectory -Directory "C:\Scripts" -Recurse -ApplyChanges
    #>
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$Directory,
        
        [Parameter()]
        [string]$BestPracticePath = (Join-Path -Path $PSScriptRoot -ChildPath "best-practice.md"),
        
        [Parameter()]
        [string]$AzureOpenAIEndpoint = $env:AZURE_OPENAI_ENDPOINT,
        
        [Parameter()]
        [string]$DeploymentName = "o3-mini",
        
        [Parameter()]
        [switch]$ApplyChanges,
        
        [Parameter()]
        [switch]$Recurse
    )
    
    try {
        # Validate directory exists
        if (-not (Test-Path -Path $Directory -PathType Container)) {
            Write-Error "Directory not found: $Directory"
            return
        }
        
        # Get all PowerShell files
        $searchOption = @{
            Path = $Directory
            Include = @("*.ps1", "*.psm1")
            File = $true
        }
        if ($Recurse) {
            $searchOption.Add("Recurse", $true)
        }
        
        $files = Get-ChildItem @searchOption
        
        Write-Host "Found $($files.Count) PowerShell files to analyze." -ForegroundColor Cyan
        
        # Process each file
        foreach ($file in $files) {
            Write-Host "`n-------------------------------------------------" -ForegroundColor DarkGray
            Repair-PowerShellFile -FilePath $file.FullName `
                                -BestPracticePath $BestPracticePath `
                                -AzureOpenAIEndpoint $AzureOpenAIEndpoint `
                                -DeploymentName $DeploymentName `
                                -ApplyChanges:$ApplyChanges
        }
        
        Write-Host "`nPowerShell best practices check completed." -ForegroundColor Green
    }
    catch {
        Write-Error "An error occurred while processing directory $Directory : $_"
    }
}

function Repair-PSBestPractice {
    <#
    .SYNOPSIS
        Analyzes and repairs PowerShell scripts according to best practices.
    
    .DESCRIPTION
        Analyzes PowerShell scripts against best practices using Azure OpenAI,
        suggests improvements, and optionally applies the changes.
        Can process either a single file or all PowerShell scripts in a directory.
    
    .PARAMETER Path
        The path to either a PowerShell script file or a directory containing PowerShell scripts.
    
    .PARAMETER BestPracticePath
        Path to the markdown file containing best practices rules.
        Defaults to 'best-practice.md' in the module directory.
    
    .PARAMETER AzureOpenAIEndpoint
        The Azure OpenAI service endpoint URL.
        Defaults to the AZURE_OPENAI_ENDPOINT environment variable.
    
    .PARAMETER DeploymentName
        The deployment name for the Azure OpenAI model.
        Defaults to 'o3-mini'.
    
    .PARAMETER ApplyChanges
        If specified, applies the suggested changes to the scripts.
        Otherwise, only shows suggestions.
    
    .PARAMETER Recurse
        If specified and Path is a directory, searches for PowerShell scripts in subdirectories.
    
    .EXAMPLE
        # Analyze a single script
        Repair-PSBestPractice -Path ".\MyScript.ps1" -ApplyChanges:$false
    
    .EXAMPLE
        # Analyze and fix all scripts in a directory and its subdirectories
        Repair-PSBestPractice -Path "C:\Scripts" -Recurse -ApplyChanges
    #>
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$Path,
        
        [Parameter()]
        [string]$BestPracticePath = (Join-Path -Path $PSScriptRoot -ChildPath "best-practice.md"),
        
        [Parameter()]
        [string]$AzureOpenAIEndpoint = $env:AZURE_OPENAI_ENDPOINT,
        
        [Parameter()]
        [string]$DeploymentName = "o3-mini",
        
        [Parameter()]
        [switch]$ApplyChanges,
        
        [Parameter()]
        [switch]$Recurse
    )
    
    try {
        # Check if path exists
        if (-not (Test-Path -Path $Path)) {
            Write-Error "Path not found: $Path"
            return
        }
        
        # Determine if path is a file or directory
        $isDirectory = Test-Path -Path $Path -PathType Container
        
        if ($isDirectory) {
            # Process directory
            Write-Host "Processing directory: $Path" -ForegroundColor Cyan
            
            # Get all PowerShell files
            $searchOption = @{
                Path = $Path
                Include = @("*.ps1", "*.psm1")
                File = $true
            }
            if ($Recurse) {
                $searchOption.Add("Recurse", $true)
            }
            
            $files = Get-ChildItem @searchOption
            
            Write-Host "Found $($files.Count) PowerShell files to analyze." -ForegroundColor Cyan
            
            # Process each file
            foreach ($file in $files) {
                Write-Host "`n-------------------------------------------------" -ForegroundColor DarkGray
                $params = @{
                    FilePath = $file.FullName
                    BestPracticePath = $BestPracticePath
                    AzureOpenAIEndpoint = $AzureOpenAIEndpoint
                    DeploymentName = $DeploymentName
                    ApplyChanges = $ApplyChanges
                }
                
                Repair-PowerShellFile @params
            }
            
            Write-Host "`nPowerShell best practices check completed." -ForegroundColor Green
        }
        else {
            # Process single file
            $params = @{
                FilePath = $Path
                BestPracticePath = $BestPracticePath
                AzureOpenAIEndpoint = $AzureOpenAIEndpoint
                DeploymentName = $DeploymentName
                ApplyChanges = $ApplyChanges
            }
            
            Repair-PowerShellFile @params
        }
    }
    catch {
        Write-Error "An error occurred while processing $Path : $_"
    }
}

# Export only the Repair-PSBestPractice function
Export-ModuleMember -Function 'Repair-PSBestPractice'
