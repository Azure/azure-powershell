if(($null -eq $TestName) -or ($TestName -contains 'Get-AzContainerInstanceContainerGroupProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerInstanceContainerGroupProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}
 
Describe 'Get-AzContainerInstanceContainerGroupProfile' {
   
    It 'List' -skip {
       {
        Get-AzContainerInstanceContainerGroupProfile
       } | Should -Not -Throw
    }
   
    It 'Get' {
        Get-AzContainerInstanceContainerGroupProfile -Name $env.containerGroupProfileName -ResourceGroupName $env.resourceGroupName
    }
 
    It 'List1' {
        Get-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName
    }
 
    It 'GetViaIdentity' {
        $get = Update-AzContainerInstanceContainerGroupProfile -Name $env.containerGroupProfileName -ResourceGroupName $env.resourceGroupName -Tag @{"key"="value"}
        Get-AzContainerInstanceContainerGroupProfile -InputObject $get
    }
}