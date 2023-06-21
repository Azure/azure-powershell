if(($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzEventHub' {
    It 'SetExpanded'  {
        $eventhub = Set-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.eventHub2 -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer $env.blobContainer -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId $env.storageAccountId
        $eventhub.PartitionCount | Should -Be 5
        $eventhub.ArchiveNameFormat | Should -Be "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
        $eventhub.BlobContainer | Should -Be $env.blobContainer
        $eventhub.CaptureEnabled | Should -Be $true
        $eventhub.SkipEmptyArchive | Should -Be $true
        $eventhub.DestinationName | Should -Be "EventHubArchive.AzureBlockBlob"
        $eventhub.Encoding | Should -Be "Avro"
        $eventhub.IntervalInSeconds | Should -Be 600
        $eventhub.SizeLimitInBytes | Should -Be 11000000
        $eventhub.StorageAccountResourceId | Should -Be $eventhub.StorageAccountResourceId

        $eventhub = Set-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.eventHub3 -RetentionTimeInHour 90
        $eventhub.RetentionTimeInHour | Should -Be 90
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

    It 'SetViaIdentityExpanded'  {
        $eventhub = New-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name eventhub

        { Set-AzEventHub -InputObject $eventhub } | Should -Throw 'Please specify the property you want to update on the -InputObject'

        $eventhub = Set-AzEventHub -InputObject $eventhub -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer $env.blobContainer -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId $env.storageAccountId
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

        $eventhub = Set-AzEventHub -InputObject $eventhub.Id -CaptureEnabled:$false
        $eventhub.PartitionCount | Should -Be 4
        $eventhub.ArchiveNameFormat | Should -Be "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
        $eventhub.BlobContainer | Should -Be $env.blobContainer
        $eventhub.CaptureEnabled | Should -Be $false
        $eventhub.SkipEmptyArchive | Should -Be $true
        $eventhub.DestinationName | Should -Be "EventHubArchive.AzureBlockBlob"
        $eventhub.Encoding | Should -Be "Avro"
        $eventhub.IntervalInSeconds | Should -Be 600
        $eventhub.SizeLimitInBytes | Should -Be 11000000
        $eventhub.StorageAccountResourceId | Should -Be $eventhub.StorageAccountResourceId
    }
}
