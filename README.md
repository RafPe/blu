<p align="center">
  <img src="Common\logo\blu.png"/>
</p>

# Blu Powershell Service
----------------------
[Reference page on ReadTheDocs](http://backslashblu.readthedocs.io/en/latest/powershell.html)

Blu is a new way to leverage Chef methods in Windows using PowerShell. To use Blu you need a Chef server installed and properly configured in your infrastructure. 
**Blu is a set of Chef client-side tools, following all the methods and concepts, accepted by the Chef community.**


Getting started
---------------

The quickest way to get started with Blu PowerShell service is to get a copy of BluService.exe and BluShell.exe and save it into C:\\Blu folder.
Then register the Windows service by::

    sc create "Blu Powershell Runspace Service" binpath= C:\Blu\BluService.exe
    
Then go to C:\Blu folder and execute a simple PowerShell command using BluShell.exe::

    cd C:\Blu
    BluShell.exe -Command 'Get-Command;'
    
This PowerShell command will show you a list of available commands, and is running in BluShell seamlessly as inside a PowerShell console.   
Now try::

    BluShell.exe -Command "$a = Get-Command;"
    
Then close the powershell session. 
Normally this is going to garbage collect all the objects and variables that are defined in a PowerShell runspace.  
To illustrate how BluService changes this behaviour, start a command prompt again (or a PowerShell session) and execute::

    cd C:\Blu
    BluShell.exe -Command "$a" 
    
As you can see, the variable $a still returns a valid list of all available commands.   
This new PowerShell behavior is extremely useful for PowerShell automation and specially in Chef cookbooks.  
**Blu PowerShell service does not dispose the variables in the current scope unless you dispose them manually.**  
You can also look at Windows event viewer for event id 271, source BluService to monitor what is running under the hood. 

BluStation Screenshots:
-----------------------

Chef API interface:
<p align="center">
  <img src="Docs\source\ui.png"/>
</p>

Transpiler:
<p align="center">
    <img src="Docs\source\transpiler.png"/>
</p>


To know more about many other futures of Blu toolkit, please continue reading: [Blu Documentation](http://backslashblu.readthedocs.io/)
