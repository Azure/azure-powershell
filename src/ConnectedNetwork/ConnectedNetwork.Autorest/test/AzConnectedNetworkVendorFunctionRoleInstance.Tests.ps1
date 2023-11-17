if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedNetworkVendorFunctionRoleInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedNetworkVendorFunctionRoleInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedNetworkVendorFunctionRoleInstance' {
    It 'Start' {
        {
            $config = Start-AzConnectedNetworkVendorFunctionRoleInstance -Name $env.RoleName -LocationName $env.Location -ServiceKey $env.ServiceKey -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
        } | Should -Not -Throw
    }

    It 'Restart' {
        {
            Restart-AzConnectedNetworkVendorFunctionRoleInstance -Name $env.RoleName -LocationName $env.Location -ServiceKey $env.ServiceKey -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
        } | Should -Not -Throw
    }

    It 'Stop' {
        {
            Stop-AzConnectedNetworkVendorFunctionRoleInstance -Name $env.RoleName -LocationName $env.Location -ServiceKey $env.ServiceKey -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzConnectedNetworkVendorFunctionRoleInstance -LocationName $env.Location -ServiceKey $env.ServiceKey -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'StartViaIdentity' {
        {
            $role = @{ RoleInstanceName = $env.RoleName; LocationName = $env.Location; SubscriptionId = $env.VendorSubscription; VendorName = $env.existingVendor; serviceKey = $env.ServiceKey}
            $config = Start-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role
        } | Should -Not -Throw
    }

    It 'RestartViaIdentity' {
        {
            $role = @{ RoleInstanceName = $env.RoleName; LocationName = $env.Location; SubscriptionId = $env.VendorSubscription; VendorName = $env.existingVendor; serviceKey = $env.ServiceKey}
            Restart-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role
        } | Should -Not -Throw
    }

    It 'StopViaIdentity' {
        {
            $role = @{ RoleInstanceName = $env.RoleName; LocationName = $env.Location; SubscriptionId = $env.VendorSubscription; VendorName = $env.existingVendor; serviceKey = $env.ServiceKey}
            Stop-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzConnectedNetworkVendorFunctionRoleInstance -Name $env.RoleName -LocationName $env.Location -ServiceKey $env.ServiceKey -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }
}
