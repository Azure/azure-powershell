$envFile = 'env.json'
$env = Get-Content (Join-Path $PSScriptRoot $envFile) | ConvertFrom-Json

Describe 'Get-AzCloudServiceRoleInstance' {

  It 'Get Cloud Service Role Instance for all instances' {
    $cloudServiceRoleInstance = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
    $cloudServiceRoleInstance.Count | Should Be $env.TotalRoleInstanceCount
  }
  
  It 'Get Cloud Service Role Instance for given instance' {
    $cloudServiceRoleInstance = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName
    $cloudServiceRoleInstance.Name | Should Be $env.RoleInstanceName
  }

  It 'Get Cloud Service Role Instance InstanceView for given instance' {
    $cloudServiceRoleInstanceInstanceView = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName -InstanceView
    $cloudServiceRoleInstanceInstanceView.Statuses.Count | Should Be 2
  }
}
