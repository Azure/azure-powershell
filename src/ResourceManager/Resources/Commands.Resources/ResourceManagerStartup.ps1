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

@{
    # Sql aliases
    "Get-AzureSqlDatabaseServerAuditingPolicy" = "Get-AzureSqlServerAuditingPolicy";
    "Remove-AzureSqlDatabaseServerAuditing" = "Remove-AzureSqlServerAuditing";
    "Set-AzureSqlDatabaseServerAuditingPolicy" = "Set-AzureSqlServerAuditingPolicy";
    "Use-AzureSqlDatabaseServerAuditingPolicy" = "Use-AzureSqlServerAuditingPolicy";

    # Storage aliases
    "Get-AzureStorageContainerAcl" = "Get-AzureStorageContainer";
    "Start-CopyAzureStorageBlob" = "Start-AzureStorageBlobCopy";
    "Stop-CopyAzureStorageBlob" = "Stop-AzureStorageBlobCopy";
}.GetEnumerator() | Select @{Name='Name'; Expression={$_.Key}}, @{Name='Value'; Expression={$_.Value}} | New-Alias -Description "AzureAlias"


# Authorization script commandlet that builds on top of existing Insights comandlets. 
# This commandlet gets all events for the "Microsoft.Authorization" resource provider by calling the "Get-AzureResourceProviderLog" commandlet

function Get-AzureAuthorizationChangeLog { 
 	[CmdletBinding()] 
 	param(  
 		[parameter(Mandatory=$false, ValueFromPipelineByPropertyName=$true, HelpMessage = "The start time. Optional
			 If both StartTime and EndTime are not provided, defaults to querying for the past 1 hour. Maximum allowed difference in StartTime and EndTime is 15 days")] 
 		[DateTime] $StartTime,

		[parameter(Mandatory=$false, ValueFromPipelineByPropertyName=$true, HelpMessage = "The end time. Optional. 
			If both StartTime and EndTime are not provided, defaults to querying for the past 1 hour. Maximum allowed difference in StartTime and EndTime is 15 days")] 
 		[DateTime] $EndTime
 	) 
 	PROCESS { 
		 # Get all events for the "Microsoft.Authorization" provider by calling the Insights commandlet
		 $events = Get-AzureResourceProviderLog -ResourceProvider "Microsoft.Authorization" -DetailedOutput -StartTime $StartTime -EndTime $EndTime
			 
		 $startEvents = @{}
         $endEvents = @{}
         $offlineEvents = @()

		 # StartEvents and EndEvents will contain matching pairs of logs for when role assignments (and definitions) were created or deleted. 
		 # i.e. A PUT on roleassignments will have a Start-End event combination and a DELETE on roleassignments will have another Start-End event combination
		 $startEvents = $events | ? { $_.httpRequest -and $_.Status -ieq "Started" }
		 $events | ? { $_.httpRequest -and $_.Status -ne "Started" } | % { $endEvents[$_.OperationId] = $_ }
		 # This filters non-RBAC events like classic administrator write or delete
		 $events | ? { $_.httpRequest -eq $null } | % { $offlineEvents += $_ } 

         $output = @()

		 # Get all role definitions once from the service and cache to use for all 'startevents'
		 $azureRoleDefinitionCache = @{}
		 Get-AzureRoleDefinition | % { $azureRoleDefinitionCache[$_.Id] = $_ }

		 $principalDetailsCache = @{}

		 # Process StartEvents
		 # Find matching EndEvents that succeeded and relating to role assignments only
		 $startEvents | ? { $endEvents.ContainsKey($_.OperationId) `
			 -and $endEvents[$_.OperationId] -ne $null `
			 -and $endevents[$_.OperationId].OperationName.StartsWith("Microsoft.Authorization/roleAssignments", [System.StringComparison]::OrdinalIgnoreCase)  `
			 -and $endEvents[$_.OperationId].Status -ieq "Succeeded"} |  % {
       
		 $endEvent = $endEvents[$_.OperationId];
		
         # Create the output structure
         $out = "" | select Timestamp, Caller, Action, PrincipalId, PrincipalName, PrincipalType, Scope, ScopeName, ScopeType, RoleDefinitionId, RoleName
         $out.Timestamp = $endEvent.EventTimestamp
         $out.Caller = $_.Caller
         if ($_.HttpRequest.Method -ieq "PUT") {
            $out.Action = "Granted"
            if ($_.Properties.Content.ContainsKey("requestbody")) {
                $messageBody = ConvertFrom-Json $_.Properties.Content["requestbody"]
            }
			 
		  $out.Scope =  $_.Authorization.Scope
        } 
		elseif ($_.HttpRequest.Method -ieq "DELETE") {
            $out.Action = "Revoked"
            if ($endEvent.Properties.Content.ContainsKey("responseBody")) {
                $messageBody = ConvertFrom-Json $endEvent.Properties.Content["responseBody"]
            }
        }

		if ($messageBody) {
            
			$out.PrincipalId = $messageBody.properties.principalId
			if ($out.PrincipalId -ne $null) { 
				$principalDetails = Get-PrincipalDetails $out.PrincipalId ([REF]$principalDetailsCache)
			    $out.PrincipalName = $principalDetails.Name
                $out.PrincipalType = $principalDetails.Type
            }

			if ([string]::IsNullOrEmpty($out.Scope)) { $out.Scope = $messageBody.properties.Scope }
           	if ($out.Scope -ne $null) {
			    $resourceDetails = Get-ResourceDetails $out.Scope
			    $out.ScopeName = $resourceDetails.Name
                $out.ScopeType = $resourceDetails.Type
			}

            $out.RoleDefinitionId = $messageBody.properties.roleDefinitionId
			if ($out.RoleDefinitionId -ne $null) {
			    if ($azureRoleDefinitionCache[$out.RoleDefinitionId]) {
		            $out.RoleName = $azureRoleDefinitionCache[$out.RoleDefinitionId].Name
		        } else {
				    $out.RoleName = ""
                }
		    }
		}
        $output += $out
    } # start event processing complete

    # Filter classic admins events
    $offlineEvents | % {
        if($_.Status -ne $null -and $_.Status -ieq "Succeeded" -and $_.OperationName -ne $null -and $_.operationName.StartsWith("Microsoft.Authorization/ClassicAdministrators", [System.StringComparison]::OrdinalIgnoreCase)) {
            
			$out = "" | select Timestamp, Caller, Action, PrincipalId, PrincipalName, PrincipalType, Scope, ScopeName, ScopeType, RoleDefinitionId, RoleName
			$out.Timestamp = $_.EventTimestamp
            $out.Caller = "Subscription Admin"

		    if($_.operationName -ieq "Microsoft.Authorization/ClassicAdministrators/write"){
        	    $out.Action = "Granted"
		    } 
			elseif($_.operationName -ieq "Microsoft.Authorization/ClassicAdministrators/delete"){
			    $out.Action = "Revoked"
		    }

			$out.RoleDefinitionId = $null
			$out.PrincipalId = $null
			$out.PrincipalType = "User"
			$out.Scope = "/subscriptions/" + $_.SubscriptionId
			$out.ScopeType = "Subscription"
			$out.ScopeName = $_.SubscriptionId
                                
			if($_.Properties -ne $null){
				$out.PrincipalName = $_.Properties.Content["adminEmail"]
				$out.RoleName = "Classic " + $_.Properties.Content["adminType"]
			}
			         
			$output += $out
        }
    } # end offline events

	$output | Sort Timestamp
} 
} # End commandlet

# Helper functions
# Resolve a principal. If the principal's object id was encountered in the principals resolved so far, return principalDetails from the cache. 
# Else make a Grpah call and add that principal to cache of known principals
function Get-PrincipalDetails($principalId, [REF]$principalDetailsCache)
{	
    if($principalDetailsCache.Value.ContainsKey($principalId)) {
		return $principalDetailsCache.Value[$principalId]
	}

	$principalDetails = "" | select Name, Type
	$user = Get-AzureADUser -ObjectId $principalId
    if ($user) {
		$principalDetails.Name = $user.DisplayName
        $principalDetails.Type = "User"    
    } else {
        $group = Get-AzureADGroup -ObjectId $principalId
        if ($group) {
            $principalDetails.Name = $group.DisplayName
            $principalDetails.Type = "Group"        
        } else {
            $servicePrincipal = Get-AzureADServicePrincipal -objectId $principalId
            if ($servicePrincipal) {
                $principalDetails.Name = $servicePrincipal.DisplayName
                $principalDetails.Type = "Service Principal"                        
            }
        }
    }

    $principalDetailsCache.Value.Add($principalId, $principalDetails);

    $principalDetails
} 

# Get resource details from scope
function Get-ResourceDetails($scope)
{
    $resourceDetails = "" | select Name, Type
    $scopeParts = $scope.Split('/', [System.StringSplitOptions]::RemoveEmptyEntries)
	$len = $scopeParts.Length

	if ($len -gt 0 -and $len -le 2 -and $scope.ToLower().Contains("subscriptions"))	{
		$resourceDetails.Type = "Subscription"
		$resourceDetails.Name  = $scopeParts[1]
	}
	elseif ($len -gt 0 -and $len -le 4 -and $scope.ToLower().Contains("resourcegroups")) {
		$resourceDetails.Type = "Resource Group"
		$resourceDetails.Name  = $scopeParts[3]
	}
	elseif ($len -ge 6 -and $scope.ToLower().Contains("providers"))	{
		$resourceDetails.Type = "Resource"
		$resourceDetails.Name  = $scopeParts[$len -1]
	}

    $resourceDetails
}
 
