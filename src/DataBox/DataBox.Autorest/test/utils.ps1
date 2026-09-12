function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
function setupEnv() {
    Write-Host "[setupEnv] START"
    # Ensure tester is logged in before running tests
    $context = Get-AzContext
    Write-Host "[setupEnv] AzContext Account: $($context.Account), Subscription: $($context.Subscription.Id)"
    if (-not $context -or -not $context.Subscription) {
        throw "No Azure context found. Please run 'Connect-AzAccount' to login before running tests."
    }

    #Preload subscriptionId and tenant from context
    $env.SubscriptionId = $context.Subscription.Id
    $env.Tenant = $context.Tenant.Id
    $subscriptionId = $context.Subscription.Id
    Write-Host "[setupEnv] SubscriptionId=$subscriptionId, Tenant=$($env.Tenant)"

    # First, find a location where DataBox is enabled
    Write-Host "[setupEnv] Finding a location with DataBox enabled..."
    $location = $null
    $skuModel = $null
    # Need a temporary RG to call the availableSkus API - use subscription-level if possible
    $locationsToTry = @("WestUS", "EastUS", "WestUS2", "CentralUS", "WestEurope", "NorthEurope", "SoutheastAsia")
    # Create RG first (needed for SKU API)
    $resourceGroup = 'databox-pwsh-rg-' + (RandomString -allChars $false -len 2)
    Write-Host "[setupEnv] Creating ResourceGroup: $resourceGroup in WestUS"
    New-AzResourceGroup -Name $resourceGroup -Location WestUS
    Write-Host "[setupEnv] RG created"
    $env.Add("ResourceGroup",$resourceGroup)

    foreach ($loc in $locationsToTry) {
        $skuRequestBody = @{
            transferType = "ImportToAzure"
            country = "US"
            location = $loc
            skuNames = @("DataBox")
        } | ConvertTo-Json -Depth 5
        $skuUri = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.DataBox/locations/$loc/availableSkus?api-version=2025-02-01"
        $skuResult = Invoke-AzRestMethod -Path $skuUri -Method POST -Payload $skuRequestBody
        if ($skuResult.StatusCode -eq 200) {
            $skuResponse = $skuResult.Content | ConvertFrom-Json
            $enabledSku = $skuResponse.value | Where-Object { $_.sku.name -eq "DataBox" -and $_.enabled -eq $true } | Select-Object -First 1
            if ($enabledSku) {
                $location = $loc
                $skuModel = $enabledSku.sku.model
                Write-Host "[setupEnv] Found enabled DataBox in $loc, model=$skuModel"
                break
            }
        }
        Write-Host "[setupEnv] DataBox not enabled in $loc, trying next..."
    }
    if (-not $skuModel) {
        $skuModel = "AzureDataBox120"
        $location = "WestUS"
        Write-Host "[setupEnv] WARNING: No enabled location found. Using $location with model $skuModel (job creation may fail)"
    }
    Write-Host "[setupEnv] Using Location: $location, SkuModel: $skuModel"

    # Create a storage account for the test
    $storageAccountName = "databoxpwsh" + (RandomString -allChars $false -len 6)
    Write-Host "[setupEnv] Creating StorageAccount: $storageAccountName in $location"
    New-AzStorageAccount -ResourceGroupName $resourceGroup -Name $storageAccountName -Location $location -SkuName Standard_LRS -Kind StorageV2
    $storageAccountId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Storage/storageAccounts/$storageAccountName"
    $env.Add("StorageAccountId", $storageAccountId)
    $env.Add("KekUrl", "")
    $env.Add("UserAssignedResourceId", "")
    $env.Add("KekVaultResourceId", "")

    # Create job
    $jobName = "powershellRandom" + (RandomString -allChars $false -len 4)
    Write-Host "[setupEnv] Creating job: $jobName"

    # Add all env values first so cleanup knows what to clean even if job creation fails
    $env.Add("JobName",$jobName)
    $env.Add("JobNameImport","powershell" + (RandomString -allChars $false -len 4))
    $env.Add("JobNameUAI", "powershellUAI" +(RandomString -allChars $false -len 4))
    $env.Add("JobNameExport", "powershellExport" +(RandomString -allChars $false -len 4))
    $env.Add("JobNameScheduleOrder", "powershellSchedule" +(RandomString -allChars $false -len 4))
    $env.Add("JobNameManagedDisk", "managedDisk" +(RandomString -allChars $false -len 4))
    $env.Add("JobNameDisk", "PwshDisk" +(RandomString -allChars $false -len 4))
    $env.Add("JobNameHeavy", "PwshHeavy" +(RandomString -allChars $false -len 4))

    Write-Host "[setupEnv] Calling New-AzDataBoxJob via REST..."
    $jobBody = @{
        location = $location
        sku = @{
            name = "DataBox"
            model = $skuModel
        }
        properties = @{
            transferType = "ImportToAzure"
            details = @{
                jobDetailsType = "DataBox"
                contactDetails = @{
                    contactName = "random"
                    emailList = @("$($context.Account.Id)")
                    phone = "1234567891"
                }
                shippingAddress = @{
                    streetAddress1 = "101 TOWNSEND ST"
                    stateOrProvince = "CA"
                    country = "US"
                    city = "San Francisco"
                    postalCode = "94107"
                    addressType = "Commercial"
                }
                dataImportDetails = @(
                    @{
                        accountDetails = @{
                            dataAccountType = "StorageAccount"
                            storageAccountId = $storageAccountId
                        }
                    }
                )
            }
        }
    } | ConvertTo-Json -Depth 10
    $jobUri = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.DataBox/jobs/${jobName}?api-version=2025-02-01"
    Write-Host "[setupEnv] PUT $jobUri"
    $jobResult = Invoke-AzRestMethod -Path $jobUri -Method PUT -Payload $jobBody
    Write-Host "[setupEnv] Job API StatusCode: $($jobResult.StatusCode)"
    if ($jobResult.StatusCode -ge 400) {
        Write-Host "[setupEnv] Job API Response: $($jobResult.Content)"
        throw "Job creation failed with HTTP $($jobResult.StatusCode): $($jobResult.Content)"
    }

    # Wait for job to be provisioned (202 = async)
    if ($jobResult.StatusCode -eq 202) {
        Write-Host "[setupEnv] Job accepted (async). Waiting for provisioning..."
        $maxRetries = 5
        for ($i = 0; $i -lt $maxRetries; $i++) {
            Start-TestSleep -Seconds 10
            $getResult = Invoke-AzRestMethod -Path "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.DataBox/jobs/${jobName}?api-version=2025-02-01" -Method GET
            if ($getResult.StatusCode -eq 200) {
                Write-Host "[setupEnv] Job provisioned successfully"
                break
            }
            Write-Host "[setupEnv] Job not ready yet (attempt $($i+1)/$maxRetries, status=$($getResult.StatusCode))"
            if ($i -eq $maxRetries - 1) {
                Write-Host "[setupEnv] WARNING: Job not found after max retries. Continuing anyway."
            }
        }
    } else {
        Write-Host "[setupEnv] Job created successfully (status=$($jobResult.StatusCode))"
    }

    $env.Add("ContactName", "random")
    $env.Add("EmailList", @("$($context.Account.Id)"))
    $env.Add("Phone", "1234567891")

    $env.Add("StreetAddress1", "101 TOWNSEND ST")
    $env.Add("City", "San Francisco")
    $env.Add("StateOrProvince", "CA")
    $env.Add("Country", "US")
    $env.Add("AddressType", "Commercial")
    $env.Add("PostalCode", "94107")

    $env.Add("StagingStorageAccount", $storageAccountId)
    $env.Add("ManagedDiskRg", "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup")

    #For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
    Write-Host "[setupEnv] END - env saved to $envFile"
}
function cleanupEnv() {
    Write-Host "[cleanupEnv] START"
    Write-Host "[cleanupEnv] env.JobName='$($env.JobName)', env.ResourceGroup='$($env.ResourceGroup)', env.SubscriptionId='$($env.SubscriptionId)'"

    # Try to stop and remove job, but don't fail if it doesn't work
    if ($env.JobName -and $env.ResourceGroup) {
        Stop-AzDataBoxJob -Name $env.JobName -ResourceGroupName $env.ResourceGroup -Reason "Test Job" -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
        Remove-AzDataBoxJob -Name $env.JobName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
    }

    # Deleting the RG removes all resources inside it
    if ($env.ResourceGroup) {
        Write-Host "[cleanupEnv] Removing ResourceGroup: $($env.ResourceGroup)"
        Remove-AzResourceGroup -Name $env.ResourceGroup
    }
    Write-Host "[cleanupEnv] END"
}

