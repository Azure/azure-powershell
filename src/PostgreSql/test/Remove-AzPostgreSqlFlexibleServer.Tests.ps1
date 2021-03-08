$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPostgreSqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzPostgreSqlFlexibleServer' {
    It 'Delete' {
        {
            If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force
                New-AzPostgreSqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.serverName2 -AdministratorUserName mysql_test -AdministratorLoginPassword $password 
            }
            Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.serverName2)"
            If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force
                New-AzPostgreSqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.serverName2 -AdministratorUserName mysql_test -AdministratorLoginPassword $password 
            }
            Remove-AzPostgreSqlFlexibleServer -InputObject $ID
        } | Should -Not -Throw
    }
}
