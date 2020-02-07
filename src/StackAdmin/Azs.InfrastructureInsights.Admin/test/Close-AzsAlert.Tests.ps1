$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Close-AzsAlert.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

InModuleScope Azs.InfrastructureInsights.Admin {

    Describe "Alerts" -Tags @('Alert', 'InfrastructureInsightsAdmin') {

        it "TestCloseAlert" -Skip:$('TestCloseAlert' -in $global:SkippedTests) {

                $global:TestName = 'TestCloseAlert'

                $Alerts = Get-AzsAlert -ResourceGroupName $global:ResourceGroupName -Location $global:location

                $Alerts | Should Not Be $null

                foreach ($Alert in $Alerts) {
                
                    $Alert | Should not be $null
                    $Alert.State | Should not be $null

                    if ($Alert.State -eq "Active") {

                        $Alert | Close-AzsAlert -Location $global:location -User "foobar"

                        return
                    }
                }
         }
    }
}
