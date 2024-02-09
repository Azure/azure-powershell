if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSphereProduct'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSphereProduct.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSphereProduct' {
    It 'List' -skip {
        {
            $listProd = Get-AzSphereProduct -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup
            $listProd.Count | Should -Be 2
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $prod1 = Get-AzSphereProduct -CatalogName $env.firstCatalog -Name $env.firstProduct -ResourceGroupName $env.resourceGroup
            $prod1.Name | Should -Be $env.firstCatalog
        } | Should -Not -Throw
    }

    It 'GetViaIdentityCatalog' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        {
            $prodObject = Get-AzSphereProduct -CatalogName $env.firstCatalog -Name $env.firstProduct -ResourceGroupName $env.resourceGroup
            $prod2 = Get-AzSphereProduct -InputObject $prodObject
            $prod2.Name | Should -Be $env.firstCatalog
        } | Should -Not -Throw
    }
}
