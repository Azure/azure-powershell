SETLOCAL EnableExtensions

ECHO Test return code success case
call testclu success show 2> out.error
REM We expect that the commands above succeed (return 0)
IF %ERRORLEVEL% NEQ 0 (
    ECHO "Expected error level 0 for success, got " %ERRORLEVEL%
    EXIT /B 1
)

ECHO Test return codes non terminating error case
call testclu success show --generatenonterminatingerror true 2> out.error
IF %ERRORLEVEL% NEQ 1 (
    ECHO "Expected error level 1 for non-terminating error, got " %ERRORLEVEL%
    EXIT /B 1
)

ECHO Test return codes terminating error case
call testclu success show --generateterminatingerror true 2> out.error
IF %ERRORLEVEL% NEQ 2 (
    ECHO "Expected error level 2 for terminating error, got " %ERRORLEVEL%
    EXIT /B 1
)

ECHO Test pipeline aliasing
call testclu record new | testclu record show > out.txt
IF %ERRORLEVEL% NEQ 0 (
    ECHO "Expected error level 0 for success, got " %ERRORLEVEL%
    EXIT /B 1
)


ECHO ALL TESTS ARE HAPPY
