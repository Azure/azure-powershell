$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzPostgreSqlFlexibleServerConnect.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzPostgreSqlFlexibleServerConnect' {
     #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
     $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force   

     If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
         Install-Module -Name SimplySQL -Scope CurrentUser -Force
         It 'Test' {
             {   
                 Get-AzPostgreSqlFlexibleServerConnect -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -AdministratorLoginPassword $password
             } | Should -Not -Throw
         }
 
         It 'TestViaIdentity' {
             {
                 $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)"
                 Get-AzPostgreSqlFlexibleServerConnect -InputObject $ID -AdministratorLoginPassword $password
             } | Should -Not -Throw
         }
 
         It 'TestAndQuery' {
             {   
                 Get-AzPostgreSqlFlexibleServerConnect -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -AdministratorLoginPassword $password -Query "CREATE TABLE dbtest (col1 INT)"
             } | Should -Not -Throw
         }
 
         It 'TestViaIdentityAndQuery' {
             {
                 $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)"
                 Get-AzPostgreSqlFlexibleServerConnect -InputObject $ID -AdministratorLoginPassword $password -Query "CREATE TABLE dbtest2 (col1 INT)"
             } | Should -Not -Throw
         }
     }
}
