if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterDevCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterDevCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterDevCatalog' {
    It 'List' {
        $listOfCatalogs = Get-AzDevCenterDevCatalog -Endpoint $env.endpoint -ProjectName $env.projectName
        $listOfCatalogs.Count | Should -Be 1

        $listOfCatalogs = Get-AzDevCenterDevCatalog -DevCenter $env.devCenterName -ProjectName $env.projectName
        $listOfCatalogs.Count | Should -Be 1

    }

    It 'Get' {
        $catalog = Get-AzDevCenterDevCatalog -Endpoint $env.endpoint -ProjectName $env.projectName -CatalogName $env.catalogName 
        $catalog.Name | Should -Be $env.catalogName


        $catalog = Get-AzDevCenterDevCatalog -DevCenter $env.devCenterName ProjectName $env.projectName -CatalogName $env.catalogName 
        $catalog.Name | Should -Be $env.catalogName
    }

    It 'GetViaIdentity' {
        $catalogInput = @{"CatalogName" = $env.catalogName; "ProjectName" = $env.projectName}
        $catalog = Get-AzDevCenterDevCatalog -Endpoint $env.endpoint -InputObject $catalogInput 
        $catalog.Name | Should -Be $env.catalogName

        $catalog = Get-AzDevCenterDevCatalog -DevCenter $env.devCenterName -InputObject $catalogInput 
        $catalog.Name | Should -Be $env.catalogName

    }
}
