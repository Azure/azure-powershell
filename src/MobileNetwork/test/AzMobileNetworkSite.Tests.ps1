if(($null -eq $TestName) -or ($TestName -contains 'AzMobileNetworkSite'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMobileNetworkSite.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMobileNetworkSite' {
    It 'CreateExpanded' {
        {
            $config = New-AzMobileNetworkSite -MobileNetworkName $env.testNetwork2 -Name $env.testSite -ResourceGroupName $env.resourceGroup -Location $env.location -Tag @{"site"="123"}
            $config.Name | Should -Be $env.testSite

            # Create with data network
            $config = New-AzMobileNetworkSite -MobileNetworkName $env.testNetwork2 -Name $env.testSite -ResourceGroupName $env.resourceGroup -Location $env.location -Tag @{"site"="123"} -DataNetworkName 'internet'
            $config.Name[0] | Should -Be $env.testSite
            $config.Name[1] | Should -Be 'internet'

            # Create with data network and control plane
            # If running in Record or Live mode, the AzureStackEdgeDeviceId parameter must be set to an ASE ID that exists in the subscription being run in.
            $config = New-AzMobileNetworkSite -MobileNetworkName $env.testNetwork2 -Name $env.testSite -ResourceGroupName $env.resourceGroup -Location $env.location -Tag @{"site"="123"} `
                -DataNetworkName 'internet' -PlatformType AKS-HCI -AzureStackEdgeDeviceId /subscriptions/9e276fe5-9273-4474-80c6-032321ab3795/resourceGroups/ASE-22-RG/providers/Microsoft.DataBoxEdge/DataBoxEdgeDevices/ASE-22 `
                -ControlPlaneAccessInterfaceName N2 -ControlPlaneAccessInterfaceIpv4Address 100.1.1.1 -ControlPlaneAccessInterfaceIpv4Gateway 100.1.1.2 -ControlPlaneAccessInterfaceIpv4Subnet 100.1.1.0/24 `
                -LocalDiagnosticAccessAuthenticationType Password -CoreNetworkTechnology 5GC -Sku G0
            $config.Name[0] | Should -Be $env.testSite
            $config.Name[1] | Should -Be 'internet'
            $pccpName = $env.testSite + '-PacketCoreControlPlane'
            $config.Name[2] | Should -Be $pccpName

            # Create with data network, control plane and data plane
            # If running in Record or Live mode, the AzureStackEdgeDeviceId parameter must be set to an ASE ID that exists in the subscription being run in.
            $config = New-AzMobileNetworkSite -MobileNetworkName $env.testNetwork2 -Name $env.testSite -ResourceGroupName $env.resourceGroup -Location $env.location -Tag @{"site"="123"} `
                -DataNetworkName 'internet' -PlatformType AKS-HCI -AzureStackEdgeDeviceId /subscriptions/9e276fe5-9273-4474-80c6-032321ab3795/resourceGroups/ASE-22-RG/providers/Microsoft.DataBoxEdge/DataBoxEdgeDevices/ASE-22 `
                -ControlPlaneAccessInterfaceName N2 -ControlPlaneAccessInterfaceIpv4Address 100.1.1.1 -ControlPlaneAccessInterfaceIpv4Gateway 100.1.1.2 -ControlPlaneAccessInterfaceIpv4Subnet 100.1.1.0/24 `
                -LocalDiagnosticAccessAuthenticationType Password -CoreNetworkTechnology 5GC -Sku G0 -UserPlaneAccessInterfaceName N3
            $config.Name[0] | Should -Be $env.testSite
            $config.Name[1] | Should -Be 'internet'
            $pccpName = $env.testSite + '-PacketCoreControlPlane'
            $config.Name[2] | Should -Be $pccpName
            $pcdpName = $env.testSite + '-PacketCoreDataPlane'
            $config.Name[3] | Should -Be $pcdpName

            # Create with data network, control plane and data plane
            # If running in Record or Live mode, the AzureStackEdgeDeviceId parameter must be set to an ASE ID that exists in the subscription being run in.
            $config = New-AzMobileNetworkSite -MobileNetworkName $env.testNetwork2 -Name $env.testSite -ResourceGroupName $env.resourceGroup -Location $env.location -Tag @{"site"="123"} `
                -DataNetworkName 'internet' -PlatformType AKS-HCI -AzureStackEdgeDeviceId /subscriptions/9e276fe5-9273-4474-80c6-032321ab3795/resourceGroups/ASE-22-RG/providers/Microsoft.DataBoxEdge/DataBoxEdgeDevices/ASE-22 `
                -ControlPlaneAccessInterfaceName N2 -ControlPlaneAccessInterfaceIpv4Address 100.1.1.1 -ControlPlaneAccessInterfaceIpv4Gateway 100.1.1.2 -ControlPlaneAccessInterfaceIpv4Subnet 100.1.1.0/24 `
                -LocalDiagnosticAccessAuthenticationType Password -CoreNetworkTechnology 5GC -Sku G0 -UserPlaneAccessInterfaceName N3 -DnsAddress 8.8.8.8 -UserPlaneDataInterfaceName N6 -UserEquipmentAddressPoolPrefix 101.0.0.0/24
            $config.Name[0] | Should -Be $env.testSite
            $config.Name[1] | Should -Be 'internet'
            $pccpName = $env.testSite + '-PacketCoreControlPlane'
            $config.Name[2] | Should -Be $pccpName
            $pcdpName = $env.testSite + '-PacketCoreDataPlane'
            $config.Name[3] | Should -Be $pcdpName
            $config.Name[4] | Should -Be 'internet'
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMobileNetworkSite -ResourceGroupName $env.resourceGroup -MobileNetworkName $env.testNetwork2
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMobileNetworkSite -ResourceGroupName $env.resourceGroup -MobileNetworkName $env.testNetwork2 -Name $env.testSite
            $config.Name | Should -Be $env.testSite
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzMobileNetworkSite -ResourceGroupName $env.resourceGroup -MobileNetworkName $env.testNetwork2 -SiteName $env.testSite -Tag @{"site"="123"}
            $config.Name | Should -Be $env.testSite
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzMobileNetworkSite -ResourceGroupName $env.resourceGroup -MobileNetworkName $env.testNetwork2 -Name $env.testSite
            $config = Update-AzMobileNetworkSite -InputObject $config -Tag @{"site"="123"}
            $config.Name | Should -Be $env.testSite
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMobileNetworkSite -ResourceGroupName $env.resourceGroup -MobileNetworkName $env.testNetwork2 -Name $env.testSite
        } | Should -Not -Throw
    }
}
