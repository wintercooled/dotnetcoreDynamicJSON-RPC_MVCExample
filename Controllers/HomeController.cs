using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExampleMVC.Models;

using DotnetcoreDynamicJSONRPC;

namespace ExampleMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // You can run this example against a Bitcoin, Elements or Liquid node as the 'getblockcount' RPC is found in all of them.
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
                    // Get the JSON result of the 'getblockcount' RPC against the node.
                    string blockCount = dynamicRPC.getblockcount();

                    // Populate the model by accessing the JSON 'result' data value using the DotnetcoreDynamicJSONRPC 
                    // GetProperty string extension.
                    nodeInfo.BlockCount = blockCount.GetProperty("result");

                    // Refer to the DotnetcoreDynamicJSONRPC GitHub page for info on how its 3 string extension methods give access 
                    // to the JSON data returned, without the need for complex classes to represent a block, list of transactions etc.
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
