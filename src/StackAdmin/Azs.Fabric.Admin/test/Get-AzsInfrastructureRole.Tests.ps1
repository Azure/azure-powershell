$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsInfrastructureRole.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsInfrastructureRole' {
        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateInfrastructureRole {
                param(
                    [Parameter(Mandatory = $true)]
                    $InfrastructureRole
                )

                $InfrastructureRole          | Should Not Be $null

                # Resource
                $InfrastructureRole.Id       | Should Not Be $null
                $InfrastructureRole.Location | Should Not Be $null
                $InfrastructureRole.Name     | Should Not Be $null
                $InfrastructureRole.Type     | Should Not Be $null

                # Infra Role
                $InfrastructureRole.Instances | Should Not be $null
                $InfrastructureRole.Instances.Count | Should Not be 0

            }

            function AssertInfrastructureRolesAreSame {
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

                    # Infra Role
                    $Found.Instances.Count| Should Be $Expected.Instances.Count

                }
            }
        }

        AfterEach {
            $global:Client = $null
        }

        It "TestListInfraRoles" -Skip:$('TestListInfraRoles' -in $global:SkippedTests) {
            $global:TestName = 'TestListInfraRoles'
            $InfrastructureRoles = Get-AzsInfrastructureRole -ResourceGroupName $global:ResourceGroupName -Location $Location
            $InfrastructureRoles | Should Not Be $null
            foreach ($InfrastructureRole in $InfrastructureRoles) {
                ValidateInfrastructureRole -InfrastructureRole $InfrastructureRole
            }
        }

        It "TestGetInfraRole" -Skip:$('TestGetInfraRole' -in $global:SkippedTests) {
            $global:TestName = 'TestGetInfraRole'

            $InfrastructureRoles = Get-AzsInfrastructureRole -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($InfrastructureRole in $InfrastructureRoles) {
                $retrieved = Get-AzsInfrastructureRole -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $InfrastructureRole.Name
                AssertInfrastructureRolesAreSame -Expected $InfrastructureRole -Found $retrieved
                break
            }
        }

        It "TestGetAllInfraRoles" -Skip:$('TestGetAllInfraRoles' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllInfraRoles'

            $InfrastructureRoles = Get-AzsInfrastructureRole -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($InfrastructureRole in $InfrastructureRoles) {
                $name = $InfrastructureRole.Name
                $check = -not ($name -like "*User*" -or $name -like "*Administrator*")
                if ($check) {
                    $retrieved = Get-AzsInfrastructureRole -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $InfrastructureRole.Name
                    AssertInfrastructureRolesAreSame -Expected $InfrastructureRole -Found $retrieved
                }
            }
        }
}
