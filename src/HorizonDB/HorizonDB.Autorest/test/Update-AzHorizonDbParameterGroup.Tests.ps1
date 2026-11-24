if(($null -eq $TestName) -or ($TestName -contains 'Update-AzHorizonDbParameterGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzHorizonDbParameterGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzHorizonDbParameterGroup' {
    It 'UpdateExpanded' {
        $null = Update-AzHorizonDbParameterGroup -ResourceGroupName $env.sharedResourceGroup -Name $env.sharedParameterGroupName -SubscriptionId $env.SubscriptionId -Parameter @(@{ Name = 'work_mem'; Value = '16384' }) -Confirm:$false -ErrorAction Stop

        $parameterGroup = Get-AzHorizonDbParameterGroup -ResourceGroupName $env.sharedResourceGroup -Name $env.sharedParameterGroupName -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $parameterGroup.Name | Should -Be $env.sharedParameterGroupName
        $parameterGroup.ResourceGroupName | Should -Be $env.sharedResourceGroup
        $workMem = @($parameterGroup.Parameter | Where-Object { $_.Name -eq 'work_mem' })
        $workMem.Count | Should -Be 1
        $workMem[0].Value | Should -Be '16384'
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
