#!/bin/bash
set -e
printf "\n=== Managing Virtual Machine Creation in Azure Compute ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
azure group create -n "$groupName" --location "$location"

printf "\n2. Creating a new storage account '%s' in type '%s'.\n" "$storageAccountName" "$storageAccountType"
azure storage account new --resourcegroupname "$groupName" --name "$storageAccountName" --location "$location" --type "$storageAccountType"

printf "\n3. Create virtual network.\n"
result=`azure virtual network create --resourcegroupname "$groupName" --name test --location "$location" --addressprefix "[\"10.0.0.0/16\"]" --subnet "[{\"Name\":\"test\",\"AddressPrefix\":\"10.0.0.0/24\"}]" --force`

contextResult=`azure context get`

subId=`echo $contextResult | jq '.Subscription.SubscriptionId' --raw-output`

subnetId="/subscriptions/$subId/resourceGroups/$groupName/providers/Microsoft.Network/virtualNetworks/test/subnets/test"

echo -n "$subnetId" > "$BASEDIR/$groupName.subnetIdFile"

printf "\n4. Create network interface with:\r\nsubId='%s' \r\n& \r\nsubnetId='$subnetId'.\n" "$subId"
azure network interface create --name test --resourcegroupname "$groupName" --location "$location" --subnetid @"$BASEDIR/$groupName.subnetIdFile"

rm -f "$BASEDIR/$groupName.subnetIdFile"

nicId="/subscriptions/$subId/resourceGroups/$groupName/providers/Microsoft.Network/networkInterfaces/test"

vhdUri="https://$storageAccountName.blob.core.windows.net/$storageAccountName/$storageAccountName.vhd"

vmStr="{\"Name\":\"test\",\"HardwareProfile\":{\"VmSize\":\"Standard_A1\"},\"NetworkProfile\":{\"NetworkInterfaces\":[{\"Id\":\"$nicId\"}]},\"OSProfile\":{\"ComputerName\":\"test\",\"AdminPassword\":\"BaR@1234\",\"AdminUsername\":\"Foo12\"},\"StorageProfile\":{\"ImageReference\":{\"Offer\":\"WindowsServer\",\"Publisher\":\"MicrosoftWindowsServer\",\"Sku\":\"2008-R2-SP1\",\"Version\":\"latest\"},\"OSDisk\":{\"Caching\":\"ReadWrite\",\"CreateOption\":\"FromImage\",\"Name\":\"osDisk\",\"Vhd\":{\"Uri\":\"$vhdUri\"}}}}"

printf "\n5. Create virtual machine with\r\nnicId='%s'\r\nvhdUri='%s'\r\nvmStr='%s'\n" "$nicId" "$vhdUri" "$vmStr"

azure vm new --resourcegroupname "$groupName" --location "$location" --vmprofile "$vmStr"

printf "\n6. Removing resource group: %s.\n" "$groupName"
azure group remove -n "$groupName" -f