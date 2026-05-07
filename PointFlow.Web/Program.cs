using Microsoft.EntityFrameworkCore;
using PointFlow.Model;
using PointFlow.Web.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PointFlowDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IQuizRepository, QuizRepository>();

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

// Custom semantic routes
app.MapControllerRoute(
    name: "dashboard",
    pattern: "dashboard",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "tasks",
    pattern: "tasks",
    defaults: new { controller = "Task", action = "Index" });

app.MapControllerRoute(
    name: "task-details",
    pattern: "tasks/{id:int}",
    defaults: new { controller = "Task", action = "Details" });

app.MapControllerRoute(
    name: "categories",
    pattern: "categories",
    defaults: new { controller = "Category", action = "Index" });

app.MapControllerRoute(
    name: "category-details",
    pattern: "categories/{id:int}",
    defaults: new { controller = "Category", action = "Details" });

app.MapControllerRoute(
    name: "quizzes",
    pattern: "quizzes",
    defaults: new { controller = "Quiz", action = "Index" });

app.MapControllerRoute(
    name: "quiz-create",
    pattern: "quizzes/new",
    defaults: new { controller = "Quiz", action = "Create" });

app.MapControllerRoute(
    name: "quiz-details",
    pattern: "quizzes/{id:int}",
    defaults: new { controller = "Quiz", action = "Details" });

app.MapControllerRoute(
    name: "quiz-edit",
    pattern: "quizzes/{id:int}/edit",
    defaults: new { controller = "Quiz", action = "Edit" });

// Default fallback route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
