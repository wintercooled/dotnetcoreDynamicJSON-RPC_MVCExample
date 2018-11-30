## A simple .NET Core MVC example using the [dotnetcoreDynamicJSON-RPC dynamic RPC wrapper](https://github.com/wintercooled/dotnetcoreDynamicJSON-RPC) class, which is intended to enable simple, dynamic wrapping of JSON RPC calls to Bitcoin, Elements, Liquid and other RPC enabled daemons.

### Status

Runs on Windows, Linux, Mac using the .NET Core cross-platform application framework.

Tested with [Bitcoin](https://github.com/bitcoin/bitcoin) (bitcoind) and [Elements](https://elementsproject.org/) (elementsd) as target daemons.

Will also work with a [Liquid](https://blockstream.com/liquid/) node.

Please see the [dotnetcoreDynamicJSON-RPC dynamic RPC wrapper](https://github.com/wintercooled/dotnetcoreDynamicJSON-RPC) page on GitHub to learn how to use it and its JSON string helper classes in detail.

![MVC](https://wintercooled.github.io/images/examplemvc.png)

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

Browse to https://localhost:5001/

## Tidying up

You can go through and remove the extra views and controller actions (About, Contact etc.) that dotnet created if you like. I've left them in so that this example code is not that different to the example given here for reference: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app-xplat/start-mvc?view=aspnetcore-2.1
