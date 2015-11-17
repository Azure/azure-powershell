## Powershell commandlet execution for MAM
write-host "###########################################################"
write-host "MAM Powershell Cmdlet execution DEMO.." -ForegroundColor Cyan
write-host "###########################################################"

write-host "-----------------------------------------------------------"
write-host "Demo POLICIES.." -ForegroundColor Red
write-host "-----------------------------------------------------------"

write-host "Creating a new Android Policy.." -ForegroundColor Yellow
write-host "New-AzureRmIntuneAndroidMAMPolicy -FriendlyName AndroidTestPolicy" -ForegroundColor DarkYellow
$p = New-AzureRmIntuneAndroidMAMPolicy -FriendlyName AndroidTestPolicy

write-host "Policy created with properties";
write-host "Policy name:" -ForegroundColor Green
$p.name
write-host "Policy properties:" -ForegroundColor Green
$p;

write-host "Patching the policy" -ForegroundColor Yellow;
$p = Set-AzureRmIntuneAndroidMAMPolicy -Name $p.Name -AllowDataTransferToApps allApps -FriendlyName "New Android Policy Patched"
write-host "Updated policy properties:" -ForegroundColor Green
$p;

write-host "-----------------------------------------------------------"
write-host "Demo Apps linking to POLICIES.." -ForegroundColor Red
write-host "-----------------------------------------------------------"

write-host "Get Android Apps available"  -ForegroundColor Yellow;
$apps = Get-AzureRmIntuneAndroidMAMApp;
$apps;

write-host "Add app with name:" $apps[0].Name  " to policy with name:"  $p.name  -ForegroundColor Yellow;
Add-AzureRmIntuneAndroidMAMPolicyApp -Name $p.name -AppName $apps[0].Name;

write-host "Add app with name:" $apps[1].Name  " to policy with name:"  $p.name  -ForegroundColor Yellow;
Add-AzureRmIntuneAndroidMAMPolicyApp -Name $p.name -AppName $apps[1].Name;

write-host "Get Apps added for the policy"  -ForegroundColor Yellow;
$apps = Get-AzureRmIntuneAndroidMAMPolicyApp -Name $p.Name
write-host "query apps added for the policy:" -ForegroundColor Green
$apps;

write-host "Get the updated policy" -ForegroundColor Yellow;
$p = Get-AzureRmIntuneAndroidMAMPolicy -Name $p.Name
write-host "Updated policy properties:" -ForegroundColor Green
$p;

write-host "Unlink app with name:" $apps[1].Name  " from policy with name:"  $p.name  -ForegroundColor Yellow;
Remove-AzureRmIntuneAndroidMAMPolicyApp -Name $p.name -AppName $apps[1].Name;

write-host "Get the updated policy" -ForegroundColor Yellow;
$p = Get-AzureRmIntuneAndroidMAMPolicy -Name $p.Name
write-host "Updated policy properties:" -ForegroundColor Green
$p;

write-host "-----------------------------------------------------------"
write-host "Demo Groups linking to POLICIES.." -ForegroundColor Red
write-host "-----------------------------------------------------------"

write-host "Get AAD groups in the environment"  -ForegroundColor Yellow;
$groups = @(Get-AzureRmADGroup);

write-host "Add AAD group with id:" $groups[0].Id " to policy with name:"  $p.name  -ForegroundColor Yellow;
Add-AzureRmIntuneAndroidMAMPolicyGroup -Name $p.Name -GroupName $groups[0].Id

write-host "Get the updated policy" -ForegroundColor Yellow;
$p = Get-AzureRmIntuneAndroidMAMPolicy -Name $p.Name
write-host "Updated policy properties:" -ForegroundColor Green
$p;

write-host "Remove AAD group with id:" $groups[0].Id " from policy with name:"  $p.name  -ForegroundColor Yellow;
Remove-AzureRmIntuneAndroidMAMPolicyGroup -Name $p.Name -GroupName $groups[0].Id

write-host "Get the updated policy" -ForegroundColor Yellow;
$p = Get-AzureRmIntuneAndroidMAMPolicy -Name $p.Name
write-host "Updated policy properties:" -ForegroundColor Green
$p;

write-host "Remove the policy" -ForegroundColor Yellow;
Remove-AzureRmIntuneAndroidMAMPolicy -Name $p.Name