if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedNetworkVendorFunction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedNetworkVendorFunction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedNetworkVendorFunction' {
    # Please input the ServiceKey and storage value
    $ServiceKey = ""
    $storage = ""

    It 'CreateExpanded' {
        {
            $ipconf1 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
            $ipconf2 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
            $ip1 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
            $ip2 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf2 -Name "mrmlannic1" -VMSwitchType "Lan"
            $keyData = @{keyData = "ssh-rsa\AAAAB3NzaC1yc2EAAAADAQABAAABAQCyMpVbBgu0kftv1k+z1c3NtcB5CVDoo/X9X1LE2JUjlLlo0luEkFGJk61i53BhiTSTeRmQXN8hAZ7sn4MDUmZK7fWcHouZ2fsJo+ehses3wQPLubWBFw2L/hoSTyXifXMbEBu9SxHgqf1CEKQcvdNiWf4U7npXwjweXW9DtsF5E7h4kxhKJKFI4sNFTIX0IwUB15QEVHoBs92kDwH3fBH3kZZCMBJE/u6kT+XB22crRKkIGlp3a9gcogtOCvP+3xmsP7hjw5+nHxMUwkc/6kYyfTeLwvfI4xrTWpnB5xufts5LW5/U5GOXVg97ix9EXgiV0czThowG5K2xQ649UlJb redmond\user@n1-azuredev1"; path = $Null}
            $keys = @{ }
            $key += $keyData
            $vendorconf = New-AzConnectedNetworkFunctionVendorConfigurationObject -NetworkInterface $ip1,$ip2 -RoleName "hpehss" -OSProfileAdminUsername "MecUser" -OSProfileCustomData $customData -OSProfileCustomDataRequired $True -SshPublicKey $key
            $config = New-AzConnectedNetworkVendorFunction -LocationName "eastus2euap" -ServiceKey $ServiceKey -SubscriptionId $env.subscriptionId -VendorName $env.VendorName3 -VendorConfiguration $vendorconf -SkuType "EvolvedPacketCore" -VendorProvisioningState "Provisioning"
            $config.VendorName | Should -Be $env.VendorName3
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzConnectedNetworkVendorFunction -LocationName "eastus2euap" -VendorName $env.VendorName3
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzConnectedNetworkVendorFunction -LocationName "eastus2euap" -VendorName $env.VendorName3 -ServiceKey $ServiceKey
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }
}
