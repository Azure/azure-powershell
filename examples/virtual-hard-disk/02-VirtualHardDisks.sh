#!/bin/bash
set -e
printf "\n=== Managing Virtual Hard Disks in Azure Compute ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
azure group create -n "$groupName" --location "$location"

printf "\n2. Creating a new storage account"
result=`azure storage account new --resourcegroupname "$groupName" --name "$groupName" --location "$location" --type "$storageAccountType"`

printf "\n3. Uploading a virtual hard disk"
result=`azure vhd add -o --resourcegroupname "$groupName" --destination https://"$groupName".blob.core.windows.net/test/test.vhd --localfilepath $(dirname $0)/test.vhd`

printf "\n4. Downloading a virtual hard disk"

printf "\n5. Removing resource group: %s.\n" "$groupName"
azure group remove -n "$groupName" -f