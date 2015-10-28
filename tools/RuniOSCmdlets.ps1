## Powershell commandlet execution for MAM
write-host "###########################################################"
write-host "MAM Powershell Cmdlet execution DEMO.." -ForegroundColor Cyan
write-host "###########################################################"

write-host "-----------------------------------------------------------"
write-host "Demo POLICIES.." -ForegroundColor Red
write-host "-----------------------------------------------------------"

write-host "Creating a new iOS Policy.." -ForegroundColor Yellow
write-host "New-AzureRmIntuneiOSMAMPolicy -FriendlyName iOSTestPolicy" -ForegroundColor DarkYellow
$p = New-AzureRmIntuneiOSMAMPolicy -FriendlyName iOSTestPolicy

write-host "Policy created with properties";
write-host "Policy name:" -ForegroundColor Green
$p.name
write-host "Policy properties:" -ForegroundColor Green
$p.Properties;

write-host "Patching the policy" -ForegroundColor Yellow;
$p = Set-AzureRmIntuneiOSMAMPolicy -Name $p.Name -AllowDataTransferToApps allApps -FriendlyName "New iOS Policy Patched"
write-host "Updated policy properties:" -ForegroundColor Green
$p.Properties;

write-host "-----------------------------------------------------------"
write-host "Demo Apps linking to POLICIES.." -ForegroundColor Red
write-host "-----------------------------------------------------------"

write-host "Get iOS Apps available"  -ForegroundColor Yellow;
$apps = Get-AzureRmIntuneiOSMAMApp;
$apps;

write-host "Add app with name:" $apps[0].Name  " to policy with name:"  $p.name  -ForegroundColor Yellow;
Add-AzureRmIntuneiOSMAMPolicyApp -Name $p.name -AppName $apps[0].Name;

write-host "Add app with name:" $apps[1].Name  " to policy with name:"  $p.name  -ForegroundColor Yellow;
Add-AzureRmIntuneiOSMAMPolicyApp -Name $p.name -AppName $apps[1].Name;

write-host "Get Apps added for the policy"  -ForegroundColor Yellow;
$apps = Get-AzureRmIntuneiOSMAMPolicyApp -Name $p.Name
write-host "query apps added for the policy:" -ForegroundColor Green
$apps;

write-host "Get the updated policy" -ForegroundColor Yellow;
$p = Get-AzureRmIntuneiOSMAMPolicy -Name $p.Name
write-host "Updated policy properties:" -ForegroundColor Green
$p.Properties;

write-host "Unlink app with name:" $apps[1].Name  " from policy with name:"  $p.name  -ForegroundColor Yellow;
Remove-AzureRmIntuneiOSMAMPolicyApp -Name $p.name -AppName $apps[1].Name;

write-host "Get the updated policy" -ForegroundColor Yellow;
$p = Get-AzureRmIntuneiOSMAMPolicy -Name $p.Name
write-host "Updated policy properties:" -ForegroundColor Green
$p.Properties;

write-host "-----------------------------------------------------------"
write-host "Demo Groups linking to POLICIES.." -ForegroundColor Red
write-host "-----------------------------------------------------------"

write-host "Get AAD groups in the environment"  -ForegroundColor Yellow;
$groups = @(Get-AzureRmADGroup);

write-host "Add AAD group with id:" $groups[0].Id " to policy with name:"  $p.name  -ForegroundColor Yellow;
Add-AzureRmIntuneiOSMAMPolicyGroup -Name $p.Name -GroupName $groups[0].Id

write-host "Get the updated policy" -ForegroundColor Yellow;
$p = Get-AzureRmIntuneiOSMAMPolicy -Name $p.Name
write-host "Updated policy properties:" -ForegroundColor Green
$p.Properties;

write-host "Remove AAD group with id:" $groups[0].Id " from policy with name:"  $p.name  -ForegroundColor Yellow;
Remove-AzureRmIntuneiOSMAMPolicyGroup -Name $p.Name -GroupName $groups[0].Id

write-host "Get the updated policy" -ForegroundColor Yellow;
$p = Get-AzureRmIntuneiOSMAMPolicy -Name $p.Name
write-host "Updated policy properties:" -ForegroundColor Green
$p.Properties;