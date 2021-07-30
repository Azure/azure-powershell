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
        $Command,

        [int]
        $RetryCount,

        # Seconds between retries
        [int]
        $Sleep
    )
    $loopLimit = 0
    do {
        try {
            &([scriptblock]::Create($Command))
            break
        }
        catch {
            $commandName = ($Command -split ' ')[0]
            if (++$loopLimit -gt $RetryCount)
            {
                throw "Failed to invoke $commandName. $_"
            } else {
                Write-Warning "Retry $commandName after $Sleep seconds"
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
    @{Name = "Az.Resources";                  Command = {New-AzResourceGroup -Name $resourceGroupName -Location westus -ErrorAction Stop}}
)

$resourceCleanUpCommands = @(
    @{Name = "Az.Storage [Cleanup]";          Command = {Retry-AzCommand -Command "Remove-AzStorageAccount -Name $storageAccountName -ResourceGroupName $resourceGroupName -Force -ErrorAction Stop" -RetryCount 30 -Sleep 30}},
    @{Name = "Az.Resources [Cleanup]";        Command = {Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction Stop}}
)

$resourceTestCommands = @(
    @{Name = "Az.Storage [Management]";       Command = {New-AzStorageAccount -Name $storageAccountName -SkuName Standard_LRS -Location westus -ResourceGroupName $resourceGroupName -ErrorAction Stop}},
    @{Name = "Az.Storage [Data]";             Command = {New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey 12345678 -ErrorAction Stop}},
    @{Name = "Az.Accounts";                   Command = {Get-AzDomain -ErrorAction Stop}},
    @{Name = "Az.Accounts [DefaultProfile]";  Command = {Get-AzSubscription -DefaultProfile (Get-AzContext)}},
    @{Name = "Az.Advisor";                    Command = {Get-AzAdvisorConfiguration -ErrorAction Stop}},
    @{Name = "Az.Aks";                        Command = {Get-AzAksCluster -ErrorAction Stop}},
    @{Name = "Az.AnalysisServices";           Command = {Get-AzAnalysisServicesServer -ErrorAction Stop}},
    @{Name = "Az.ApiManagement";              Command = {Get-AzApiManagement -ErrorAction Stop}},
    @{Name = "Az.ApplicationInsights";        Command = {Get-AzApplicationInsights -ErrorAction Stop}},
    @{Name = "Az.Automation";                 Command = {Get-AzAutomationAccount -ErrorAction Stop}},
    @{Name = "Az.Batch";                      Command = {Get-AzBatchAccount -ErrorAction Stop}},
    @{Name = "Az.Billing";                    Command = {Get-AzBillingInvoice -ErrorAction Stop}},
    @{Name = "Az.Billing [Consumption]";      Command = {try {Get-AzConsumptionUsageDetail -ErrorAction Stop} catch {if ($_.ToString() -notlike "*422*" -and $_.ToString() -notlike "*UnprocessableEntity*" -and $_.ToString() -notlike "*BadRequest*") {throw $_}}}},
    @{Name = "Az.Cdn";                        Command = {Get-AzCdnProfile -ErrorAction Stop}},
    @{Name = "Az.CognitiveServices";          Command = {Get-AzCognitiveServicesAccount -ErrorAction Stop}},
    @{Name = "Az.Compute";                    Command = {Get-AzVM -ErrorAction Stop}},
    @{Name = "Az.ContainerInstance";          Command = {Get-AzContainerGroup -ErrorAction Stop}},
    @{Name = "Az.ContainerRegistry";          Command = {Get-AzContainerRegistry -ErrorAction Stop}},
    @{Name = "Az.DataBoxEdge";                Command = {Get-AzDataBoxEdgeDevice -ResourceGroupName $resourceGroupName -ErrorAction Stop}},
    @{Name = "Az.Databricks";                 Command = {Get-AzDatabricksWorkspace -ResourceGroupName $resourceGroupName -ErrorAction Stop}},
    @{Name = "Az.DataFactory [V1]";           Command = {Get-AzDataFactory -ResourceGroupName $resourceGroupName -ErrorAction Stop}},
    @{Name = "Az.DataFactoryV2 [V2]";         Command = {Get-AzDataFactoryV2 -ErrorAction Stop}},
    @{Name = "Az.DataLakeAnalytics";          Command = {Get-AzDataLakeAnalyticsAccount -ErrorAction Stop}},
    @{Name = "Az.DataLakeStore";              Command = {Get-AzDataLakeStoreAccount -ErrorAction Stop}},
    @{Name = "Az.DataShare";                  Command = {Get-AzDataShareAccount -ResourceGroupName $resourceGroupName -ErrorAction Stop}},
    # Waiting for an issue fix: https://github.com/Azure/azure-powershell/issues/13522#issuecomment-728659457
    # @{Name = "Az.DeploymentManager";          Command = {try {Get-AzDeploymentManagerArtifactSource -ResourceGroupName $resourceGroupName  -ErrorAction Stop}catch {if ($_.ToString() -notlike "*not found*") {throw $_}}}},
    @{Name = "Az.DesktopVirtualization";      Command = {Get-AzWvdApplicationGroup -ResourceGroupName $resourceGroupName -ErrorAction Stop}},
    @{Name = "Az.DevTestLabs ";               Command = {try {Get-AzDtlAllowedVMSizesPolicy -LabName nonexistent -ResourceGroupName nonexistent -ErrorAction Stop} catch {if ($_.ToString() -notlike "*'nonexistent' could not be found.") {throw $_}}}},
    @{Name = "Az.Dns";                        Command = {Get-AzDnsZone -ErrorAction Stop}},
    @{Name = "Az.EventGrid";                  Command = {Get-AzEventGridTopic -ErrorAction Stop}},
    @{Name = "Az.EventHub";                   Command = {Get-AzEventHubNamespace -ErrorAction Stop}},
    @{Name = "Az.FrontDoor";                  Command = {Get-AzFrontDoor -ErrorAction Stop}},
    @{Name = "Az.Functions";                  Command = {Get-AzFunctionApp -ErrorAction Stop}},
    @{Name = "Az.HDInsight ";                 Command = {Get-AzHDInsightCluster -ErrorAction Stop}},
    @{Name = "Az.HealthcareApis";             Command = {Get-AzHealthcareApisService -ErrorAction Stop}},
    @{Name = "Az.IotHub";                     Command = {Get-AzIotHub -ErrorAction Stop}},
    @{Name = "Az.KeyVault";                   Command = {Get-AzKeyVault -ErrorAction Stop}},
    @{Name = "Az.Kusto";                      Command = {Get-AzKustoCluster -ErrorAction Stop}},
    @{Name = "Az.LogicApp";                   Command = {Get-AzIntegrationAccount -ErrorAction Stop}},
    @{Name = "Az.MachineLearning";            Command = {Get-AzMlWebService -ErrorAction Stop}},
    @{Name = "Az.Maintenance";                Command = {Retry-AzCommand -Command "Get-AzMaintenanceConfiguration -ErrorAction Stop" -RetryCount 30 -Sleep 30}},
    @{Name = "Az.ManagedServices";            Command = {Get-AzManagedServicesAssignment -ErrorAction Stop}},
    # Machine learning compute cmdlets are removed. The following line are to be commented until they are brought back
    # @{Name = "Az.MachineLearning [Compute]";  Command = {Get-AzMlOpCluster -ErrorAction Stop}},
    @{Name = "Az.MarketplaceOrdering";        Command = {try {Get-AzMarketplaceTerms -Publisher nonexistent -Product nonexistent -Name nonexistent -ErrorAction Stop} catch {if ($_.ToString() -notlike "*not found*") {throw $_}}}},
    @{Name = "Az.Media";                      Command = {Get-AzMediaService -ResourceGroupName $resourceGroupName -ErrorAction Stop}},
    @{Name = "Az.Monitor";                    Command = {Get-AzLogProfile -ErrorAction Stop}},
    @{Name = "Az.Network";                    Command = {Get-AzNetworkInterface -ErrorAction Stop}},
    @{Name = "Az.NotificationHubs";           Command = {Get-AzNotificationHubsNamespace -ErrorAction Stop}},
    @{Name = "Az.OperationalInsights";        Command = {Get-AzOperationalInsightsWorkspace -ErrorAction Stop}},
    @{Name = "Az.PolicyInsights";             Command = {Get-AzPolicyEvent -Top 10 -ErrorAction Stop}}, # without -Top service may return 400: ResponseTooLarge
    @{Name = "Az.PowerBIEmbedded";            Command = {Get-AzPowerBIEmbeddedCapacity -ErrorAction Stop}},
    @{Name = "Az.PowerBIUEmbedded";           Command = {Get-AzPowerBIWorkspaceCollection -ErrorAction Stop}},
    @{Name = "Az.PrivateDns";                 Command = {Get-AzPrivateDnsZone -ErrorAction Stop}},
    @{Name = "Az.RecoveryServices";           Command = {Get-AzRecoveryServicesVault -ErrorAction Stop}},
    @{Name = "Az.RedisCache";                 Command = {Get-AzRedisCache -ErrorAction Stop}},
    @{Name = "Az.Relay";                      Command = {Get-AzRelayNamespace -ErrorAction Stop}},
    @{Name = "Az.ServiceBus";                 Command = {Get-AzServiceBusNamespace -ErrorAction Stop}},
    @{Name = "Az.ServiceFabric";              Command = {Get-AzServiceFabricCluster -ErrorAction Stop}},
    @{Name = "Az.SignalR";                    Command = {Get-AzSignalR -ErrorAction Stop}},
    @{Name = "Az.Sql";                        Command = {Get-AzSqlServer -ErrorAction Stop}},
    @{Name = "Az.SqlVirtualMachine";          Command = {Get-AzSqlVM -ErrorAction Stop}},
    @{Name = "Az.StreamAnalytics";            Command = {Get-AzStreamAnalyticsJob -ErrorAction Stop}},
    @{Name = "Az.StorageSync";                Command = {Get-AzStorageSyncService -ErrorAction Stop}},
    @{Name = "Az.Support";                    Command = {Get-AzSupportTicket -ErrorAction Stop}},
    @{Name = "Az.Resources [Tags]";           Command = {Get-AzTag -ErrorAction Stop}},
    @{Name = "Az.TrafficManager";             Command = {Get-AzTrafficManagerProfile -ErrorAction Stop}},
    @{Name = "Az.Billing [UsageAggregates]";  Command = {Get-UsageAggregates -ReportedStartTime '1/1/2018' -ReportedEndTime '1/2/2018' -ErrorAction Stop}},
    @{Name = "Az.Websites";                   Command = {Get-AzWebApp -ErrorAction Stop}}
)

if($Reverse.IsPresent){
    [array]::Reverse($resourceTestCommands)
}

$resourceCommands=$resourceSetUpCommands+$resourceTestCommands+$resourceCleanUpCommands

$startTime = Get-Date
$resourceCommands | ForEach-Object {
    $testName = $_.Name
    $script = $_.Command
    Write-Output "Running test $testName"
    $testStart = Get-Date
    try
    {
         &$script
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
