#!/bin/bash
. setup.sh

for d in $( ls .. --ignore=lib ); do
    for f in $( ls ../$d/*.sh ); do
        echo "running: $f"
        . $f
    done
done