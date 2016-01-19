#!/bin/env/bash
set -e
printf "\n=== Managing Resource Groups in Azure ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
az resource group create -n "$groupName" --location "$location"

printf "\n2. Updating the group %s with tags.\n" "$groupName"
az resource group set -n "$groupName" --tags "[{\"Value\":\"testval\",\"Name\":\"testtag\"}]"

printf "\n3. Get information about resource group : %s.\n" "$groupName"
resourceGroupInfo=`az resource group ls -n $groupName`

printf "\nValidating resource group name is: %s\n" "$groupName"
[ $(echo $resourceGroupInfo | jq '.ResourceGroupName' --raw-output) == "$groupName" ]

printf "\n4. Listing all resource groups in the subscription.\n"
az resource group ls

printf "\n5. Removing resource group: %s.\n" "$groupName"
az resource group rm -n "$groupName" -f