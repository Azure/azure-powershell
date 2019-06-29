$exportsPath = Join-Path $PSScriptRoot "..\..\exports"
[string[]]$cmdlets = (Get-ChildItem -Path $exportsPath -Include *.ps1 -Recurse).Name
$cmdlets | %{$global:PSDefaultParameterValues[($_ -replace ".ps1", "") + ":SubscriptionId"] = {(Get-AzContext).Subscription.Id}}
