var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();   // This is for MVC
builder.Services.AddControllers();            // Add this for API support

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ Add API controller mapping here
app.MapControllers();

// ✅ Keep the MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
