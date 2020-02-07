$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsIPPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe "IpPools" -Tags @('IpPool', 'Azs.Fabric.Admin') {

    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidateIpPool {
            param(
                [Parameter(Mandatory = $true)]
                $IpPool
            )

            $IpPool          | Should Not Be $null

            # Resource
            $IpPool.Id       | Should Not Be $null
            $IpPool.Location | Should Not Be $null
            $IpPool.Name     | Should Not Be $null
            $IpPool.Type     | Should Not Be $null

            # IpPool
            $IpPool.EndIpAddress                     | Should not be $null
            $IpPool.NumberOfAllocatedIpAddresses     | Should not be $null
            $IpPool.NumberOfIpAddresses              | Should not be $null
            $IpPool.NumberOfIpAddressesInTransition  | Should not be $null
            $IpPool.StartIpAddress                   | Should not be $null

        }

        function AssertIpPoolsAreSame {
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

                # IpPool
                $Found.EndIpAddress                     | Should Be $Expected.EndIpAddress
                $Found.NumberOfAllocatedIpAddresses     | Should Be $Expected.NumberOfAllocatedIpAddresses
                $Found.NumberOfIpAddresses              | Should Be $Expected.NumberOfIpAddresses
                $Found.NumberOfIpAddressesInTransition  | Should Be $Expected.NumberOfIpAddressesInTransition
                $Found.StartIpAddress                   | Should Be $Expected.StartIpAddress

            }
        }
    }

    AfterEach {
        $global:Client = $null
    }

    It "TestListIpPools" -Skip:$('TestListIpPools' -in $global:SkippedTests) {
        $global:TestName = 'TestListIpPools'
        $IpPools = Get-AzsIpPool -ResourceGroupName $global:ResourceGroupName -Location $Location
        $IpPools | Should not be $null
        foreach ($IpPool in $IpPools) {
            ValidateIpPool -IpPool $IpPool
        }
    }

    It "TestGetIpPool" -Skip:$('TestGetIpPool' -in $global:SkippedTests) {
        $global:TestName = 'TestGetIpPool'

        $IpPools = Get-AzsIpPool -ResourceGroupName $global:ResourceGroupName -Location $Location
        if ($IpPools -and $IpPools.Count -gt 0) {
            $IpPool = $IpPools[0]
            $retrieved = Get-AzsIpPool -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $IpPool.Name
            AssertIpPoolsAreSame -Expected $IpPool -Found $retrieved
        }
    }

    It "TestGetAllIpPools" -Skip:$('TestGetAllIpPools' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllIpPools'

        $IpPools = Get-AzsIpPool -ResourceGroupName $global:ResourceGroupName -Location $Location
        foreach ($IpPool in $IpPools) {
            $retrieved = Get-AzsIpPool -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $IpPool.Name
            AssertIpPoolsAreSame -Expected $IpPool -Found $retrieved
        }
    }
}