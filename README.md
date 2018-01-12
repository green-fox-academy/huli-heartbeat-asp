# Huli-Heartbeat-asp

'/heartbeat' endpoint which returns with a JSON. The response contains a http status code and a database connection status. If the dbstatus is true the database is connected, if false the connection is wrong or missing. Only works with .NET Core 2.0.1

To install the heartbeat package you can either use the Nuget Package Manager or the Package Manager Console.

In the Nuget Package Manager search for the HeartBeatMW package.

In the Package manager Console type in the following command:
```
Install-Package HeartBeatMW -Version 1.0.7
```
Next step is to add the HeartBeat Middleware to the StartUp.cs file

```
app.UseHeartBeat();
```

If there is a database in your program you need to pass the Context to the Configure method in the StartUp.cs, and finally you should pass that context to the HeartBeat Middleware as a parameter.

```
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ContextName context)
        {
            app.UseHeartBeat(context);
        }
```
