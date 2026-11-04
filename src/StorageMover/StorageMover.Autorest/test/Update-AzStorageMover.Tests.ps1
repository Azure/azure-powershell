if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMover'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }

  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMover.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMover PythonParity' -Tag 'PythonParity' {
    It 'UpdateDescriptionAndAddReplaceRemoveTags' {
        $context = $null
        try {
            $context = New-StorageMoverTestContext -Name 'sm-tag-lifecycle'
            $parameters = @{ SubscriptionId = $context.SubscriptionId; ResourceGroupName = $context.ResourceGroupName; Name = $context.StorageMoverName; HttpPipelinePrepend = $context.HttpPipelinePrepend }
            $mover = Update-AzStorageMover @parameters -Description 'Updated description'
            $mover.Description | Should -Be 'Updated description'
            $mover = Update-AzStorageMover @parameters -Tag @{ tag1 = 'value1' }
            $mover.Tag['tag1'] | Should -Be 'value1'
            $mover = Update-AzStorageMover @parameters -Tag @{ tag2 = 'value2'; tag3 = 'value3' }
            $mover.Tag['tag2'] | Should -Be 'value2'
            $mover.Tag['tag3'] | Should -Be 'value3'
            @($mover.Tag.Keys) | Should -Not -Contain 'tag1'
            $mover = Update-AzStorageMover @parameters -Tag @{ tag3 = 'value3' }
            $mover.Tag['tag3'] | Should -Be 'value3'
            @($mover.Tag.Keys) | Should -Not -Contain 'tag2'
            $mover = Get-AzStorageMover @parameters
            $mover.Description | Should -Be 'Updated description'
            $mover.Tag['tag3'] | Should -Be 'value3'
            Remove-StorageMoverTestContext -Context $context
            $context = $null
            Invoke-StorageMoverTestFailure -Code ResourceNotFound -Command { Get-AzStorageMover @parameters -ErrorAction Stop }
        } finally {
            Remove-StorageMoverTestContext -Context $context
        }
    }
}

Describe 'Update-AzStorageMover' {
    It 'UpdateExpanded' {
        $storageMoverName = "testStorageMover" + "k3pmhtl9"
        $description = "test Storage mover description" 
        $updateDescription = "update storage mover description"
        $newStorageMover = New-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName -Location $env.Location -Description $description
        $newStorageMover.Name | Should -Be $storageMoverName
        $newStorageMover.Location | Should -Be $env.Location
        $newStorageMover.Description | Should -Be $description 

        $updatedStorageMover = Update-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName -Description $updateDescription
        $updatedStorageMover.Name | Should -Be $storageMoverName
        $updatedStorageMover.Location | Should -Be $env.Location
        $updatedStorageMover.Description | Should -Be $updateDescription

        $updatedStorageMover = Get-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName
        $updatedStorageMover.Name | Should -Be $storageMoverName
        $updatedStorageMover.Location | Should -Be $env.Location
        $updatedStorageMover.Description | Should -Be $updateDescription

    }
}
