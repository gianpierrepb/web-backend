using System.Web.Http;
using Moments;
using WebActivatorEx;
using Swashbuckle.Application;
using Moments.App_Start;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Moments
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;


            GlobalConfiguration.Configuration

                .EnableSwagger(c =>
                {

                    c.SingleApiVersion("v1", "Moments");
                    c.IncludeXmlComments(string.Format(@"{0}\bin\Moments.XML",
                       System.AppDomain.CurrentDomain.BaseDirectory));
                    c.OAuth2("oauth2")
                        .Description("OAuth2 Implicit Grant")
                        .Flow("implicit")
                        .AuthorizationUrl("http://silspapi.azurewebsites.net/Token")
                        .TokenUrl("http://silspapi.azurewebsites.net/Token")
                        .Scopes(scopes =>
                        {
                            scopes.Add("roles", "Write access to protected resources");
                        });

                    c.OperationFilter<AssignOAuth2SecurityRequirements>();
                })

                .EnableSwaggerUi(c =>
                {
                    c.EnableDiscoveryUrlSelector();
                    c.EnableOAuth2Support(
                        clientId: "test-client-id",
                        clientSecret: null,
                        realm: "test-realm",
                        appName: "Moments"
                    //additionalQueryStringParams: new Dictionary<string, string>() { { "foo", "bar" } }
                    );
                });
        }
    }
}