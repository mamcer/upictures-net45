@echo off
SETLOCAL

@REM  ----------------------------------------------------------------------------
@REM  base-script.cmd
@REM
@REM  author: m4mc3r@gmail.com
@REM  ----------------------------------------------------------------------------

set start_time=%time%
set working_dir=%CD%

if "%1"=="/?" goto help

@REM  Shorten the command prompt for making the output easier to read
set savedPrompt=%prompt%
set prompt=$$$g$s

@REM Change working directory 
pushd %working_dir%

@REM <cool-functionalty>
echo base-script
@if %errorlevel%  NEQ 0  goto :error
@REM </cool-functionalty>

@REM  Restore the command prompt and exit
@goto :success

:error
echo an error has occured: %errorLevel%
echo start time: %start_time%
echo end time: %time%
goto :finish

:help
echo usage: base-script.cmd [/?] 
echo "/?" shows this help test 

:success
echo process successfully finished
echo start time: %start_time%
echo end time: %time%

:finish
popd
set prompt=%savedPrompt%

ENDLOCAL
echo on