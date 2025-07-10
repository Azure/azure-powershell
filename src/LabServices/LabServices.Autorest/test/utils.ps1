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
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
        .\test\CreateTestResources.ps1
    }

    $env.ResourceGroupName = 'powershell-sdk-testing'
    $env.Location = 'westcentralus'
    $env.LabPlanName = 'labplan-record-powershell'
    $env.LabName = 'lab-record-powershell'
    $env.NewLabName = 'new-lab-record-powershell'
    $env.LabPlanNameToDelete = 'labplan-record-powershell-del'
    $env.LabNameToDelete = 'lab-unit-powershell-del'
    $env.LabNameLike = '*powershell'
    $env.UserEmail = 'test@contosouniversity.com'
    $env.UserName = 'testuser'
    $env.UserEmailSecond = 'testsecond@contosouniversity.com'
    $env.UserNameSecond = 'testseconduser'
    $env.ScheduleName = 'testschedule'
    $env.ScheduleNameSecond = 'secondtestschedule'
    $env.SIGName = 'sigunitpowershell'
    $env.InviteUserEmail = 'v-jiaji@microsoft.com'

    Import-Module (Join-Path $PSScriptRoot .\WebRequestHandler.psm1) -Force
    
    # Manually create the resource group and SIG if they do not exist. And assign role to the SIG
    # Connect-AzAccount -Subscription 2d5eedc9-8509-41fe-aac8-f16d54583ac6 -TenantId 29db6d0a-ccde-43f0-b9c1-6b234698e734
    # New-AzResourceGroup -Name 'powershell-sdk-testing' -Location 'westcentralus'
    # New-AzGallery -GalleryName 'sigunitpowershell' -ResourceGroupName 'powershell-sdk-testing' -Location 'westcentralus' -Description 'Shared Image Gallery for my unit tests'
    # New-AzRoleAssignment -ObjectId 594510ee-5396-4a71-902c-43e31b4c8d5a -RoleDefinitionName Contributor -Scope "/subscriptions/2d5eedc9-8509-41fe-aac8-f16d54583ac6/resourceGroups/powershell-sdk-testing/providers/Microsoft.Compute/galleries/sigunitpowershell"

    $env.SharedGalleryId = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/galleries/$($env.SIGName)"

    # Create the Lab Plan
    $labPlanUri = "https://management.azure.com/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.LabServices/labPlans/$($env.LabPlanName)"
    $labPlanToDeleteUri = "https://management.azure.com/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.LabServices/labPlans/$($env.LabPlanNameToDelete)"
    
    $labPlanBody = @{
        location = $env.Location
        properties = @{
            description = $env.LabPlanName
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
            allowedRegions = @($env.Location)
            sharedGalleryId = $env.SharedGalleryId
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
        Write-Host "Creating LabPlan $env.LabPlanName."
        New-AzLabServicesLabPlan -Name $env.LabPlanName -ResourceGroupName $env.ResourceGroupName -JsonString (ConvertTo-Json $labPlanBody -Depth 10)
        Update-AzLabServicesPlanImage -ResourceGroupName $env.ResourceGroupName -LabPlanName $env.LabPlanName -Name 'MicrosoftWindowsDesktop.windows-11.win11-23h2-pro' -EnabledState "Enabled"
    } else {
        Write-Host "$env.LabPlanName already exists."
    }

    if (!(CheckExists($labPlanToDeleteUri)))
    {
        Write-Host "Creating LabPlan $env.LabPlanNameToDelete."
        New-AzLabServicesLabPlan -Name $env.LabPlanNameToDelete -ResourceGroupName $env.ResourceGroupName -JsonString (ConvertTo-Json $labPlanBody -Depth 10)
    } else {
        Write-Host "$env.LabPlanNameToDelete already exists."
    }

    # Create the Lab
    $labUri = "https://management.azure.com/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.LabServices/labs/$($env.LabName)"
    $labdelUri = "https://management.azure.com/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.LabServices/labs/$($env.LabNameToDelete)"

    $labBody = @{
        location = $env.Location
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
                offer = "windows-11"
                publisher = "MicrosoftWindowsDesktop"
                sku = "win11-23h2-pro"
                version = "latest"
                }
                sku = @{
                name = "Classic_Fsv2_2_4GB_128_S_SSD"
                capacity = 2
                }
                additionalCapabilities = @{
                installGpuDrivers = "Disabled"
                }
                usageQuota = "P0M"
                useSharedPassword = "Disabled"
                adminUser = @{ 
                    username = $env.UserName
                    password = 'REDACTED'
                }
            }
            title = "LAB $($env.LabName)"
            description = "DESCRIPTION $($env.LabName)"
            labPlanId = "subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.LabServices/labPlans/$($env.LabPlanName)"
        }
    }

    if (!(CheckExists($labUri)))
    {
        Write-Host "Creating Lab $env.LabName."
        New-AzLabServicesLab -Name $env.LabName -ResourceGroupName $env.ResourceGroupName -JsonString (ConvertTo-Json $labBody -Depth 10)
    } else {
        Write-Host "$env.LabName already exists."
    }

    if (!(CheckExists($labdelUri)))
    {
        Write-Host "Creating Lab $env.LabNameToDelete."
        New-AzLabServicesLab -Name $env.LabNameToDelete -ResourceGroupName $env.ResourceGroupName -JsonString (ConvertTo-Json $labBody -Depth 10)
    } else {
        Write-Host "$env.LabNameToDelete already exists."
    }

    # Add Users
    $userUri = "https://management.azure.com/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.LabServices/labs/$($env.LabName)/users/$($env.UserName)"

    $userBody = @{
        properties = @{
            email = $env.UserEmail
        }
    }

    if (!(CheckExists($userUri))){
        Write-Host "Adding user $env.UserName."
        New-AzLabServicesUser -LabName $env.LabName -Name $env.UserName -ResourceGroupName $env.ResourceGroupName -JsonString (ConvertTo-Json $userBody -Depth 10)
    } else {
        Write-Host "$env.UserName already exists."
    }

    # Create schedule
    $scheduleUri = "https://management.azure.com/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.LabServices/labs/$($env.LabName)/schedules/$($env.ScheduleName)"

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
        Write-Host "Adding user $env.ScheduleName."
        New-AzLabServicesSchedule -LabName $env.LabName -Name $env.ScheduleName -ResourceGroupName $env.ResourceGroupName -JsonString (ConvertTo-Json $scheduleBody -Depth 10)
    }
    else {
        Write-Host "$env.ScheduleName already exists."
    }

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
    # .\test\SetVariables.ps1
    Write-Host "Sub: $($env.SubscriptionId)"
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.ResourceGroupName

}

