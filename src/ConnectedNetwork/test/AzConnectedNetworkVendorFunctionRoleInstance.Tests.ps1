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
    # Please input the ServiceKey
    $ServiceKey = ""

    It 'Start' {
        {
            $config = Start-AzConnectedNetworkVendorFunctionRoleInstance -LocationName "centraluseuap" -ServiceKey $ServiceKey -SubscriptionId $env.subscriptionId -VendorName $env.VendorName3 -Name "role1"
        } | Should -Not -Throw
    }

    It 'StartViaIdentity' {
        {
            $role = @{ RoleInstanceName = "role123"; LocationName = "centraluseuap"; SubscriptionId = $env.subscriptionId; VendorName = $env.VendorName3; serviceKey = $ServiceKey}
            $config = Start-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzConnectedNetworkVendorFunctionRoleInstance -LocationName "centraluseuap" -ServiceKey $ServiceKey -VendorName $env.VendorName3
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzConnectedNetworkVendorFunctionRoleInstance -Name "role123" -LocationName "centraluseuap" -ServiceKey $ServiceKey -VendorName $env.VendorName3
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'Stop' {
        {
            Stop-AzConnectedNetworkVendorFunctionRoleInstance -Name "role1" -LocationName "centraluseuap" -ServiceKey $ServiceKey -VendorName $env.VendorName3
        } | Should -Not -Throw
    }

    It 'StopViaIdentity' {
        {
            $role = Get-AzConnectedNetworkVendorFunctionRoleInstance -Name "role123" -LocationName "centraluseuap" -ServiceKey $ServiceKey -VendorName $env.VendorName3
            Stop-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role
        } | Should -Not -Throw
    }

    It 'Restart' {
        {
            Restart-AzConnectedNetworkVendorFunctionRoleInstance -Name "role1" -LocationName "centraluseuap" -ServiceKey $ServiceKey -VendorName $env.VendorName3
        } | Should -Not -Throw
    }

    It 'RestartViaIdentity' {
        {
            $role = Get-AzConnectedNetworkVendorFunctionRoleInstance -Name "role123" -LocationName "centraluseuap" -ServiceKey $ServiceKey -VendorName $env.VendorName3
            Restart-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role
        } | Should -Not -Throw
    }
}
