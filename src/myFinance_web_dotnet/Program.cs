using myFinance_web_dotnet.Infrastructure;
using myFinance_web_dotnet.Mappers;
using myFinance_web_dotnet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyFinanceDbContext>();


//services
builder.Services.AddTransient<IPlanoContasService, PlanoContaService>();
builder.Services.AddTransient<ITransacaoService, TransacaoService>();
//builder.Services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());
builder.Services.AddAutoMapper(typeof(PlanoContaMap));
builder.Services.AddAutoMapper(typeof(TransacaoMap));
//builder.Services.AddAutoMapper(typeof(Program));

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
