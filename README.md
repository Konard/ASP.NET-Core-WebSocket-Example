# ASP.NET 5 CoreCLR WebSocket Example
Started as adaptation of https://github.com/aspnet/WebSockets/tree/dev/test/AutobahnTestServer to simple WebSocket test.

## Run on Linux

### Setup
Requires DNVM, DNU and DNX (.NET Core RC1).

(https://github.com/aspnet/Docs/blob/df4ef8d01a95a3b3f103a8952af23a1dc6109a13/aspnet/getting-started/installing-on-linux.rst).
### Run
```
cd WebSocketExample/src/WebSocketExample
dnu restore
dnu build
dnx web --server.urls http://$IP:$PORT
```
`$IP` and `$PORT` are environment variables at [Cloud 9 IDE](https://c9.io/) virtual machine. If you use another linux machine or environment, then you should use `dnx web` without parameters or set `$IP` and `$PORT` variables before running `dnx web --server.urls http://$IP:$PORT` (example of set commands: `IP=127.0.0.1`, `PORT=8080`).

`dnx web` without parameters starts server at [http://localhost:5000](http://localhost:5000)

(based on [#1](https://github.com/Konard/ASP.NET-5-CoreCLR-WebSocket-Example/issues/1#issuecomment-154317756))

## Videos of the development process
https://www.youtube.com/playlist?list=PLeYxH0Vd8lotkvykdfCLTWq8ulzEZrStA
