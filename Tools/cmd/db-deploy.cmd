@echo off
SETLOCAL

@REM  ----------------------------------------------------------------------------
@REM  db-deploy.cmd
@REM
@REM  author: m4mc3r@gmail.com
@REM  ----------------------------------------------------------------------------

set start_time=%time%
set msbuild_folder=%ProgramFiles(x86)%\MSBuild\14.0\Bin
set webdeploy_folder=%ProgramW6432%\IIS\Microsoft Web Deploy V3
set solution_folder=..\..
set solution_name=UPictures.sln
set default_build_type=Release
set dacpac_path=Src\UPictures.Database\bin\Release\UPictures.Database.dacpac
set data_source=10.0.64.10
set database=UPictures
set user_id=upictures
set password=upictures

@REM  Shorten the command prompt for making the output easier to read
set savedPrompt=%prompt%
set prompt=$$$g$s

@REM Change to the directory where the solution file resides
pushd "%solution_folder%"

"%msbuild_folder%\MSBuild.exe" /m %solution_name% /t:Rebuild /p:Configuration=%default_build_type%
@if %errorlevel%  NEQ 0  goto :error

call "%webdeploy_folder%\msdeploy.exe" -verb:sync -source:dbDacFx="%CD%\%dacpac_path%" -dest:dbDacFx="Data Source=%data_source%;Initial Catalog=%database%;User ID=%user_id%;Password=%password%"
@if %errorlevel%  NEQ 0  goto :error

@REM  Restore the command prompt and exit
@goto :success

:error
echo An error has occured: %errorLevel%
echo start time: %start_time%
echo end time: %time%
goto :finish

:success
echo process successfully finished.
echo start time: %start_time%
echo end time: %Time%

:finish
popd
set prompt=%savedPrompt%

ENDLOCAL
echo on