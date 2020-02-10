$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzsIPPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzsIPPool' {
    It "TestCreateIpPool" -Skip:$('TestCreateIpPool' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateIpPool'

            $Name = "okaytodelete"
            $StartIpAddress = "192.168.99.1"
            $EndIpAddress = "192.168.99.254"
            $AddressPrefix = "192.168.99.0/24"


            $params = @($Location, $global:ResourceGroupName, $Name, $StartIpAddress, $EndIpAddress, $AddressPrefix)
            $ipPool = New-AzsIpPool @params

            $ipPool | Should not be $null
    }
}
