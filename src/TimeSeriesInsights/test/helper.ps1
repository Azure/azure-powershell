function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

function GetUseModules() {
    $usedModule = & 'gmo'
    foreach($module in $usedModule)
    {
      $name = $module.Name
      $version = $module.Version
      Write-Host -ForegroundColor Green "Using module name: $name $version"
    }
} 

function RandomNumber([int32]$len) {
    return -join (0,1,2,3,4,5,6,7,8,9 | Get-Random -Count $len | % {[int32]$_})
}
function RandomLetters([int32]$len,[bool]$lowerCase) {
    if($lowerCase)
    {
         return -join ((97..122) | Get-Random -Count $len | % {[char]$_})
    }
    return -join ((65..90) + (97..122) | Get-Random -Count $len | % {[char]$_})
}

function CreateStaAccount([string]$resourceGroup, [string]$staAccountName,[string]$location, [string]$skuName)
{
    Write-Host -ForegroundColor Green 'Start creating storage account for test...'
    New-AzStorageAccount -ResourceGroupName $resourceGroup -AccountName $staAccountName -Location $location -SkuName $skuName
    Write-Host -ForegroundColor Green 'Created storage account successfully.'
    $staAccountKeys = Get-AzStorageAccountKey -ResourceGroupName $resourceGroup -Name $staAccountName
    $staAccountKey = $staAccountKeys[0].Value
    return $staccountParam = @{accountName=$staAccountName; accountKey=$staAccountKey}
}

function GetOrCreateTsiEnv([bool]$forceCreate, [string]$resourceGroup, $tsiEnvParamObj, $staccountParamObj)
{
    if(!$forceCreate)
    {
        $tsiEnvList = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $resourceGroup
        foreach($tsiEnv in $tsiEnvList)
        {
            if(($tsiEnv.Kind -eq $tsiEnvParamObj.Kind) -and ($tsiEnv.SkuName -eq $tsiEnvParamObj.SkuName))
            {
                Write-Host -ForegroundColor Green "Get TimeSeriesInsightsEnvironment for test from resource group."
                return $tsiEnv 
            }
        } 
    }
    if(!$tsiEnvParamObj.TsiEnvName)
    {
        $tsiEnvParamObj.TsiEnvName = "tsi-env-" + (RandomLetters -len 5)
    }
    if(!$tsiEnvParamObj.Location)
    {
        $tsiEnvParamObj.Location = 'eastus'
    }
    if(!$tsiEnvParamObj.TimeSpan)
    {
        $tsiEnvParamObj.TimeSpan = New-TimeSpan -Days 1 -Hours 1 -Minutes 25
    }
    if(!$tsiEnvParamObj.Capacity)
    {
        $tsiEnvParamObj.Capacity = 2
    }

    if($tsiEnvParamObj.Kind -eq 'Gen2')
    {
        if(!$tsiEnvParamObj.TimeSeriesIdProperty)
        {
            $tsiEnvParamObj.TimeSeriesIdProperty = @{name='cdc';type='string'}
        }
        $staAccountKey  = $staccountParamObj.accountKey | ConvertTo-SecureString -AsPlainText -Force
        Write-Host -ForegroundColor Green 'Start creating TimeSeriesInsightsEnvironment(Kind:Gen2) for test...'
        $tsiEnv = New-AzTimeSeriesInsightsEnvironment -ResourceGroupName $resourceGroup -Name $tsiEnvParamObj.TsiEnvName -Kind $tsiEnvParamObj.Kind -Location $tsiEnvParamObj.Location -Sku $tsiEnvParamObj.SkuName -StorageAccountName $staccountParamObj.accountName -StorageAccountKey $staAccountKey -TimeSeriesIdProperty $tsiEnvParamObj.TimeSeriesIdProperty
        Write-Host -ForegroundColor Green 'Created TimeSeriesInsightsEnvironment(Kind:Gen2) successfully.'
        return $tsiEnv
    }

    Write-Host -ForegroundColor Green 'Start creating TimeSeriesInsightsEnvironment(Kind:Gen1) for test...'
    $tsiEnv = New-AzTimeSeriesInsightsEnvironment -ResourceGroupName $resourceGroup -Name $tsiEnvParamObj.TsiEnvName -Kind $tsiEnvParamObj.Kind -Location $tsiEnvParamObj.Location -Sku $tsiEnvParamObj.SkuName -DataRetentionTime $tsiEnvParamObj.TimeSpan -Capacity $tsiEnvParamObj.Capacity
    #$tsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $resourceGroup -Name $tsiEnvParamObj.TsiEnvName
    Write-Host -ForegroundColor Green 'Created TimeSeriesInsightsEnvironment(Kind:Gen1) successfully.'
    return $tsiEnv
}

function CreateEventHub ([string]$eventHubSpaceName,[string]$eventHubName,[string]$resourceGroup, [string]$location)
{
    Write-Host -ForegroundColor Green 'Start creating EventHub for test...'
    $eventHubSpace = New-AzEventHubNamespace -Name $eventHubSpaceName -ResourceGroupName $resourceGroup -Location $location
    $eventHub = New-AzEventHub -ResourceGroupName $resourceGroup -NamespaceName $eventHubSpace.Name -Name $eventHubName 
    Write-Host -ForegroundColor Green 'Created EventHub successfully.'
    $eventHubKeys = Get-AzEventHubKey -ResourceGroupName $resourceGroup -NamespaceName $eventHubSpace.Name -AuthorizationRuleName RootManageSharedAccessKey
    $eventHubKey  = $eventHubKeys.PrimaryKey
    $eventhubParam = @{eventHubSpace=$eventHubSpaceName;eventhub=$eventHub;eventHubKey=$eventHubKey}
    return $eventhubParam
}

function CreateIotHub($iotHubParamObj,[string]$resourceGroup, [string]$location)
{
    if(!$iotHubParamObj.iotHubName)
    {
        $iotHubParamObj.iotHubName = 'rstr-' + (RandomString -allChars $false -len 6)
    }
    if(!$iotHubParamObj.iotHubSkuName)
    {
        $iotHubParamObj.iotHubSkuName = 'S1'
    }
    if(!$iotHubParamObj.iotUnits)
    {
        $iotHubParamObj.iotUnits = 100
    }
    Write-Host -ForegroundColor Green 'Start creating IotHub for test...'
    $iotHub = New-AzIotHub -ResourceGroupName $resourceGroup -Location $location -Name $iotHubParamObj.iotHubName -SkuName $iotHubParamObj.iotHubSkuName -Units $iotHubParamObj.iotUnits
    $iotHubKeys = Get-AzIotHubKey -ResourceGroupName $resourceGroup -Name $iotHubParamObj.iotHubName
    $iotHubKey  = $iotHubKeys[0].PrimaryKey
    Write-Host -ForegroundColor Green 'Created IotHub successfully.'
    $iothubParam = @{iotHubName=$iotHubParamObj.iotHubName;iotHub=$iotHub;iotHubKey=$iotHubKey}
    return $iothubParam
}

function CreateTsiEventSource([string]$tsiEevntSourceName,[string]$resourceGroup,$tsiEnv,$eventhubParam)
{
    # eventhub need modify.
    $eventHubKey  = $eventhubParam.eventHubKey | ConvertTo-SecureString -AsPlainText -Force
    Write-Host -ForegroundColor Green 'Start creating TimeSeriesInsightsEventSource for test...'
    $tsiEventSource = New-AzTimeSeriesInsightsEventSource -ResourceGroupName $resourceGroup -Name $tsiEevntSourceName -EnvironmentName $tsiEnv.Name.ToString() -Kind Microsoft.EventHub -ConsumerGroupName $resourceGroup -Location $tsiEnv.Location -KeyName RootManageSharedAccessKey -ServiceBusNameSpace $eventhubParam.eventHubSpace -EventHubName $eventhubParam.eventHub.Name -EventSourceResourceId $eventhubParam.eventHub.id -SharedAccessKey $eventHubKey
    Write-Host -ForegroundColor Green 'Created TimeSeriesInsightsEventSource successfully.'
    return $tsiEventSource
}