if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedNetworkVendorSkuPreview'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedNetworkVendorSkuPreview.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedNetworkVendorSkuPreview' {
    # Please input storage value
    $guid = New-Guid
    $storage = ""

    It 'CreateExpanded' {
        {
            $ipconf1 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
            $ipconf2 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
            $ip1 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
            $ip2 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf2 -Name "mrmlannic1" -VMSwitchType "Lan"
            $keyData = @{keyData = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCyMpVbBgu0kftv1k+z1c3NtcB5CVDoo/X9X1LE2JUjlLlo0luEkFGJk61i53BhiTSTeRmQXN8hAZ7sn4MDUmZK7fWcHouZ2fsJo+ehses3wQPLubWBFw2L/hoSTyXifXMbEBu9SxHgqf1CEKQcvdNiWf4U7npXwjweXW9DtsF5E7h4kxhKJKFI4sNFTIX0IwUB15QEVHoBs92kDwH3fBH3kZZCMBJE/u6kT+XB22crRKkIGlp3a9gcogtOCvP+3xmsP7hjw5+nHxMUwkc/6kYyfTeLwvfI4xrTWpnB5xufts5LW5/U5GOXVg97ix9EXgiV0czThowG5K2xQ649UlJb"; path = $Null}
            $key = @( $keyData)
            $role = New-AzConnectedNetworkFunctionRoleConfigurationObject -NetworkInterface $ip1,$ip2 -OSDiskName "Disk1" -OSDiskOstype "Linux" -OSDiskSizeGb 40 -OSProfileCustomDataRequired $False -OSProfileAdminUsername "MecUser" -RoleName "hpehss" -RoleType "VirtualMachine" -VirtualMachineSize "Standard_D3_v2" -SshPublicKey $key -StorageProfileDataDisk $storage -VhdUri "https://mecvdrvhd.blob.core.windows/myvhd.vhd"
            $config = New-AzConnectedNetworkVendorSku -SkuName "sku123" -VendorName $env.VendorName3 -SubscriptionId $env.subscriptionId -SkuType "VirtualMachine" -DeploymentMode "PrivateEdgeZone" -NetworkFunctionRoleConfigurationType @($role)
            $config.VendorName | Should -Be $env.VendorName3

            $config = New-AzConnectedNetworkVendorSkuPreview -PreviewSubscription $guid -SkuName "sku123" -VendorName $env.VendorName3 -SubscriptionId $env.subscriptionId
            $config.Name | Should -Be $guid
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzConnectedNetworkVendorSkuPreview -SkuName "sku123" -VendorName $env.VendorName3
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzConnectedNetworkVendorSkuPreview -PreviewSubscription $guid -SkuName "sku123" -VendorName $env.VendorName3
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzConnectedNetworkVendorSkuPreview -PreviewSubscription $guid -SkuName "sku123" -VendorName $env.VendorName3
        } | Should -Not -Throw
    }
}
