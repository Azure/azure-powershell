$envFile = 'env.json'
$env = Get-Content (Join-Path $PSScriptRoot $envFile) | ConvertFrom-Json

Describe 'Update-AzCloudService' {

  # TODO: Extend Update-AzCloudService test case once cmdlet is fixed.

  # It 'Get followed by Update Cloud Service' {
  #   $cloudService = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
  #   $cloudService | Update-AzCloudService
  # }

}
