if(($null -eq $TestName) -or ($TestName -contains 'AzDellStorage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzDellStorage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDellStorage' {
    # Create filesystem resource for Get, List, and Remove tests
    It 'CreateExpanded' {
        {
            $dellObject = New-AzDellFileSystem -Name $env.dell1Name -ResourceGroupName $env.resourceGroup `
                -SubscriptionId $env.SubscriptionId `
                -DelegatedSubnetId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.vnetResourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.virtualNetworkName)/subnets/$($env.subnetName)" `
                -DelegatedSubnetCidr $env.delegatedSubnetCidr `
                -Location $env.region `
                -UserEmail $env.testerEmail `
                -DellReferenceNumber $env.dellReferenceNumber `
                -EncryptionType "Microsoft-managed keys (MMK)" `
                -MarketplaceOfferId $env.offerID `
                -MarketplacePlanId $env.planID `
                -MarketplacePublisherId $env.publisherID `
                -MarketplacePlanName $env.planName `
                -MarketplaceTermUnit $env.termUnit `
                -MarketplaceSubscriptionId "00000000-0000-0000-0000-000000000000" `
                -Tag @{"bypassPartner"="true"}
            $dellObject.Name | Should -Be $env.dell1Name
            $dellObject.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $result = Get-AzDellFileSystem -ResourceGroupName $env.resourceGroup -Name $env.dell1Name -SubscriptionId $env.SubscriptionId
            $result.Name | Should -Be $env.dell1Name
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $result = Get-AzDellFileSystem -SubscriptionId $env.SubscriptionId
            $result.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $result = Get-AzDellFileSystem -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId
            $result.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $fileSystem = Get-AzDellFileSystem -ResourceGroupName $env.resourceGroup -Name $env.dell1Name -SubscriptionId $env.SubscriptionId
            $result = Get-AzDellFileSystem -InputObject $fileSystem
            $result.Name | Should -Be $env.dell1Name
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzDellFileSystem -Name $env.dell1Name -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' {
        {
            $jsonPath = Join-Path $PSScriptRoot 'dell-filesystem.json'
            $dellObject = New-AzDellFileSystem -Name $env.dell2Name -ResourceGroupName $env.resourceGroup `
                -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonPath
            $dellObject.Name | Should -Be $env.dell2Name
            $dellObject.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' {
        {
            $jsonString = Get-Content (Join-Path $PSScriptRoot 'dell-filesystem.json') -Raw
            $dellObject = New-AzDellFileSystem -Name "$($env.dell2Name)-json" -ResourceGroupName $env.resourceGroup `
                -SubscriptionId $env.SubscriptionId `
                -JsonString $jsonString
            $dellObject.Name | Should -Be "$($env.dell2Name)-json"
            $dellObject.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            # Delete dell2Name via identity
            $fileSystem = Get-AzDellFileSystem -ResourceGroupName $env.resourceGroup -Name $env.dell2Name -SubscriptionId $env.SubscriptionId
            Remove-AzDellFileSystem -InputObject $fileSystem

            # Delete dell2Name-json via identity
            $fileSystem2 = Get-AzDellFileSystem -ResourceGroupName $env.resourceGroup -Name "$($env.dell2Name)-json" -SubscriptionId $env.SubscriptionId
            Remove-AzDellFileSystem -InputObject $fileSystem2
        } | Should -Not -Throw
    }
}
