namespace LivrariaMud.CrossCutting.DependenciesApp;

public static class AddAppIsDevelopment
{
    public static bool IsDevelopment 
        ( this IWebApplication app )
    {
        if ( app.Environment.IsDevelopment() )
        {
            app.UseExceptionHandler( "/Error", createScopeForErrors: true );
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        return app;
    }
}
}
