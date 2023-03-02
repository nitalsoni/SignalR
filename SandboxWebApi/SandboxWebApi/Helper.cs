using SandboxWebApi.Models;
using System;
using System.Collections.Generic;

namespace SandboxWebApi
{
    public static class Helper
    {
        private static readonly string[] clients = { "BARC", "CAPG", "INVE", "C1", "CAGT", "G3", "CSIPROP", "BELLR", "AXA", "ANIMAMIL", "BLACKPTA", "ASSETDV", "D1CSI", "CSST" };

        private static readonly string[] symbols = { "AAL.L", "BP.L", "VOD.L", "ENEI.MI", "ENX.PA", "BT.L", "CHDVD.S", "DQ.N", "SAND.ST", "BRBY.L", "INDV.L", "IMB.L", "BFIT.AS", "BNZL.L", "LOIM.PA" };

        private static IEnumerable<AgoraOrder> GenerateRandomOrders(int n)
        {
            var orders = new List<AgoraOrder>();
            for (int i = 0; i < n; i++)
            {
                orders.Add(
                        new AgoraOrder()
                        {
                            OrderId = Guid.NewGuid().ToString(),
                            Client = clients[new Random().Next(0, clients.Length - 1)],
                            Symbol = symbols[new Random().Next(0, symbols.Length - 1)],
                            Side = (new Random().Next(0, clients.Length - 1)) % 2 == 0 ? "S": "B",
                            Status = (new Random().Next(0, clients.Length - 1)) % 2 == 0 ? "Active" : "Expired",
                            Created = DateTime.Now.AddMinutes(new Random().Next(0, 180)),
                            IsActive = (new Random().Next(0, clients.Length - 1)) % 2 == 0 ? true: false
                        }
                    );
            }

            return orders;
        }

        public static IEnumerable<AgoraOrder> GetOrders(int n)
        { 
            return GenerateRandomOrders(n);
        }

    }
}
