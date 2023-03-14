using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddServerSideBlazor().AddCircuitOptions(option =>
{
    option.DetailedErrors = true;
});

builder.Services.AddControllersWithViews();
builder.Services.AddMudServices(options =>
{
    options.PopoverOptions.ThrowOnDuplicateProvider = false;
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
app.MapFallbackToPage("/_Host");
app.MapBlazorHub();

app.Run();
