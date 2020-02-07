$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsRPHealth.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

DInModuleScope Azs.InfrastructureInsights.Admin {

    Describe "AzsServiceHealths" -Tags @('AzsServiceHealth', 'InfrastructureInsightsAdmin') {

        BeforeEach {

            function ValidateAzsServiceHealth {
                param(
                    [Parameter(Mandatory = $true)]
                    $ServiceHealth
                )

                $ServiceHealth          | Should Not Be $null

                # Resource
                $ServiceHealth.Id       | Should Not Be $null
                $ServiceHealth.Location | Should Not Be $null
                $ServiceHealth.Name     | Should Not Be $null
                $ServiceHealth.Type     | Should Not Be $null

                # Service Health
                $ServiceHealth.AlertSummaryCriticalAlertCount | Should Not Be $null
                $ServiceHealth.AlertSummaryWarningAlertCount | Should Not Be $null
                $ServiceHealth.DisplayName  	| Should Not Be $null
                $ServiceHealth.HealthState  	| Should Not Be $null
                $ServiceHealth.InfraURI  		| Should Not Be $null
                $ServiceHealth.RegistrationId   | Should Not Be $null
                $ServiceHealth.RoutePrefix      | Should Not Be $null
                $ServiceHealth.ServiceLocation	| Should Not Be $null
            }

            function AssertAzsServiceHealthsAreSame {
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


                    $Found.AlertSummaryCriticalAlertCount  | Should Be $Expected.AlertSummaryCriticalAlertCount
                    $Found.AlertSummaryWarningAlertCount   | Should Be $Expected.AlertSummaryWarningAlertCount


                    $Found.DisplayName  	| Should Be $Expected.DisplayName
                    $Found.HealthState  	| Should Be $Expected.HealthState
                    $Found.InfraURI  		| Should Be $Expected.InfraURI
                    $Found.RegistrationId	| Should Be $Expected.RegistrationId
                    $Found.RoutePrefix  	| Should Be $Expected.RoutePrefix
                    $Found.ServiceLocation  | Should Be $Expected.ServiceLocation


                }
            }
        }
        
        it "TestListServiceHealths" -Skip:$('TestListServiceHealths' -in $global:SkippedTests) {
            $global:TestName = 'TestListServiceHealths'


            $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {
                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {
                    ValidateAzsServiceHealth -ServiceHealth $serviceHealth
                }
            }
        }

        it "TestGetServiceHealth" -Skip:$('TestGetServiceHealth' -in $global:SkippedTests) {
            $global:TestName = 'TestGetServiceHealth'

            $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {
                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {
                    $retrieved = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceHealth  $serviceHealth.RegistrationId
                    AssertAzsServiceHealthsAreSame -Expected $serviceHealth -Found $retrieved
                    break
                }
                break
            }
        }

        it "TestGetAllServiceHealths" -Skip:$('TestGetAllServiceHealths' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllServiceHealths'

            $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {
                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {
                    $retrieved = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceHealth  $serviceHealth.RegistrationId
                    AssertAzsServiceHealthsAreSame -Expected $serviceHealth -Found $retrieved
                }
            }
        }



        it "TestGetAllServiceHealths" -Skip:$('TestGetAllServiceHealths' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllServiceHealths'

            $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {
                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {
                    $retrieved = $serviceHealth | Get-AzsRPHealth
                    AssertAzsServiceHealthsAreSame -Expected $serviceHealth -Found $retrieved
                }
            }
        }
    }
}