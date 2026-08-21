if(($null -eq $TestName) -or ($TestName -contains 'New-AzDiscoveryBookshelfPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiscoveryBookshelfPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDiscoveryBookshelfPrivateEndpointConnection' {
    # Skip: PEC create/update/delete operations fail due to server-side RP bug (LRO returns status: "Failed").
    # Get-AzDiscoveryBookshelfPrivateEndpointConnection tests confirm the cmdlet works for read operations.
    It 'CreateExpanded' -Skip {
        $result = New-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForGet `
            -PrivateLinkServiceConnectionStateStatus 'Approved' `
            -PrivateLinkServiceConnectionStateDescription 'Approved via CreateExpanded' `
            -PrivateLinkServiceConnectionStateActionsRequired 'None' -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfPrivateEndpointConnectionNameForGet
    }

    It 'CreateViaJsonString' -Skip {
        $json = @{
            properties = @{
                privateLinkServiceConnectionState = @{
                    status = 'Approved'
                    description = 'Approved via ViaJsonString'
                    actionsRequired = 'None'
                }
            }
        } | ConvertTo-Json -Depth 10

        $result = New-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForGet `
            -JsonString $json -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfPrivateEndpointConnectionNameForGet
    }

    It 'CreateViaJsonFilePath' -Skip {
        $jsonPath = Join-Path $PSScriptRoot 'new-bspec-test.json'
        try {
            $json = @{
                properties = @{
                    privateLinkServiceConnectionState = @{
                        status = 'Approved'
                        description = 'Approved via ViaJsonFilePath'
                        actionsRequired = 'None'
                    }
                }
            } | ConvertTo-Json -Depth 10
            $json | Set-Content -Path $jsonPath

            $result = New-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
                -BookshelfName $env.BookshelfNameForGet `
                -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForGet `
                -JsonFilePath $jsonPath -Confirm:$false
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.BookshelfPrivateEndpointConnectionNameForGet
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'CreateViaIdentityBookshelfExpanded' -Skip {
        $bookshelf = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = New-AzDiscoveryBookshelfPrivateEndpointConnection `
            -BookshelfInputObject $bookshelf `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForGet `
            -PrivateLinkServiceConnectionStateStatus 'Approved' `
            -PrivateLinkServiceConnectionStateDescription 'Approved via parent identity' `
            -PrivateLinkServiceConnectionStateActionsRequired 'None' -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfPrivateEndpointConnectionNameForGet
    }
}
