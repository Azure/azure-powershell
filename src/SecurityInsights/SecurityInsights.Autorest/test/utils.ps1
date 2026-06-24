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

    #needed for custom api call
    $token = . "$PSScriptRoot/../utils/Unprotect-SecureString.ps1" (Get-AzAccessToken -AsSecureString).Token
    $Header = @{
        Authorization="Bearer $token"
        Content='application/json'
    }

    # Some constants
    $constants = Get-Content .\test\constants.json | ConvertFrom-Json
    $constants.psobject.Properties | ForEach-Object { $env[$_.Name] = $_.Value }
    $TemplatePath = ".\test\deployment-templates"
    $SampleDataPath = ".\test\sampleData"

    #Load common Functions
    . (".\test\common.ps1")

    # Create the test group
    $resourceGroupName = "aspstest" + (RandomString -allChars $false -len 6)
    Write-Host "Start to create test resource group" $resourceGroupName
    $null = $env.Add("resourceGroupName", $resourceGroupName)
    New-AzResourceGroup -Name $resourceGroupName -Location $env.location

    # Create the Workspace+Sentinel
    $workspaceName = "asptest" + (RandomString -allChars $false -len 6)
    $newOnboardingStateWS = "asptest" + (RandomString -allChars $false -len 6)
    $removeOnboardingStateWS = "asptest" + (RandomString -allChars $false -len 6)
    Write-Host "Start to create test workspace" $workspaceName
    $workspaceParams = Get-Content .\test\deployment-templates\workspace\template.parameters.json | ConvertFrom-Json
    $workspaceParams.parameters.workspaceName.value = $workspaceName
    $workspaceParams.parameters.newOnboardingStateWS.value = $newOnboardingStateWS
    $workspaceParams.parameters.removeOnboardingStateWS.value = $removeOnboardingStateWS
    set-content -Path .\test\deployment-templates\workspace\template.parameters.json -Value (ConvertTo-Json $workspaceParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\workspace\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\workspace\template.parameters.json).FullName
    $result = New-AzResourceGroupDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name Workspace -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add("workspaceName", $workspaceName)
        $null = $env.Add('workspaceId', $result.Outputs.workspaceId.Value)
        $workspaceKey = $result.Outputs.workspaceKey.Value
        $null = $env.Add('workspaceResourceId', $result.Outputs.workspaceResourceId.Value)
        $null = $env.Add("newOnboardingStateWS", $newOnboardingStateWS)
        $null = $env.Add("removeOnboardingStateWS", $removeOnboardingStateWS)
    }


    #Custom Log Import -> Create Analytic that triggers
    Write-Host "Ingesting Sample Data"
    $files = Get-ChildItem -Path $SampleDataPath -Filter *.csv
    foreach($file in $Files){
        $fileToImport = $file.FullName
        $tableName = ($file.Name).Replace('.csv','')
        $status = SendToLogA -eventsTableName $tableName -EventsTableFile $fileToImport -CustomerId $env.workspaceId -SharedKey $workspaceKey
        Write-Host "$TableName results: $status"
    }
    write-Host "Starting sleep to allow time for ingestion"
    #Start-Sleep -Seconds 600
    Start-WaitForData 600

    # Alert Rules that trigger off custom data.
    Write-Host "Start to create test alert rules that trigger off custom data"
    $solarigateRuleGuid = (New-Guid).Guid
    $disabledRuleGuid = (New-Guid).Guid
    $mlRuleGuid = (New-Guid).Guid
    $alertRuleParams = Get-Content .\test\deployment-templates\customData\alertRules.parameters.json | ConvertFrom-Json
    $alertRuleParams.parameters.solarigateRuleGuid.value = $solarigateRuleGuid
    $alertRuleParams.parameters.disabledRuleGuid.value = $disabledRuleGuid
    $alertRuleParams.parameters.mlRuleGuid.value = $mlRuleGuid
    $alertRuleParams.parameters.workspaceName.value = $env.workspaceName
    set-content -Path .\test\deployment-templates\customData\alertRules.parameters.json -Value (ConvertTo-Json $alertRuleParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\customData\alertRules.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\customData\alertRules.parameters.json).FullName
    $result = New-AzResourceGroupDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name CustomData -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add(("solarigateRuleGuid"), $solarigateRuleGuid)
        $null = $env.Add(("disabledRuleGuid"), $disabledRuleGuid)
        $null = $env.Add(("mlRuleGuid"), $mlRuleGuid)
    }

    #Deploy Playbooks
    Write-Host "Start to create test playbooks"
    $TemplateFile = (Get-ChildItem $TemplatePath\playbooks\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\playbooks\template.parameters.json).FullName
    New-AzResourceGroupDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name Playbooks -ResourceGroupName $resourceGroupName
    $result = Get-AzResourceGroupDeployment -ResourceGroupName $resourceGroupName -Name 'Playbooks' -ErrorAction SilentlyContinue
    if(-not $result -or $result.ProvisioningState -ne "Succeeded"){
        Start-TestSleep -Seconds 30
        New-AzResourceGroupDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name PlaybooksRetry -ResourceGroupName $resourceGroupName
        $result = Get-AzResourceGroupDeployment -ResourceGroupName $resourceGroupName -Name 'PlaybooksRetry' -ErrorAction SilentlyContinue
    }
    if($result -and $result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add('Playbook1LogicAppResourceId', $result.Outputs.playbook1LogicAppResourceId.Value)
        $null = $env.Add('Playbook1TriggerUrl', $result.Outputs.playbook1triggerUrl.Value)
        $null = $env.Add('Playbook2LogicAppResourceId', $result.Outputs.playbook2LogicAppResourceId.Value)
        $null = $env.Add('Playbook2TriggerUrl', $result.Outputs.playbook2triggerUrl.Value)
        $null = $env.Add('Playbook3LogicAppResourceId', $result.Outputs.playbook3LogicAppResourceId.Value)
        $null = $env.Add('Playbook3TriggerUrl', $result.Outputs.playbook3triggerUrl.Value)
        $null = $env.Add('Playbook4LogicAppResourceId', $result.Outputs.playbook4LogicAppResourceId.Value)
        $null = $env.Add('Playbook4TriggerUrl', $result.Outputs.playbook4triggerUrl.Value)
    } else {
        Write-Host "Playbooks deployment failed after both attempts"
    }


    #Create Alert Rules
    Write-Host "Start to create test alert rules"
    $null = $env.Add('NewAlertRuleName', ("NewAlertRule" + (RandomString -allChars $false -len 6)))
    $null = $env.Add('NewAlertRuleId', ((New-Guid).Guid))
    Create-AlertRule -PSVerb Get -WorkspaceName $env.workspaceName
    Create-AlertRule -PSVerb Remove -WorkspaceName $env.workspaceName
    Create-AlertRule -PSVerb RemoveViaId -WorkspaceName $env.workspaceName
    Create-AlertRule -PSVerb Update -WorkspaceName $env.workspaceName
    Create-AlertRule -PSVerb UpdateViaId -WorkspaceName $env.workspaceName

    #Create AlertRuleAction
    Write-Host "Start to create test alert rule actions"
    $null = $env.Add('NewalertRuleActionRuleId', (New-Guid).Guid)
    $null = $env.Add('NewalertRuleActionRuleName', ("NewalertRuleActionRuleName" + (RandomString -allChars $false -len 6)))
    $null = $env.Add('NewAlertRuleActionId', (New-Guid).Guid)
    Create-AlertRuleAction -PSVerb Get -WorkspaceName $env.workspaceName -logicAppResourceId $env.Playbook1LogicAppResourceId -triggerUrl $env.Playbook1TriggerUrl
    Create-AlertRuleAction -PSVerb Remove -WorkspaceName $env.workspaceName -logicAppResourceId $env.Playbook1LogicAppResourceId -triggerUrl $env.Playbook1TriggerUrl
    Create-AlertRuleAction -PSVerb RemoveViaId -WorkspaceName $env.workspaceName -logicAppResourceId $env.Playbook1LogicAppResourceId -triggerUrl $env.Playbook1TriggerUrl
    Create-AlertRuleAction -PSVerb Update -WorkspaceName $env.workspaceName -logicAppResourceId $env.Playbook1LogicAppResourceId -triggerUrl $env.Playbook1TriggerUrl
    Create-AlertRuleAction -PSVerb UpdateViaId -WorkspaceName $env.workspaceName -logicAppResourceId $env.Playbook1LogicAppResourceId -triggerUrl $env.Playbook1TriggerUrl

    #Service Principal needs to be in constants.json.
    #Write-Host "Get Service Principal"
    #$ClientID = '1950a258-227b-4e31-a9cf-717495945fc2'
    #$Resource = "74658136-14ec-4630-ad9b-26e160ff0fc6"
    #$uri = "https://login.microsoftonline.com/"+$env.Tenant+"/oauth2/devicecode"
    #$DeviceCodeRequestParams = @{
    #    Method = 'POST'
    #    Uri    = $uri
    #    Body   = @{
    #        client_id = $ClientId
    #        resource  = $Resource
    #    }
    #}
    #$DeviceCodeRequest = Invoke-RestMethod @DeviceCodeRequestParams
    #Write-Host $DeviceCodeRequest.message -ForegroundColor Yellow
    #write-host "You need to go login with the data above. script will continue in "
    #start-sleep -Seconds 120
    #$uri = "https://login.microsoftonline.com/"+$env.Tenant+"/oauth2/token"
    #$TokenRequestParams = @{
    #    Method = 'POST'
    #    Uri    = $uri
    #    Body   = @{
    #        grant_type = "urn:ietf:params:oauth:grant-type:device_code"
    #        code       = $DeviceCodeRequest.device_code
    #        client_id  = $ClientId
    #    }
    #}
    #$TokenRequest = Invoke-RestMethod @TokenRequestParams
    #$appToken = $TokenRequest.access_token

    #$header = @{
    #'Authorization' = 'Bearer ' + $appToken
    #'X-Requested-With'= 'XMLHttpRequest'
    #'x-ms-client-request-id'= [guid]::NewGuid()
    #'x-ms-correlation-id' = [guid]::NewGuid()
    #}
    #$body = @{"accountEnabled"=$null;"isAppVisible"=$null;"appListQuery"=1;"searchText"="Azure Security Insights";"top"=50;"loadLogo"=$false;"putCachedLogoUrlOnly"=$true;"nextLink"="";"usedFirstPartyAppIds"=$null;"__ko_mapping__"=@{"ignore"=@();"include"=@("_destroy");"copy"=@();"observe"=@();"mappedProperties"=@{"accountEnabled"=$true;"isAppVisible"=$true;"appListQuery"=$true;"searchText"=$true;"top"=$true;"loadLogo"=$true;"putCachedLogoUrlOnly"=$true;"nextLink"=$true;"usedFirstPartyAppIds"=$true};"copiedProperties"=@()}}
    #$url = "https://main.iam.ad.ext.azure.com/api/ManagedApplications/List"
    #$res = Invoke-RestMethod -Uri $url -Headers $header -Method POST -body ($body | convertto-Json) -ErrorAction Stop -ContentType "application/json"
    #$null = $env.Add('ASIServicePrinicpal', ($res.appList[0].objectId))

    Write-Host "Deploy authorization to allow automation rules"
    $authorizationParams = Get-Content .\test\deployment-templates\authorization\template.parameters.json | ConvertFrom-Json
    $authorizationParams.parameters.ASIServicePrinicpal.value = $env.ASIServicePrinicpal
    set-content -Path .\test\deployment-templates\authorization\template.parameters.json -Value (ConvertTo-Json $authorizationParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\authorization\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\authorization\template.parameters.json).FullName
    $result = New-AzResourceGroupDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name Authorization -ResourceGroupName $resourceGroupName
    start-sleep 60

    #Create Automation Rule
    Write-Host "Start to create test automation rule"
    $null = $env.Add('NewAutomationRuleId', (New-Guid).Guid)
    $null = $env.Add('NewAutomationRule', ("NewAutomationRule" + (RandomString -allChars $false -len 6)))
    Create-AutomationRule -PSVerb Get -WorkspaceName $env.workspaceName -logicAppResourceId $env.Playbook2LogicAppResourceId
    Create-AutomationRule -PSVerb Remove -WorkspaceName $env.workspaceName -logicAppResourceId $env.Playbook2LogicAppResourceId
    Create-AutomationRule -PSVerb RemoveViaId -WorkspaceName $env.workspaceName -logicAppResourceId $env.Playbook2LogicAppResourceId
    Create-AutomationRule -PSVerb Update -WorkspaceName $env.workspaceName -logicAppResourceId $env.Playbook2LogicAppResourceId
    Create-AutomationRule -PSVerb UpdateViaId -WorkspaceName $env.workspaceName -logicAppResourceId $env.Playbook2LogicAppResourceId

    #Create Bookmark
    Write-Host "Start to create test bookmark"
    $null = $env.Add(('NewBookmarkName'), ("Newbookmark"+ (RandomString -allChars $false -len 6)))
    $null = $env.Add(('NewBookmarkId'), ((New-Guid).Guid))
    Create-Bookmark -PSVerb Get -WorkspaceName $env.workspaceName
    Create-Bookmark -PSVerb Remove -WorkspaceName $env.workspaceName
    Create-Bookmark -PSVerb RemoveViaId -WorkspaceName $env.workspaceName
    Create-Bookmark -PSVerb Update -WorkspaceName $env.workspaceName
    Create-Bookmark -PSVerb UpdateViaId -WorkspaceName $env.workspaceName
    Create-Bookmark -PSVerb Expand -WorkspaceName $env.workspaceName

    #Bookmark Expansion
    $bookmarkExpansionId = (New-Guid).Guid
    $null = $env.Add('bookmarkExpansionId', $bookmarkExpansionId)

    #Create Bookmark Realtion
    Write-Host "Start to create test bookmark Relation"
    $null = $env.Add('NewBookmarkRelationName', ("NewbookmarkRelation"+ (RandomString -allChars $false -len 6)))
    $null = $env.Add('NewBookmarkRelationId', ((New-Guid).Guid))
    $null = $env.Add('NewbookmarkRelationBookmarkId', ((New-Guid).Guid))
    $null = $env.Add('NewbookmarkRelationBookmarkName', ("NewbookmarkRelationBookmarkName"+ (RandomString -allChars $false -len 6)))
    $null = $env.Add('NewBookmarkRelationIncidentId', ((New-Guid).Guid))
    $null = $env.Add('NewbookmarkRelationIncidentName', ("NewbookmarkRelationIncidentName"+ (RandomString -allChars $false -len 6)))
    Create-BookmarkRelation -PSVerb Get -WorkspaceName $env.workspaceName
    Create-BookmarkRelation -PSVerb Remove -WorkspaceName $env.workspaceName
    Create-BookmarkRelation -PSVerb RemoveViaId -WorkspaceName $env.workspaceName
    Create-BookmarkRelation -PSVerb Update -WorkspaceName $env.workspaceName
    $null = $env.Add('UpdateBookmarkRelationIncidentId2', ((New-Guid).Guid))
    $null = $env.Add('UpdatebookmarkRelationIncidentName2', ("NewbookmarkRelationIncidentName"+ (RandomString -allChars $false -len 6)))
    Create-BookmarkRelation -PSVerb UpdateViaId -WorkspaceName $env.workspaceName
    $null = $env.Add('UpdateViaIdBookmarkRelationIncidentId2', ((New-Guid).Guid))
    $null = $env.Add('UpdateViaIdbookmarkRelationIncidentName2', ("NewbookmarkRelationIncidentName"+ (RandomString -allChars $false -len 6)))


    #Create DataConnector
    Write-Host "Start to create test dataConnector"
    $env.Add('NewDataConnectorId', ((New-Guid).Guid))
    $dataConnectorId = (New-Guid).Guid
    $updateDataConnectorId = (New-Guid).Guid
    $dataConnectorParams = Get-Content .\test\deployment-templates\dataConnector\template.parameters.json | ConvertFrom-Json
    $dataConnectorParams.parameters.dataConnectorId.value = $dataConnectorId
    $dataConnectorParams.parameters.updateDataConnectorId.value = $updateDataConnectorId
    $dataConnectorParams.parameters.workspaceName.value = $workspaceName
    set-content -Path .\test\deployment-templates\dataConnector\template.parameters.json -Value (ConvertTo-Json $dataConnectorParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\dataConnector\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\dataConnector\template.parameters.json).FullName
    $result = New-AzResourceGroupDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name dataConnector -ResourceGroupName $resourceGroupName
    # Workaround - save dataConnectorId even on partial failure (AzureSecurityCenter succeeds when Office365 fails)
    $null = $env.Add('dataConnectorId', $dataConnectorId)
    if($result -and $result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add('updateDataConnectorId', $updateDataConnectorId)
    }
    $null = $env.Add('RemoveDataConnectorId', ((New-Guid).Guid))
    $null = $env.Add('RemoveDataConnectorIdInputObject', ((New-Guid).Guid))


    #Entity
    #imported fake data so nothing needed to create in arm.

    #Create Entity Queriers
    Write-Host "Start to create test entityQuery"
    $null = $env.Add('NewentityQueryActivityName', ("NewentityQueryActivity"+ (RandomString -allChars $false -len 6)))
    $null = $env.Add('NewentityQueryActivityId', ((New-Guid).Guid))
    Create-EntityQuery -PSVerb Get -WorkspaceName $env.workspaceName
    Create-EntityQuery -PSVerb Remove -WorkspaceName $env.workspaceName
    Create-EntityQuery -PSVerb RemoveViaId -WorkspaceName $env.workspaceName
    Create-EntityQuery -PSVerb Update -WorkspaceName $env.workspaceName
    Create-EntityQuery -PSVerb UpdateViaId -WorkspaceName $env.workspaceName

    #Entity Relations
    #System built, can't test without data.  Find way to import data?

    #Entity Timeline
    #System built, can't test without data.  Find way to import data?

    #Create Incident
    Write-Host "Start to create test incident"
    $null = $env.Add('NewincidentName', ("Newincident"+ (RandomString -allChars $false -len 6)))
    $null = $env.Add('NewincidentId', ((New-Guid).Guid))
    Create-Incident -PSVerb Get -WorkspaceName $env.workspaceName
    Create-Incident -PSVerb Remove -WorkspaceName $env.workspaceName
    Create-Incident -PSVerb RemoveViaId -WorkspaceName $env.workspaceName
    Create-Incident -PSVerb Update -WorkspaceName $env.workspaceName
    Create-Incident -PSVerb UpdateViaId -WorkspaceName $env.workspaceName

    #Incident Alert
    #Custom data imported should trigger alert.

    #IncidentBookmark
    #uses Bookmark Relation so no need to create anything new.

    #IncidentComment
    Write-Host "Start to create test incident comment"
    $null = $env.Add('NewincidentCommentName', ("NewincidentComment"+ (RandomString -allChars $false -len 6)))
    $null = $env.Add('NewincidentCommentId', ((New-Guid).Guid))
    $null = $env.Add('NewincidentCommentIncidentName', ("NewincidentCommentIncident"+ (RandomString -allChars $false -len 6)))
    $null = $env.Add('NewincidentCommentIncidentId', ((New-Guid).Guid))
    Create-IncidentComment -PSVerb Get -WorkspaceName $env.workspaceName
    Create-IncidentComment -PSVerb Remove -WorkspaceName $env.workspaceName
    Create-IncidentComment -PSVerb RemoveViaId -WorkspaceName $env.workspaceName
    Create-IncidentComment -PSVerb Update -WorkspaceName $env.workspaceName
    Create-IncidentComment -PSVerb UpdateViaId -WorkspaceName $env.workspaceName

    #IncidentEntity
    #Custom data imported should trigger alert with entity

    #IncidentRelation
    Write-Host "Start to create test incident relation"
    $null = $env.Add('NewincidentRelationName', ("NewincidentRelationName"+ (RandomString -allChars $false -len 6)))
    $null = $env.Add('NewincidentRelationId', ((New-Guid).Guid))
    $null = $env.Add('NewincidentRelationIncidentId', ((New-Guid).Guid))
    $null = $env.Add('NewincidentRelationIncidentName', ("NewincidentRelationIncidentName"+ (RandomString -allChars $false -len 6)))
    $null = $env.Add('NewincidentRelationBookmarkId', ((New-Guid).Guid))
    $null = $env.Add('NewincidentRelationBookmarkName', ("NewincidentRelationBookmarkName"+ (RandomString -allChars $false -len 6)))
    Create-IncidentRelation -PSVerb Get -WorkspaceName $env.workspaceName
    Create-IncidentRelation -PSVerb Remove -WorkspaceName $env.workspaceName
    Create-IncidentRelation -PSVerb RemoveViaId -WorkspaceName $env.workspaceName
    Create-IncidentRelation -PSVerb Update -WorkspaceName $env.workspaceName
    $null = $env.Add('UpdateincidentRelationBookmarkId2', ((New-Guid).Guid))
    $null = $env.Add('UpdateincidentRelationBookmarkName2', ("NewincidentRelationBookmarkName"+ (RandomString -allChars $false -len 6)))
    Create-IncidentRelation -PSVerb UpdateViaId -WorkspaceName $env.workspaceName
    $null = $env.Add('UpdateViaIdincidentRelationBookmarkId2', ((New-Guid).Guid))
    $null = $env.Add('UpdateViaIdincidentRelationBookmarkName2', ("NewincidentRelationBookmarkName"+ (RandomString -allChars $false -len 6)))


    #IncidentTeam
    $null = $env.Add('NewincidentTeamIncidentId', ((New-Guid).Guid))
    $null = $env.Add('NewincidentTeamIncidentName', ("NewincidentTeamIncidentName"+ (RandomString -allChars $false -len 6)))

    #Metadata
    #"sourceId": "azuresentinel.azure-sentinel-solution-zerotrust
    Write-Host "Start to create test MetaData"
    $metadataParams = Get-Content .\test\deployment-templates\metadata\template.parameters.json | ConvertFrom-Json
    $metadataParams.parameters.workspace.value = $workspaceName
    set-content -Path .\test\deployment-templates\metadata\template.parameters.json -Value (ConvertTo-Json $metadataParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\metadata\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\metadata\template.parameters.json).FullName
    $result = New-AzResourceGroupDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name metadata -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add('metadataName', 'azuresentinel.azure-sentinel-solution-zerotrust')
    }

    #OfficeConsent
    #cant pre-create to test.

    #OnboardingState
    #create additonal workspaces in first template

    #Setting
    #Nothing to create

    #SourceControl
    #SourceControlRepository
    #nothing to create

    #ThreatIntelligeneceIndicator
    Write-Host "Start to create test threat intelligence indicator"
    Create-ThreatIntelligenceIndicator -PSVerb Get -WorkspaceName $env.workspaceName -IP "8.8.8.1"
    Create-ThreatIntelligenceIndicator -PSVerb Remove -WorkspaceName $env.workspaceName -IP "8.8.8.2"
    Create-ThreatIntelligenceIndicator -PSVerb RemoveViaId -WorkspaceName $env.workspaceName -IP "8.8.8.3"
    Create-ThreatIntelligenceIndicator -PSVerb Update -WorkspaceName $env.workspaceName -IP "8.8.8.4"
    Create-ThreatIntelligenceIndicator -PSVerb UpdateViaId -WorkspaceName $env.workspaceName -IP "8.8.8.5"

    #ThreatIntelligeneceIndicatorMetric
    #nothing to create

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.resourceGroupName

    #clean template parameter files.
    #$files = Get-ChildItem -Path (Join-Path $PSScriptRoot "deployment-templates") -recurse *.parameters.json
    #foreach($file in $files){
    #    $content = Get-Content $file.FullName | ConvertFrom-Json
    #    foreach($param in $content.parameters.PSObject.Properties){
    #         $param.Value = "null"
    #    }
    #    $content | convertto-json -depth 5 | set-content ($file.FullName)
    #}
}

