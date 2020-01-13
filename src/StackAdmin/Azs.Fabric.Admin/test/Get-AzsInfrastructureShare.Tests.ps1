$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsInfrastructureShare.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsInfrastructureShare' {

    . $PSScriptRoot\StorageCommon.ps1

    BeforeEach {

        function ValidateFileShare {
            param(
                [Parameter(Mandatory = $true)]
                $Share
            )

            $FileShare          | Should Not Be $null

            # Resource
            $FileShare.Id       | Should Not Be $null
            $FileShare.Location | Should Not Be $null
            $FileShare.Name     | Should Not Be $null
            $FileShare.Type     | Should Not Be $null

            # FileShare
            $FileShare.AssociatedVolume  | Should not be $null
            $FileShare.UncPath           | Should not be $null

        }

        function AssertFileSharesAreSame {
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

                # FileShare
                $Found.AssociatedVolume    | Should Be $Expected.AssociatedVolume
                $Found.UncPath             | Should Be $Expected.UncPath

            }
        }
    }

    AfterEach {
        $global:Client = $null
    }

    It "TestListFileShares" -Skip:$('TestListFileShares' -in $global:SkippedTests) {
        $global:TestName = 'TestListFileShares'

        $fileShares = Get-AzsInfrastructureShare -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        $fileShares | Should not be $null
        foreach ($fileShare in $fileShares) {
            ValidateFileShare -Share $fileShare
        }
    }

    It "TestGetFileShare" -Skip:$('TestGetFileShare' -in $global:SkippedTests) {
        $global:TestName = 'TestGetFileShare'

        $fileShares = Get-AzsInfrastructureShare -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        if ($fileShares -and $fileShares.Count -gt 0) {
            $fileShare = $fileShares[0]
            $retrieved = Get-AzsInfrastructureShare -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $fileShare.Name

            AssertFileSharesAreSame -Expected $fileShare -Found $retrieved
        }
    }

    It "TestGetAllFileShares" -Skip:$('TestGetAllFileShares' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllFileShares'

        $fileShares = Get-AzsInfrastructureShare -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($fileShare in $fileShares) {
            $retrieved = Get-AzsInfrastructureShare -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $fileShare.Name
            AssertFileSharesAreSame -Expected $fileShare -Found $retrieved
        }
    }

    It "TestGetFileShareByInputObject" -Skip:$('TestGetFileShareByInputObject' -in $global:SkippedTests) {
        $global:TestName = 'TestGetFileShareByInputObject'

        $fileShare = Get-AzsInfrastructureShare -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Top 1
        $retrieved = Get-AzsInfrastructureShare -InputObject $fileShare
        AssertFileSharesAreSame -Expected $fileShare -Found $retrieved
    }
}
