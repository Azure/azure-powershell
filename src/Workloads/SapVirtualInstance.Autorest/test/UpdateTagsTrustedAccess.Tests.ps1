if(($null -eq $TestName) -or ($TestName -contains 'UpdateTagsTrustedAccess'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'UpdateTagsTrustedAccess.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'UpdateTagsTrustedAccess' {
    It 'UpdateTagsDatabaseInstance' {
        $UpdateTags = @{ $env.TestType = $env.TestTypeValue}
        $UpdateTagsDatabaseInstanceResponse = Update-AzWorkloadsSapDatabaseInstance -SubscriptionId $env.WaaSSubscriptionId  -Name $env.SapDatabseInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Tag $UpdateTags
        $UpdateTagsDatabaseInstanceResponse.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'UpdateTagsCentralInstance' {
        $UpdateTags = @{ $env.TestType = $env.TestTypeValue}
        $UpdateTagsCentralInstanceResponse = Update-AzWorkloadsSapCentralInstance -SubscriptionId $env.WaaSSubscriptionId  -Name $env.SapCentralInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Tag $UpdateTags
        $UpdateTagsCentralInstanceResponse.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'UpdateTagsApplicationInstance' {
        $UpdateTags = @{ $env.TestType = $env.TestTypeValue}
        $UpdateTagsApplicationInstanceResponse = Update-AzWorkloadsSapApplicationInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.SapApplicationInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Tag $UpdateTags
        $UpdateTagsApplicationInstanceResponse.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'UpdateTagsSapVirtualInstance' {
        $UpdateTags = @{ $env.TestType = $env.TestTypeValue}
        $UpdateTagsSapVirtualInstanceResponse = Update-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId  -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -Tag $UpdateTags
        $UpdateTagsSapVirtualInstanceResponse.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'UpdateTrustedAccessToPublic' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $null = Update-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId  -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPub -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $UpdateTrustedAcessPublicResponse = Get-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.SapVirtualInstanceName
        $UpdateTrustedAcessPublicResponse.ManagedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPub
    }

    It 'UpdateTrustedAccessToPrivate' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $null = Update-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId  -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $UpdateTrustedAcessPrivateResponse = Get-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.SapVirtualInstanceName
        $UpdateTrustedAcessPrivateResponse.ManagedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPrvt
    }
}
