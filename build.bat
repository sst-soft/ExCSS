REM Build library
set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %msBuildDir%\msbuild.exe ExCSS.Unity.sln  /p:Configuration=Release /l:FileLogger,Microsoft.Build.Engine;logfile=Manual_MSBuild_ReleaseVersion_LOG.log
if ERRORLEVEL 1 exit 1

REM Run unit tests
call .\nunit-console\nunit3-console.exe .\ExCSS.Tests\bin\DebugUnity35\ExCSS.Tests.dll
if ERRORLEVEL 1 exit 1

call .\nunit-console\nunit3-console.exe .\ExCSS.Tests\bin\ReleaseUnity35\ExCSS.Tests.dll
if ERRORLEVEL 1 exit 1
