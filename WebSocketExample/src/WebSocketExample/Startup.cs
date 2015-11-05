using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using System.Net.WebSockets;
using Microsoft.AspNet.WebSockets.Server;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.Http;
using System.Collections.Generic;
using Microsoft.AspNet.Hosting;

namespace WebSocketExample
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseIISPlatformHandler();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets(); // Only for Kestrel

            app.Map("/ws", builder =>
            {
                builder.Use(async (context, next) =>
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        await Echo(webSocket);
                        return;
                    }
                    await next();
                });
            });
        }

        private async Task Echo(WebSocket webSocket)
        {
            byte[] buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
