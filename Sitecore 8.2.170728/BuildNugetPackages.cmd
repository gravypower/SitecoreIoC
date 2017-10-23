pushd SitecoreIoC.SimpleInjector
msbuild /p:Configuration=Release
nuget pack -symbols -Prop Configuration=Release -IncludeReferencedProjects
move *.nupkg ..
popd

pushd SitecoreIoC.SimpleInjector.Example
msbuild /p:Configuration=Release
nuget pack -symbols -Prop Configuration=Release -IncludeReferencedProjects
move *.nupkg ..
popd
