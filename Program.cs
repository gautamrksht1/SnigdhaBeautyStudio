using SnigdhaBeautyStudio.Models;
using SnigdhaBeautyStudio.Services;
using Microsoft.Extensions.Azure;


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<SnigdhaBeautyStudioContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SnigdhaBeautyStudioContext") ?? throw new InvalidOperationException("Connection string 'SnigdhaBeautyStudioContext' not found.")));
builder.Services.AddScoped<IDocTableService, DocTableService>();
builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<SendMessageToServiceBus>();
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["StorageAccountConnectionString:blob"], preferMsi: true);
    clientBuilder.AddQueueServiceClient(builder.Configuration["StorageAccountConnectionString:queue"], preferMsi: true);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
