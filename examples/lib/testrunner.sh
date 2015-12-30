#!/bin/bash
export BASEDIR=$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)
. $BASEDIR/assert.sh
. $BASEDIR/helper.sh
. $BASEDIR/setup.sh
export groupName=`randomName testrg`
export location="westus"
export MSYS_NO_PATHCONV=1

login

for d in $( ls $BASEDIR/.. --ignore=lib ); do
    for f in $( ls $BASEDIR/../$d/*.sh ); do
        echo "running: $f"
        . $f
        cleanup
        echo "success: $f"
    done
done

export MSYS_NO_PATHCONV=