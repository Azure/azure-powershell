#!/bin/bash

randomName() {
    echo "$1$RANDOM"
}

export -f randomName 