using KUSYS_Demo.Business.Abstract;
using KUSYS_Demo.Business.Concrete;
using KUSYS_Demo.DataAccess.Abstract;
using KUSYS_Demo.DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependencies Configure
builder.Services.AddScoped<ICourseService, CourseManager>();
builder.Services.AddScoped<ICourseDal, EfCourseDal>();

builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<IStudentDal, EfStudentDal>();

builder.Services.AddScoped<IStudentCourseService, StudentCourseManager>();
builder.Services.AddScoped<IStudentCourseDal, EfStudentCourseDal>();

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
