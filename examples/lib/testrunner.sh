#!/bin/bash
export BASEDIR=$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)
. $BASEDIR/helper.sh
export groupName=`randomName testrg`
export location="westus"
export CmdletSessionID=1010
export MSYS_NO_PATHCONV=1

echo "Logging in as user"
. $BASEDIR/loginUser.sh

for d in $( ls $BASEDIR/.. --ignore=lib ); do
    for f in $( ls $BASEDIR/../$d/*.sh ); do
        echo "running: $f"
        . $f
        set +e
        printf "\nCleanup: removing resource group: %s\n" $groupName
        azure group remove --name "$groupName" --force
        set -e
        echo "success: $f"
    done
done

export MSYS_NO_PATHCONV=