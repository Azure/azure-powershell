$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConfluentOrganization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzConfluentOrganization' {
    # Skip test case because the cmdlet needs to be interactive to take consent from user 
    It 'Delete' -Skip {
      Remove-AzConfluentOrganization -ResourceGroupName $env.resourceGroup -Name $env.confluentOrgName00
      $confluentOrgList = Get-AzConfluentOrganization 
      $confluentOrgList.Name | Should -Not -Contain $env.confluentOrgName00
    }

    It 'DeleteViaIdentity' -Skip {
      $confluentOrg = Get-AzConfluentOrganization -ResourceGroupName $env.resourceGroup -Name $env.confluentOrgName01 
      Remove-AzConfluentOrganization -InputObject $confluentOrg
      $confluentOrgList = Get-AzConfluentOrganization 
      $confluentOrgList.Name | Should -Not -Contain $env.confluentOrgName01
    }
}
