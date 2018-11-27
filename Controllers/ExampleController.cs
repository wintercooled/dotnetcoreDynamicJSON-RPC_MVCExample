using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ExampleMVC.Models;

using DotnetcoreDynamicJSONRPC;
using System;

namespace ExampleMVC.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            // We will be using an Elements node in this example. 
            // It is easy to switch to use a Bitcoin, Liquid node.
            // You need to change these to make sure you can authenticate against the daemon you are running:
            string rpcUrl = "http://localhost";
            string rpcPort = "18884";
            string rpcUsername = "user1";
            string rpcPassword = "password1";

            // For examples and notes on how to use the dotnetcoreDynamicJSON-RPC tool and its JSON helper methods please see:
            // https://github.com/wintercooled/dotnetcoreDynamicJSON-RPC            
            
            // Initialise an instance of the dynamic dotnetcoreDynamicJSON_RPC class.
            dynamic dynamicRPC = new DynamicRPC(rpcUrl, rpcPort, rpcUsername, rpcPassword);

            // Initialise our model that will be passed to the view
            var nodeInfo = new ExampleNodeInfo();
            
            if (dynamicRPC.DaemonIsRunning())
            {
                try
                {
                    // Get the JSON result of the 'getwalletinfo' RPC on the Elements node.
                    string balance = dynamicRPC.getwalletinfo();
                    
                    // Use the DotnetcoreDynamicJSONRPC 'GetProperty' string helper to return the property value we want.
                    balance = balance.GetProperty("result.balance.bitcoin");

                    // Populate the model
                    nodeInfo.Balance = balance;
                }
                catch (Exception e)
                {
                    nodeInfo.Message = e.Message;
                }
            }
            else
            {
                nodeInfo.Message = "Could not communicate with daemon";
            }

            // Return the view and the associated model we have populated
            return View(nodeInfo);
        }
    }
}
