if(($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminDevBoxDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminDevBoxDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminDevBoxDefinition' {
    It 'CreateExpanded'  {

        $devBoxDefinition = New-AzDevCenterAdminDevBoxDefinition -Name $env.devBoxDefinitionNew -DevCenterName $env.devCenterName -ResourceGroupName $env.resourceGroup -Location $env.location -HibernateSupport "Enabled" -ImageReferenceId $env.imageReferenceId -OSStorageType $env.osStorageType -SkuName $env.skuName 
        $devBoxDefinition.Name | Should -Be $env.devBoxDefinitionNew
        $devBoxDefinition.ImageReferenceId | Should -Be $env.imageReferenceId
        $devBoxDefinition.OSStorageType | Should -Be $env.osStorageType
        $devBoxDefinition.SkuName | Should -Be $env.skuName
        $devBoxDefinition.ImageReferenceExactVersion | Should -Be "1.0.0"
        $devBoxDefinition.HibernateSupport | Should -Be "Enabled"
        }

}
