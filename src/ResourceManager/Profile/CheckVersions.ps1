$AzureRMModules = @(
  "AzureRM.ApiManagement";
  "AzureRM.Automation";
  "AzureRM.Backup";
  "AzureRM.Batch";
  "AzureRM.Compute";
  "AzureRM.DataFactories";
  "AzureRM.Dns";
  "AzureRM.HDInsight";
  "AzureRM.Intune";
  "AzureRM.KeyVault";
  "AzureRM.Network";
  "AzureRM.OperationalInsights";
  "AzureRM.RedisCache";
  "AzureRM.Resources";
  "AzureRM.SiteRecovery";
  "AzureRM.Sql";
  "AzureRM.Storage";
  "AzureRM.StreamAnalytics";
  "AzureRM.Tags";
  "AzureRM.TrafficManager";
  "AzureRM.UsageAggregates";
  "AzureRM.Websites"
)

$global:AvailableModules = @()

function CheckVersions {
    $profile = GetModuleInfo("AzureRM.Profile")
    if (-not $profile)
    {
        exit 0
    }
    ForEach ($moduleName in $AzureRMModules) {
        $module = GetModuleInfo($moduleName)
        if ($module)
        {
            $module.RequiredModules | Where-Object {$_.Name -eq "AzureRM.Profile"} | ForEach {
                if ($profile.Version.Major -ne $_.Version.Major) {
                    Write-Warning("$moduleName $($module.Version) is not compatible with $profile $($profile.Version)!")
                }
            }
        }
    }
}

function GetModuleInfo {
    param(
	[Parameter(Position=0)]
	[string]
	$ModuleName)

    if ($global:AvailableModules.Length -eq 0)
    {
        $global:AvailableModules = Get-Module -ListAvailable
    }

    return $global:AvailableModules `
        | Where-Object { $_.Name -eq $ModuleName} `
        | Select-Object -first 1
}

CheckVersions
