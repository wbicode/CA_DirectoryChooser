# WiX Custom Action - Directory Chooser

This is a CustomAction for a WiX Project (v3) which provides a handy dialog to choose a directory. <br />

<img src="https://github.com/wbicode/CA_DirectoryChooser/blob/develop/CA_DirectoryChooser/documentation/example.png?raw=true" alt="" style="float: left; margin-right: 10px;" />

## Usage

Include the built CA_DirectoryChooser.CA.dll from this project in your own project or use the [published nuget](https://www.nuget.org/packages/CA_DirectoryChooser/) (defined in CA_DirectoryChooser/CA_DirectoryChooser.nuspec). <br />

Reference the .dll in your .wxs like so:

```xml
<Binary Id="CA_DirectoryChooser" SourceFile="pathToPackages/CA_DirectoryChooser.X.X.X/lib/net45/CA_DirectoryChooser.CA.dll" />
```

* "pathToPackages" could be $(var.SolutionDir)/packages

<br />

And now you can have your CustomAction: <br />

```xml
<CustomAction Id="OpenFileChooser" BinaryKey="CA_DirectoryChooser" DllEntry="OpenFileChooser" />
```

* Id can be something different

<br />

Which can now be called in the GUI (Publish element is a child of the Button-Control element) :

```xml
<Control Id="ChangeFolder" Type="PushButton" X="79" Y="158" Width="80" Height="17" Text="Browse">
    <Publish Event="DoAction" Value="OpenFileChooser" Order="1">1</Publish>
    <Publish Property="LOG_PATH" Value="[CHOSEN_DIRECTORY]" Order="2">CHOSEN_DIRECTORY</Publish>
</Control>
```

After the OpenFileChooser-CustomAction the MSI property "CHOSEN_DIRECTORY" is set to the user-chosen directory.  In the above example it's stored into LOG_PATH to be able to choose another directory later.

## Customize Default Directory

To define the default directory set the "CA_DC_OPEN_DIR" property. You can use a Publish-Element to set the property before opening each dialog:

```xml
<Control Id="ChangeFolder" Type="PushButton" X="79" Y="158" Width="80" Height="17" Text="Browse">
    <Publish Property="CA_DC_OPEN_DIR" Value="C:\Users\MyUser\Downloads">1</Publish>
    <Publish Event="DoAction" Value="OpenFileChooser" Order="1">1</Publish>
    <Publish Property="LOG_PATH" Value="[CHOSEN_DIRECTORY]" Order="2">CHOSEN_DIRECTORY</Publish>
</Control>
```