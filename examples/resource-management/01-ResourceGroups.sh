#!/bin/bash
set -e
printf "\n=== Managing Resource Groups in Azure ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
azure resource group new --name "$groupName" --location "$location"

printf "\n2. Updating the group %s with tags.\n" "$groupName"
azure resource group set --name "$groupName" --tags "[{\"Value\":\"testval\",\"Name\":\"testtag\"}]"

printf "\n3. Get information about resource group : %s.\n" "$groupName"
resourceGroupInfo=`azure resource group get --name $groupName`
printf "\nThe resource group info is: \n %s\n" "$resourceGroupInfo"

printf "\n4. Listing all resource groups in the subscription.\n"
azure resource group get

printf "\n5. Removing resource group: %s.\n" "$groupName"
azure resource group remove --name "$groupName" --force
