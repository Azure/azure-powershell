$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataDogSingleSignOnConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataDogSingleSignOnConfiguration' {
    It 'CreateExpanded' {
        { 
            New-AzDataDogSingleSignOnConfiguration -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 -Name 'default' -SingleSignOnState Enable -EnterpriseAppId $env.enterpriseAppId
        } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        { 
            $obj = Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 -Name 'default' 
            New-AzDataDogSingleSignOnConfiguration -InputObject $obj -SingleSignOnState Disable -EnterpriseAppId $env.enterpriseAppId
        } | Should -Not -Throw
    }
}
