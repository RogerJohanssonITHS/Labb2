using ControllerRestDemo.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<StudentContext>(options =>
//{
//    var connectionString =  builder.Configuration.GetConnectionString("WestCoastConnectionString");
//    options.UseSqlServer(connectionString);
//});

builder.Services.AddDbContext<StudentContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("WestCoastConnectionString");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline. __SWAGGER__
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// Configure the HTTP request pipeline. __RAZOR__
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

app.Run();
