using POC.Grpc.App.Application.Extensions.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpcClients(builder.Configuration);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();
app.UseExceptionHandler("/Error/Error");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("default", "{controller=Customer}/{action=Index}/{id?}");
app.Run();