if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminAttachedNetwork'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminAttachedNetwork.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminAttachedNetwork' {
    It 'Delete' {
        Remove-AzDevCenterAdminAttachedNetwork -ConnectionName $env.attachedNetworkNameDelete -DevCenterName $env.devCenterName -ResourceGroupName $env.resourceGroup
        { Get-AzDevCenterAdminAttachedNetwork -ConnectionName $env.attachedNetworkNameDelete -DevCenterName $env.devCenterName -ResourceGroupName $env.resourceGroup  } | Should -Throw

    }

    It 'DeleteViaIdentity' {
        $id = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $env.resourceGroup + "/providers/Microsoft.DevCenter/devcenters/" + $env.devCenterName + "/attachednetworks/" + $env.attachedNetworkNameDelete2

        $attachedNetworkInput = @{"Id" = $id}

        Remove-AzDevCenterAdminAttachedNetwork -InputObject $attachedNetworkInput
        { Get-AzDevCenterAdminAttachedNetwork -InputObject $attachedNetworkInput  } | Should -Throw

    }
}
