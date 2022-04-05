using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Extensions
{
    public static class ServicesAPIExtensions
    {
        public static void AgregaVersionado(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }

       public static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source, Func<TSource, TSource> nextItem, Func<TSource, bool> canContinue)
       {
          for (var current = source; canContinue(current); current = nextItem(current))
          {
              yield return current;
          }
       }

       public static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source, Func<TSource, TSource> nextItem) where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }

        public static string ObtenTodosLosMsjs(this Exception exception)
        {
            var messages = exception.FromHierarchy(ex => ex.InnerException!).Select(ex => ex.Message);
            return string.Join(Environment.NewLine, messages);
        }
        
    }
}
