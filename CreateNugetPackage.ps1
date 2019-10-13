$DateTime = Get-Date -UFormat "%m.%d.%Y.%H.%M.%S"
$Name = "RollerCoaster2019.Logic" + "." + $DateTime
dotnet pack RollerCoaster2019.Logic -c Release -p:PackageID=$Name  --output C:\Packages 