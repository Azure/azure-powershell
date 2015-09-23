$AzureRMModules = (
  "Azure.Storage",
  "AzureRM.ApiManagement",
  "AzureRM.Automation",
  "AzureRM.Backup",
  "AzureRM.Batch",
  "AzureRM.Compute",
  "AzureRM.DataFactories",
  "AzureRM.Dns",
  "AzureRM.HDInsight",
  "AzureRM.Insights",
  "AzureRM.KeyVault",
  "AzureRM.Network",
  "AzureRM.OperationalInsights",
  "AzureRM.Profile",
  "AzureRM.RedisCache",
  "AzureRM.Resources",
  "AzureRM.SiteRecovery",
  "AzureRM.Sql",
  "AzureRM.Storage",
  "AzureRM.StreamAnalytics",
  "AzureRM.Tags",
  "AzureRM.TrafficManager",
  "AzureRM.UsageAggregates",
  "AzureRM.Websites"
)

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
  [Parameter(Position=0, Mandatory = $false)]
  [string]
  $Repository,

  [Parameter(Position=1, Mandatory = $false)]
  [ValidateSet("CurrentUser","AllUsers")]
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
    } -ArgumentList $_, $Repository, $Scope }
  
  $AzureRMModules | ForEach {Get-Job -Name $_ | Wait-Job | Receive-Job }
}
New-Alias -Name Install-AzureRM -Value Update-AzureRM
Export-ModuleMember -function * -Alias *