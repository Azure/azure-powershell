:workerLoop

:: Do work
ping 123.45.67.89 -n 1 -w 1000000 > nul

goto workerLoop