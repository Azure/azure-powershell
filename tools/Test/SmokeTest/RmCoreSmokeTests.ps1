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
            $script = "`$ErrorActionPreference='Continue' `n"
            $script += $Command.ToString()
            Write-Output "$script"
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

Write-Information "resourceGroupName=$resourceGroupName; storageAccountName=$storageAccountName"
Get-AzContextAutosaveSetting

$resourceSetUpCommands=@(
    @{Name = "Az.Resources";                  Command = {New-AzResourceGroup -Name $resourceGroupName -Location westus -Verbose}}
)

$resourceCleanUpCommands = @(
    @{Name = "Az.Storage [Cleanup]";          Command = {Remove-AzStorageAccount -Name $storageAccountName -ResourceGroupName $resourceGroupName -Force}},
    @{Name = "Az.Resources [Cleanup]";        Command = {Remove-AzResourceGroup -Name $resourceGroupName -Force}}
)

$resourceTestCommands = @(
    @{Name = "Az.Storage [Management]";       Command = {New-AzStorageAccount -Name $storageAccountName -SkuName Standard_LRS -Location westus -ResourceGroupName $resourceGroupName}},
    @{Name = "Az.Storage [Data]";             Command = {New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey 12345678}},
    @{Name = "Az.Storage [Data 1]";           Command = {Get-Command Get-AzStorageBlob}},
    @{Name = "Az.Accounts";                   Command = {Get-AzDomain}},
    @{Name = "Az.Accounts [DefaultProfile]";  Command = {Get-AzSubscription -DefaultProfile (Get-AzContext)}},
    @{Name = "Az.Advisor";                    Command = {Get-AzAdvisorConfiguration}},
    @{Name = "Az.Aks";                        Command = {Get-AzAksCluster}},
    @{Name = "Az.AnalysisServices";           Command = {Get-AzAnalysisServicesServer}},
    @{Name = "Az.ApiManagement";              Command = {Get-AzApiManagement}},
    @{Name = "Az.ApplicationInsights";        Command = {Get-AzApplicationInsights}},
    @{Name = "Az.Automation";                 Command = {Get-AzAutomationAccount}},
    @{Name = "Az.Batch [MngmPlane]";          Command = {Get-AzBatchAccount}},
    @{Name = "Az.Batch [DataPlane]";          Command = {Get-Command Get-AzBatchSupportedImage}},
    @{Name = "Az.Billing";                    Command = {Get-AzBillingInvoice}},
    @{Name = "Az.Billing [Consumption]";      Command = {Get-AzConsumptionBudget}},
    @{Name = "Az.Cdn";                        Command = {Get-AzCdnProfile}},
    @{Name = "Az.CognitiveServices";          Command = {Get-AzCognitiveServicesAccount}},
    @{Name = "Az.Compute";                    Command = {Get-AzVM}; Since="7.0.0"},
    @{Name = "Az.ContainerInstance";          Command = {Get-AzContainerGroup}},
    @{Name = "Az.ContainerRegistry [MngmPlane]"; Command = {Get-AzContainerRegistry}},
    @{Name = "Az.ContainerRegistry [DataPlane]"; Command = {Get-Command Get-AzContainerRegistryManifest}},
    @{Name = "Az.DataBoxEdge";                Command = {Get-AzDataBoxEdgeDevice -ResourceGroupName $resourceGroupName}},
    @{Name = "Az.Databricks";                 Command = {Get-AzDatabricksWorkspace -ResourceGroupName $resourceGroupName}},
    # The resource type could not be found in the namespace 'Microsoft.DataFactory' for api version '2015-10-01'.
    # @{Name = "Az.DataFactory [V1]";           Command = {Get-AzDataFactory -ResourceGroupName $resourceGroupName}},
    @{Name = "Az.DataFactoryV2 [V2]";         Command = {Get-AzDataFactoryV2}},
    @{Name = "Az.DataLakeAnalytics";          Command = {Get-AzDataLakeAnalyticsAccount}},
    @{Name = "Az.DataLakeStore [MngmPlane]";  Command = {Get-AzDataLakeStoreAccount}},
    @{Name = "Az.DataLakeStore [DataPlane]";  Command = {Get-Command New-AzDataLakeStoreItem}},
    @{Name = "Az.DataShare";                  Command = {Get-AzDataShareAccount -ResourceGroupName $resourceGroupName}},
    # Waiting for an issue fix: https://github.com/Azure/azure-powershell/issues/13522#issuecomment-728659457
    # @{Name = "Az.DeploymentManager";          Command = {try {Get-AzDeploymentManagerArtifactSource -ResourceGroupName $resourceGroupName }catch {if ($_.ToString() -notlike "*not found*") {throw $_}}}},
    @{Name = "Az.DesktopVirtualization";      Command = {Get-AzWvdApplicationGroup -ResourceGroupName $resourceGroupName}},
    @{Name = "Az.Dns";                        Command = {Get-AzDnsZone}},
    @{Name = "Az.EventGrid";                  Command = {Get-AzEventGridTopic}},
    @{Name = "Az.EventHub";                   Command = {Get-AzEventHubNamespace}},
    @{Name = "Az.FrontDoor";                  Command = {Get-AzFrontDoor}},
    @{Name = "Az.Functions";                  Command = {Get-AzFunctionApp}},
    @{Name = "Az.HDInsight ";                 Command = {Get-AzHDInsightCluster}},
    @{Name = "Az.HealthcareApis";             Command = {Get-AzHealthcareApisService}},
    @{Name = "Az.IotHub [MngmPlane]";         Command = {Get-AzIotHub}},
    @{Name = "Az.IotHub [DataPlane]";         Command = {Get-Command Get-AzIotHubModuleConnectionString}},
    @{Name = "Az.KeyVault [MngmPlane]";       Command = {Get-AzKeyVault}},
    @{Name = "Az.KeyVault [DataPlane]";       Command = {Get-Command Get-AzKeyVaultKey}},
    @{Name = "Az.Kusto";                      Command = {Get-AzKustoCluster}},
    @{Name = "Az.LogicApp";                   Command = {Get-AzIntegrationAccount}},
    @{Name = "Az.MachineLearning";            Command = {Get-AzMlWebService}},
    @{Name = "Az.Maintenance";                Command = {Get-AzMaintenanceConfiguration}},
    @{Name = "Az.ManagedServices";            Command = {Get-AzManagedServicesAssignment}},
    @{Name = "Az.Media";                      Command = {Get-AzMediaService -ResourceGroupName $resourceGroupName}},
    @{Name = "Az.Monitor";                    Command = {Get-AzLogProfile}},
    @{Name = "Az.Network";                    Command = {Get-AzNetworkInterface}},
    @{Name = "Az.NotificationHubs";           Command = {Get-AzNotificationHubsNamespace}},
    @{Name = "Az.OperationalInsights [MngmPlane]"; Command = {Get-AzOperationalInsightsWorkspace}},
    @{Name = "Az.OperationalInsights [DataPlane]"; Command = {Get-Command Invoke-AzOperationalInsightsQuery}},
    @{Name = "Az.PolicyInsights";             Command = {Get-AzPolicyEvent -Top 10}}, # without -Top service may return 400: ResponseTooLarge
    @{Name = "Az.PowerBIEmbedded";            Command = {Get-AzPowerBIEmbeddedCapacity}},
    @{Name = "Az.PrivateDns";                 Command = {Get-AzPrivateDnsZone}},
    @{Name = "Az.RecoveryServices";           Command = {Get-AzRecoveryServicesVault}},
    @{Name = "Az.RedisCache";                 Command = {Get-AzRedisCache}},
    @{Name = "Az.Relay";                      Command = {Get-AzRelayNamespace}},
    @{Name = "Az.ServiceBus";                 Command = {Get-AzServiceBusNamespace}},
    @{Name = "Az.ServiceFabric [MngmPlane]";  Command = {Get-AzServiceFabricCluster}},
    @{Name = "Az.ServiceFabric [DataPlane]";  Command = {Get-Command New-AzServiceFabricCluster}},
    @{Name = "Az.SignalR";                    Command = {Get-AzSignalR}},
    @{Name = "Az.Sql";                        Command = {Get-AzSqlServer}},
    @{Name = "Az.SqlVirtualMachine";          Command = {Get-AzSqlVM}},
    @{Name = "Az.StreamAnalytics";            Command = {Get-AzStreamAnalyticsJob}},
    @{Name = "Az.StorageSync";                Command = {Get-AzStorageSyncService}},
    @{Name = "Az.Support";                    Command = {Get-AzSupportTicket}},
    @{Name = "Az.Resources [Tags]";           Command = {Get-AzTag}},
    @{Name = "Az.Resources [MSGraph]";        Command = {Get-AzADUser -First 1 -Select Id}},
    @{Name = "Az.TrafficManager";             Command = {Get-AzTrafficManagerProfile}},
    @{Name = "Az.Billing [UsageAggregates]";  Command = {Get-UsageAggregates -ReportedStartTime '1/1/2018' -ReportedEndTime '1/2/2018'}},
    @{Name = "Az.Websites";                   Command = {Get-AzWebApp -ResourceGroupName $resourceGroupName}}
)

$generalCommands = @(
    @{
        Name = "Import Az.Accounts in Parallel (Process)";
        Command = {
            if ($null -ne $env:SYSTEM_DEFINITIONID -or $null -ne $env:Release_DefinitionId -or $null -ne $env:AZUREPS_HOST_ENVIRONMENT) {
                Write-Warning "Skipping because 'Start-Job' is not supported by design in scenarios where PowerShell is being hosted in other applications."
                return
            }
            $importJobs = @()
            1..10 | ForEach-Object {
                $importJobs += Start-Job -name "import-no.$_" -ScriptBlock { Import-Module Az.Accounts; Get-AzConfig; }
            }
            $importJobs | Wait-Job
            $importJobs | Receive-Job
            $importJobs | ForEach-Object {
                if ("Completed" -ne $_.State) {
                    throw "Some jobs have failed."
                }
            }
        };
        Retry = 0; # no need to retry
    }
    @{
        Name = "Import Az.Accounts in Parallel (Thread)";

        Command = {
            $importJobs = @()
            1..50 | ForEach-Object {
                $importJobs += Start-ThreadJob -name "import-no.$_" -ScriptBlock { Import-Module Az.Accounts; Get-AzTenant; }
            }
            $importJobs | Wait-Job
            $importJobs | Receive-Job
            $importJobs | ForEach-Object {
                if ("Completed" -ne $_.State) {
                    throw "Some jobs have failed."
                }
            }
        };
        Retry = 0; # no need to retry
    }
)

if($Reverse.IsPresent){
    [array]::Reverse($resourceTestCommands)
}

$resourceCommands = $resourceSetUpCommands + $resourceTestCommands + $resourceCleanUpCommands + $generalCommands

$startTime = Get-Date
$resourceCommands | ForEach-Object {
    $testName = $_.Name
    $script = $_.Command
    $retry = if($null -eq $_.Retry) {3} Else {$_.Retry}
    $sleep = if($null -eq $_.Sleep) {30} Else {$_.Sleep}
    if($null -ne $_.Since -and "Core" -eq $PSVersionTable.PSEdition -and $PSVersionTable.PSVersion -lt [System.Version]$_.Since) {
        Write-Output "Skip test $testName"
        $testInfo.SkippedCount += 1
        return
    }
    Write-Output "Running test $testName"
    $testStart = Get-Date
    try
    {
        Retry-AzCommand -Name $testName -Command $script -Retry 0 -Sleep 0
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
