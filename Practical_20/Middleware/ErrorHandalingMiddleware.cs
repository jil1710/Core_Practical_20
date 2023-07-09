using Practical_20.Middleware;
using System.Net;

namespace Practical_20.Middleware
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class ErrorHandalingMiddleware
	{
		private readonly RequestDelegate _next;

		public ErrorHandalingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			await _next(httpContext);

			if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound && !httpContext.Response.HasStarted && httpContext.Request.Path.StartsWithSegments("/Error"))
			{
				httpContext.Response.Redirect("/Error/NotFoundEx");
			}


			if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
			{
				httpContext.Response.Redirect("/Error/NotFoundEx");
			}

			if (httpContext.Response.StatusCode == (int)HttpStatusCode.Ambiguous && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
			{
				httpContext.Response.Redirect("/Error/Ambiguous");
			}

			if (httpContext.Response.StatusCode == (int)HttpStatusCode.BadRequest && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
			{
				httpContext.Response.Redirect("/Error/BadRequestEx");
			}

			if (httpContext.Response.StatusCode == (int)HttpStatusCode.InternalServerError && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
			{
				httpContext.Response.Redirect("/Error/InternalServerError");
			}

			if (httpContext.Response.StatusCode == (int)HttpStatusCode.LoopDetected && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
			{
				httpContext.Response.Redirect("/Error/LoopDetected");
			}

			if (httpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
			{
				httpContext.Response.Redirect("/Error/UnAuthorized");
			}

		}
	}
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ErrorHandalingMiddlewareExtensions
{
	public static IApplicationBuilder UseErrorHandalingMiddleware(this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<ErrorHandalingMiddleware>();
	}
}

