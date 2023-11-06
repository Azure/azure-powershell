if(($null -eq $TestName) -or ($TestName -contains 'Connect-AzDevCenterAdminCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Connect-AzDevCenterAdminCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Connect-AzDevCenterAdminCatalog' {
    It 'Connect' -skip {
        Connect-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogName -ResourceGroupName $env.resourceGroup
    }

    It 'ConnectViaIdentity' -skip {
        $catalog = Get-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogName -ResourceGroupName $env.resourceGroup
        Connect-AzDevCenterAdminCatalog -InputObject $catalog
        }
}
