if(($null -eq $TestName) -or ($TestName -contains 'Update-AzArcSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzArcSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzArcSetting' {
    It 'PatchExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PatchViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PatchViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Patch' {
        # SettingsResourceName is optional and set to 'default'
        $settings = Update-AzArcSetting -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.subscriptionId -BaseProvider $env.BaseProvider -BaseResourceName $env.MachineName -BaseResourceType $env.BaseProviderType -GatewayResourceId $env.GatewayResourceId 
        $settings | Should -Not -Be $null
    }

    It 'PatchViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PatchViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
