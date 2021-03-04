set pathMSBuild="C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin"
@echo off
cls
cd %pathMSBuild%
msbuild.exe "%~dp0\Crypter.sln" /p:configuration=Release
pause
