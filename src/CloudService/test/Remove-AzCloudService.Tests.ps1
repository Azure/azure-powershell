$envFile = 'env.json'
$env = Get-Content (Join-Path $PSScriptRoot $envFile) | ConvertFrom-Json

Describe 'Remove-AzCloudService' {

  # TODO: Enable once cmdlet is fixed

  # It 'Remove Cloud Service multiple role instances' {
  #   $roles = @($env.RoleInstanceName1, $env.RoleInstanceName2)
  #   Remove-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstance $roles
  #   $cloudService = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName1 -ErrorAction SilentlyContinue
  #   $cloudService | Should be $NULL
  # }

  It 'Remove Cloud Service' {
    Remove-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
    $cloudService = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -ErrorAction SilentlyContinue
    $cloudService | Should be $NULL
  }
}
