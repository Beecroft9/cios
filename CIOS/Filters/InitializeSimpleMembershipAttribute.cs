//using System;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Threading;
//using System.Web.Mvc;
//using WebMatrix.WebData;
//using CIOS.Models;
//using CIOS.DAL;

//namespace CIOS.Filters
//{
//    /**
//    * Class Name: 
//    * Class Purpose: 
//    * 
//    * Date Created: 
//    * Last Modified: 
//    * @author 
//    */
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
//    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
//    {
//        private static SimpleMembershipInitializer _initializer;
//        private static object _initializerLock = new object();
//        private static bool _isInitialized;
//        /**
//        * Method Name:
//        * Method Purpose:
//        * 
//        * Date Created:
//        * Last Modified:
//        * 
//        * Specifications, Algorithms, and Assumptions:
//        * 
//        * 
//        * @param returnURL: 
//        * @return 
//        */
//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            // Ensure ASP.NET Simple Membership is initialized only once per app start
//            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
//        }
//        /**
//        * Class Name: 
//        * Class Purpose: 
//        * 
//        * Date Created: 
//        * Last Modified: 
//        * @author 
//        */
//        private class SimpleMembershipInitializer
//        {
//            /**
//            * Method Name:
//            * Method Purpose:
//            * 
//            * Date Created:
//            * Last Modified:
//            * 
//            * Specifications, Algorithms, and Assumptions:
//            * 
//            * 
//            * @param returnURL: 
//            * @return 
//            */
//            public SimpleMembershipInitializer()
//            {
//                Database.SetInitializer<CbatContext>(null);

//                try
//                {
//                    using(var context = new CbatContext())
//                    {
//                        if (!context.Database.Exists())
//                        {
//                            // Create the SimpleMembership database without Entity Framework migration schema
//                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
//                        }
//                    }

//                    if (WebSecurity.Initialized == false)
//                    {
//                        WebSecurity.InitializeDatabaseConnection("DefaultConnection",
//                    "UserProfile", "UserId", "UserName", autoCreateTables: false);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
//                }
//            }
//        }
//    }
//}
