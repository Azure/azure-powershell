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
    It 'Preserves the legacy list output declaration' {
        $outputTypes = @((Get-Command Get-AzWvdSessionHostSingleRegistrationToken).OutputType | ForEach-Object { $_.Name })
        $outputTypes | Should -Contain 'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IRegistrationTokenList'
        $outputTypes | Should -Not -Contain 'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IRegistrationTokenMinimal'
    }

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
            foreach ($registrationToken in @($tokenList)) {
                $registrationToken.Token.GetType().FullName | Should -Be 'System.String'
            }
        } finally {
            Remove-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -HostPoolName $env.StandardHostPoolPersistent `
                -Name $env.SHMSessionHostNameRemove `
                -Force
        }
    }
}
