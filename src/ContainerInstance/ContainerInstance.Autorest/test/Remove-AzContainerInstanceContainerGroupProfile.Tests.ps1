if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzContainerInstanceContainerGroupProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzContainerInstanceContainerGroupProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}
 
Describe 'Remove-AzContainerInstanceContainerGroupProfile' {
    It 'Delete' {
        Remove-AzContainerInstanceContainerGroupProfile -Name "$($env.containerGroupProfileName)-remove1" -ResourceGroupName $env.resourceGroupName
    }
 
    It 'DeleteViaIdentity' {
        $remove = Get-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name "$($env.containerGroupProfileName)-remove2"
        Remove-AzContainerInstanceContainerGroupProfile -InputObject $remove
    }
 
    It 'DeleteSpotPriority' {
        Remove-AzContainerInstanceContainerGroupProfile -Name "$($env.spotContainerGroupProfileName)-remove1" -ResourceGroupName $env.resourceGroupName
    }
 
    It 'DeleteViaIdentitySpotPriority' {
        $remove = Get-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name "$($env.spotContainerGroupProfileName)-remove2"
        Remove-AzContainerInstanceContainerGroupProfile -InputObject $remove
    }
 
    It 'DeleteConfidentialSku' {
        Remove-AzContainerInstanceContainerGroupProfile -Name "$($env.confidentialContainerGroupProfileName)-remove1" -ResourceGroupName $env.resourceGroupName
    }
 
    It 'DeleteViaIdentityConfidentialSku' {
        $remove = Get-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name "$($env.confidentialContainerGroupProfileName)-remove2"
        Remove-AzContainerInstanceContainerGroupProfile -InputObject $remove
    }
}