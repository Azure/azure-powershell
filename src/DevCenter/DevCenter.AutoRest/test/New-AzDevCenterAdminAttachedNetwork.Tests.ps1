if(($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminAttachedNetwork'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminAttachedNetwork.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminAttachedNetwork' {
    It 'CreateExpanded' {
        $attachedNetwork = New-AzDevCenterAdminAttachedNetwork -ConnectionName $env.attachedNetworkNew -DevCenterName $env.devCenterName -ResourceGroupName $env.resourceGroup -NetworkConnectionId $env.networkConnectionId
        $attachedNetwork.Name | Should -Be $env.attachedNetworkNew
        $attachedNetwork.NetworkConnectionId | Should -Be $env.networkConnectionId
        $attachedNetwork.DomainJoinType | Should -Be "AzureADJoin"
    }

}
