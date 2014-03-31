using DotNetRocks.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DotNetRocks.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // InitialDatabase();
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }
        //private void InitialDatabase()
        //{
        //    // Generate Mapping Views . 
        //    // More details see http://msdn.microsoft.com/en-us/data/dn469601#code
        //    using (var db = new ApplicationDbContext())
        //    {
        //        var objectContext = ((IObjectContextAdapter)db).ObjectContext;
        //        var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
        //        mappingCollection.GenerateViews(new List<EdmSchemaError>());
        //    }
        //}
    }
}
