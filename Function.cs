using Amazon.Lambda.Core;
using HelpDeskService;
using HelpDeskService.Model;
using System;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace HelpDesk.SubmitSupportRequest
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task FunctionHandler(SupportData supportData, ILambdaContext context)
        {
            // newHireSupportJson is not set
            if (supportData == null)
            {
                throw new Exception("Support request json is not set.");
            }

            SupportService service = new SupportService(context);
            await service.SubmitRequestAsync(supportData);
        }
    }
}
