﻿using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Jog.Api.Filter
{
	// https://blog.dhampir.no/content/allowing-an-empty-json-body-or-no-content-type-in-a-c-asp-net-core-api

	[AttributeUsage(AttributeTargets.Method)]
	public class AllowEmptyJsonBodyAttribute : Attribute, IResourceFilter
	{
		private const string StreamOverride = "StreamOverride";

		public void OnResourceExecuting(ResourceExecutingContext context)
		{
			var request = context.HttpContext.Request;
			if (!string.IsNullOrEmpty(request.ContentType) && !request.HasJsonContentType() || (request.ContentLength ?? 0) != 0) return;
			request.ContentType = "application/json";
			context.HttpContext.Items[StreamOverride] = request.Body; // store the original stream
			var emptyPayload = Encoding.UTF8.GetBytes("{}");
			request.Body = new MemoryStream(emptyPayload); // replace the stream
			request.ContentLength = emptyPayload.Length;
		}

		public void OnResourceExecuted(ResourceExecutedContext context)
		{
			if (!context.HttpContext.Items.TryGetValue(StreamOverride, out var o) || o is not Stream s) return;
			var request = context.HttpContext.Request;
			request.Body.Dispose(); // this disposes our injected stream
			request.Body = s; // put the original back, so it can be cleaned up as usual
		}
	}
}
