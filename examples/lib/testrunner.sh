#!/bin/env/bash
export TESTDIR=$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)
. $TESTDIR/helper.sh
export groupName=`randomName testrg`
export location="westus"
export MSYS_NO_PATHCONV=1

echo "Logging in as user"
. $TESTDIR/loginUser.sh

for d in $( ls $TESTDIR/.. --ignore=lib ); do
    for f in $( ls $TESTDIR/../$d/*.sh ); do
        echo "running: $f"
        BASEDIR=$(cd "$(dirname "$f")" && pwd)
        . $f
        set +e
        printf "\nCleanup: removing resource group: %s\n" $groupName
        az resourcemanager group rm --name "$groupName" --force
        set -e
        echo "success: $f"
    done
done

export MSYS_NO_PATHCONV=