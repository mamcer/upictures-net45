echo off
pushd %~dp0

CD C:\root\home\projects\bit\upictures\Src\UPictures.Discover.Tests\bin\Debug\

C:\root\bin\open-cover\OpenCover.Console.exe -register:user -target:"C:\root\home\projects\bit\upictures\packages\xunit.runner.console.2.1.0\tools\xunit.console.exe" -targetargs:"C:\root\home\projects\bit\upictures\Src\UPictures.Discover.Tests\bin\Debug\UPictures.Discover.Tests.dll" -filter:"+[*]* -[*.Tests]* -[*.Test]* -[xunit.*]* -[Microsoft.*]*" -output:C:\root\home\projects\bit\upictures\open-cover-discover.xml

CD C:\root\home\projects\bit\upictures\Src\UPictures.Application.Tests\bin\Debug\

C:\root\bin\open-cover\OpenCover.Console.exe -register:user -target:"C:\root\home\projects\bit\upictures\packages\xunit.runner.console.2.1.0\tools\xunit.console.exe" -targetargs:"C:\root\home\projects\bit\upictures\Src\UPictures.Application.Tests\bin\Debug\UPictures.Application.Tests.dll" -filter:"+[*]* -[*.Tests]* -[*.Test]* -[xunit.*]* -[Microsoft.*]*" -output:C:\root\home\projects\bit\upictures\open-cover-application.xml

CD C:\root\home\projects\bit\upictures\Src\UPictures.Core.Tests\bin\Debug\

C:\root\bin\open-cover\OpenCover.Console.exe -register:user -target:"C:\root\home\projects\bit\upictures\packages\xunit.runner.console.2.1.0\tools\xunit.console.exe" -targetargs:"C:\root\home\projects\bit\upictures\Src\UPictures.Core.Tests\bin\Debug\UPictures.Core.Tests.dll" -filter:"+[*]* -[*.Tests]* -[*.Test]* -[xunit.*]* -[Microsoft.*]*" -output:C:\root\home\projects\bit\upictures\open-cover-core.xml

CD C:\root\home\projects\bit\upictures\Src\UPictures.Data.IntegrationTests\bin\Debug\

C:\root\bin\open-cover\OpenCover.Console.exe -register:user -target:"C:\root\home\projects\bit\upictures\packages\xunit.runner.console.2.1.0\tools\xunit.console.exe" -targetargs:"C:\root\home\projects\bit\upictures\Src\UPictures.Data.IntegrationTests\bin\Debug\UPictures.Data.IntegrationTests.dll" -filter:"+[*]* -[*.Tests]* -[*.IntegrationTests]* -[*.Test]* -[xunit.*]* -[Microsoft.*]*" -output:C:\root\home\projects\bit\upictures\open-cover-data.xml

popd