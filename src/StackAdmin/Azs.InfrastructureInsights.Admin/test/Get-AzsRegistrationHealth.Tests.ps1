$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsRegistrationHealth.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName


Describe "ResourceHealths" -Tags @('ResourceHealth', 'InfrastructureInsightsAdmin') {

    . $PSScriptRoot\Common.ps1

    it "TestListResourceHealths" -Skip:$('TestListResourceHealths' -in $global:SkippedTests) {
        $global:TestName = 'TestListResourceHealths'

        $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
        foreach ($RegionHealth in $RegionHealths) {
            $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
            foreach ($serviceHealth in $ServiceHealths) {
                $ResourceHealths = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationId $serviceHealth.RegistrationId
                foreach ($ResourceHealth in $ResourceHealths) {
                    ValidateResourceHealth -ResourceHealth $ResourceHealth
                }
            }
        }
    }


    it "TestGetResourceHealth" -Skip:$('TestGetResourceHealth' -in $global:SkippedTests) {
        $global:TestName = 'TestGetResourceHealth'

        $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
        foreach ($RegionHealth in $RegionHealths) {

            $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
            foreach ($serviceHealth in $ServiceHealths) {

                $infraRoleHealths = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationId $serviceHealth.RegistrationId
                foreach ($infraRoleHealth in $infraRoleHealths) {

                    $retrieved = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationId $serviceHealth.RegistrationId -Name $infraRoleHealth.Name
                    AssertResourceHealthsAreSame -Expected $infraRoleHealth -Found $retrieved
                    break
                }
                break
            }
            break
        }
    }

    it "TestGetAllResourceHealths" -Skip:$('TestGetAllResourceHealths' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllResourceHealths'

        $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
        foreach ($RegionHealth in $RegionHealths) {

            $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
            foreach ($serviceHealth in $ServiceHealths) {

                $infraRoleHealths = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationId $serviceHealth.RegistrationId
                foreach ($infraRoleHealth in $infraRoleHealths) {

                    $retrieved = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationId $serviceHealth.RegistrationId -ResourceRegistrationId $infraRoleHealth.RegistrationId
                    AssertResourceHealthsAreSame -Expected $infraRoleHealth -Found $retrieved
                }
            }
        }
    }

    it "TestGetAllResourceHealths" -Skip:$('TestGetAllResourceHealths' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllResourceHealths'

        $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
        foreach ($RegionHealth in $RegionHealths) {

            $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
            foreach ($serviceHealth in $ServiceHealths) {

                $infraRoleHealths = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationId $serviceHealth.RegistrationId
                foreach ($infraRoleHealth in $infraRoleHealths) {

                    $infraRoleHealth | Should not be $null

                    $retrieved = $infraRoleHealth | Get-AzsRegistrationHealth
                    AssertResourceHealthsAreSame -Expected $infraRoleHealth -Found $retrieved
                }
            }
        }
    }
}