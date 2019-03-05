﻿# WiX Custom Action - Directory Chooser

This is a CustomAction for a WiX Project (v3) which provides a handy dialog to choose a directory. <br />

## Usage

Include the built CA_DirectoryChooser.CA.dll from this project in your own project or use the published nuget (defined in CA_DirectoryChooser/CA_DirectoryChooser.nuspec). <br />

Reference the .dll in your .wxs like so:

`<Binary Id="CA_DirectoryChooser" SourceFile="pathToPackages/CA_DirectoryChooser.X.X.X/lib/net45/CA_DirectoryChooser.CA.dll" />`

* "pathToPackages" could be $(var.SolutionDir)/packages

<br />

And now you can have your CustomAction: <br />

`<CustomAction Id="OpenFileChooser" BinaryKey="CA_DirectoryChooser" DllEntry="OpenFileChooser" />`

* Id can be something different

<br />

Which can now be called in the GUI (Publish element is a child of the Button-Control element) :

`<Control Id="ChangeFolder" Type="PushButton" X="79" Y="158" Width="80" Height="17" Text="Browse">
    <Publish Event="DoAction" Value="OpenFileChooser" Order="1">1</Publish>
    <Publish Property="LOG_PATH" Value="[CHOSEN_DIRECTORY]" Order="2">1</Publish>
</Control>`

After the OpenFileChooser-CustomAction the MSI property "CHOSEN_DIRECTORY" is set to the user-chosen directory.  In the above example it's stored into LOG_PATH to be able to choose another directory later.

## Customize Default Directory

Define the property "CA_DC_OPEN_DIR" (If you use multiple calls, use SetProperty with the attribute Before or After) to define the directory which gets opened at startup.