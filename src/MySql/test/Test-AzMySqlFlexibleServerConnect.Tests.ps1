$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzMySqlFlexibleServerConnect.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzMySqlFlexibleServerConnect' {
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force   

    if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
        Install-Module -Name SimplySQL -Scope CurrentUser -Force
        It 'Test' {
            {   
                Get-AzMySqlFlexibleServerConnect -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -AdministratorLoginPassword $password
            } | Should -Not -Throw
        }

        It 'TestViaIdentity' {
            {
                $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)"
                Get-AzMySqlFlexibleServerConnect -InputObject $ID -AdministratorLoginPassword $password
            } | Should -Not -Throw
        }

        It 'TestAndQuery' {
            {   
                Get-AzMySqlFlexibleServerConnect -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -AdministratorLoginPassword $password -Query "CREATE TABLE dbtest (col1 INT)"
            } | Should -Not -Throw
        }

        It 'TestViaIdentityAndQuery' {
            {
                $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)"
                Get-AzMySqlFlexibleServerConnect -InputObject $ID -AdministratorLoginPassword $password -Query "CREATE TABLE dbtest2 (col1 INT)"
            } | Should -Not -Throw
        }
    }
}
