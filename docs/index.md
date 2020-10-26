ASP.NET documentation,
https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1

To Build,
press Ctrl+Shift+B or choose Build > Build Solution

To add a property with {get;set;} in a model class
type "prop" and press tab twice

To scaffold a class (all the CRUD operations/ a complete controller with views using EF)
1.Right click on Controllers folder. Choose Add > New Scaffolded item
2.Pick 'MVC Controller with views, using Entity Framework'. Press Add 
3.Select the model class from which you're going to scaffold the controller and views.
4.Select the database context class
5.Set the controller name
6.Check all three boxes (generate views,reference script libraries (jQuery,Bootstrap),use a layout page)
7.Press Add
8.A new ...Controller.cs file under Controllers folder and a new .... folder under Views folder will be there.

If you only need to scaffold 
for an (empty controller)
1.Right click on Controllers folder. Choose Add > Controller
2.Pick "MVC Controller - Empty"
3. Give a name. Add

for an (empty view)
1.Add a new subfolder withing Views folder.
2.Right click on the new folder. Add > View (New Visual Studio pages MVC View is called Razer Pages(select the second one)).
3.Define the type of views you want.
4.(If you want to display the view whenever it's controller is invoked (default page), name the page as 'Index')
5.Template,Model class, keep Data context class field empty if you don't want to tie this to the DB directly(because data would be in a view model, not in a database model)
6.Make sure 'Create as partial view' is not selected.
7.Check 'reference script libraries' and 'use a layout page'
8.Add

Changes to views can be updated while the app is running.
But changes to controllers/model can only take place after stopping debugging and starting normal development state.
But to enable this feature, you need to
1.Open developer shell (Ctrl + `), type 'dotnet add <name-of-the-project> package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation -v 3.1.0',press enter
2.In startup.cs under the ConfigureServices method, change services.AddRazorPages(); to services.AddRazorPages().AddRazorRuntimeCompilation();

To view the DB created,
1.On VS, View > SQL Server Object Explorer
2. To data on each individual tables, right click on the table > View Data
3. To see the structure of a table, right click on the table > View Code


