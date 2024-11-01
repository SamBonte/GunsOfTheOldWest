var builder = WebApplication.CreateBuilder(args);

// Voeg services toe aan de container
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
var app = builder.Build();

// Configureer de HTTP-request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

// MVC-routes voor controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
