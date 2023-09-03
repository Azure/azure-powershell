if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminEnvironmentType'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminEnvironmentType.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminEnvironmentType' {
    It 'Delete' {
        Remove-AzDevCenterAdminEnvironmentType -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.environmentTypeNameDelete 
        { Get-AzDevCenterAdminEnvironmentType -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.environmentTypeNameDelete } | Should -Throw
  
     }

    It 'DeleteViaIdentity' {
        $env = Get-AzDevCenterAdminEnvironmentType -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.environmentTypeNameDelete2
        Remove-AzDevCenterAdminEnvironmentType -InputObject $env
        { Get-AzDevCenterAdminEnvironmentType -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.environmentTypeNameDelete2 } | Should -Throw

       }
}
