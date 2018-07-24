using System;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using FreemiumGameShop.DataAccess;
using FreemiumGameShop.DataModels;

namespace FreemiumGameShop.Client
{
    internal class ClientService
    {
        public static void CreateClient(ClientModel clm)
        {
            using (var sctx = new ShopContext())
            {
                var cl = new DataAccess.Client { Name = clm.Name};
                sctx.Clients.Add(cl);
                sctx.SaveChanges();
            }
        }

        public static void UpdateClient(int clientId, ClientModel clm)
        {
            using (var sctx = new ShopContext())
            {
                var curClient = sctx.Clients.SingleOrDefault(cl => cl.Id == clientId);
                if (curClient == null)
                {
                    throw new Exception("There is no client with this ID");
                }

                curClient.Name = clm.Name;
                sctx.SaveChanges();
            }
        }

        public static void DeleteClient(int clientId)
        {
            using (var sctx = new ShopContext())
            {
                var toDel = sctx.Clients.SingleOrDefault(cl => cl.Id == clientId);
                sctx.Clients.Remove(toDel ?? throw new Exception("There is no client with this ID"));
                sctx.SaveChanges();
            }
        }

        public static ClientModel GetClient(int clientId)
        {
            using (var sctx = new ShopContext())
            {
                var curClient = sctx.Clients.SingleOrDefault(cl => cl.Id == clientId);
                if (curClient == null)
                {
                    throw new Exception("There is no client with this ID");
                }
                var model = new ClientModel() { Name = curClient.Name };
                return model;
            }
        }
    }
}