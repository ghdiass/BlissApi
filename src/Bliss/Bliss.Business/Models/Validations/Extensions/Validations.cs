using FluentValidation;
using System;

namespace Bliss.Business.Models.Validations.Extensions
{
    public static class Validations
    {
        public static IRuleBuilderOptions<T, string> Url<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            bool UrlIsValidUri(string url) => Uri.TryCreate(url, UriKind.Absolute, out var outUri)
               && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
            return ruleBuilder.Must(UrlIsValidUri);
        }
    }
}
