if(($null -eq $TestName) -or ($TestName -contains 'Get-AzContainerRegistry'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerRegistry.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzContainerRegistry' {
    It 'List' {
        $List = Get-AzContainerRegistry -SubscriptionId $env.SubscriptionId
        $List.count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $Obj = Get-AzContainerRegistry -Name $env.rstr1 -ResourceGroupName $env.ResourceGroup 
        $Obj.Name | Should -Be $env.rstr1
    }

    It 'List1'{
        $List = Get-AzContainerRegistry -ResourceGroupName $env.ResourceGroup
        $List.count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $obj = Get-AzContainerRegistry -Name $env.rstr1 -ResourceGroupName $env.ResourceGroup
        $res = Get-AzContainerRegistry -InputObject $Obj
        $res.Name | Should -Be $env.rstr1
    }
}
