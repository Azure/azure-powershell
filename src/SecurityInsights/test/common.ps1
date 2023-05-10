# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------
function Start-WaitForData($seconds) {
    $doneDT = (Get-Date).AddSeconds($seconds)
    while($doneDT -gt (Get-Date)) {
        $secondsLeft = $doneDT.Subtract((Get-Date)).TotalSeconds
        $percent = ($seconds - $secondsLeft) / $seconds * 100
        Write-Progress -Activity "Sleeping" -Status "Sleeping..." -SecondsRemaining $secondsLeft -PercentComplete $percent
        [System.Threading.Thread]::Sleep(500)
    }
    Write-Progress -Activity "Sleeping" -Status "Sleeping..." -SecondsRemaining 0 -Completed
}

Function Write-OMSLogfile {
    <#
    .SYNOPSIS
    Inputs a hashtable, date and workspace type and writes it to a Log Analytics Workspace.
    .DESCRIPTION
    Given a  value pair hash table, this function will write the data to an OMS Log Analytics workspace.
    Certain variables, such as Customer ID and Shared Key are specific to the OMS workspace data is being written to.
    This function will not write to multiple OMS workspaces.  BuildSignature and post-analytics function from Microsoft documentation
    at https://learn.microsoft.com/azure/log-analytics/log-analytics-data-collector-api
    .PARAMETER DateTime
    date and time for the log.  DateTime value
    .PARAMETER Type
    Name of the logfile or Log Analytics "Type".  Log Analytics will append _CL at the end of custom logs  String Value
    .PARAMETER LogData
    A series of key, value pairs that will be written to the log.  Log file are unstructured but the key should be consistent
    withing each source.
    .INPUTS
    The parameters of data and time, type and logdata.  Logdata is converted to JSON to submit to Log Analytics.
    .OUTPUTS
    The Function will return the HTTP status code from the Post method.  Status code 200 indicates the request was received.
    .NOTES
    Version:        2.0
    Author:         Travis Roberts
    Creation Date:  7/9/2018
    Purpose/Change: Crating a stand alone function    
    #>
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [datetime]$dateTime,
        [parameter(Mandatory = $true, Position = 1)]
        [string]$type,
        [Parameter(Mandatory = $true, Position = 2)]
        [psobject]$logdata,
        [Parameter(Mandatory = $true, Position = 3)]
        [string]$CustomerID,
        [Parameter(Mandatory = $true, Position = 4)]
        [string]$SharedKey
    )
    Write-Verbose -Message "DateTime: $dateTime"
    Write-Verbose -Message ('DateTimeKind:' + $dateTime.kind)
    Write-Verbose -Message "Type: $type"
    write-Verbose -Message "LogData: $logdata"   

    # Supporting Functions
    # Function to create the auth signature
    Function BuildSignature ($CustomerID, $SharedKey, $Date, $ContentLength, $Method, $ContentType, $Resource) {
        $xheaders = 'x-ms-date:' + $Date
        $stringToHash = $Method + "`n" + $contentLength + "`n" + $contentType + "`n" + $xHeaders + "`n" + $Resource
        $bytesToHash = [text.Encoding]::UTF8.GetBytes($stringToHash)
        $keyBytes = [Convert]::FromBase64String($SharedKey)
        $sha256 = New-Object System.Security.Cryptography.HMACSHA256
        $sha256.key = $keyBytes
        $calculateHash = $sha256.ComputeHash($bytesToHash)
        $encodeHash = [convert]::ToBase64String($calculateHash)
        $authorization = 'SharedKey {0}:{1}' -f $CustomerID, $encodeHash
        return $authorization
    }
    # Function to create and post the request
    Function PostLogAnalyticsData ($CustomerID, $SharedKey, $Body, $Type) {
        $method = "POST"
        $contentType = 'application/json'
        $resource = '/api/logs'
        $rfc1123date = ($dateTime).ToString('r')
        $ContentLength = $Body.Length
        $signature = BuildSignature `
            -customerId $CustomerID `
            -sharedKey $SharedKey `
            -date $rfc1123date `
            -contentLength $ContentLength `
            -method $method `
            -contentType $contentType `
            -resource $resource
        $uri = "https://" + $customerId + ".ods.opinsights.azure.com" + $resource + "?api-version=2016-04-01"
		Write-Output "LA_URI : $uri"
        $headers = @{
            "Authorization"        = $signature;
            "Log-Type"             = $type;
            "x-ms-date"            = $rfc1123date
            "time-generated-field" = $dateTime
        }
        $response = Invoke-WebRequest -Uri $uri -Method $method -ContentType $contentType -Headers $headers -Body $Body -UseBasicParsing
        Write-Verbose -message ('Post Function Return Code ' + $response.statuscode)
        return $response.statuscode
    }   

    # Check if time is UTC, Convert to UTC if not.
    # $dateTime = (Get-Date)
    if ($dateTime.kind.tostring() -ne 'Utc') {
        $dateTime = $dateTime.ToUniversalTime()
        Write-Verbose -Message $dateTime
    }
    #Build the JSON file
    $logMessage = ($logdata | ConvertTo-Json -Depth 20)
    
    #Submit the data
    $returnCode = PostLogAnalyticsData -CustomerID $CustomerID -SharedKey $SharedKey -Body $logMessage -Type $type
    Write-Verbose -Message "Post Statement Return Code $returnCode"
    return $returnCode
}


Function SendToLogA ($eventsTableName, $EventsTableFile, $CustomerId, $SharedKey ) {
    $eventsData = Import-Csv $EventsTableFile
        
    #Test Size; Log A limit is 30MB
    $tempdata = @()
    $tempDataSize = 0
    
    if ((($eventsData |  Convertto-json -depth 20).Length) -gt 25MB) {        
        Write-Host "Upload is over 25MB, needs to be split"									 
        foreach ($record in $eventsData) {            
            $tempdata += $record
            $tempDataSize += ($record | ConvertTo-Json -depth 20).Length
            if ($tempDataSize -gt 25MB) {
                $postLAStatus = Write-OMSLogfile -dateTime (Get-Date) -type $eventsTableName -logdata $tempdata -CustomerID $CustomerId -SharedKey $SharedKey
                write-Host "Sending data = $TempDataSize"
                $tempdata = $null
                $tempdata = @()
                $tempDataSize = 0
            }
        }
        Write-Host "Sending left over data = $Tempdatasize"
        $postLAStatus = Write-OMSLogfile -dateTime (Get-Date) -type $eventsTableName -logdata $tempdata -CustomerID $CustomerId -SharedKey $SharedKey
    }
    Else {          
        $postLAStatus = Write-OMSLogfile -dateTime (Get-Date) -type $eventsTableName -logdata $eventsData -CustomerID $CustomerId -SharedKey $SharedKey        
    }  
    return $postLAStatus
}

Function Prepare-LogATables{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [datetime]$SubscriptionId,
        [parameter(Mandatory = $true, Position = 1)]
        [string]$ResourceGroup,
        [Parameter(Mandatory = $true, Position = 2)]
        [psobject]$WorkspaceName,
        [Parameter(Mandatory = $true, Position = 3)]
        [psobject]$Tables

    )

    ForEach($Table in $Tables){
        $tableParams = @'
{
    "properties": {
        "schema": {
            "name": "LAQueryLogs",
            "columns": [
            ]
        }
    }
}
'@
        Invoke-AzRestMethod -Path "/subscriptions/$SubscriptionId/resourcegroups/$ResourceGroup/providers/microsoft.operationalinsights/workspaces/$WorkspaceName/tables/LAQueryLogs?api-version=2021-03-01-privatepreview" -Method PUT -payload $tableParams

    }
}

Function Create-AlertRule{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$PSVerb,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$workspaceName
    )
    $alertRuleName = $PSVerb + "AlertRule" + (RandomString -allChars $false -len 6)
    $alertRuleId = (New-Guid).Guid
    $alertRuleParams = Get-Content .\test\deployment-templates\alertRule\template.parameters.json | ConvertFrom-Json
    $alertRuleParams.parameters.alertruleName.value = $alertRuleName
    $alertRuleParams.parameters.alertRuleId.value = $alertRuleId
    $alertRuleParams.parameters.workspaceName.value = $workspaceName
    set-content -Path .\test\deployment-templates\alertRule\template.parameters.json -Value (ConvertTo-Json $alertRuleParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\alertRule\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\alertRule\template.parameters.json).FullName
    $result = New-AzDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name ($PSVerb+"AlertRule") -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add(($PSVerb+"AlertRuleName"), $alertRuleName)
        $null = $env.Add(($PSVerb+"AlertRuleId"), $alertRuleId)
    }
}

Function Create-AlertRuleAction{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$PSVerb,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$WorkspaceName,
        [Parameter(Mandatory = $true, Position = 2)]
        [string]$logicAppResourceId,
        [Parameter(Mandatory = $true, Position = 3)]
        [string]$triggerUrl

    )
    $alertRuleActionRuleId = (New-Guid).Guid
    $alertRuleActionRuleName = $PSVerb + "alertRuleActionRuleName" + (RandomString -allChars $false -len 6)
    $alertRuleActionId = (New-Guid).Guid
    $alertRuleActionParams = Get-Content .\test\deployment-templates\alertRuleAction\template.parameters.json | ConvertFrom-Json
    $alertRuleActionParams.parameters.alertRuleActionRuleId.value = $alertRuleActionRuleId
    $alertRuleActionParams.parameters.alertRuleActionRuleName.value = $alertRuleActionRuleName
    $alertRuleActionParams.parameters.alertRuleActionId.value = $alertRuleActionId
    $alertRuleActionParams.parameters.workspaceName.value = $workspaceName
    $alertRuleActionParams.parameters.logicAppResourceId.value = $logicAppResourceId
    $alertRuleActionParams.parameters.triggerUrl.value = $triggerUrl
    set-content -Path .\test\deployment-templates\alertRuleAction\template.parameters.json -Value (ConvertTo-Json $alertRuleActionParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\alertRuleAction\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\alertRuleAction\template.parameters.json).FullName
    $result = New-AzDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name ($PSVerb+"AlertRuleAction") -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add(($PSVerb+"alertRuleActionRuleId"), $alertRuleActionRuleId)
        $null = $env.Add(($PSVerb+"alertRuleActionRuleName"), $alertRuleActionRuleName)
        $null = $env.Add(($PSVerb+"AlertRuleActionId"), $alertRuleActionId)
    }
}

Function Create-AutomationRule{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$PSVerb,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$WorkspaceName,
        [Parameter(Mandatory = $true, Position = 2)]
        [string]$logicAppResourceId

    )
    $automationRuleName = $PSVerb+"AutomationRule"+ (RandomString -allChars $false -len 6)
    $automationRuleId = (New-Guid).Guid
    $automationRuleParams = Get-Content .\test\deployment-templates\automationRule\template.parameters.json | ConvertFrom-Json
    $automationRuleParams.parameters.automationRuleName.value = $automationRuleName
    $automationRuleParams.parameters.automationRuleId.value = $automationRuleId
    $automationRuleParams.parameters.workspaceName.value = $workspaceName
    $automationRuleParams.parameters.logicAppResourceId.value = $logicAppResourceId
    set-content -Path .\test\deployment-templates\automationRule\template.parameters.json -Value (ConvertTo-Json $automationRuleParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\automationRule\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\automationRule\template.parameters.json).FullName
    $result = New-AzDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name ($PSVerb+"AutomationRule") -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add(($PSVerb+'AutomationRule'), $automationRuleName)
        $null = $env.Add(($PSVerb+'AutomationRuleId'), $automationRuleId)
    }
}

Function Create-Bookmark{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$PSVerb,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$WorkspaceName
    )
    $bookmarkName = $PSVerb+"bookmark"+ (RandomString -allChars $false -len 6)
    $bookmarkId = (New-Guid).Guid
    $bookmarkParams = Get-Content .\test\deployment-templates\bookmark\template.parameters.json | ConvertFrom-Json
    $bookmarkParams.parameters.bookmarkName.value = $bookmarkName
    $bookmarkParams.parameters.bookmarkId.value = $bookmarkId
    $bookmarkParams.parameters.workspaceName.value = $workspaceName
    $bookmarkParams.parameters.queryStartTime.value = (get-date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
    $bookmarkParams.parameters.queryEndTime.value = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
    set-content -Path .\test\deployment-templates\bookmark\template.parameters.json -Value (ConvertTo-Json $bookmarkParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\bookmark\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\bookmark\template.parameters.json).FullName
    $result = New-AzDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name ($PSVerb+"bookmark") -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add(($PSVerb+'BookmarkName'), $bookmarkName)
        $null = $env.Add(($PSVerb+'BookmarkId'), $bookmarkId)
    }
    # workaround using API to create bookmarks.
    #$queryStartTime = (get-date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
    #$queryEndTime = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
    #$uri = "https://management.azure.com/subscriptions/"+$env.SubscriptionId+"/resourceGroups/"+$env.resourceGroupName+"/providers/Microsoft.OperationalInsights/workspaces/"+$env.workspaceName+"/providers/Microsoft.SecurityInsights/bookmarks/"+$bookmarkId+"?api-version=2020-01-01"   
    #$token = ConvertTo-SecureString -String ((Get-AzAccessToken).Token) -AsPlainText
    #$body = @{
    #    "properties" = @{
    #            "displayName" = "$bookmarkName"
    #            "labels" = @( "asptest" )
    #            "notes" = "Notes go here"
    #            "query" = "SecurityEvent\n| take 1"
    #            "queryStartTime" = "$queryStartTime"
    #            "queryEndTime" = "$queryEndTime"
    #            "eventTime" = "$queryEndTime"
    #        }
    #}
    #$result = Invoke-RestMethod -Uri $uri -Method PUT -Authentication Bearer -Token $token -Body ($body | ConvertTo-Json)
}

Function Create-BookmarkRelation{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$PSVerb,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$WorkspaceName
    )
    $bookmarkRelationName = $PSVerb + "bookmarkRelation"+ (RandomString -allChars $false -len 6)
    $bookmarkRelationId = (New-Guid).Guid
    $bookmarkRelationBookmarkId = (New-Guid).Guid
    $bookmarkRelationBookmarkName = $PSVerb + "bookmarkRelationBookmarkName"+ (RandomString -allChars $false -len 6)
    $bookmarkRelationIncidentId = (New-Guid).Guid
    $bookmarkRelationIncidentName = $PSVerb + "bookmarkRelationIncidentName"+ (RandomString -allChars $false -len 6)
    $bookmarkRelationParams = Get-Content .\test\deployment-templates\bookmarkRelation\template.parameters.json | ConvertFrom-Json
    $bookmarkRelationParams.parameters.bookmarkRelationId.value = $bookmarkRelationId
    $bookmarkRelationParams.parameters.bookmarkRelationBookmarkId.value = $bookmarkRelationBookmarkId
    $bookmarkRelationParams.parameters.bookmarkRelationBookmarkName.value = $bookmarkRelationBookmarkName
    $bookmarkRelationParams.parameters.queryStartTime.value = (get-date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
    $bookmarkRelationParams.parameters.queryEndTime.value = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
    $bookmarkRelationParams.parameters.bookmarkRelationIncidentId.value = $bookmarkRelationIncidentId
    $bookmarkRelationParams.parameters.bookmarkRelationIncidentName.value = $bookmarkRelationIncidentName
    $bookmarkRelationParams.parameters.workspaceName.value = $workspaceName
    set-content -Path .\test\deployment-templates\bookmarkRelation\template.parameters.json -Value (ConvertTo-Json $bookmarkRelationParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\bookmarkRelation\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\bookmarkRelation\template.parameters.json).FullName
    $result = New-AzDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name ($PSVerb+"BookmarkRelation") -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add(($PSVerb+'BookmarkRelationName'), $bookmarkRelationName)
        $null = $env.Add(($PSVerb+'BookmarkRelationId'), $bookmarkRelationId)
        $null = $env.Add(($PSVerb+'bookmarkRelationBookmarkId'), $bookmarkRelationBookmarkId)
        $null = $env.Add(($PSVerb+'bookmarkRelationBookmarkName'), $bookmarkRelationBookmarkName)
        $null = $env.Add(($PSVerb+'BookmarkRelationIncidentId'), $bookmarkRelationIncidentId)
        $null = $env.Add(($PSVerb+'bookmarkRelationIncidentName'), $bookmarkRelationIncidentName)
    }
}
 
Function Create-EntityQuery{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$PSVerb,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$WorkspaceName
    )
    $entityQueryActivityName = $PSVerb+"entityQueryActivity"+ (RandomString -allChars $false -len 6)
    $entityQueryActivityId = (New-Guid).Guid
    $entityQueryParams = Get-Content .\test\deployment-templates\entityQuery\template.parameters.json | ConvertFrom-Json
    $entityQueryParams.parameters.entityQueryActivityId.value = $entityQueryActivityId
    $entityQueryParams.parameters.workspaceName.value = $workspaceName
    set-content -Path .\test\deployment-templates\entityQuery\template.parameters.json -Value (ConvertTo-Json $entityQueryParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\entityQuery\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\entityQuery\template.parameters.json).FullName
    # Bug Sent to Aviv
    $result = New-AzDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name ($PSVerb+"entityQuery") -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add(($PSVerb+'entityQueryActivityName'), $entityQueryActivityName)
        $null = $env.Add(($PSVerb+'entityQueryActivityId'), $entityQueryActivityId)              
    }
}

Function Create-Incident{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$PSVerb,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$WorkspaceName
    )
    $incidentName = $PSVerb+"incident"+ (RandomString -allChars $false -len 6)
    $incidentId = (New-Guid).Guid
    $incidentParams = Get-Content .\test\deployment-templates\incident\template.parameters.json | ConvertFrom-Json
    $incidentParams.parameters.incidentId.value = $incidentId
    $incidentParams.parameters.workspaceName.value = $workspaceName
    set-content -Path .\test\deployment-templates\incident\template.parameters.json -Value (ConvertTo-Json $incidentParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\incident\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\incident\template.parameters.json).FullName
    $result = New-AzDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name ($PSVerb+"incident") -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add(($PSVerb+'incidentName'), $incidentName)
        $null = $env.Add(($PSVerb+'incidentId'), $incidentId)   
    }
}

Function Create-IncidentComment{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$PSVerb,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$WorkspaceName
    )
    $incidentCommentName = $PSVerb+"incidentComment"+ (RandomString -allChars $false -len 6)
    $incidentCommentId = (New-Guid).Guid
    $incidentCommentIncidentId = (New-Guid).Guid
    $incidentCommentParams = Get-Content .\test\deployment-templates\incidentComment\template.parameters.json | ConvertFrom-Json
    $incidentCommentParams.parameters.incidentCommentIncidentId.value = $incidentCommentIncidentId
    $incidentCommentParams.parameters.incidentCommentId.value = $incidentCommentId
    $incidentCommentParams.parameters.incidentCommentName.value = $incidentCommentName
    $incidentCommentParams.parameters.workspaceName.value = $workspaceName
    set-content -Path .\test\deployment-templates\incidentComment\template.parameters.json -Value (ConvertTo-Json $incidentCommentParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\incidentComment\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\incidentComment\template.parameters.json).FullName
    $result = New-AzDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name ($PSVerb+"incidentComment") -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add(($PSVerb+'incidentCommentName'), $incidentCommentName)
        $null = $env.Add(($PSVerb+'incidentCommentId'), $incidentCommentId)
        $null = $env.Add(($PSVerb+'incidentCommentIncidentId'), $incidentCommentIncidentId)
    }
}

Function Create-IncidentRelation{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$PSVerb,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$WorkspaceName
    )
    $incidentRelationName = $PSVerb+"incidentRelationName"+ (RandomString -allChars $false -len 6)
    $incidentRelationId = (New-Guid).Guid
    $incidentRelationIncidentName = $PSVerb+"incidentRelationIncidentName"+ (RandomString -allChars $false -len 6)
    $incidentRelationIncidentId = (New-Guid).Guid
    $incidentRelationBookmarkName = $PSVerb+"incidentRelationBookmarkName"+ (RandomString -allChars $false -len 6)
    $incidentRelationBookmarkId = (New-Guid).Guid
    $incidentRelationParams = Get-Content .\test\deployment-templates\incidentRelation\template.parameters.json | ConvertFrom-Json
    $incidentRelationParams.parameters.incidentRelationBookmarkId.value = $incidentRelationBookmarkId
    $incidentRelationParams.parameters.incidentRelationBookmarkName.value = $incidentRelationBookmarkName
    $incidentRelationParams.parameters.incidentRelationIncidentId.value = $incidentRelationIncidentId
    $incidentRelationParams.parameters.incidentRelationIncidentName.value = $incidentRelationIncidentName
    $incidentRelationParams.parameters.queryStartTime.value = (get-date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
    $incidentRelationParams.parameters.queryEndTime.value = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
    $incidentRelationParams.parameters.incidentRelationId.value = $incidentRelationId
    $incidentRelationParams.parameters.workspaceName.value = $workspaceName
    set-content -Path .\test\deployment-templates\incidentRelation\template.parameters.json -Value (ConvertTo-Json $incidentRelationParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\incidentRelation\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\incidentRelation\template.parameters.json).FullName
    #Bug due to bookmark
    $result = New-AzDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name ($PSVerb+"incidentRelation") -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add(($PSVerb+'incidentRelationName'), $incidentRelationName)
        $null = $env.Add(($PSVerb+'incidentRelationId'), $incidentRelationId)
        $null = $env.Add(($PSVerb+'incidentRelationIncidentId'), $incidentRelationIncidentId)
        $null = $env.Add(($PSVerb+'incidentRelationIncidentName'), $incidentRelationIncidentName)
        $null = $env.Add(($PSVerb+'incidentRelationBookmarkId'), $incidentRelationBookmarkId)
        $null = $env.Add(($PSVerb+'incidentRelationBookmarkName'), $incidentRelationBookmarkName)
    }
}

Function Create-SourceControl{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$PSVerb,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$WorkspaceName,
        [Parameter(Mandatory = $true, Position = 2)]
        [string]$Url
    )
    $sourceControlName = $PSVerb+"sourceControl"+ (RandomString -allChars $false -len 6)
    $sourceControlId = (New-Guid).Guid
    $sourceControlParams = Get-Content .\test\deployment-templates\sourceControl\template.parameters.json | ConvertFrom-Json
    $sourceControlParams.parameters.sourceControlId.value = $sourceControlId
    $sourceControlParams.parameters.sourceControlName.value = $sourceControlName
    $sourceControlParams.parameters.url.value = $url
    $sourceControlParams.parameters.workspaceName.value = $workspaceName
    set-content -Path .\test\deployment-templates\sourceControl\template.parameters.json -Value (ConvertTo-Json $sourceControlParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\sourceControl\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\sourceControl\template.parameters.json).FullName
    $result = New-AzDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name ($PSVerb+"sourceControl") -ResourceGroupName $resourceGroupName
    if($result.ProvisioningState -eq "Succeeded"){
        $null = $env.Add(($PSVerb+'sourceControlName'), $sourceControlName)
        $null = $env.Add(($PSVerb+'sourceControlId'), $sourceControlId)
        $null = $env.Add(($PSVerb+'sourceControlurl'), $url)
    }
}

Function Create-ThreatIntelligenceIndicator{
    [cmdletbinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$PSVerb,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$WorkspaceName,
        [Parameter(Mandatory = $true, Position = 2)]
        [string]$IP 
    )
    $threatIntelligenceIndicatorName = $PSVerb+"threatIntelligenceIndicator"+ (RandomString -allChars $false -len 6)
    $threatIntelligenceIndicatorId = (New-Guid).Guid
    $threatIntelligenceIndicatorDate = (get-date).ToUniversalTime() | Get-Date -Format "ddd, dd MMM yyyy hh:00:00 'GMT'"
    $threatIntelligenceIndicatorParams = Get-Content .\test\deployment-templates\threatIntelligenceIndicator\template.parameters.json | ConvertFrom-Json
    $threatIntelligenceIndicatorParams.parameters.threatIntelligenceIndicatorId.value = $threatIntelligenceIndicatorId
    $threatIntelligenceIndicatorParams.parameters.threatIntelligenceIndicatorName.value = $threatIntelligenceIndicatorName
    $threatIntelligenceIndicatorParams.parameters.ip.value = $IP
    $threatIntelligenceIndicatorParams.parameters.threatIntelligenceIndicatorDate.value = $threatIntelligenceIndicatorDate
    $threatIntelligenceIndicatorParams.parameters.workspaceName.value = $workspaceName
    set-content -Path .\test\deployment-templates\threatIntelligenceIndicator\template.parameters.json -Value (ConvertTo-Json $threatIntelligenceIndicatorParams)
    $TemplateFile = (Get-ChildItem $TemplatePath\threatIntelligenceIndicator\template.json).FullName
    $TemplateParametersFile = (Get-ChildItem $TemplatePath\threatIntelligenceIndicator\template.parameters.json).FullName
    #ARM doesnt work use API
    #$result = New-AzDeployment -Mode Incremental -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParametersFile -Name ($PSVerb+"threatIntelligenceIndicator") -ResourceGroupName $resourceGroupName
    #if($result.ProvisioningState -eq "Succeeded"){
    #    $null = $env.Add(($PSVerb+'threatIntelligenceIndicatorName'), $threatIntelligenceIndicatorName)
    #    $null = $env.Add(($PSVerb+'threatIntelligenceIndicatorId'), $threatIntelligenceIndicatorId)
    #    $null = $env.Add(($PSVerb+'threatIntelligenceIndicatorIP'), $IP)
    #}
    $tiToken = (Get-AzAccessToken).Token
    $tiHeaders = @{
        Authorization="Bearer $tiToken"
        Content='application/json'
    }
    $tiBody = @{
            "kind" = "indicator"
            "properties" = @{
                "confidence" = 0
                "threatTypes"= @(
                    "unknown"
                )
                "displayName" = "$threatIntelligenceIndicatorName"
                "pattern" = "[ipv4-addr:value = '$ip']"
                "patternType" = "ipv4-addr"
                "revoked" = $false
                "validFrom" = "$threatIntelligenceIndicatorDate"
                "validUntil" = $null
                "source" = "Azure Sentinel"
                "threatIntelligenceTags" = @()
            }
    }
    $tiBody = $tiBody | Convertto-json
    $uri = "https://management.azure.com/subscriptions/"+ $env.SubscriptionId + "/resourceGroups/" + $env.resourceGroupName + "/providers/Microsoft.OperationalInsights/workspaces/" + $env.workspaceName + "/providers/Microsoft.SecurityInsights/threatIntelligence/main/createIndicator?api-version=2021-09-01-preview"
    $indicator = Invoke-RestMethod -Method POST -Uri $Uri -Headers $tiHeaders -body $tiBody -ContentType Application/json
    #if($indicator.Kind -eq "indicator"){
        $null = $env.Add(($PSVerb+'threatIntelligenceIndicatorName'), $threatIntelligenceIndicatorName)
        $null = $env.Add(($PSVerb+'threatIntelligenceIndicatorId'), ($indicator.Name))
        $null = $env.Add(($PSVerb+'threatIntelligenceIndicatorIP'), $IP)
    #}
}