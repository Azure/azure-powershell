# Usage
# ./cmdletcount.ps1 -path ../src/

param([string]$path = './')

$moduleList = @('ADDomainServices', 'Aks/Aks.Autorest', 'AppConfiguration', 'BotService','ChangeAnalysis','CloudService','Communication','Confluent','ConnectedKubernetes','ConnectedMachine','ContainerInstance','CostManagement','CustomProviders', 'DataBox', 'Databricks','Datadog','DataProtection','DedicatedHsm','DesktopVirtualization','DigitalTwins','DiskPool','DnsResolver','Elastic','Functions','HanaOnAzure','HealthBot','ImageBuilder','ImportExport','KubernetesConfiguration','Kusto','Maps','MariaDb','Migrate','MonitoringSolutions','MySql','Portal','PostgreSql','ProviderHub','Purview','RedisEnterpriseCache','ResourceGraph/ResourceGraph.Autorest','ResourceMover','SpringCloud','StreamAnalytics','Synapse/Synapse.Autorest','TimeSeriesInsights','VMware','Websites/Websites.Autorest','WindowsIotServices')

$resultFile = './result.csv'

$result = @()

foreach ($module in $moduleList) {
    $modulePath = Join-Path (Join-Path $path $module) docs
    $customPath = Join-Path (Join-Path $path $module) custom
    $module = $module.Split('/')[0]
    $cmdlets = Get-ChildItem $modulePath -Exclude readme.md, "Az.$module.md", "$module.md" | foreach {$_.name.Split(".")[0]}
    foreach ($cmdlet in $cmdlets) {
        $isCustom = Get-ChildItem $customPath -Include "$cmdlet.ps1" -Recurse
        $genMode = "Autogen"
        if ($isCustom) {
            $genMode = "Custom"
        }
        $item = @{Module = "Az.$module"; Cmdlet = "$cmdlet"; GenMode = "$genMode"}
        $result += [pscustomobject]$item
    }
}

$result | ConvertTo-Csv | Out-File -Path $resultFile
