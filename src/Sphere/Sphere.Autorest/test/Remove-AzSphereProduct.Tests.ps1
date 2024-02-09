if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSphereProduct'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSphereProduct.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSphereProduct' {
    It 'Delete' {
        {
            Remove-AzSphereProduct -CatalogName $env.firstCatalog -Name $env.anotherProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityCatalog' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            Get-AzSphereProduct -CatalogName $env.firstCatalog -Name $env.secondProduct -ResourceGroupName $env.resourceGroup | Remove-AzSphereProduct
        } | Should -Not -Throw
    }
}
