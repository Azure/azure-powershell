if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWvdSessionHostSingleRegistrationToken'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdSessionHostSingleRegistrationToken.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWvdSessionHostSingleRegistrationToken' {
    It 'Retrieve' {
        try {
            New-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -HostPoolName $env.StandardHostPoolPersistent `
                -Name $env.SHMSessionHostNameRemove

            $tokenList = Get-AzWvdSessionHostSingleRegistrationToken `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -HostPoolName $env.StandardHostPoolPersistent `
                -SessionHostName $env.SHMSessionHostNameRemove `
                -ExpirationTimeInUtc (Get-Date).ToUniversalTime().AddHours(2)
            $tokenList | Should -Not -BeNullOrEmpty
            $tokenList[0].Token | Should -Not -BeNullOrEmpty
        } finally {
            Remove-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -HostPoolName $env.StandardHostPoolPersistent `
                -Name $env.SHMSessionHostNameRemove `
                -Force
        }
    }
}
