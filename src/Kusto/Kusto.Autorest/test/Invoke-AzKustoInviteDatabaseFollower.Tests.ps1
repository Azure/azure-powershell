if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzKustoInviteDatabaseFollower'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzKustoInviteDatabaseFollower.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzKustoInviteDatabaseFollower' {
    It 'InviteExpanded' {
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $resourceGroupName = $env.resourceGroupName
        $inviteeEmail = "user@contoso.com"

        Invoke-AzKustoInviteDatabaseFollower -ClusterName $clusterName -DatabaseName $databaseName -ResourceGroupName $resourceGroupName -InviteeEmail $inviteeEmail
    }

    It 'Invite' {
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $resourceGroupName = $env.resourceGroupName
        $inviteeEmail = "user@contoso.com"
        $databaseInviteFollowerRequest = @{ InviteeEmail = $inviteeEmail }

        Invoke-AzKustoInviteDatabaseFollower -ClusterName $clusterName -DatabaseName $databaseName -ResourceGroupName $resourceGroupName -Parameter $databaseInviteFollowerRequest
    }

    It 'InviteViaIdentityExpanded' {
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $resourceGroupName = $env.resourceGroupName
        $inviteeEmail = "user@contoso.com"

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName

        Invoke-AzKustoInviteDatabaseFollower -InputObject $database -InviteeEmail $inviteeEmail
    }

    It 'InviteViaIdentity'{
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $resourceGroupName = $env.resourceGroupName
        $inviteeEmail = "user@contoso.com"
        $databaseInviteFollowerRequest = @{ InviteeEmail = $inviteeEmail }

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName

        Invoke-AzKustoInviteDatabaseFollower -InputObject $database -Parameter $databaseInviteFollowerRequest
    }
}
