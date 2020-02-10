$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsEdgeGatewayPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsEdgeGatewayPool' {
        . $PSScriptRoot\Common.ps1

        BeforeEach {
            function ValidateEdgeGatewayPool {
                param(
                    [Parameter(Mandatory = $true)]
                    $EdgeGatewayPool
                )

                $EdgeGatewayPool          | Should Not Be $null

                # Resource
                $EdgeGatewayPool.Id       | Should Not Be $null
                $EdgeGatewayPool.Location | Should Not Be $null
                $EdgeGatewayPool.Name     | Should Not Be $null
                $EdgeGatewayPool.Type     | Should Not Be $null

                # Edge Gateway Pool
                $EdgeGatewayPool.GatewayType      | Should Not Be $null
                $EdgeGatewayPool.PublicIpAddress  | Should Not Be $null
                $EdgeGatewayPool.NumberOfGateways | Should Not Be $null
            }

            function AssertEdgeGatewayPoolsAreSame {
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

                    # Edge Gateway Pool
                    $Found.GatewayType      | Should Be $Expected.GatewayType
                    $Found.PublicIpAddress  | Should Be $Expected.PublicIpAddress
                    $Found.NumberOfGateways | Should Be $Expected.NumberOfGateways
                }
            }
        }

        AfterEach {
            $global:Client = $null
        }


        It "TestListEdgeGatewayPools" -Skip:$('TestListEdgeGatewayPools' -in $global:SkippedTests) {
            $global:TestName = 'TestListEdgeGatewayPools'
            $edgeGatewayPools = Get-AzsEdgeGatewayPool -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            $edgeGatewayPools | Should Not Be $null
            foreach ($edgeGatewayPool in $edgeGatewayPools) {
                ValidateEdgeGatewayPool -EdgeGatewayPool $edgeGatewayPool
            }
        }


        It "TestGetEdgeGatewayPool" -Skip:$('TestGetEdgeGatewayPool' -in $global:SkippedTests) {
            $global:TestName = 'TestGetEdgeGatewayPool'

            $edgeGatewayPools = Get-AzsEdgeGatewayPool -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($edgeGatewayPool in $edgeGatewayPools) {
                $retrieved = Get-AzsEdgeGatewayPool -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $edgeGatewayPool.Name
                AssertEdgeGatewayPoolsAreSame -Expected $edgeGatewayPool -Found $retrieved
                break
            }
        }

        It "TestGetAllEdgeGatewayPools" -Skip:$('TestGetAllEdgeGatewayPools' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllEdgeGatewayPools'

            $edgeGatewayPools = Get-AzsEdgeGatewayPool -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($edgeGatewayPool in $edgeGatewayPools) {
                $retrieved = Get-AzsEdgeGatewayPool -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $edgeGatewayPool.Name
                AssertEdgeGatewayPoolsAreSame -Expected $edgeGatewayPool -Found $retrieved
            }
        }
}
