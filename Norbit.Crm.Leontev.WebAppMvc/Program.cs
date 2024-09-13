namespace Norbit.Crm.Leontev.WebAppMvc
{
    /// <summary>
    /// ������ ���������.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ����� ����� � ���������.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            
            builder.Services.AddHttpClient();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Trade}/{action=Home}/{id?}");

            app.Run();
        }
    }
}
