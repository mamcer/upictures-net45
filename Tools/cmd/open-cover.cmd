@echo off
SETLOCAL

@REM  ----------------------------------------------------------------------------
@REM  base-script.cmd
@REM
@REM  author: m4mc3r@gmail.com
@REM  ----------------------------------------------------------------------------

set start_time=%time%
set working_dir=%CD%\..\..
set opencover_bin=C:\root\bin\open-cover\tools\OpenCover.Console.exe
set xunit_runner_console=C:\root\bin\xunit.runner.console.2.2.0\tools\xunit.console.exe
set discover_test_path=Src\UPictures.Discover.Tests\bin\Debug\
set application_test_path=Src\UPictures.Application.Tests\bin\Debug\
set core_test_path=Src\UPictures.Core.Tests\bin\Debug\
set data_test_path=Src\UPictures.Data.IntegrationTests\bin\Debug\
set opencover_xml=Z:\upictures\open-cover.xml

@REM  Shorten the command prompt for making the output easier to read
set savedPrompt=%prompt%
set prompt=$$$g$s

CD "%working_dir%\%discover_test_path%"
"%opencover_bin%" -register:user -target:"%xunit_runner_console%" -targetargs:"UPictures.Discover.Tests.dll" -filter:"+[*]* -[*.Tests]* -[*.Test]* -[xunit.*]* -[Microsoft.*]*" -output:"%opencover_xml%"
@if %errorlevel%  NEQ 0  goto :error

CD "%working_dir%\%application_test_path%"
"%opencover_bin%" -register:user -target:"%xunit_runner_console%" -targetargs:"UPictures.Application.Tests.dll" -filter:"+[*]* -[*.Tests]* -[*.Test]* -[xunit.*]* -[Microsoft.*]*" -output:"%opencover_xml%" -mergebyhash -mergeoutput -hideskipped:All -log:Verbose -skipautoprops
@if %errorlevel%  NEQ 0  goto :error

CD "%working_dir%\%core_test_path%"
"%opencover_bin%" -register:user -target:"%xunit_runner_console%" -targetargs:"UPictures.Core.Tests.dll" -filter:"+[*]* -[*.Tests]* -[*.Test]* -[xunit.*]* -[Microsoft.*]*" -output:"%opencover_xml%" -mergebyhash -mergeoutput -hideskipped:All -log:Verbose -skipautoprops
@if %errorlevel%  NEQ 0  goto :error

CD "%working_dir%\%data_test_path%"
"%opencover_bin%" -register:user -target:"%xunit_runner_console%" -targetargs:"UPictures.Data.IntegrationTests.dll" -filter:"+[*]* -[*.Tests]* -[*.Test]* -[xunit.*]* -[Microsoft.*]* -[*.IntegrationTests]*" -output:"%opencover_xml%" -mergebyhash -mergeoutput -hideskipped:All -log:Verbose -skipautoprops
@if %errorlevel%  NEQ 0  goto :error

REM  Restore the command prompt and exit
@goto :success

:error
echo an error has occured: %errorLevel%
echo start time: %start_time%
echo end time: %time%
goto :finish

:success
echo process successfully finished
echo start time: %start_time%
echo end time: %time%

:finish
popd
set prompt=%savedPrompt%

ENDLOCAL
echo on