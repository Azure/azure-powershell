if(($null -eq $TestName) -or ($TestName -contains 'New-AzDiscoveryBookshelf'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiscoveryBookshelf.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDiscoveryBookshelf' {
    It 'CreateExpanded' {
        New-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForNew -Location $env.location `
            -PrivateEndpointSubnetId $env.NewBsPepSubnetId `
            -SearchSubnetId $env.NewBsSearchSubnetId `
            -WorkloadIdentity @{$env.UamiSwcId = @{}} `
            -Tag @{'test' = 'powershell'; 'SkipAssociateKeyVaultToNsp' = 'True'} -Confirm:$false | Out-Null

        $result = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForNew -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfNameForNew
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonFilePath' -Skip {
        $jsonPath = Join-Path $PSScriptRoot 'new-bookshelf-test.json'
        try {
            $json = @{
                location = $env.location
                properties = @{
                    privateEndpointSubnetId = $env.NewBsPepSubnetId
                    searchSubnetId = $env.NewBsSearchSubnetId
                    workloadIdentities = @{ $env.UamiSwcId = @{} }
                }
                tags = @{ test = 'powershell-jsonfile'; SkipAssociateKeyVaultToNsp = 'True' }
            } | ConvertTo-Json -Depth 10
            $json | Set-Content -Path $jsonPath

            $result = New-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
                -Name $env.BookshelfNameForNewJsonFile -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonPath -Confirm:$false
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.BookshelfNameForNewJsonFile
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'CreateViaJsonString' -Skip {
        $json = @{
            location = $env.location
            properties = @{
                privateEndpointSubnetId = $env.NewBsPepSubnetId
                searchSubnetId = $env.NewBsSearchSubnetId
                workloadIdentities = @{ $env.UamiSwcId = @{} }
            }
            tags = @{ test = 'powershell-json'; SkipAssociateKeyVaultToNsp = 'True' }
        } | ConvertTo-Json -Depth 10

        $result = New-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForNewJson -SubscriptionId $env.SubscriptionId `
            -JsonString $json -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfNameForNewJson
    }
}
