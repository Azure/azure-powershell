if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedNetworkVendorSku'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedNetworkVendorSku.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedNetworkVendorSku' {
    It 'CreateExpanded' {
        {
            $ipconf1 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
            $ipconf2 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
            $ip1 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
            $ip2 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf2 -Name "mrmlannic1" -VMSwitchType "Lan"
            $keyData = @{keyData = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCyMpVbBgu0kftv1k+z1c3NtcB5CVDoo/X9X1LE2JUjlLlo0luEkFGJk61i53BhiTSTeRmQXN8hAZ7sn4MDUmZK7fWcHouZ2fsJo+ehses3wQPLubWBFw2L/hoSTyXifXMbEBu9SxHgqf1CEKQcvdNiWf4U7npXwjweXW9DtsF5E7h4kxhKJKFI4sNFTIX0IwUB15QEVHoBs92kDwH3fBH3kZZCMBJE/u6kT+XB22crRKkIGlp3a9gcogtOCvP+3xmsP7hjw5+nHxMUwkc/6kYyfTeLwvfI4xrTWpnB5xufts5LW5/U5GOXVg97ix9EXgiV0czThowG5K2xQ649UlJb"; path = $Null}
            $key = @( $keyData)
            $role = New-AzConnectedNetworkFunctionRoleConfigurationObject -NetworkInterface $ip1,$ip2 -OSDiskName "Disk1" -OSDiskOstype "Linux" -OSDiskSizeGb 150 -OSProfileCustomDataRequired $False -OSProfileAdminUsername "MecUser" -RoleName $env.RoleName -RoleType "VirtualMachine" -VirtualMachineSize "Standard_D3_v2" -SshPublicKey $key -StorageProfileDataDisk $null -VhdUri "https://xy-abcde123.blob.core.windows.net/myvhd.vhdx"
            $config = New-AzConnectedNetworkVendorSku -SkuName "sku1" -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription -SkuType "EvolvedPacketCore" -DeploymentMode "PrivateEdgeZone" -NetworkFunctionRoleConfigurationType @($role)
            $config.Name | Should -Be "sku1"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzConnectedNetworkVendorSku -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzConnectedNetworkVendorSku -SkuName "sku1" -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
            $config.Name | Should -Be "sku1"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzConnectedNetworkVendorSku -SkuName "sku1" -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
        } | Should -Not -Throw
    }
}
