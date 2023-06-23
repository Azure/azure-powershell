if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminDevBoxDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminDevBoxDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminDevBoxDefinition' {
    It 'List' {
        $listOfDevBoxDefinitions = Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName
        
        $listOfDevBoxDefinitions.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $devBoxDefinition = Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.devBoxDefinitionName
        $devBoxDefinition.Name | Should -Be $env.devBoxDefinitionName
        $devBoxDefinition.ImageReferenceId | Should -Be $env.imageReferenceId
        $devBoxDefinition.OSStorageType | Should -Be $env.osStorageType
        $devBoxDefinition.SkuName | Should -Be $env.skuName
        $devBoxDefinition.ImageReferenceExactVersion | Should -Be "1.0.0"
        $devBoxDefinition.HibernateSupport | Should -Be "Enabled"
    }

    It 'Get1' {
        $devBoxDefinition = Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName $env.resourceGroup -ProjectName $env.projectName -Name $env.devBoxDefinitionName
        $devBoxDefinition.Name | Should -Be $env.devBoxDefinitionName
        $devBoxDefinition.ImageReferenceId | Should -Be $env.imageReferenceId
        $devBoxDefinition.OSStorageType | Should -Be $env.osStorageType
        $devBoxDefinition.SkuName | Should -Be $env.skuName
        $devBoxDefinition.ImageReferenceExactVersion | Should -Be "1.0.0"
        $devBoxDefinition.HibernateSupport | Should -Be "Enabled"
    }

    It 'List1' {
        $listOfDevBoxDefinitions = Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName $env.resourceGroup -ProjectName $env.projectName
        
        $listOfDevBoxDefinitions.Count | Should -BeGreaterOrEqual 1 
    }
}
