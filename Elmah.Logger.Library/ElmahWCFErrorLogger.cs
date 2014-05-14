using System;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace Elmah.Logger.Library
{
    
    public class ElmahWCFErrorLogger : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return false;
        }

        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            if (error == null)
                return;
            ///In case we run outside of IIS, 
            ///make sure aspNetCompatibilityEnabled="true" in web.config under system.serviceModel/serviceHostingEnvironment
            ///to be sure that HttpContext.Current is not null
            if (HttpContext.Current == null)
                return;
            Elmah.ErrorSignal.FromCurrentContext().Raise(error);
        }
    }
    
}
