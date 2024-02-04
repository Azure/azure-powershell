$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzConfluentOrganization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzConfluentOrganization' {
    It 'UpdateExpanded' {
      Update-AzConfluentOrganization -ResourceGroupName $env.resourceGroup -Name $env.confluentOrgName00 -Tag @{"key01" = "value01"; "key02" = "value02"; "key03" = "value03"}
      $confluentOrg =  Get-AzConfluentOrganization -ResourceGroupName $env.resourceGroup -Name $env.confluentOrgName00
      $confluentOrg.Tag.Count | Should -Be 3
    }

    It 'UpdateViaIdentityExpanded' {
      $confluentOrg = Get-AzConfluentOrganization -ResourceGroupName $env.resourceGroup -Name $env.confluentOrgName00 
      $confluentOrg = Update-AzConfluentOrganization -InputObject $confluentOrg -Tag @{"key01" = "value01"; "key02" = "value02"}
      $confluentOrg =  Get-AzConfluentOrganization -ResourceGroupName $env.resourceGroup -Name $env.confluentOrgName00
      $confluentOrg.Tag.Count | Should -Be 2
    }
}
