dotnet tool uninstall -g Lit.Cli
dotnet pack
dotnet tool install --global --add-source ./nupkg Lit.Cli