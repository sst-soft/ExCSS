set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319 
call %msBuildDir%\msbuild.exe ExCSS.Unity.sln  /p:Configuration=Release /l:FileLogger,Microsoft.Build.Engine;logfile=Manual_MSBuild_ReleaseVersion_LOG.log

