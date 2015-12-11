#!/bin/bash
. setup.sh
. helper.sh
export resourceGroupName=`randomName testrg`
export resourceGroupLocation="westus"

for d in $( ls .. --ignore=lib ); do
    for f in $( ls ../$d/*.sh ); do
        echo "running: $f"
        . $f
    done
done