# $oldVerbose = $VerbosePreference
# $oldDebug = $DebugPreference
# $VerbosePreference = "Continue"
# $DebugPreference = "SilentlyContinue"
# $debugState = $false
[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $false, Position = 0)]
    [PSDefaultValue(Help = "9e223dbe-3399-4e19-88eb-0975f02ac87f")]
    $subscriptionId = "9e223dbe-3399-4e19-88eb-0975f02ac87f",

    [Parameter()]
    [switch]
    $Reverse
)

if (Get-Module -ListAVailable 'Az.Accounts')
{
    Enable-AzureRmAlias
}

if (!(Get-AzureRmContext -ErrorAction 'Ignore'))
{
  Connect-AzureRmAccount -Subscription $subscriptionId
}

$testInfo = @{
    TotalCount = 0;
    PassedCount = 0;
    PassedTests = @();
    FailedTests = @();
    FailureDetails = @();
    Times = @()
}
$randomValue = Get-Random -Minimum 1000 -Maximum 10000
$resourceGroupName = "smokergtest$randomValue"
$storageAccountName = "smokesatest$randomValue"

$resourceSetUpCommands=@(
    @{Name = "Az.Resources";                  Command = {New-AzureRmResourceGroup -Name $resourceGroupName -Location westus -ErrorAction Stop}}
)
$resourceCleanUpCommands = @(
    @{Name = "Az.Storage [Cleanup]";          Command = {Remove-AzureRmStorageAccount -Name $storageAccountName -ResourceGroupName $resourceGroupName -Force -ErrorAction Stop}},
    @{Name = "Az.Resources [Cleanup]";        Command = {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction Stop}}
)
$resourceTestCommands = @(
    @{Name = "Az.Storage [Management]";       Command = {New-AzureRmStorageAccount -Name $storageAccountName -SkuName Standard_LRS -Location westus -ResourceGroupName $resourceGroupName -ErrorAction Stop}},
    @{Name = "Az.Storage [Data]";             Command = {New-AzureStorageContext -StorageAccountName $storageAccountName -StorageAccountKey 12345678 -ErrorAction Stop}},
    @{Name = "Az.Aks";                        Command = {Get-AzureRmAks -ErrorAction Stop}},
    @{Name = "Az.AnalysisServices";           Command = {Get-AzureRmAnalysisServicesServer -ErrorAction Stop}},
    @{Name = "Az.ApiManagement";              Command = {Get-AzureRmApiManagement -ErrorAction Stop}},
    @{Name = "Az.ApplicationInsights";        Command = {Get-AzureRmApplicationInsights -ErrorAction Stop}},
    @{Name = "Az.Automation";                 Command = {Get-AzureRmAutomationAccount -ErrorAction Stop}},
    @{Name = "Az.Batch";                      Command = {Get-AzureRmBatchAccount -ErrorAction Stop}},
    @{Name = "Az.Billing";                    Command = {Get-AzureRmBillingInvoice -ErrorAction Stop}},
    @{Name = "Az.Billing [Consumption]";      Command = {try {Get-AzureRmConsumptionUsageDetail -ErrorAction Stop} catch {if ($_.ToString() -notlike "*422*" -and $_.ToString() -notlike "*UnprocessableEntity*" -and $_.ToString() -notlike "*BadRequest*") {throw $_}}}},
    @{Name = "Az.Cdn";                        Command = {Get-AzureRmCdnProfile -ErrorAction Stop}},
    @{Name = "Az.CognitiveServices";          Command = {Get-AzureRmCognitiveServicesAccount -ErrorAction Stop}},
    @{Name = "Az.Compute";                    Command = {Get-AzureRmVM -ErrorAction Stop}},
    @{Name = "Az.ContainerInstance";          Command = {Get-AzureRmContainerGroup -ErrorAction Stop}},
    @{Name = "Az.ContainerRegistry";          Command = {Get-AzureRmContainerRegistry -ErrorAction Stop}},
    @{Name = "Az.DataFactory [V1]";           Command = {Get-AzureRmDataFactory -ResourceGroupName $resourceGroupName -ErrorAction Stop}},
    @{Name = "Az.DataFactoryV2 [V2]";         Command = {Get-AzureRmDataFactoryV2 -ErrorAction Stop}},
    @{Name = "Az.DataLakeAnalytics";          Command = {Get-AzureRmDataLakeAnalyticsAccount -ErrorAction Stop}},
    @{Name = "Az.DataLakeStore";              Command = {Get-AzureRmDataLakeStoreAccount -ErrorAction Stop}},
    @{Name = "Az.DevTestLabs ";               Command = {try {Get-AzDtlAllowedVMSizesPolicy -LabName nonexistent -ResourceGroupName nonexistent -ErrorAction Stop} catch {if ($_.ToString() -notlike "*'nonexistent' could not be found.") {throw $_}}}},
    @{Name = "Az.Dns";                        Command = {Get-AzureRmDnsZone -ErrorAction Stop}},
    @{Name = "Az.EventGrid";                  Command = {Get-AzureRmEventGridTopic -ErrorAction Stop}},
    @{Name = "Az.EventHub";                   Command = {Get-AzureRmEventHubNamespace -ErrorAction Stop}},
    @{Name = "Az.HDInsight ";                 Command = {Get-AzHDInsightCluster -ErrorAction Stop}},
    @{Name = "Az.IotHub";                     Command = {Get-AzureRmIotHub -ErrorAction Stop}},
    @{Name = "Az.KeyVault";                   Command = {Get-AzureRmKeyVault -ErrorAction Stop}},
    @{Name = "Az.LogicApp";                   Command = {Get-AzureRmIntegrationAccount -ErrorAction Stop}},
    @{Name = "Az.MachineLearning";            Command = {Get-AzureRmMlWebService -ErrorAction Stop}},
    # Machine learning compute cmdlets are removed. The following line are to be commented until they are brought back
    # @{Name = "Az.MachineLearning [Compute]";  Command = {Get-AzureRmMlOpCluster -ErrorAction Stop}},
    @{Name = "Az.MarketplaceOrdering";        Command = {try {Get-AzMarketplaceTerms -Publisher nonexistent -Product nonexistent -Name nonexistent -ErrorAction Stop} catch {if ($_.ToString() -notlike "*not found*") {throw $_}}}},
    @{Name = "Az.Media";                      Command = {Get-AzureRmMediaService -ResourceGroupName $resourceGroupName -ErrorAction Stop}},
    @{Name = "Az.Monitor";                    Command = {Get-AzureRmLogProfile -ErrorAction Stop}},
    @{Name = "Az.Network";                    Command = {Get-AzureRmNetworkInterface -ErrorAction Stop}},
    @{Name = "Az.NotificationHubs";           Command = {Get-AzureRmNotificationHubsNamespace -ErrorAction Stop}},
    @{Name = "Az.OperationalInsights";        Command = {Get-AzureRmOperationalInsightsWorkspace -ErrorAction Stop}},
    @{Name = "Az.PolicyInsights";             Command = {Get-AzPolicyEvent -ErrorAction Stop}},
    @{Name = "Az.PowerBIUEmbedded";           Command = {Get-AzureRmPowerBIWorkspaceCollection -ErrorAction Stop}},
    @{Name = "Az.RecoveryServices";           Command = {Get-AzRecoveryServicesVault -ErrorAction Stop}},
    @{Name = "Az.RedisCache";                 Command = {Get-AzureRmRedisCache -ErrorAction Stop}},
    @{Name = "Az.Relay";                      Command = {Get-AzureRmRelayNamespace -ErrorAction Stop}},
    @{Name = "Az.ServiceBus";                 Command = {Get-AzureRmServiceBusNamespace -ErrorAction Stop}},
    @{Name = "Az.ServiceFabric";              Command = {Get-AzureRmServiceFabricCluster -ErrorAction Stop}},
    @{Name = "Az.SignalR";                    Command = {Get-AzSignalR -ErrorAction Stop}},
    @{Name = "Az.Sql";                        Command = {Get-AzureRmSqlServer -ErrorAction Stop}},
    @{Name = "Az.StreamAnalytics";            Command = {Get-AzureRmStreamAnalyticsJob -ErrorAction Stop}},
    @{Name = "Az.Resources [Tags]";           Command = {Get-AzureRmTag -ErrorAction Stop}},
    @{Name = "Az.TrafficManager";             Command = {Get-AzureRmTrafficManagerProfile -ErrorAction Stop}},
    @{Name = "Az.Billing [UsageAggregates]";  Command = {Get-UsageAggregates -ReportedStartTime '1/1/2018' -ReportedEndTime '1/2/2018' -ErrorAction Stop}},
    @{Name = "Az.Websites";                   Command = {Get-AzureRmWebApp -ErrorAction Stop}}
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
         $detail = Resolve-AzureRmError -Last
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

# Resolve-AzureRmError
# $DebugPreference = $oldDebug
# $VerbosePreference = $oldVerbose