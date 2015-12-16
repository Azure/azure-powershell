SETLOCAL EnableExtensions

ECHO Test return code success case
call azure success show
REM We expect that the commands above succeed (return 0)
IF ERRORLEVEL 1 (EXIT /B 1)

ECHO Test return codes non terminating error case
call azure success show --generatenonterminatingerror true
if ERRORLEVEL 1 goto :verify_error_code_2
REM We expect the error code to be 1 - so we shouldn't be here
EXIT /B 1
:verify_error_code_2
IF ERRORLEVEL 2 (EXIT /B 1)

ECHO Test return codes terminating error case
call azure success show --generateterminatingerror true
if ERRORLEVEL 2 goto :verify_error_code_3
REM We expect the error code to be 1 - so we shouldn't be here
EXIT /B 1
:verify_error_code_3
IF ERRORLEVEL 3 (EXIT /B 1)

ECHO Test pipeline aliasing
call azure test record new > testrecordnew.json
call azure test record show < testrecordnew.json

REM We expect that the commands above succeed
IF ERRORLEVEL 1 (EXIT /B 1)

