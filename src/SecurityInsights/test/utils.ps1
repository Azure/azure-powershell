function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    $resourceGroupName = "si-jj-test"
    $workspaceName = "si-test-ws2"
    $Location = "eastus"
    
    # Create the resource group if needed
    Write-Host "Start to create test resource group" $resourceGroupName
    try {
        Get-AzResourceGroup -Name $resourceGroupName -ErrorAction Stop
    } catch {
        New-AzResourceGroup -Name $resourceGroupName -Location $Location
    }
    
    # Create the workspace
    Write-Host "Start to create test workspace" $workspaceName
    try {
        Get-AzOperationalInsightsWorkspace -Name $workspaceName -ErrorAction Stop
    } catch {
        New-AzOperationalInsightsWorkspace -Location $Location -Name $workspaceName -ResourceGroupName $resourceGroupName

        Write-Host "Add Microsoft Sentinel to a workspace https://ms.portal.azure.com/#view/HubsExtension/BrowseResource/resourceType/microsoft.securityinsightsarg%2Fsentinel  Doc:https://learn.microsoft.com/en-us/azure/sentinel/quickstart-onboard. "
        Write-Host "Create Logic app and prepare to sentinel alert rule action. Docs: https://learn.microsoft.com/en-us/azure/logic-apps/quickstart-create-example-consumption-workflow#create-a-consumption-logic-app-resource"
        # 1.Create sentinel workspace 
        # 2.Add Automation rule playbook permission, Workspace-> Settings-> Settings-> Playbook permissions-> Configure permission-> select resource goup
        # 3.Create logic app
        $AlertLogicAppResourceName = "AlertLogicApp"
        $IncidentLogicAppResourceName = "IncidentLogicApp"
        $UpdateLogicAppResourceName = "AlertRuleUpdateLogicApp"
        # 4.Edit logic app design, add Microsoft sentinel Alert or Incident
        
        Start-Sleep(1000)
    }

    $null = $env.Add("resourceGroupName", $resourceGroupName)
    $null = $env.Add("workspaceName", $workspaceName)

    # Create and remove rule id
    $NewAlertRuleId = (New-Guid).Guid
    $null = $env.Add("NewAlertRuleId", $NewAlertRuleId)
    $NewAlertRuleName = "Powershell Exection Alert (Several Times per Hour)"
    $null = $env.Add("NewAlertRuleName", $NewAlertRuleName)

    # 5.Create Get Alert Rule
    Write-Host "Go to Test"
    #FusionMLTI
    $AlertRuleTemplateName1 = "f71aba3d-28fb-450b-b192-4e76a83015c8"
    $RemoveRule = New-AzSentinelAlertRule -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Kind Fusion -Enabled -AlertRuleTemplate $AlertRuleTemplateName1 -RuleId $RemoveRuleId
    $null = $env.Add("RemoveRuleId", $RemoveRule.Id)

    #MicrosoftSecurityIncidentCreation
    $AlertRuleTemplateName2 = "a2e0eb51-1f11-461a-999b-cd0ebe5c7a72"
    $GetUpdateAlertRule = New-AzSentinelAlertRule -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Kind MicrosoftSecurityIncidentCreation -Enabled -AlertRuleTemplateName $AlertRuleTemplateName2 -ProductFilter "Azure Security Center for IoT" -DisplayName "MSIC testing displayname"
    $null = $env.Add("GetUpdateAlertRuleID", $GetUpdateAlertRule.RuleId)
    
    # 6. Create Alert rule action
    $AlertLogicAppResource = Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $AlertLogicAppResourceName
    $null = $env.Add("AlertLogicAppResourceId", $AlertLogicAppResource.Id)
    $AlertLogicAppTriggerUri = Get-AzLogicAppTriggerCallbackUrl -ResourceGroupName $env.resourceGroupName -Name $AlertLogicAppResourceName -TriggerName "Microsoft_Sentinel_alert"
    $null = $env.Add("AlertLogicAppTriggerUri", $AlertLogicAppTriggerUri)
    #CreateViaIdentityAlertRuleExpanded
    $GetAlertRuleAction = New-AzSentinelAlertRuleAction -AlertRuleInputObject $GetUpdateAlertRule -LogicAppResourceId ($env.AlertLogicAppResourceId.Id) -TriggerUri ($AlertLogicAppTriggerUri.Value)
    $null = $env.Add("GetAlertRuleActionID", $GetAlertRuleAction.Id)
    #New and Remove Alert Rule Action Id
    $RemoveAlertRuleAction = New-AzSentinelAlertRuleAction -AlertRuleInputObject $GetUpdateAlertRule -LogicAppResourceId ($env.AlertLogicAppResourceId.Id) -TriggerUri ($AlertLogicAppTriggerUri.Value)
    $null = $env.Add("RemoveAlertRuleActionId", $RemoveAlertRuleAction.Id)
    $null = $env.Add("NewAlertRuleActionId", "7f702c43-c948-4f82-aed9-be1933badf74")

    # 7.1 create automation rule action
    # 7.2 create automation rule
    $automationRuleAction = New-AzSentinelAutomationRuleRunPlaybookActionObject -Order 1 -ActionConfigurationLogicAppResourceId $env.AlertLogicAppResourceId -ActionConfigurationTenantId $env.Tenant
    $GetAutomationRule = New-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
    -Action $automationRuleAction -DisplayName "Run Playbook to create alerts" -Order 1 `
    -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn Alerts -TriggeringLogicTriggersWhen Created
    $null = $env.Add("GetAutomationRuleId", $GetAutomationRule.Id)

    $null = $env.Add("NewAutomationRuleId", (New-Guid).Guid)

    $IncidentLogicAppResource = Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $IncidentLogicAppResourceName
    $null = $env.Add("IncidentLogicAppResourceId", $IncidentLogicAppResource.Id)
    $IncidentLogicAppTriggerUri = Get-AzLogicAppTriggerCallbackUrl -ResourceGroupName $resourceGroupName -Name $IncidentLogicAppResourceName -TriggerName "Microsoft_Sentinel_incident"
    $null = $env.Add("IncidentLogicAppTriggerUri", $IncidentLogicAppTriggerUri)

    $UpdateLogicAppResourceId = Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $UpdateLogicAppResourceName
    $null = $env.Add("UpdateLogicAppResourceId", $UpdateLogicAppResourceId)
    $UpdateLogicAppTriggerUri = Get-AzLogicAppTriggerCallbackUrl -ResourceGroupName $env.resourceGroupName -Name $UpdateLogicAppResourceName -TriggerName "Microsoft_Sentinel_alert"
    $null = $env.Add("UpdateLogicAppTriggerUri", $UpdateLogicAppTriggerUri)

    $automationRuleAction2 = New-AzSentinelAutomationRuleRunPlaybookActionObject -Order 1 -ActionConfigurationLogicAppResourceId $env.UpdateLogicAppResourceId -ActionConfigurationTenantId $env.Tenant
    $RemoveAutomationRule = New-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
    -Action $automationRuleAction2 -DisplayName "remove automation rule" -Order 3 `
    -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn Alerts -TriggeringLogicTriggersWhen Created
    $env.Add("RemoveAutomationRuleId", $RemoveAutomationRule.Id)

    # 8. Create bookmark
    $queryStartTime = (Get-Date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
    $queryEndTime = (Get-Date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
    $GetUpdateBookmark = New-AzSentinelBookmark -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
        -DisplayName "Incident Evidence Get" -Query "SecurityEvent | take 1" -QueryStartTime $queryStartTime -QueryEndTime $queryEndTime -EventTime $queryEndTime
    $RemoveBookmark = New-AzSentinelBookmark -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
        -DisplayName "Incident Evidence Remove" -Query "SecurityEvent | take 1" -QueryStartTime $queryStartTime -QueryEndTime $queryEndTime -EventTime $queryEndTime
    $env.Add("GetbookmarkId", $GetUpdateBookmark.Id)
    $env.Add("UpdateBookmarkId", $GetUpdateBookmark.Id)
    $env.Add("NewBookmarkId", (New-Guid).Guid)
    $env.Add("NewBookmarkName", "Incident Evidence New")
    $env.Add("RemoveBookmarkId", $RemoveBookmark.Id)

    # 9. create incident
    $GetIncident = New-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Title "GetIncident" -Description "Get incident Description" -Severity Low -Status New
    $RemoveIncident = New-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Title "GetIncident2" -Description "Remove incident Description" -Severity High -Status New
    $env.Add("GetIncidentId", $GetIncident.Id)
    $env.Add("NewincidentId", (New-Guid).Guid)
    $env.Add("NewincidentName", "NewIncident")
    $env.Add("RemoveIncidentId", $RemoveIncident.Id)

    # 10. create incident comment
    $GetIncidentComment = New-AzSentinelIncidentComment -IncidentInputObject $GetIncident -Message "Get Commet Here"
    $RemoveIncidentComment = New-AzSentinelIncidentComment -IncidentInputObject $GetIncident -Message "Get Commet2 Here"
    $env.Add("GetIncidentCommentId", $GetIncidentComment.Id)
    $env.Add("NewIncidentCommentId", (New-Guid).Guid)
    $env.Add("NewIncidentCommentName", "NewCommentHere")
    $env.Add("NewIncidentCommentIncidentId", (New-Guid).Guid)
    $env.Add("RemoveViaIncidentCommentId", $RemoveIncidentComment.Id)

    # 11. create incident relation


    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzOperationalInsightsWorkspace -ResourceGroupName "resource-group-name" -Name "workspace-name" -ForceDelete
}