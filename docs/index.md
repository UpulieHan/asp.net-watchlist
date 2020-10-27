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

If you need to use inputs in your forms, specifying the format and the text area inputs easiest way is to use a helper method
*a0- text input for a model item named Comments
*a1- the number of rows (8)
*a2- the number of columns(0 means the box will fill the width of the available space)
*a3- an anonymous object that represents the HTML attributes applied to the box (the form-control CSS class, an the required attribute)
@Html.TextAreaFor(model => model.Comments, 8, 0, new {
    @class = “form-control”, required = “required” })


Authentication - The process by which your application verifies a user's identity.
Authorization - How you decide what parts of your site you will allow users to acess.

To implement authorization,
Make a list of controllers and controller actions in your application and give each one an access level.
Eg: 
All users
Registered(authenticated) users
Specific types of registered users
Specific users

To debug always use Fn+F5. Selecting debug on the menu doesn't work?

wwwroot container holds all the assets of the project (css files,img,js files,lib)

To add a boostrap template,
1.Extract it
2.Copy the folders inside it
3.Paste them inside wwwroot (although there are previous assets inside it (there's not a lot))
4.Now set up the _Layout.cshtml page so it can be applied to all the other pages in the project .
<!DOCTYPE html>
<html>
<head>
</head>
<body>

    @RenderBody()


    @RenderSection("Scripts", required: false)
</body>
</html>

*We need @RenderBody to render the page in response to the request
*@RenderSection - We need to render a section of code from within any of the pages

5.Now open up the home.html or index.html page from the template folder on an editor.
6. Copy the head of it to the head of the _Layout page
7. Copy the body of home.html (up until Content) and put it right above @RenderBody
8. Skip the Content part on home.html (because @RenderBody will replace that)
9. Copy the code on home.html after Content (the footer part including the script tags, up until the </body>) and paste it after the previous section
10. Now since you've changed the relative location of the html pages and the lib files (such as bootstrap files) you need to map them accordingly.
(Earlier all the assets and sample html files from the template were in the same folder, now they are not (our assets are inside wwwroot and our htmls are inside Views folder))
11. To map locations, go through the whole Layout file and add "~/" infront of all assets that are looking for a location
12. Remove the href="" on the Layout that refer to a sample page in the template
13. @RenderSection.. should be placed right before the ending of the </body> and after the script tags of the template
5.Then set a sample page to see the template in action.
6.Now you need to get into every razor page and add the template.

When building the view model for a particular view,
Although the model is often built in the controller action and passed to the view as a parameter, 
the type defined in the action must match the type defined in the view with the  @model  command.


