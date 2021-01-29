$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateProject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMigrateProject' {
    It 'PutExpandedCustom' -Skip {
        $projName = "AzMigratePwshTestProj123"
        $project = New-AzMigrateProject -Name $projName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId -Location "centralus"
        $project.Name | Should -Be $projName
    }
}