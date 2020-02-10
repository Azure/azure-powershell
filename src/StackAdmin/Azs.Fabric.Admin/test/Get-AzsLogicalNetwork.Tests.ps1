$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsLogicalNetwork.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsLogicalNetwork' {
    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidateLogicalNetwork {
            param(
                [Parameter(Mandatory = $true)]
                $LogicalNetwork
            )

            $LogicalNetwork          | Should Not Be $null

            # Resource
            $LogicalNetwork.Id       | Should Not Be $null
            $LogicalNetwork.Location | Should Not Be $null
            $LogicalNetwork.Name     | Should Not Be $null
            $LogicalNetwork.Type     | Should Not Be $null

            # Logical Network
            $LogicalNetwork.NetworkVirtualizationEnabled  | Should Not Be $null
            $LogicalNetwork.Subnets                       | Should Not Be $null
        }

        function AssertLogicalNetworksAreSame {
            param(
                [Parameter(Mandatory = $true)]
                $Expected,

                [Parameter(Mandatory = $true)]
                $Found
            )
            if ($Expected -eq $null) {
                $Found | Should Be $null
            }
            else {
                $Found                  | Should Not Be $null

                # Resource
                $Found.Id               | Should Be $Expected.Id
                $Found.Location         | Should Be $Expected.Location
                $Found.Name             | Should Be $Expected.Name
                $Found.Type             | Should Be $Expected.Type

                # Logical Network
                $Found.NetworkVirtualizationEnabled  | Should Be $Expected.NetworkVirtualizationEnabled

                if ($Expected.Subnets -eq $null) {
                    $Found.Subnets        | Should Be $null
                }
                else {
                    $Found.Subnets        | Should Not Be $null
                    $Found.Subnets.Count  | Should Be $Expected.Subnets.Count
                }

                if ($Expected.Metadata -eq $null) {
                    $Found.Metadata        | Should Be $null
                }
                else {
                    $Found.Metadata        | Should Not Be $null
                    $Found.Metadata.Count  | Should Be $Expected.Metadata.Count
                }
            }
        }
    }

    AfterEach {
        $global:Client = $null
    }


    it "TestListLogicalNetworks" -Skip:$('TestListLogicalNetworks' -in $global:SkippedTests) {
        $global:TestName = 'TestListLogicalNetworks'
        $logicalNetworks = Get-AzsLogicalNetwork -ResourceGroupName $global:ResourceGroupName -Location $Location
        $logicalNetworks | Should Not Be $null
        foreach ($logicalNetwork in $logicalNetworks) {
            ValidateLogicalNetwork -LogicalNetwork $logicalNetwork
        }
    }


    it "TestGetLogicalNetwork" -Skip:$('TestGetLogicalNetwork' -in $global:SkippedTests) {
        $global:TestName = 'TestGetLogicalNetwork'

        $logicalNetworks = Get-AzsLogicalNetwork -ResourceGroupName $global:ResourceGroupName -Location $Location
        foreach ($logicalNetwork in $logicalNetworks) {
            $retrieved = Get-AzsLogicalNetwork -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $logicalNetwork.Name
            AssertLogicalNetworksAreSame -Expected $logicalNetwork -Found $retrieved
            break
        }
    }

    It "TestGetAllLogicalNetworks" -Skip:$('TestGetAllLogicalNetworks' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllLogicalNetworks'

        $logicalNetworks = Get-AzsLogicalNetwork -ResourceGroupName $global:ResourceGroupName -Location $Location
        foreach ($logicalNetwork in $logicalNetworks) {
            $retrieved = Get-AzsLogicalNetwork -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $logicalNetwork.Name
            AssertLogicalNetworksAreSame -Expected $logicalNetwork -Found $retrieved
        }
    }
}
