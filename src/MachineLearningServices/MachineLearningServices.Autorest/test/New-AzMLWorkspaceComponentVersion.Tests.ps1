if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceComponentVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceComponentVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceComponentVersion' {
    It 'CreateExpanded' {
      $codeid = (Get-AzMLWorkspaceCodeVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.codename -Version 1).Id
      $codestring = "azureml:$codeid"
      $envid = (Get-AzMLWorkspaceEnvironmentVersion  -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name commandjobenv1 -Version 1).Id
      $environmentstring = "azureml:$envid"
      $componentHash = @{
        "name"= "train_data_component";
        "version"= "1";
        "display_name"= "train_data";
        "is_deterministic"= "True";
        "type"= "command";
        "code"= $codestring;
        "environment"= $environmentstring;
        "command"= "python train.py"
      }
      New-AzMLWorkspaceComponentVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.componentName -Version 2 -ComponentSpec $componentHash
    }
}
