if(($null -eq $TestName) -or ($TestName -contains 'Get-AzKustoSandboxCustomImage'))
{
  $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
  . ($kustoCommonPath)
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoSandboxCustomImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzKustoSandboxCustomImage' {
    It 'List' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $subscriptionId = $env.subscriptionId
        $sandboxCustomImageName = "testimage"
        $languageVersion = "3.9.7"
        $requirementsFileContent = "Pillow"

        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -LanguageVersion $languageVersion -RequirementsFileContent $requirementsFileContent

        [array]$sandboxImages = Get-AzKustoSandboxCustomImage -ClusterName $clusterName -ResourceGroupName $resourceGroupName

        Validate_SandboxCustomImage $sandboxImages[0] $languageVersion $requirementsFileContent

        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
    }

    It 'Get' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $subscriptionId = $env.subscriptionId
        $sandboxCustomImageName = "testimage"
        $languageVersion = "3.9.7"
        $requirementsFileContent = "Pillow"

        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -LanguageVersion $languageVersion -RequirementsFileContent $requirementsFileContent

        $sandboxImage = Get-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName

        Validate_SandboxCustomImage $sandboxImage $languageVersion $requirementsFileContent
        
        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
    }

    It 'GetViaIdentity' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $subscriptionId = $env.subscriptionId
        $sandboxCustomImageName = "testimage"
        $languageVersion = "3.9.7"
        $requirementsFileContent = "Pillow"

        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -LanguageVersion $languageVersion -RequirementsFileContent $requirementsFileContent

        $sandboxImage = Get-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
        $sandboxImage = Get-AzKustoSandboxCustomImage -InputObject $sandboxImage

        Validate_SandboxCustomImage $sandboxImage $languageVersion $requirementsFileContent
        
        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
    }
}
