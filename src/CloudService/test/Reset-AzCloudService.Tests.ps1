$envFile = 'env.json'
$env = Get-Content (Join-Path $PSScriptRoot $envFile) | ConvertFrom-Json

# Restart/Reimage/Rebuild are async operation and it is not possible to determine the state of role just after the operation.
# Hence in this test we only verify the execution of command is succesful.

Describe 'Reset-AzCloudService' {

  It 'Restart Cloud Service' {
    Reset-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -Restart
  }

  # TODO: Enable once PowerShell Team fixes the cmdlet

  # It 'Reimage Cloud Service' {
  #   Reset-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -Reimage
  # }

  # TODO: Enable this once Rebuild option is supported

  # It 'Rebuild Cloud Service' {
  #   Reset-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -Rebuild
  # }
}
