using PointFlow.Web.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<AppUserMockRepository>();
builder.Services.AddSingleton<PointTaskMockRepository>();
builder.Services.AddSingleton<RewardMockRepository>();
builder.Services.AddSingleton<CategoryMockRepository>();
builder.Services.AddSingleton<TagMockRepository>();
builder.Services.AddSingleton<PomodoroSessionMockRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
