Import-Module .\WebRequestHandler.psm1 -Force

.\SetVariables.ps1

Connect-AzAccount -Subscription $ENV:SubscriptionId

Write-Host "Start Time : $(Get-Date)"
# Create the resource Group
$rgUri = "https://management.azure.com/subscriptions/" + $ENV:SubscriptionId +"/resourcegroups/$($ENV:ResourceGroupName)?api-version=2021-04-01"

$rgBody = @{
    location = $ENV:Location
} | ConvertTo-Json -Depth 10

if (!(CheckExists($rgUri)))
{
    Write-Host "Creating resource group $ENV:ResourceGroupName."
    $result = InvokeRest -Method PUT -Uri $rgUri -Body $rgBody
    Write-Host "Resource Group Result: $result"
    $resourceGroup = WaitProvisioning -uri $rgUri -delaySec 60 -retryCount 120
    
} else {
    Write-Host "$ENV:ResourceGroupName already exists."
}

# Create the SIG
$gallery = New-AzGallery `
  -GalleryName $ENV:SIGName `
  -ResourceGroupName $ENV:ResourceGroupName `
  -Location $ENV:Location `
  -Description 'Shared Image Gallery for my unit tests'

$ENV:SharedGalleryId = $gallery.Id

Write-Host "Created Shared Gallery $($ENV:SIGName)"

# Create the Lab Plan
$labPlanUri = "https://management.azure.com/subscriptions/" + $ENV:SubscriptionId  +"/resourceGroups/$($ENV:ResourceGroupName)/providers/Microsoft.LabServices/labPlans/$($ENV:LabPlanName)"
$labPlanToDeleteUri = "https://management.azure.com/subscriptions/" + $ENV:SubscriptionId  +"/resourceGroups/$($ENV:ResourceGroupName)/providers/Microsoft.LabServices/labPlans/$($ENV:LabPlanNameToDelete)"

$labPlanBody = @{
    location = $ENV:Location
    properties = @{
        description = $ENV:LabPlanName
        defaultConnectionProfile = @{
            webSshAccess = 'None'
            webRdpAccess = 'None'
            clientSshAccess = 'None'
            clientRdpAccess = 'Public'
            sharedPassword = 'None'
        }
        defaultAutoShutdownProfile = @{
            shutdownOnDisconnect = 'Disabled'
            shutdownWhenNotConnected = 'Disabled'
            shutdownOnIdle = 'None'
        }
        allowedRegions = @($ENV:Location)
        sharedGalleryId = $ENV:SharedGalleryId
        supportInfo = @{
            url = "https://help.contoso.com"
            email = "help@contoso.com"
            phone = "+1-202-555-0123"
            instructions = "Contact support for help."
        }
    }
}

if (!(CheckExists($labPlanUri)))
{
    Write-Host "Creating LabPlan $ENV:LabPlanName."
    $result = InvokeRest -Method PUT -Uri $labPlanUri -Body (ConvertTo-Json $labPlanBody -Depth 10)
    Write-Host "Lab Plan Result: $result"
    $labPlan = WaitProvisioning -uri $labPlanUri -delaySec 60 -retryCount 120

    
} else {
    Write-Host "$ENV:LabPlanName already exists."
    $labPlan = WaitProvisioning -uri $labPlanUri -delaySec 60 -retryCount 120
}

if (!(CheckExists($labPlanToDeleteUri)))
{
    Write-Host "Creating LabPlan $ENV:LabPlanNameToDelete."
    $result = InvokeRest -Method PUT -Uri $labPlanToDeleteUri -Body (ConvertTo-Json $labPlanBody -Depth 10)
    Write-Host "Lab Plan Result: $result"
    $labPlanToDelete = WaitProvisioning -uri $labPlanUri -delaySec 60 -retryCount 120

    
} else {
    Write-Host "$ENV:LabPlanNameToDelete already exists."
    $labPlanToDelete = WaitProvisioning -uri $labPlanToDeleteUri -delaySec 60 -retryCount 120
}

# Create the Lab
$labUri = "https://management.azure.com/subscriptions/" + $ENV:SubscriptionId  +"/resourceGroups/$($ENV:ResourceGroupName)/providers/Microsoft.LabServices/labs/$($ENV:LabName)"
$labdelUri = "https://management.azure.com/subscriptions/" + $ENV:SubscriptionId  +"/resourceGroups/$($ENV:ResourceGroupName)/providers/Microsoft.LabServices/labs/$($ENV:LabNameToDelete)"

$labBody = @{
    location = $ENV:Location
    properties = @{
        connectionProfile = @{
            webSshAccess = 'None'
            webRdpAccess = 'None'
            clientSshAccess = 'None'
            clientRdpAccess = 'Public'
        }
        autoShutdownProfile = @{
            shutdownOnDisconnect = 'Disabled'
            shutdownWhenNotConnected = 'Disabled'
            shutdownOnIdle = 'None'
        }
        securityProfile = @{
            openAccess = 'Disabled'
        }
        virtualMachineProfile = @{
            createOption = "TemplateVM"
            capacity = 2
            imageReference = @{
              offer = "Windows-10"
              publisher = "MicrosoftWindowsDesktop"
              sku = "20h2-pro"
              version = "latest"
            }
            sku = @{
              name = "Standard"
              capacity = 2
            }
            additionalCapabilities = @{
              installGpuDrivers = "Disabled"
            }
            usageQuota = "P0M"
            useSharedPassword = "Disabled"
            adminUser = @{ 
                username = 'PlaceholderAccountName'
                password = 'PlaceholderPassword'
            }
        }
        title = "LAB $($ENV:LabName)"
        description = "DESCRIPTION $($ENV:LabName)"
        labPlanId = $($labPlan | Select -ExpandProperty Id)
    }
}

if (!(CheckExists($labUri)))
{
    Write-Host "Creating Lab $ENV:LabName."
    $result = InvokeRest -Method PUT -Uri $labUri -Body (ConvertTo-Json $labBody -Depth 10)
    Write-Host "Lab Result: $result"
    $lab = WaitProvisioning -uri $labUri -delaySec 60 -retryCount 120
} else {
    Write-Host "$ENV:LabName already exists."
    $lab = WaitProvisioning -uri $labUri -delaySec 60 -retryCount 120
}

if (!(CheckExists($labdelUri)))
{
    Write-Host "Creating Lab $ENV:LabNameToDelete."
    $result = InvokeRest -Method PUT -Uri $labdelUri -Body (ConvertTo-Json $labBody -Depth 10)
    Write-Host "Lab Result: $result"
    $lab = WaitProvisioning -uri $labdelUri -delaySec 60 -retryCount 120
} else {
    Write-Host "$ENV:LabNameToDelete already exists."
    $lab = WaitProvisioning -uri $labdelUri -delaySec 60 -retryCount 120
}

# Add Users
$userUri = "https://management.azure.com/subscriptions/" + $ENV:SubscriptionId  +"/resourceGroups/$($ENV:ResourceGroupName)/providers/Microsoft.LabServices/labs/$($ENV:LabName)/users/$($ENV:UserName)"

$userBody = @{
    properties = @{
        email = $ENV:UserEmail
    }
}

if (!(CheckExists($userUri))){
    Write-Host "Adding user $ENV:UserName."
    $result = InvokeRest -Method PUT -Uri $userUri -Body (ConvertTo-Json $userBody -Depth 10)
    Write-Host "User Result: $result"
} else {
    Write-Host "$ENV:UserName already exists."
}

# Create schedule
$scheduleUri = "https://management.azure.com/subscriptions/" + $ENV:SubscriptionId  +"/resourceGroups/$($ENV:ResourceGroupName)/providers/Microsoft.LabServices/labs/$($ENV:LabName)/schedules/$($ENV:ScheduleName)"

$currentDate = (Get-Date).AddHours(2)
$endDate = (Get-Date).AddHours(3)
$expireDate = (Get-Date).AddDays(30)

$scheduleBody = @{
    properties = @{
        startAt = "$(Get-Date $currentDate -format yyyy-MM-ddTHH:mm:ssZ)"
        stopAt = "$(Get-Date $endDate -format yyyy-MM-ddTHH:mm:ssZ)"
        recurrencePattern = @{
            frequency = "Daily"
            interval = 2
            expirationDate = $(Get-Date $expireDate -format yyyy-MM-dd)
        }
        timeZoneId = 'America/Los_Angeles'
        notes = 'Automated schedule'
    }
}

if (!(CheckExists($scheduleUri))){
    Write-Host "Adding user $ENV:ScheduleName."
    $result = InvokeRest -Method PUT -Uri $scheduleUri -Body (ConvertTo-Json $scheduleBody -Depth 10)
    Write-Host "Schedule Result: $result"
}
else {
    Write-Host "$ENV:ScheduleName already exists."
}
Write-Host "End Time : $(Get-Date)"
