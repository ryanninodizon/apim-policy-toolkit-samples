using Azure.ApiManagement.PolicyToolkit.Authoring;

namespace Apim.Policies
{
    [Document]
    public class FirstPolicy : IDocument
    {
        public void Inbound(IInboundContext context)
        {
           context.Base();
           context.SetHeader("X-First-Policy", "FirstPolicy");           
        
        }
        
    }
}