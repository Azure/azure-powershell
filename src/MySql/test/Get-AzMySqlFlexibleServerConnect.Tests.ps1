$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlFlexibleServerConnect.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlFlexibleServerConnect' {
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force   
    It 'Get' {
        {   
            Get-AzMySqlFlexibleServerConnect -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -AdministratorLoginPassword $password
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)"
            Get-AzMySqlFlexibleServerConnect -InputObject $ID -AdministratorLoginPassword $password
        } | Should -Not -Throw
    }

    It 'GetAndQuery' {
        {   
            Get-AzMySqlFlexibleServerConnect -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -AdministratorLoginPassword $password -Query "CREATE TABLE dbtest (col1 INT)"
        } | Should -Not -Throw
    }

    It 'GetViaIdentityAndQuery' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)"
            Get-AzMySqlFlexibleServerConnect -InputObject $ID -AdministratorLoginPassword $password -Query "CREATE TABLE dbtest2 (col1 INT)"
        } | Should -Not -Throw
    }
}
