$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPostgreSqlServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzPostgreSqlServer' {
    It 'Delete' {
        { 
            #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
            New-AzPostgreSqlServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Location $env.location -AdministratorUserName pwsh -AdministratorLoginPassword $password -Sku $env.Sku
            Remove-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2 
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -Skip {
        {
            #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
            New-AzPostgreSqlServer -Name postgresqldelete -ResourceGroupName $env.resourceGroup -Location $env.location -AdministratorUserName pwsh -AdministratorLoginPassword $password -Sku $env.Sku
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/servers/postgresqldelete"
            Remove-AzPostgreSqlServer -InputObject $ID
        } | Should -Not -Throw
    }
}
