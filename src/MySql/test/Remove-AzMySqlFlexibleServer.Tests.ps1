$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMySqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

# !Important: some test cases are skipped and require to be recorded again
# See https://github.com/Azure/autorest.powershell/issues/580
Describe 'Remove-AzMySqlFlexibleServer' {
    It 'Delete' {
        {
            if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force
                New-AzMySqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.serverName2 -AdministratorUserName mysql_test -AdministratorLoginPassword $password 
            }
            Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force
                New-AzMySqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.serverName2 -AdministratorUserName mysql_test -AdministratorLoginPassword $password 
            }
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.serverName2)"
            Remove-AzMySqlFlexibleServer -InputObject $ID
        } | Should -Not -Throw
    }
}
