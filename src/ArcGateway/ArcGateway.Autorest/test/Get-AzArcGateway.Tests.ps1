if(($null -eq $TestName) -or ($TestName -contains 'Get-AzArcGateway'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzArcGateway.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzArcGateway' {
    It 'List1' {
        $gateway = Get-AzArcGateway -SubscriptionId $env.SubscriptionId
        $gateway | Should -Not -Be $null
    }

    It 'Get' {
        $gateway = Get-AzArcGateway -Name $env.Name -ResourceGroupName $env.ResourceGroupName
        $gateway | Should -Not -Be $null
    }

    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
