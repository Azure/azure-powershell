if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDisconnectedOperationsDisconnectedOperation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDisconnectedOperationsDisconnectedOperation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDisconnectedOperationsDisconnectedOperation' {
    It 'Delete' {

        #Create the Resource
        New-AzDisconnectedOperationsDisconnectedOperation -Name $env.NewResource -ResourceGroupName $env.ResourceGroupName -Location $env.Location -ConnectionIntent 'Disconnected' -Tag @{}

        #Delete the Resource using Name and ResourceGroupName
        Remove-AzDisconnectedOperationsDisconnectedOperation -Name $env.NewResource -ResourceGroupName $env.ResourceGroupName

        # Verify the Resource is deleted by trying to get it using the ResourceName and ResourceGroupName (should throw)
        { Get-AzDisconnectedOperationsDisconnectedOperation -Name $env.NewResource -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop} | Should -Throw

    }

    It 'DeleteViaIdentity' {
        #Create the Resource
        New-AzDisconnectedOperationsDisconnectedOperation -Name $env.NewResource -ResourceGroupName $env.ResourceGroupName -Location $env.Location -ConnectionIntent 'Disconnected' -Tag @{} -SubscriptionId $env.SubscriptionId

        $disconnectedOperationIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.ResourceGroupName
            Name = $env.NewResource
        }

        #Delete the Resource using DisconnectedOperation Identity
        Remove-AzDisconnectedOperationsDisconnectedOperation -InputObject $disconnectedOperationIdentity

        # Verify the Resource is deleted by trying to get it using the ResourceName and ResourceGroupName (should throw)
        { Get-AzDisconnectedOperationsDisconnectedOperation -Name $env.NewResource -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -ErrorAction Stop} | Should -Throw
    }
}
