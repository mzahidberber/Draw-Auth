using AuthServer.Core.DTOs;
using AuthServer.Core.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AuthServer.Core.Extensions
{
    public static class CustomExceptionHandle
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (errorFeature != null)
                    {
                        var exception = errorFeature.Error;
                        ErrorDTO? errorDto = null;
                        if (exception is CustomException)
                        {
                            errorDto = new ErrorDTO(exception.Message, true);
                        }
                        else
                        {
                            errorDto = new ErrorDTO(exception.Message, false);
                        }

                        var response = Response<NoDataDTO>.Fail(errorDto, 500);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
