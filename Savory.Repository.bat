msbuild Savory.Repository\Savory.Repository.csproj /t:rebuild /p:configuration=release;DocumentationFile=bin\Release\Savory.Repository.xml;DebugType=none

nuget pack Savory.Repository.nuspec

move /y Savory.Repository.*.nupkg ..\Nuget\Packages

pause