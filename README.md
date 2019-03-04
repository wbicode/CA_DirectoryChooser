﻿# WiX Custom Action - Directory Chooser

This is a CustomAction for a WiX Project (v3) which provides a handy dialog to choose a directory. <br />

## Usage

Include the built CA_DirectoryChooser.CA.dll from this project in your own project or use the published nuget (defined in CA_DirectoryChooser/CA_DirectoryChooser.nuspec). <br />

Reference the .dll in your .wxs like so:

`<Binary Id="CA_DirectoryChooser" SourceFile="pathToPackages/CA_DirectoryChooser.CA.dll" />`

<br />

And now you can have your CustomAction: <br />

`<CustomAction Id="OpenFileChooser" BinaryKey="CA_DirectoryChooser" DllEntry="OpenFileChooser" />`

<br />

Which could be called in the GUI (Publish element :

`<Publish Event="DoAction" Value="OpenFileChooser" Order="1">1</Publish>`

## Customize Default Directory

Define the property "CA_DC_OPEN_DIR" (If you use multiple calls, use SetProperty with the attribute Before or After)