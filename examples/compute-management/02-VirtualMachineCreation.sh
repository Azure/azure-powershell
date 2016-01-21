#!/bin/env/bash
set -e
printf "\n=== Managing Virtual Machine Creation in Azure Compute ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
az resource group create -n "$groupName" --location "$location"

printf "\n2. Creating a new storage account '%s' in type '%s'.\n" "$storageAccountName" "$storageAccountType"
az storage account create --resourcegroupname "$groupName" --name "$storageAccountName" --location "$location" --type "$storageAccountType"

printf "\n3. Create virtual network.\n"
result=`az vnet create --resourcegroupname "$groupName" --name test --location "$location" --addressprefix "[\"10.0.0.0/16\"]" --subnet "[{\"Name\":\"test\",\"AddressPrefix\":\"10.0.0.0/24\"}]" --force`

contextResult=`az context ls`

subId=`echo $contextResult | jq '.Subscription.SubscriptionId' --raw-output`

subnetId="/subscriptions/$subId/resourceGroups/$groupName/providers/Microsoft.Network/virtualNetworks/test/subnets/test"

printf "\n4. Create network interface with:\r\nsubId='%s' \r\n& \r\nsubnet='$subnetId'.\n" "$subId"
export MSYS_NO_PATHCONV=1
az network interface create --name test --resourcegroupname "$groupName" --location "$location" --subnetId "$subnetId"
export MSYS_NO_PATHCONV=

nicId="/subscriptions/$subId/resourceGroups/$groupName/providers/Microsoft.Network/networkInterfaces/test"

vhdUri="https://$storageAccountName.blob.core.windows.net/$storageAccountName/$storageAccountName.vhd"

vmStr="{\"Name\":\"test\",\"HardwareProfile\":{\"VmSize\":\"Standard_A1\"},\"NetworkProfile\":{\"NetworkInterfaces\":[{\"Id\":\"$nicId\"}]},\"OSProfile\":{\"ComputerName\":\"test\",\"AdminPassword\":\"BaR@1234\",\"AdminUsername\":\"Foo12\"},\"StorageProfile\":{\"ImageReference\":{\"Offer\":\"WindowsServer\",\"Publisher\":\"MicrosoftWindowsServer\",\"Sku\":\"2008-R2-SP1\",\"Version\":\"latest\"},\"OSDisk\":{\"Caching\":\"ReadWrite\",\"CreateOption\":\"FromImage\",\"Name\":\"osDisk\",\"Vhd\":{\"Uri\":\"$vhdUri\"}}}}"

printf "\n5. Create virtual machine with\r\nnicId='%s'\r\nvhdUri='$vhdUri'\r\nvmStr='$vmStr'\n" "$nicId"
az vm create --resourcegroupname "$groupName" --location "$location" --vmprofile "$vmStr"

printf "\n6. Removing resource group: %s.\n" "$groupName"
az resource group rm -n "$groupName" -f