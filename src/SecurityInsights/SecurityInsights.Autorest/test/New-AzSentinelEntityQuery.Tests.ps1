if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelEntityQuery'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelEntityQuery.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelEntityQuery' {
    It 'CreateExpanded' {
        $query = 'let UserConsentToApplication = (Account_Name:string, Account_UPNSuffix:string, Account_AadUserId:string){
            let account_upn = iff(Account_Name != "" and Account_UPNSuffix != "", strcat(Account_Name,"@",Account_UPNSuffix),"" );
            AuditLogs
            | where OperationName == "Consent to application"
            | extend Source_Account_UPNSuffix = tostring(todynamic(InitiatedBy) ["user"]["userPrincipalName"]), Source_Account_AadUserId = tostring(todynamic(InitiatedBy) ["user"]["id"])
            | where (account_upn != "" and account_upn =~ Source_Account_UPNSuffix) 
            or (Account_AadUserId != "" and Account_AadUserId =~ Source_Account_AadUserId)
            | extend Target_CloudApplication_Name = tostring(todynamic(TargetResources)[0]["displayName"]), Target_CloudApplication_AppId = tostring(todynamic(TargetResources)[0]["id"])
            };
            UserConsentToApplication(''{{Account_Name}}'', ''{{Account_UPNSuffix}}'', ''{{Account_AadUserId}}'')  
            | project Target_CloudApplication_AppId, Target_CloudApplication_Name, TimeGenerated'
        $entityQuery = New-AzSentinelEntityQuery -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.NewentityQueryActivityId -Kind Activity -Title "The user consented to OAuth application" `
            -InputEntityType "Account" -Content "The user consented to the OAuth application named {{Target_CloudApplication_Name}} {{Count}} time(s)" `
            -Description "This activity lists user's consents to an OAuth applications." `
            -QueryDefinitionQuery $query
        $entityQuery.InputEntityType | Should -Be "Account"
    }
}
