#!/bin/bash
set -e
printf "\n=== Managing Resource Groups in Azure ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
az group create -n "$groupName" --location "$location"

printf "\n2. Updating the group %s with tags.\n" "$groupName"
az group set -n "$groupName" --tags "[{\"Value\":\"testval\",\"Name\":\"testtag\"}]"

printf "\n3. Get information about resource group : %s.\n" "$groupName"
resourceGroupInfo=`az group get -n $groupName`

printf "\nValidating resource group name is: %s\n" "$groupName"
[ $(echo $resourceGroupInfo | jq '.ResourceGroupName' --raw-output) == "$groupName" ]

printf "\n4. Listing all resource groups in the subscription.\n"
az group get

printf "\n5. Removing resource group: %s.\n" "$groupName"
az group remove -n "$groupName" -f