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

InModuleScope Azs.InfrastructureInsights.Admin {

    Describe "ResourceHealths" -Tags @('ResourceHealth', 'InfrastructureInsightsAdmin') {

        BeforeEach {

            function ValidateResourceHealth {
                param(
                    [Parameter(Mandatory = $true)]
                    $ResourceHealth
                )

                $ResourceHealth          | Should Not Be $null

                # Resource
                $ResourceHealth.Id       | Should Not Be $null
                $ResourceHealth.Location | Should Not Be $null
                $ResourceHealth.Name     | Should Not Be $null
                $ResourceHealth.Type     | Should Not Be $null

                # Scale Unit Node
                $ResourceHealth.AlertSummaryCriticalAlertCount  | Should Not Be $null
                $ResourceHealth.AlertSummaryWarningAlertCount   | Should Not Be $null
                $ResourceHealth.HealthState     	| Should Not Be $null
                # Sometimes this can be null??
                #$ResourceHealth.Namespace  			| Should Not Be $null
                $ResourceHealth.RegistrationId  	| Should Not Be $null
                $ResourceHealth.ResourceDisplayName	| Should Not Be $null
                $ResourceHealth.ResourceLocation	| Should Not Be $null
                $ResourceHealth.ResourceName		| Should Not Be $null
                $ResourceHealth.ResourceType		| Should Not Be $null
                $ResourceHealth.ResourceURI			| Should Not Be $null
                $ResourceHealth.RoutePrefix			| Should Not Be $null
                $ResourceHealth.RpRegistrationId	| Should Not Be $null
            }

            function AssertResourceHealthsAreSame {
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

                    # Resource Health
                    $Found.AlertSummaryCriticalAlertCount  | Should Be $Expected.AlertSummaryCriticalAlertCount
                    $Found.AlertSummaryWarningAlertCount  	| Should Be $Expected.AlertSummaryWarningAlertCount

                    $Found.HealthState      	| Should Be $Expected.HealthState
                    $Found.NamespaceProperty	| Should Be $Expected.NamespaceProperty
                    $Found.RegistrationId       | Should Be $Expected.RegistrationId
                    $Found.ResourceDisplayName  | Should Be $Expected.ResourceDisplayName
                    $Found.ResourceLocation   	| Should Be $Expected.ResourceLocation
                    $Found.ResourceName      	| Should Be $Expected.ResourceName
                    $Found.ResourceType  		| Should Be $Expected.ResourceType
                    $Found.ResourceURI  		| Should Be $Expected.ResourceURI
                    $Found.RoutePrefix  		| Should Be $Expected.RoutePrefix
                    $Found.RpRegistrationId  	| Should Be $Expected.RpRegistrationId
                }
            }
        }

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
}