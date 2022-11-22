var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //Add

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>                     //Add
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://example.com",
                                              "http://www.contoso.com")
                                               .WithMethods("PUT", "DELETE", "GET");
                      });
});

builder.Services.AddControllers();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();      //Add

app.UseAuthorization();

app.UseEndpoints(endpoints =>    //Add
{
    endpoints.MapGet("/echo",
        context => context.Response.WriteAsync("echo"))
        .RequireCors(MyAllowSpecificOrigins);

    endpoints.MapControllers()
             .RequireCors(MyAllowSpecificOrigins);

    endpoints.MapGet("/echo2",
        context => context.Response.WriteAsync("echo2"));

    endpoints.MapRazorPages();
});

app.Run();