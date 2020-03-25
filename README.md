# bitbar-covid-mn
Covid-19 Metrics for MN in the Mac OS X Menu Bar


# Installation

1. Clone the repo locally
```
git clone https://github.com/wkallhof/bitbar-covid-mn.git
cd bitbar-covid-mn
```

2. Publish the .NET Core project
```
dotnet publish -c release
```

3. Move the files to your Bitbar plugins folder
```
cp covid.10m.sh ./path/to/bitbar/plugins/covid.10m.sh
```

4. Update the plugin file `covid.10m.sh` to point to your published DLL.

```
File : covid.10m.sh

#!/bin/bash
/usr/local/share/dotnet/dotnet ~/bitbar-covid-mn/bin/release/netcoreapp3.1/Covid.dll
```
