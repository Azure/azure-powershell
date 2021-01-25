$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzPostgreSqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restart-AzPostgreSqlFlexibleServer' {
    It 'Restart' {
        {
            Restart-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } | Should -Not -Throw
    }

    It 'RestartViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/restart"
            Restart-AzPostgreSqlFlexibleServer -InputObject $ID
        } | Should -Not -Throw
    }
}
