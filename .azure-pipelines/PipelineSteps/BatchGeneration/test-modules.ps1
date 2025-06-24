param (
    [string]$MatrixKey,
    [string]$TestEnvName,
    [string]$RepoRoot
)

# Install Az.Accounts module and Pester module
Install-Module -Name Pester -Repository PSGallery -RequiredVersion 4.10.1 -Force -SkipPublisherCheck
Install-Module -Name Az.Accounts -AllowClobber -Force -Repository PSGallery

$utilFilePath = Join-Path $RepoRoot '.azure-pipelines' 'PipelineSteps' 'BatchGeneration' 'util.psm1'
Import-Module $utilFilePath -Force
$subModuleGroup = Get-Targets -RepoRoot $RepoRoot -TargetsOutputFileName "test$($TestEnvName)Targets.json" -MatrixKey $MatrixKey

$results = @()  

foreach ($subModule in $subModuleGroup) {
    $startTime = Get-Date
    $moduleName, $subModuleName = $subModule -split '/'
    $result = @{
        OSName = $TestEnvName
        MatrixKey = $MatrixKey
        Module = $moduleName
        SubModule = $subModuleName
        Status = "Success"
        DurationSeconds = 0
        Error = ""
    }

    try {
        Write-Host "Testing sub module: $subModule"
        $subModulePath = Join-Path $RepoRoot 'artifacts' 'Debug' "Az.$ModuleName" $subModuleName
        Set-Location $subModulePath
        # remove the integrated Az Accounts so that the installed latest one could be used for test
        $integratedAzAccounts = Join-Path $subModulePath 'generated' 'modules' 'Az.Accounts'
        If (Test-Path $integratedAzAccounts){
            Write-Host "Removing integrated Az.Accounts module from $integratedAzAccounts"
            Remove-Item -Path $integratedAzAccounts -Recurse -Force
        }

        & ".\test-module.ps1"  

        if ($LASTEXITCODE -ne 0) {
            Write-Warning "❌ Test failed: $subModule (exit code $LASTEXITCODE)"
            $result.Status = "Failed"
            $result.Error = "Test failed with exit code $LASTEXITCODE"
        }
    }
    catch {
        Write-Warning "Failed to test module: $module"
        Write-Warning "Error message: $($_.Exception.Message)"
        $result.Status = "Failed"
        $result.Error = $_.Exception.Message
    }
    finally {
        $endTime = Get-Date
        $result.DurationSeconds = ($endTime - $startTime).TotalSeconds
        $results += $result
    }
}

$artifactRoot = Join-Path $RepoRoot 'artifacts'
$reportPath = Join-Path $artifactRoot "Test$($TestEnvName)Report-$MatrixKey.json"
$results | ConvertTo-Json -Depth 3 | Out-File -FilePath $reportPath -Encoding utf8
