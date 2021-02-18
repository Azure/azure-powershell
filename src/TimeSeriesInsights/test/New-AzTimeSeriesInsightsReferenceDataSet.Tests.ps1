$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzTimeSeriesInsightsReferenceDataSet.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzTimeSeriesInsightsReferenceDataSet' {
    It 'CreateExpanded' {
        $tsiDsName = 'tsirds001'
        $mykeyproperties = @{ "name" = "device01"; "type" = "Double"}
        $environmentName = $env.rstrenv02 
        $tsiDs = New-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $environmentName -Name $tsiDsName -ResourceGroupName $env.resourceGroup -Location $env.location -DataStringComparisonBehavior Ordinal -KeyProperty $mykeyproperties
        $tsiDs.Name | Should -Be $tsiDsName
    }
}
