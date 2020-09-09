$envFile = 'env.json'
$env = Get-Content (Join-Path $PSScriptRoot $envFile) | ConvertFrom-Json

Describe 'Remove-AzCloudServiceRoleInstance' {

  # TODO: Enable this once delete of role instance is supported

  # It 'Remove Cloud Service RoleInstance' {
  #   Remove-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName
  #   $cloudServiceRoleInstance = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName -ErrorAction SilentlyContinue
  #   $cloudServiceRoleInstance | Should be ""
  # }
}
