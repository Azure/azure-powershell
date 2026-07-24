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
    # Skip: RP KB validation bug on bookshelf delete (ADO #2904045) - to be re-enabled once fix is confirmed stable
    It 'Delete' -Skip {
        Remove-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForNew -SubscriptionId $env.SubscriptionId -Confirm:$false
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
