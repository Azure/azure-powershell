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
    It 'Enable' {
        {
            # Enable the flow
            Enable-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowToEnable -Confirm:$false | Should -BeNullOrEmpty

            # Verify the flow is enabled
            $enabledFlow = Get-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowToEnable
            $enabledFlow.Status | Should -Be "Enabled"
        } | Should -Not -Throw
    }

    It 'Enable when already enabled' {
        {
            # Ensure the flow is already enabled
            Enable-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowToEnable -Confirm:$false | Should -BeNullOrEmpty

            # Attempt to enable the flow again
            Enable-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowToEnable -Confirm:$false | Should -BeNullOrEmpty

            # Verify the flow is still enabled
            $enabledFlow = Get-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowToEnable
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
