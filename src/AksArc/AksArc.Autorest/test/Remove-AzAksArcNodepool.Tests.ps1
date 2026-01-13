if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAksArcNodepool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAksArcNodepool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Forced to skip for now since autorest doesn't support playback with Az commands in custom file.
Describe 'Remove-AzAksArcNodepool' -Tag 'LiveOnly' {
    BeforeAll {
        if (!$env.rmPool1 -or !$env.rmPool2) {
            Import-Module (Join-Path -Path $PSScriptRoot -ChildPath 'AzAksArcTestHelper.psm1')
            $uniqueNumbers = Get-RandomNumbers -Count 2
            # Nodepool names must be lowercase and have a maximum of 12 characters.
            Add-Member -InputObject $env -MemberType NoteProperty -Name "rmPool1" -Value "rmpool1$($uniqueNumbers[0])"
            Add-Member -InputObject $env -MemberType NoteProperty -Name "rmPool2" -Value "rmpool2$($uniqueNumbers[1])"
        }
        function Test-Remove {
            param ($NodePoolName)
            try {
                Get-AzAksArcNodepool `
                    -ClusterName $env.clusterName `
                    -ResourceGroupName $env.resourceGroupName `
                    -Name $NodePoolName
            } catch {
                $_.Exception.Message -like "*ResourceNotFound*" | Should -BeTrue
            }
        }
    }
    It 'Delete' {
        New-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.rmPool1
        Remove-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.rmPool1
        Test-Remove -NodePoolName $env.rmPool1
    }
    It 'DeleteViaIdentity' {
        $poolToDelete = New-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.rmPool2
        $poolToDelete | Remove-AzAksArcNodepool
        Test-Remove -NodePoolName $env.rmPool2
    }
}
