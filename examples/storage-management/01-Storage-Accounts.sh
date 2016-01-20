#!/bin/bash
printf "\n=== Managing Storage Accounts Resources in Azure ===\n"
export BASEDIR=$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)

az reource group get -n $groupName
if [ $? -ne 0 ]; then
    printf "\n Creating group %s in location %s \n" $groupName $location
    az resource group create -n "$groupName" --location "$location"
fi

set -e
accountName=`randomName $groupName`
accountType="Standard_GRS"

printf "\n1. Creating storage account %s in resrouce group %s with type %s in location %s \n" $accountName $groupName $accountType $location
az storage account create -g "$groupName" -n "$accountName" -t "$accountType" -l "$location"

printf "\n2. Get account info of storage account %s in group %s\n" $accountName $groupName
az storage account ls -g $groupName -n $accountName > $BASEDIR/$accountName.json
[ $(cat $BASEDIR/$accountName.json | jq '.ResourceGroupName' --raw-output) == "$groupName" ]
[ $(cat $BASEDIR/$accountName.json | jq '.StorageAccountName' --raw-output) == "$accountName" ]
[ $(cat $BASEDIR/$accountName.json | jq '.AccountType' --raw-output) == "$accountType" ]
[ $(cat $BASEDIR/$accountName.json | jq '.Location' --raw-output) == "$location" ]
rm -f $BASEDIR/$accountName.json

accountType1="Standard_RAGRS"
printf "\n3. Set account type from %s to %s of storage account %s in group %s\n" $accountType $accountType1 $accountName $groupName
az storage account set -g $groupName -n $accountName -t "$accountType1" > $BASEDIR/$accountName.json
[ $(cat $BASEDIR/$accountName.json | jq '.AccountType' --raw-output) == "$accountType1" ]
rm -f $BASEDIR/$accountName.json

printf "\n4. Get account key of storage account %s in group %s\n" $accountName $groupName
az storage key ls -g $groupName -n $accountName > $BASEDIR/$accountName.json
key1=$(cat $BASEDIR/$accountName.json | jq '.key1' --raw-output)
key2=$(cat $BASEDIR/$accountName.json | jq '.key2' --raw-output)
[ $key1 != $key2 ]
rm -f $BASEDIR/$accountName.json

printf "\n5. Renew account key1 of storage account %s in group %s\n" $accountName $groupName
az storage key create -g $groupName -n $accountName -k "key1"
az storage key ls -g $groupName -n $accountName > $BASEDIR/$accountName.json
[ $(cat $BASEDIR/$accountName.json | jq '.key1' --raw-output) != $key1 ]
rm -f $BASEDIR/$accountName.json

printf "\n6. Renew account key2 of storage account %s in group %s\n" $accountName $groupName
az storage key create -g $groupName -n $accountName -k "key2"
az storage key ls -g $groupName -n $accountName > $BASEDIR/$accountName.json
[ $(cat $BASEDIR/$accountName.json | jq '.key2' --raw-output) != $key2 ]
rm -f $BASEDIR/$accountName.json

printf "\n7. Removing account %s in group %s\n" $accountName $groupName
az storage account rm -g $groupName -n $accountName
