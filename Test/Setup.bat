@ECHO OFF
ECHO Build started
call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\Tools\VsMSBuildCmd.bat"
call msbuild.exe "E:\Proj2022\Misc\Magnifinance\\Test\\Test.sln" /t:Clean,Build /p:Configuration=Release /p:Platform="Any CPU"
ECHO Build Completed

set VSCMD_DEBUG=1
call "C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\Common7\Tools\VsDevCmd.bat" 
devenv "E:\Proj2022\Misc\Magnifinance\\Test\\Test.sln" /Run