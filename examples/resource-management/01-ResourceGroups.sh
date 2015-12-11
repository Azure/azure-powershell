#!/bin/bash

printf "\n=== Managing Resource Groups in Azure ===\n"

printf "\n1. Creating a new resource group: %s.\n" "$resourceGroupName"
azure resource group new --name "$resourceGroupName" --location "$resourceGroupLocation"

printf "\n2. Updating the group %s with tags.\n" "$resourceGroupName"
azure resource group set --name "$resourceGroupName" --tags "[{\"Value\":\"testval\",\"Name\":\"testtag\"}]"

printf "\n3. Get information about resource group : %s.\n" "$resourceGroupName"
resourceGroupInfo=`azure resource group get --name $resourceGroupName`
printf "\nThe resource group info is: \n %s\n" "$resourceGroupInfo"

printf "\n4. Listing all resource groups in the subscription.\n"
azure resource group get

printf "\n5. Removing resource group: %s.\n" "$resourceGroupName"
azure resource group remove --name "$resourceGroupName" --force
