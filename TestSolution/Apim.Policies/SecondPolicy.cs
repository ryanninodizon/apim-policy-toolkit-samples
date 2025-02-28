using Azure.ApiManagement.PolicyToolkit.Authoring;
using Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;
namespace Apim.Policies
{
    [Document]
    public class SecondPolicy : IDocument
{
    public void Inbound(IInboundContext context)
    {
        context.Base();
        if(IsCompanyIP(context.ExpressionContext))
        {
            context.AuthenticationBasic("username", "password");
        }
        else
        {
            context.AuthenticationManagedIdentity(new ManagedIdentityAuthenticationConfig 
            {
                Resource = "https://graph.microsoft.com"
            });
        }
        context.SetHeader("X-User-Id", GetUserId(context.ExpressionContext));
    }
    
    public static bool IsCompanyIP(IExpressionContext context)
        => context.Request.IpAddress.StartsWith("10.0.0.");

    private static string GetUserId(IExpressionContext context)
        => context.User.Id;
}}