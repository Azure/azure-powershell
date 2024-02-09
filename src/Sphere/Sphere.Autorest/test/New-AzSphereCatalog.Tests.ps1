if(($null -eq $TestName) -or ($TestName -contains 'New-AzSphereCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSphereCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSphereCatalog' {
    It 'CreateExpanded' {
        {
            $catalog = New-AzSphereCatalog -Name $env.anotherCatalog -ResourceGroupName $env.resourceGroup -Location $env.globalLocation
            $catalog.Name | Should -Be $env.anotherCatalog

            $result = Get-AzSphereCatalog -InputObject $catalog
            $result.Name | Should -Be $env.anotherCatalog
        } | Should -Not -Throw
    }
}
