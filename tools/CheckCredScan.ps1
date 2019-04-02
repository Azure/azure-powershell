param(
    [string]$CIToolsPath,
    [string]$PullRequestNumber
)

. $PSScriptRoot/BuildPackagesTask/Microsoft.Azure.Build.Tasks/GetPullRequestFileChanges.ps1

Write-Output "==== CredScan started"
try {
    if ([System.String]::IsNullOrWhiteSpace($CIToolsPath)) {
        Write-Error "CI Tools Path is not provided."
        return
    }
    if ([System.String]::IsNullOrWhiteSpace($PullRequestNumber)) {
        Write-Error "Pull Request Number is not provided."
        return
    }

    $owner = "Azure"
    $repo = "azure-powershell"
    $credScanInputFile = ".\CredScanInput.tsv"
    if (Test-Path $credScanInputFile) {
        Remove-Item $credScanInputFile -Force
    }
    $curDir = (Get-Location).Path
    $filelist = Get-PullRequestFileChanges -RepositoryOwner $owner -RepositoryName $repo -PullRequestNumber $PullRequestNumber 
    $filelist | ForEach-Object {
        Add-Content -Path $credScanInputFile -Value (Join-Path $curDir $_)
    }
    $fileListSize = $filelist.Count
    $request = "https://api.github.com/repos/$owner/$repo/pulls/$PullRequestNumber"
    $changedFilesNumber = Invoke-WebRequest $request -UseBasicParsing | ConvertFrom-Json | Select-Object -ExpandProperty changed_files
    if ($changedFilesNumber -gt $fileListSize) {
        Write-Warning "Only $fileListSize files will be scanned out of $changedFilesNumber with CredScan."
    }

    & "$CIToolsPath/RunCredentialScanner.ps1" -InputDir $credScanInputFile -Verbose
} catch {
    if ($_.Exception.Message -like "Credential scanner match found exception!*") {
        $resultsDir = "$PSScriptRoot/../artifacts/CredScanResults"
        $matchesPath = "$resultsDir/-matches.csv"
        $newName = "CredScanIssues.csv"
        if (Test-Path $matchesPath) {
            $lines = [string[]](Get-Content -Path $matchesPath)
            if ($lines.Count -gt 1) {
                Write-Output "Renaming $matchesPath to $newName"
                Rename-Item -Path $matchesPath -NewName $newName
            }
        }
        $message = "Credential scanner match found.`nDetails can be found in the $newName file.`nPath to the file: $resultsDir/$newName`nFor false positives, follow the instructions on this doc: https://github.com/Azure/adx-documentation-pr/blob/master/engineering/credscan-ps.md`nFor more information, please read the 'How should I respond to reports of incorrectly handled secrets?' section `nof this doc: https://microsoft.sharepoint.com/teams/AzureSecurityCompliance/Security/SitePages/SecretsManagement.aspx."
        Write-Output "<<<<`n`nERROR`n`n$message`n`n>>>>"
        $LastExitCode = 1
    }
}
Write-Output "==== CredScan finished"