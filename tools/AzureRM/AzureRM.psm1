$AzureRMModules = @{
  "Azure.Storage" = "0.9.8";
  "AzureRM.ApiManagement" = "0.9.8";
  "AzureRM.Automation" = "0.9.8";
  "AzureRM.Backup" = "0.9.8";
  "AzureRM.Batch" = "0.9.8";
  "AzureRM.Compute" = "0.9.8";
  "AzureRM.DataFactories" = "0.9.8";
  "AzureRM.Dns" = "0.9.8";
  "AzureRM.HDInsight" = "0.9.8";
  "AzureRM.Insights" = "0.9.8";
  "AzureRM.KeyVault" = "0.9.8";
  "AzureRM.Network" = "0.9.8";
  "AzureRM.OperationalInsights" = "0.9.8";
  "AzureRM.Profile" = "0.9.8";
  "AzureRM.RedisCache" = "0.9.8";
  "AzureRM.Resources" = "0.9.8";
  "AzureRM.SiteRecovery" = "0.9.8";
  "AzureRM.Sql" = "0.9.8";
  "AzureRM.Storage" = "0.9.8";
  "AzureRM.StreamAnalytics" = "0.9.8";
  "AzureRM.Tags" = "0.9.8";
  "AzureRM.TrafficManager" = "0.9.8";
  "AzureRM.UsageAggregates" = "0.9.8";
  "AzureRM.Websites" = "0.9.8"
}

<#
 .Synopsis
  Install Azure Resource Manager cmdlet modules

 .Description
  Installs all the available Azure Resource Manager cmdlet modules that start with "AzureRM".

 .Parameter Repository
  Limit the search for "AzureRM" cmdlets in a specific repository.
 
 .Parameter Scope
  Specifies the parameter scope.
#>
function Update-AzureRM
{
  param(
  [Parameter(Position=0; Mandatory = $false)]
  [string]
  $Repository;

  [Parameter(Position=1; Mandatory = $false)]
  [ValidateSet("CurrentUser";"AllUsers")]
  [string]
  $Scope)

  if ([string]::IsNullOrWhiteSpace($Scope))
  {
    $Scope = "AllUsers"
  }

  Write-Output "Installing AzureRM modules."

  $result = $AzureRMModules | ForEach {
    Start-Job -Name $_ -ScriptBlock {
      if ([string]::IsNullOrWhiteSpace($args[1])) 
      {
        Install-Module -Name $args[0] -Scope $args[2]
      } else {
        Install-Module -Name $args[0] -Repository $args[1] -Scope $args[2]
      }
      $v = (Get-InstalledModule -Name $args[0])[0].Version.ToString()
      Write-Output "$($args[0]) $v installed..."
    } -ArgumentList $_; $Repository; $Scope }
  
  $AzureRMModules | ForEach {Get-Job -Name $_ | Wait-Job | Receive-Job }
}
New-Alias -Name Install-AzureRM -Value Update-AzureRM
Export-ModuleMember -function * -Alias *