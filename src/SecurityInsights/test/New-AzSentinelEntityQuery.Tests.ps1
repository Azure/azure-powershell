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
        $requiredInputFieldsSet = @(
            @("Account_Name","Account_UPNSuffix"),
            @("Account_AadUserId")
        )
        $entityQuery = New-AzSentinelEntityQuery -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -EntityQueryId ((New-Guid).Guid) -Kind Activity -Title "The user consented to OAuth application" `
            -InputEntityType "Account" -Content "The user consented to the OAuth application named {{Target_CloudApplication_Name}} {{Count}} time(s)" `
            -Description "This activity lists user's consents to an OAuth applications." `
            -QueryDefinitionQuery "let UserConsentToApplication = (Account_Name:string, Account_UPNSuffix:string, Account_AadUserId:string){\nlet account_upn = iff(Account_Name != \"\" and Account_UPNSuffix != \"\"\n, strcat(Account_Name,\"@\",Account_UPNSuffix)\n,\"\" );\nAuditLogs\n| where OperationName == \"Consent to application\"\n| extend Source_Account_UPNSuffix = tostring(todynamic(InitiatedBy) [\"user\"][\"userPrincipalName\"]), Source_Account_AadUserId = tostring(todynamic(InitiatedBy) [\"user\"][\"id\"])\n| where (account_upn != \"\" and account_upn =~ Source_Account_UPNSuffix) \nor (Account_AadUserId != \"\" and Account_AadUserId =~ Source_Account_AadUserId)\n| extend Target_CloudApplication_Name = tostring(todynamic(TargetResources)[0][\"displayName\"]), Target_CloudApplication_AppId = tostring(todynamic(TargetResources)[0][\"id\"])\n};\nUserConsentToApplication('{{Account_Name}}', '{{Account_UPNSuffix}}', '{{Account_AadUserId}}')  \n| project Target_CloudApplication_AppId, Target_CloudApplication_Name, TimeGenerated" `
            -RequiredInputFieldsSet $requiredInputFieldsSet
        $entityQuery.InputEntityType | Should -Be "Account"
    }
}
