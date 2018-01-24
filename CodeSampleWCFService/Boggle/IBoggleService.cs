using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CodeSampleWCFService.BoggleSvc
{
    [ServiceContract]
    interface IBoggleService
    {
        [OperationContract]
        [WebInvoke]
        List<string> GetBoggleAnswers(BoggleDataContract input);
    }
}
