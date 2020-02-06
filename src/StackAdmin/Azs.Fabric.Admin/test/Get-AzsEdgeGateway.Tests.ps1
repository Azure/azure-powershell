$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsEdgeGateway.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsEdgeGateway' {
        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateEdgeGateway {
                param(
                    [Parameter(Mandatory = $true)]
                    $EdgeGateway
                )

                $EdgeGateway          | Should Not Be $null

                # Resource
                $EdgeGateway.Id       | Should Not Be $null
                $EdgeGateway.Location | Should Not Be $null
                $EdgeGateway.Name     | Should Not Be $null
                $EdgeGateway.Type     | Should Not Be $null

                # Edge Gateway
                $EdgeGateway.NumberOfConnections  | Should Not Be $null
                $EdgeGateway.State                | Should Not Be $null
                $EdgeGateway.TotalCapacity        | Should Not Be $null

            }

            function AssertEdgeGatewaysAreSame {
                param(
                    [Parameter(Mandatory = $true)]
                    $Expected,

                    [Parameter(Mandatory = $true)]
                    $Found
                )

                if ($Expected -eq $null) {
                    $Found | Should Be $null
                } else {
                    $Found                  | Should Not Be $null

                    # Resource
                    $Found.Id               | Should Be $Expected.Id
                    $Found.Location         | Should Be $Expected.Location
                    $Found.Name             | Should Be $Expected.Name
                    $Found.Type             | Should Be $Expected.Type

                    # Edgegateway
                    $Found.NumberOfConnections  | Should Be $Expected.NumberOfConnections
                    $Found.State                | Should Be $Expected.State
                    $Found.TotalCapacity        | Should Be $Expected.TotalCapacity
                }
            }
        }

        AfterEach {
            $global:Client = $null
        }

        It "TestListEdgeGateways" -Skip:$('TestListEdgeGateways' -in $global:SkippedTests) {
            $global:TestName = 'TestListEdgeGateways'

            $gateways = Get-AzsEdgeGateway -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            $gateways | Should Not Be $null
            foreach ($gateway in $gateways) {
                ValidateEdgeGateway -EdgeGateway $gateway
            }
        }

        It "TestGetEdgeGateway" -Skip:$('TestGetEdgeGateway' -in $global:SkippedTests) {
            $global:TestName = 'TestGetEdgeGateway'

            $gateways = Get-AzsEdgeGateway -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            $gateways | Should not be $null
            foreach ($gateway in $gateways) {
                $retrieved = Get-AzsEdgeGateway -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $gateway.Name
                AssertEdgeGatewaysAreSame -Expected $gateway -Found $retrieved
                break
            }
        }

        It "TestGetAllEdgeGateways" -Skip:$('TestGetAllEdgeGateways' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllEdgeGateways'

            $gateways = Get-AzsEdgeGateway -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($gateway in $gateways) {
                $retrieved = Get-AzsEdgeGateway -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $gateway.Name
                AssertEdgeGatewaysAreSame -Expected $gateway -Found $retrieved
            }
        }
}
