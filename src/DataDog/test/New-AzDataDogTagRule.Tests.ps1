$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataDogTagRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataDogTagRule' {
    It 'CreateExpanded' {
        { 
          $ftobjArray = @()
          $ftobjArray += New-AzDataDogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
          $ftobjArray += New-AzDataDogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
          New-AzDataDogTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name 'default' -LogRuleFilteringTag $ftobjArray
        } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        {
            $ftobjArray = @()
            $ftobjArray += New-AzDataDogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
            $ftobjArray += New-AzDataDogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
            $obj = Get-AzDataDogTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name 'default'
            New-AzDataDogTagRule -InputObject $obj -LogRuleFilteringTag $ftobjArray
        } | Should -Not -Throw
    }
}
