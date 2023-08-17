if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEventHub' {
    It 'CreateExpanded' {
        #create Premium Namespace
        $eventHubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV1 -SkuName Premium -Location eastus
        #create EventHub with Compact CleanUpPolicy
        $eventhub = New-AzEventHub -Name $env.eventHub2 -ResourceGroupName $env.resourceGroup -NamespaceName $eventHubNamespace.Name -PartitionCount 2 -CleanupPolicy Compact
        $eventhub.Name | Should -Be $env.eventHub2
        $eventhub.ResourceGroupName | Should -Be $env.resourceGroup
        $eventhub.PartitionCount | Should -Be 2
        $eventhub.CleanupPolicy | Should -Be "Compact"

        #create EventHub with Delete CleanUpPolicy
        $eventhub = New-AzEventHub -Name $env.eventHub9 -ResourceGroupName $env.resourceGroup -NamespaceName $eventHubNamespace.Name -PartitionCount 2 -CleanupPolicy Delete
        $eventhub.Name | Should -Be $env.eventHub9
        $eventhub.ResourceGroupName | Should -Be $env.resourceGroup
        $eventhub.PartitionCount | Should -Be 2
        $eventhub.CleanupPolicy | Should -Be "Delete"

        # Create EventHub without capture
        $eventhub = New-AzEventHub -Name $env.eventHub2 -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -PartitionCount 5
        $eventhub.Name | Should -Be $env.eventHub2
        $eventhub.ResourceGroupName | Should -Be $env.resourceGroup
        $eventhub.PartitionCount | Should -Be 5

        # Create EventHub with capture enabled 
        $eventhub = New-AzEventHub -Name $env.eventHub3 -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer $env.blobContainer -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId $env.storageAccountId
        $eventhub.Name | Should -Be $env.eventHub3
        $eventhub.ResourceGroupName | Should -Be $env.resourceGroup
        $eventhub.PartitionCount | Should -Be 4
        $eventhub.ArchiveNameFormat | Should -Be "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
        $eventhub.BlobContainer | Should -Be $env.blobContainer
        $eventhub.CaptureEnabled | Should -Be $true
        $eventhub.SkipEmptyArchive | Should -Be $true
        $eventhub.DestinationName | Should -Be "EventHubArchive.AzureBlockBlob"
        $eventhub.Encoding | Should -Be "Avro"
        $eventhub.IntervalInSeconds | Should -Be 600
        $eventhub.SizeLimitInBytes | Should -Be 11000000
        $eventhub.StorageAccountResourceId | Should -Be $eventhub.StorageAccountResourceId
    }
}
