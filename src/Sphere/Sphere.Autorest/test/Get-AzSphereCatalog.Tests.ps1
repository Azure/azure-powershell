if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSphereCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSphereCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSphereCatalog' {
    It 'List' {
        {
            $listSub = Get-AzSphereCatalog
            $listSub.Count | Should -BeGreaterThan 100
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $catalog = Get-AzSphereCatalog -Name $env.firstCatalog -ResourceGroupName $env.resourceGroup
            $catalog.Name | Should -Be $env.firstCatalog
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $listGroup = Get-AzSphereCatalog -ResourceGroupName $env.resourceGroup
            $listGroup.Count | Should -BeGreaterOrEqual 2
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
