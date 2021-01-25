$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMigrateProject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzMigrateProject' {
    It 'Delete' -Skip {
        $props = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateProjectProperties]::new()
        $props.RegisteredTool = {}
        $projName = "AzMigratePwshTestProj"
        New-AzMigrateProject -Name $projName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId -Location "centralus" -ETag "*" -Property $props
        {Remove-AzMigrateProject -Name $projName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId} | Should -Not -Throw
    }
}
