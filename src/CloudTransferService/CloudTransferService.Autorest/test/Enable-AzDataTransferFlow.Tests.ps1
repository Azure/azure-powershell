if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzDataTransferFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzDataTransferFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzDataTransferFlow' {
    $flowToEnable = "test-flow-to-enable-" + -join ((65..90) + (97..122) | Get-Random -Count 6 | ForEach-Object {[char]$_})

    It 'Enable' {
        {
            # Enable the flow
            $enabledFlow = Enable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $env.FaikhRecvFlow -Confirm:$false

            # Verify the flow is enabled
            $enabledFlow.Status | Should -Be "Enabled"
        } | Should -Not -Throw
    }

    It 'Enable when already enabled' {
        {
            # Attempt to enable the flow again
            $enabledFlow = Enable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $env.FaikhEnabledFlow -Confirm:$false

            # Verify the flow is still enabled
            $enabledFlow.Status | Should -Be "Enabled"
        } | Should -Not -Throw
    }

    It 'EnableViaIdentityConnection' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
