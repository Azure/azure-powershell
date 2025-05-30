if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDataTransferConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataTransferConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDataTransferConnection' {
    It 'Delete' {
        { 
            $connectionToRemove = "test-connection-" + -join ((65..90) + (97..122) | Get-Random -Count 6 | ForEach-Object {[char]$_})
            Write-Host "Connection name: $connectionToRemove"

            $connectionParams = @{
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Receive"
                FlowType             = "Mission"
                ResourceGroupName    = $env.ResourceGroupName
                Justification        = "Receive side for PS testing"
                RemoteSubscriptionId = $env.SubscriptionId
                RequirementId        = 0
                Name                 = $connectionToRemove
                PrimaryContact       = "faikh@microsoft.com"
            }
            $createdConnection = New-AzDataTransferConnection @connectionParams
            $createdConnection | Should -Not -BeNullOrEmpty

            Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToRemove -Confirm:$false | Should -BeNullOrEmpty

            # Ensure the connection is deleted
            $deletedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToRemove -ErrorAction SilentlyContinue
            $deletedConnection | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Delete and return result' {
        {
            $connectionToRemove = "test-connection-" + -join ((65..90) + (97..122) | Get-Random -Count 6 | ForEach-Object {[char]$_})
            Write-Host "Connection name: $connectionToRemove"

            $connectionParams = @{
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Receive"
                FlowType             = "Mission"
                ResourceGroupName    = $env.ResourceGroupName
                Justification        = "Receive side for PS testing"
                RemoteSubscriptionId = $env.SubscriptionId
                RequirementId        = 0
                Name                 = $connectionToRemove
                PrimaryContact       = "faikh@microsoft.com"
            }
            $createdConnection = New-AzDataTransferConnection @connectionParams
            $createdConnection | Should -Not -BeNullOrEmpty

            $result = Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToRemove -PassThru -Confirm:$false
            $result | Should -Be $true

            # Ensure the connection is deleted
            $deletedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToRemove -ErrorAction SilentlyContinue
            $deletedConnection | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Delete AsJob' {
        {
            # Create a new connection to remove
            $connectionToRemove = "test-connection-asjob-" + -join ((65..90) + (97..122) | Get-Random -Count 6 | ForEach-Object {[char]$_})
            Write-Host "Connection name: $connectionToRemove"
            
            $connectionParams = @{
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Receive"
                FlowType             = "Mission"
                ResourceGroupName    = $env.ResourceGroupName
                Justification        = "Receive side for PS testing"
                RemoteSubscriptionId = $env.SubscriptionId
                RequirementId        = 0
                Name                 = $connectionToRemove
                PrimaryContact       = "faikh@microsoft.com"
            }
    
            $createdConnection = New-AzDataTransferConnection @connectionParams
            $createdConnection | Should -Not -BeNullOrEmpty
    
            # Remove the connection as a background job
            $job = Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToRemove -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
    
            # Ensure the connection is deleted
            $deletedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToRemove -ErrorAction SilentlyContinue
            $deletedConnection | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
