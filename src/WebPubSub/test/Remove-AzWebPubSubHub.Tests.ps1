if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzWebPubSubHub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWebPubSubHub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzWebPubSubHub' {
    It 'Delete' {
        $hubName = "hub-" + "remove-hub-" + "Delete"
        New-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1 -Name $hubName

        Remove-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1 -Name $hubName

        $hubList = Get-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1
        $hubList.Name | Should -Not -Contain $hubName
    }

    It 'DeleteViaIdentity' {
        $hubName = "hub-" + "remove-hub-" + "DeleteViaIdentity"
        $hub = New-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1 -Name $hubName

        Remove-AzWebPubSubHub -InputObject $hub

        $hubList = Get-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1
        $hubList.Name | Should -Not -Contain $hubName
    }
}
