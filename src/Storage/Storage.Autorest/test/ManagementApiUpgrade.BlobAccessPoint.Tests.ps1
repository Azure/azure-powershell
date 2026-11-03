if (($null -eq $TestName) -or ($TestName -contains 'ManagementApiUpgrade.BlobAccessPoint')) {
    . (Join-Path $PSScriptRoot 'loadEnv.ps1')
    $script:TestRecordingFile = Join-Path $PSScriptRoot 'ManagementApiUpgrade.BlobAccessPoint.Recording.json'
    $currentPath = $PSScriptRoot
    $mockingPath = $null
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Filter 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
        if (-not $mockingPath -and -not $currentPath) {
            throw 'Cannot find the Storage recording support module.'
        }
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ManagementApiUpgrade.BlobAccessPoint' -Tag 'Qumulo' {
    It 'Runs configuration and connection-test operations for Qumulo' {
        $fixture = (Get-StorageManagementFixture Sources).Qumulo
        if ($null -eq $fixture -or $fixture.Source.sourceType -ne 'Qumulo') {
            throw 'Configure a pre-provisioned Qumulo source in the recording fixtures.'
        }
        $account = Get-StorageManagementFixture BlobAccessPoint
        $scope = @{
            ResourceGroupName = $account.ResourceGroupName
            AccountName = $account.AccountName
            SubscriptionId = Get-StorageManagementFixture SubscriptionId
        }
        $name = 'point-qumulo-' + $account.AccountName
        $json = @{
            location = $account.Location
            properties = @{ source = $fixture.Source }
        } | ConvertTo-Json -Depth 100
        $resource = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.BlobAccessPointConfiguration]::FromJsonString($json)
        $accessKeyId = 'REDACTED-ACCESS-KEY-ID'
        $secret = 'REDACTED-SECRET'
        if ($TestMode -ne 'playback') {
            $accessKeyId = [Environment]::GetEnvironmentVariable($fixture.AccessKeyIdEnvironmentVariable)
            $secret = [Environment]::GetEnvironmentVariable($fixture.SecretAccessKeyEnvironmentVariable)
            if ([string]::IsNullOrWhiteSpace($accessKeyId) -or [string]::IsNullOrWhiteSpace($secret)) {
                throw 'Set the credential environment variables for the Qumulo recording fixture.'
            }
        }
        $resource.Source.Auth.AccessKeyId = $accessKeyId
        $secureSecret = [Security.SecureString]::new()
        foreach ($character in $secret.ToCharArray()) {
            $secureSecret.AppendChar($character)
        }
        $secureSecret.MakeReadOnly()
        $resource.Source.Auth.SecretAccessKey = $secureSecret
        $resource.ToString().Contains($secret) | Should -Be $false
        $resource.Source.ToString().Contains($secret) | Should -Be $false
        $resource.Source.Auth.ToString().Contains($secret) | Should -Be $false
        $created = $false
        try {
            $proposed = @{
                source = $fixture.Source
            } | ConvertTo-Json -Depth 100 | ConvertFrom-Json
            $proposed.source.auth | Add-Member -NotePropertyName accessKeyId -NotePropertyValue $accessKeyId -Force
            $proposed.source.auth | Add-Member -NotePropertyName secretAccessKey -NotePropertyValue $secret -Force
            $null = Test-AzStorageBlobAccessPointConnection @scope -JsonString ($proposed | ConvertTo-Json -Depth 100) -NoWait -ErrorAction Stop
            $configuration = New-AzStorageBlobAccessPointConfiguration @scope -Name $name -Resource $resource -ErrorAction Stop
            $created = $true
            $configuration.SourceType | Should -Be 'Qumulo'
            $configuration.UniqueId | Should -Not -BeNullOrEmpty
            $configuration = Get-AzStorageBlobAccessPointConfiguration @scope -Name $name -ErrorAction Stop
            $configuration.SourceType | Should -Be 'Qumulo'
            @(Get-AzStorageBlobAccessPointConfiguration @scope | Where-Object Name -EQ $name).Count | Should -Be 1
            $uniqueId = $configuration.UniqueId
            $configuration = Update-AzStorageBlobAccessPointConfiguration @scope -Name $name -Description updated -ErrorAction Stop
            $configuration.Description | Should -Be 'updated'
            $configuration.UniqueId | Should -Be $uniqueId
            $patch = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.BlobAccessPointConfigurationUpdate]::FromJsonString($json)
            $patch.Source.Auth.AccessKeyId = $accessKeyId
            $patch.Source.Auth.SecretAccessKey = $secureSecret
            $configuration = Update-AzStorageBlobAccessPointConfiguration @scope -Name $name -Property $patch -ErrorAction Stop
            $configuration.SourceType | Should -Be 'Qumulo'
            if ($fixture.Source.connection.endpoint) {
                $configuration.Source.Connection.Endpoint | Should -Be $fixture.Source.connection.endpoint
            }
            $connection = Test-AzStorageBlobAccessPointConfigurationConnection @scope `
                -BlobAccessPointConfigurationName $name -UniqueId $uniqueId -ErrorAction Stop
            $connection.MethodName | Should -Not -BeNullOrEmpty
            $connection.RequestId | Should -Not -BeNullOrEmpty
            $connection.ErrorMessage | Should -BeNullOrEmpty
        } finally {
            try {
                if ($created) {
                    Remove-AzStorageBlobAccessPointConfiguration @scope -Name $name -Confirm:$false -ErrorAction Stop
                }
            } finally {
                try {
                    Protect-StorageManagementRecording
                } finally {
                    $secureSecret.Dispose()
                }
            }
        }
        @(Get-AzStorageBlobAccessPointConfiguration @scope | Where-Object Name -EQ $name).Count | Should -Be 0
    }
}
