# MVVMGenericLayout

This is for creating Generic Layout for all cruds inside an application using MVVM pattern.

There are 6 Project used for this basic demonstration.

1) Business Logic is used for faking Database Calls.
2) Application.Windows implements the generic ViewModel. The Generic ViewModel will be used by all Curds View Models For Notification and IDataError Info.
3) DesktopApplication consist of the following Folders
      1) View Model
          1) Base
             1) BaseViewModel (Used for Pagination od DataGrids and filters). Will be used by Cruds as well as reports.
             2) CRUDBaseViewModel (Inherited from BaseViewModel to get Pagination Functionality. Add A few more functionality for adding and Updating Data)
          2)Other folder will be inherited from CRUDBaseViewModel to implement Search and Update Functionality.
      2) User Controls
          1) Custom Control. Currently Consists of Pagination Template.
          2) Generic Layout. Here I have defined my Layout that I want to be in all the CRUDS of application
          3) All Other Folders will be for each CRUD. Each will be using Generic Layout Main Template.
4) Helpers Consists of some generic function that will be used in all projects. Like Image Conversion and stuff like that.
5) Helpers.Windows consists of Generic function which are commonly used in WPF. Like BoolToVisibility converter, EnumToVisibility Converter etc.
6) Models Consists of Fake Database Models.
