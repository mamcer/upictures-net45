echo off
pushd %~dp0

CD C:\root\home\projects\bit\upictures

IF NOT EXIST "%CD%\coverage-report" GOTO NoCoverageReport
rmdir /s /q "%CD%\coverage-report"
:NoCoverageReport
md "%CD%\coverage-report"

C:\root\bin\report-generator\ReportGenerator.exe -reports:"C:\root\home\projects\bit\upictures\open-cover-discover.xml;C:\root\home\projects\bit\upictures\open-cover-application.xml;C:\root\home\projects\bit\upictures\open-cover-core.xml;C:\root\home\projects\bit\upictures\open-cover-data.xml" -targetdir:"%CD%\coverage-report" -reporttypes:Html

popd