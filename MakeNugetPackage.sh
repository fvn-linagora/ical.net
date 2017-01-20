NUGETDIR="$HOME/dev/NuGet"
NUGET="mono ${NUGETDIR}/NuGet.exe"
${NUGET} restore v2
${NUGET} restore v3
${NUGET} install NUnit.Runners -Version 3.4.1 -OutputDirectory testrunner
xbuild /p:Configuration=Release40 v2/ical-v2.sln
xbuild /p:Configuration=Release45 v2/ical-v2.sln
xbuild /p:Configuration=Release46 v2/ical-v2.sln
xbuild /p:Configuration=Release45 v3/ical-v3.sln
xbuild /p:Configuration=Release46 v3/ical-v3.sln
${NUGET} pack v2/Ical.Net.nuspec
