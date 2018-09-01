@echo off
SETLOCAL

@REM  ----------------------------------------------------------------------------
@REM  xunit-runner-console.cmd
@REM
@REM  author: Mario Moreno (@mamcer)
@REM  ----------------------------------------------------------------------------

set start_time=%time%
set working_dir=%CD%\..\..
set msbuild_bin_path="%PROGRAMFILES(X86)%\MSBuild\14.0\Bin\MSBuild.exe"
set xunit-runner-console_bin_path="C:\root\bin\xunit.runner.console.2.2.0\tools\xunit.console.exe"
set xunit-runner-console_proj_path=\xunit-runner-console.proj

if "%1"=="/?" goto help

@REM run xunit-runner-console
%msbuild_bin_path% "%working_dir%%xunit-runner-console_proj_path%" /p:WorkingDirectory="%working_dir%" /p:XunitRunnerConsoleBinPath=%xunit-runner-console_bin_path%
@if %errorlevel% NEQ 0 goto error
goto success

:error
@exit /b errorLevel

:help
echo looks for test assemblies and runs xunit-runner-console
echo usage: vstest-console.cmd [/?] 
echo "/?" shows this help test 

:success
echo process successfully finished
echo start time: %start_time%
echo end time: %time%

ENDLOCAL
echo on