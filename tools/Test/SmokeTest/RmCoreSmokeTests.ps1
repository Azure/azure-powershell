# $oldVerbose = $VerbosePreference
# $oldDebug = $DebugPreference
# $VerbosePreference = "Continue"
# $DebugPreference = "SilentlyContinue"
# $debugState = $false
[cmdletbinding()]
param(
    [Parameter()]
    [switch]
    $Reverse
)

if (Get-Module -ListAVailable 'Az.Accounts')
{
    Enable-AzureRmAlias
}

$testInfo = @{
    TotalCount = 0;
    PassedCount = 0;
    PassedTests = @();
    FailedTests = @();
    FailureDetails = @();
    Times = @()
}

# Generate random suffix ^\d[\da-z]{9}$
$strarray = "0123456789abcdefghijklmnopqurstuvxxyz"
$randomValue = $strarray[(Get-Random -Maximum 10)]
for($i=0; $i -lt 9; $i++) 
{
    $randomValue += $strarray[(Get-Random -Maximum $strarray.Length)]
}

# Retry azure powershell command.
function Retry-AzCommand {
    [CmdletBinding()]
    param (
        [string]
        $Name,

        [ScriptBlock]
        $Command,

        [int]
        $Retry,

        # Seconds between retries
        [int]
        $Sleep
    )
    $loopLimit = 0
    do {
        try {
            $script = "`$ErrorActionPreference='Stop' `n"
            $script += $Command.ToString()
            &([ScriptBlock]::Create($script))
            break
        }
        catch {
            $commandName = ($Command -split ' ')[0]
            if (++$loopLimit -gt $Retry)
            {
                throw "Failed to invoke script of $Name. $_"
            } else {
                Write-Warning "Retry $Name after $Sleep seconds"
                Start-Sleep -Seconds $Sleep
            }
        }
    } while ($true) 
}

# The name of resource group is 1~90 charactors complying with ^[-\w\._\(\)]+$
$resourceGroupName = "azpssmokerg$randomValue"
# The name of storage account should be 3~24 lowercase letters and numbers.
$storageAccountName = "azpssmokesa$randomValue"

$resourceSetUpCommands=@(
    @{Name = "Az.Resources";                  Command = {New-AzResourceGroup -Name $resourceGroupName -Location westus}; Retry=3; Sleep=30}
)

$resourceCleanUpCommands = @(
    @{Name = "Az.Storage [Cleanup]";          Command = {Remove-AzStorageAccount -Name $storageAccountName -ResourceGroupName $resourceGroupName -Force}; Retry=30; Sleep=30},
    @{Name = "Az.Resources [Cleanup]";        Command = {Remove-AzResourceGroup -Name $resourceGroupName -Force}; Retry=3; Sleep=30}
)

$resourceTestCommands = @(
    @{Name = "Az.Storage [Management]";       Command = {New-AzStorageAccount -Name $storageAccountName -SkuName Standard_LRS -Location westus -ResourceGroupName $resourceGroupName}; Retry=3; Sleep=30},
    @{Name = "Az.Storage [Data]";             Command = {New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey 12345678}; Retry=3; Sleep=30},
    @{Name = "Az.Storage [Data 1]";           Command = {Get-Command Get-AzStorageBlob}; Retry=3; Sleep=30},
    @{Name = "Az.Accounts";                   Command = {Get-AzDomain}; Retry=3; Sleep=30},
    @{Name = "Az.Accounts [DefaultProfile]";  Command = {Get-AzSubscription -DefaultProfile (Get-AzContext)}; Retry=3; Sleep=30},
    @{Name = "Az.Advisor";                    Command = {Get-AzAdvisorConfiguration}; Retry=3; Sleep=30},
    @{Name = "Az.Aks";                        Command = {Get-AzAksCluster}; Retry=3; Sleep=30},
    @{Name = "Az.AnalysisServices";           Command = {Get-AzAnalysisServicesServer}; Retry=3; Sleep=30},
    @{Name = "Az.ApiManagement";              Command = {Get-AzApiManagement}; Retry=3; Sleep=30},
    @{Name = "Az.ApplicationInsights";        Command = {Get-AzApplicationInsights}; Retry=3; Sleep=30},
    @{Name = "Az.Automation";                 Command = {Get-AzAutomationAccount}; Retry=3; Sleep=30},
    @{Name = "Az.Batch [MngmPlane]";          Command = {Get-AzBatchAccount}; Retry=3; Sleep=30},
    @{Name = "Az.Batch [DataPlane]";          Command = {Get-Command Get-AzBatchSupportedImage}; Retry=3; Sleep=30},
    @{Name = "Az.Billing";                    Command = {Get-AzBillingInvoice}; Retry=3; Sleep=30},
    @{Name = "Az.Billing [Consumption]";      Command = {Get-AzConsumptionBudget}; Retry=3; Sleep=30},
    @{Name = "Az.Cdn";                        Command = {Get-AzCdnProfile}; Retry=3; Sleep=30},
    @{Name = "Az.CognitiveServices";          Command = {Get-AzCognitiveServicesAccount}; Retry=3; Sleep=30},
    @{Name = "Az.Compute";                    Command = {Get-AzVM}; Retry=3; Sleep=30; Since="7.0.0"},
    @{Name = "Az.ContainerInstance";          Command = {Get-AzContainerGroup}; Retry=3; Sleep=30},
    @{Name = "Az.ContainerRegistry [MngmPlane]"; Command = {Get-AzContainerRegistry}; Retry=3; Sleep=30},
    @{Name = "Az.ContainerRegistry [DataPlane]"; Command = {Get-Command Get-AzContainerRegistryManifest}; Retry=3; Sleep=30},
    @{Name = "Az.DataBoxEdge";                Command = {Get-AzDataBoxEdgeDevice -ResourceGroupName $resourceGroupName}; Retry=3; Sleep=30},
    @{Name = "Az.Databricks";                 Command = {Get-AzDatabricksWorkspace -ResourceGroupName $resourceGroupName}; Retry=3; Sleep=30},
    @{Name = "Az.DataFactory [V1]";           Command = {Get-AzDataFactory -ResourceGroupName $resourceGroupName}; Retry=3; Sleep=30},
    @{Name = "Az.DataFactoryV2 [V2]";         Command = {Get-AzDataFactoryV2}; Retry=3; Sleep=30},
    @{Name = "Az.DataLakeAnalytics";          Command = {Get-AzDataLakeAnalyticsAccount}; Retry=3; Sleep=30},
    @{Name = "Az.DataLakeStore [MngmPlane]";  Command = {Get-AzDataLakeStoreAccount}; Retry=3; Sleep=30},
    @{Name = "Az.DataLakeStore [DataPlane]";  Command = {Get-Command New-AzDataLakeStoreItem}; Retry=3; Sleep=30},
    @{Name = "Az.DataShare";                  Command = {Get-AzDataShareAccount -ResourceGroupName $resourceGroupName}; Retry=3; Sleep=30},
    # Waiting for an issue fix: https://github.com/Azure/azure-powershell/issues/13522#issuecomment-728659457
    # @{Name = "Az.DeploymentManager";          Command = {try {Get-AzDeploymentManagerArtifactSource -ResourceGroupName $resourceGroupName }catch {if ($_.ToString() -notlike "*not found*") {throw $_}}}},
    @{Name = "Az.DesktopVirtualization";      Command = {Get-AzWvdApplicationGroup -ResourceGroupName $resourceGroupName}; Retry=3; Sleep=30},
    @{Name = "Az.Dns";                        Command = {Get-AzDnsZone}; Retry=3; Sleep=30},
    @{Name = "Az.EventGrid";                  Command = {Get-AzEventGridTopic}; Retry=3; Sleep=30},
    @{Name = "Az.EventHub";                   Command = {Get-AzEventHubNamespace}; Retry=3; Sleep=30},
    @{Name = "Az.FrontDoor";                  Command = {Get-AzFrontDoor}; Retry=3; Sleep=30},
    @{Name = "Az.Functions";                  Command = {Get-AzFunctionApp}; Retry=3; Sleep=30},
    @{Name = "Az.HDInsight ";                 Command = {Get-AzHDInsightCluster}; Retry=3; Sleep=30},
    @{Name = "Az.HealthcareApis";             Command = {Get-AzHealthcareApisService}; Retry=3; Sleep=30},
    @{Name = "Az.IotHub [MngmPlane]";         Command = {Get-AzIotHub}; Retry=3; Sleep=30},
    @{Name = "Az.IotHub [DataPlane]";         Command = {Get-Command Get-AzIotHubModuleConnectionString}; Retry=3; Sleep=30},
    @{Name = "Az.KeyVault [MngmPlane]";       Command = {Get-AzKeyVault}; Retry=3; Sleep=30},
    @{Name = "Az.KeyVault [DataPlane]";       Command = {Get-Command Get-AzKeyVaultKey}; Retry=3; Sleep=30},
    @{Name = "Az.Kusto";                      Command = {Get-AzKustoCluster}; Retry=3; Sleep=30},
    @{Name = "Az.LogicApp";                   Command = {Get-AzIntegrationAccount}; Retry=3; Sleep=30},
    @{Name = "Az.MachineLearning";            Command = {Get-AzMlWebService}; Retry=3; Sleep=30},
    @{Name = "Az.Maintenance";                Command = {Get-AzMaintenanceConfiguration}; Retry=30; Sleep=30},
    @{Name = "Az.ManagedServices";            Command = {Get-AzManagedServicesAssignment}; Retry=3; Sleep=30},
    @{Name = "Az.Media";                      Command = {Get-AzMediaService -ResourceGroupName $resourceGroupName}; Retry=3; Sleep=30},
    @{Name = "Az.Monitor";                    Command = {Get-AzLogProfile}; Retry=3; Sleep=30},
    @{Name = "Az.Network";                    Command = {Get-AzNetworkInterface}; Retry=3; Sleep=30},
    @{Name = "Az.NotificationHubs";           Command = {Get-AzNotificationHubsNamespace}; Retry=3; Sleep=30},
    @{Name = "Az.OperationalInsights [MngmPlane]"; Command = {Get-AzOperationalInsightsWorkspace}; Retry=3; Sleep=30},
    @{Name = "Az.OperationalInsights [DataPlane]"; Command = {Get-Command Invoke-AzOperationalInsightsQuery}; Retry=3; Sleep=30},
    @{Name = "Az.PolicyInsights";             Command = {Get-AzPolicyEvent -Top 10}; Retry=3; Sleep=30}, # without -Top service may return 400: ResponseTooLarge
    @{Name = "Az.PowerBIEmbedded";            Command = {Get-AzPowerBIEmbeddedCapacity}; Retry=3; Sleep=30},
    @{Name = "Az.PowerBIUEmbedded";           Command = {Get-AzPowerBIWorkspaceCollection}; Retry=3; Sleep=30},
    @{Name = "Az.PrivateDns";                 Command = {Get-AzPrivateDnsZone}; Retry=3; Sleep=30},
    @{Name = "Az.RecoveryServices";           Command = {Get-AzRecoveryServicesVault}; Retry=3; Sleep=30},
    @{Name = "Az.RedisCache";                 Command = {Get-AzRedisCache}; Retry=3; Sleep=30},
    @{Name = "Az.Relay";                      Command = {Get-AzRelayNamespace}; Retry=3; Sleep=30},
    @{Name = "Az.ServiceBus";                 Command = {Get-AzServiceBusNamespace}; Retry=3; Sleep=30},
    @{Name = "Az.ServiceFabric [MngmPlane]";  Command = {Get-AzServiceFabricCluster}; Retry=3; Sleep=30},
    @{Name = "Az.ServiceFabric [DataPlane]";  Command = {Get-Command New-AzServiceFabricCluster}; Retry=3; Sleep=30},
    @{Name = "Az.SignalR";                    Command = {Get-AzSignalR}; Retry=3; Sleep=30},
    @{Name = "Az.Sql";                        Command = {Get-AzSqlServer}; Retry=3; Sleep=30},
    @{Name = "Az.SqlVirtualMachine";          Command = {Get-AzSqlVM}; Retry=3; Sleep=30},
    @{Name = "Az.StreamAnalytics";            Command = {Get-AzStreamAnalyticsJob}; Retry=3; Sleep=30},
    @{Name = "Az.StorageSync";                Command = {Get-AzStorageSyncService}; Retry=3; Sleep=30},
    @{Name = "Az.Support";                    Command = {Get-AzSupportTicket}; Retry=3; Sleep=30},
    @{Name = "Az.Resources [Tags]";           Command = {Get-AzTag}; Retry=3; Sleep=30},
    @{Name = "Az.Resources [MSGraph]";        Command = {Get-AzAdGroup -First 1}; Retry=3; Sleep=30},
    @{Name = "Az.TrafficManager";             Command = {Get-AzTrafficManagerProfile}; Retry=3; Sleep=30},
    @{Name = "Az.Billing [UsageAggregates]";  Command = {Get-UsageAggregates -ReportedStartTime '1/1/2018' -ReportedEndTime '1/2/2018'}; Retry=3; Sleep=30},
    @{Name = "Az.Websites";                   Command = {Get-AzWebApp -ResourceGroupName $resourceGroupName}; Retry=3; Sleep=30}
)

if($Reverse.IsPresent){
    [array]::Reverse($resourceTestCommands)
}

$resourceCommands=$resourceSetUpCommands+$resourceTestCommands+$resourceCleanUpCommands

$startTime = Get-Date
$resourceCommands | ForEach-Object {
    $testName = $_.Name
    $script = $_.Command
    $retry = if($null -eq $_.retry) {0} Else {$_.retry}
    $sleep = if($null -eq $_.sleep) {30} Else {$_.sleep}
    if($null -ne $_.Since -and "Core" -eq $PSVersionTable.PSEdition -and $PSVersionTable.PSVersion -lt [System.Version]$_.Since) {
        Write-Output "Skip test $testName"
        $testInfo.SkippedCount += 1
        return
    }
    Write-Output "Running test $testName"
    $testStart = Get-Date
    try
    {
        Retry-AzCommand -Name $testName -Command $script -Retry $retry -Sleep $sleep
        $testInfo.PassedCount += 1
        $testInfo.PassedTests += $testName
    }
    catch
    {
        Write-Error $_.Exception
        $detail = Resolve-AzError -Last
        $testInfo.FailureDetails += (New-Object PSObject -Property @{Name = $testName; Details = $detail})
        $testInfo.FailedTests += $testName
    }
    finally
    {
        $testEnd = Get-Date
        $testElapsed = $testEnd - $testStart
        $testInfo.Times += (New-Object PSObject -Property @{TestName = $testName; ElapsedTime = $testElapsed})
        $testInfo.TotalCount += 1
    }
}
$endTime = Get-Date

@{
    Subscription = $context.Context.Subscription.Name;
    StartTime = $startTime;
    EndTime = $endTime;
    Elapsed = $endTime - $startTime;
    TotalTests = $testInfo.TotalCount;
    PassedTests = $testInfo.PassedTests;
    SkippedTests = $testInfo.SkippedCount;
    FailedTests = $testInfo.FailedTests
} | Write-Output

$testInfo.FailureDetails | ForEach-Object{
    $_ | Select-Object -Property Name | Write-Output
    $_.Details | Write-Output
}
$testInfo.Times | Format-Table

if ($testInfo.FailedTests.Count -gt 0)
{
    throw ("Test run failed with " + $testInfo.FailedTests.Count + " failures.")
}

# Resolve-AzError
# $DebugPreference = $oldDebug
# $VerbosePreference = $oldVerbose
