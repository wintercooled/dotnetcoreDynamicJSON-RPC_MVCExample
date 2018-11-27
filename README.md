# Setting up and running the MVC example on Linux

## Install .Net Core 2.1 SDK

Register Microsoft key and feed:

```
wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

Install the .NET SDK:

```
sudo add-apt-repository universe
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-2.1
```

## Clone this repository and configure

```
git clone https://github.com/wintercooled/dotnetcoreDynamicJSON-RPC_MVCExample.git
cd dotnetcoreDynamicJSON-RPC_MVCExample
```

Amend ExampleController.cs and set the rpc details needed to connect to your Bitcoin/Elements/Liquid node etc.

## Run the web app

```
dotnet run
```

Browse to https://localhost:5001/Example
