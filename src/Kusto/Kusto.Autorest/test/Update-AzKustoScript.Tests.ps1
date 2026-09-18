Describe 'Update-AzKustoScript' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoScript.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Update'{
        $continueOnErrors = $false
        $clusterName = $env.kustoClusterName
        $databaseName = "testdatabase" + $env.rstr4
        $scriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)"
        $scriptName = "testScript2"
        New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location
        New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $scriptName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ContinueOnError -ForceUpdateTag "tag1" -ScriptContent $scriptContent -PrincipalPermissionsAction "RetainPermissionOnScriptCompletion" -ScriptLevel "Database"  # this must be set to 'Retain'

        # Upload script to blob storage for Update (Update-AzKustoScript requires scriptUrl)
        $storageAccountName = $env.storageAccountName
        $containerName = "scripts"
        $blobName = "update-script.kql"
        if ($TestMode -ne 'playback') {
            $storageAccount = Get-AzStorageAccount -ResourceGroupName $env.resourceGroupName -Name $storageAccountName
            $ctx = $storageAccount.Context
            New-AzStorageContainer -Name $containerName -Context $ctx -Permission Off -ErrorAction SilentlyContinue
            $scriptContent | Out-File -FilePath (Join-Path $env:TEMP $blobName) -Encoding utf8 -Force
            Set-AzStorageBlobContent -File (Join-Path $env:TEMP $blobName) -Container $containerName -Blob $blobName -Context $ctx -Force
            $sasToken = New-AzStorageBlobSASToken -Container $containerName -Blob $blobName -Context $ctx -Permission r -ExpiryTime (Get-Date).AddHours(1)
        } else {
            $sasToken = "?sv=faketoken"
        }
        $scriptUrl = "https://$storageAccountName.blob.core.windows.net/$containerName/$blobName"

        $jsonBody = @{
            properties = @{
                scriptUrl = $scriptUrl
                scriptUrlSasToken = $sasToken
                forceUpdateTag = "tag2"
                continueOnErrors = $true
                scriptLevel = "Database"
                principalPermissionsAction = "RemovePermissionOnScriptCompletion"
            }
        } | ConvertTo-Json -Depth 3 -Compress

        $Script = Update-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $scriptName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -JsonString $jsonBody

        Validate_Inline_Script $Script "tag2" $continueOnErrors $clusterName $databaseName $scriptName -PrincipalPermissionsAction "RemovePermissionOnScriptCompletion" -ScriptLevel "Database"

        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $databaseName } | Should -Not -Throw
    }
}
