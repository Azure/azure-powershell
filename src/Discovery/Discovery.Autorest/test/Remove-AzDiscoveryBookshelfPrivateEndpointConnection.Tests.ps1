if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDiscoveryBookshelfPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiscoveryBookshelfPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDiscoveryBookshelfPrivateEndpointConnection' {
    It 'Delete' -Skip {
        # Skip: Server-side RP bug — PEC delete LRO returns status "Failed" (confirmed via direct API call).
        $maxRetries = 3
        for ($i = 1; $i -le $maxRetries; $i++) {
            try {
                Remove-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
                    -BookshelfName $env.BookshelfNameForGet `
                    -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForDel `
                    -SubscriptionId $env.SubscriptionId -Confirm:$false
                break
            } catch {
                if ($i -eq $maxRetries) { throw }
                Write-Host "PEC delete attempt $i failed, retrying in 30s..."
                Start-TestSleep -Seconds 30
            }
        }
        Start-TestSleep -Seconds 10
        { Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForDel `
            -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentityBookshelf' -Skip {
        # Skip: Server-side RP bug — PEC delete LRO returns status "Failed" (confirmed via direct API call).
        $bookshelf = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $maxRetries = 3
        for ($i = 1; $i -le $maxRetries; $i++) {
            try {
                Remove-AzDiscoveryBookshelfPrivateEndpointConnection -BookshelfInputObject $bookshelf `
                    -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForDelViaPar `
                    -Confirm:$false
                break
            } catch {
                if ($i -eq $maxRetries) { throw }
                Write-Host "PEC delete attempt $i failed, retrying in 30s..."
                Start-TestSleep -Seconds 30
            }
        }
        Start-TestSleep -Seconds 10
        { Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForDelViaPar `
            -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentity' -Skip {
        # Skip: Server-side RP bug — PEC delete LRO returns status "Failed" (confirmed via direct API call).
        $identity = Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForDelVia `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $maxRetries = 3
        for ($i = 1; $i -le $maxRetries; $i++) {
            try {
                $identity | Remove-AzDiscoveryBookshelfPrivateEndpointConnection -Confirm:$false
                break
            } catch {
                if ($i -eq $maxRetries) { throw }
                Write-Host "PEC delete attempt $i failed, retrying in 30s..."
                Start-TestSleep -Seconds 30
            }
        }
        Start-TestSleep -Seconds 10
        { Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForDelVia `
            -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }
}
