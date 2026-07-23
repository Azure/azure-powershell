if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDiscoveryBookshelf'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiscoveryBookshelf.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDiscoveryBookshelf' {
    It 'Delete' {
        # Verify bookshelf is fully provisioned before attempting delete
        $bs = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForNew -SubscriptionId $env.SubscriptionId
        $bs.ProvisioningState | Should -Be 'Succeeded'

        # Wait for internal KB sub-resources to settle (ADO #2904045 - KB validation error on delete)
        Start-TestSleep -Seconds 60

        # Attempt delete with one retry in case KB state is transiently invalid
        try {
            Remove-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
                -Name $env.BookshelfNameForNew -SubscriptionId $env.SubscriptionId -Confirm:$false
        } catch {
            Write-Host "First delete attempt failed: $_. Retrying after 30s..."
            Start-TestSleep -Seconds 30
            Remove-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
                -Name $env.BookshelfNameForNew -SubscriptionId $env.SubscriptionId -Confirm:$false
        }

        Start-TestSleep -Seconds 10
        { Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForNew -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentity' -Skip {
        $identity | Remove-AzDiscoveryBookshelf -Confirm:$false
        Start-TestSleep -Seconds 10
        { Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForNewJson -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }
}
