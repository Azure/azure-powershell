#!/bin/env/bash
set -e
printf "\n=== Managing Virtual Hard Disks in Azure Compute ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
az resource group create -n "$groupName" --location "$location"

printf "\n2. Creating a new storage account '%s' in type '%s'.\n" "$storageAccountName" "$storageAccountType"
az storage account create --resourcegroupname "$groupName" --name "$storageAccountName" --location "$location" --type "$storageAccountType"

printf "\n3. Uploading a virtual hard disk to: %s.\n" "$storageAccountName"
az vhd add -o --resourcegroupname "$groupName" --destination https://"$storageAccountName".blob.core.windows.net/test/test.vhd --localfilepath $BASEDIR/test.vhd

printf "\n4. Downloading a virtual hard disk"
az vhd save -o --resourcegroupname "$groupName" --sourceuri https://"$storageAccountName".blob.core.windows.net/test/test.vhd --localfilepath ./test_downloaded_by_clu.vhd

printf "\n5. Validating the downloaded file is the same.\n"
diffResult=`diff ./test_downloaded_by_clu.vhd $BASEDIR/test_uploaded_byps.vhd`
printf "Difference Result = '%s'.\n" "$diffResult"
if [ "$diffResult" = "" ]; then
    echo "Checked"
else
    echo "Different!" 1>&2
    exit 1
fi

printf "\n6. Removing resource group: %s.\n" "$groupName"
az resource group rm -n "$groupName" -f