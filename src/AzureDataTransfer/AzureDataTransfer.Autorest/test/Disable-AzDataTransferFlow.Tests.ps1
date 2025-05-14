if(($null -eq $TestName) -or ($TestName -contains 'Disable-AzDataTransferFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Disable-AzDataTransferFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Disable-AzDataTransferFlow' {
    It 'Disable' {
        {
            # Disable the flow
            Disable-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowToDisable -Confirm:$false | Should -BeNullOrEmpty

            # Verify the flow is disabled
            $disabledFlow = Get-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowToDisable
            $disabledFlow.Status | Should -Be "Disabled"
        } | Should -Not -Throw
    }

    It 'Disable when already disabled' {
        {
            # Ensure the flow is already disabled
            Disable-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowToDisable -Confirm:$false | Should -BeNullOrEmpty

            # Attempt to disable the flow again
            Disable-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowToDisable -Confirm:$false | Should -BeNullOrEmpty

            # Verify the flow is still disabled
            $disabledFlow = Get-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowToDisable
            $disabledFlow.Status | Should -Be "Disabled"
        } | Should -Not -Throw
    }

    It 'DisableViaIdentityConnection' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DisableViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
