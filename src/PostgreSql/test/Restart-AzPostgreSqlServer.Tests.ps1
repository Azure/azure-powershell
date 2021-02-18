$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzPostgreSqlServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restart-AzPostgreSqlServer' {
    It 'Restart' {
        { 
            Restart-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup -Name $env.serverName 
        } | Should -Not -Throw
    }

    It 'RestartViaIdentity' -Skip {
        { 
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/servers/$($env.serverName)/restart"
            Restart-AzPostgreSqlServer -InputObject $ID
        } | Should -Not -Throw
    }
}
