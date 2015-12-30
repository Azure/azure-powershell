#!/bin/bash
set -e
printf "\n=== Managing Virtual Hard Disks in Azure Compute ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
azure group create -n "$groupName" --location "$location"

printf "\n2. Creating a new storage account '%s' in type '%s'.\n" "$storageAccountName" "$storageAccountType"
azure storage account new --resourcegroupname "$groupName" --name "$storageAccountName" --location "$location" --type "$storageAccountType"

printf "\n3. Uploading a virtual hard disk to: %s.\n" "$storageAccountName"
azure vhd add -o --resourcegroupname "$groupName" --destination https://"$storageAccountName".blob.core.windows.net/test/test.vhd --localfilepath $BASEDIR/test.vhd

printf "\n4. Downloading a virtual hard disk"
azure vhd save -o --resourcegroupname "$groupName" --sourceuri https://"$storageAccountName".blob.core.windows.net/test/test.vhd --localfilepath ./test_downloaded_by_clu.vhd

printf "\n5. Validating the downloaded file is the same.\n"
diffResult=`diff ./test_downloaded_by_clu.vhd $BASEDIR/test_uploaded_byps.vhd`
if [ "$diffResult" = "" ]; then
    echo "Checked"
else
    echo "Different!" 1>&2
    exit 1
fi

printf "\n6. Removing resource group: %s.\n" "$groupName"
azure group remove -n "$groupName" -f